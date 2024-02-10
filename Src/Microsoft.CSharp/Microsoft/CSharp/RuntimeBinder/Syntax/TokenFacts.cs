// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Syntax.TokenFacts
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Syntax
{
  internal static class TokenFacts
  {
    internal static string GetText(TokenKind kind)
    {
      switch (kind)
      {
        case TokenKind.ArgList:
          return "__arglist";
        case TokenKind.MakeRef:
          return "__makeref";
        case TokenKind.RefType:
          return "__reftype";
        case TokenKind.RefValue:
          return "__refvalue";
        case TokenKind.As:
          return "as";
        case TokenKind.Base:
          return "base";
        case TokenKind.Checked:
          return "checked";
        case TokenKind.Explicit:
          return "explicit";
        case TokenKind.False:
          return "false";
        case TokenKind.Implicit:
          return "implicit";
        case TokenKind.Is:
          return "is";
        case TokenKind.Null:
          return "null";
        case TokenKind.This:
          return "this";
        case TokenKind.True:
          return "true";
        case TokenKind.TypeOf:
          return "typeof";
        case TokenKind.Unchecked:
          return "unchecked";
        case TokenKind.Void:
          return "void";
        case TokenKind.Equal:
          return "=";
        case TokenKind.PlusEqual:
          return "+=";
        case TokenKind.MinusEqual:
          return "-=";
        case TokenKind.SplatEqual:
          return "*=";
        case TokenKind.SlashEqual:
          return "/=";
        case TokenKind.PercentEqual:
          return "%=";
        case TokenKind.AndEqual:
          return "&=";
        case TokenKind.HatEqual:
          return "^=";
        case TokenKind.BarEqual:
          return "|=";
        case TokenKind.LeftShiftEqual:
          return "<<=";
        case TokenKind.RightShiftEqual:
          return ">>=";
        case TokenKind.Question:
          return "?";
        case TokenKind.Colon:
          return ":";
        case TokenKind.ColonColon:
          return "::";
        case TokenKind.LogicalOr:
          return "||";
        case TokenKind.LogicalAnd:
          return "&&";
        case TokenKind.Bar:
          return "|";
        case TokenKind.Hat:
          return "^";
        case TokenKind.Ampersand:
          return "&";
        case TokenKind.EqualEqual:
          return "==";
        case TokenKind.NotEqual:
          return "!=";
        case TokenKind.LessThan:
          return "<";
        case TokenKind.LessThanEqual:
          return "<=";
        case TokenKind.GreaterThan:
          return ">";
        case TokenKind.GreaterThanEqual:
          return ">=";
        case TokenKind.LeftShift:
          return "<<";
        case TokenKind.RightShift:
          return ">>";
        case TokenKind.Plus:
          return "+";
        case TokenKind.Minus:
          return "-";
        case TokenKind.Splat:
          return "*";
        case TokenKind.Slash:
          return "/";
        case TokenKind.Percent:
          return "%";
        case TokenKind.Tilde:
          return "~";
        case TokenKind.Bang:
          return "!";
        case TokenKind.PlusPlus:
          return "++";
        case TokenKind.MinusMinus:
          return "--";
        case TokenKind.Dot:
          return ".";
        case TokenKind.QuestionQuestion:
          return "??";
        default:
          throw Error.InternalCompilerError();
      }
    }
  }
}
