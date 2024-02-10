// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ArrayType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ArrayType : CType
  {
    public ArrayType(CType elementType, int rank, bool isSZArray)
      : base(TypeKind.TK_ArrayType)
    {
      this.Rank = rank;
      this.IsSZArray = isSZArray;
      this.ElementType = elementType;
    }

    public int Rank { get; }

    public bool IsSZArray { get; }

    public CType ElementType { get; }

    public CType BaseElementType
    {
      get
      {
        CType elementType = this.ElementType;
        while (elementType is ArrayType arrayType)
          elementType = arrayType.ElementType;
        return elementType;
      }
    }

    public override bool IsReferenceType => true;

    public override bool IsUnsafe() => this.BaseElementType is PointerType;

    public override Type AssociatedSystemType
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        Type associatedSystemType = this.ElementType.AssociatedSystemType;
        return !this.IsSZArray ? associatedSystemType.MakeArrayType(this.Rank) : associatedSystemType.MakeArrayType();
      }
    }

    public override CType BaseOrParameterOrElementType => this.ElementType;

    public override FUNDTYPE FundamentalType => FUNDTYPE.FT_REF;

    public override ConstValKind ConstValKind => ConstValKind.IntPtr;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public override AggregateType GetAts()
    {
      return SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY);
    }
  }
}
