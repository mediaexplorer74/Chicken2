// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Errors.ErrArg
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using Microsoft.CSharp.RuntimeBinder.Syntax;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Errors
{
  internal class ErrArg
  {
    public ErrArgKind eak;
    public ErrArgFlags eaf;
    internal int n;
    internal SYMKIND sk;
    internal Name name;
    internal Symbol sym;
    internal string psz;
    internal CType pType;
    internal MethPropWithInstMemo mpwiMemo;
    internal SymWithTypeMemo swtMemo;

    public ErrArg()
    {
    }

    public ErrArg(int n)
    {
      this.eak = ErrArgKind.Int;
      this.eaf = ErrArgFlags.None;
      this.n = n;
    }

    public ErrArg(Name name)
    {
      this.eak = ErrArgKind.Name;
      this.eaf = ErrArgFlags.None;
      this.name = name;
    }

    public ErrArg(string psz)
    {
      this.eak = ErrArgKind.Str;
      this.eaf = ErrArgFlags.None;
      this.psz = psz;
    }

    public ErrArg(CType pType)
      : this(pType, ErrArgFlags.None)
    {
    }

    public ErrArg(CType pType, ErrArgFlags eaf)
    {
      this.eak = ErrArgKind.Type;
      this.eaf = eaf;
      this.pType = pType;
    }

    public ErrArg(Symbol pSym)
      : this(pSym, ErrArgFlags.None)
    {
    }

    private ErrArg(Symbol pSym, ErrArgFlags eaf)
    {
      this.eak = ErrArgKind.Sym;
      this.eaf = eaf;
      this.sym = pSym;
    }

    public ErrArg(SymWithType swt)
    {
      this.eak = ErrArgKind.SymWithType;
      this.eaf = ErrArgFlags.None;
      this.swtMemo = new SymWithTypeMemo();
      this.swtMemo.sym = swt.Sym;
      this.swtMemo.ats = swt.Ats;
    }

    public ErrArg(MethPropWithInst mpwi)
    {
      this.eak = ErrArgKind.MethWithInst;
      this.eaf = ErrArgFlags.None;
      this.mpwiMemo = new MethPropWithInstMemo();
      this.mpwiMemo.sym = mpwi.Sym;
      this.mpwiMemo.ats = mpwi.Ats;
      this.mpwiMemo.typeArgs = mpwi.TypeArgs;
    }

    public static implicit operator ErrArg(int n) => new ErrArg(n);

    public static implicit operator ErrArg(CType type) => new ErrArg(type);

    public static implicit operator ErrArg(string psz) => new ErrArg(psz);

    public static implicit operator ErrArg(Name name) => new ErrArg(name);

    public static implicit operator ErrArg(Symbol pSym) => new ErrArg(pSym);

    public static implicit operator ErrArg(SymWithType swt) => new ErrArg(swt);

    public static implicit operator ErrArg(MethPropWithInst mpwi) => new ErrArg(mpwi);
  }
}
