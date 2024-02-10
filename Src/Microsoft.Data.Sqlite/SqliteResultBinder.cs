// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteResultBinder
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using SQLitePCL;
using System;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal class SqliteResultBinder : SqliteValueBinder
  {
    private readonly sqlite3_context _ctx;

    public SqliteResultBinder(sqlite3_context ctx, object? value)
      : base(value)
    {
      this._ctx = ctx;
    }

    protected override void BindBlob(byte[] value)
    {
      raw.sqlite3_result_blob(this._ctx, (ReadOnlySpan<byte>) value);
    }

    protected override void BindDoubleCore(double value)
    {
      raw.sqlite3_result_double(this._ctx, value);
    }

    protected override void BindInt64(long value) => raw.sqlite3_result_int64(this._ctx, value);

    protected override void BindNull() => raw.sqlite3_result_null(this._ctx);

    protected override void BindText(string value) => raw.sqlite3_result_text(this._ctx, value);
  }
}
