// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprCast
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprCast : ExprWithType
  {
    public ExprCast(EXPRFLAG flags, CType type, Expr argument)
      : base(ExpressionKind.Cast, type)
    {
      this.Argument = argument;
      this.Flags = flags;
    }

    public Expr Argument { get; set; }

    public bool IsBoxingCast
    {
      get => (this.Flags & (EXPRFLAG.EXF_CTOR | EXPRFLAG.EXF_UNREALIZEDGOTO)) != 0;
    }

    public override object Object
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        Expr expr = this.Argument;
        while (expr is ExprCast exprCast)
          expr = exprCast.Argument;
        return expr.Object;
      }
    }
  }
}
