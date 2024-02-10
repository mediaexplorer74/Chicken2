// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.symbmask_t
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  [Flags]
  internal enum symbmask_t : long
  {
    MASK_NamespaceSymbol = 1,
    MASK_AggregateSymbol = 2,
    MASK_TypeParameterSymbol = 4,
    MASK_FieldSymbol = 8,
    MASK_MethodSymbol = 32, // 0x0000000000000020
    MASK_PropertySymbol = 64, // 0x0000000000000040
    MASK_EventSymbol = 128, // 0x0000000000000080
    MASK_ALL = -1, // 0xFFFFFFFFFFFFFFFF
    MASK_Member = MASK_EventSymbol | MASK_PropertySymbol | MASK_MethodSymbol | MASK_FieldSymbol, // 0x00000000000000E8
  }
}
