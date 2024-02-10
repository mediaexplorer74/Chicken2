// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.CONVERTTYPE
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  [Flags]
  internal enum CONVERTTYPE
  {
    NOUDC = 1,
    STANDARD = 2,
    ISEXPLICIT = 4,
    CHECKOVERFLOW = 8,
    FORCECAST = 16, // 0x00000010
    STANDARDANDNOUDC = STANDARD | NOUDC, // 0x00000003
  }
}
