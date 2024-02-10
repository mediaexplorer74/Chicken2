// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.MemLookFlags
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  [Flags]
  internal enum MemLookFlags : uint
  {
    None = 0,
    Ctor = 2,
    NewObj = 16, // 0x00000010
    Operator = 8,
    Indexer = 4,
    UserCallable = 256, // 0x00000100
    BaseCall = 64, // 0x00000040
    MustBeInvocable = 536870912, // 0x20000000
    All = MustBeInvocable | BaseCall | UserCallable | Indexer | Operator | NewObj | Ctor, // 0x2000015E
  }
}
