// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ErrorArgBuilder
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
  internal sealed class ErrorArgBuilder : SimpleArgBuilder
  {
    internal ErrorArgBuilder(Type parameterType)
      : base(parameterType)
    {
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal override Expression Marshal(Expression parameter)
    {
      return (Expression) Expression.Property(Helpers.Convert(base.Marshal(parameter), typeof (ErrorWrapper)), "ErrorCode");
    }

    internal override Expression UnmarshalFromRef(Expression value)
    {
      return base.UnmarshalFromRef((Expression) Expression.New(typeof (ErrorWrapper).GetConstructor(new Type[1]
      {
        typeof (int)
      }), value));
    }
  }
}
