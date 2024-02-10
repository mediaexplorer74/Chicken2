// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.PredefinedMethodInfo
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class PredefinedMethodInfo
  {
    public PREDEFMETH method;
    public PredefinedType type;
    public PredefinedName name;
    public MethodCallingConventionEnum callingConvention;
    public ACCESS access;
    public int cTypeVars;
    public int[] signature;

    public PredefinedMethodInfo(
      PREDEFMETH method,
      PredefinedType type,
      PredefinedName name,
      MethodCallingConventionEnum callingConvention,
      ACCESS access,
      int cTypeVars,
      int[] signature)
    {
      this.method = method;
      this.type = type;
      this.name = name;
      this.callingConvention = callingConvention;
      this.access = access;
      this.cTypeVars = cTypeVars;
      this.signature = signature;
    }
  }
}
