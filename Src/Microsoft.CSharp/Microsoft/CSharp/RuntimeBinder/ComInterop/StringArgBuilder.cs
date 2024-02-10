// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.StringArgBuilder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class StringArgBuilder : SimpleArgBuilder
  {
    private readonly bool _isWrapper;

    internal StringArgBuilder(Type parameterType)
      : base(parameterType)
    {
      this._isWrapper = parameterType == typeof (BStrWrapper);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal override Expression Marshal(Expression parameter)
    {
      parameter = base.Marshal(parameter);
      if (this._isWrapper)
        parameter = (Expression) Expression.Property(Helpers.Convert(parameter, typeof (BStrWrapper)), typeof (BStrWrapper).GetProperty("WrappedObject"));
      return parameter;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal override Expression MarshalToRef(Expression parameter)
    {
      parameter = this.Marshal(parameter);
      return (Expression) Expression.Call(typeof (System.Runtime.InteropServices.Marshal).GetMethod("StringToBSTR"), parameter);
    }

    internal override Expression UnmarshalFromRef(Expression value)
    {
      Expression newValue = (Expression) Expression.Condition((Expression) Expression.Equal(value, (Expression) Expression.Constant((object) IntPtr.Zero)), (Expression) Expression.Constant((object) null, typeof (string)), (Expression) Expression.Call(typeof (System.Runtime.InteropServices.Marshal).GetMethod("PtrToStringBSTR"), value));
      if (this._isWrapper)
        newValue = (Expression) Expression.New(typeof (BStrWrapper).GetConstructor(new Type[1]
        {
          typeof (string)
        }), newValue);
      return base.UnmarshalFromRef(newValue);
    }
  }
}
