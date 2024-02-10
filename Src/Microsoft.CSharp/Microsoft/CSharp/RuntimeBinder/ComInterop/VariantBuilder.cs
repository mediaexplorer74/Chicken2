﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.VariantBuilder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class VariantBuilder
  {
    private MemberExpression _variant;
    private readonly ArgBuilder _argBuilder;
    private readonly VarEnum _targetComType;

    internal ParameterExpression TempVariable { get; private set; }

    internal VariantBuilder(VarEnum targetComType, ArgBuilder builder)
    {
      this._targetComType = targetComType;
      this._argBuilder = builder;
    }

    internal bool IsByRef => (this._targetComType & VarEnum.VT_BYREF) != 0;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expression InitializeArgumentVariant(MemberExpression variant, Expression parameter)
    {
      this._variant = variant;
      if (this.IsByRef)
      {
        Expression right = this._argBuilder.MarshalToRef(parameter);
        this.TempVariable = Expression.Variable(right.Type, (string) null);
        return (Expression) Expression.Block((Expression) Expression.Assign((Expression) this.TempVariable, right), (Expression) Expression.Call((Expression) variant, Variant.GetByrefSetter(this._targetComType & ~VarEnum.VT_BYREF), (Expression) this.TempVariable));
      }
      Expression right1 = this._argBuilder.Marshal(parameter);
      if (this._argBuilder is ConvertibleArgBuilder)
        return (Expression) Expression.Call((Expression) variant, typeof (Variant).GetMethod("SetAsIConvertible"), right1);
      if (Variant.IsPrimitiveType(this._targetComType) || this._targetComType == VarEnum.VT_DISPATCH || this._targetComType == VarEnum.VT_UNKNOWN || this._targetComType == VarEnum.VT_VARIANT || this._targetComType == VarEnum.VT_RECORD || this._targetComType == VarEnum.VT_ARRAY)
        return (Expression) Expression.Assign((Expression) Expression.Property((Expression) variant, Variant.GetAccessor(this._targetComType)), right1);
      switch (this._targetComType)
      {
        case VarEnum.VT_EMPTY:
          return (Expression) null;
        case VarEnum.VT_NULL:
          return (Expression) Expression.Call((Expression) variant, typeof (Variant).GetMethod("SetAsNULL"));
        default:
          return (Expression) null;
      }
    }

    private static Expression Release(Expression pUnk)
    {
      return (Expression) Expression.Call(typeof (UnsafeMethods).GetMethod("IUnknownReleaseNotZero"), pUnk);
    }

    internal Expression Clear()
    {
      if (this.IsByRef)
      {
        if (this._argBuilder is StringArgBuilder)
          return (Expression) Expression.Call(typeof (Marshal).GetMethod("FreeBSTR"), (Expression) this.TempVariable);
        if (this._argBuilder is DispatchArgBuilder)
          return VariantBuilder.Release((Expression) this.TempVariable);
        if (this._argBuilder is UnknownArgBuilder)
          return VariantBuilder.Release((Expression) this.TempVariable);
        return this._argBuilder is VariantArgBuilder ? (Expression) Expression.Call((Expression) this.TempVariable, typeof (Variant).GetMethod(nameof (Clear))) : (Expression) null;
      }
      switch (this._targetComType)
      {
        case VarEnum.VT_EMPTY:
        case VarEnum.VT_NULL:
          return (Expression) null;
        case VarEnum.VT_BSTR:
        case VarEnum.VT_DISPATCH:
        case VarEnum.VT_VARIANT:
        case VarEnum.VT_UNKNOWN:
        case VarEnum.VT_RECORD:
        case VarEnum.VT_ARRAY:
          return (Expression) Expression.Call((Expression) this._variant, typeof (Variant).GetMethod(nameof (Clear)));
        default:
          return (Expression) null;
      }
    }

    internal Expression UpdateFromReturn(Expression parameter)
    {
      return this.TempVariable == null ? (Expression) null : (Expression) Expression.Assign(parameter, Helpers.Convert(this._argBuilder.UnmarshalFromRef((Expression) this.TempVariable), parameter.Type));
    }
  }
}
