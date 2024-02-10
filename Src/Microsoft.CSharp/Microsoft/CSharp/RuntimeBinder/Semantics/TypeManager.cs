// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.TypeManager
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class TypeManager
  {
    private static readonly Dictionary<(Assembly, Assembly), bool> s_internalsVisibleToCache = new Dictionary<(Assembly, Assembly), bool>();
    private static readonly TypeManager.StdTypeVarColl s_stvcMethod = new TypeManager.StdTypeVarColl();

    public static ArrayType GetArray(CType elementType, int args, bool isSZArray)
    {
      int rankNum = isSZArray ? 0 : args;
      ArrayType pArray = TypeTable.LookupArray(elementType, rankNum);
      if (pArray == null)
      {
        pArray = new ArrayType(elementType, args, isSZArray);
        TypeTable.InsertArray(elementType, rankNum, pArray);
      }
      return pArray;
    }

    public static AggregateType GetAggregate(
      AggregateSymbol agg,
      AggregateType atsOuter,
      TypeArray typeArgs)
    {
      if (typeArgs == null)
        typeArgs = TypeArray.Empty;
      AggregateType ats = TypeTable.LookupAggregate(agg, atsOuter, typeArgs);
      if (ats == null)
      {
        ats = new AggregateType(agg, typeArgs, atsOuter);
        TypeTable.InsertAggregate(agg, atsOuter, typeArgs, ats);
      }
      return ats;
    }

    public static AggregateType GetAggregate(AggregateSymbol agg, TypeArray typeArgsAll)
    {
      if (typeArgsAll.Count == 0)
        return agg.getThisType();
      AggregateSymbol outerAgg = agg.GetOuterAgg();
      if (outerAgg == null)
        return TypeManager.GetAggregate(agg, (AggregateType) null, typeArgsAll);
      int count = outerAgg.GetTypeVarsAll().Count;
      TypeArray typeArgsAll1 = TypeArray.Allocate(count, typeArgsAll, 0);
      TypeArray typeArgs = TypeArray.Allocate(agg.GetTypeVars().Count, typeArgsAll, count);
      AggregateType aggregate = TypeManager.GetAggregate(outerAgg, typeArgsAll1);
      return TypeManager.GetAggregate(agg, aggregate, typeArgs);
    }

    public static PointerType GetPointer(CType baseType)
    {
      PointerType pointer = TypeTable.LookupPointer(baseType);
      if (pointer == null)
      {
        pointer = new PointerType(baseType);
        TypeTable.InsertPointer(baseType, pointer);
      }
      return pointer;
    }

    public static NullableType GetNullable(CType pUnderlyingType)
    {
      NullableType nullable = TypeTable.LookupNullable(pUnderlyingType);
      if (nullable == null)
      {
        nullable = new NullableType(pUnderlyingType);
        TypeTable.InsertNullable(pUnderlyingType, nullable);
      }
      return nullable;
    }

    public static ParameterModifierType GetParameterModifier(CType paramType, bool isOut)
    {
      ParameterModifierType parameterModifier = TypeTable.LookupParameterModifier(paramType, isOut);
      if (parameterModifier == null)
      {
        parameterModifier = new ParameterModifierType(paramType, isOut);
        TypeTable.InsertParameterModifier(paramType, isOut, parameterModifier);
      }
      return parameterModifier;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static AggregateSymbol GetNullable()
    {
      return TypeManager.GetPredefAgg(PredefinedType.PT_G_OPTIONAL);
    }

    private static CType SubstType(
      CType typeSrc,
      TypeArray typeArgsCls,
      TypeArray typeArgsMeth,
      bool denormMeth)
    {
      SubstContext pctx = new SubstContext(typeArgsCls, typeArgsMeth, denormMeth);
      return !pctx.IsNop ? TypeManager.SubstTypeCore(typeSrc, pctx) : typeSrc;
    }

    public static AggregateType SubstType(AggregateType typeSrc, TypeArray typeArgsCls)
    {
      SubstContext ctx = new SubstContext(typeArgsCls, (TypeArray) null, false);
      return !ctx.IsNop ? TypeManager.SubstTypeCore(typeSrc, ctx) : typeSrc;
    }

    private static CType SubstType(CType typeSrc, TypeArray typeArgsCls, TypeArray typeArgsMeth)
    {
      return TypeManager.SubstType(typeSrc, typeArgsCls, typeArgsMeth, false);
    }

    public static TypeArray SubstTypeArray(TypeArray taSrc, SubstContext ctx)
    {
      if (taSrc != null && taSrc.Count != 0 && ctx != null && !ctx.IsNop)
      {
        CType[] items = taSrc.Items;
        for (int length = 0; length < items.Length; ++length)
        {
          CType type = items[length];
          CType ctype = TypeManager.SubstTypeCore(type, ctx);
          if (type != ctype)
          {
            CType[] destinationArray = new CType[items.Length];
            Array.Copy((Array) items, (Array) destinationArray, length);
            destinationArray[length] = ctype;
            while (++length < items.Length)
              destinationArray[length] = TypeManager.SubstTypeCore(items[length], ctx);
            return TypeArray.Allocate(destinationArray);
          }
        }
      }
      return taSrc;
    }

    public static TypeArray SubstTypeArray(
      TypeArray taSrc,
      TypeArray typeArgsCls,
      TypeArray typeArgsMeth)
    {
      return taSrc != null && taSrc.Count != 0 ? TypeManager.SubstTypeArray(taSrc, new SubstContext(typeArgsCls, typeArgsMeth, false)) : taSrc;
    }

    public static TypeArray SubstTypeArray(TypeArray taSrc, TypeArray typeArgsCls)
    {
      return TypeManager.SubstTypeArray(taSrc, typeArgsCls, (TypeArray) null);
    }

    private static AggregateType SubstTypeCore(AggregateType type, SubstContext ctx)
    {
      TypeArray typeArgsAll1 = type.TypeArgsAll;
      if (typeArgsAll1.Count > 0)
      {
        TypeArray typeArgsAll2 = TypeManager.SubstTypeArray(typeArgsAll1, ctx);
        if (typeArgsAll1 != typeArgsAll2)
          return TypeManager.GetAggregate(type.OwningAggregate, typeArgsAll2);
      }
      return type;
    }

    private static CType SubstTypeCore(CType type, SubstContext pctx)
    {
      switch (type.TypeKind)
      {
        case TypeKind.TK_AggregateType:
          return (CType) TypeManager.SubstTypeCore((AggregateType) type, pctx);
        case TypeKind.TK_VoidType:
        case TypeKind.TK_NullType:
        case TypeKind.TK_MethodGroupType:
        case TypeKind.TK_ArgumentListType:
          return type;
        case TypeKind.TK_ArrayType:
          ArrayType arrayType = (ArrayType) type;
          CType elementType1;
          CType elementType2 = TypeManager.SubstTypeCore(elementType1 = arrayType.ElementType, pctx);
          return elementType2 != elementType1 ? (CType) TypeManager.GetArray(elementType2, arrayType.Rank, arrayType.IsSZArray) : type;
        case TypeKind.TK_PointerType:
          CType referentType;
          CType baseType = TypeManager.SubstTypeCore(referentType = ((PointerType) type).ReferentType, pctx);
          return baseType != referentType ? (CType) TypeManager.GetPointer(baseType) : type;
        case TypeKind.TK_ParameterModifierType:
          ParameterModifierType parameterModifierType = (ParameterModifierType) type;
          CType parameterType;
          CType paramType = TypeManager.SubstTypeCore(parameterType = parameterModifierType.ParameterType, pctx);
          return paramType != parameterType ? (CType) TypeManager.GetParameterModifier(paramType, parameterModifierType.IsOut) : type;
        case TypeKind.TK_NullableType:
          CType underlyingType;
          CType pUnderlyingType = TypeManager.SubstTypeCore(underlyingType = ((NullableType) type).UnderlyingType, pctx);
          return pUnderlyingType != underlyingType ? (CType) TypeManager.GetNullable(pUnderlyingType) : type;
        case TypeKind.TK_TypeParameterType:
          TypeParameterSymbol symbol = ((TypeParameterType) type).Symbol;
          int inTotalParameters = symbol.GetIndexInTotalParameters();
          return symbol.IsMethodTypeParameter() ? (pctx.DenormMeth && symbol.parent != null || inTotalParameters >= pctx.MethodTypes.Length ? type : pctx.MethodTypes[inTotalParameters]) : (inTotalParameters >= pctx.ClassTypes.Length ? type : pctx.ClassTypes[inTotalParameters]);
        default:
          return type;
      }
    }

    public static bool SubstEqualTypes(
      CType typeDst,
      CType typeSrc,
      TypeArray typeArgsCls,
      TypeArray typeArgsMeth,
      bool denormMeth)
    {
      if (typeDst.Equals((object) typeSrc))
        return true;
      SubstContext pctx = new SubstContext(typeArgsCls, typeArgsMeth, denormMeth);
      return !pctx.IsNop && TypeManager.SubstEqualTypesCore(typeDst, typeSrc, pctx);
    }

    public static bool SubstEqualTypeArrays(
      TypeArray taDst,
      TypeArray taSrc,
      TypeArray typeArgsCls,
      TypeArray typeArgsMeth)
    {
      if (taDst == taSrc || taDst != null && taDst.Equals((object) taSrc))
        return true;
      if (taDst.Count != taSrc.Count)
        return false;
      if (taDst.Count == 0)
        return true;
      SubstContext pctx = new SubstContext(typeArgsCls, typeArgsMeth, true);
      if (pctx.IsNop)
        return false;
      for (int i = 0; i < taDst.Count; ++i)
      {
        if (!TypeManager.SubstEqualTypesCore(taDst[i], taSrc[i], pctx))
          return false;
      }
      return true;
    }

    private static bool SubstEqualTypesCore(CType typeDst, CType typeSrc, SubstContext pctx)
    {
      for (; typeDst != typeSrc && !typeDst.Equals((object) typeSrc); typeDst = typeDst.BaseOrParameterOrElementType)
      {
        switch (typeSrc.TypeKind)
        {
          case TypeKind.TK_AggregateType:
            if (!(typeDst is AggregateType aggregateType1))
              return false;
            AggregateType aggregateType2 = (AggregateType) typeSrc;
            if (aggregateType2.OwningAggregate != aggregateType1.OwningAggregate)
              return false;
            for (int i = 0; i < aggregateType2.TypeArgsAll.Count; ++i)
            {
              if (!TypeManager.SubstEqualTypesCore(aggregateType1.TypeArgsAll[i], aggregateType2.TypeArgsAll[i], pctx))
                return false;
            }
            return true;
          case TypeKind.TK_VoidType:
          case TypeKind.TK_NullType:
            return false;
          case TypeKind.TK_ArrayType:
            ArrayType arrayType1 = (ArrayType) typeSrc;
            if (!(typeDst is ArrayType arrayType2) || arrayType2.Rank != arrayType1.Rank || arrayType2.IsSZArray != arrayType1.IsSZArray)
              return false;
            break;
          case TypeKind.TK_PointerType:
          case TypeKind.TK_NullableType:
            if (typeDst.TypeKind != typeSrc.TypeKind)
              return false;
            break;
          case TypeKind.TK_ParameterModifierType:
            if (!(typeDst is ParameterModifierType parameterModifierType) || parameterModifierType.IsOut != ((ParameterModifierType) typeSrc).IsOut)
              return false;
            break;
          case TypeKind.TK_TypeParameterType:
            TypeParameterSymbol symbol = ((TypeParameterType) typeSrc).Symbol;
            int inTotalParameters = symbol.GetIndexInTotalParameters();
            return symbol.IsMethodTypeParameter() ? (!pctx.DenormMeth || symbol.parent == null) && inTotalParameters < pctx.MethodTypes.Length && typeDst == pctx.MethodTypes[inTotalParameters] : inTotalParameters < pctx.ClassTypes.Length && typeDst == pctx.ClassTypes[inTotalParameters];
          default:
            return false;
        }
        typeSrc = typeSrc.BaseOrParameterOrElementType;
      }
      return true;
    }

    public static bool TypeContainsType(CType type, CType typeFind)
    {
      for (; type != typeFind && !type.Equals((object) typeFind); type = type.BaseOrParameterOrElementType)
      {
        switch (type.TypeKind)
        {
          case TypeKind.TK_AggregateType:
            AggregateType aggregateType = (AggregateType) type;
            for (int i = 0; i < aggregateType.TypeArgsAll.Count; ++i)
            {
              if (TypeManager.TypeContainsType(aggregateType.TypeArgsAll[i], typeFind))
                return true;
            }
            return false;
          case TypeKind.TK_VoidType:
          case TypeKind.TK_NullType:
            return false;
          case TypeKind.TK_ArrayType:
          case TypeKind.TK_PointerType:
          case TypeKind.TK_ParameterModifierType:
          case TypeKind.TK_NullableType:
            continue;
          case TypeKind.TK_TypeParameterType:
            return false;
          default:
            return false;
        }
      }
      return true;
    }

    public static bool TypeContainsTyVars(CType type, TypeArray typeVars)
    {
      while (true)
      {
        switch (type.TypeKind)
        {
          case TypeKind.TK_AggregateType:
            goto label_4;
          case TypeKind.TK_VoidType:
          case TypeKind.TK_NullType:
          case TypeKind.TK_MethodGroupType:
            goto label_2;
          case TypeKind.TK_ArrayType:
          case TypeKind.TK_PointerType:
          case TypeKind.TK_ParameterModifierType:
          case TypeKind.TK_NullableType:
            type = type.BaseOrParameterOrElementType;
            continue;
          case TypeKind.TK_TypeParameterType:
            goto label_10;
          default:
            goto label_1;
        }
      }
label_1:
      return false;
label_2:
      return false;
label_4:
      AggregateType aggregateType = (AggregateType) type;
      for (int i = 0; i < aggregateType.TypeArgsAll.Count; ++i)
      {
        if (TypeManager.TypeContainsTyVars(aggregateType.TypeArgsAll[i], typeVars))
          return true;
      }
      return false;
label_10:
      if (typeVars == null || typeVars.Count <= 0)
        return true;
      int inTotalParameters = ((TypeParameterType) type).IndexInTotalParameters;
      return inTotalParameters < typeVars.Count && type == typeVars[inTotalParameters];
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static AggregateSymbol GetPredefAgg(PredefinedType pt)
    {
      return PredefinedTypes.GetPredefinedAggregate(pt);
    }

    public static AggregateType SubstType(AggregateType typeSrc, SubstContext ctx)
    {
      return ctx != null && !ctx.IsNop ? TypeManager.SubstTypeCore(typeSrc, ctx) : typeSrc;
    }

    public static CType SubstType(CType typeSrc, SubstContext pctx)
    {
      return pctx != null && !pctx.IsNop ? TypeManager.SubstTypeCore(typeSrc, pctx) : typeSrc;
    }

    public static CType SubstType(CType typeSrc, AggregateType atsCls)
    {
      return TypeManager.SubstType(typeSrc, atsCls, (TypeArray) null);
    }

    public static CType SubstType(CType typeSrc, AggregateType atsCls, TypeArray typeArgsMeth)
    {
      return TypeManager.SubstType(typeSrc, atsCls?.TypeArgsAll, typeArgsMeth);
    }

    public static CType SubstType(CType typeSrc, CType typeCls, TypeArray typeArgsMeth)
    {
      return TypeManager.SubstType(typeSrc, typeCls is AggregateType aggregateType ? aggregateType.TypeArgsAll : (TypeArray) null, typeArgsMeth);
    }

    public static TypeArray SubstTypeArray(
      TypeArray taSrc,
      AggregateType atsCls,
      TypeArray typeArgsMeth)
    {
      return TypeManager.SubstTypeArray(taSrc, atsCls?.TypeArgsAll, typeArgsMeth);
    }

    public static TypeArray SubstTypeArray(TypeArray taSrc, AggregateType atsCls)
    {
      return TypeManager.SubstTypeArray(taSrc, atsCls, (TypeArray) null);
    }

    private static bool SubstEqualTypes(
      CType typeDst,
      CType typeSrc,
      CType typeCls,
      TypeArray typeArgsMeth)
    {
      return TypeManager.SubstEqualTypes(typeDst, typeSrc, typeCls is AggregateType aggregateType ? aggregateType.TypeArgsAll : (TypeArray) null, typeArgsMeth, false);
    }

    public static bool SubstEqualTypes(CType typeDst, CType typeSrc, CType typeCls)
    {
      return TypeManager.SubstEqualTypes(typeDst, typeSrc, typeCls, (TypeArray) null);
    }

    public static TypeParameterType GetStdMethTypeVar(int iv)
    {
      return TypeManager.s_stvcMethod.GetTypeVarSym(iv, true);
    }

    public static TypeParameterType GetTypeParameter(TypeParameterSymbol pSymbol)
    {
      return new TypeParameterType(pSymbol);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static CType GetBestAccessibleType(AggregateSymbol context, CType typeSrc)
    {
      if (CSemanticChecker.CheckTypeAccess(typeSrc, (Symbol) context))
        return typeSrc;
      switch (typeSrc)
      {
        case AggregateType typeSrc1:
          CType typeDst1;
          AggregateType baseClass;
          for (; !typeSrc1.IsInterfaceType && !typeSrc1.IsDelegateType || !TypeManager.TryVarianceAdjustmentToGetAccessibleType(context, typeSrc1, out typeDst1); typeSrc1 = baseClass)
          {
            baseClass = typeSrc1.BaseClass;
            if (baseClass == null)
              return (CType) TypeManager.GetPredefAgg(PredefinedType.PT_OBJECT).getThisType();
            if (CSemanticChecker.CheckTypeAccess((CType) baseClass, (Symbol) context))
              return (CType) baseClass;
          }
          return typeDst1;
        case ArrayType typeSrc2:
          CType typeDst2;
          return TypeManager.TryArrayVarianceAdjustmentToGetAccessibleType(context, typeSrc2, out typeDst2) ? typeDst2 : (CType) TypeManager.GetPredefAgg(PredefinedType.PT_ARRAY).getThisType();
        default:
          return (CType) TypeManager.GetPredefAgg(PredefinedType.PT_VALUE).getThisType();
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool TryVarianceAdjustmentToGetAccessibleType(
      AggregateSymbol context,
      AggregateType typeSrc,
      out CType typeDst)
    {
      typeDst = (CType) null;
      AggregateSymbol owningAggregate = typeSrc.OwningAggregate;
      AggregateType thisType = owningAggregate.getThisType();
      if (!CSemanticChecker.CheckTypeAccess((CType) thisType, (Symbol) context))
        return false;
      TypeArray typeArgsThis1 = typeSrc.TypeArgsThis;
      TypeArray typeArgsThis2 = thisType.TypeArgsThis;
      CType[] ctypeArray = new CType[typeArgsThis1.Count];
      for (int i = 0; i < ctypeArray.Length; ++i)
      {
        CType ctype = typeArgsThis1[i];
        if (CSemanticChecker.CheckTypeAccess(ctype, (Symbol) context))
        {
          ctypeArray[i] = ctype;
        }
        else
        {
          if (!ctype.IsReferenceType || !((TypeParameterType) typeArgsThis2[i]).Covariant)
            return false;
          ctypeArray[i] = TypeManager.GetBestAccessibleType(context, ctype);
        }
      }
      TypeArray typeArgs = TypeArray.Allocate(ctypeArray);
      CType aggregate = (CType) TypeManager.GetAggregate(owningAggregate, typeSrc.OuterType, typeArgs);
      if (!TypeBind.CheckConstraints(aggregate, CheckConstraintsFlags.NoErrors))
        return false;
      typeDst = aggregate;
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool TryArrayVarianceAdjustmentToGetAccessibleType(
      AggregateSymbol context,
      ArrayType typeSrc,
      out CType typeDst)
    {
      CType elementType = typeSrc.ElementType;
      if (elementType.IsReferenceType)
      {
        CType bestAccessibleType = TypeManager.GetBestAccessibleType(context, elementType);
        typeDst = (CType) TypeManager.GetArray(bestAccessibleType, typeSrc.Rank, typeSrc.IsSZArray);
        return true;
      }
      typeDst = (CType) null;
      return false;
    }

    internal static bool InternalsVisibleTo(
      Assembly assemblyThatDefinesAttribute,
      Assembly assemblyToCheck)
    {
      (Assembly, Assembly) key = (assemblyThatDefinesAttribute, assemblyToCheck);
      bool flag;
      if (!TypeManager.s_internalsVisibleToCache.TryGetValue(key, out flag))
      {
        try
        {
          AssemblyName name = assemblyToCheck.GetName();
          foreach (Attribute customAttribute in assemblyThatDefinesAttribute.GetCustomAttributes())
          {
            if (customAttribute is InternalsVisibleToAttribute visibleToAttribute && AssemblyName.ReferenceMatchesDefinition(new AssemblyName(visibleToAttribute.AssemblyName), name))
            {
              flag = true;
              break;
            }
          }
        }
        catch (SecurityException ex)
        {
          flag = false;
        }
        TypeManager.s_internalsVisibleToCache[key] = flag;
      }
      return flag;
    }

    private sealed class StdTypeVarColl
    {
      private readonly List<TypeParameterType> prgptvs;

      public StdTypeVarColl() => this.prgptvs = new List<TypeParameterType>();

      public TypeParameterType GetTypeVarSym(int iv, bool fMeth)
      {
        TypeParameterType typeVarSym;
        if (iv >= this.prgptvs.Count)
        {
          TypeParameterSymbol pSymbol = new TypeParameterSymbol();
          pSymbol.SetIsMethodTypeParameter(fMeth);
          pSymbol.SetIndexInOwnParameters(iv);
          pSymbol.SetIndexInTotalParameters(iv);
          pSymbol.SetAccess(ACCESS.ACC_PRIVATE);
          typeVarSym = TypeManager.GetTypeParameter(pSymbol);
          this.prgptvs.Add(typeVarSym);
        }
        else
          typeVarSym = this.prgptvs[iv];
        return typeVarSym;
      }
    }
  }
}
