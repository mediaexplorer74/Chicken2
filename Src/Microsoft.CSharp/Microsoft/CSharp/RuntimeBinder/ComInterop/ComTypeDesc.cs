// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComTypeDesc
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal class ComTypeDesc
  {
    private readonly string _typeName;
    private readonly string _documentation;
    private ComMethodDesc _getItem;
    private ComMethodDesc _setItem;

    internal ComTypeDesc(ITypeInfo typeInfo, ComTypeLibDesc typeLibDesc)
    {
      if (typeInfo != null)
        ComRuntimeHelpers.GetInfoFromType(typeInfo, out this._typeName, out this._documentation);
      this.TypeLib = typeLibDesc;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static ComTypeDesc FromITypeInfo(ITypeInfo typeInfo, TYPEATTR typeAttr)
    {
      switch (typeAttr.typekind)
      {
        case TYPEKIND.TKIND_ENUM:
          return (ComTypeDesc) new ComTypeEnumDesc(typeInfo, (ComTypeLibDesc) null);
        case TYPEKIND.TKIND_INTERFACE:
        case TYPEKIND.TKIND_DISPATCH:
          return new ComTypeDesc(typeInfo, (ComTypeLibDesc) null);
        case TYPEKIND.TKIND_COCLASS:
          return (ComTypeDesc) new ComTypeClassDesc(typeInfo, (ComTypeLibDesc) null);
        default:
          throw new InvalidOperationException(SR.UnsupportedEnum);
      }
    }

    internal static ComTypeDesc CreateEmptyTypeDesc()
    {
      return new ComTypeDesc((ITypeInfo) null, (ComTypeLibDesc) null)
      {
        Funcs = new Hashtable(),
        Puts = new Hashtable(),
        PutRefs = new Hashtable(),
        Events = ComTypeDesc.EmptyEvents
      };
    }

    internal static Dictionary<string, ComEventDesc> EmptyEvents { get; } = new Dictionary<string, ComEventDesc>();

    internal Hashtable Funcs { get; set; }

    internal Hashtable Puts { get; set; }

    internal Hashtable PutRefs { get; set; }

    internal Dictionary<string, ComEventDesc> Events { get; set; }

    internal bool TryGetFunc(string name, out ComMethodDesc method)
    {
      name = name.ToUpper(CultureInfo.InvariantCulture);
      if (this.Funcs.ContainsKey((object) name))
      {
        method = this.Funcs[(object) name] as ComMethodDesc;
        return true;
      }
      method = (ComMethodDesc) null;
      return false;
    }

    internal void AddFunc(string name, ComMethodDesc method)
    {
      name = name.ToUpper(CultureInfo.InvariantCulture);
      lock (this.Funcs)
        this.Funcs[(object) name] = (object) method;
    }

    internal bool TryGetPut(string name, out ComMethodDesc method)
    {
      name = name.ToUpper(CultureInfo.InvariantCulture);
      if (this.Puts.ContainsKey((object) name))
      {
        method = this.Puts[(object) name] as ComMethodDesc;
        return true;
      }
      method = (ComMethodDesc) null;
      return false;
    }

    internal void AddPut(string name, ComMethodDesc method)
    {
      name = name.ToUpper(CultureInfo.InvariantCulture);
      lock (this.Puts)
        this.Puts[(object) name] = (object) method;
    }

    internal bool TryGetPutRef(string name, out ComMethodDesc method)
    {
      name = name.ToUpper(CultureInfo.InvariantCulture);
      if (this.PutRefs.ContainsKey((object) name))
      {
        method = this.PutRefs[(object) name] as ComMethodDesc;
        return true;
      }
      method = (ComMethodDesc) null;
      return false;
    }

    internal void AddPutRef(string name, ComMethodDesc method)
    {
      name = name.ToUpper(CultureInfo.InvariantCulture);
      lock (this.PutRefs)
        this.PutRefs[(object) name] = (object) method;
    }

    internal bool TryGetEvent(string name, out ComEventDesc @event)
    {
      name = name.ToUpper(CultureInfo.InvariantCulture);
      return this.Events.TryGetValue(name, out @event);
    }

    internal string[] GetMemberNames(bool dataOnly)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      lock (this.Funcs)
      {
        foreach (ComMethodDesc comMethodDesc in (IEnumerable) this.Funcs.Values)
        {
          if (!dataOnly || comMethodDesc.IsDataMember)
            dictionary.Add(comMethodDesc.Name, (object) null);
        }
      }
      if (!dataOnly)
      {
        lock (this.Puts)
        {
          foreach (ComMethodDesc comMethodDesc in (IEnumerable) this.Puts.Values)
          {
            if (!dictionary.ContainsKey(comMethodDesc.Name))
              dictionary.Add(comMethodDesc.Name, (object) null);
          }
        }
        lock (this.PutRefs)
        {
          foreach (ComMethodDesc comMethodDesc in (IEnumerable) this.PutRefs.Values)
          {
            if (!dictionary.ContainsKey(comMethodDesc.Name))
              dictionary.Add(comMethodDesc.Name, (object) null);
          }
        }
        if (this.Events != null && this.Events.Count > 0)
        {
          foreach (string key in this.Events.Keys)
          {
            if (!dictionary.ContainsKey(key))
              dictionary.Add(key, (object) null);
          }
        }
      }
      string[] array = new string[dictionary.Keys.Count];
      dictionary.Keys.CopyTo(array, 0);
      return array;
    }

    public string TypeName => this._typeName;

    public ComTypeLibDesc TypeLib { get; }

    internal Guid Guid { get; set; }

    internal ComMethodDesc GetItem => this._getItem;

    internal void EnsureGetItem(ComMethodDesc candidate)
    {
      Interlocked.CompareExchange<ComMethodDesc>(ref this._getItem, candidate, (ComMethodDesc) null);
    }

    internal ComMethodDesc SetItem => this._setItem;

    internal void EnsureSetItem(ComMethodDesc candidate)
    {
      Interlocked.CompareExchange<ComMethodDesc>(ref this._setItem, candidate, (ComMethodDesc) null);
    }
  }
}
