// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprBinOp
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprBinOp : ExprOperator
  {
    public ExprBinOp(ExpressionKind kind, CType type, Expr left, Expr right)
      : base(kind, type)
    {
      this.Flags = EXPRFLAG.EXF_BINOP;
      this.OptionalLeftChild = left;
      this.OptionalRightChild = right;
    }

    public ExprBinOp(
      ExpressionKind kind,
      CType type,
      Expr left,
      Expr right,
      Expr call,
      MethPropWithInst userMethod)
      : base(kind, type, call, userMethod)
    {
      this.Flags = EXPRFLAG.EXF_BINOP;
      this.OptionalLeftChild = left;
      this.OptionalRightChild = right;
    }

    public Expr OptionalLeftChild { get; set; }

    public Expr OptionalRightChild { get; set; }

    public bool IsLifted
    {
      set => this.\u003CIsLifted\u003Ek__BackingField = value;
    }

    public void SetAssignment() => this.Flags |= EXPRFLAG.EXF_ASSGOP;
  }
}
