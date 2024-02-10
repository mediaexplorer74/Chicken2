// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteConnectionPoolGroup
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteConnectionPoolGroup
  {
    private SqliteConnectionPool? _pool;
    private SqliteConnectionPoolGroup.State _state;

    public SqliteConnectionPoolGroup(
      SqliteConnectionStringBuilder connectionOptions,
      string connectionString,
      bool isNonPooled)
    {
      this.ConnectionOptions = connectionOptions;
      this.ConnectionString = connectionString;
      this.IsNonPooled = isNonPooled;
    }

    public SqliteConnectionStringBuilder ConnectionOptions { get; }

    public string ConnectionString { get; }

    public bool IsNonPooled { get; }

    public bool IsDisabled => this._state == SqliteConnectionPoolGroup.State.Disabled;

    public SqliteConnectionPool? GetPool()
    {
      if (this.IsNonPooled)
      {
        lock (this)
          this.KeepAlive();
        return (SqliteConnectionPool) null;
      }
      if (this._pool == null)
      {
        lock (this)
        {
          if (this._pool == null)
          {
            if (this.KeepAlive())
              this._pool = new SqliteConnectionPool(this.ConnectionOptions);
          }
        }
      }
      return this._pool;
    }

    public bool Clear()
    {
      lock (this)
      {
        if (this._pool != null)
        {
          SqliteConnectionFactory.Instance.ReleasePool(this._pool, true);
          this._pool = (SqliteConnectionPool) null;
        }
      }
      return this._pool != null;
    }

    public bool Prune()
    {
      lock (this)
      {
        SqliteConnectionPool pool = this._pool;
        if ((pool != null ? (pool.Count == 0 ? 1 : 0) : 0) != 0)
        {
          SqliteConnectionFactory.Instance.ReleasePool(this._pool, false);
          this._pool = (SqliteConnectionPool) null;
        }
        if (this._pool == null)
        {
          if (this._state == SqliteConnectionPoolGroup.State.Active)
            this._state = SqliteConnectionPoolGroup.State.Idle;
          else if (this._state == SqliteConnectionPoolGroup.State.Idle)
            this._state = SqliteConnectionPoolGroup.State.Disabled;
        }
        return this._state == SqliteConnectionPoolGroup.State.Disabled;
      }
    }

    private bool KeepAlive()
    {
      if (this._state == SqliteConnectionPoolGroup.State.Idle)
        this._state = SqliteConnectionPoolGroup.State.Active;
      return this._state == SqliteConnectionPoolGroup.State.Active;
    }

    private enum State
    {
      Active,
      Idle,
      Disabled,
    }
  }
}
