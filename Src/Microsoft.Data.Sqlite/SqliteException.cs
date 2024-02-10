// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteException
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System.Data.Common;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteException : DbException
  {
    public SqliteException(string? message, int errorCode)
      : this(message, errorCode, errorCode)
    {
    }

    public SqliteException(string? message, int errorCode, int extendedErrorCode)
      : base(message)
    {
      this.SqliteErrorCode = errorCode;
      this.SqliteExtendedErrorCode = extendedErrorCode;
    }

    public virtual int SqliteErrorCode { get; }

    public virtual int SqliteExtendedErrorCode { get; }

    public static void ThrowExceptionForRC(int rc, sqlite3? db)
    {
      if (rc != 0 && rc != 100 && rc != 101)
      {
        string message;
        int extendedErrorCode;
        if (db == null || db.IsInvalid || rc != raw.sqlite3_errcode(db))
        {
          message = raw.sqlite3_errstr(rc).utf8_to_string() + " " + Resources.DefaultNativeError;
          extendedErrorCode = rc;
        }
        else
        {
          message = raw.sqlite3_errmsg(db).utf8_to_string();
          extendedErrorCode = raw.sqlite3_extended_errcode(db);
        }
        throw new SqliteException(Resources.SqliteNativeError((object) rc, (object) message), rc, extendedErrorCode);
      }
    }
  }
}
