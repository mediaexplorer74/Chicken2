// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprNamedArgumentSpecification
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprNamedArgumentSpecification : Expr
  {
    private Expr _value;

    public ExprNamedArgumentSpecification(Name name, Expr value)
      : base(ExpressionKind.NamedArgumentSpecification)
    {
      this.Name = name;
      this.Value = value;
    }

    public Name Name { get; }

    public Expr Value
    {
      get => this._value;
      set => this.Type = (this._value = value).Type;
    }
  }
}
