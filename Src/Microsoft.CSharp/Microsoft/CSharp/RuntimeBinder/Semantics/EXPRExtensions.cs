// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.EXPRExtensions
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class EXPRExtensions
  {
    public static Expr Map(this Expr expr, Func<Expr, Expr> f)
    {
      if (expr == null)
        return f((Expr) null);
      Expr first = (Expr) null;
      Expr last = (Expr) null;
      foreach (Expr expr1 in expr.ToEnumerable())
        ExprFactory.AppendItemToList(f(expr1), ref first, ref last);
      return first;
    }

    public static IEnumerable<Expr> ToEnumerable(this Expr expr)
    {
      Expr expr1 = expr;
      while (expr1 != null)
      {
        if (expr1 is ExprList list)
        {
          yield return list.OptionalElement;
          expr1 = list.OptionalNextListNode;
          list = (ExprList) null;
        }
        else
        {
          yield return expr1;
          break;
        }
      }
    }

    public static bool isLvalue(this Expr expr)
    {
      return expr != null && (expr.Flags & EXPRFLAG.EXF_LVALUE) != 0;
    }

    public static bool isChecked(this Expr expr)
    {
      return expr != null && (expr.Flags & EXPRFLAG.EXF_CHECKOVERFLOW) != 0;
    }

    public static bool isNull(this Expr expr)
    {
      return expr is ExprConstant exprConstant && expr.Type.FundamentalType == FUNDTYPE.FT_REF && exprConstant.Val.IsNullRef;
    }

    public static bool IsZero(this Expr expr)
    {
      return expr is ExprConstant exprConstant && exprConstant.IsZero;
    }

    private static Expr GetSeqVal(this Expr expr)
    {
      if (expr == null)
        return (Expr) null;
      Expr seqVal = expr;
      while (seqVal.Kind == ExpressionKind.Sequence)
        seqVal = ((ExprBinOp) seqVal).OptionalRightChild;
      return seqVal;
    }

    public static Expr GetConst(this Expr expr)
    {
      Expr seqVal = expr.GetSeqVal();
      ExpressionKind? kind = seqVal?.Kind;
      if (kind.HasValue)
      {
        switch (kind.GetValueOrDefault())
        {
          case ExpressionKind.Constant:
          case ExpressionKind.ZeroInit:
            return seqVal;
        }
      }
      return (Expr) null;
    }
  }
}
