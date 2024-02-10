// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprMemberGroup
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprMemberGroup : ExprWithType
  {
    public ExprMemberGroup(
      EXPRFLAG flags,
      Name name,
      TypeArray typeArgs,
      SYMKIND symKind,
      CType parentType,
      Expr optionalObject,
      CMemberLookupResults memberLookupResults)
      : base(ExpressionKind.MemberGroup, (CType) MethodGroupType.Instance)
    {
      this.Flags = flags;
      this.Name = name;
      this.TypeArgs = typeArgs ?? TypeArray.Empty;
      this.SymKind = symKind;
      this.ParentType = parentType;
      this.OptionalObject = optionalObject;
      this.MemberLookupResults = memberLookupResults;
    }

    public Name Name { get; }

    public TypeArray TypeArgs { get; }

    public SYMKIND SymKind { get; }

    public Expr OptionalObject { get; set; }

    public CMemberLookupResults MemberLookupResults { get; }

    public CType ParentType { get; }

    public bool IsDelegate => (this.Flags & EXPRFLAG.EXF_GOTONOTBLOCKED) != 0;
  }
}
