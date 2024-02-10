// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.MethPropWithInst
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal class MethPropWithInst : MethPropWithType
  {
    public TypeArray TypeArgs { get; private set; }

    public MethPropWithInst()
    {
      this.Set((MethodOrPropertySymbol) null, (AggregateType) null, (TypeArray) null);
    }

    public MethPropWithInst(MethodOrPropertySymbol mps, AggregateType ats)
      : this(mps, ats, (TypeArray) null)
    {
    }

    public MethPropWithInst(MethodOrPropertySymbol mps, AggregateType ats, TypeArray typeArgs)
    {
      this.Set(mps, ats, typeArgs);
    }

    public override void Clear()
    {
      base.Clear();
      this.TypeArgs = (TypeArray) null;
    }

    public void Set(MethodOrPropertySymbol mps, AggregateType ats, TypeArray typeArgs)
    {
      if (mps == null)
      {
        ats = (AggregateType) null;
        typeArgs = (TypeArray) null;
      }
      this.Set((Symbol) mps, ats);
      this.TypeArgs = typeArgs;
    }
  }
}
