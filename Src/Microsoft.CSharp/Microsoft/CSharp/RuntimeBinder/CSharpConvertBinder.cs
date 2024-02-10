// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpConvertBinder
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
  internal sealed class CSharpConvertBinder : ConvertBinder, ICSharpBinder
  {
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
      return !this.Explicit ? runtimeBinder.BindImplicitConversion(arguments, this.Type, locals, this.ConversionKind == CSharpConversionKind.ArrayCreationConversion) : runtimeBinder.BindExplicitConversion(arguments, this.Type, locals);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
    {
    }

    public bool IsBinderThatCanHaveRefReceiver => false;

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => CSharpArgumentInfo.None;

    private CSharpConversionKind ConversionKind { get; }

    private bool IsChecked => this._binder.IsChecked;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpConvertBinder(
      Type type,
      CSharpConversionKind conversionKind,
      bool isChecked,
      Type callingContext)
      : base(type, conversionKind == CSharpConversionKind.ExplicitConversion)
    {
      this.ConversionKind = conversionKind;
      this._callingContext = callingContext;
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext, isChecked);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      int h1 = HashHelpers.Combine((object) callingContext != null ? callingContext.GetHashCode() : 0, (int) this.ConversionKind);
      if (this.IsChecked)
        h1 = HashHelpers.Combine(h1, 1);
      return HashHelpers.Combine(h1, this.Type.GetHashCode());
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpConvertBinder csharpConvertBinder && this.ConversionKind == csharpConvertBinder.ConversionKind && this.IsChecked == csharpConvertBinder.IsChecked && !(this._callingContext != csharpConvertBinder._callingContext) && !(this.Type != csharpConvertBinder.Type);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackConvert(
      DynamicMetaObject target,
      DynamicMetaObject errorSuggestion)
    {
      DynamicMetaObject result;
      if (ComBinder.TryConvert((ConvertBinder) this, target, out result))
        return result;
      BinderHelper.ValidateBindArgument(target, nameof (target));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, new DynamicMetaObject[1]
      {
        target
      }, (IEnumerable<CSharpArgumentInfo>) null, errorSuggestion);
    }
  }
}
