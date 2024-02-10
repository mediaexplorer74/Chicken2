// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprCall
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprCall : ExprWithArgs
  {
    public ExprCall(
      CType type,
      EXPRFLAG flags,
      Expr arguments,
      ExprMemberGroup member,
      MethWithInst method)
      : base(ExpressionKind.Call, type)
    {
      this.Flags = flags;
      this.OptionalArguments = arguments;
      this.MemberGroup = member;
      this.NullableCallLiftKind = NullableCallLiftKind.NotLifted;
      this.MethWithInst = method;
    }

    public MethWithInst MethWithInst { get; set; }

    public PREDEFMETH PredefinedMethod { get; set; } = PREDEFMETH.PM_COUNT;

    public NullableCallLiftKind NullableCallLiftKind { get; set; }

    public Expr PConversions { get; set; }

    public Expr CastOfNonLiftedResultToLiftedType { get; set; }

    public override SymWithType GetSymWithType() => (SymWithType) this.MethWithInst;
  }
}
