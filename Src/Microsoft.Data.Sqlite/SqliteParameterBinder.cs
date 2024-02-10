// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteParameterBinder
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using SQLitePCL;
using System;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteParameterBinder : SqliteValueBinder
  {
    private readonly sqlite3_stmt _stmt;
    private readonly int _index;
    private readonly int? _size;

    public SqliteParameterBinder(
      sqlite3_stmt stmt,
      int index,
      object value,
      int? size,
      SqliteType? sqliteType)
      : base(value, sqliteType)
    {
      this._stmt = stmt;
      this._index = index;
      this._size = size;
    }

    protected override void BindBlob(byte[] value)
    {
      byte[] numArray = value;
      if (this.ShouldTruncate(value.Length))
      {
        numArray = new byte[this._size.Value];
        Array.Copy((Array) value, (Array) numArray, this._size.Value);
      }
      raw.sqlite3_bind_blob(this._stmt, this._index, (ReadOnlySpan<byte>) numArray);
    }

    protected override void BindDoubleCore(double value)
    {
      raw.sqlite3_bind_double(this._stmt, this._index, value);
    }

    protected override void BindInt64(long value)
    {
      raw.sqlite3_bind_int64(this._stmt, this._index, value);
    }

    protected override void BindNull() => raw.sqlite3_bind_null(this._stmt, this._index);

    protected override void BindText(string value)
    {
      raw.sqlite3_bind_text(this._stmt, this._index, this.ShouldTruncate(value.Length) ? value.Substring(0, this._size.Value) : value);
    }

    private bool ShouldTruncate(int length)
    {
      return this._size.HasValue && length > this._size.Value && this._size.Value != -1;
    }
  }
}
