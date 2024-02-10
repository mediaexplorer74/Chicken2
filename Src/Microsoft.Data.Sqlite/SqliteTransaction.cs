// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteTransaction
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System;
using System.Data;
using System.Data.Common;
using System.Text;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteTransaction : DbTransaction
  {
    private SqliteConnection? _connection;
    private bool _completed;

    internal SqliteTransaction(
      SqliteConnection connection,
      IsolationLevel isolationLevel,
      bool deferred)
    {
      if (isolationLevel == IsolationLevel.ReadUncommitted && (connection.ConnectionOptions.Cache != SqliteCacheMode.Shared || !deferred) || isolationLevel == IsolationLevel.ReadCommitted || isolationLevel == IsolationLevel.RepeatableRead || isolationLevel == IsolationLevel.Unspecified)
        isolationLevel = IsolationLevel.Serializable;
      this._connection = connection;
      this.IsolationLevel = isolationLevel;
      if (isolationLevel == IsolationLevel.ReadUncommitted)
        connection.ExecuteNonQuery("PRAGMA read_uncommitted = 1;");
      else if (isolationLevel != IsolationLevel.Serializable)
        throw new ArgumentException(Resources.InvalidIsolationLevel((object) isolationLevel));
      connection.ExecuteNonQuery(this.IsolationLevel != IsolationLevel.Serializable || deferred ? "BEGIN;" : "BEGIN IMMEDIATE;");
      raw.sqlite3_rollback_hook(connection.Handle, new delegate_rollback(this.RollbackExternal), (object) null);
    }

    public virtual SqliteConnection? Connection => this._connection;

    protected override DbConnection? DbConnection => (DbConnection) this.Connection;

    internal bool ExternalRollback { get; private set; }

    public override IsolationLevel IsolationLevel { get; }

    public override void Commit()
    {
      if (this.ExternalRollback || this._completed || this._connection.State != ConnectionState.Open)
        throw new InvalidOperationException(Resources.TransactionCompleted);
      raw.sqlite3_rollback_hook(this._connection.Handle, (delegate_rollback) null, (object) null);
      this._connection.ExecuteNonQuery("COMMIT;");
      this.Complete();
    }

    public override void Rollback()
    {
      if (this._completed || this._connection.State != ConnectionState.Open)
        throw new InvalidOperationException(Resources.TransactionCompleted);
      this.RollbackInternal();
    }

    public override bool SupportsSavepoints => true;

    public override void Save(string savepointName)
    {
      if (savepointName == null)
        throw new ArgumentNullException(nameof (savepointName));
      if (this._completed || this._connection.State != ConnectionState.Open)
        throw new InvalidOperationException(Resources.TransactionCompleted);
      this._connection.ExecuteNonQuery(new StringBuilder().Append("SAVEPOINT \"").Append(savepointName.Replace("\"", "\"\"")).Append("\";").ToString());
    }

    public override void Rollback(string savepointName)
    {
      if (savepointName == null)
        throw new ArgumentNullException(nameof (savepointName));
      if (this._completed || this._connection.State != ConnectionState.Open)
        throw new InvalidOperationException(Resources.TransactionCompleted);
      this._connection.ExecuteNonQuery(new StringBuilder().Append("ROLLBACK TO SAVEPOINT \"").Append(savepointName.Replace("\"", "\"\"")).Append("\";").ToString());
    }

    public override void Release(string savepointName)
    {
      if (savepointName == null)
        throw new ArgumentNullException(nameof (savepointName));
      if (this._completed || this._connection.State != ConnectionState.Open)
        throw new InvalidOperationException(Resources.TransactionCompleted);
      this._connection.ExecuteNonQuery(new StringBuilder().Append("RELEASE SAVEPOINT \"").Append(savepointName.Replace("\"", "\"\"")).Append("\";").ToString());
    }

    protected override void Dispose(bool disposing)
    {
      if (!disposing || this._completed || this._connection.State != ConnectionState.Open)
        return;
      this.RollbackInternal();
    }

    private void Complete()
    {
      if (this.IsolationLevel == IsolationLevel.ReadUncommitted)
        this._connection.ExecuteNonQuery("PRAGMA read_uncommitted = 0;");
      this._connection.Transaction = (SqliteTransaction) null;
      this._connection = (SqliteConnection) null;
      this._completed = true;
    }

    private void RollbackInternal()
    {
      if (!this.ExternalRollback)
      {
        raw.sqlite3_rollback_hook(this._connection.Handle, (delegate_rollback) null, (object) null);
        this._connection.ExecuteNonQuery("ROLLBACK;");
      }
      this.Complete();
    }

    private void RollbackExternal(object userData)
    {
      raw.sqlite3_rollback_hook(this._connection.Handle, (delegate_rollback) null, (object) null);
      this.ExternalRollback = true;
    }
  }
}
