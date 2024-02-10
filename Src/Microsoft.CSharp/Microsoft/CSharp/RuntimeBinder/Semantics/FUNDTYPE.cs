// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.FUNDTYPE
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal enum FUNDTYPE
  {
    FT_NONE = 0,
    FT_I1 = 1,
    FT_I2 = 2,
    FT_I4 = 3,
    FT_U1 = 4,
    FT_U2 = 5,
    FT_LASTNONLONG = 6,
    FT_U4 = 6,
    FT_I8 = 7,
    FT_LASTINTEGRAL = 8,
    FT_U8 = 8,
    FT_R4 = 9,
    FT_LASTNUMERIC = 10, // 0x0000000A
    FT_R8 = 10, // 0x0000000A
    FT_REF = 11, // 0x0000000B
    FT_STRUCT = 12, // 0x0000000C
    FT_PTR = 13, // 0x0000000D
    FT_VAR = 14, // 0x0000000E
    FT_COUNT = 15, // 0x0000000F
  }
}
