// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.SymFactory
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class SymFactory
  {
    private static Symbol NewBasicSymbol(SYMKIND kind, Name name, ParentSymbol parent)
    {
      Symbol symbol;
      switch (kind)
      {
        case SYMKIND.SK_NamespaceSymbol:
          symbol = (Symbol) new NamespaceSymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_AggregateSymbol:
          symbol = (Symbol) new AggregateSymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_TypeParameterSymbol:
          symbol = (Symbol) new TypeParameterSymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_FieldSymbol:
          symbol = (Symbol) new FieldSymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_LocalVariableSymbol:
          symbol = (Symbol) new LocalVariableSymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_MethodSymbol:
          symbol = (Symbol) new MethodSymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_PropertySymbol:
          symbol = (Symbol) new PropertySymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_EventSymbol:
          symbol = (Symbol) new EventSymbol();
          symbol.name = name;
          break;
        case SYMKIND.SK_Scope:
          symbol = (Symbol) new Scope();
          symbol.name = name;
          break;
        case SYMKIND.SK_IndexerSymbol:
          symbol = (Symbol) new IndexerSymbol();
          symbol.name = name;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      symbol.setKind(kind);
      if (parent != null)
      {
        parent.AddToChildList(symbol);
        SymbolStore.InsertChild(parent, symbol);
      }
      return symbol;
    }

    public static NamespaceSymbol CreateNamespace(Name name, NamespaceSymbol parent)
    {
      NamespaceSymbol namespaceSymbol = (NamespaceSymbol) SymFactory.NewBasicSymbol(SYMKIND.SK_NamespaceSymbol, name, (ParentSymbol) parent);
      namespaceSymbol.SetAccess(ACCESS.ACC_PUBLIC);
      return namespaceSymbol;
    }

    public static AggregateSymbol CreateAggregate(Name name, NamespaceOrAggregateSymbol parent)
    {
      AggregateSymbol aggregate = (AggregateSymbol) SymFactory.NewBasicSymbol(SYMKIND.SK_AggregateSymbol, name, (ParentSymbol) parent);
      aggregate.name = name;
      aggregate.SetSealed(false);
      aggregate.SetAccess(ACCESS.ACC_UNKNOWN);
      aggregate.SetIfaces((TypeArray) null);
      aggregate.SetIfacesAll((TypeArray) null);
      aggregate.SetTypeVars((TypeArray) null);
      return aggregate;
    }

    public static FieldSymbol CreateMemberVar(Name name, AggregateSymbol parent)
    {
      return SymFactory.NewBasicSymbol(SYMKIND.SK_FieldSymbol, name, (ParentSymbol) parent) as FieldSymbol;
    }

    public static LocalVariableSymbol CreateLocalVar(Name name, Scope parent, CType type)
    {
      LocalVariableSymbol localVar = (LocalVariableSymbol) SymFactory.NewBasicSymbol(SYMKIND.SK_LocalVariableSymbol, name, (ParentSymbol) parent);
      localVar.SetType(type);
      localVar.SetAccess(ACCESS.ACC_UNKNOWN);
      localVar.wrap = (ExprWrap) null;
      return localVar;
    }

    public static MethodSymbol CreateMethod(Name name, AggregateSymbol parent)
    {
      return SymFactory.NewBasicSymbol(SYMKIND.SK_MethodSymbol, name, (ParentSymbol) parent) as MethodSymbol;
    }

    public static PropertySymbol CreateProperty(Name name, AggregateSymbol parent)
    {
      return SymFactory.NewBasicSymbol(SYMKIND.SK_PropertySymbol, name, (ParentSymbol) parent) as PropertySymbol;
    }

    public static EventSymbol CreateEvent(Name name, AggregateSymbol parent)
    {
      return SymFactory.NewBasicSymbol(SYMKIND.SK_EventSymbol, name, (ParentSymbol) parent) as EventSymbol;
    }

    public static TypeParameterSymbol CreateMethodTypeParameter(
      Name pName,
      MethodSymbol pParent,
      int index,
      int indexTotal)
    {
      TypeParameterSymbol methodTypeParameter = (TypeParameterSymbol) SymFactory.NewBasicSymbol(SYMKIND.SK_TypeParameterSymbol, pName, (ParentSymbol) pParent);
      methodTypeParameter.SetIndexInOwnParameters(index);
      methodTypeParameter.SetIndexInTotalParameters(indexTotal);
      methodTypeParameter.SetIsMethodTypeParameter(true);
      methodTypeParameter.SetAccess(ACCESS.ACC_PRIVATE);
      return methodTypeParameter;
    }

    public static TypeParameterSymbol CreateClassTypeParameter(
      Name pName,
      AggregateSymbol pParent,
      int index,
      int indexTotal)
    {
      TypeParameterSymbol classTypeParameter = (TypeParameterSymbol) SymFactory.NewBasicSymbol(SYMKIND.SK_TypeParameterSymbol, pName, (ParentSymbol) pParent);
      classTypeParameter.SetIndexInOwnParameters(index);
      classTypeParameter.SetIndexInTotalParameters(indexTotal);
      classTypeParameter.SetIsMethodTypeParameter(false);
      classTypeParameter.SetAccess(ACCESS.ACC_PRIVATE);
      return classTypeParameter;
    }

    public static Scope CreateScope()
    {
      return (Scope) SymFactory.NewBasicSymbol(SYMKIND.SK_Scope, (Name) null, (ParentSymbol) null);
    }

    public static IndexerSymbol CreateIndexer(Name name, ParentSymbol parent)
    {
      IndexerSymbol indexer = (IndexerSymbol) SymFactory.NewBasicSymbol(SYMKIND.SK_IndexerSymbol, name, parent);
      indexer.setKind(SYMKIND.SK_PropertySymbol);
      indexer.isOperator = true;
      return indexer;
    }
  }
}
