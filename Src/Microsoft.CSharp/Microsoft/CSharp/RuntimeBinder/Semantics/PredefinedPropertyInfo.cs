﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.PredefinedPropertyInfo
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class PredefinedPropertyInfo
  {
    public PREDEFPROP property;
    public PredefinedName name;
    public PREDEFMETH getter;

    public PredefinedPropertyInfo(PREDEFPROP property, PredefinedName name, PREDEFMETH getter)
    {
      this.property = property;
      this.name = name;
      this.getter = getter;
    }
  }
}
