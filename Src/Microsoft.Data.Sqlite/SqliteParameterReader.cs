// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteParameterReader
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteParameterReader : SqliteValueReader
  {
    private readonly string _function;
    private readonly sqlite3_value[] _values;

    public SqliteParameterReader(string function, sqlite3_value[] values)
    {
      this._function = function;
      this._values = values;
    }

    public override int FieldCount => this._values.Length;

    protected override string GetOnNullErrorMsg(int ordinal)
    {
      return Resources.UDFCalledWithNull((object) this._function, (object) ordinal);
    }

    protected override double GetDoubleCore(int ordinal)
    {
      return raw.sqlite3_value_double(this._values[ordinal]);
    }

    protected override long GetInt64Core(int ordinal)
    {
      return raw.sqlite3_value_int64(this._values[ordinal]);
    }

    protected override string GetStringCore(int ordinal)
    {
      return raw.sqlite3_value_text(this._values[ordinal]).utf8_to_string();
    }

    protected override byte[] GetBlobCore(int ordinal)
    {
      return raw.sqlite3_value_blob(this._values[ordinal]).ToArray();
    }

    protected override int GetSqliteType(int ordinal)
    {
      return raw.sqlite3_value_type(this._values[ordinal]);
    }
  }
}
