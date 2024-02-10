// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComTypeLibDesc
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ComTypeLibDesc : IDynamicMetaObjectProvider
  {
    private readonly LinkedList<ComTypeClassDesc> _classes;
    private readonly Dictionary<string, ComTypeEnumDesc> _enums;
    private TYPELIBATTR _typeLibAttributes;
    private static readonly Dictionary<Guid, ComTypeLibDesc> s_cachedTypeLibDesc = new Dictionary<Guid, ComTypeLibDesc>();

    private ComTypeLibDesc()
    {
      this._enums = new Dictionary<string, ComTypeEnumDesc>();
      this._classes = new LinkedList<ComTypeClassDesc>();
    }

    public override string ToString() => "<type library " + this.Name + ">";

    DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
    {
      return (DynamicMetaObject) new TypeLibMetaObject(parameter, this);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static ComTypeLibDesc GetFromTypeLib(ITypeLib typeLib)
    {
      TYPELIBATTR typeAttrForTypeLib = ComRuntimeHelpers.GetTypeAttrForTypeLib(typeLib);
      lock (ComTypeLibDesc.s_cachedTypeLibDesc)
      {
        ComTypeLibDesc fromTypeLib;
        if (ComTypeLibDesc.s_cachedTypeLibDesc.TryGetValue(typeAttrForTypeLib.guid, out fromTypeLib))
          return fromTypeLib;
      }
      ComTypeLibDesc typeLibDesc = new ComTypeLibDesc()
      {
        Name = ComRuntimeHelpers.GetNameOfLib(typeLib),
        _typeLibAttributes = typeAttrForTypeLib
      };
      int typeInfoCount = typeLib.GetTypeInfoCount();
      for (int index = 0; index < typeInfoCount; ++index)
      {
        TYPEKIND pTKind;
        typeLib.GetTypeInfoType(index, out pTKind);
        ITypeInfo ppTI1;
        typeLib.GetTypeInfo(index, out ppTI1);
        switch (pTKind)
        {
          case TYPEKIND.TKIND_ENUM:
            ComTypeEnumDesc comTypeEnumDesc1 = new ComTypeEnumDesc(ppTI1, typeLibDesc);
            typeLibDesc._enums.Add(comTypeEnumDesc1.TypeName, comTypeEnumDesc1);
            break;
          case TYPEKIND.TKIND_COCLASS:
            ComTypeClassDesc comTypeClassDesc = new ComTypeClassDesc(ppTI1, typeLibDesc);
            typeLibDesc._classes.AddLast(comTypeClassDesc);
            break;
          case TYPEKIND.TKIND_ALIAS:
            TYPEATTR typeAttrForTypeInfo = ComRuntimeHelpers.GetTypeAttrForTypeInfo(ppTI1);
            if (typeAttrForTypeInfo.tdescAlias.vt == (short) 29)
            {
              string name;
              ComRuntimeHelpers.GetInfoFromType(ppTI1, out name, out string _);
              ITypeInfo ppTI2;
              ppTI1.GetRefTypeInfo(typeAttrForTypeInfo.tdescAlias.lpValue.ToInt32(), out ppTI2);
              if (ComRuntimeHelpers.GetTypeAttrForTypeInfo(ppTI2).typekind == TYPEKIND.TKIND_ENUM)
              {
                ComTypeEnumDesc comTypeEnumDesc2 = new ComTypeEnumDesc(ppTI2, typeLibDesc);
                typeLibDesc._enums.Add(name, comTypeEnumDesc2);
                break;
              }
              break;
            }
            break;
        }
      }
      lock (ComTypeLibDesc.s_cachedTypeLibDesc)
        ComTypeLibDesc.s_cachedTypeLibDesc.Add(typeAttrForTypeLib.guid, typeLibDesc);
      return typeLibDesc;
    }

    public object GetTypeLibObjectDesc(string member)
    {
      foreach (ComTypeClassDesc typeLibObjectDesc in this._classes)
      {
        if (member == typeLibObjectDesc.TypeName)
          return (object) typeLibObjectDesc;
      }
      ComTypeEnumDesc comTypeEnumDesc;
      return this._enums != null && this._enums.TryGetValue(member, out comTypeEnumDesc) ? (object) comTypeEnumDesc : (object) null;
    }

    public string[] GetMemberNames()
    {
      string[] memberNames = new string[this._enums.Count + this._classes.Count];
      int num = 0;
      foreach (ComTypeClassDesc comTypeClassDesc in this._classes)
        memberNames[num++] = comTypeClassDesc.TypeName;
      foreach (KeyValuePair<string, ComTypeEnumDesc> keyValuePair in this._enums)
        memberNames[num++] = keyValuePair.Key;
      return memberNames;
    }

    internal bool HasMember(string member)
    {
      foreach (ComTypeClassDesc comTypeClassDesc in this._classes)
      {
        if (member == comTypeClassDesc.TypeName)
          return true;
      }
      return this._enums.ContainsKey(member);
    }

    public Guid Guid => this._typeLibAttributes.guid;

    public string Name { get; private set; }

    internal ComTypeClassDesc GetCoClassForInterface(string itfName)
    {
      foreach (ComTypeClassDesc classForInterface in this._classes)
      {
        if (classForInterface.Implements(itfName, false))
          return classForInterface;
      }
      return (ComTypeClassDesc) null;
    }
  }
}
