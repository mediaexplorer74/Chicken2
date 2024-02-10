// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.Helpers
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class Helpers
  {
    internal static Expression Convert(Expression expression, Type type)
    {
      if (expression.Type == type)
        return expression;
      if (expression.Type == typeof (void))
        return (Expression) Expression.Block(expression, (Expression) Expression.Default(type));
      return type == typeof (void) ? (Expression) Expression.Block(expression, (Expression) Expression.Empty()) : (Expression) Expression.Convert(expression, type);
    }
  }
}
