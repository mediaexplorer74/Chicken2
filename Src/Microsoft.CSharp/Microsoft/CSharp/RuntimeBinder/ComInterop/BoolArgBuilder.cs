// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.BoolArgBuilder
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
  internal sealed class BoolArgBuilder : SimpleArgBuilder
  {
    internal BoolArgBuilder(Type parameterType)
      : base(parameterType)
    {
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal override Expression MarshalToRef(Expression parameter)
    {
      return (Expression) Expression.Condition(this.Marshal(parameter), (Expression) Expression.Constant((object) (short) -1), (Expression) Expression.Constant((object) (short) 0));
    }

    internal override Expression UnmarshalFromRef(Expression value)
    {
      return base.UnmarshalFromRef((Expression) Expression.NotEqual(value, (Expression) Expression.Constant((object) (short) 0)));
    }
  }
}
