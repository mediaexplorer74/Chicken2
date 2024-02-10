// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.SymWithType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal class SymWithType
  {
    private AggregateType _ats;
    private Symbol _sym;

    public SymWithType()
    {
    }

    public SymWithType(Symbol sym, AggregateType ats) => this.Set(sym, ats);

    public virtual void Clear()
    {
      this._sym = (Symbol) null;
      this._ats = (AggregateType) null;
    }

    public AggregateType Ats => this._ats;

    public Symbol Sym => this._sym;

    public AggregateType GetType() => this.Ats;

    public static bool operator ==(SymWithType swt1, SymWithType swt2)
    {
      if ((object) swt1 == (object) swt2)
        return true;
      if ((object) swt1 == null)
        return swt2._sym == null;
      if ((object) swt2 == null)
        return swt1._sym == null;
      return swt1.Sym == swt2.Sym && swt1.Ats == swt2.Ats;
    }

    public static bool operator !=(SymWithType swt1, SymWithType swt2) => !(swt1 == swt2);

    [ExcludeFromCodeCoverage(Justification = "== overload should always be the method called")]
    public override bool Equals(object obj)
    {
      SymWithType symWithType = obj as SymWithType;
      return !(symWithType == (SymWithType) null) && this.Sym == symWithType.Sym && this.Ats == symWithType.Ats;
    }

    [ExcludeFromCodeCoverage(Justification = "Never used as a key")]
    public override int GetHashCode()
    {
      Symbol sym = this.Sym;
      int hashCode1 = sym != null ? sym.GetHashCode() : 0;
      AggregateType ats = this.Ats;
      int hashCode2 = ats != null ? ats.GetHashCode() : 0;
      return hashCode1 + hashCode2;
    }

    public static implicit operator bool(SymWithType swt) => swt != (SymWithType) null;

    public MethodOrPropertySymbol MethProp() => this.Sym as MethodOrPropertySymbol;

    public MethodSymbol Meth() => this.Sym as MethodSymbol;

    public PropertySymbol Prop() => this.Sym as PropertySymbol;

    public FieldSymbol Field() => this.Sym as FieldSymbol;

    public EventSymbol Event() => this.Sym as EventSymbol;

    public void Set(Symbol sym, AggregateType ats)
    {
      if (sym == null)
        ats = (AggregateType) null;
      this._sym = sym;
      this._ats = ats;
    }
  }
}
