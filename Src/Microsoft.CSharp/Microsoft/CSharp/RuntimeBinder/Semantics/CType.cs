// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.CType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal abstract class CType
  {
    private protected CType(TypeKind kind) => this.TypeKind = kind;

    [ExcludeFromCodeCoverage(Justification = "Should only be called through override")]
    public virtual Type AssociatedSystemType
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        throw Error.InternalCompilerError();
      }
    }

    public TypeKind TypeKind { get; }

    public virtual CType BaseOrParameterOrElementType => (CType) null;

    public virtual FUNDTYPE FundamentalType => FUNDTYPE.FT_NONE;

    public virtual ConstValKind ConstValKind => ConstValKind.Int;

    public CType GetNakedType(bool fStripNub)
    {
      CType nakedType = this;
      while (true)
      {
        switch (nakedType.TypeKind)
        {
          case TypeKind.TK_ArrayType:
          case TypeKind.TK_PointerType:
          case TypeKind.TK_ParameterModifierType:
            nakedType = nakedType.BaseOrParameterOrElementType;
            continue;
          case TypeKind.TK_NullableType:
            if (!fStripNub)
              goto label_2;
            else
              goto case TypeKind.TK_ArrayType;
          default:
            goto label_2;
        }
      }
label_2:
      return nakedType;
    }

    public virtual CType StripNubs() => this;

    public virtual CType StripNubs(out bool wasNullable)
    {
      wasNullable = false;
      return this;
    }

    public virtual bool IsDelegateType => false;

    public virtual bool IsSimpleType => false;

    public virtual bool IsSimpleOrEnum => false;

    public virtual bool IsSimpleOrEnumOrString => false;

    public virtual bool IsNumericType => false;

    public virtual bool IsStructType => false;

    public virtual bool IsEnumType => false;

    public virtual bool IsInterfaceType => false;

    public virtual bool IsClassType => false;

    [ExcludeFromCodeCoverage(Justification = "Should only be called through override")]
    public virtual AggregateType UnderlyingEnumType => throw Error.InternalCompilerError();

    public virtual bool IsUnsafe() => false;

    public virtual bool IsPredefType(PredefinedType pt) => false;

    public virtual bool IsPredefined => false;

    [ExcludeFromCodeCoverage(Justification = "Should only be called through override")]
    public virtual PredefinedType PredefinedType => throw Error.InternalCompilerError();

    public virtual bool IsStaticClass => false;

    public virtual bool IsValueType => false;

    public virtual bool IsNonNullableValueType => false;

    public virtual bool IsReferenceType => false;

    [ExcludeFromCodeCoverage(Justification = "Should only be called through override")]
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public virtual AggregateType GetAts() => (AggregateType) null;
  }
}
