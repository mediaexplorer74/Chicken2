// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.MemberLookup
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Errors;
using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class MemberLookup
  {
    private CType _typeSrc;
    private CType _typeQual;
    private ParentSymbol _symWhere;
    private Name _name;
    private int _arity;
    private MemLookFlags _flags;
    private readonly List<AggregateType> _rgtypeStart;
    private List<AggregateType> _prgtype;
    private int _csym;
    private readonly SymWithType _swtFirst;
    private readonly List<MethPropWithType> _methPropWithTypeList;
    private readonly SymWithType _swtAmbig;
    private readonly SymWithType _swtInaccess;
    private readonly SymWithType _swtBad;
    private readonly SymWithType _swtBogus;
    private readonly SymWithType _swtBadArity;
    private bool _fMulti;

    private void RecordType(AggregateType type, Symbol sym)
    {
      if (!this._prgtype.Contains(type))
        this._prgtype.Add(type);
      ++this._csym;
      if (!(this._swtFirst == (SymWithType) null))
        return;
      this._swtFirst.Set(sym, type);
      this._fMulti = sym is MethodSymbol || sym is IndexerSymbol;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool SearchSingleType(AggregateType typeCur, out bool pfHideByName)
    {
      bool flag1 = false;
      pfHideByName = false;
      bool flag2 = !CSemanticChecker.CheckTypeAccess((CType) typeCur, (Symbol) this._symWhere);
      if (flag2 && (this._csym != 0 || this._swtInaccess != (SymWithType) null))
        return false;
      for (Symbol symbol = SymbolLoader.LookupAggMember(this._name, typeCur.OwningAggregate, symbmask_t.MASK_Member); symbol != null; symbol = symbol.LookupNext(symbmask_t.MASK_Member))
      {
        if (this._arity > 0 && (!(symbol is MethodSymbol methodSymbol1) || methodSymbol1.typeVars.Count != this._arity))
        {
          if (!(bool) this._swtBadArity)
            this._swtBadArity.Set(symbol, typeCur);
        }
        else if (!symbol.IsOverride() || symbol.IsHideByName())
        {
          MethodOrPropertySymbol mps = symbol as MethodOrPropertySymbol;
          MethodSymbol methodSymbol = symbol as MethodSymbol;
          if (mps != null && (this._flags & MemLookFlags.UserCallable) != MemLookFlags.None && !mps.isUserCallable() && (methodSymbol == null || !methodSymbol.isPropertyAccessor() || (!symbol.name.Text.StartsWith("set_", StringComparison.Ordinal) || methodSymbol.Params.Count <= 1) && (!symbol.name.Text.StartsWith("get_", StringComparison.Ordinal) || methodSymbol.Params.Count <= 0)))
          {
            if (!(bool) this._swtInaccess)
              this._swtInaccess.Set(symbol, typeCur);
          }
          else if (flag2 || !CSemanticChecker.CheckAccess(symbol, typeCur, (Symbol) this._symWhere, this._typeQual))
          {
            if (!(bool) this._swtInaccess)
              this._swtInaccess.Set(symbol, typeCur);
            if (flag2)
              return false;
          }
          else
          {
            PropertySymbol propertySymbol = symbol as PropertySymbol;
            if (((this._flags & MemLookFlags.Ctor) == MemLookFlags.None ? 1 : 0) != (methodSymbol == null ? 1 : (!methodSymbol.IsConstructor() ? 1 : 0)) || ((this._flags & MemLookFlags.Operator) == MemLookFlags.None ? 1 : 0) != (methodSymbol == null ? 1 : (!methodSymbol.isOperator ? 1 : 0)) || (this._flags & MemLookFlags.Indexer) == MemLookFlags.None != !(propertySymbol is IndexerSymbol))
            {
              if (!(bool) this._swtBad)
                this._swtBad.Set(symbol, typeCur);
            }
            else if (!(symbol is MethodSymbol) && (this._flags & MemLookFlags.Indexer) == MemLookFlags.None && CSemanticChecker.CheckBogus(symbol))
            {
              if (!(bool) this._swtBogus)
                this._swtBogus.Set(symbol, typeCur);
            }
            else if ((this._flags & MemLookFlags.MustBeInvocable) != MemLookFlags.None && (symbol is FieldSymbol fieldSymbol && !MemberLookup.IsDelegateType(fieldSymbol.GetType(), typeCur) && !MemberLookup.IsDynamicMember(symbol) || propertySymbol != null && !MemberLookup.IsDelegateType(propertySymbol.RetType, typeCur) && !MemberLookup.IsDynamicMember(symbol)))
            {
              if (!(bool) this._swtBad)
                this._swtBad.Set(symbol, typeCur);
            }
            else
            {
              if (mps != null)
                this._methPropWithTypeList.Add(new MethPropWithType(mps, typeCur));
              flag1 = true;
              if ((bool) this._swtFirst)
              {
                if (!typeCur.IsInterfaceType)
                {
                  if (!this._fMulti)
                  {
                    if (this._swtFirst.Sym is FieldSymbol && symbol is EventSymbol && this._swtFirst.Field().isEvent || this._swtFirst.Sym is FieldSymbol && symbol is EventSymbol)
                      continue;
                  }
                  else if (this._swtFirst.Sym.getKind() != symbol.getKind())
                  {
                    if (typeCur != this._prgtype[0])
                    {
                      pfHideByName = true;
                      continue;
                    }
                  }
                  else
                    goto label_39;
                }
                else if (!this._fMulti)
                {
                  if (symbol is MethodSymbol)
                  {
                    this._prgtype = new List<AggregateType>();
                    this._csym = 0;
                    this._swtFirst.Clear();
                    this._swtAmbig.Clear();
                    goto label_39;
                  }
                }
                else if (this._swtFirst.Sym.getKind() != symbol.getKind())
                {
                  if (typeCur.DiffHidden || this._swtFirst.Sym is MethodSymbol)
                  {
                    pfHideByName = true;
                    continue;
                  }
                }
                else
                  goto label_39;
                if (!(bool) this._swtAmbig)
                  this._swtAmbig.Set(symbol, typeCur);
                pfHideByName = true;
                return true;
              }
label_39:
              this.RecordType(typeCur, symbol);
              if (mps != null && mps.isHideByName)
                pfHideByName = true;
            }
          }
        }
      }
      return flag1;
    }

    private static bool IsDynamicMember(Symbol sym)
    {
      DynamicAttribute dynamicAttribute = (DynamicAttribute) null;
      if (sym is FieldSymbol fieldSymbol)
      {
        if (!fieldSymbol.getType().IsPredefType(PredefinedType.PT_OBJECT))
          return false;
        object[] customAttributes = fieldSymbol.AssociatedFieldInfo.GetCustomAttributes(typeof (DynamicAttribute), false);
        if (customAttributes.Length == 1)
          dynamicAttribute = customAttributes[0] as DynamicAttribute;
      }
      else
      {
        PropertySymbol propertySymbol = (PropertySymbol) sym;
        if (!propertySymbol.getType().IsPredefType(PredefinedType.PT_OBJECT))
          return false;
        object[] customAttributes = propertySymbol.AssociatedPropertyInfo.GetCustomAttributes(typeof (DynamicAttribute), false);
        if (customAttributes.Length == 1)
          dynamicAttribute = customAttributes[0] as DynamicAttribute;
      }
      if (dynamicAttribute == null)
        return false;
      if (dynamicAttribute.TransformFlags.Count == 0)
        return true;
      return dynamicAttribute.TransformFlags.Count == 1 && dynamicAttribute.TransformFlags[0];
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool LookupInClass(AggregateType typeStart, ref AggregateType ptypeEnd)
    {
      AggregateType aggregateType = ptypeEnd;
      for (AggregateType typeCur = typeStart; typeCur != aggregateType && typeCur != null; typeCur = typeCur.BaseClass)
      {
        bool pfHideByName;
        this.SearchSingleType(typeCur, out pfHideByName);
        if ((bool) this._swtFirst && !this._fMulti)
          return false;
        if (pfHideByName)
        {
          ptypeEnd = (AggregateType) null;
          return true;
        }
        if ((this._flags & MemLookFlags.Ctor) != MemLookFlags.None)
          return false;
      }
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool LookupInInterfaces(AggregateType typeStart, TypeArray types)
    {
      if (typeStart != null)
      {
        typeStart.AllHidden = false;
        typeStart.DiffHidden = this._swtFirst != (SymWithType) null;
      }
      for (int i = 0; i < types.Count; ++i)
      {
        AggregateType type = (AggregateType) types[i];
        type.AllHidden = false;
        type.DiffHidden = (bool) this._swtFirst;
      }
      bool flag = false;
      AggregateType typeCur = typeStart;
      int num = 0;
      if (typeCur == null)
        typeCur = (AggregateType) types[num++];
      while (true)
      {
        bool pfHideByName;
        if (!typeCur.AllHidden && this.SearchSingleType(typeCur, out pfHideByName))
        {
          pfHideByName |= !this._fMulti;
          foreach (AggregateType aggregateType in typeCur.IfacesAll.Items)
          {
            if (pfHideByName)
              aggregateType.AllHidden = true;
            aggregateType.DiffHidden = true;
          }
          if (pfHideByName)
            flag = true;
        }
        if (num < types.Count)
          typeCur = types[num++] as AggregateType;
        else
          break;
      }
      return !flag;
    }

    private static RuntimeBinderException ReportBogus(SymWithType swt)
    {
      MethodSymbol getterMethod = swt.Prop().GetterMethod;
      MethodSymbol setterMethod = swt.Prop().SetterMethod;
      return !(getterMethod == null | setterMethod == null) ? ErrorHandling.Error(ErrorCode.ERR_BindToBogusProp2, (ErrArg) swt.Sym.name, (ErrArg) new SymWithType((Symbol) getterMethod, swt.GetType()), (ErrArg) new SymWithType((Symbol) setterMethod, swt.GetType()), (ErrArg) new ErrArgRefOnly(swt.Sym)) : ErrorHandling.Error(ErrorCode.ERR_BindToBogusProp1, (ErrArg) swt.Sym.name, (ErrArg) new SymWithType((Symbol) (getterMethod ?? setterMethod), swt.GetType()), (ErrArg) new ErrArgRefOnly(swt.Sym));
    }

    private static bool IsDelegateType(CType pSrcType, AggregateType pAggType)
    {
      return TypeManager.SubstType(pSrcType, pAggType, pAggType.TypeArgsAll).IsDelegateType;
    }

    public MemberLookup()
    {
      this._methPropWithTypeList = new List<MethPropWithType>();
      this._rgtypeStart = new List<AggregateType>();
      this._swtFirst = new SymWithType();
      this._swtAmbig = new SymWithType();
      this._swtInaccess = new SymWithType();
      this._swtBad = new SymWithType();
      this._swtBogus = new SymWithType();
      this._swtBadArity = new SymWithType();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public bool Lookup(
      CType typeSrc,
      Expr obj,
      ParentSymbol symWhere,
      Name name,
      int arity,
      MemLookFlags flags)
    {
      this._prgtype = this._rgtypeStart;
      this._typeSrc = typeSrc;
      this._symWhere = symWhere;
      this._name = name;
      this._arity = arity;
      this._flags = flags;
      this._typeQual = (this._flags & MemLookFlags.Ctor) != MemLookFlags.None ? this._typeSrc : obj?.Type;
      AggregateType typeStart1;
      AggregateType typeStart2;
      TypeArray types;
      if (typeSrc.IsInterfaceType)
      {
        typeStart1 = (AggregateType) null;
        typeStart2 = (AggregateType) typeSrc;
        types = typeStart2.IfacesAll;
      }
      else
      {
        typeStart1 = (AggregateType) typeSrc;
        typeStart2 = (AggregateType) null;
        types = TypeArray.Empty;
      }
      AggregateType predefindType = typeStart2 != null || types.Count > 0 ? SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT) : (AggregateType) null;
      if ((typeStart1 == null || this.LookupInClass(typeStart1, ref predefindType)) && (typeStart2 != null || types.Count > 0) && this.LookupInInterfaces(typeStart2, types) && predefindType != null)
      {
        AggregateType ptypeEnd = (AggregateType) null;
        this.LookupInClass(predefindType, ref ptypeEnd);
      }
      return !this.FError();
    }

    private bool FError() => !(bool) this._swtFirst || (bool) this._swtAmbig;

    public SymWithType SwtFirst() => this._swtFirst;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Exception ReportErrors()
    {
      if ((bool) this._swtFirst)
        return (Exception) ErrorHandling.Error(ErrorCode.ERR_AmbigMember, (ErrArg) this._swtFirst, (ErrArg) this._swtAmbig);
      if ((bool) this._swtInaccess)
      {
        if (this._swtInaccess.Sym.isUserCallable() || (this._flags & MemLookFlags.UserCallable) == MemLookFlags.None)
          return (Exception) CSemanticChecker.ReportAccessError(this._swtInaccess, (Symbol) this._symWhere, this._typeQual);
        return (Exception) ErrorHandling.Error(ErrorCode.ERR_CantCallSpecialMethod, (ErrArg) this._swtInaccess);
      }
      if ((this._flags & MemLookFlags.Ctor) != MemLookFlags.None)
        return this._arity <= 0 ? (Exception) ErrorHandling.Error(ErrorCode.ERR_NoConstructors, (ErrArg) (Symbol) ((AggregateType) this._typeSrc).OwningAggregate) : (Exception) ErrorHandling.Error(ErrorCode.ERR_BadCtorArgCount, (ErrArg) (Symbol) ((AggregateType) this._typeSrc).OwningAggregate, (ErrArg) this._arity);
      if ((this._flags & MemLookFlags.Operator) != MemLookFlags.None)
        return (Exception) ErrorHandling.Error(ErrorCode.ERR_NoSuchMember, (ErrArg) this._typeSrc, (ErrArg) this._name);
      if ((this._flags & MemLookFlags.Indexer) != MemLookFlags.None)
        return (Exception) ErrorHandling.Error(ErrorCode.ERR_BadIndexLHS, (ErrArg) this._typeSrc);
      if ((bool) this._swtBad)
        return (Exception) ErrorHandling.Error((ErrorCode) ((this._flags & MemLookFlags.MustBeInvocable) != MemLookFlags.None ? 1955 : 571), (ErrArg) this._swtBad);
      if ((bool) this._swtBogus)
        return (Exception) MemberLookup.ReportBogus(this._swtBogus);
      if ((bool) this._swtBadArity)
      {
        if (this._swtBadArity.Sym is MethodSymbol sym)
        {
          int count = sym.typeVars.Count;
          return (Exception) ErrorHandling.Error((ErrorCode) (count > 0 ? 305 : 308), (ErrArg) this._swtBadArity, (ErrArg) new ErrArgSymKind(this._swtBadArity.Sym), (ErrArg) count);
        }
        return (Exception) ErrorHandling.Error(ErrorCode.ERR_TypeArgsNotAllowed, (ErrArg) this._swtBadArity, (ErrArg) new ErrArgSymKind(this._swtBadArity.Sym));
      }
      return (Exception) ErrorHandling.Error(ErrorCode.ERR_NoSuchMember, (ErrArg) this._typeSrc, (ErrArg) this._name);
    }
  }
}
