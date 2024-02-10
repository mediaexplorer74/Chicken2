// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.MethodTypeInferrer
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
  internal sealed class MethodTypeInferrer
  {
    private readonly ExpressionBinder _binder;
    private readonly TypeArray _pMethodTypeParameters;
    private readonly TypeArray _pMethodFormalParameterTypes;
    private readonly ArgInfos _pMethodArguments;
    private readonly List<CType>[] _pExactBounds;
    private readonly List<CType>[] _pUpperBounds;
    private readonly List<CType>[] _pLowerBounds;
    private readonly CType[] _pFixedResults;
    private MethodTypeInferrer.Dependency[][] _ppDependencies;
    private bool _dependenciesDirty;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool Infer(
      ExpressionBinder binder,
      MethodSymbol pMethod,
      TypeArray pMethodFormalParameterTypes,
      ArgInfos pMethodArguments,
      out TypeArray ppInferredTypeArguments)
    {
      ppInferredTypeArguments = (TypeArray) null;
      if (pMethodFormalParameterTypes.Count == 0 || pMethod.InferenceMustFail())
        return false;
      MethodTypeInferrer methodTypeInferrer = new MethodTypeInferrer(binder, pMethodFormalParameterTypes, pMethodArguments, pMethod.typeVars);
      bool flag = methodTypeInferrer.InferTypeArgs();
      ppInferredTypeArguments = methodTypeInferrer.GetResults();
      return flag;
    }

    private MethodTypeInferrer(
      ExpressionBinder exprBinder,
      TypeArray pMethodFormalParameterTypes,
      ArgInfos pMethodArguments,
      TypeArray pMethodTypeParameters)
    {
      this._binder = exprBinder;
      this._pMethodFormalParameterTypes = pMethodFormalParameterTypes;
      this._pMethodArguments = pMethodArguments;
      this._pMethodTypeParameters = pMethodTypeParameters;
      this._pFixedResults = new CType[pMethodTypeParameters.Count];
      this._pLowerBounds = new List<CType>[pMethodTypeParameters.Count];
      this._pUpperBounds = new List<CType>[pMethodTypeParameters.Count];
      this._pExactBounds = new List<CType>[pMethodTypeParameters.Count];
      for (int index = 0; index < pMethodTypeParameters.Count; ++index)
      {
        this._pLowerBounds[index] = new List<CType>();
        this._pUpperBounds[index] = new List<CType>();
        this._pExactBounds[index] = new List<CType>();
      }
      this._ppDependencies = (MethodTypeInferrer.Dependency[][]) null;
    }

    private TypeArray GetResults() => TypeArray.Allocate(this._pFixedResults);

    private bool IsUnfixed(int iParam) => this._pFixedResults[iParam] == null;

    private bool IsUnfixed(TypeParameterType pParam)
    {
      return this.IsUnfixed(pParam.IndexInTotalParameters);
    }

    private bool AllFixed()
    {
      for (int iParam = 0; iParam < this._pMethodTypeParameters.Count; ++iParam)
      {
        if (this.IsUnfixed(iParam))
          return false;
      }
      return true;
    }

    private void AddLowerBound(TypeParameterType pParam, CType pBound)
    {
      int inTotalParameters = pParam.IndexInTotalParameters;
      if (this._pLowerBounds[inTotalParameters].Contains(pBound))
        return;
      this._pLowerBounds[inTotalParameters].Add(pBound);
    }

    private void AddUpperBound(TypeParameterType pParam, CType pBound)
    {
      int inTotalParameters = pParam.IndexInTotalParameters;
      if (this._pUpperBounds[inTotalParameters].Contains(pBound))
        return;
      this._pUpperBounds[inTotalParameters].Add(pBound);
    }

    private void AddExactBound(TypeParameterType pParam, CType pBound)
    {
      int inTotalParameters = pParam.IndexInTotalParameters;
      if (this._pExactBounds[inTotalParameters].Contains(pBound))
        return;
      this._pExactBounds[inTotalParameters].Add(pBound);
    }

    private bool HasBound(int iParam)
    {
      return !this._pLowerBounds[iParam].IsEmpty<CType>() || !this._pExactBounds[iParam].IsEmpty<CType>() || !this._pUpperBounds[iParam].IsEmpty<CType>();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool InferTypeArgs()
    {
      this.InferTypeArgsFirstPhase();
      return this.InferTypeArgsSecondPhase();
    }

    private static bool IsReallyAType(CType pType)
    {
      switch (pType)
      {
        case NullType _:
        case VoidType _:
          return false;
        default:
          return !(pType is MethodGroupType);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void InferTypeArgsFirstPhase()
    {
      for (int index = 0; index < this._pMethodArguments.carg; ++index)
      {
        Expr expr = this._pMethodArguments.prgexpr[index];
        if (!expr.IsOptionalArgument)
        {
          CType pDest = this._pMethodFormalParameterTypes[index];
          CType ctype = expr.RuntimeObjectActualType ?? this._pMethodArguments.types[index];
          bool flag = false;
          if (pDest is ParameterModifierType parameterModifierType1)
          {
            pDest = parameterModifierType1.ParameterType;
            flag = true;
          }
          if (ctype is ParameterModifierType parameterModifierType2)
            ctype = parameterModifierType2.ParameterType;
          if (MethodTypeInferrer.IsReallyAType(ctype))
          {
            if (flag)
              this.ExactInference(ctype, pDest);
            else
              this.LowerBoundInference(ctype, pDest);
          }
        }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool InferTypeArgsSecondPhase()
    {
      this.InitializeDependencies();
      MethodTypeInferrer.NewInferenceResult newInferenceResult;
      do
      {
        newInferenceResult = this.DoSecondPhase();
        if (newInferenceResult == MethodTypeInferrer.NewInferenceResult.InferenceFailed)
          return false;
      }
      while (newInferenceResult != MethodTypeInferrer.NewInferenceResult.Success);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private MethodTypeInferrer.NewInferenceResult DoSecondPhase()
    {
      if (this.AllFixed())
        return MethodTypeInferrer.NewInferenceResult.Success;
      MethodTypeInferrer.NewInferenceResult newInferenceResult1 = this.FixNondependentParameters();
      if (newInferenceResult1 != MethodTypeInferrer.NewInferenceResult.NoProgress)
        return newInferenceResult1;
      MethodTypeInferrer.NewInferenceResult newInferenceResult2 = this.FixDependentParameters();
      return newInferenceResult2 != MethodTypeInferrer.NewInferenceResult.NoProgress ? newInferenceResult2 : MethodTypeInferrer.NewInferenceResult.InferenceFailed;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private MethodTypeInferrer.NewInferenceResult FixNondependentParameters()
    {
      bool[] flagArray = new bool[this._pMethodTypeParameters.Count];
      MethodTypeInferrer.NewInferenceResult newInferenceResult = MethodTypeInferrer.NewInferenceResult.NoProgress;
      for (int iParam = 0; iParam < this._pMethodTypeParameters.Count; ++iParam)
      {
        if (this.IsUnfixed(iParam) && this.HasBound(iParam) && !this.DependsOnAny(iParam))
        {
          flagArray[iParam] = true;
          newInferenceResult = MethodTypeInferrer.NewInferenceResult.MadeProgress;
        }
      }
      for (int iParam = 0; iParam < this._pMethodTypeParameters.Count; ++iParam)
      {
        if (flagArray[iParam] && !this.Fix(iParam))
          newInferenceResult = MethodTypeInferrer.NewInferenceResult.InferenceFailed;
      }
      return newInferenceResult;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private MethodTypeInferrer.NewInferenceResult FixDependentParameters()
    {
      bool[] flagArray = new bool[this._pMethodTypeParameters.Count];
      MethodTypeInferrer.NewInferenceResult newInferenceResult = MethodTypeInferrer.NewInferenceResult.NoProgress;
      for (int iParam = 0; iParam < this._pMethodTypeParameters.Count; ++iParam)
      {
        if (this.IsUnfixed(iParam) && this.HasBound(iParam) && this.AnyDependsOn(iParam))
        {
          flagArray[iParam] = true;
          newInferenceResult = MethodTypeInferrer.NewInferenceResult.MadeProgress;
        }
      }
      for (int iParam = 0; iParam < this._pMethodTypeParameters.Count; ++iParam)
      {
        if (flagArray[iParam] && !this.Fix(iParam))
          newInferenceResult = MethodTypeInferrer.NewInferenceResult.InferenceFailed;
      }
      return newInferenceResult;
    }

    private void InitializeDependencies()
    {
      this._ppDependencies = new MethodTypeInferrer.Dependency[this._pMethodTypeParameters.Count][];
      for (int index = 0; index < this._pMethodTypeParameters.Count; ++index)
        this._ppDependencies[index] = new MethodTypeInferrer.Dependency[this._pMethodTypeParameters.Count];
      this.DeduceAllDependencies();
    }

    private bool DependsOn(int iParam, int jParam)
    {
      if (this._dependenciesDirty)
      {
        this.SetIndirectsToUnknown();
        this.DeduceAllDependencies();
      }
      return (this._ppDependencies[iParam][jParam] & MethodTypeInferrer.Dependency.DependsMask) != 0;
    }

    private bool DependsTransitivelyOn(int iParam, int jParam)
    {
      for (int index = 0; index < this._pMethodTypeParameters.Count; ++index)
      {
        if ((this._ppDependencies[iParam][index] & MethodTypeInferrer.Dependency.DependsMask) != MethodTypeInferrer.Dependency.Unknown && (this._ppDependencies[index][jParam] & MethodTypeInferrer.Dependency.DependsMask) != MethodTypeInferrer.Dependency.Unknown)
          return true;
      }
      return false;
    }

    private void DeduceAllDependencies()
    {
      do
        ;
      while (this.DeduceDependencies());
      this.SetUnknownsToNotDependent();
      this._dependenciesDirty = false;
    }

    private bool DeduceDependencies()
    {
      bool flag = false;
      for (int iParam = 0; iParam < this._pMethodTypeParameters.Count; ++iParam)
      {
        for (int jParam = 0; jParam < this._pMethodTypeParameters.Count; ++jParam)
        {
          if (this._ppDependencies[iParam][jParam] == MethodTypeInferrer.Dependency.Unknown && this.DependsTransitivelyOn(iParam, jParam))
          {
            this._ppDependencies[iParam][jParam] = MethodTypeInferrer.Dependency.Indirect;
            flag = true;
          }
        }
      }
      return flag;
    }

    private void SetUnknownsToNotDependent()
    {
      for (int index1 = 0; index1 < this._pMethodTypeParameters.Count; ++index1)
      {
        for (int index2 = 0; index2 < this._pMethodTypeParameters.Count; ++index2)
        {
          if (this._ppDependencies[index1][index2] == MethodTypeInferrer.Dependency.Unknown)
            this._ppDependencies[index1][index2] = MethodTypeInferrer.Dependency.NotDependent;
        }
      }
    }

    private void SetIndirectsToUnknown()
    {
      for (int index1 = 0; index1 < this._pMethodTypeParameters.Count; ++index1)
      {
        for (int index2 = 0; index2 < this._pMethodTypeParameters.Count; ++index2)
        {
          if (this._ppDependencies[index1][index2] == MethodTypeInferrer.Dependency.Indirect)
            this._ppDependencies[index1][index2] = MethodTypeInferrer.Dependency.Unknown;
        }
      }
    }

    private void UpdateDependenciesAfterFix(int iParam)
    {
      if (this._ppDependencies == null)
        return;
      for (int index = 0; index < this._pMethodTypeParameters.Count; ++index)
      {
        this._ppDependencies[iParam][index] = MethodTypeInferrer.Dependency.NotDependent;
        this._ppDependencies[index][iParam] = MethodTypeInferrer.Dependency.NotDependent;
      }
      this._dependenciesDirty = true;
    }

    private bool DependsOnAny(int iParam)
    {
      for (int jParam = 0; jParam < this._pMethodTypeParameters.Count; ++jParam)
      {
        if (this.DependsOn(iParam, jParam))
          return true;
      }
      return false;
    }

    private bool AnyDependsOn(int iParam)
    {
      for (int iParam1 = 0; iParam1 < this._pMethodTypeParameters.Count; ++iParam1)
      {
        if (this.DependsOn(iParam1, iParam))
          return true;
      }
      return false;
    }

    private void ExactInference(CType pSource, CType pDest)
    {
      if (this.ExactTypeParameterInference(pSource, pDest) || this.ExactArrayInference(pSource, pDest) || this.ExactNullableInference(pSource, pDest))
        return;
      this.ExactConstructedInference(pSource, pDest);
    }

    private bool ExactTypeParameterInference(CType pSource, CType pDest)
    {
      if (!(pDest is TypeParameterType pParam) || !pParam.IsMethodTypeParameter || !this.IsUnfixed(pParam))
        return false;
      this.AddExactBound(pParam, pSource);
      return true;
    }

    private bool ExactArrayInference(CType pSource, CType pDest)
    {
      if (!(pSource is ArrayType arrayType1) || !(pDest is ArrayType arrayType2) || arrayType1.Rank != arrayType2.Rank || arrayType1.IsSZArray != arrayType2.IsSZArray)
        return false;
      this.ExactInference(arrayType1.ElementType, arrayType2.ElementType);
      return true;
    }

    private bool ExactNullableInference(CType pSource, CType pDest)
    {
      if (!(pSource is NullableType nullableType1) || !(pDest is NullableType nullableType2))
        return false;
      this.ExactInference(nullableType1.UnderlyingType, nullableType2.UnderlyingType);
      return true;
    }

    private bool ExactConstructedInference(CType pSource, CType pDest)
    {
      if (!(pSource is AggregateType pSource1) || !(pDest is AggregateType pDest1) || pSource1.OwningAggregate != pDest1.OwningAggregate)
        return false;
      this.ExactTypeArgumentInference(pSource1, pDest1);
      return true;
    }

    private void ExactTypeArgumentInference(AggregateType pSource, AggregateType pDest)
    {
      TypeArray typeArgsAll1 = pSource.TypeArgsAll;
      TypeArray typeArgsAll2 = pDest.TypeArgsAll;
      for (int i = 0; i < typeArgsAll1.Count; ++i)
        this.ExactInference(typeArgsAll1[i], typeArgsAll2[i]);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void LowerBoundInference(CType pSource, CType pDest)
    {
      if (this.LowerBoundTypeParameterInference(pSource, pDest) || this.LowerBoundArrayInference(pSource, pDest) || this.ExactNullableInference(pSource, pDest))
        return;
      this.LowerBoundConstructedInference(pSource, pDest);
    }

    private bool LowerBoundTypeParameterInference(CType pSource, CType pDest)
    {
      if (!(pDest is TypeParameterType pParam) || !pParam.IsMethodTypeParameter || !this.IsUnfixed(pParam))
        return false;
      this.AddLowerBound(pParam, pSource);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool LowerBoundArrayInference(CType pSource, CType pDest)
    {
      if (!(pSource is ArrayType arrayType1))
        return false;
      CType elementType = arrayType1.ElementType;
      CType pDest1;
      if (pDest is ArrayType arrayType2)
      {
        if (arrayType2.Rank != arrayType1.Rank || arrayType2.IsSZArray != arrayType1.IsSZArray)
          return false;
        pDest1 = arrayType2.ElementType;
      }
      else
      {
        if (!pDest.IsPredefType(PredefinedType.PT_G_IENUMERABLE) && !pDest.IsPredefType(PredefinedType.PT_G_ICOLLECTION) && !pDest.IsPredefType(PredefinedType.PT_G_ILIST) && !pDest.IsPredefType(PredefinedType.PT_G_IREADONLYCOLLECTION) && !pDest.IsPredefType(PredefinedType.PT_G_IREADONLYLIST) || !arrayType1.IsSZArray)
          return false;
        pDest1 = ((AggregateType) pDest).TypeArgsThis[0];
      }
      if (elementType.IsReferenceType)
        this.LowerBoundInference(elementType, pDest1);
      else
        this.ExactInference(elementType, pDest1);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool LowerBoundConstructedInference(CType pSource, CType pDest)
    {
      if (!(pDest is AggregateType pDest1) || pDest1.TypeArgsAll.Count == 0)
        return false;
      if (pSource is AggregateType pSource1 && pSource1.OwningAggregate == pDest1.OwningAggregate)
      {
        if (pSource1.IsInterfaceType || pSource1.IsDelegateType)
          this.LowerBoundTypeArgumentInference(pSource1, pDest1);
        else
          this.ExactTypeArgumentInference(pSource1, pDest1);
        return true;
      }
      return this.LowerBoundClassInference(pSource, pDest1) || this.LowerBoundInterfaceInference(pSource, pDest1);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool LowerBoundClassInference(CType pSource, AggregateType pDest)
    {
      if (!pDest.IsClassType)
        return false;
      AggregateType pSource1 = (AggregateType) null;
      if (pSource.IsClassType)
        pSource1 = (pSource as AggregateType).BaseClass;
      for (; pSource1 != null; pSource1 = pSource1.BaseClass)
      {
        if (pSource1.OwningAggregate == pDest.OwningAggregate)
        {
          this.ExactTypeArgumentInference(pSource1, pDest);
          return true;
        }
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool LowerBoundInterfaceInference(CType pSource, AggregateType pDest)
    {
      if (!pDest.IsInterfaceType || !(pSource is AggregateType aggregateType1) || !aggregateType1.IsStructType && !aggregateType1.IsClassType && !aggregateType1.IsInterfaceType)
        return false;
      AggregateType pSource1 = (AggregateType) null;
      foreach (AggregateType aggregateType2 in aggregateType1.IfacesAll.Items)
      {
        if (aggregateType2.OwningAggregate == pDest.OwningAggregate)
        {
          if (pSource1 == null)
            pSource1 = aggregateType2;
          else if (pSource1 != aggregateType2)
            return false;
        }
      }
      if (pSource1 == null)
        return false;
      this.LowerBoundTypeArgumentInference(pSource1, pDest);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void LowerBoundTypeArgumentInference(AggregateType pSource, AggregateType pDest)
    {
      TypeArray typeVarsAll = pSource.OwningAggregate.GetTypeVarsAll();
      TypeArray typeArgsAll1 = pSource.TypeArgsAll;
      TypeArray typeArgsAll2 = pDest.TypeArgsAll;
      for (int i = 0; i < typeArgsAll1.Count; ++i)
      {
        TypeParameterType typeParameterType = (TypeParameterType) typeVarsAll[i];
        CType pSource1 = typeArgsAll1[i];
        CType pDest1 = typeArgsAll2[i];
        if (pSource1.IsReferenceType)
        {
          if (typeParameterType.Covariant)
          {
            this.LowerBoundInference(pSource1, pDest1);
            continue;
          }
          if (typeParameterType.Contravariant)
          {
            this.UpperBoundInference(typeArgsAll1[i], typeArgsAll2[i]);
            continue;
          }
        }
        this.ExactInference(typeArgsAll1[i], typeArgsAll2[i]);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void UpperBoundInference(CType pSource, CType pDest)
    {
      if (this.UpperBoundTypeParameterInference(pSource, pDest) || this.UpperBoundArrayInference(pSource, pDest) || this.ExactNullableInference(pSource, pDest))
        return;
      this.UpperBoundConstructedInference(pSource, pDest);
    }

    private bool UpperBoundTypeParameterInference(CType pSource, CType pDest)
    {
      if (!(pDest is TypeParameterType pParam) || !pParam.IsMethodTypeParameter || !this.IsUnfixed(pParam))
        return false;
      this.AddUpperBound(pParam, pSource);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool UpperBoundArrayInference(CType pSource, CType pDest)
    {
      if (!(pDest is ArrayType arrayType1))
        return false;
      CType elementType = arrayType1.ElementType;
      CType pSource1;
      if (pSource is ArrayType arrayType2)
      {
        if (arrayType1.Rank != arrayType2.Rank || arrayType1.IsSZArray != arrayType2.IsSZArray)
          return false;
        pSource1 = arrayType2.ElementType;
      }
      else
      {
        if (!pSource.IsPredefType(PredefinedType.PT_G_IENUMERABLE) && !pSource.IsPredefType(PredefinedType.PT_G_ICOLLECTION) && !pSource.IsPredefType(PredefinedType.PT_G_ILIST) && !pSource.IsPredefType(PredefinedType.PT_G_IREADONLYLIST) && !pSource.IsPredefType(PredefinedType.PT_G_IREADONLYCOLLECTION) || !arrayType1.IsSZArray)
          return false;
        pSource1 = ((AggregateType) pSource).TypeArgsThis[0];
      }
      if (pSource1.IsReferenceType)
        this.UpperBoundInference(pSource1, elementType);
      else
        this.ExactInference(pSource1, elementType);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool UpperBoundConstructedInference(CType pSource, CType pDest)
    {
      if (!(pSource is AggregateType pSource1) || pSource1.TypeArgsAll.Count == 0)
        return false;
      if (pDest is AggregateType pDest1 && pSource1.OwningAggregate == pDest1.OwningAggregate)
      {
        if (pDest1.IsInterfaceType || pDest1.IsDelegateType)
          this.UpperBoundTypeArgumentInference(pSource1, pDest1);
        else
          this.ExactTypeArgumentInference(pSource1, pDest1);
        return true;
      }
      return this.UpperBoundClassInference(pSource1, pDest) || this.UpperBoundInterfaceInference(pSource1, pDest);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool UpperBoundClassInference(AggregateType pSource, CType pDest)
    {
      if (!pSource.IsClassType || !pDest.IsClassType)
        return false;
      for (AggregateType baseClass = ((AggregateType) pDest).BaseClass; baseClass != null; baseClass = baseClass.BaseClass)
      {
        if (baseClass.OwningAggregate == pSource.OwningAggregate)
        {
          this.ExactTypeArgumentInference(pSource, baseClass);
          return true;
        }
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool UpperBoundInterfaceInference(AggregateType pSource, CType pDest)
    {
      if (!pSource.IsInterfaceType || !(pDest is AggregateType aggregateType1) || !aggregateType1.IsStructType && !aggregateType1.IsClassType && !aggregateType1.IsInterfaceType)
        return false;
      AggregateType pSource1 = (AggregateType) null;
      foreach (AggregateType aggregateType2 in aggregateType1.IfacesAll.Items)
      {
        if (aggregateType2.OwningAggregate == pSource.OwningAggregate)
        {
          if (pSource1 == null)
            pSource1 = aggregateType2;
          else if (pSource1 != aggregateType2)
            return false;
        }
      }
      if (pSource1 == null)
        return false;
      this.UpperBoundTypeArgumentInference(pSource1, pDest as AggregateType);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void UpperBoundTypeArgumentInference(AggregateType pSource, AggregateType pDest)
    {
      TypeArray typeVarsAll = pSource.OwningAggregate.GetTypeVarsAll();
      TypeArray typeArgsAll1 = pSource.TypeArgsAll;
      TypeArray typeArgsAll2 = pDest.TypeArgsAll;
      for (int i = 0; i < typeArgsAll1.Count; ++i)
      {
        TypeParameterType typeParameterType = (TypeParameterType) typeVarsAll[i];
        CType pSource1 = typeArgsAll1[i];
        CType pDest1 = typeArgsAll2[i];
        if (pSource1.IsReferenceType)
        {
          if (typeParameterType.Covariant)
          {
            this.UpperBoundInference(pSource1, pDest1);
            continue;
          }
          if (typeParameterType.Contravariant)
          {
            this.LowerBoundInference(typeArgsAll1[i], typeArgsAll2[i]);
            continue;
          }
        }
        this.ExactInference(typeArgsAll1[i], typeArgsAll2[i]);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool Fix(int iParam)
    {
      if (this._pExactBounds[iParam].Count >= 2)
        return false;
      List<CType> list = new List<CType>();
      if (this._pExactBounds[iParam].IsEmpty<CType>())
      {
        HashSet<CType> ctypeSet = new HashSet<CType>();
        foreach (CType ctype in this._pLowerBounds[iParam])
        {
          if (ctypeSet.Add(ctype))
            list.Add(ctype);
        }
        foreach (CType ctype in this._pUpperBounds[iParam])
        {
          if (ctypeSet.Add(ctype))
            list.Add(ctype);
        }
      }
      else
        list.Add(this._pExactBounds[iParam].Head<CType>());
      if (list.IsEmpty<CType>())
        return false;
      foreach (CType src in this._pLowerBounds[iParam])
      {
        List<CType> ctypeList = new List<CType>();
        foreach (CType dest in list)
        {
          if (src != dest && !this._binder.canConvert(src, dest))
            ctypeList.Add(dest);
        }
        foreach (CType ctype in ctypeList)
          list.Remove(ctype);
      }
      foreach (CType dest in this._pUpperBounds[iParam])
      {
        List<CType> ctypeList = new List<CType>();
        foreach (CType src in list)
        {
          if (dest != src && !this._binder.canConvert(src, dest))
            ctypeList.Add(src);
        }
        foreach (CType ctype in ctypeList)
          list.Remove(ctype);
      }
      CType typeSrc = (CType) null;
      using (List<CType>.Enumerator enumerator = list.GetEnumerator())
      {
label_59:
        while (enumerator.MoveNext())
        {
          CType current = enumerator.Current;
          foreach (CType src in list)
          {
            if (current != src)
            {
              if (!this._binder.canConvert(src, current))
                goto label_59;
            }
          }
          if (typeSrc != null)
            return false;
          typeSrc = current;
        }
      }
      if (typeSrc == null)
        return false;
      this._pFixedResults[iParam] = TypeManager.GetBestAccessibleType(this._binder.Context.ContextForMemberLookup, typeSrc);
      this.UpdateDependenciesAfterFix(iParam);
      return true;
    }

    private enum NewInferenceResult
    {
      InferenceFailed,
      MadeProgress,
      NoProgress,
      Success,
    }

    [Flags]
    private enum Dependency
    {
      Unknown = 0,
      NotDependent = 1,
      DependsMask = 16, // 0x00000010
      Indirect = 18, // 0x00000012
    }
  }
}
