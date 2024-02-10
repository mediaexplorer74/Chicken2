// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpInvokeMemberBinder
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
  internal sealed class CSharpInvokeMemberBinder : 
    InvokeMemberBinder,
    ICSharpInvokeOrInvokeMemberBinder,
    ICSharpBinder
  {
    private readonly CSharpArgumentInfo[] _argumentInfo;
    private readonly Microsoft.CSharp.RuntimeBinder.RuntimeBinder _binder;

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
      get
      {
        CSharpArgumentInfo csharpArgumentInfo = this._argumentInfo[0];
        return csharpArgumentInfo != null && csharpArgumentInfo.IsStaticType;
      }
    }

    public CSharpCallFlags Flags { get; }

    public Type CallingContext { get; }

    public Type[] TypeArguments { get; }

    public CSharpArgumentInfo GetArgumentInfo(int index) => this._argumentInfo[index];

    public CSharpArgumentInfo[] ArgumentInfoArray()
    {
      CSharpArgumentInfo[] csharpArgumentInfoArray = new CSharpArgumentInfo[this._argumentInfo.Length];
      this._argumentInfo.CopyTo((Array) csharpArgumentInfoArray, 0);
      return csharpArgumentInfoArray;
    }

    bool ICSharpInvokeOrInvokeMemberBinder.ResultDiscarded
    {
      get => (this.Flags & CSharpCallFlags.ResultDiscarded) != 0;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpInvokeMemberBinder(
      CSharpCallFlags flags,
      string name,
      Type callingContext,
      IEnumerable<Type> typeArguments,
      IEnumerable<CSharpArgumentInfo> argumentInfo)
      : base(name, false, BinderHelper.CreateCallInfo(ref argumentInfo, 1))
    {
      this.Flags = flags;
      this.CallingContext = callingContext;
      this.TypeArguments = BinderHelper.ToArray<Type>(typeArguments);
      this._argumentInfo = BinderHelper.ToArray<CSharpArgumentInfo>(argumentInfo);
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this.CallingContext;
      return BinderHelper.AddArgHashes(HashHelpers.Combine(HashHelpers.Combine((object) callingContext != null ? callingContext.GetHashCode() : 0, (int) this.Flags), this.Name.GetHashCode()), this.TypeArguments, this._argumentInfo);
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpInvokeMemberBinder invokeMemberBinder && this.Flags == invokeMemberBinder.Flags && !(this.CallingContext != invokeMemberBinder.CallingContext) && !(this.Name != invokeMemberBinder.Name) && this.TypeArguments.Length == invokeMemberBinder.TypeArguments.Length && this._argumentInfo.Length == invokeMemberBinder._argumentInfo.Length && BinderHelper.CompareArgInfos(this.TypeArguments, invokeMemberBinder.TypeArguments, this._argumentInfo, invokeMemberBinder._argumentInfo);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackInvokeMember(
      DynamicMetaObject target,
      DynamicMetaObject[] args,
      DynamicMetaObject errorSuggestion)
    {
      DynamicMetaObject result;
      if (ComBinder.TryBindInvokeMember((InvokeMemberBinder) this, target, args, out result))
        return result;
      BinderHelper.ValidateBindArgument(target, nameof (target));
      BinderHelper.ValidateBindArgument(args, nameof (args));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, BinderHelper.Cons<DynamicMetaObject>(target, args), (IEnumerable<CSharpArgumentInfo>) this._argumentInfo, errorSuggestion);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackInvoke(
      DynamicMetaObject target,
      DynamicMetaObject[] args,
      DynamicMetaObject errorSuggestion)
    {
      return new CSharpInvokeBinder(this.Flags, this.CallingContext, (IEnumerable<CSharpArgumentInfo>) this._argumentInfo).TryGetExisting<CSharpInvokeBinder>().Defer(target, args);
    }

    string ICSharpBinder.get_Name() => this.Name;
  }
}
