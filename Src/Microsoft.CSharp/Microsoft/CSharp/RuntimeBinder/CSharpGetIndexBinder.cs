// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpGetIndexBinder
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

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal sealed class CSharpGetIndexBinder : GetIndexBinder, ICSharpBinder
  {
    private readonly CSharpArgumentInfo[] _argumentInfo;
    private readonly Microsoft.CSharp.RuntimeBinder.RuntimeBinder _binder;
    private readonly Type _callingContext;

    public string Name => "$Item$";

    public BindingFlag BindingFlags => BindingFlag.BIND_RVALUEREQUIRED;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr DispatchPayload(
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder runtimeBinder,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      Expr argumentListExpr = runtimeBinder.CreateArgumentListEXPR(arguments, locals, 1, arguments.Length);
      return runtimeBinder.BindProperty((ICSharpBinder) this, arguments[0], locals[0], argumentListExpr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
    {
      SymbolTable.PopulateSymbolTableWithName("$Item$", (IEnumerable<Type>) null, arguments[0].Type);
    }

    public bool IsBinderThatCanHaveRefReceiver => true;

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => this._argumentInfo[index];

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpGetIndexBinder(Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
      : base(BinderHelper.CreateCallInfo(ref argumentInfo, 1))
    {
      this._argumentInfo = argumentInfo as CSharpArgumentInfo[];
      this._callingContext = callingContext;
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      return BinderHelper.AddArgHashes((object) callingContext != null ? callingContext.GetHashCode() : 0, this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpGetIndexBinder csharpGetIndexBinder && !(this._callingContext != csharpGetIndexBinder._callingContext) && this._argumentInfo.Length == csharpGetIndexBinder._argumentInfo.Length && BinderHelper.CompareArgInfos(this._argumentInfo, csharpGetIndexBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackGetIndex(
      DynamicMetaObject target,
      DynamicMetaObject[] indexes,
      DynamicMetaObject errorSuggestion)
    {
      DynamicMetaObject result;
      if (ComBinder.TryBindGetIndex((GetIndexBinder) this, target, indexes, out result))
        return result;
      BinderHelper.ValidateBindArgument(target, nameof (target));
      BinderHelper.ValidateBindArgument(indexes, nameof (indexes));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, BinderHelper.Cons<DynamicMetaObject>(target, indexes), (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, errorSuggestion);
    }
  }
}
