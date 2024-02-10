// Decompiled with JetBrains decompiler
// Type: System.TypeExtensions
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

#nullable enable
namespace System
{
  internal static class TypeExtensions
  {
    public static bool IsNullable(this Type type)
    {
      if (!type.IsValueType)
        return true;
      return type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>);
    }

    public static Type UnwrapEnumType(this Type type)
    {
      return !type.IsEnum ? type : Enum.GetUnderlyingType(type);
    }

    public static Type UnwrapNullableType(this Type type)
    {
      Type underlyingType = Nullable.GetUnderlyingType(type);
      return (object) underlyingType != null ? underlyingType : type;
    }
  }
}
