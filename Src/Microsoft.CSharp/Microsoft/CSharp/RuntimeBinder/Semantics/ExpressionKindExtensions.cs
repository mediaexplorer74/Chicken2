// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExpressionKindExtensions
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class ExpressionKindExtensions
  {
    public static bool IsRelational(this ExpressionKind kind)
    {
      return ExpressionKind.Eq <= kind && kind <= ExpressionKind.GreaterThanOrEqual;
    }

    public static bool IsUnaryOperator(this ExpressionKind kind)
    {
      switch (kind)
      {
        case ExpressionKind.True:
        case ExpressionKind.False:
        case ExpressionKind.Inc:
        case ExpressionKind.Dec:
        case ExpressionKind.LogicalNot:
        case ExpressionKind.Negate:
        case ExpressionKind.UnaryPlus:
        case ExpressionKind.BitwiseNot:
        case ExpressionKind.Addr:
        case ExpressionKind.DecimalNegate:
        case ExpressionKind.DecimalInc:
        case ExpressionKind.DecimalDec:
          return true;
        default:
          return false;
      }
    }
  }
}
