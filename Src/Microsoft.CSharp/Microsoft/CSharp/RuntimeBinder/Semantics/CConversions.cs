// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.CConversions
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class CConversions
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool FImpRefConv(CType typeSrc, CType typeDst)
    {
      return typeSrc.IsReferenceType && SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeSrc, typeDst);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool FExpRefConv(CType typeSrc, CType typeDst)
    {
      if (typeSrc.IsReferenceType && typeDst.IsReferenceType)
      {
        if (SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeSrc, typeDst) || SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeDst, typeSrc) || typeSrc.IsInterfaceType && typeDst is TypeParameterType || typeSrc is TypeParameterType && typeDst.IsInterfaceType)
          return true;
        if (typeSrc is AggregateType aggregateType1 && typeDst is AggregateType aggregateType2)
        {
          AggregateSymbol owningAggregate1 = aggregateType1.OwningAggregate;
          AggregateSymbol owningAggregate2 = aggregateType2.OwningAggregate;
          if (owningAggregate1.IsClass() && !owningAggregate1.IsSealed() && owningAggregate2.IsInterface() || owningAggregate1.IsInterface() && owningAggregate2.IsClass() && !owningAggregate2.IsSealed() || owningAggregate1.IsInterface() && owningAggregate2.IsInterface())
            return true;
        }
        if (typeSrc is ArrayType arrayType1)
        {
          if (typeDst is ArrayType arrayType)
            return arrayType1.Rank == arrayType.Rank && arrayType1.IsSZArray == arrayType.IsSZArray && CConversions.FExpRefConv(arrayType1.ElementType, arrayType.ElementType);
          if (!arrayType1.IsSZArray || !typeDst.IsInterfaceType)
            return false;
          AggregateType aggregateType3 = (AggregateType) typeDst;
          TypeArray typeArgsAll = aggregateType3.TypeArgsAll;
          if (typeArgsAll.Count != 1)
            return false;
          AggregateSymbol predefAgg1 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
          AggregateSymbol predefAgg2 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
          return (predefAgg1 != null && SymbolLoader.IsBaseAggregate(predefAgg1, aggregateType3.OwningAggregate) || predefAgg2 != null && SymbolLoader.IsBaseAggregate(predefAgg2, aggregateType3.OwningAggregate)) && CConversions.FExpRefConv(arrayType1.ElementType, typeArgsAll[0]);
        }
        if (typeDst is ArrayType arrayType2 && typeSrc is AggregateType aggregateType4)
        {
          if (SymbolLoader.HasIdentityOrImplicitReferenceConversion((CType) SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY), typeSrc))
            return true;
          if (!arrayType2.IsSZArray || !typeSrc.IsInterfaceType || aggregateType4.TypeArgsAll.Count != 1)
            return false;
          AggregateSymbol predefAgg3 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
          AggregateSymbol predefAgg4 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
          if ((predefAgg3 == null || !SymbolLoader.IsBaseAggregate(predefAgg3, aggregateType4.OwningAggregate)) && (predefAgg4 == null || !SymbolLoader.IsBaseAggregate(predefAgg4, aggregateType4.OwningAggregate)))
            return false;
          CType elementType = arrayType2.ElementType;
          CType typeDst1 = aggregateType4.TypeArgsAll[0];
          return elementType == typeDst1 || CConversions.FExpRefConv(elementType, typeDst1);
        }
        if (CConversions.HasGenericDelegateExplicitReferenceConversion(typeSrc, typeDst))
          return true;
      }
      else
      {
        if (typeSrc.IsReferenceType)
          return SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeSrc, typeDst);
        if (typeDst.IsReferenceType)
          return SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeDst, typeSrc);
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool HasGenericDelegateExplicitReferenceConversion(CType source, CType target)
    {
      return target is AggregateType pTarget && CConversions.HasGenericDelegateExplicitReferenceConversion(source, pTarget);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool HasGenericDelegateExplicitReferenceConversion(
      CType pSource,
      AggregateType pTarget)
    {
      if (!(pSource is AggregateType pSource1) || !pSource1.IsDelegateType || !pTarget.IsDelegateType || pSource1.OwningAggregate != pTarget.OwningAggregate || SymbolLoader.HasIdentityOrImplicitReferenceConversion((CType) pSource1, (CType) pTarget))
        return false;
      TypeArray typeVarsAll = pSource1.OwningAggregate.GetTypeVarsAll();
      TypeArray typeArgsAll1 = pSource1.TypeArgsAll;
      TypeArray typeArgsAll2 = pTarget.TypeArgsAll;
      for (int i = 0; i < typeVarsAll.Count; ++i)
      {
        CType typeSrc = typeArgsAll1[i];
        CType typeDst = typeArgsAll2[i];
        if (typeSrc != typeDst)
        {
          TypeParameterType typeParameterType = (TypeParameterType) typeVarsAll[i];
          if (typeParameterType.Invariant)
            return false;
          if (typeParameterType.Covariant)
          {
            if (!CConversions.FExpRefConv(typeSrc, typeDst))
              return false;
          }
          else if (typeParameterType.Contravariant && (!typeSrc.IsReferenceType || !typeDst.IsReferenceType))
            return false;
        }
      }
      return true;
    }

    public static bool FWrappingConv(CType typeSrc, CType typeDst)
    {
      return typeDst is NullableType nullableType && typeSrc == nullableType.UnderlyingType;
    }

    public static bool FUnwrappingConv(CType typeSrc, CType typeDst)
    {
      return CConversions.FWrappingConv(typeDst, typeSrc);
    }
  }
}
