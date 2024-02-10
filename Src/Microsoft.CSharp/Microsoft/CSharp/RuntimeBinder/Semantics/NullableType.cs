// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.NullableType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class NullableType : CType
  {
    private AggregateType _ats;

    public NullableType(CType underlyingType)
      : base(TypeKind.TK_NullableType)
    {
      this.UnderlyingType = underlyingType;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public override AggregateType GetAts()
    {
      AggregateType ats = this._ats;
      if (ats != null)
        return ats;
      return this._ats = TypeManager.GetAggregate(TypeManager.GetNullable(), TypeArray.Allocate(this.UnderlyingType));
    }

    public override CType StripNubs() => this.UnderlyingType;

    public override CType StripNubs(out bool wasNullable)
    {
      wasNullable = true;
      return this.UnderlyingType;
    }

    public CType UnderlyingType { get; }

    public override bool IsValueType => true;

    public override bool IsStructType => true;

    public override Type AssociatedSystemType
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        return typeof (Nullable<>).MakeGenericType(this.UnderlyingType.AssociatedSystemType);
      }
    }

    public override CType BaseOrParameterOrElementType => this.UnderlyingType;

    public override FUNDTYPE FundamentalType => FUNDTYPE.FT_STRUCT;

    [ExcludeFromCodeCoverage(Justification = "Should be unreachable. Overload exists just to catch it being hit during debug.")]
    public override ConstValKind ConstValKind => ConstValKind.Decimal;
  }
}
