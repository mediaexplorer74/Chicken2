// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ParameterModifierType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ParameterModifierType : CType
  {
    public ParameterModifierType(CType parameterType, bool isOut)
      : base(TypeKind.TK_ParameterModifierType)
    {
      this.ParameterType = parameterType;
      this.IsOut = isOut;
    }

    public bool IsOut { get; }

    public CType ParameterType { get; }

    public override Type AssociatedSystemType
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        return this.ParameterType.AssociatedSystemType.MakeByRefType();
      }
    }

    public override CType BaseOrParameterOrElementType => this.ParameterType;
  }
}
