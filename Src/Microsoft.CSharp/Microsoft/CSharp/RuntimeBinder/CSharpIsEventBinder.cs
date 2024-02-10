// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpIsEventBinder
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
  internal sealed class CSharpIsEventBinder : DynamicMetaObjectBinder, ICSharpBinder
  {
    private readonly Microsoft.CSharp.RuntimeBinder.RuntimeBinder _binder;
    private readonly Type _callingContext;

    public BindingFlag BindingFlags => (BindingFlag) 0;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr DispatchPayload(
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder runtimeBinder,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      return runtimeBinder.BindIsEvent(this, arguments, locals);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
    {
      SymbolTable.PopulateSymbolTableWithName(this.Name, (IEnumerable<Type>) null, arguments[0].Info.IsStaticType ? arguments[0].Value as Type : arguments[0].Type);
    }

    public bool IsBinderThatCanHaveRefReceiver => false;

    CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index) => CSharpArgumentInfo.None;

    public string Name { get; }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public CSharpIsEventBinder(string name, Type callingContext)
    {
      this.Name = name;
      this._callingContext = callingContext;
      this._binder = new Microsoft.CSharp.RuntimeBinder.RuntimeBinder(callingContext);
    }

    public int GetGetBinderEquivalenceHash()
    {
      Type callingContext = this._callingContext;
      return HashHelpers.Combine((object) callingContext != null ? callingContext.GetHashCode() : 0, this.Name.GetHashCode());
    }

    public bool IsEquivalentTo(ICSharpBinder other)
    {
      return other is CSharpIsEventBinder csharpIsEventBinder && !(this._callingContext != csharpIsEventBinder._callingContext) && !(this.Name != csharpIsEventBinder.Name);
    }

    public override Type ReturnType => typeof (bool);

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args)
    {
      BinderHelper.ValidateBindArgument(target, nameof (target));
      return BinderHelper.Bind((ICSharpBinder) this, this._binder, new DynamicMetaObject[1]
      {
        target
      }, (IEnumerable<CSharpArgumentInfo>) null, (DynamicMetaObject) null);
    }
  }
}
