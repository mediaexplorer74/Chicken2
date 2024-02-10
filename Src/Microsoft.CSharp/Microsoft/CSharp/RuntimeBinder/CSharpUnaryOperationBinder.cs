// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpUnaryOperationBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Numerics.Hashing;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal sealed class CSharpUnaryOperationBinder : UnaryOperationBinder, ICSharpBinder
  {
    private readonly CSharpArgumentInfo[] _argumentInfo;
    private readonly Microsoft.CSharp.RuntimeBinder.RuntimeBinder _binder;
    private readonly Type _callingContext;

    [ExcludeFromCodeCoverage(Justification = "Name should not be called for this binder")]
    public string Name => (string) null;

    public BindingFlag BindingFlags => (BindingFlag) 0;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr DispatchPayload(
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder runtimeBinder,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      return runtimeBinder.BindUnaryOperation(this, arguments, locals);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
    {
      SymbolTable.PopulateSymbolTableWithName(this.Operation.GetCLROperatorName(), (IEnumerable<Type>) null, arguments[0].Type);
    }

    public bool IsBinderThatCanHaveRefReceiver => false;

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => this._argumentInfo[index];

    private bool IsChecked => this._binder.IsChecked;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpUnaryOperationBinder(
      ExpressionType operation,
      bool isChecked,
      Type callingContext,
      IEnumerable<CSharpArgumentInfo> argumentInfo)
      : base(operation)
    {
      this._argumentInfo = BinderHelper.ToArray<CSharpArgumentInfo>(argumentInfo);
      this._callingContext = callingContext;
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext, isChecked);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      int num = HashHelpers.Combine((object) callingContext != null ? callingContext.GetHashCode() : 0, (int) this.Operation);
      if (this.IsChecked)
        num = HashHelpers.Combine(num, 1);
      return BinderHelper.AddArgHashes(num, this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpUnaryOperationBinder unaryOperationBinder && this.Operation == unaryOperationBinder.Operation && this.IsChecked == unaryOperationBinder.IsChecked && !(this._callingContext != unaryOperationBinder._callingContext) && BinderHelper.CompareArgInfos(this._argumentInfo, unaryOperationBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackUnaryOperation(
      DynamicMetaObject target,
      DynamicMetaObject errorSuggestion)
    {
      BinderHelper.ValidateBindArgument(target, nameof (target));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, new DynamicMetaObject[1]
      {
        target
      }, (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, errorSuggestion);
    }
  }
}
