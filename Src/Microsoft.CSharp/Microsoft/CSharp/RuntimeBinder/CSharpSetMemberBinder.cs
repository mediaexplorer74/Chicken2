// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpSetMemberBinder
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
  internal sealed class CSharpSetMemberBinder : SetMemberBinder, ICSharpBinder
  {
    private readonly CSharpArgumentInfo[] _argumentInfo;
    private readonly Microsoft.CSharp.RuntimeBinder.RuntimeBinder _binder;
    private readonly Type _callingContext;

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
      SymbolTable.PopulateSymbolTableWithName(this.Name, (IEnumerable<Type>) null, arguments[0].Type);
    }

    public bool IsBinderThatCanHaveRefReceiver => false;

    internal bool IsCompoundAssignment { get; }

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => this._argumentInfo[index];

    private bool IsChecked => this._binder.IsChecked;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpSetMemberBinder(
      string name,
      bool isCompoundAssignment,
      bool isChecked,
      Type callingContext,
      IEnumerable<CSharpArgumentInfo> argumentInfo)
      : base(name, false)
    {
      this.IsCompoundAssignment = isCompoundAssignment;
      this._argumentInfo = BinderHelper.ToArray<CSharpArgumentInfo>(argumentInfo);
      this._callingContext = callingContext;
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext, isChecked);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      int h1 = (object) callingContext != null ? callingContext.GetHashCode() : 0;
      if (this.IsChecked)
        h1 = HashHelpers.Combine(h1, 1);
      if (this.IsCompoundAssignment)
        h1 = HashHelpers.Combine(h1, 1);
      return BinderHelper.AddArgHashes(HashHelpers.Combine(h1, this.Name.GetHashCode()), this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpSetMemberBinder csharpSetMemberBinder && !(this.Name != csharpSetMemberBinder.Name) && !(this._callingContext != csharpSetMemberBinder._callingContext) && this.IsChecked == csharpSetMemberBinder.IsChecked && this.IsCompoundAssignment == csharpSetMemberBinder.IsCompoundAssignment && this._argumentInfo.Length == csharpSetMemberBinder._argumentInfo.Length && BinderHelper.CompareArgInfos(this._argumentInfo, csharpSetMemberBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackSetMember(
      DynamicMetaObject target,
      DynamicMetaObject value,
      DynamicMetaObject errorSuggestion)
    {
      DynamicMetaObject result;
      if (ComBinder.TryBindSetMember((SetMemberBinder) this, target, value, out result))
        return result;
      BinderHelper.ValidateBindArgument(target, nameof (target));
      BinderHelper.ValidateBindArgument(value, nameof (value));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, new DynamicMetaObject[2]
      {
        target,
        value
      }, (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, errorSuggestion);
    }

    string ICSharpBinder.get_Name() => this.Name;
  }
}
