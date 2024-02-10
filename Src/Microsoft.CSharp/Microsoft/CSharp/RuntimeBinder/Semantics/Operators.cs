// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.Operators
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class Operators
  {
    private static readonly Operators.OperatorInfo[] s_operatorInfos = new Operators.OperatorInfo[68]
    {
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Equal, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.PlusEqual, PredefinedName.PN_COUNT, ExpressionKind.BitwiseAnd | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.MinusEqual, PredefinedName.PN_COUNT, ExpressionKind.BitwiseOr | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.SplatEqual, PredefinedName.PN_COUNT, ExpressionKind.BitwiseExclusiveOr | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.SlashEqual, PredefinedName.PN_COUNT, ExpressionKind.BitwiseNot | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.PercentEqual, PredefinedName.PN_COUNT, ExpressionKind.LeftShirt | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.AndEqual, PredefinedName.PN_COUNT, ExpressionKind.LogicalOr | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.HatEqual, PredefinedName.PN_COUNT, ExpressionKind.Save | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.BarEqual, PredefinedName.PN_COUNT, ExpressionKind.Sequence | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.LeftShiftEqual, PredefinedName.PN_COUNT, ExpressionKind.Indir | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.RightShiftEqual, PredefinedName.PN_COUNT, ExpressionKind.Addr | ExpressionKind.DelegateEq),
      new Operators.OperatorInfo(TokenKind.Question, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.QuestionQuestion, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.LogicalOr, PredefinedName.PN_COUNT, ExpressionKind.LogicalOr),
      new Operators.OperatorInfo(TokenKind.LogicalAnd, PredefinedName.PN_COUNT, ExpressionKind.LogicalAnd),
      new Operators.OperatorInfo(TokenKind.Bar, PredefinedName.PN_OPBITWISEOR, ExpressionKind.BitwiseOr),
      new Operators.OperatorInfo(TokenKind.Hat, PredefinedName.PN_OPXOR, ExpressionKind.BitwiseExclusiveOr),
      new Operators.OperatorInfo(TokenKind.Ampersand, PredefinedName.PN_OPBITWISEAND, ExpressionKind.BitwiseAnd),
      new Operators.OperatorInfo(TokenKind.EqualEqual, PredefinedName.PN_OPEQUALITY, ExpressionKind.Eq),
      new Operators.OperatorInfo(TokenKind.NotEqual, PredefinedName.PN_OPINEQUALITY, ExpressionKind.NotEq),
      new Operators.OperatorInfo(TokenKind.LessThan, PredefinedName.PN_OPLESSTHAN, ExpressionKind.LessThan),
      new Operators.OperatorInfo(TokenKind.LessThanEqual, PredefinedName.PN_OPLESSTHANOREQUAL, ExpressionKind.LessThanOrEqual),
      new Operators.OperatorInfo(TokenKind.GreaterThan, PredefinedName.PN_OPGREATERTHAN, ExpressionKind.GreaterThan),
      new Operators.OperatorInfo(TokenKind.GreaterThanEqual, PredefinedName.PN_OPGREATERTHANOREQUAL, ExpressionKind.GreaterThanOrEqual),
      new Operators.OperatorInfo(TokenKind.Is, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.As, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.LeftShift, PredefinedName.PN_OPLEFTSHIFT, ExpressionKind.LeftShirt),
      new Operators.OperatorInfo(TokenKind.RightShift, PredefinedName.PN_OPRIGHTSHIFT, ExpressionKind.RightShift),
      new Operators.OperatorInfo(TokenKind.Plus, PredefinedName.PN_OPPLUS, ExpressionKind.Add),
      new Operators.OperatorInfo(TokenKind.Minus, PredefinedName.PN_OPMINUS, ExpressionKind.Subtract),
      new Operators.OperatorInfo(TokenKind.Splat, PredefinedName.PN_OPMULTIPLY, ExpressionKind.Multiply),
      new Operators.OperatorInfo(TokenKind.Slash, PredefinedName.PN_OPDIVISION, ExpressionKind.Divide),
      new Operators.OperatorInfo(TokenKind.Percent, PredefinedName.PN_OPMODULUS, ExpressionKind.Modulo),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Plus, PredefinedName.PN_OPUNARYPLUS, ExpressionKind.UnaryPlus),
      new Operators.OperatorInfo(TokenKind.Minus, PredefinedName.PN_OPUNARYMINUS, ExpressionKind.Negate),
      new Operators.OperatorInfo(TokenKind.Tilde, PredefinedName.PN_OPCOMPLEMENT, ExpressionKind.BitwiseNot),
      new Operators.OperatorInfo(TokenKind.Bang, PredefinedName.PN_OPNEGATION, ExpressionKind.LogicalNot),
      new Operators.OperatorInfo(TokenKind.PlusPlus, PredefinedName.PN_OPINCREMENT, ExpressionKind.Add),
      new Operators.OperatorInfo(TokenKind.MinusMinus, PredefinedName.PN_OPDECREMENT, ExpressionKind.Subtract),
      new Operators.OperatorInfo(TokenKind.TypeOf, PredefinedName.PN_COUNT, ExpressionKind.TypeOf),
      new Operators.OperatorInfo(TokenKind.Checked, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unchecked, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.MakeRef, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.RefValue, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.RefType, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.ArgList, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Splat, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Ampersand, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Colon, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.This, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Base, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Null, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.True, PredefinedName.PN_OPTRUE, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.False, PredefinedName.PN_OPFALSE, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.PlusPlus, PredefinedName.PN_COUNT, ExpressionKind.Add),
      new Operators.OperatorInfo(TokenKind.MinusMinus, PredefinedName.PN_COUNT, ExpressionKind.Subtract),
      new Operators.OperatorInfo(TokenKind.Dot, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Implicit, PredefinedName.PN_OPIMPLICITMN, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Explicit, PredefinedName.PN_OPEXPLICITMN, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_OPEQUALS, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_OPCOMPARE, ExpressionKind.ExpressionKindCount),
      new Operators.OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount)
    };
    private static Dictionary<Name, string> s_operatorsByName;

    private static Dictionary<Name, string> GetOperatorByName()
    {
      Dictionary<Name, string> operatorByName = new Dictionary<Name, string>(28)
      {
        {
          NameManager.GetPredefinedName(PredefinedName.PN_OPEQUALS),
          "equals"
        },
        {
          NameManager.GetPredefinedName(PredefinedName.PN_OPCOMPARE),
          "compare"
        }
      };
      foreach (Operators.OperatorInfo operatorInfo in Operators.s_operatorInfos)
      {
        PredefinedName methodName = operatorInfo.MethodName;
        TokenKind tokenKind = operatorInfo.TokenKind;
        if (methodName != PredefinedName.PN_COUNT && tokenKind != TokenKind.Unknown)
          operatorByName.Add(NameManager.GetPredefinedName(methodName), TokenFacts.GetText(tokenKind));
      }
      return operatorByName;
    }

    private static Operators.OperatorInfo GetInfo(OperatorKind op)
    {
      return Operators.s_operatorInfos[(int) op];
    }

    public static string OperatorOfMethodName(Name name)
    {
      return (Operators.s_operatorsByName ?? (Operators.s_operatorsByName = Operators.GetOperatorByName()))[name];
    }

    public static string GetDisplayName(OperatorKind op)
    {
      return TokenFacts.GetText(Operators.GetInfo(op).TokenKind);
    }

    public static ExpressionKind GetExpressionKind(OperatorKind op)
    {
      return Operators.GetInfo(op).ExpressionKind;
    }

    private sealed class OperatorInfo
    {
      public readonly TokenKind TokenKind;
      public readonly PredefinedName MethodName;
      public readonly ExpressionKind ExpressionKind;

      public OperatorInfo(TokenKind kind, PredefinedName pn, ExpressionKind e)
      {
        this.TokenKind = kind;
        this.MethodName = pn;
        this.ExpressionKind = e;
      }
    }
  }
}
