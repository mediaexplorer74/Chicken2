// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.Symbol
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal abstract class Symbol
  {
    private SYMKIND _kind;
    private ACCESS _access;
    public Name name;
    public ParentSymbol parent;
    public Symbol nextChild;
    public Symbol nextSameName;

    public Symbol LookupNext(symbmask_t kindmask)
    {
      for (Symbol nextSameName = this.nextSameName; nextSameName != null; nextSameName = nextSameName.nextSameName)
      {
        if ((kindmask & nextSameName.mask()) != ~symbmask_t.MASK_ALL)
          return nextSameName;
      }
      return (Symbol) null;
    }

    public ACCESS GetAccess() => this._access;

    public void SetAccess(ACCESS access) => this._access = access;

    public SYMKIND getKind() => this._kind;

    public void setKind(SYMKIND kind) => this._kind = kind;

    public symbmask_t mask() => (symbmask_t) (1 << (int) (this._kind & (SYMKIND) 31));

    public CType getType()
    {
      switch (this)
      {
        case MethodOrPropertySymbol orPropertySymbol:
          return orPropertySymbol.RetType;
        case FieldSymbol fieldSymbol:
          return fieldSymbol.GetType();
        case EventSymbol eventSymbol:
          return eventSymbol.type;
        default:
          return (CType) null;
      }
    }

    public bool isStatic
    {
      get
      {
        switch (this)
        {
          case FieldSymbol fieldSymbol:
            return fieldSymbol.isStatic;
          case EventSymbol eventSymbol:
            return eventSymbol.isStatic;
          case MethodOrPropertySymbol orPropertySymbol:
            return orPropertySymbol.isStatic;
          default:
            return this is AggregateSymbol;
        }
      }
    }

    private Assembly GetAssembly()
    {
      switch (this._kind)
      {
        case SYMKIND.SK_AggregateSymbol:
          return ((AggregateSymbol) this).AssociatedAssembly;
        case SYMKIND.SK_TypeParameterSymbol:
        case SYMKIND.SK_FieldSymbol:
        case SYMKIND.SK_MethodSymbol:
        case SYMKIND.SK_PropertySymbol:
        case SYMKIND.SK_EventSymbol:
          return ((AggregateSymbol) this.parent).AssociatedAssembly;
        default:
          return (Assembly) null;
      }
    }

    private bool InternalsVisibleTo(Assembly assembly)
    {
      switch (this._kind)
      {
        case SYMKIND.SK_AggregateSymbol:
          return ((AggregateSymbol) this).InternalsVisibleTo(assembly);
        case SYMKIND.SK_TypeParameterSymbol:
        case SYMKIND.SK_FieldSymbol:
        case SYMKIND.SK_MethodSymbol:
        case SYMKIND.SK_PropertySymbol:
        case SYMKIND.SK_EventSymbol:
          return ((AggregateSymbol) this.parent).InternalsVisibleTo(assembly);
        default:
          return false;
      }
    }

    public bool SameAssemOrFriend(Symbol sym)
    {
      Assembly assembly = this.GetAssembly();
      return assembly == sym.GetAssembly() || sym.InternalsVisibleTo(assembly);
    }

    public bool IsOverride()
    {
      switch (this._kind)
      {
        case SYMKIND.SK_MethodSymbol:
        case SYMKIND.SK_PropertySymbol:
          return ((MethodOrPropertySymbol) this).isOverride;
        case SYMKIND.SK_EventSymbol:
          return ((EventSymbol) this).isOverride;
        default:
          return false;
      }
    }

    public bool IsHideByName()
    {
      switch (this._kind)
      {
        case SYMKIND.SK_MethodSymbol:
        case SYMKIND.SK_PropertySymbol:
          return ((MethodOrPropertySymbol) this).isHideByName;
        case SYMKIND.SK_EventSymbol:
          MethodSymbol methAdd = ((EventSymbol) this).methAdd;
          return methAdd != null && methAdd.isHideByName;
        default:
          return true;
      }
    }

    public bool isUserCallable()
    {
      return !(this is MethodSymbol methodSymbol) || methodSymbol.isUserCallable();
    }
  }
}
