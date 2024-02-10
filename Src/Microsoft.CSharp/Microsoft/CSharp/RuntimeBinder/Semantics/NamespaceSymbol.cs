// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.NamespaceSymbol
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class NamespaceSymbol : NamespaceOrAggregateSymbol
  {
    public static readonly NamespaceSymbol Root = NamespaceSymbol.GetRootNamespaceSymbol();

    private static NamespaceSymbol GetRootNamespaceSymbol()
    {
      NamespaceSymbol namespaceSymbol = new NamespaceSymbol();
      namespaceSymbol.name = NameManager.GetPredefinedName(PredefinedName.PN_VOID);
      NamespaceSymbol rootNamespaceSymbol = namespaceSymbol;
      rootNamespaceSymbol.setKind(SYMKIND.SK_NamespaceSymbol);
      return rootNamespaceSymbol;
    }
  }
}
