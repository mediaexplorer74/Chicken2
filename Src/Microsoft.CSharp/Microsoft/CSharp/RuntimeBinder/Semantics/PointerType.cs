// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.PointerType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class PointerType : CType
  {
    public PointerType(CType referentType)
      : base(TypeKind.TK_PointerType)
    {
      this.ReferentType = referentType;
    }

    public CType ReferentType { get; }

    public override bool IsUnsafe() => true;

    public override Type AssociatedSystemType
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        return this.ReferentType.AssociatedSystemType.MakePointerType();
      }
    }

    public override CType BaseOrParameterOrElementType => this.ReferentType;

    public override FUNDTYPE FundamentalType => FUNDTYPE.FT_PTR;

    [ExcludeFromCodeCoverage(Justification = "Dynamic code can't contain constant pointers")]
    public override ConstValKind ConstValKind => ConstValKind.IntPtr;
  }
}
