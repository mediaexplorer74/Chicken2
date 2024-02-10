// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.UnaOpMask
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  [Flags]
  internal enum UnaOpMask
  {
    None = 0,
    Plus = 1,
    Minus = 2,
    Tilde = 4,
    Bang = 8,
    IncDec = 16, // 0x00000010
    Signed = Tilde | Minus | Plus, // 0x00000007
    Unsigned = Tilde | Plus, // 0x00000005
    Real = Minus | Plus, // 0x00000003
    Bool = Bang, // 0x00000008
  }
}
