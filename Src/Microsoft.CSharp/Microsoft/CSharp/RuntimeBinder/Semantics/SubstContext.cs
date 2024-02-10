// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.SubstContext
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class SubstContext
  {
    public readonly CType[] ClassTypes;
    public readonly CType[] MethodTypes;
    public readonly bool DenormMeth;

    public SubstContext(TypeArray typeArgsCls, TypeArray typeArgsMeth, bool denormMeth)
    {
      this.ClassTypes = typeArgsCls?.Items ?? Array.Empty<CType>();
      this.MethodTypes = typeArgsMeth?.Items ?? Array.Empty<CType>();
      this.DenormMeth = denormMeth;
    }

    public SubstContext(AggregateType type)
      : this(type, (TypeArray) null, false)
    {
    }

    public SubstContext(AggregateType type, TypeArray typeArgsMeth)
      : this(type, typeArgsMeth, false)
    {
    }

    private SubstContext(AggregateType type, TypeArray typeArgsMeth, bool denormMeth)
      : this(type?.TypeArgsAll, typeArgsMeth, denormMeth)
    {
    }

    public bool IsNop => this.ClassTypes.Length == 0 & this.MethodTypes.Length == 0;
  }
}
