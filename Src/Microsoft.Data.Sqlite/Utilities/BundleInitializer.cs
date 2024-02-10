// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.Utilities.BundleInitializer
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using SQLitePCL;
using System;
using System.Reflection;

#nullable disable
namespace Microsoft.Data.Sqlite.Utilities
{
  internal static class BundleInitializer
  {
    private const int SQLITE_WIN32_DATA_DIRECTORY_TYPE = 1;
    private const int SQLITE_WIN32_TEMP_DIRECTORY_TYPE = 2;

    public static void Initialize()
    {
      Assembly assembly = (Assembly) null;
      try
      {
        assembly = Assembly.Load(new AssemblyName("SQLitePCLRaw.batteries_v2"));
      }
      catch
      {
      }
      if (assembly != (Assembly) null)
        assembly.GetType("SQLitePCL.Batteries_V2", true).GetMethod("Init", Type.EmptyTypes).Invoke((object) null, (object[]) null);
      if (ApplicationDataHelper.CurrentApplicationData == null)
        return;
      raw.sqlite3_win32_set_directory(1, ApplicationDataHelper.LocalFolderPath);
      raw.sqlite3_win32_set_directory(2, ApplicationDataHelper.TemporaryFolderPath);
    }
  }
}
