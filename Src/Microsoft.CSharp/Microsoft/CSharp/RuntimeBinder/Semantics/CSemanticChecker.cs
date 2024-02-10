// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.CSemanticChecker
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Errors;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class CSemanticChecker
  {
    public static void CheckForStaticClass(CType type)
    {
      if (type.IsStaticClass)
        throw ErrorHandling.Error(ErrorCode.ERR_ConvertToStaticClass, (ErrArg) type);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ACCESSERROR CheckAccess2(
      Symbol symCheck,
      AggregateType atsCheck,
      Symbol symWhere,
      CType typeThru)
    {
      ACCESSERROR accesserror = CSemanticChecker.CheckAccessCore(symCheck, atsCheck, symWhere, typeThru);
      if (ACCESSERROR.ACCESSERROR_NOERROR != accesserror)
        return accesserror;
      CType ctype = symCheck.getType();
      if (ctype == null)
        return ACCESSERROR.ACCESSERROR_NOERROR;
      if (atsCheck.TypeArgsAll.Count > 0)
        ctype = TypeManager.SubstType(ctype, atsCheck);
      return !CSemanticChecker.CheckTypeAccess(ctype, symWhere) ? ACCESSERROR.ACCESSERROR_NOACCESS : ACCESSERROR.ACCESSERROR_NOERROR;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool CheckTypeAccess(CType type, Symbol symWhere)
    {
      type = type.GetNakedType(true);
      if (!(type is AggregateType aggregateType))
        return true;
      while (ACCESSERROR.ACCESSERROR_NOERROR == CSemanticChecker.CheckAccessCore((Symbol) aggregateType.OwningAggregate, aggregateType.OuterType, symWhere, (CType) null))
      {
        aggregateType = aggregateType.OuterType;
        if (aggregateType == null)
        {
          TypeArray typeArgsAll = ((AggregateType) type).TypeArgsAll;
          for (int i = 0; i < typeArgsAll.Count; ++i)
          {
            if (!CSemanticChecker.CheckTypeAccess(typeArgsAll[i], symWhere))
              return false;
          }
          return true;
        }
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ACCESSERROR CheckAccessCore(
      Symbol symCheck,
      AggregateType atsCheck,
      Symbol symWhere,
      CType typeThru)
    {
      switch (symCheck.GetAccess())
      {
        case ACCESS.ACC_UNKNOWN:
          return ACCESSERROR.ACCESSERROR_NOACCESS;
        case ACCESS.ACC_PRIVATE:
        case ACCESS.ACC_PROTECTED:
          if (symWhere == null)
            return ACCESSERROR.ACCESSERROR_NOACCESS;
          break;
        case ACCESS.ACC_INTERNAL_AND_PROTECTED:
          if (symWhere == null || !symWhere.SameAssemOrFriend(symCheck))
            return ACCESSERROR.ACCESSERROR_NOACCESS;
          break;
        case ACCESS.ACC_INTERNAL:
        case ACCESS.ACC_INTERNALPROTECTED:
          if (symWhere == null)
            return ACCESSERROR.ACCESSERROR_NOACCESS;
          if (symWhere.SameAssemOrFriend(symCheck))
            return ACCESSERROR.ACCESSERROR_NOERROR;
          if (symCheck.GetAccess() == ACCESS.ACC_INTERNAL)
            return ACCESSERROR.ACCESSERROR_NOACCESS;
          break;
        case ACCESS.ACC_PUBLIC:
          return ACCESSERROR.ACCESSERROR_NOERROR;
        default:
          throw Error.InternalCompilerError();
      }
      AggregateSymbol aggregateSymbol1 = (AggregateSymbol) null;
      for (Symbol symbol = symWhere; symbol != null; symbol = (Symbol) symbol.parent)
      {
        if (symbol is AggregateSymbol aggregateSymbol2)
        {
          aggregateSymbol1 = aggregateSymbol2;
          break;
        }
      }
      if (aggregateSymbol1 == null)
        return ACCESSERROR.ACCESSERROR_NOACCESS;
      AggregateSymbol parent = symCheck.parent as AggregateSymbol;
      for (AggregateSymbol aggregateSymbol3 = aggregateSymbol1; aggregateSymbol3 != null; aggregateSymbol3 = aggregateSymbol3.GetOuterAgg())
      {
        if (aggregateSymbol3 == parent)
          return ACCESSERROR.ACCESSERROR_NOERROR;
      }
      if (symCheck.GetAccess() == ACCESS.ACC_PRIVATE)
        return ACCESSERROR.ACCESSERROR_NOACCESS;
      AggregateType aggregateType = (AggregateType) null;
      if (typeThru != null && !symCheck.isStatic)
        aggregateType = typeThru.GetAts();
      bool flag = false;
      for (AggregateSymbol agg = aggregateSymbol1; agg != null; agg = agg.GetOuterAgg())
      {
        if (agg.FindBaseAgg(parent))
        {
          flag = true;
          if (aggregateType == null || aggregateType.OwningAggregate.FindBaseAgg(agg))
            return ACCESSERROR.ACCESSERROR_NOERROR;
        }
      }
      return !flag ? ACCESSERROR.ACCESSERROR_NOACCESS : ACCESSERROR.ACCESSERROR_NOACCESSTHRU;
    }

    public static bool CheckBogus(Symbol sym)
    {
      return sym is PropertySymbol propertySymbol && propertySymbol.Bogus;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static RuntimeBinderException ReportAccessError(
      SymWithType swtBad,
      Symbol symWhere,
      CType typeQual)
    {
      return CSemanticChecker.CheckAccess2(swtBad.Sym, swtBad.GetType(), symWhere, typeQual) != ACCESSERROR.ACCESSERROR_NOACCESSTHRU ? ErrorHandling.Error(ErrorCode.ERR_BadAccess, (ErrArg) swtBad) : ErrorHandling.Error(ErrorCode.ERR_BadProtectedAccess, (ErrArg) swtBad, (ErrArg) typeQual, (ErrArg) symWhere);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool CheckAccess(
      Symbol symCheck,
      AggregateType atsCheck,
      Symbol symWhere,
      CType typeThru)
    {
      return CSemanticChecker.CheckAccess2(symCheck, atsCheck, symWhere, typeThru) == ACCESSERROR.ACCESSERROR_NOERROR;
    }
  }
}
