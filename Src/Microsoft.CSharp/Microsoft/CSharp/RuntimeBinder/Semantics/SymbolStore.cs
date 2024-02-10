// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.SymbolStore
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class SymbolStore
  {
    private static readonly Dictionary<SymbolStore.Key, Symbol> s_dictionary = new Dictionary<SymbolStore.Key, Symbol>();

    public static Symbol LookupSym(Name name, ParentSymbol parent, symbmask_t kindmask)
    {
      Symbol sym;
      return !SymbolStore.s_dictionary.TryGetValue(new SymbolStore.Key(name, parent), out sym) ? (Symbol) null : SymbolStore.FindCorrectKind(sym, kindmask);
    }

    public static void InsertChild(ParentSymbol parent, Symbol child)
    {
      child.parent = parent;
      SymbolStore.InsertChildNoGrow(child);
    }

    private static void InsertChildNoGrow(Symbol child)
    {
      switch (child.getKind())
      {
        case SYMKIND.SK_LocalVariableSymbol:
          break;
        case SYMKIND.SK_Scope:
          break;
        default:
          Symbol nextSameName;
          if (SymbolStore.s_dictionary.TryGetValue(new SymbolStore.Key(child.name, child.parent), out nextSameName))
          {
            while (nextSameName?.nextSameName != null)
              nextSameName = nextSameName.nextSameName;
            nextSameName.nextSameName = child;
            break;
          }
          SymbolStore.s_dictionary.Add(new SymbolStore.Key(child.name, child.parent), child);
          break;
      }
    }

    private static Symbol FindCorrectKind(Symbol sym, symbmask_t kindmask)
    {
      while ((kindmask & sym.mask()) == ~symbmask_t.MASK_ALL)
      {
        sym = sym.nextSameName;
        if (sym == null)
          return (Symbol) null;
      }
      return sym;
    }

    private readonly struct Key : IEquatable<SymbolStore.Key>
    {
      private readonly Name _name;
      private readonly ParentSymbol _parent;

      public Key(Name name, ParentSymbol parent)
      {
        this._name = name;
        this._parent = parent;
      }

      public bool Equals(SymbolStore.Key other)
      {
        return this._name == other._name && this._parent == other._parent;
      }

      public override bool Equals(object obj) => obj is SymbolStore.Key other && this.Equals(other);

      public override int GetHashCode() => this._name.GetHashCode() ^ this._parent.GetHashCode();
    }
  }
}
