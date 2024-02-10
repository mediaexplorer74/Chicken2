// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprProperty
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprProperty : ExprWithArgs
  {
    public ExprProperty(
      CType type,
      Expr pOptionalObjectThrough,
      Expr pOptionalArguments,
      ExprMemberGroup pMemberGroup,
      PropWithType pwtSlot,
      MethWithType mwtSet)
      : base(ExpressionKind.Property, type)
    {
      this.OptionalObjectThrough = pOptionalObjectThrough;
      this.OptionalArguments = pOptionalArguments;
      this.MemberGroup = pMemberGroup;
      if ((SymWithType) pwtSlot != (SymWithType) null)
        this.PropWithTypeSlot = pwtSlot;
      if (!((SymWithType) mwtSet != (SymWithType) null))
        return;
      this.MethWithTypeSet = mwtSet;
      if (ExprProperty.HasIsExternalInitModifier(mwtSet))
        return;
      this.Flags = EXPRFLAG.EXF_LVALUE;
    }

    public Expr OptionalObjectThrough { get; }

    public PropWithType PropWithTypeSlot { get; }

    public MethWithType MethWithTypeSet { get; }

    public override SymWithType GetSymWithType() => (SymWithType) this.PropWithTypeSlot;

    internal static bool HasIsExternalInitModifier(MethWithType mwtSet)
    {
      System.Type[] requiredCustomModifiers = (mwtSet.Meth()?.AssociatedMemberInfo as MethodInfo)?.ReturnParameter.GetRequiredCustomModifiers();
      return requiredCustomModifiers != null && ((IEnumerable<System.Type>) requiredCustomModifiers).Any<System.Type>((Func<System.Type, bool>) (type => type.Name == "IsExternalInit" && !type.IsNested && type.Namespace == "System.Runtime.CompilerServices"));
    }
  }
}
