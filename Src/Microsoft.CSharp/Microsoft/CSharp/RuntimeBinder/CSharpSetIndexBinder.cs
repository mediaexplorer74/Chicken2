// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpSetIndexBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.ComInterop;
using Microsoft.CSharp.RuntimeBinder.Semantics;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Numerics.Hashing;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal sealed class CSharpSetIndexBinder : SetIndexBinder, ICSharpBinder
  {
    private readonly CSharpArgumentInfo[] _argumentInfo;
    private readonly Microsoft.CSharp.RuntimeBinder.RuntimeBinder _binder;
    private readonly Type _callingContext;

    public string Name => "$Item$";

    public BindingFlag BindingFlags => (BindingFlag) 0;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr DispatchPayload(
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder runtimeBinder,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      return runtimeBinder.BindAssignment((ICSharpBinder) this, arguments, locals);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
    {
      SymbolTable.PopulateSymbolTableWithName("$Item$", (IEnumerable<Type>) null, arguments[0].Type);
    }

    public bool IsBinderThatCanHaveRefReceiver => true;

    internal bool IsCompoundAssignment { get; }

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => this._argumentInfo[index];

    private bool IsChecked => this._binder.IsChecked;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpSetIndexBinder(
      bool isCompoundAssignment,
      bool isChecked,
      Type callingContext,
      IEnumerable<CSharpArgumentInfo> argumentInfo)
      : base(BinderHelper.CreateCallInfo(ref argumentInfo, 2))
    {
      this.IsCompoundAssignment = isCompoundAssignment;
      this._argumentInfo = argumentInfo as CSharpArgumentInfo[];
      this._callingContext = callingContext;
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext, isChecked);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      int num = (object) callingContext != null ? callingContext.GetHashCode() : 0;
      if (this.IsChecked)
        num = HashHelpers.Combine(num, 1);
      if (this.IsCompoundAssignment)
        num = HashHelpers.Combine(num, 1);
      return BinderHelper.AddArgHashes(num, this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpSetIndexBinder csharpSetIndexBinder && !(this._callingContext != csharpSetIndexBinder._callingContext) && this.IsChecked == csharpSetIndexBinder.IsChecked && this.IsCompoundAssignment == csharpSetIndexBinder.IsCompoundAssignment && this._argumentInfo.Length == csharpSetIndexBinder._argumentInfo.Length && BinderHelper.CompareArgInfos(this._argumentInfo, csharpSetIndexBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackSetIndex(
      DynamicMetaObject target,
      DynamicMetaObject[] indexes,
      DynamicMetaObject value,
      DynamicMetaObject errorSuggestion)
    {
      DynamicMetaObject result;
      if (ComBinder.TryBindSetIndex((SetIndexBinder) this, target, indexes, value, out result))
        return result;
      BinderHelper.ValidateBindArgument(target, nameof (target));
      BinderHelper.ValidateBindArgument(indexes, nameof (indexes));
      BinderHelper.ValidateBindArgument(value, nameof (value));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, BinderHelper.Cons<DynamicMetaObject>(target, indexes, value), (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, errorSuggestion);
    }
  }
}
