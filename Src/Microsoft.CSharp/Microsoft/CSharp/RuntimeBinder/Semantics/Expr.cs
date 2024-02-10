// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.Expr
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal abstract class Expr
  {
    private CType _type;

    protected Expr(ExpressionKind kind) => this.Kind = kind;

    internal object RuntimeObject { get; set; }

    internal CType RuntimeObjectActualType { get; set; }

    public ExpressionKind Kind { get; }

    public EXPRFLAG Flags { get; set; }

    public bool IsOptionalArgument { get; set; }

    public string ErrorString { get; set; }

    public CType Type
    {
      get => this._type;
      protected set => this._type = value;
    }

    [ExcludeFromCodeCoverage(Justification = "Should only be called through override")]
    public virtual object Object
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        throw Error.InternalCompilerError();
      }
    }
  }
}
