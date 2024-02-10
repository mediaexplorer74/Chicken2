// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.ComEventsSink
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.ComInterop;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Versioning;

#nullable disable
namespace System.Runtime.InteropServices
{
  [SupportedOSPlatform("windows")]
  internal sealed class ComEventsSink : IDispatch, ICustomQueryInterface
  {
    private Guid _iidSourceItf;
    private IConnectionPoint _connectionPoint;
    private int _cookie;
    private ComEventsMethod _methods;
    private ComEventsSink _next;
    private const VarEnum VT_BYREF_VARIANT = VarEnum.VT_VARIANT | VarEnum.VT_BYREF;
    private const VarEnum VT_TYPEMASK = (VarEnum) 4095;
    private const VarEnum VT_BYREF_TYPEMASK = (VarEnum) 20479;

    public ComEventsSink(object rcw, Guid iid)
    {
      this._iidSourceItf = iid;
      this.Advise(rcw);
    }

    public static ComEventsSink Find(ComEventsSink sinks, ref Guid iid)
    {
      ComEventsSink comEventsSink = sinks;
      while (comEventsSink != null && comEventsSink._iidSourceItf != iid)
        comEventsSink = comEventsSink._next;
      return comEventsSink;
    }

    public static ComEventsSink Add(ComEventsSink sinks, ComEventsSink sink)
    {
      sink._next = sinks;
      return sink;
    }

    public static ComEventsSink RemoveAll(ComEventsSink sinks)
    {
      for (; sinks != null; sinks = sinks._next)
        sinks.Unadvise();
      return (ComEventsSink) null;
    }

    public static ComEventsSink Remove(ComEventsSink sinks, ComEventsSink sink)
    {
      ComEventsSink comEventsSink1 = sinks;
      if (sink == sinks)
      {
        comEventsSink1 = sinks._next;
      }
      else
      {
        ComEventsSink comEventsSink2 = sinks;
        while (comEventsSink2 != null && comEventsSink2._next != sink)
          comEventsSink2 = comEventsSink2._next;
        if (comEventsSink2 != null)
          comEventsSink2._next = sink._next;
      }
      sink.Unadvise();
      return comEventsSink1;
    }

    public ComEventsMethod RemoveMethod(ComEventsMethod method)
    {
      this._methods = ComEventsMethod.Remove(this._methods, method);
      return this._methods;
    }

    public ComEventsMethod FindMethod(int dispid) => ComEventsMethod.Find(this._methods, dispid);

    public ComEventsMethod AddMethod(int dispid)
    {
      ComEventsMethod method = new ComEventsMethod(dispid);
      this._methods = ComEventsMethod.Add(this._methods, method);
      return method;
    }

    int IDispatch.GetTypeInfoCount() => 0;

    ITypeInfo IDispatch.GetTypeInfo(int iTInfo, int lcid) => throw new NotImplementedException();

    void IDispatch.GetIDsOfNames(
      ref Guid iid,
      string[] names,
      int cNames,
      int lcid,
      int[] rgDispId)
    {
      throw new NotImplementedException();
    }

    private static unsafe ref Variant GetVariant(ref Variant pSrc)
    {
      if (pSrc.VariantType == (VarEnum.VT_VARIANT | VarEnum.VT_BYREF))
      {
        Span<Variant> span = new Span<Variant>(pSrc.AsByRefVariant.ToPointer(), 1);
        if ((span[0].VariantType & (VarEnum) 20479) == (VarEnum.VT_VARIANT | VarEnum.VT_BYREF))
          return ref span[0];
      }
      return ref pSrc;
    }

