// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.AggregateType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class AggregateType : CType
  {
    private AggregateType _baseType;
    private TypeArray _ifacesAll;
    private Type _associatedSystemType;
    public bool? ConstraintError;
    public bool AllHidden;
    public bool DiffHidden;

    public AggregateType(AggregateSymbol parent, TypeArray typeArgsThis, AggregateType outerType)
      : base(TypeKind.TK_AggregateType)
    {
      this.OuterType = outerType;
      this.OwningAggregate = parent;
      this.TypeArgsThis = typeArgsThis;
      this.TypeArgsAll = outerType != null ? TypeArray.Concat(outerType.TypeArgsAll, typeArgsThis) : typeArgsThis;
    }

    public AggregateType OuterType { get; }

    public AggregateSymbol OwningAggregate { get; }

    public AggregateType BaseClass
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        if (this._baseType == null)
        {
          Type baseType = this.AssociatedSystemType.BaseType;
          if (baseType == (Type) null)
            return (AggregateType) null;
          this._baseType = TypeManager.SubstType(SymbolTable.GetCTypeFromType(baseType) as AggregateType, this.TypeArgsAll);
        }
        return this._baseType;
      }
    }

    public IEnumerable<AggregateType> TypeHierarchy
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        AggregateType aggregateType = this;
        if (aggregateType.IsInterfaceType)
        {
          yield return aggregateType;
          CType[] ctypeArray = aggregateType.IfacesAll.Items;
          for (int index = 0; index < ctypeArray.Length; ++index)
            yield return (AggregateType) ctypeArray[index];
          ctypeArray = (CType[]) null;
          yield return AggregateType.GetPredefinedAggregateGetThisTypeWithSuppressedMessage();
        }
        else
        {
          AggregateType agg;
          for (agg = aggregateType; agg != null; agg = agg.BaseClassWithSuppressedMessage)
            yield return agg;
          agg = (AggregateType) null;
        }
      }
    }

    private AggregateType BaseClassWithSuppressedMessage
    {
      [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Workarounds https://github.com/mono/linker/issues/1906. All usages are marked as unsafe.")] get
      {
        return this.BaseClass;
      }
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Workarounds https://github.com/mono/linker/issues/1906. All usages are marked as unsafe.")]
    private static AggregateType GetPredefinedAggregateGetThisTypeWithSuppressedMessage()
    {
      return PredefinedTypes.GetPredefinedAggregate(PredefinedType.PT_OBJECT).getThisType();
    }

    public TypeArray TypeArgsThis { get; }

    public TypeArray TypeArgsAll { get; }

    public TypeArray IfacesAll
    {
      get
      {
        return this._ifacesAll ?? (this._ifacesAll = TypeManager.SubstTypeArray(this.OwningAggregate.GetIfacesAll(), this.TypeArgsAll));
      }
    }

    public override bool IsReferenceType => this.OwningAggregate.IsRefType();

    public override bool IsNonNullableValueType => this.IsValueType;

    public override bool IsValueType => this.OwningAggregate.IsValueType();

    public override bool IsStaticClass => this.OwningAggregate.IsStatic();

    public override bool IsPredefined => this.OwningAggregate.IsPredefined();

    public override PredefinedType PredefinedType => this.OwningAggregate.GetPredefType();

    public override bool IsPredefType(PredefinedType pt)
    {
      AggregateSymbol owningAggregate = this.OwningAggregate;
      return owningAggregate.IsPredefined() && owningAggregate.GetPredefType() == pt;
    }

    public override bool IsDelegateType => this.OwningAggregate.IsDelegate();

    public override bool IsSimpleType
    {
      get
      {
        AggregateSymbol owningAggregate = this.OwningAggregate;
        return owningAggregate.IsPredefined() && PredefinedTypeFacts.IsSimpleType(owningAggregate.GetPredefType());
      }
    }

    public override bool IsSimpleOrEnum
    {
      get
      {
        AggregateSymbol owningAggregate = this.OwningAggregate;
        return !owningAggregate.IsPredefined() ? owningAggregate.IsEnum() : PredefinedTypeFacts.IsSimpleType(owningAggregate.GetPredefType());
      }
    }

    public override bool IsSimpleOrEnumOrString
    {
      get
      {
        AggregateSymbol owningAggregate = this.OwningAggregate;
        if (!owningAggregate.IsPredefined())
          return owningAggregate.IsEnum();
        PredefinedType predefType = owningAggregate.GetPredefType();
        return PredefinedTypeFacts.IsSimpleType(predefType) || predefType == PredefinedType.PT_STRING;
      }
    }

    public override bool IsNumericType
    {
      get
      {
        AggregateSymbol owningAggregate = this.OwningAggregate;
        return owningAggregate.IsPredefined() && PredefinedTypeFacts.IsNumericType(owningAggregate.GetPredefType());
      }
    }

    public override bool IsStructType => this.OwningAggregate.IsStruct();

    public override bool IsEnumType => this.OwningAggregate.IsEnum();

    public override bool IsInterfaceType => this.OwningAggregate.IsInterface();

    public override bool IsClassType => this.OwningAggregate.IsClass();

    public override AggregateType UnderlyingEnumType => this.OwningAggregate.GetUnderlyingType();

    public override Type AssociatedSystemType
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        Type associatedSystemType = this._associatedSystemType;
        return (object) associatedSystemType != null ? associatedSystemType : (this._associatedSystemType = this.CalculateAssociatedSystemType());
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Type CalculateAssociatedSystemType()
    {
      Type associatedSystemType = this.OwningAggregate.AssociatedSystemType;
      if (associatedSystemType.IsGenericType)
      {
        TypeArray typeArgsAll = this.TypeArgsAll;
        Type[] typeArray = new Type[typeArgsAll.Count];
        for (int i = 0; i < typeArray.Length; ++i)
        {
          CType ctype = typeArgsAll[i];
          if (ctype is TypeParameterType typeParameterType && typeParameterType.Symbol.name == null)
            return (Type) null;
          typeArray[i] = ctype.AssociatedSystemType;
        }
        try
        {
          return associatedSystemType.MakeGenericType(typeArray);
        }
        catch (ArgumentException ex)
        {
        }
      }
      return associatedSystemType;
    }

    public override FUNDTYPE FundamentalType
    {
      get
      {
        AggregateSymbol owningAggregate = this.OwningAggregate;
        if (owningAggregate.IsEnum())
          owningAggregate = owningAggregate.GetUnderlyingType().OwningAggregate;
        else if (!owningAggregate.IsStruct())
          return FUNDTYPE.FT_REF;
        return !owningAggregate.IsPredefined() ? FUNDTYPE.FT_STRUCT : PredefinedTypeFacts.GetFundType(owningAggregate.GetPredefType());
      }
    }

    public override ConstValKind ConstValKind
    {
      get
      {
        if (this.IsPredefType(PredefinedType.FirstNonSimpleType) || this.IsPredefType(PredefinedType.PT_UINTPTR))
          return ConstValKind.IntPtr;
        switch (this.FundamentalType)
        {
          case FUNDTYPE.FT_I1:
            return ConstValKind.Boolean;
          case FUNDTYPE.FT_I8:
          case FUNDTYPE.FT_U8:
            return ConstValKind.Long;
          case FUNDTYPE.FT_R4:
            return ConstValKind.Float;
          case FUNDTYPE.FT_R8:
            return ConstValKind.Double;
          case FUNDTYPE.FT_REF:
            return !this.IsPredefined || this.PredefinedType != PredefinedType.PT_STRING ? ConstValKind.IntPtr : ConstValKind.String;
          case FUNDTYPE.FT_STRUCT:
            return !this.IsPredefined || this.PredefinedType != PredefinedType.PT_DATETIME ? ConstValKind.Decimal : ConstValKind.Long;
          default:
            return ConstValKind.Int;
        }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public override AggregateType GetAts() => this;
  }
}
