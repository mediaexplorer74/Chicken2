// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.TypeParameterType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class TypeParameterType : CType
  {
    public TypeParameterType(TypeParameterSymbol symbol)
      : base(TypeKind.TK_TypeParameterType)
    {
      this.Symbol = symbol;
      symbol.SetTypeParameterType(this);
    }

    public TypeParameterSymbol Symbol { get; }

    public ParentSymbol OwningSymbol => this.Symbol.parent;

    public Name Name => this.Symbol.name;

    public bool Covariant => this.Symbol.Covariant;

    public bool Invariant => this.Symbol.Invariant;

    public bool Contravariant => this.Symbol.Contravariant;

    public override bool IsValueType => this.Symbol.IsValueType();

    public override bool IsReferenceType => this.Symbol.IsReferenceType();

    public override bool IsNonNullableValueType => this.Symbol.IsNonNullableValueType();

    public bool HasNewConstraint => this.Symbol.HasNewConstraint();

    public bool HasRefConstraint => this.Symbol.HasRefConstraint();

    public bool HasValConstraint => this.Symbol.HasValConstraint();

    public bool IsMethodTypeParameter => this.Symbol.IsMethodTypeParameter();

    public int IndexInOwnParameters => this.Symbol.GetIndexInOwnParameters();

    public int IndexInTotalParameters => this.Symbol.GetIndexInTotalParameters();

    public TypeArray Bounds => this.Symbol.GetBounds();

    public override Type AssociatedSystemType
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        return (this.IsMethodTypeParameter ? ((MethodBase) ((MethodSymbol) this.OwningSymbol).AssociatedMemberInfo).GetGenericArguments() : ((AggregateSymbol) this.OwningSymbol).AssociatedSystemType.GetGenericArguments())[this.IndexInOwnParameters];
      }
    }

    public override FUNDTYPE FundamentalType => FUNDTYPE.FT_VAR;
  }
}