    unsafe void IDispatch.Invoke(
      int dispid,
      ref Guid riid,
      int lcid,
      InvokeFlags wFlags,
      ref DISPPARAMS pDispParams,
      IntPtr pVarResult,
      IntPtr pExcepInfo,
      IntPtr puArgErr)
    {
      ComEventsMethod method = this.FindMethod(dispid);
      if (method == null)
        return;
      object[] args = new object[pDispParams.cArgs];
      int[] numArray = new int[pDispParams.cArgs];
      bool[] flagArray = new bool[pDispParams.cArgs];
      int length = pDispParams.cNamedArgs + pDispParams.cArgs;
      Span<Variant> span1 = new Span<Variant>(pDispParams.rgvarg.ToPointer(), length);
      Span<int> span2 = new Span<int>(pDispParams.rgdispidNamedArgs.ToPointer(), length);
      int index1;
      for (index1 = 0; index1 < pDispParams.cNamedArgs; ++index1)
      {
        int index2 = span2[index1];
        ref Variant local = ref ComEventsSink.GetVariant(ref span1[index1]);
        args[index2] = local.ToObject();
        flagArray[index2] = true;
        int num = -1;
        if (local.IsByRef)
          num = index1;
        numArray[index2] = num;
      }
      int index3 = 0;
      for (; index1 < pDispParams.cArgs; ++index1)
      {
        while (flagArray[index3])
          ++index3;
        ref Variant local = ref ComEventsSink.GetVariant(ref span1[pDispParams.cArgs - 1 - index1]);
        args[index3] = local.ToObject();
        int num = -1;
        if (local.IsByRef)
          num = pDispParams.cArgs - 1 - index1;
        numArray[index3] = num;
        ++index3;
      }
      object obj = method.Invoke(args);
      if (pVarResult != IntPtr.Zero)
        Marshal.GetNativeVariantForObject(obj, pVarResult);
      for (int index4 = 0; index4 < pDispParams.cArgs; ++index4)
      {
        int index5 = numArray[index4];
        if (index5 != -1)
          ComEventsSink.GetVariant(ref span1[index5]).CopyFromIndirect(args[index4]);
      }
    }

    CustomQueryInterfaceResult ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
    {
      ppv = IntPtr.Zero;
      if (!(iid == this._iidSourceItf) && !(iid == typeof (IDispatch).GUID))
        return CustomQueryInterfaceResult.NotHandled;
      ppv = Marshal.GetComInterfaceForObject((object) this, typeof (IDispatch), CustomQueryInterfaceMode.Ignore);
      return CustomQueryInterfaceResult.Handled;
    }

    private void Advise(object rcw)
    {
      IConnectionPoint ppCP;
      ((IConnectionPointContainer) rcw).FindConnectionPoint(ref this._iidSourceItf, out ppCP);
      object pUnkSink = (object) this;
      ppCP.Advise(pUnkSink, out this._cookie);
      this._connectionPoint = ppCP;
    }

    private void Unadvise()
    {
      if (this._connectionPoint == null)
        return;
      try
      {
        this._connectionPoint.Unadvise(this._cookie);
        Marshal.ReleaseComObject((object) this._connectionPoint);
      }
      catch
      {
      }
      finally
      {
        this._connectionPoint = (IConnectionPoint) null;
      }
    }

    private void Initialize(object rcw, Guid iid)
    {
      this._iidSourceItf = iid;
      this.Advise(rcw);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public void AddHandler(int dispid, object func)
    {
      ComEventsMethod comEventsMethod = this.FindMethod(dispid) ?? this.AddMethod(dispid);
      Delegate d = func as Delegate;
      if ((object) d != null)
        comEventsMethod.AddDelegate(d);
      else
        comEventsMethod.AddDelegate((Delegate) new SplatCallSite.InvokeDelegate(new SplatCallSite(func).Invoke), true);
    }

    public void RemoveHandler(int dispid, object func)
    {
      ComEventsMethod method = this.FindMethod(dispid);
      if (method == null)
        return;
      Delegate d1 = func as Delegate;
      if ((object) d1 != null)
        method.RemoveDelegate(d1);
      else
        method.RemoveDelegates((Func<Delegate, bool>) (d => d.Target is SplatCallSite target && target._callable.Equals(func)));
      if (method.Empty)
        this.RemoveMethod(method);
      if (this._methods != null && !this._methods.Empty)
        return;
      this.Unadvise();
      this._iidSourceItf = Guid.Empty;
    }

    public static ComEventsSink FromRuntimeCallableWrapper(
      object rcw,
      Guid sourceIid,
      bool createIfNotFound)
    {
      List<ComEventsSink> comEventsSinkList = (List<ComEventsSink>) ComEventSinksContainer.FromRuntimeCallableWrapper(rcw, createIfNotFound);
      if (comEventsSinkList == null)
        return (ComEventsSink) null;
      ComEventsSink comEventsSink1 = (ComEventsSink) null;
      lock (comEventsSinkList)
      {
        foreach (ComEventsSink comEventsSink2 in comEventsSinkList)
        {
          if (comEventsSink2._iidSourceItf == sourceIid)
          {
            comEventsSink1 = comEventsSink2;
            break;
          }
          if (comEventsSink2._iidSourceItf == Guid.Empty)
          {
            comEventsSink2.Initialize(rcw, sourceIid);
            comEventsSink1 = comEventsSink2;
          }
        }
        if (comEventsSink1 == null & createIfNotFound)
        {
          comEventsSink1 = new ComEventsSink(rcw, sourceIid);
          comEventsSinkList.Add(comEventsSink1);
        }
      }
      return comEventsSink1;
    }
  }
}
