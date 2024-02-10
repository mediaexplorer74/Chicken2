// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComEventSinksContainer
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ComEventSinksContainer : List<ComEventsSink>, IDisposable
  {
    private static readonly object s_comObjectEventSinksKey = new object();

    private ComEventSinksContainer()
    {
    }

    public static ComEventSinksContainer FromRuntimeCallableWrapper(
      object rcw,
      bool createIfNotFound)
    {
      object comObjectData1 = Marshal.GetComObjectData(rcw, ComEventSinksContainer.s_comObjectEventSinksKey);
      if (comObjectData1 != null || !createIfNotFound)
        return (ComEventSinksContainer) comObjectData1;
      lock (ComEventSinksContainer.s_comObjectEventSinksKey)
      {
        object comObjectData2 = Marshal.GetComObjectData(rcw, ComEventSinksContainer.s_comObjectEventSinksKey);
        if (comObjectData2 != null)
          return (ComEventSinksContainer) comObjectData2;
        ComEventSinksContainer data = new ComEventSinksContainer();
        if (!Marshal.SetComObjectData(rcw, ComEventSinksContainer.s_comObjectEventSinksKey, (object) data))
          throw Error.SetComObjectDataFailed();
        return data;
      }
    }

    public void Dispose()
    {
      this.DisposeAll();
      GC.SuppressFinalize((object) this);
    }

    private void DisposeAll()
    {
      foreach (ComEventsSink sinks in (List<ComEventsSink>) this)
        ComEventsSink.RemoveAll(sinks);
    }

    ~ComEventSinksContainer() => this.DisposeAll();
  }
}
