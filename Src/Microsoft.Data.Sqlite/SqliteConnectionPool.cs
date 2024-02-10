// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteConnectionPool
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteConnectionPool
  {
    private static readonly Random _random = new Random();
    private readonly SqliteConnectionStringBuilder _connectionOptions;
    private readonly List<SqliteConnectionInternal> _connections = new List<SqliteConnectionInternal>();
    private readonly ConcurrentStack<SqliteConnectionInternal> _warmPool = new ConcurrentStack<SqliteConnectionInternal>();
    private readonly ConcurrentStack<SqliteConnectionInternal> _coldPool = new ConcurrentStack<SqliteConnectionInternal>();
    private readonly Semaphore _poolSemaphore = new Semaphore(0, int.MaxValue);
    private Timer? _pruneTimer;
    private SqliteConnectionPool.State _state;

    public SqliteConnectionPool(SqliteConnectionStringBuilder connectionOptions)
    {
      lock (SqliteConnectionPool._random)
      {
        TimeSpan timeSpan = TimeSpan.FromSeconds((double) (SqliteConnectionPool._random.Next(12, 24) * 10));
        this._pruneTimer = new Timer(new TimerCallback(this.PruneCallback), (object) null, timeSpan, timeSpan);
      }
      this._connectionOptions = connectionOptions;
    }

    public int Count => this._connections.Count;

    public void Shutdown()
    {
      this._state = SqliteConnectionPool.State.Disabled;
      this._pruneTimer?.Dispose();
      this._pruneTimer = (Timer) null;
    }

    public SqliteConnectionInternal GetConnection()
    {
      SqliteConnectionInternal result = (SqliteConnectionInternal) null;
      do
      {
        if (this._poolSemaphore.WaitOne(0))
        {
          if (this._warmPool.TryPop(out result) || this._coldPool.TryPop(out result))
            ;
        }
        else if (this.Count % 2 == 1 || !this.ReclaimLeakedConnections())
        {
          result = new SqliteConnectionInternal(this._connectionOptions, this);
          lock (this._connections)
            this._connections.Add(result);
        }
      }
      while (result == null);
      return result;
    }

    public void Return(SqliteConnectionInternal connection)
    {
      connection.Deactivate();
      if (this._state != SqliteConnectionPool.State.Disabled && connection.CanBePooled)
      {
        this._warmPool.Push(connection);
        this._poolSemaphore.Release();
      }
      else
        this.DisposeConnection(connection);
    }

    public void Clear()
    {
      lock (this._connections)
      {
        foreach (SqliteConnectionInternal connection in this._connections)
          connection.DoNotPool();
      }
      SqliteConnectionInternal result1;
      while (this._warmPool.TryPop(out result1))
        this.DisposeConnection(result1);
      SqliteConnectionInternal result2;
      while (this._coldPool.TryPop(out result2))
        this.DisposeConnection(result2);
      this.ReclaimLeakedConnections();
    }

    private void PruneCallback(object? _)
    {
      while (this.Count > 0 && this._poolSemaphore.WaitOne(0))
      {
        SqliteConnectionInternal result;
        if (this._coldPool.TryPop(out result))
        {
          this.DisposeConnection(result);
        }
        else
        {
          this._poolSemaphore.Release();
          break;
        }
      }
      if (!this._poolSemaphore.WaitOne(0))
        return;
      SqliteConnectionInternal result1;
      while (this._warmPool.TryPop(out result1))
        this._coldPool.Push(result1);
      this._poolSemaphore.Release();
    }

    private void DisposeConnection(SqliteConnectionInternal connection)
    {
      lock (this._connections)
        this._connections.Remove(connection);
      connection.Dispose();
    }

    private bool ReclaimLeakedConnections()
    {
      bool flag = false;
      List<SqliteConnectionInternal> list;
      lock (this._connections)
        list = this._connections.Where<SqliteConnectionInternal>((Func<SqliteConnectionInternal, bool>) (c => c.Leaked)).ToList<SqliteConnectionInternal>();
      foreach (SqliteConnectionInternal connection in list)
      {
        flag = true;
        this.Return(connection);
      }
      return flag;
    }

    private enum State
    {
      Active,
      Disabled,
    }
  }
}
