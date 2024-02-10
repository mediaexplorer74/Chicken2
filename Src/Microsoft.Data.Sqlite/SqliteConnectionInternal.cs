// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteConnectionInternal
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using SQLitePCL;
using System;
using System.IO;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteConnectionInternal
  {
    private const string DataDirectoryMacro = "|DataDirectory|";
    private readonly sqlite3 _db;
    private readonly WeakReference<SqliteConnection?> _outerConnection = new WeakReference<SqliteConnection>((SqliteConnection) null);
    private SqliteConnectionPool? _pool;
    private volatile bool _active;
    private volatile bool _canBePooled = true;

    public SqliteConnectionInternal(
      SqliteConnectionStringBuilder connectionOptions,
      SqliteConnectionPool? pool = null)
    {
      string str = connectionOptions.DataSource;
      int num = 0;
      if (str.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
        num |= 64;
      int flags;
      switch (connectionOptions.Mode)
      {
        case SqliteOpenMode.ReadWrite:
          flags = num | 2;
          break;
        case SqliteOpenMode.ReadOnly:
          flags = num | 1;
          break;
        case SqliteOpenMode.Memory:
          flags = num | 134;
          if ((flags & 64) == 0)
          {
            flags |= 64;
            str = "file:" + str;
            break;
          }
          break;
        default:
          flags = num | 6;
          break;
      }
      switch (connectionOptions.Cache)
      {
        case SqliteCacheMode.Private:
          flags |= 262144;
          break;
        case SqliteCacheMode.Shared:
          flags |= 131072;
          break;
      }
      string data = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
      if (!string.IsNullOrEmpty(data) && (flags & 64) == 0 && !str.Equals(":memory:", StringComparison.OrdinalIgnoreCase))
      {
        if (str.StartsWith("|DataDirectory|", StringComparison.InvariantCultureIgnoreCase))
          str = Path.Combine(data, str.Substring("|DataDirectory|".Length));
        else if (!Path.IsPathRooted(str))
          str = Path.Combine(data, str);
      }
      SqliteException.ThrowExceptionForRC(raw.sqlite3_open_v2(str, out this._db, flags, (string) null), this._db);
      this._pool = pool;
    }

    public bool Leaked
    {
      get => this._active && !this._outerConnection.TryGetTarget(out SqliteConnection _);
    }

    public bool CanBePooled
    {
      get => this._canBePooled && !this._outerConnection.TryGetTarget(out SqliteConnection _);
    }

    public sqlite3? Handle => this._db;

    public void DoNotPool() => this._canBePooled = false;

    public void Activate(SqliteConnection outerConnection)
    {
      this._active = true;
      this._outerConnection.SetTarget(outerConnection);
    }

    public void Close()
    {
      if (this._pool != null)
        this._pool.Return(this);
      else
        this.Dispose();
    }

    public void Deactivate()
    {
      SqliteConnection target;
      if (this._outerConnection.TryGetTarget(out target))
        target.Deactivate();
      this._outerConnection.SetTarget((SqliteConnection) null);
      this._active = false;
    }

    public void Dispose()
    {
      this._db.Dispose();
      this._pool = (SqliteConnectionPool) null;
    }
  }
}
