// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpInvokeConstructorBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Numerics.Hashing;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal sealed class CSharpInvokeConstructorBinder : 
    DynamicMetaObjectBinder,
    ICSharpInvokeOrInvokeMemberBinder,
    ICSharpBinder
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
      return (Expr) runtimeBinder.DispatchPayload((ICSharpInvokeOrInvokeMemberBinder) this, arguments, locals);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
    {
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder.PopulateSymbolTableWithPayloadInformation((ICSharpInvokeOrInvokeMemberBinder) this, callingType, arguments);
    }

    public bool IsBinderThatCanHaveRefReceiver => true;

    public CSharpCallFlags Flags { get; }

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => this._argumentInfo[index];

    public bool StaticCall => true;

    public Type[] TypeArguments => Type.EmptyTypes;

    public string Name => ".ctor";

    bool ICSharpInvokeOrInvokeMemberBinder.ResultDiscarded => false;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpInvokeConstructorBinder(
      CSharpCallFlags flags,
      Type callingContext,
      IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      this.Flags = flags;
      this._callingContext = callingContext;
      this._argumentInfo = BinderHelper.ToArray<CSharpArgumentInfo>(argumentInfo);
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      return BinderHelper.AddArgHashes(HashHelpers.Combine(HashHelpers.Combine((object) callingContext != null ? callingContext.GetHashCode() : 0, (int) this.Flags), this.Name.GetHashCode()), this.TypeArguments, this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpInvokeConstructorBinder constructorBinder && this.Flags == constructorBinder.Flags && !(this._callingContext != constructorBinder._callingContext) && !(this.Name != constructorBinder.Name) && this.TypeArguments.Length == constructorBinder.TypeArguments.Length && this._argumentInfo.Length == constructorBinder._argumentInfo.Length && BinderHelper.CompareArgInfos(this.TypeArguments, constructorBinder.TypeArguments, this._argumentInfo, constructorBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args)
    {
      BinderHelper.ValidateBindArgument(target, nameof (target));
      BinderHelper.ValidateBindArgument(args, nameof (args));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, BinderHelper.Cons<DynamicMetaObject>(target, args), (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, (DynamicMetaObject) null);
    }
  }
}
