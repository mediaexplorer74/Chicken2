// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.IDispatchComObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class IDispatchComObject : ComObject, IDynamicMetaObjectProvider
  {
    private ComTypeDesc _comTypeDesc;
    private static readonly Dictionary<Guid, ComTypeDesc> s_cacheComTypeDesc = new Dictionary<Guid, ComTypeDesc>();

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal IDispatchComObject(IDispatch rcw)
      : base((object) rcw)
    {
      this.DispatchObject = rcw;
    }

    public override string ToString()
    {
      ComTypeDesc comTypeDesc = this._comTypeDesc;
      string str = (string) null;
      if (comTypeDesc != null)
        str = comTypeDesc.TypeName;
      if (string.IsNullOrEmpty(str))
        str = "IDispatch";
      return this.RuntimeCallableWrapper.ToString() + " (" + str + ")";
    }

    public ComTypeDesc ComTypeDesc
    {
      get
      {
        this.EnsureScanDefinedMethods();
        return this._comTypeDesc;
      }
    }

    public IDispatch DispatchObject { get; }

    private static int GetIDsOfNames(IDispatch dispatch, string name, out int dispId)
    {
      int[] rgDispId = new int[1];
      Guid empty = Guid.Empty;
      int idsOfNames = dispatch.TryGetIDsOfNames(ref empty, new string[1]
      {
        name
      }, 1U, 0, rgDispId);
      dispId = rgDispId[0];
      return idsOfNames;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal bool TryGetGetItem(out ComMethodDesc value)
    {
      ComMethodDesc getItem = this._comTypeDesc.GetItem;
      if (getItem == null)
        return this.SlowTryGetGetItem(out value);
      value = getItem;
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool SlowTryGetGetItem(out ComMethodDesc value)
    {
      this.EnsureScanDefinedMethods();
      ComMethodDesc getItem = this._comTypeDesc.GetItem;
      if (getItem == null)
      {
        this._comTypeDesc.EnsureGetItem(new ComMethodDesc("[PROPERTYGET, DISPID(0)]", 0, INVOKEKIND.INVOKE_PROPERTYGET));
        getItem = this._comTypeDesc.GetItem;
      }
      value = getItem;
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal bool TryGetSetItem(out ComMethodDesc value)
    {
      ComMethodDesc setItem = this._comTypeDesc.SetItem;
      if (setItem == null)
        return this.SlowTryGetSetItem(out value);
      value = setItem;
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool SlowTryGetSetItem(out ComMethodDesc value)
    {
      this.EnsureScanDefinedMethods();
      ComMethodDesc setItem = this._comTypeDesc.SetItem;
      if (setItem == null)
      {
        this._comTypeDesc.EnsureSetItem(new ComMethodDesc("[PROPERTYPUT, DISPID(0)]", 0, INVOKEKIND.INVOKE_PROPERTYPUT));
        setItem = this._comTypeDesc.SetItem;
      }
      value = setItem;
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal bool TryGetMemberMethod(string name, out ComMethodDesc method)
    {
      this.EnsureScanDefinedMethods();
      return this._comTypeDesc.TryGetFunc(name, out method);
    }

    internal bool TryGetMemberEvent(string name, out ComEventDesc @event)
    {
      this.EnsureScanDefinedEvents();
      return this._comTypeDesc.TryGetEvent(name, out @event);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal bool TryGetMemberMethodExplicit(string name, out ComMethodDesc method)
    {
      this.EnsureScanDefinedMethods();
      int dispId;
      int idsOfNames = IDispatchComObject.GetIDsOfNames(this.DispatchObject, name, out dispId);
      switch (idsOfNames)
      {
        case -2147352570:
          method = (ComMethodDesc) null;
          return false;
        case 0:
          ComMethodDesc method1 = new ComMethodDesc(name, dispId, INVOKEKIND.INVOKE_FUNC);
          this._comTypeDesc.AddFunc(name, method1);
          method = method1;
          return true;
        default:
          throw Error.CouldNotGetDispId((object) name, (object) string.Format((IFormatProvider) CultureInfo.InvariantCulture, "0x{0:X})", (object) idsOfNames));
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal bool TryGetPropertySetterExplicit(
      string name,
      out ComMethodDesc method,
      Type limitType,
      bool holdsNull)
    {
      this.EnsureScanDefinedMethods();
      int dispId;
      int idsOfNames = IDispatchComObject.GetIDsOfNames(this.DispatchObject, name, out dispId);
      switch (idsOfNames)
      {
        case -2147352570:
          method = (ComMethodDesc) null;
          return false;
        case 0:
          ComMethodDesc method1 = new ComMethodDesc(name, dispId, INVOKEKIND.INVOKE_PROPERTYPUT);
          this._comTypeDesc.AddPut(name, method1);
          ComMethodDesc method2 = new ComMethodDesc(name, dispId, INVOKEKIND.INVOKE_PROPERTYPUTREF);
          this._comTypeDesc.AddPutRef(name, method2);
          method = !ComBinderHelpers.PreferPut(limitType, holdsNull) ? method2 : method1;
          return true;
        default:
          throw Error.CouldNotGetDispId((object) name, (object) string.Format((IFormatProvider) CultureInfo.InvariantCulture, "0x{0:X})", (object) idsOfNames));
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal override IList<string> GetMemberNames(bool dataOnly)
    {
      this.EnsureScanDefinedMethods();
      this.EnsureScanDefinedEvents();
      return (IList<string>) this.ComTypeDesc.GetMemberNames(dataOnly);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal override IList<KeyValuePair<string, object>> GetMembers(IEnumerable<string> names)
    {
      if (names == null)
        names = (IEnumerable<string>) this.GetMemberNames(true);
      Type type = this.RuntimeCallableWrapper.GetType();
      List<KeyValuePair<string, object>> keyValuePairList = new List<KeyValuePair<string, object>>();
      foreach (string name in names)
      {
        ComMethodDesc method;
        if (name != null && this.ComTypeDesc.TryGetFunc(name, out method))
        {
          if (method.IsDataMember)
          {
            try
            {
              object obj = type.InvokeMember(method.Name, BindingFlags.GetProperty, (System.Reflection.Binder) null, this.RuntimeCallableWrapper, Array.Empty<object>(), CultureInfo.InvariantCulture);
              keyValuePairList.Add(new KeyValuePair<string, object>(method.Name, obj));
            }
            catch (Exception ex)
            {
              keyValuePairList.Add(new KeyValuePair<string, object>(method.Name, (object) ex));
            }
          }
        }
      }
      return (IList<KeyValuePair<string, object>>) keyValuePairList.ToArray();
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
    {
      this.EnsureScanDefinedMethods();
      return (DynamicMetaObject) new IDispatchMetaObject(parameter, this);
    }

    private static void GetFuncDescForDescIndex(
      ITypeInfo typeInfo,
      int funcIndex,
      out FUNCDESC funcDesc,
      out IntPtr funcDescHandle)
    {
      IntPtr ppFuncDesc;
      typeInfo.GetFuncDesc(funcIndex, out ppFuncDesc);
      funcDesc = !(ppFuncDesc == IntPtr.Zero) ? (FUNCDESC) Marshal.PtrToStructure(ppFuncDesc, typeof (FUNCDESC)) : throw Error.CannotRetrieveTypeInformation();
      funcDescHandle = ppFuncDesc;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    private void EnsureScanDefinedEvents()
    {
      if (this._comTypeDesc?.Events != null)
        return;
      ITypeInfo infoFromIdispatch = ComRuntimeHelpers.GetITypeInfoFromIDispatch(this.DispatchObject);
      if (infoFromIdispatch == null)
      {
        this._comTypeDesc = ComTypeDesc.CreateEmptyTypeDesc();
      }
      else
      {
        TYPEATTR typeAttrForTypeInfo1 = ComRuntimeHelpers.GetTypeAttrForTypeInfo(infoFromIdispatch);
        if (this._comTypeDesc == null)
        {
          lock (IDispatchComObject.s_cacheComTypeDesc)
          {
            if (IDispatchComObject.s_cacheComTypeDesc.TryGetValue(typeAttrForTypeInfo1.guid, out this._comTypeDesc))
            {
              if (this._comTypeDesc.Events != null)
                return;
            }
          }
        }
        ComTypeDesc comTypeDesc1 = ComTypeDesc.FromITypeInfo(infoFromIdispatch, typeAttrForTypeInfo1);
        Dictionary<string, ComEventDesc> events;
        if (!(this.RuntimeCallableWrapper is IConnectionPointContainer))
        {
          events = ComTypeDesc.EmptyEvents;
        }
        else
        {
          ITypeInfo coClassTypeInfo;
          if ((coClassTypeInfo = IDispatchComObject.GetCoClassTypeInfo(this.RuntimeCallableWrapper, infoFromIdispatch)) == null)
          {
            events = ComTypeDesc.EmptyEvents;
          }
          else
          {
            events = new Dictionary<string, ComEventDesc>();
            TYPEATTR typeAttrForTypeInfo2 = ComRuntimeHelpers.GetTypeAttrForTypeInfo(coClassTypeInfo);
            for (int index = 0; index < (int) typeAttrForTypeInfo2.cImplTypes; ++index)
            {
              int href;
              coClassTypeInfo.GetRefTypeOfImplType(index, out href);
              ITypeInfo ppTI;
              coClassTypeInfo.GetRefTypeInfo(href, out ppTI);
              IMPLTYPEFLAGS pImplTypeFlags;
              coClassTypeInfo.GetImplTypeFlags(index, out pImplTypeFlags);
              if ((pImplTypeFlags & IMPLTYPEFLAGS.IMPLTYPEFLAG_FSOURCE) != (IMPLTYPEFLAGS) 0)
                IDispatchComObject.ScanSourceInterface(ppTI, ref events);
            }
            if (events.Count == 0)
              events = ComTypeDesc.EmptyEvents;
          }
        }
        lock (IDispatchComObject.s_cacheComTypeDesc)
        {
          ComTypeDesc comTypeDesc2;
          if (IDispatchComObject.s_cacheComTypeDesc.TryGetValue(typeAttrForTypeInfo1.guid, out comTypeDesc2))
          {
            this._comTypeDesc = comTypeDesc2;
          }
          else
          {
            this._comTypeDesc = comTypeDesc1;
            IDispatchComObject.s_cacheComTypeDesc.Add(typeAttrForTypeInfo1.guid, this._comTypeDesc);
          }
          this._comTypeDesc.Events = events;
        }
      }
    }

    private static void ScanSourceInterface(
      ITypeInfo sourceTypeInfo,
      ref Dictionary<string, ComEventDesc> events)
    {
      TYPEATTR typeAttrForTypeInfo = ComRuntimeHelpers.GetTypeAttrForTypeInfo(sourceTypeInfo);
      for (int funcIndex = 0; funcIndex < (int) typeAttrForTypeInfo.cFuncs; ++funcIndex)
      {
        IntPtr funcDescHandle = IntPtr.Zero;
        try
        {
          FUNCDESC funcDesc;
          IDispatchComObject.GetFuncDescForDescIndex(sourceTypeInfo, funcIndex, out funcDesc, out funcDescHandle);
          if (((int) funcDesc.wFuncFlags & 64) == 0)
          {
            if (((int) funcDesc.wFuncFlags & 1) == 0)
            {
              string upper = ComRuntimeHelpers.GetNameOfMethod(sourceTypeInfo, funcDesc.memid).ToUpper(CultureInfo.InvariantCulture);
              if (!events.ContainsKey(upper))
              {
                ComEventDesc comEventDesc = new ComEventDesc()
                {
                  Dispid = funcDesc.memid,
                  SourceIID = typeAttrForTypeInfo.guid
                };
                events.Add(upper, comEventDesc);
              }
            }
          }
        }
        finally
        {
          if (funcDescHandle != IntPtr.Zero)
            sourceTypeInfo.ReleaseFuncDesc(funcDescHandle);
        }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ITypeInfo GetCoClassTypeInfo(object rcw, ITypeInfo typeInfo)
    {
      if (rcw is IProvideClassInfo provideClassInfo)
      {
        IntPtr info = IntPtr.Zero;
        try
        {
          provideClassInfo.GetClassInfo(out info);
          if (info != IntPtr.Zero)
            return Marshal.GetObjectForIUnknown(info) as ITypeInfo;
        }
        finally
        {
          if (info != IntPtr.Zero)
            Marshal.Release(info);
        }
      }
      ITypeLib ppTLB;
      typeInfo.GetContainingTypeLib(out ppTLB, out int _);
      string nameOfType = ComRuntimeHelpers.GetNameOfType(typeInfo);
      ComTypeClassDesc classForInterface = ComTypeLibDesc.GetFromTypeLib(ppTLB).GetCoClassForInterface(nameOfType);
      if (classForInterface == null)
        return (ITypeInfo) null;
      Guid guid = classForInterface.Guid;
      ITypeInfo ppTInfo;
      ppTLB.GetTypeInfoOfGuid(ref guid, out ppTInfo);
      return ppTInfo;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    private void EnsureScanDefinedMethods()
    {
      if (this._comTypeDesc?.Funcs != null)
        return;
      ITypeInfo infoFromIdispatch = ComRuntimeHelpers.GetITypeInfoFromIDispatch(this.DispatchObject);
      if (infoFromIdispatch == null)
      {
        this._comTypeDesc = ComTypeDesc.CreateEmptyTypeDesc();
      }
      else
      {
        TYPEATTR typeAttrForTypeInfo = ComRuntimeHelpers.GetTypeAttrForTypeInfo(infoFromIdispatch);
        if (this._comTypeDesc == null)
        {
          lock (IDispatchComObject.s_cacheComTypeDesc)
          {
            if (IDispatchComObject.s_cacheComTypeDesc.TryGetValue(typeAttrForTypeInfo.guid, out this._comTypeDesc))
            {
              if (this._comTypeDesc.Funcs != null)
                return;
            }
          }
        }
        ComTypeDesc comTypeDesc1 = ComTypeDesc.FromITypeInfo(infoFromIdispatch, typeAttrForTypeInfo);
        ComMethodDesc candidate1 = (ComMethodDesc) null;
        ComMethodDesc candidate2 = (ComMethodDesc) null;
        Hashtable hashtable1 = new Hashtable((int) typeAttrForTypeInfo.cFuncs);
        Hashtable hashtable2 = new Hashtable();
        Hashtable hashtable3 = new Hashtable();
        for (int funcIndex = 0; funcIndex < (int) typeAttrForTypeInfo.cFuncs; ++funcIndex)
        {
          IntPtr funcDescHandle = IntPtr.Zero;
          try
          {
            FUNCDESC funcDesc;
            IDispatchComObject.GetFuncDescForDescIndex(infoFromIdispatch, funcIndex, out funcDesc, out funcDescHandle);
            if (((int) funcDesc.wFuncFlags & 1) == 0)
            {
              ComMethodDesc comMethodDesc = new ComMethodDesc(infoFromIdispatch, funcDesc);
              string upper = comMethodDesc.Name.ToUpper(CultureInfo.InvariantCulture);
              if ((funcDesc.invkind & INVOKEKIND.INVOKE_PROPERTYPUT) != (INVOKEKIND) 0)
              {
                hashtable2.Add((object) upper, (object) comMethodDesc);
                if (comMethodDesc.DispId == 0)
                {
                  if (candidate2 == null)
                    candidate2 = comMethodDesc;
                }
              }
              else if ((funcDesc.invkind & INVOKEKIND.INVOKE_PROPERTYPUTREF) != (INVOKEKIND) 0)
              {
                hashtable3.Add((object) upper, (object) comMethodDesc);
                if (comMethodDesc.DispId == 0)
                {
                  if (candidate2 == null)
                    candidate2 = comMethodDesc;
                }
              }
              else if (funcDesc.memid == -4)
              {
                hashtable1.Add((object) "GETENUMERATOR", (object) comMethodDesc);
              }
              else
              {
                hashtable1.Add((object) upper, (object) comMethodDesc);
                if (funcDesc.memid == 0)
                  candidate1 = comMethodDesc;
              }
            }
          }
          finally
          {
            if (funcDescHandle != IntPtr.Zero)
              infoFromIdispatch.ReleaseFuncDesc(funcDescHandle);
          }
        }
        lock (IDispatchComObject.s_cacheComTypeDesc)
        {
          ComTypeDesc comTypeDesc2;
          if (IDispatchComObject.s_cacheComTypeDesc.TryGetValue(typeAttrForTypeInfo.guid, out comTypeDesc2))
          {
            this._comTypeDesc = comTypeDesc2;
          }
          else
          {
            this._comTypeDesc = comTypeDesc1;
            IDispatchComObject.s_cacheComTypeDesc.Add(typeAttrForTypeInfo.guid, this._comTypeDesc);
          }
          this._comTypeDesc.Funcs = hashtable1;
          this._comTypeDesc.Puts = hashtable2;
          this._comTypeDesc.PutRefs = hashtable3;
          this._comTypeDesc.EnsureGetItem(candidate1);
          this._comTypeDesc.EnsureSetItem(candidate2);
        }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal bool TryGetPropertySetter(
      string name,
      out ComMethodDesc method,
      Type limitType,
      bool holdsNull)
    {
      this.EnsureScanDefinedMethods();
      return ComBinderHelpers.PreferPut(limitType, holdsNull) ? this._comTypeDesc.TryGetPut(name, out method) || this._comTypeDesc.TryGetPutRef(name, out method) : this._comTypeDesc.TryGetPutRef(name, out method) || this._comTypeDesc.TryGetPut(name, out method);
    }
  }
}
