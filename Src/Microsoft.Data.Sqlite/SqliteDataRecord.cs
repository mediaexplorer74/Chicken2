// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteDataRecord
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteDataRecord : SqliteValueReader, IDisposable
  {
    private readonly SqliteConnection _connection;
    private byte[][]? _blobCache;
    private int?[]? _typeCache;
    private Dictionary<string, int>? _columnNameOrdinalCache;
    private string[]? _columnNameCache;
    private bool _stepped;
    private int? _rowidOrdinal;

    public SqliteDataRecord(sqlite3_stmt stmt, bool hasRows, SqliteConnection connection)
    {
      this.Handle = stmt;
      this.HasRows = hasRows;
      this._connection = connection;
    }

    public virtual object this[string name] => this.GetValue(this.GetOrdinal(name));

    public virtual object this[int ordinal] => this.GetValue(ordinal);

    public override int FieldCount => raw.sqlite3_column_count(this.Handle);

    public sqlite3_stmt Handle { get; }

    public bool HasRows { get; }

    public override bool IsDBNull(int ordinal)
    {
      if (this._stepped && raw.sqlite3_data_count(this.Handle) != 0)
        return base.IsDBNull(ordinal);
      throw new InvalidOperationException(Resources.NoData);
    }

    public override object GetValue(int ordinal)
    {
      if (this._stepped && raw.sqlite3_data_count(this.Handle) != 0)
        return base.GetValue(ordinal);
      throw new InvalidOperationException(Resources.NoData);
    }

    protected override double GetDoubleCore(int ordinal)
    {
      return raw.sqlite3_column_double(this.Handle, ordinal);
    }

    protected override long GetInt64Core(int ordinal)
    {
      return raw.sqlite3_column_int64(this.Handle, ordinal);
    }

    protected override string GetStringCore(int ordinal)
    {
      return raw.sqlite3_column_text(this.Handle, ordinal).utf8_to_string();
    }

    public override T GetFieldValue<T>(int ordinal)
    {
      if (typeof (T) == typeof (Stream))
        return (T) this.GetStream(ordinal);
      return typeof (T) == typeof (TextReader) ? (T) this.GetTextReader(ordinal) : base.GetFieldValue<T>(ordinal);
    }

    protected override byte[] GetBlob(int ordinal) => base.GetBlob(ordinal);

    protected override byte[] GetBlobCore(int ordinal)
    {
      return raw.sqlite3_column_blob(this.Handle, ordinal).ToArray();
    }

    protected override int GetSqliteType(int ordinal)
    {
      int sqliteType = raw.sqlite3_column_type(this.Handle, ordinal);
      if (sqliteType != 5 || ordinal >= 0 && ordinal < this.FieldCount)
        return sqliteType;
      throw new ArgumentOutOfRangeException(nameof (ordinal), (object) ordinal, (string) null);
    }

    protected override T GetNull<T>(int ordinal)
    {
      if (!(typeof (T) == typeof (DBNull)) && !(typeof (T) == typeof (object)))
        throw new InvalidOperationException(this.GetOnNullErrorMsg(ordinal));
      return (T) DBNull.Value;
    }

    public virtual string GetName(int ordinal)
    {
      string name = this._columnNameCache?[ordinal] ?? raw.sqlite3_column_name(this.Handle, ordinal).utf8_to_string();
      if (name == null && (ordinal < 0 || ordinal >= this.FieldCount))
        throw new ArgumentOutOfRangeException(nameof (ordinal), (object) ordinal, (string) null);
      if (this._columnNameCache == null)
        this._columnNameCache = new string[this.FieldCount];
      this._columnNameCache[ordinal] = name;
      return name;
    }

    public virtual int GetOrdinal(string name)
    {
      if (this._columnNameOrdinalCache == null)
      {
        this._columnNameOrdinalCache = new Dictionary<string, int>();
        for (int ordinal = 0; ordinal < this.FieldCount; ++ordinal)
          this._columnNameOrdinalCache[this.GetName(ordinal)] = ordinal;
      }
      int ordinal1;
      if (this._columnNameOrdinalCache.TryGetValue(name, out ordinal1))
        return ordinal1;
      KeyValuePair<string, int>? nullable = new KeyValuePair<string, int>?();
      foreach (KeyValuePair<string, int> keyValuePair in this._columnNameOrdinalCache)
      {
        if (string.Equals(name, keyValuePair.Key, StringComparison.OrdinalIgnoreCase))
          nullable = !nullable.HasValue ? new KeyValuePair<string, int>?(keyValuePair) : throw new InvalidOperationException(Resources.AmbiguousColumnName((object) name, (object) nullable.Value.Key, (object) keyValuePair.Key));
      }
      if (!nullable.HasValue)
        throw new ArgumentOutOfRangeException(nameof (name), (object) name, (string) null);
      this._columnNameOrdinalCache.Add(name, nullable.Value.Value);
      return nullable.Value.Value;
    }

    public virtual string GetDataTypeName(int ordinal)
    {
      string str = raw.sqlite3_column_decltype(this.Handle, ordinal).utf8_to_string();
      if (str != null)
      {
        int length = str.IndexOf('(');
        return length != -1 ? str.Substring(0, length) : str;
      }
      switch (this.GetSqliteType(ordinal))
      {
        case 1:
          return "INTEGER";
        case 2:
          return "REAL";
        case 3:
          return "TEXT";
        default:
          return "BLOB";
      }
    }

    public virtual Type GetFieldType(int ordinal)
    {
      int sqliteType = this.GetSqliteType(ordinal);
      if (sqliteType == 5)
      {
        sqliteType = (int?) this._typeCache?[ordinal] ?? SqliteDataRecord.Sqlite3AffinityType(this.GetDataTypeName(ordinal));
      }
      else
      {
        if (this._typeCache == null)
          this._typeCache = new int?[this.FieldCount];
        this._typeCache[ordinal] = new int?(sqliteType);
      }
      return SqliteDataRecord.GetFieldTypeFromSqliteType(sqliteType);
    }

    internal static Type GetFieldTypeFromSqliteType(int sqliteType)
    {
      switch (sqliteType)
      {
        case 1:
          return typeof (long);
        case 2:
          return typeof (double);
        case 3:
          return typeof (string);
        default:
          return typeof (byte[]);
      }
    }

    public static Type GetFieldType(string type)
    {
      switch (type)
      {
        case "integer":
          return typeof (long);
        case "real":
          return typeof (double);
        case "text":
          return typeof (string);
        default:
          return typeof (byte[]);
      }
    }

    public virtual long GetBytes(
      int ordinal,
      long dataOffset,
      byte[]? buffer,
      int bufferOffset,
      int length)
    {
      using (Stream stream = this.GetStream(ordinal))
      {
        if (buffer == null)
          return stream.Length;
        stream.Position = dataOffset;
        return (long) stream.Read(buffer, bufferOffset, length);
      }
    }

    public virtual long GetChars(
      int ordinal,
      long dataOffset,
      char[]? buffer,
      int bufferOffset,
      int length)
    {
      using (StreamReader streamReader = new StreamReader(this.GetStream(ordinal), Encoding.UTF8))
      {
        if (buffer == null)
        {
          int chars = 0;
          while (streamReader.Read() != -1)
            ++chars;
          return (long) chars;
        }
        for (int index = 0; (long) index < dataOffset; ++index)
        {
          if (streamReader.Read() == -1)
            throw new ArgumentOutOfRangeException(nameof (dataOffset), (object) dataOffset, (string) null);
        }
        return (long) streamReader.Read(buffer, bufferOffset, length);
      }
    }

    public virtual Stream GetStream(int ordinal)
    {
      string databaseName = ordinal >= 0 && ordinal < this.FieldCount ? raw.sqlite3_column_database_name(this.Handle, ordinal).utf8_to_string() : throw new ArgumentOutOfRangeException(nameof (ordinal), (object) ordinal, (string) null);
      string tableName = raw.sqlite3_column_table_name(this.Handle, ordinal).utf8_to_string();
      if (!this._rowidOrdinal.HasValue)
      {
        this._rowidOrdinal = new int?(-1);
        long num = -1;
        for (int index = 0; index < this.FieldCount; ++index)
        {
          if (index != ordinal)
          {
            string dbName = raw.sqlite3_column_database_name(this.Handle, index).utf8_to_string();
            if (!(dbName != databaseName))
            {
              string tblName = raw.sqlite3_column_table_name(this.Handle, index).utf8_to_string();
              if (!(tblName != tableName))
              {
                string colName = raw.sqlite3_column_origin_name(this.Handle, index).utf8_to_string();
                if (colName == "rowid")
                {
                  this._rowidOrdinal = new int?(index);
                  break;
                }
                string dataType;
                int primaryKey;
                SqliteException.ThrowExceptionForRC(raw.sqlite3_table_column_metadata(this._connection.Handle, dbName, tblName, colName, out dataType, out string _, out int _, out primaryKey, out int _), this._connection.Handle);
                if (string.Equals(dataType, "INTEGER", StringComparison.OrdinalIgnoreCase) && primaryKey != 0)
                {
                  if (num < 0L)
                  {
                    using (SqliteCommand command = this._connection.CreateCommand())
                    {
                      command.CommandText = "SELECT COUNT(*) FROM pragma_table_info($table) WHERE pk != 0;";
                      command.Parameters.AddWithValue("$table", (object) tblName);
                      num = (long) command.ExecuteScalar();
                    }
                  }
                  if (num == 1L)
                  {
                    this._rowidOrdinal = new int?(index);
                    break;
                  }
                }
              }
            }
          }
        }
      }
      if (this._rowidOrdinal.Value < 0)
        return (Stream) new MemoryStream(this.GetCachedBlob(ordinal), false);
      string columnName = raw.sqlite3_column_origin_name(this.Handle, ordinal).utf8_to_string();
      int int32 = this.GetInt32(this._rowidOrdinal.Value);
      return (Stream) new SqliteBlob(this._connection, databaseName, tableName, columnName, (long) int32, true);
    }

    public virtual TextReader GetTextReader(int ordinal)
    {
      return !this.IsDBNull(ordinal) ? (TextReader) new StreamReader(this.GetStream(ordinal), Encoding.UTF8) : (TextReader) new StringReader(string.Empty);
    }

    public bool Read()
    {
      if (!this._stepped)
      {
        this._stepped = true;
        return this.HasRows;
      }
      if (raw.sqlite3_data_count(this.Handle) == 0)
        return false;
      int rc = raw.sqlite3_step(this.Handle);
      SqliteException.ThrowExceptionForRC(rc, this._connection.Handle);
      if (this._blobCache != null)
        Array.Clear((Array) this._blobCache, 0, this._blobCache.Length);
      return rc != 101;
    }

    public void Dispose() => raw.sqlite3_reset(this.Handle);

    private byte[] GetCachedBlob(int ordinal)
    {
      if (ordinal < 0 || ordinal >= this.FieldCount)
        throw new ArgumentOutOfRangeException(nameof (ordinal), (object) ordinal, (string) null);
      byte[] blob = this._blobCache?[ordinal];
      if (blob == null)
      {
        blob = this.GetBlob(ordinal);
        if (this._blobCache == null)
          this._blobCache = new byte[this.FieldCount][];
        this._blobCache[ordinal] = blob;
      }
      return blob;
    }

    internal static int Sqlite3AffinityType(string dataTypeName)
    {
      if (dataTypeName == null)
        return 4;
      return ((IEnumerable<Func<string, int?>>) new Func<string, int?>[4]
      {
        (Func<string, int?>) (name => !SqliteDataRecord.Contains(name, "INT") ? new int?() : new int?(1)),
        (Func<string, int?>) (name => !SqliteDataRecord.Contains(name, "CHAR") && !SqliteDataRecord.Contains(name, "CLOB") && !SqliteDataRecord.Contains(name, "TEXT") ? new int?() : new int?(3)),
        (Func<string, int?>) (name => !SqliteDataRecord.Contains(name, "BLOB") ? new int?() : new int?(4)),
        (Func<string, int?>) (name => !SqliteDataRecord.Contains(name, "REAL") && !SqliteDataRecord.Contains(name, "FLOA") && !SqliteDataRecord.Contains(name, "DOUB") ? new int?() : new int?(2))
      }).Select<Func<string, int?>, int?>((Func<Func<string, int?>, int?>) (r => r(dataTypeName))).FirstOrDefault<int?>((Func<int?, bool>) (r => r.HasValue)) ?? 3;
    }

    private static bool Contains(string haystack, string needle)
    {
      return haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase) >= 0;
    }
  }
}
