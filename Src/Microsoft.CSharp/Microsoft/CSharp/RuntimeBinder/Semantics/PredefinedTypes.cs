// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.PredefinedTypes
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class PredefinedTypes
  {
    private static readonly AggregateSymbol[] s_predefSymbols = new AggregateSymbol[49];

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static AggregateSymbol DelayLoadPredefSym(PredefinedType pt)
    {
      return PredefinedTypes.InitializePredefinedType(((AggregateType) SymbolTable.GetCTypeFromType(PredefinedTypeFacts.GetAssociatedSystemType(pt))).OwningAggregate, pt);
    }

    internal static AggregateSymbol InitializePredefinedType(AggregateSymbol sym, PredefinedType pt)
    {
      sym.SetPredefined(true);
      sym.SetPredefType(pt);
      sym.SetSkipUDOps(pt <= PredefinedType.PT_ENUM && pt != PredefinedType.FirstNonSimpleType && pt != PredefinedType.PT_UINTPTR && pt != PredefinedType.PT_TYPE);
      return sym;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static AggregateSymbol GetPredefinedAggregate(PredefinedType pt)
    {
      return PredefinedTypes.s_predefSymbols[(int) pt] ?? (PredefinedTypes.s_predefSymbols[(int) pt] = PredefinedTypes.DelayLoadPredefSym(pt));
    }

    private static string GetNiceName(PredefinedType pt) => PredefinedTypeFacts.GetNiceName(pt);

    public static string GetNiceName(AggregateSymbol type)
    {
      return !type.IsPredefined() ? (string) null : PredefinedTypes.GetNiceName(type.GetPredefType());
    }
  }
}
