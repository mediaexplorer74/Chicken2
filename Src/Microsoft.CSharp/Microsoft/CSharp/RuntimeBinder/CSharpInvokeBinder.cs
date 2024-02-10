// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpInvokeBinder
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
  internal sealed class CSharpInvokeBinder : 
    InvokeBinder,
    ICSharpInvokeOrInvokeMemberBinder,
    ICSharpBinder
  {
    private readonly CSharpCallFlags _flags;
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

    bool ICSharpInvokeOrInvokeMemberBinder.StaticCall
    {
      get => this._argumentInfo[0] != null && this._argumentInfo[0].IsStaticType;
    }

    string ICSharpBinder.Name => "Invoke";

    Type[] ICSharpInvokeOrInvokeMemberBinder.TypeArguments => Type.EmptyTypes;

    CSharpCallFlags ICSharpInvokeOrInvokeMemberBinder.Flags => this._flags;

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => this._argumentInfo[index];

    bool ICSharpInvokeOrInvokeMemberBinder.ResultDiscarded
    {
      get => (this._flags & CSharpCallFlags.ResultDiscarded) != 0;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpInvokeBinder(
      CSharpCallFlags flags,
      Type callingContext,
      IEnumerable<CSharpArgumentInfo> argumentInfo)
      : base(BinderHelper.CreateCallInfo(ref argumentInfo, 1))
    {
      this._flags = flags;
      this._callingContext = callingContext;
      this._argumentInfo = argumentInfo as CSharpArgumentInfo[];
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      return BinderHelper.AddArgHashes(HashHelpers.Combine((object) callingContext != null ? callingContext.GetHashCode() : 0, (int) this._flags), this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpInvokeBinder csharpInvokeBinder && this._flags == csharpInvokeBinder._flags && !(this._callingContext != csharpInvokeBinder._callingContext) && this._argumentInfo.Length == csharpInvokeBinder._argumentInfo.Length && BinderHelper.CompareArgInfos(this._argumentInfo, csharpInvokeBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackInvoke(
      DynamicMetaObject target,
      DynamicMetaObject[] args,
      DynamicMetaObject errorSuggestion)
    {
      DynamicMetaObject result;
      if (ComBinder.TryBindInvoke((InvokeBinder) this, target, args, out result))
        return result;
      BinderHelper.ValidateBindArgument(target, nameof (target));
      BinderHelper.ValidateBindArgument(args, nameof (args));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, BinderHelper.Cons<DynamicMetaObject>(target, args), (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, errorSuggestion);
    }
  }
}
