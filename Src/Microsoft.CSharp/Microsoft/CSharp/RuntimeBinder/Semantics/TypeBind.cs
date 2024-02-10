// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.TypeBind
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Errors;
using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class TypeBind
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool CheckConstraints(CType type, CheckConstraintsFlags flags)
    {
      type = type.GetNakedType(false);
      switch (type)
      {
        case AggregateType ats:
label_3:
          if (ats.TypeArgsAll.Count == 0)
          {
            ats.ConstraintError = new bool?(false);
            return true;
          }
          if (ats.ConstraintError.HasValue)
          {
            if (!ats.ConstraintError.GetValueOrDefault())
              return true;
            if ((flags & CheckConstraintsFlags.NoErrors) != CheckConstraintsFlags.None)
              return false;
          }
          TypeArray typeVars = ats.OwningAggregate.GetTypeVars();
          TypeArray typeArgsThis = ats.TypeArgsThis;
          TypeArray typeArgsAll = ats.TypeArgsAll;
          if (ats.OuterType != null && ((flags & CheckConstraintsFlags.Outer) != CheckConstraintsFlags.None || !ats.OuterType.ConstraintError.HasValue) && !TypeBind.CheckConstraints((CType) ats.OuterType, flags))
          {
            ats.ConstraintError = new bool?(true);
            return false;
          }
          if (typeVars.Count > 0 && !TypeBind.CheckConstraintsCore((Symbol) ats.OwningAggregate, typeVars, typeArgsThis, typeArgsAll, (TypeArray) null, flags & CheckConstraintsFlags.NoErrors))
          {
            ats.ConstraintError = new bool?(true);
            return false;
          }
          for (int i = 0; i < typeArgsThis.Count; ++i)
          {
            if (typeArgsThis[i].GetNakedType(true) is AggregateType nakedType && !nakedType.ConstraintError.HasValue)
            {
              TypeBind.CheckConstraints((CType) nakedType, flags | CheckConstraintsFlags.Outer);
              if (nakedType.ConstraintError.GetValueOrDefault())
              {
                ats.ConstraintError = new bool?(true);
                return false;
              }
            }
          }
          ats.ConstraintError = new bool?(false);
          return true;
        case NullableType nullableType:
          ats = nullableType.GetAts();
          goto label_3;
        default:
          return true;
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static void CheckMethConstraints(MethWithInst mwi)
    {
      if (mwi.TypeArgs.Count <= 0)
        return;
      TypeBind.CheckConstraintsCore((Symbol) mwi.Meth(), mwi.Meth().typeVars, mwi.TypeArgs, mwi.GetType().TypeArgsAll, mwi.TypeArgs, CheckConstraintsFlags.None);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool CheckConstraintsCore(
      Symbol symErr,
      TypeArray typeVars,
      TypeArray typeArgs,
      TypeArray typeArgsCls,
      TypeArray typeArgsMeth,
      CheckConstraintsFlags flags)
    {
      for (int i = 0; i < typeVars.Count; ++i)
      {
        TypeParameterType typeVar = (TypeParameterType) typeVars[i];
        CType typeArg = typeArgs[i];
        if (!TypeBind.CheckSingleConstraint(symErr, typeVar, typeArg, typeArgsCls, typeArgsMeth, flags))
          return false;
      }
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool CheckSingleConstraint(
      Symbol symErr,
      TypeParameterType var,
      CType arg,
      TypeArray typeArgsCls,
      TypeArray typeArgsMeth,
      CheckConstraintsFlags flags)
    {
      bool flag = (flags & CheckConstraintsFlags.NoErrors) == CheckConstraintsFlags.None;
      if (var.HasRefConstraint && !arg.IsReferenceType)
      {
        if (flag)
          throw ErrorHandling.Error(ErrorCode.ERR_RefConstraintNotSatisfied, (ErrArg) symErr, (ErrArg) new ErrArgNoRef((CType) var), (ErrArg) arg);
        return false;
      }
      TypeArray typeArray = TypeManager.SubstTypeArray(var.Bounds, typeArgsCls, typeArgsMeth);
      int num = 0;
      if (var.HasValConstraint)
      {
        if (!arg.IsNonNullableValueType)
        {
          if (flag)
            throw ErrorHandling.Error(ErrorCode.ERR_ValConstraintNotSatisfied, (ErrArg) symErr, (ErrArg) new ErrArgNoRef((CType) var), (ErrArg) arg);
          return false;
        }
        if (typeArray.Count != 0 && typeArray[0].IsPredefType(PredefinedType.PT_VALUE))
          num = 1;
      }
      for (int i = num; i < typeArray.Count; ++i)
      {
        CType ctype = typeArray[i];
        if (!TypeBind.SatisfiesBound(arg, ctype))
        {
          if (flag)
            throw ErrorHandling.Error((ErrorCode) (!arg.IsReferenceType ? (!(arg is NullableType nullableType) || !SymbolLoader.HasBaseConversion(nullableType.UnderlyingType, ctype) ? 315 : (ctype.IsPredefType(PredefinedType.PT_ENUM) || nullableType.UnderlyingType == ctype ? 312 : 313)) : 311), new ErrArg(symErr), new ErrArg(ctype, ErrArgFlags.Unique), (ErrArg) (CType) var, new ErrArg(arg, ErrArgFlags.Unique));
          return false;
        }
      }
      if (!var.HasNewConstraint || arg.IsValueType)
        return true;
      if (arg.IsClassType)
      {
        AggregateSymbol owningAggregate = ((AggregateType) arg).OwningAggregate;
        SymbolLoader.LookupAggMember(NameManager.GetPredefinedName(PredefinedName.PN_CTOR), owningAggregate, symbmask_t.MASK_ALL);
        if (owningAggregate.HasPubNoArgCtor() && !owningAggregate.IsAbstract())
          return true;
      }
      if (flag)
        throw ErrorHandling.Error(ErrorCode.ERR_NewConstraintNotSatisfied, (ErrArg) symErr, (ErrArg) new ErrArgNoRef((CType) var), (ErrArg) arg);
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool SatisfiesBound(CType arg, CType typeBnd)
    {
      if (typeBnd == arg)
        return true;
      switch (typeBnd.TypeKind)
      {
        case TypeKind.TK_AggregateType:
        case TypeKind.TK_ArrayType:
        case TypeKind.TK_TypeParameterType:
          switch (arg.TypeKind)
          {
            case TypeKind.TK_AggregateType:
            case TypeKind.TK_ArrayType:
            case TypeKind.TK_TypeParameterType:
              return SymbolLoader.HasBaseConversion(arg, typeBnd);
            case TypeKind.TK_PointerType:
              return false;
            case TypeKind.TK_NullableType:
              arg = (CType) arg.GetAts();
              goto case TypeKind.TK_AggregateType;
            default:
              return false;
          }
        case TypeKind.TK_VoidType:
        case TypeKind.TK_PointerType:
          return false;
        case TypeKind.TK_NullableType:
          typeBnd = (CType) typeBnd.GetAts();
          goto case TypeKind.TK_AggregateType;
        default:
          return false;
      }
    }
  }
}
