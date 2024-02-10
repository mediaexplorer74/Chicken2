// Decompiled with JetBrains decompiler
// Type: SQLitePCL.SQLitePCLExtensions
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using System.Collections.Generic;

#nullable enable
namespace SQLitePCL
{
  internal static class SQLitePCLExtensions
  {
    private static readonly Dictionary<string, bool> _knownLibraries = new Dictionary<string, bool>()
    {
      {
        "e_sqlcipher",
        true
      },
      {
        "e_sqlite3",
        false
      },
      {
        "sqlcipher",
        true
      },
      {
        "winsqlite3",
        false
      }
    };

    public static bool? EncryptionSupported()
    {
      return SQLitePCLExtensions.EncryptionSupported(out string _);
    }

    public static bool? EncryptionSupported(out string libraryName)
    {
      libraryName = raw.GetNativeLibraryName();
      bool flag;
      return !SQLitePCLExtensions._knownLibraries.TryGetValue(libraryName, out flag) ? new bool?() : new bool?(flag);
    }
  }
}
