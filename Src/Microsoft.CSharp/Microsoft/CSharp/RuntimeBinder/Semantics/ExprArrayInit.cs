// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprArrayInit
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprArrayInit : ExprWithType
  {
    public ExprArrayInit(
      CType type,
      Expr arguments,
      Expr argumentDimensions,
      int[] dimensionSizes)
      : base(ExpressionKind.ArrayInit, type)
    {
      this.OptionalArguments = arguments;
      this.OptionalArgumentDimensions = argumentDimensions;
      this.DimensionSizes = dimensionSizes;
    }

    public Expr OptionalArguments { get; set; }

    public Expr OptionalArgumentDimensions { get; set; }

    public int[] DimensionSizes { get; }

    public bool GeneratedForParamArray { get; set; }
  }
}
