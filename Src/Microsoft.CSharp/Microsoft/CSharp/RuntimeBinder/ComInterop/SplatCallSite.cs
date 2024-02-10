// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.SplatCallSite
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class SplatCallSite
  {
    internal readonly object _callable;
    private CallSite<Func<CallSite, object, object[], object>> _site;

    internal SplatCallSite(object callable) => this._callable = callable;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal object Invoke(object[] args)
    {
      if (this._site == null)
        this._site = CallSite<Func<CallSite, object, object[], object>>.Create((CallSiteBinder) SplatInvokeBinder.Instance);
      return this._site.Target((CallSite) this._site, this._callable, args);
    }

    public delegate object InvokeDelegate(object[] args);
  }
}
