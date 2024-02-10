// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.CMemberLookupResults
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class CMemberLookupResults
  {
    private readonly Name _pName;

    private TypeArray ContainingTypes { get; }

    public CMemberLookupResults(TypeArray containingTypes, Name name)
    {
      this._pName = name;
      this.ContainingTypes = containingTypes;
    }

    public CMemberLookupResults.CMethodIterator GetMethodIterator(
      CType qualifyingType,
      AggregateSymbol context,
      int arity,
      EXPRFLAG flags,
      symbmask_t mask,
      ArgInfos nonTrailingNamedArguments)
    {
      return new CMemberLookupResults.CMethodIterator(this._pName, this.ContainingTypes, qualifyingType, context, arity, flags, mask, nonTrailingNamedArguments);
    }

    public class CMethodIterator
    {
      private readonly AggregateSymbol _context;
      private readonly TypeArray _containingTypes;
      private readonly CType _qualifyingType;
      private readonly Name _name;
      private readonly int _arity;
      private readonly symbmask_t _mask;
      private readonly EXPRFLAG _flags;
      private readonly ArgInfos _nonTrailingNamedArguments;
      private int _currentTypeIndex;

      public CMethodIterator(
        Name name,
        TypeArray containingTypes,
        CType qualifyingType,
        AggregateSymbol context,
        int arity,
        EXPRFLAG flags,
        symbmask_t mask,
        ArgInfos nonTrailingNamedArguments)
      {
        this._name = name;
        this._containingTypes = containingTypes;
        this._qualifyingType = qualifyingType;
        this._context = context;
        this._arity = arity;
        this._flags = flags;
        this._mask = mask;
        this._nonTrailingNamedArguments = nonTrailingNamedArguments;
      }

      public MethodOrPropertySymbol CurrentSymbol { get; private set; }

      public AggregateType CurrentType { get; private set; }

      public bool IsCurrentSymbolInaccessible { get; private set; }

      public bool IsCurrentSymbolBogus { get; private set; }

      public bool IsCurrentSymbolMisnamed { get; private set; }

      public bool MoveNext()
      {
        return (this.CurrentType != null || this.FindNextTypeForInstanceMethods()) && this.FindNextMethod();
      }

      public bool AtEnd => this.CurrentSymbol == null;

      public bool CanUseCurrentSymbol
      {
        [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
        {
          if (this._mask == symbmask_t.MASK_MethodSymbol && ((this._flags & EXPRFLAG.EXF_CTOR) == (EXPRFLAG) 0 != !((MethodSymbol) this.CurrentSymbol).IsConstructor() || (this._flags & EXPRFLAG.EXF_OPERATOR) == (EXPRFLAG) 0 != !this.CurrentSymbol.isOperator) || this._mask == symbmask_t.MASK_PropertySymbol && !(this.CurrentSymbol is IndexerSymbol) || this._arity > 0 & this._mask == symbmask_t.MASK_MethodSymbol && ((MethodSymbol) this.CurrentSymbol).typeVars.Count != this._arity || !ExpressionBinder.IsMethPropCallable(this.CurrentSymbol, (this._flags & EXPRFLAG.EXF_USERCALLABLE) != 0))
            return false;
          this.IsCurrentSymbolInaccessible = !CSemanticChecker.CheckAccess((Symbol) this.CurrentSymbol, this.CurrentType, (Symbol) this._context, this._qualifyingType);
          this.IsCurrentSymbolBogus = CSemanticChecker.CheckBogus((Symbol) this.CurrentSymbol);
          this.IsCurrentSymbolMisnamed = this.CheckArgumentNames();
          return true;
        }
      }

      private bool CheckArgumentNames()
      {
        ArgInfos trailingNamedArguments = this._nonTrailingNamedArguments;
        if (trailingNamedArguments != null)
        {
          List<Name> parameterNames = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(this.CurrentSymbol, this._qualifyingType).ParameterNames;
          List<Expr> prgexpr = trailingNamedArguments.prgexpr;
          for (int index = 0; index < trailingNamedArguments.carg; ++index)
          {
            if (prgexpr[index] is ExprNamedArgumentSpecification argumentSpecification && (parameterNames[index] != argumentSpecification.Name || index == parameterNames.Count - 1 && index != trailingNamedArguments.carg - 1))
              return true;
          }
        }
        return false;
      }

      private bool FindNextMethod()
      {
        do
        {
          this.CurrentSymbol = (this.CurrentSymbol == null ? SymbolLoader.LookupAggMember(this._name, this.CurrentType.OwningAggregate, this._mask) : this.CurrentSymbol.LookupNext(this._mask)) as MethodOrPropertySymbol;
          if (this.CurrentSymbol != null)
            goto label_3;
        }
        while (this.FindNextTypeForInstanceMethods());
        return false;
label_3:
        return true;
      }

      private bool FindNextTypeForInstanceMethods()
      {
        if (this._currentTypeIndex >= this._containingTypes.Count)
        {
          this.CurrentType = (AggregateType) null;
          return false;
        }
        this.CurrentType = this._containingTypes[this._currentTypeIndex++] as AggregateType;
        return true;
      }
    }
  }
}
