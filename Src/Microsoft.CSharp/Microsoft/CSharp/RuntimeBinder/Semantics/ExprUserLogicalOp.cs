// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprUserLogicalOp
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprUserLogicalOp : ExprWithType
  {
    public ExprUserLogicalOp(CType type, Expr trueFalseCall, ExprCall operatorCall)
      : base(ExpressionKind.UserLogicalOp, type)
    {
      this.Flags = EXPRFLAG.EXF_ASSGOP;
      this.TrueFalseCall = trueFalseCall;
      this.OperatorCall = operatorCall;
      Expr optionalElement = ((ExprList) operatorCall.OptionalArguments).OptionalElement;
      this.FirstOperandToExamine = optionalElement is ExprWrap exprWrap ? exprWrap.OptionalExpression : optionalElement;
    }

    public Expr TrueFalseCall { get; set; }

    public ExprCall OperatorCall { get; set; }

    public Expr FirstOperandToExamine { get; set; }
  }
}
