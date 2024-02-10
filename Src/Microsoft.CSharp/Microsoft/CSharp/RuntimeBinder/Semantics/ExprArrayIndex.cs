// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprArrayIndex
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprArrayIndex : ExprWithType
  {
    public ExprArrayIndex(CType type, Expr array, Expr index)
      : base(ExpressionKind.ArrayIndex, type)
    {
      this.Array = array;
      this.Index = index;
      this.Flags = EXPRFLAG.EXF_ASSGOP | EXPRFLAG.EXF_LVALUE;
    }

    public Expr Array { get; set; }

    public Expr Index { get; set; }
  }
}
