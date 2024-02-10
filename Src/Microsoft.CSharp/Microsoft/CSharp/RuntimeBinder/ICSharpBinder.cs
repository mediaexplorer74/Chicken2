// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ICSharpBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal interface ICSharpBinder
  {
    CSharpArgumentInfo GetArgumentInfo(int index);

    bool IsBinderThatCanHaveRefReceiver { get; }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    Expr DispatchPayload(
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder runtimeBinder,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals);

    BindingFlag BindingFlags { get; }

    string Name { get; }

    Type ReturnType { get; }

    int GetGetBinderEquivalenceHash();

    bool IsEquivalentTo(ICSharpBinder other);
  }
}
