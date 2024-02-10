// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.BinOpMask
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  [Flags]
  internal enum BinOpMask
  {
    None = 0,
    Add = 1,
    Sub = 2,
    Mul = 4,
    Shift = 8,
    Equal = 16, // 0x00000010
    Compare = 32, // 0x00000020
    Bitwise = 64, // 0x00000040
    BitXor = 128, // 0x00000080
    Logical = 256, // 0x00000100
    Integer = BitXor | Bitwise | Compare | Equal | Mul | Sub | Add, // 0x000000F7
    Real = Compare | Equal | Mul | Sub | Add, // 0x00000037
    BoolNorm = BitXor | Equal, // 0x00000090
    Delegate = Equal | Sub | Add, // 0x00000013
    Enum = BoolNorm | Bitwise | Compare | Sub, // 0x000000F2
    EnumUnder = Sub | Add, // 0x00000003
    UnderEnum = Add, // 0x00000001
  }
}
