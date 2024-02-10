// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteConnectionFactory
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using System;
using System.Collections.Generic;
using System.Threading;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteConnectionFactory
  {
    public static readonly SqliteConnectionFactory Instance = new SqliteConnectionFactory();
    private readonly bool _newLockingBehavior;
    private readonly Timer _pruneTimer;
    private readonly List<SqliteConnectionPoolGroup> _idlePoolGroups = new List<SqliteConnectionPoolGroup>();
    private readonly List<SqliteConnectionPool> _poolsToRelease = new List<SqliteConnectionPool>();
    private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    private Dictionary<string, SqliteConnectionPoolGroup> _poolGroups = new Dictionary<string, SqliteConnectionPoolGroup>();

    protected SqliteConnectionFactory()
    {
      bool isEnabled;
      this._newLockingBehavior = !AppContext.TryGetSwitch("Microsoft.Data.Sqlite.Issue26612", out isEnabled) || !isEnabled;
      if (!AppContext.TryGetSwitch("Microsoft.Data.Sqlite.Issue26422", out isEnabled) || !isEnabled)
      {
        AppDomain.CurrentDomain.DomainUnload += (EventHandler) ((_1, _2) => this.ClearPools());
        AppDomain.CurrentDomain.ProcessExit += (EventHandler) ((_3, _4) => this.ClearPools());
      }
      this._pruneTimer = new Timer(new TimerCallback(this.PruneCallback), (object) null, TimeSpan.FromMinutes(4.0), TimeSpan.FromSeconds(30.0));
    }

    public SqliteConnectionInternal GetConnection(SqliteConnection outerConnection)
    {
      SqliteConnectionPoolGroup poolGroup = outerConnection.PoolGroup;
      if (poolGroup.IsDisabled && !poolGroup.IsNonPooled)
      {
        poolGroup = this.GetPoolGroup(poolGroup.ConnectionString);
        outerConnection.PoolGroup = poolGroup;
      }
      SqliteConnectionPool pool = poolGroup.GetPool();
      SqliteConnectionInternal connection = pool == null ? new SqliteConnectionInternal(outerConnection.ConnectionOptions) : pool.GetConnection();
      connection.Activate(outerConnection);
      return connection;
    }

    public SqliteConnectionPoolGroup GetPoolGroup(string connectionString)
    {
      if (this._newLockingBehavior)
        this._lock.EnterUpgradeableReadLock();
      try
      {
        SqliteConnectionPoolGroup poolGroup;
        if (!this._poolGroups.TryGetValue(connectionString, out poolGroup) || poolGroup.IsDisabled && !poolGroup.IsNonPooled)
        {
          SqliteConnectionStringBuilder connectionOptions = new SqliteConnectionStringBuilder(connectionString);
          if (this._newLockingBehavior)
            this._lock.EnterWriteLock();
          else
            Monitor.Enter((object) this);
          try
          {
            if (!this._poolGroups.TryGetValue(connectionString, out poolGroup))
            {
              bool isNonPooled = connectionOptions.DataSource == ":memory:" || connectionOptions.Mode == SqliteOpenMode.Memory || connectionOptions.DataSource.Length == 0 || !connectionOptions.Pooling;
              poolGroup = new SqliteConnectionPoolGroup(connectionOptions, connectionString, isNonPooled);
              this._poolGroups.Add(connectionString, poolGroup);
            }
          }
          finally
          {
            if (this._newLockingBehavior)
              this._lock.ExitWriteLock();
            else
              Monitor.Exit((object) this);
          }
        }
        return poolGroup;
      }
      finally
      {
        if (this._newLockingBehavior)
          this._lock.ExitUpgradeableReadLock();
      }
    }

    public void ReleasePool(SqliteConnectionPool pool, bool clearing)
    {
      pool.Shutdown();
      lock (this._poolsToRelease)
      {
        if (clearing)
          pool.Clear();
        this._poolsToRelease.Add(pool);
      }
    }

    public void ClearPools()
    {
      if (this._newLockingBehavior)
        this._lock.EnterWriteLock();
      else
        Monitor.Enter((object) this);
      try
      {
        foreach (KeyValuePair<string, SqliteConnectionPoolGroup> poolGroup in this._poolGroups)
          poolGroup.Value.Clear();
      }
      finally
      {
        if (this._newLockingBehavior)
          this._lock.ExitWriteLock();
        else
          Monitor.Exit((object) this);
      }
    }

    private void PruneCallback(object? _)
    {
      lock (this._poolsToRelease)
      {
        for (int index = this._poolsToRelease.Count - 1; index >= 0; --index)
        {
          SqliteConnectionPool sqliteConnectionPool = this._poolsToRelease[index];
          sqliteConnectionPool.Clear();
          if (sqliteConnectionPool.Count == 0)
            this._poolsToRelease.Remove(sqliteConnectionPool);
        }
      }
      for (int index = this._idlePoolGroups.Count - 1; index >= 0; --index)
      {
        SqliteConnectionPoolGroup idlePoolGroup = this._idlePoolGroups[index];
        if (!idlePoolGroup.Clear())
          this._idlePoolGroups.Remove(idlePoolGroup);
      }
      if (this._newLockingBehavior)
        this._lock.EnterWriteLock();
      else
        Monitor.Enter((object) this);
      try
      {
        Dictionary<string, SqliteConnectionPoolGroup> dictionary = new Dictionary<string, SqliteConnectionPoolGroup>();
        foreach (KeyValuePair<string, SqliteConnectionPoolGroup> poolGroup in this._poolGroups)
        {
          SqliteConnectionPoolGroup connectionPoolGroup = poolGroup.Value;
          if (connectionPoolGroup.Prune())
            this._idlePoolGroups.Add(connectionPoolGroup);
          else
            dictionary.Add(poolGroup.Key, connectionPoolGroup);
        }
        this._poolGroups = dictionary;
      }
      finally
      {
        if (this._newLockingBehavior)
          this._lock.ExitWriteLock();
        else
          Monitor.Exit((object) this);
      }
    }
  }
}
