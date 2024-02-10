// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.SymbolLoader
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class SymbolLoader
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static AggregateSymbol GetPredefAgg(PredefinedType pt) => TypeManager.GetPredefAgg(pt);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static AggregateType GetPredefindType(PredefinedType pt)
    {
      return SymbolLoader.GetPredefAgg(pt).getThisType();
    }

    public static Symbol LookupAggMember(Name name, AggregateSymbol agg, symbmask_t mask)
    {
      return SymbolStore.LookupSym(name, (ParentSymbol) agg, mask);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool IsBaseInterface(AggregateType atsDer, AggregateType pBase)
    {
      if (pBase.IsInterfaceType)
      {
        for (; atsDer != null; atsDer = atsDer.BaseClass)
        {
          foreach (CType pType1 in atsDer.IfacesAll.Items)
          {
            if (SymbolLoader.AreTypesEqualForConversion(pType1, (CType) pBase))
              return true;
          }
        }
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool IsBaseClassOfClass(CType pDerived, CType pBase)
    {
      return pDerived.IsClassType && SymbolLoader.IsBaseClass(pDerived, pBase);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool IsBaseClass(CType pDerived, CType pBase)
    {
      if (!(pBase is AggregateType aggregateType) || !aggregateType.IsClassType)
        return false;
      switch (pDerived)
      {
        case AggregateType ats:
label_5:
          for (AggregateType baseClass = ats.BaseClass; baseClass != null; baseClass = baseClass.BaseClass)
          {
            if (baseClass == aggregateType)
              return true;
          }
          return false;
        case NullableType nullableType:
          ats = nullableType.GetAts();
          goto label_5;
        default:
          return false;
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasCovariantArrayConversion(ArrayType pSource, ArrayType pDest)
    {
      return pSource.Rank == pDest.Rank && pSource.IsSZArray == pDest.IsSZArray && SymbolLoader.HasImplicitReferenceConversion(pSource.ElementType, pDest.ElementType);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool HasIdentityOrImplicitReferenceConversion(CType pSource, CType pDest)
    {
      return SymbolLoader.AreTypesEqualForConversion(pSource, pDest) || SymbolLoader.HasImplicitReferenceConversion(pSource, pDest);
    }

    private static bool AreTypesEqualForConversion(CType pType1, CType pType2)
    {
      return pType1.Equals((object) pType2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasArrayConversionToInterface(ArrayType pSource, CType pDest)
    {
      if (!pSource.IsSZArray || !pDest.IsInterfaceType)
        return false;
      if (pDest.IsPredefType(PredefinedType.PT_IENUMERABLE))
        return true;
      AggregateType aggregateType = (AggregateType) pDest;
      AggregateSymbol owningAggregate = aggregateType.OwningAggregate;
      return (owningAggregate.isPredefAgg(PredefinedType.PT_G_ILIST) || owningAggregate.isPredefAgg(PredefinedType.PT_G_ICOLLECTION) || owningAggregate.isPredefAgg(PredefinedType.PT_G_IENUMERABLE) || owningAggregate.isPredefAgg(PredefinedType.PT_G_IREADONLYCOLLECTION) || owningAggregate.isPredefAgg(PredefinedType.PT_G_IREADONLYLIST)) && SymbolLoader.HasIdentityOrImplicitReferenceConversion(pSource.ElementType, aggregateType.TypeArgsAll[0]);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasImplicitReferenceConversion(CType pSource, CType pDest)
    {
      if (pSource.IsReferenceType && pDest.IsPredefType(PredefinedType.PT_OBJECT))
        return true;
      switch (pSource)
      {
        case AggregateType aggregateType2:
          if (pDest is AggregateType aggregateType1)
          {
            switch (aggregateType2.OwningAggregate.AggKind())
            {
              case AggKindEnum.Class:
                switch (aggregateType1.OwningAggregate.AggKind())
                {
                  case AggKindEnum.Class:
                    return SymbolLoader.IsBaseClass((CType) aggregateType2, (CType) aggregateType1);
                  case AggKindEnum.Interface:
                    return SymbolLoader.HasAnyBaseInterfaceConversion((CType) aggregateType2, (CType) aggregateType1);
                }
                break;
              case AggKindEnum.Delegate:
                if (aggregateType1.IsPredefType(PredefinedType.PT_MULTIDEL) || aggregateType1.IsPredefType(PredefinedType.PT_DELEGATE) || SymbolLoader.IsBaseInterface(SymbolLoader.GetPredefindType(PredefinedType.PT_MULTIDEL), aggregateType1))
                  return true;
                return pDest.IsDelegateType && SymbolLoader.HasDelegateConversion(aggregateType2, aggregateType1);
              case AggKindEnum.Interface:
                if (aggregateType1.IsInterfaceType)
                  return SymbolLoader.HasAnyBaseInterfaceConversion((CType) aggregateType2, (CType) aggregateType1) || SymbolLoader.HasInterfaceConversion(aggregateType2, aggregateType1);
                break;
            }
          }
          else
            break;
          break;
        case ArrayType pSource1:
          switch (pDest)
          {
            case ArrayType pDest1:
              return SymbolLoader.HasCovariantArrayConversion(pSource1, pDest1);
            case AggregateType pBase:
              return pBase.IsPredefType(PredefinedType.PT_ARRAY) || SymbolLoader.IsBaseInterface(SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY), pBase) || SymbolLoader.HasArrayConversionToInterface(pSource1, pDest);
          }
          break;
        case NullType _:
          return pDest.IsReferenceType || pDest is NullableType;
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasAnyBaseInterfaceConversion(CType pDerived, CType pBase)
    {
      if (!pBase.IsInterfaceType || !(pDerived is AggregateType aggregateType))
        return false;
      AggregateType pDest = (AggregateType) pBase;
      for (; aggregateType != null; aggregateType = aggregateType.BaseClass)
      {
        foreach (AggregateType pSource in aggregateType.IfacesAll.Items)
        {
          if (SymbolLoader.HasInterfaceConversion(pSource, pDest))
            return true;
        }
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasInterfaceConversion(AggregateType pSource, AggregateType pDest)
    {
      return SymbolLoader.HasVariantConversion(pSource, pDest);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasDelegateConversion(AggregateType pSource, AggregateType pDest)
    {
      return SymbolLoader.HasVariantConversion(pSource, pDest);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasVariantConversion(AggregateType pSource, AggregateType pDest)
    {
      if (pSource == pDest)
        return true;
      AggregateSymbol owningAggregate = pSource.OwningAggregate;
      if (owningAggregate != pDest.OwningAggregate)
        return false;
      TypeArray typeVarsAll = owningAggregate.GetTypeVarsAll();
      TypeArray typeArgsAll1 = pSource.TypeArgsAll;
      TypeArray typeArgsAll2 = pDest.TypeArgsAll;
      for (int i = 0; i < typeVarsAll.Count; ++i)
      {
        CType ctype1 = typeArgsAll1[i];
        CType ctype2 = typeArgsAll2[i];
        if (ctype1 != ctype2)
        {
          TypeParameterType typeParameterType = (TypeParameterType) typeVarsAll[i];
          if (typeParameterType.Invariant || typeParameterType.Covariant && !SymbolLoader.HasImplicitReferenceConversion(ctype1, ctype2) || typeParameterType.Contravariant && !SymbolLoader.HasImplicitReferenceConversion(ctype2, ctype1))
            return false;
        }
      }
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool HasImplicitBoxingConversion(CType pSource, CType pDest)
    {
      if (!pDest.IsReferenceType)
        return false;
      if (pSource is NullableType nullableType)
        pSource = nullableType.UnderlyingType;
      else if (!pSource.IsValueType)
        return false;
      return SymbolLoader.IsBaseClass(pSource, pDest) || SymbolLoader.HasAnyBaseInterfaceConversion(pSource, pDest);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool HasBaseConversion(CType pSource, CType pDest)
    {
      return pSource is AggregateType && pDest.IsPredefType(PredefinedType.PT_OBJECT) || SymbolLoader.HasIdentityOrImplicitReferenceConversion(pSource, pDest) || SymbolLoader.HasImplicitBoxingConversion(pSource, pDest);
    }

    public static bool IsBaseAggregate(AggregateSymbol derived, AggregateSymbol @base)
    {
      if (derived == @base)
        return true;
      if (@base.IsInterface())
      {
        for (; derived != null; derived = derived.GetBaseAgg())
        {
          foreach (AggregateType aggregateType in derived.GetIfacesAll().Items)
          {
            if (aggregateType.OwningAggregate == @base)
              return true;
          }
        }
        return false;
      }
      while (derived.GetBaseClass() != null)
      {
        derived = derived.GetBaseClass().OwningAggregate;
        if (derived == @base)
          return true;
      }
      return false;
    }
  }
}
