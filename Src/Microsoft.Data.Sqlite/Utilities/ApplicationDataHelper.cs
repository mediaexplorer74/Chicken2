// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.Utilities.ApplicationDataHelper
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using System;
using System.Reflection;

#nullable enable
namespace Microsoft.Data.Sqlite.Utilities
{
  internal class ApplicationDataHelper
  {
    private static object? _appData;
    private static string? _localFolder;
    private static string? _tempFolder;

    public static object? CurrentApplicationData
    {
      get
      {
        return ApplicationDataHelper._appData ?? (ApplicationDataHelper._appData = ApplicationDataHelper.LoadAppData());
      }
    }

    public static string? TemporaryFolderPath
    {
      get
      {
        return ApplicationDataHelper._tempFolder ?? (ApplicationDataHelper._tempFolder = ApplicationDataHelper.GetFolderPath("TemporaryFolder"));
      }
    }

    public static string? LocalFolderPath
    {
      get
      {
        return ApplicationDataHelper._localFolder ?? (ApplicationDataHelper._localFolder = ApplicationDataHelper.GetFolderPath("LocalFolder"));
      }
    }

    private static object? LoadAppData()
    {
      try
      {
        object type1 = (object) Type.GetType("Windows.Storage.ApplicationData, Windows, ContentType=WindowsRuntime");
        if (type1 == null)
        {
          Type type2 = Type.GetType("Windows.Storage.ApplicationData, Microsoft.Windows.SDK.NET");
          type1 = (object) type2 != null ? type2.GetRuntimeProperty("Current").GetValue((object) null) : (object) null;
        }
        return type1;
      }
      catch
      {
        return (object) null;
      }
    }

    private static string? GetFolderPath(string propertyName)
    {
      Type type = ApplicationDataHelper.CurrentApplicationData?.GetType();
      object obj = (object) type != null ? type.GetRuntimeProperty(propertyName)?.GetValue(ApplicationDataHelper.CurrentApplicationData) : (object) null;
      return (obj != null ? obj.GetType().GetRuntimeProperty("Path").GetValue(obj) : (object) null) as string;
    }
  }
}
