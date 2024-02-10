// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ConvertArgBuilder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ConvertArgBuilder : SimpleArgBuilder
  {
    private readonly Type _marshalType;

    internal ConvertArgBuilder(Type parameterType, Type marshalType)
      : base(parameterType)
    {
      this._marshalType = marshalType;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal override Expression Marshal(Expression parameter)
    {
      parameter = base.Marshal(parameter);
      return (Expression) Expression.Convert(parameter, this._marshalType);
    }

    internal override Expression UnmarshalFromRef(Expression newValue)
    {
      return base.UnmarshalFromRef((Expression) Expression.Convert(newValue, this.ParameterType));
    }
  }
}
