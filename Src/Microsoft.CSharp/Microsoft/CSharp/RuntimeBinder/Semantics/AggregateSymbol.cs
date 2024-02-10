// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.AggregateSymbol
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
  internal sealed class AggregateSymbol : NamespaceOrAggregateSymbol
  {
    public Type AssociatedSystemType;
    public Assembly AssociatedAssembly;
    private AggregateType _atsInst;
    private AggregateType _pBaseClass;
    private AggregateType _pUnderlyingType;
    private TypeArray _ifaces;
    private TypeArray _ifacesAll;
    private TypeArray _typeVarsThis;
    private TypeArray _typeVarsAll;
    private MethodSymbol _pConvFirst;
    private AggKindEnum _aggKind;
    private bool _isPredefined;
    private PredefinedType _iPredef;
    private bool _isAbstract;
    private bool _isSealed;
    private bool _hasPubNoArgCtor;
    private bool _isSkipUDOps;
    private bool? _hasConversion;

    public AggregateSymbol GetBaseAgg() => this._pBaseClass?.OwningAggregate;

    public AggregateType getThisType()
    {
      if (this._atsInst == null)
        this._atsInst = TypeManager.GetAggregate(this, this.isNested() ? this.GetOuterAgg().getThisType() : (AggregateType) null, this.GetTypeVars());
      return this._atsInst;
    }

    public bool FindBaseAgg(AggregateSymbol agg)
    {
      for (AggregateSymbol aggregateSymbol = this; aggregateSymbol != null; aggregateSymbol = aggregateSymbol.GetBaseAgg())
      {
        if (aggregateSymbol == agg)
          return true;
      }
      return false;
    }

    public bool isNested() => this.parent is AggregateSymbol;

    public AggregateSymbol GetOuterAgg() => this.parent as AggregateSymbol;

    public bool isPredefAgg(PredefinedType pt) => this._isPredefined && this._iPredef == pt;

    public AggKindEnum AggKind() => this._aggKind;

    public void SetAggKind(AggKindEnum aggKind)
    {
      this._aggKind = aggKind;
      if (aggKind != AggKindEnum.Interface)
        return;
      this.SetAbstract(true);
    }

    public bool IsClass() => this.AggKind() == AggKindEnum.Class;

    public bool IsDelegate() => this.AggKind() == AggKindEnum.Delegate;

    public bool IsInterface() => this.AggKind() == AggKindEnum.Interface;

    public bool IsStruct() => this.AggKind() == AggKindEnum.Struct;

    public bool IsEnum() => this.AggKind() == AggKindEnum.Enum;

    public bool IsValueType()
    {
      return this.AggKind() == AggKindEnum.Struct || this.AggKind() == AggKindEnum.Enum;
    }

    public bool IsRefType()
    {
      return this.AggKind() == AggKindEnum.Class || this.AggKind() == AggKindEnum.Interface || this.AggKind() == AggKindEnum.Delegate;
    }

    public bool IsStatic() => this._isAbstract && this._isSealed;

    public bool IsAbstract() => this._isAbstract;

    public void SetAbstract(bool @abstract) => this._isAbstract = @abstract;

    public bool IsPredefined() => this._isPredefined;

    public void SetPredefined(bool predefined) => this._isPredefined = predefined;

    public PredefinedType GetPredefType() => this._iPredef;

    public void SetPredefType(PredefinedType predef) => this._iPredef = predef;

    public bool IsSealed() => this._isSealed;

    public void SetSealed(bool @sealed) => this._isSealed = @sealed;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public bool HasConversion()
    {
      SymbolTable.AddConversionsForType(this.AssociatedSystemType);
      if (!this._hasConversion.HasValue)
        this._hasConversion = new bool?(this.GetBaseAgg() != null && this.GetBaseAgg().HasConversion());
      return this._hasConversion.Value;
    }

    public void SetHasConversion() => this._hasConversion = new bool?(true);

    public bool HasPubNoArgCtor() => this._hasPubNoArgCtor;

    public void SetHasPubNoArgCtor(bool hasPubNoArgCtor) => this._hasPubNoArgCtor = hasPubNoArgCtor;

    public bool IsSkipUDOps() => this._isSkipUDOps;

    public void SetSkipUDOps(bool skipUDOps) => this._isSkipUDOps = skipUDOps;

    public TypeArray GetTypeVars() => this._typeVarsThis;

    public void SetTypeVars(TypeArray typeVars)
    {
      if (typeVars == null)
      {
        this._typeVarsThis = (TypeArray) null;
        this._typeVarsAll = (TypeArray) null;
      }
      else
      {
        TypeArray pta1 = this.GetOuterAgg() == null ? TypeArray.Empty : this.GetOuterAgg().GetTypeVarsAll();
        this._typeVarsThis = typeVars;
        this._typeVarsAll = TypeArray.Concat(pta1, typeVars);
      }
    }

    public TypeArray GetTypeVarsAll() => this._typeVarsAll;

    public AggregateType GetBaseClass() => this._pBaseClass;

    public void SetBaseClass(AggregateType baseClass) => this._pBaseClass = baseClass;

    public AggregateType GetUnderlyingType() => this._pUnderlyingType;

    public void SetUnderlyingType(AggregateType underlyingType)
    {
      this._pUnderlyingType = underlyingType;
    }

    public TypeArray GetIfaces() => this._ifaces;

    public void SetIfaces(TypeArray ifaces) => this._ifaces = ifaces;

    public TypeArray GetIfacesAll() => this._ifacesAll;

    public void SetIfacesAll(TypeArray ifacesAll) => this._ifacesAll = ifacesAll;

    public MethodSymbol GetFirstUDConversion() => this._pConvFirst;

    public void SetFirstUDConversion(MethodSymbol conv) => this._pConvFirst = conv;

    public bool InternalsVisibleTo(Assembly assembly)
    {
      return TypeManager.InternalsVisibleTo(this.AssociatedAssembly, assembly);
    }
  }
}
