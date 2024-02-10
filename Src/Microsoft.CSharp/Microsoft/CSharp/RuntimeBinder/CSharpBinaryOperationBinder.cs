// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpBinaryOperationBinder
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
  internal sealed class CSharpBinaryOperationBinder : BinaryOperationBinder, ICSharpBinder
  {
    private readonly CSharpBinaryOperationFlags _binopFlags;
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
      return runtimeBinder.BindBinaryOperation(this, arguments, locals);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
    {
      string clrOperatorName = this.Operation.GetCLROperatorName();
      SymbolTable.PopulateSymbolTableWithName(clrOperatorName, (IEnumerable<Type>) null, arguments[0].Type);
      SymbolTable.PopulateSymbolTableWithName(clrOperatorName, (IEnumerable<Type>) null, arguments[1].Type);
    }

    public bool IsBinderThatCanHaveRefReceiver => false;

    internal bool IsLogicalOperation
    {
      get => (this._binopFlags & CSharpBinaryOperationFlags.LogicalOperation) != 0;
    }

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => this._argumentInfo[index];

    private bool IsChecked => this._binder.IsChecked;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpBinaryOperationBinder(
      ExpressionType operation,
      bool isChecked,
      CSharpBinaryOperationFlags binaryOperationFlags,
      Type callingContext,
      IEnumerable<CSharpArgumentInfo> argumentInfo)
      : base(operation)
    {
      this._binopFlags = binaryOperationFlags;
      this._callingContext = callingContext;
      this._argumentInfo = BinderHelper.ToArray<CSharpArgumentInfo>(argumentInfo);
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext, isChecked);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      int h1 = HashHelpers.Combine((object) callingContext != null ? callingContext.GetHashCode() : 0, (int) this._binopFlags);
      if (this.IsChecked)
        h1 = HashHelpers.Combine(h1, 1);
      return BinderHelper.AddArgHashes(HashHelpers.Combine(h1, (int) this.Operation), this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpBinaryOperationBinder binaryOperationBinder && this._binopFlags == binaryOperationBinder._binopFlags && this.Operation == binaryOperationBinder.Operation && this.IsChecked == binaryOperationBinder.IsChecked && !(this._callingContext != binaryOperationBinder._callingContext) && BinderHelper.CompareArgInfos(this._argumentInfo, binaryOperationBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackBinaryOperation(
      DynamicMetaObject target,
      DynamicMetaObject arg,
      DynamicMetaObject errorSuggestion)
    {
      BinderHelper.ValidateBindArgument(target, nameof (target));
      BinderHelper.ValidateBindArgument(arg, nameof (arg));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, new DynamicMetaObject[2]
      {
        target,
        arg
      }, (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, errorSuggestion);
    }
  }
}
