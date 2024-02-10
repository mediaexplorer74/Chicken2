// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteCommand
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteCommand : DbCommand
  {
    private SqliteParameterCollection? _parameters;
    private readonly List<sqlite3_stmt> _preparedStatements = new List<sqlite3_stmt>();
    private SqliteConnection? _connection;
    private string _commandText = string.Empty;
    private bool _prepared;
    private int? _commandTimeout;

    public SqliteCommand()
    {
    }

    public SqliteCommand(string? commandText) => this.CommandText = commandText;

    public SqliteCommand(string? commandText, SqliteConnection? connection)
      : this(commandText)
    {
      this.Connection = connection;
    }

    public SqliteCommand(
      string? commandText,
      SqliteConnection? connection,
      SqliteTransaction? transaction)
      : this(commandText, connection)
    {
      this.Transaction = transaction;
    }

    public override CommandType CommandType
    {
      get => CommandType.Text;
      set
      {
        if (value != CommandType.Text)
          throw new ArgumentException(Resources.InvalidCommandType((object) value));
      }
    }

    public override string CommandText
    {
      get => this._commandText;
      [param: AllowNull] set
      {
        if (this.DataReader != null)
          throw new InvalidOperationException(Resources.SetRequiresNoOpenReader((object) nameof (CommandText)));
        if (!(value != this._commandText))
          return;
        this.DisposePreparedStatements();
        this._commandText = value ?? string.Empty;
      }
    }

    public virtual SqliteConnection? Connection
    {
      get => this._connection;
      set
      {
        if (this.DataReader != null)
          throw new InvalidOperationException(Resources.SetRequiresNoOpenReader((object) nameof (Connection)));
        if (value == this._connection)
          return;
        this.DisposePreparedStatements();
        this._connection?.RemoveCommand(this);
        this._connection = value;
        value?.AddCommand(this);
      }
    }

    protected override DbConnection? DbConnection
    {
      get => (DbConnection) this.Connection;
      set => this.Connection = (SqliteConnection) value;
    }

    public virtual SqliteTransaction? Transaction { get; set; }

    protected override DbTransaction? DbTransaction
    {
      get => (DbTransaction) this.Transaction;
      set => this.Transaction = (SqliteTransaction) value;
    }

    public virtual SqliteParameterCollection Parameters
    {
      get => this._parameters ?? (this._parameters = new SqliteParameterCollection());
    }

    protected override DbParameterCollection DbParameterCollection
    {
      get => (DbParameterCollection) this.Parameters;
    }

    public override int CommandTimeout
    {
      get
      {
        int? commandTimeout = this._commandTimeout;
        if (commandTimeout.HasValue)
          return commandTimeout.GetValueOrDefault();
        SqliteConnection connection = this._connection;
        return connection == null ? 30 : connection.DefaultTimeout;
      }
      set => this._commandTimeout = new int?(value);
    }

    public override bool DesignTimeVisible { get; set; }

    public override UpdateRowSource UpdatedRowSource { get; set; }

    protected internal virtual SqliteDataReader? DataReader { get; set; }

    protected override void Dispose(bool disposing)
    {
      this.DisposePreparedStatements(disposing);
      if (disposing)
        this._connection?.RemoveCommand(this);
      base.Dispose(disposing);
    }

    public virtual SqliteParameter CreateParameter() => new SqliteParameter();

    protected override DbParameter CreateDbParameter() => (DbParameter) this.CreateParameter();

    public override void Prepare()
    {
      SqliteConnection connection = this._connection;
      if ((connection != null ? (connection.State != ConnectionState.Open ? 1 : 0) : 1) != 0)
        throw new InvalidOperationException(Resources.CallRequiresOpenConnection((object) nameof (Prepare)));
      if (this._prepared)
        return;
      using (IEnumerator<sqlite3_stmt> enumerator = this.PrepareAndEnumerateStatements(new Stopwatch()).GetEnumerator())
      {
        do
          ;
        while (enumerator.MoveNext());
      }
    }

    public virtual SqliteDataReader ExecuteReader() => this.ExecuteReader(CommandBehavior.Default);

    public virtual SqliteDataReader ExecuteReader(CommandBehavior behavior)
    {
      if (this.DataReader != null)
        throw new InvalidOperationException(Resources.DataReaderOpen);
      SqliteConnection connection = this._connection;
      if ((connection != null ? (connection.State != ConnectionState.Open ? 1 : 0) : 1) != 0)
        throw new InvalidOperationException(Resources.CallRequiresOpenConnection((object) nameof (ExecuteReader)));
      if (this.Transaction != this._connection.Transaction)
        throw new InvalidOperationException(this.Transaction == null ? Resources.TransactionRequired : Resources.TransactionConnectionMismatch);
      SqliteTransaction transaction = this._connection.Transaction;
      if ((transaction != null ? (transaction.ExternalRollback ? 1 : 0) : 0) != 0)
        throw new InvalidOperationException(Resources.TransactionCompleted);
      Stopwatch timer = new Stopwatch();
      bool closeConnection = behavior.HasFlag((Enum) CommandBehavior.CloseConnection);
      SqliteDataReader sqliteDataReader = new SqliteDataReader(this, timer, this.GetStatements(timer), closeConnection);
      sqliteDataReader.NextResult();
      return this.DataReader = sqliteDataReader;
    }

    private IEnumerable<sqlite3_stmt> GetStatements(Stopwatch timer)
    {
      foreach (sqlite3_stmt stmt in !this._prepared ? this.PrepareAndEnumerateStatements(timer) : (IEnumerable<sqlite3_stmt>) this._preparedStatements)
      {
        SqliteParameterCollection parameters = this._parameters;
        int num1 = parameters != null ? parameters.Bind(stmt) : 0;
        int num2 = raw.sqlite3_bind_parameter_count(stmt);
        if (num2 != num1)
        {
          List<string> values = new List<string>();
          for (int index = 1; index <= num2; ++index)
          {
            string name = raw.sqlite3_bind_parameter_name(stmt, index).utf8_to_string();
            if (this._parameters != null && !this._parameters.Cast<SqliteParameter>().Any<SqliteParameter>((Func<SqliteParameter, bool>) (p => p.ParameterName == name)))
              values.Add(name);
          }
          if (raw.sqlite3_libversion_number() < 3028000 || raw.sqlite3_stmt_isexplain(stmt) == 0)
            throw new InvalidOperationException(Resources.MissingParameters((object) string.Join(", ", (IEnumerable<string>) values)));
        }
        yield return stmt;
      }
    }

    protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
    {
      return (DbDataReader) this.ExecuteReader(behavior);
    }

    public virtual Task<SqliteDataReader> ExecuteReaderAsync()
    {
      return this.ExecuteReaderAsync(CommandBehavior.Default, CancellationToken.None);
    }

    public virtual Task<SqliteDataReader> ExecuteReaderAsync(CancellationToken cancellationToken)
    {
      return this.ExecuteReaderAsync(CommandBehavior.Default, cancellationToken);
    }

    public virtual Task<SqliteDataReader> ExecuteReaderAsync(CommandBehavior behavior)
    {
      return this.ExecuteReaderAsync(behavior, CancellationToken.None);
    }

    public virtual Task<SqliteDataReader> ExecuteReaderAsync(
      CommandBehavior behavior,
      CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();
      return Task.FromResult<SqliteDataReader>(this.ExecuteReader(behavior));
    }

    protected override async Task<DbDataReader> ExecuteDbDataReaderAsync(
      CommandBehavior behavior,
      CancellationToken cancellationToken)
    {
      return (DbDataReader) await this.ExecuteReaderAsync(behavior, cancellationToken).ConfigureAwait(false);
    }

    public override int ExecuteNonQuery()
    {
      SqliteConnection connection = this._connection;
      if ((connection != null ? (connection.State != ConnectionState.Open ? 1 : 0) : 1) != 0)
        throw new InvalidOperationException(Resources.CallRequiresOpenConnection((object) nameof (ExecuteNonQuery)));
      SqliteDataReader sqliteDataReader = this.ExecuteReader();
      sqliteDataReader.Dispose();
      return sqliteDataReader.RecordsAffected;
    }

    public override object? ExecuteScalar()
    {
      SqliteConnection connection = this._connection;
      if ((connection != null ? (connection.State != ConnectionState.Open ? 1 : 0) : 1) != 0)
        throw new InvalidOperationException(Resources.CallRequiresOpenConnection((object) nameof (ExecuteScalar)));
      using (SqliteDataReader sqliteDataReader = this.ExecuteReader())
        return sqliteDataReader.Read() ? sqliteDataReader.GetValue(0) : (object) null;
    }

    public override void Cancel()
    {
    }

    private IEnumerable<sqlite3_stmt> PrepareAndEnumerateStatements(Stopwatch timer)
    {
      SqliteCommand sqliteCommand = this;
      sqliteCommand.DisposePreparedStatements(false);
      int byteCount = Encoding.UTF8.GetByteCount(sqliteCommand._commandText);
      byte[] sql = new byte[byteCount + 1];
      Encoding.UTF8.GetBytes(sqliteCommand._commandText, 0, sqliteCommand._commandText.Length, sql, 0);
      int start = 0;
      do
      {
        timer.Start();
        sqlite3_stmt stmt;
        ReadOnlySpan<byte> tail;
        int rc;
        while (SqliteCommand.IsBusy(rc = raw.sqlite3_prepare_v2(sqliteCommand._connection.Handle, (ReadOnlySpan<byte>) sql.AsSpan<byte>(start), out stmt, out tail)) && (sqliteCommand.CommandTimeout == 0 || timer.ElapsedMilliseconds < (long) sqliteCommand.CommandTimeout * 1000L))
          Thread.Sleep(150);
        timer.Stop();
        start = sql.Length - tail.Length;
        SqliteException.ThrowExceptionForRC(rc, sqliteCommand._connection.Handle);
        if (stmt.IsInvalid)
        {
          if (start >= byteCount)
            break;
        }
        else
        {
          sqliteCommand._preparedStatements.Add(stmt);
          yield return stmt;
        }
      }
      while (start < byteCount);
      sqliteCommand._prepared = true;
    }

    private void DisposePreparedStatements(bool disposing = true)
    {
      if (disposing && this.DataReader != null)
      {
        this.DataReader.Dispose();
        this.DataReader = (SqliteDataReader) null;
      }
      if (this._preparedStatements != null)
      {
        foreach (SafeHandle preparedStatement in this._preparedStatements)
          preparedStatement.Dispose();
        this._preparedStatements.Clear();
      }
      this._prepared = false;
    }

    private static bool IsBusy(int rc) => rc == 6 || rc == 5 || rc == 262;
  }
}
