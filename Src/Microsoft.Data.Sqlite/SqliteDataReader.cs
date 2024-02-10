// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteDataReader
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteDataReader : DbDataReader
  {
    private readonly SqliteCommand _command;
    private readonly bool _closeConnection;
    private readonly Stopwatch _timer;
    private IEnumerator<sqlite3_stmt>? _stmtEnumerator;
    private SqliteDataRecord? _record;
    private bool _closed;
    private int _recordsAffected = -1;

    internal SqliteDataReader(
      SqliteCommand command,
      Stopwatch timer,
      IEnumerable<sqlite3_stmt> stmts,
      bool closeConnection)
    {
      this._command = command;
      this._timer = timer;
      this._stmtEnumerator = stmts.GetEnumerator();
      this._closeConnection = closeConnection;
    }

    public override int Depth => 0;

    public override int FieldCount
    {
      get
      {
        if (this._closed)
          throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (FieldCount)));
        SqliteDataRecord record = this._record;
        return record == null ? 0 : record.FieldCount;
      }
    }

    public virtual sqlite3_stmt? Handle => this._record?.Handle;

    public override bool HasRows
    {
      get
      {
        SqliteDataRecord record = this._record;
        return record != null && record.HasRows;
      }
    }

    public override bool IsClosed => this._closed;

    public override int RecordsAffected => this._recordsAffected;

    public override object this[string name]
    {
      get
      {
        return this._record != null ? this._record[name] : throw new InvalidOperationException(Resources.NoData);
      }
    }

    public override object this[int ordinal]
    {
      get
      {
        return this._record != null ? this._record[ordinal] : throw new InvalidOperationException(Resources.NoData);
      }
    }

    public override IEnumerator GetEnumerator()
    {
      return (IEnumerator) new DbEnumerator((DbDataReader) this, false);
    }

    public override bool Read()
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (Read)));
      SqliteDataRecord record = this._record;
      return record != null && record.Read();
    }

    public override bool NextResult()
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (NextResult)));
      if (this._record != null)
      {
        this._record.Dispose();
        this._record = (SqliteDataRecord) null;
      }
      while (this._stmtEnumerator.MoveNext())
      {
        try
        {
          sqlite3_stmt current = this._stmtEnumerator.Current;
          this._timer.Start();
          int rc;
          while (SqliteDataReader.IsBusy(rc = raw.sqlite3_step(current)) && (this._command.CommandTimeout == 0 || this._timer.ElapsedMilliseconds < (long) this._command.CommandTimeout * 1000L))
          {
            raw.sqlite3_reset(current);
            Thread.Sleep(150);
          }
          this._timer.Stop();
          SqliteException.ThrowExceptionForRC(rc, this._command.Connection.Handle);
          if (raw.sqlite3_column_count(current) != 0)
          {
            this._record = new SqliteDataRecord(current, rc != 101, this._command.Connection);
            return true;
          }
          while (rc != 101)
          {
            rc = raw.sqlite3_step(current);
            SqliteException.ThrowExceptionForRC(rc, this._command.Connection.Handle);
          }
          raw.sqlite3_reset(current);
          int num = raw.sqlite3_changes(this._command.Connection.Handle);
          if (this._recordsAffected == -1)
            this._recordsAffected = num;
          else
            this._recordsAffected += num;
        }
        catch
        {
          raw.sqlite3_reset(this._stmtEnumerator.Current);
          this._stmtEnumerator.Dispose();
          this._stmtEnumerator = (IEnumerator<sqlite3_stmt>) null;
          this.Dispose();
          throw;
        }
      }
      return false;
    }

    private static bool IsBusy(int rc) => rc == 6 || rc == 5 || rc == 262;

    public override void Close() => this.Dispose(true);

    protected override void Dispose(bool disposing)
    {
      if (!disposing || this._closed)
        return;
      this._command.DataReader = (SqliteDataReader) null;
      this._record?.Dispose();
      if (this._stmtEnumerator != null)
      {
        try
        {
          while (this.NextResult())
            this._record.Dispose();
        }
        catch
        {
        }
      }
      this._stmtEnumerator?.Dispose();
      this._closed = true;
      if (!this._closeConnection)
        return;
      this._command.Connection.Close();
    }

    public override string GetName(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetName)));
      return this._record != null ? this._record.GetName(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override int GetOrdinal(string name)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetOrdinal)));
      return this._record != null ? this._record.GetOrdinal(name) : throw new InvalidOperationException(Resources.NoData);
    }

    public override string GetDataTypeName(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetDataTypeName)));
      return this._record != null ? this._record.GetDataTypeName(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override Type GetFieldType(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetFieldType)));
      return this._record != null ? this._record.GetFieldType(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override bool IsDBNull(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (IsDBNull)));
      return this._record != null ? this._record.IsDBNull(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override bool GetBoolean(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetBoolean)));
      return this._record != null ? this._record.GetBoolean(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override byte GetByte(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetByte)));
      return this._record != null ? this._record.GetByte(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override char GetChar(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetChar)));
      return this._record != null ? this._record.GetChar(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override DateTime GetDateTime(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetDateTime)));
      return this._record != null ? this._record.GetDateTime(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public virtual DateTimeOffset GetDateTimeOffset(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetDateTimeOffset)));
      return this._record != null ? this._record.GetDateTimeOffset(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public virtual TimeSpan GetTimeSpan(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetTimeSpan)));
      return this._record != null ? this._record.GetTimeSpan(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override Decimal GetDecimal(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetDecimal)));
      return this._record != null ? this._record.GetDecimal(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override double GetDouble(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetDouble)));
      return this._record != null ? this._record.GetDouble(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override float GetFloat(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetFloat)));
      return this._record != null ? this._record.GetFloat(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override Guid GetGuid(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetGuid)));
      return this._record != null ? this._record.GetGuid(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override short GetInt16(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetInt16)));
      return this._record != null ? this._record.GetInt16(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override int GetInt32(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetInt32)));
      return this._record != null ? this._record.GetInt32(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override long GetInt64(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetInt64)));
      return this._record != null ? this._record.GetInt64(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override string GetString(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetString)));
      return this._record != null ? this._record.GetString(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override long GetBytes(
      int ordinal,
      long dataOffset,
      byte[]? buffer,
      int bufferOffset,
      int length)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetBytes)));
      if (this._record != null)
        return this._record.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
      throw new InvalidOperationException(Resources.NoData);
    }

    public override long GetChars(
      int ordinal,
      long dataOffset,
      char[]? buffer,
      int bufferOffset,
      int length)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetChars)));
      if (this._record != null)
        return this._record.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
      throw new InvalidOperationException(Resources.NoData);
    }

    public override Stream GetStream(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetStream)));
      return this._record != null ? this._record.GetStream(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override TextReader GetTextReader(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetTextReader)));
      return this._record != null ? this._record.GetTextReader(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override T GetFieldValue<T>(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetFieldValue)));
      return this._record != null ? this._record.GetFieldValue<T>(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override object GetValue(int ordinal)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetValue)));
      return this._record != null ? this._record.GetValue(ordinal) : throw new InvalidOperationException(Resources.NoData);
    }

    public override int GetValues(object?[] values)
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetValues)));
      return this._record != null ? this._record.GetValues(values) : throw new InvalidOperationException(Resources.NoData);
    }

    public override DataTable GetSchemaTable()
    {
      if (this._closed)
        throw new InvalidOperationException(Resources.DataReaderClosed((object) nameof (GetSchemaTable)));
      if (this._record == null)
        throw new InvalidOperationException(Resources.NoData);
      DataTable schemaTable = new DataTable("SchemaTable");
      DataColumn column1 = new DataColumn(SchemaTableColumn.ColumnName, typeof (string));
      DataColumn column2 = new DataColumn(SchemaTableColumn.ColumnOrdinal, typeof (int));
      DataColumn column3 = new DataColumn(SchemaTableColumn.ColumnSize, typeof (int));
      DataColumn column4 = new DataColumn(SchemaTableColumn.NumericPrecision, typeof (short));
      DataColumn column5 = new DataColumn(SchemaTableColumn.NumericScale, typeof (short));
      DataColumn column6 = new DataColumn(SchemaTableColumn.DataType, typeof (Type));
      DataColumn column7 = new DataColumn("DataTypeName", typeof (string));
      DataColumn column8 = new DataColumn(SchemaTableColumn.IsLong, typeof (bool));
      DataColumn column9 = new DataColumn(SchemaTableColumn.AllowDBNull, typeof (bool));
      DataColumn column10 = new DataColumn(SchemaTableColumn.IsUnique, typeof (bool));
      DataColumn column11 = new DataColumn(SchemaTableColumn.IsKey, typeof (bool));
      DataColumn column12 = new DataColumn(SchemaTableOptionalColumn.IsAutoIncrement, typeof (bool));
      DataColumn column13 = new DataColumn(SchemaTableOptionalColumn.BaseCatalogName, typeof (string));
      DataColumn column14 = new DataColumn(SchemaTableColumn.BaseSchemaName, typeof (string));
      DataColumn column15 = new DataColumn(SchemaTableColumn.BaseTableName, typeof (string));
      DataColumn column16 = new DataColumn(SchemaTableColumn.BaseColumnName, typeof (string));
      DataColumn column17 = new DataColumn(SchemaTableOptionalColumn.BaseServerName, typeof (string));
      DataColumn column18 = new DataColumn(SchemaTableColumn.IsAliased, typeof (bool));
      DataColumn column19 = new DataColumn(SchemaTableColumn.IsExpression, typeof (bool));
      DataColumnCollection columns = schemaTable.Columns;
      columns.Add(column1);
      columns.Add(column2);
      columns.Add(column3);
      columns.Add(column4);
      columns.Add(column5);
      columns.Add(column10);
      columns.Add(column11);
      columns.Add(column17);
      columns.Add(column13);
      columns.Add(column16);
      columns.Add(column14);
      columns.Add(column15);
      columns.Add(column6);
      columns.Add(column7);
      columns.Add(column9);
      columns.Add(column18);
      columns.Add(column19);
      columns.Add(column12);
      columns.Add(column8);
      for (int index = 0; index < this.FieldCount; ++index)
      {
        DataRow row = schemaTable.NewRow();
        row[column1] = (object) this.GetName(index);
        row[column2] = (object) index;
        row[column3] = (object) -1;
        row[column4] = (object) DBNull.Value;
        row[column5] = (object) DBNull.Value;
        row[column17] = (object) this._command.Connection.DataSource;
        utf8z utf8z = raw.sqlite3_column_database_name(this._record.Handle, index);
        string dbName = utf8z.utf8_to_string();
        row[column13] = (object) dbName;
        utf8z = raw.sqlite3_column_origin_name(this._record.Handle, index);
        string colName = utf8z.utf8_to_string();
        row[column16] = (object) colName;
        row[column14] = (object) DBNull.Value;
        utf8z = raw.sqlite3_column_table_name(this._record.Handle, index);
        string tblName = utf8z.utf8_to_string();
        row[column15] = (object) tblName;
        row[column6] = (object) this.GetFieldType(index);
        string dataTypeName = this.GetDataTypeName(index);
        row[column7] = (object) dataTypeName;
        row[column18] = (object) (colName != this.GetName(index));
        row[column19] = (object) (colName == null);
        row[column8] = (object) DBNull.Value;
        bool flag = false;
        if (tblName != null && colName != null)
        {
          using (SqliteCommand command = this._command.Connection.CreateCommand())
          {
            command.CommandText = new StringBuilder().AppendLine("SELECT COUNT(*)").AppendLine("FROM pragma_index_list($table) i, pragma_index_info(i.name) c").AppendLine("WHERE \"unique\" = 1 AND c.name = $column AND").AppendLine("NOT EXISTS (SELECT * FROM pragma_index_info(i.name) c2 WHERE c2.name != c.name);").ToString();
            command.Parameters.AddWithValue("$table", (object) tblName);
            command.Parameters.AddWithValue("$column", (object) colName);
            long num = (long) command.ExecuteScalar();
            row[column10] = (object) (num != 0L);
            command.Parameters.Clear();
            string str1 = "typeof(\"" + colName.Replace("\"", "\"\"") + "\")";
            SqliteCommand sqliteCommand = command;
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = stringBuilder1;
            StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler1 = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder1);
            interpolatedStringHandler1.AppendLiteral("SELECT ");
            interpolatedStringHandler1.AppendFormatted(str1);
            ref StringBuilder.AppendInterpolatedStringHandler local1 = ref interpolatedStringHandler1;
            StringBuilder stringBuilder3 = stringBuilder2.AppendLine(ref local1);
            StringBuilder stringBuilder4 = stringBuilder3;
            StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler2 = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder3);
            interpolatedStringHandler2.AppendLiteral("FROM \"");
            interpolatedStringHandler2.AppendFormatted(tblName);
            interpolatedStringHandler2.AppendLiteral("\"");
            ref StringBuilder.AppendInterpolatedStringHandler local2 = ref interpolatedStringHandler2;
            StringBuilder stringBuilder5 = stringBuilder4.AppendLine(ref local2);
            StringBuilder stringBuilder6 = stringBuilder5;
            StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler3 = new StringBuilder.AppendInterpolatedStringHandler(16, 1, stringBuilder5);
            interpolatedStringHandler3.AppendLiteral("WHERE ");
            interpolatedStringHandler3.AppendFormatted(str1);
            interpolatedStringHandler3.AppendLiteral(" != 'null'");
            ref StringBuilder.AppendInterpolatedStringHandler local3 = ref interpolatedStringHandler3;
            StringBuilder stringBuilder7 = stringBuilder6.AppendLine(ref local3);
            StringBuilder stringBuilder8 = stringBuilder7;
            StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler4 = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder7);
            interpolatedStringHandler4.AppendLiteral("GROUP BY ");
            interpolatedStringHandler4.AppendFormatted(str1);
            ref StringBuilder.AppendInterpolatedStringHandler local4 = ref interpolatedStringHandler4;
            string str2 = stringBuilder8.AppendLine(ref local4).AppendLine("ORDER BY count() DESC").AppendLine("LIMIT 1;").ToString();
            sqliteCommand.CommandText = str2;
            string type = (string) command.ExecuteScalar();
            row[column6] = type != null ? (object) SqliteDataRecord.GetFieldType(type) : (object) SqliteDataRecord.GetFieldTypeFromSqliteType(SqliteDataRecord.Sqlite3AffinityType(dataTypeName));
            command.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE name = $name AND type IN ('table', 'view')";
            command.Parameters.AddWithValue("$name", (object) tblName);
            flag = (long) command.ExecuteScalar() == 0L;
          }
          if (dbName != null && !flag)
          {
            int notNull;
            int primaryKey;
            int autoInc;
            SqliteException.ThrowExceptionForRC(raw.sqlite3_table_column_metadata(this._command.Connection.Handle, dbName, tblName, colName, out string _, out string _, out notNull, out primaryKey, out autoInc), this._command.Connection.Handle);
            row[column11] = (object) (primaryKey != 0);
            row[column9] = (object) (notNull == 0);
            row[column12] = (object) (autoInc != 0);
          }
        }
        schemaTable.Rows.Add(row);
      }
      return schemaTable;
    }
  }
}
