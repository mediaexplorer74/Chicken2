// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComTypeClassDesc
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
  internal sealed class ComTypeClassDesc : ComTypeDesc, IDynamicMetaObjectProvider
  {
    private LinkedList<string> _itfs;
    private LinkedList<string> _sourceItfs;
    private Type _typeObj;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public object CreateInstance()
    {
      if (this._typeObj == (Type) null)
        this._typeObj = Type.GetTypeFromCLSID(this.Guid);
      return Activator.CreateInstance(Type.GetTypeFromCLSID(this.Guid));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal ComTypeClassDesc(ITypeInfo typeInfo, ComTypeLibDesc typeLibDesc)
      : base(typeInfo, typeLibDesc)
    {
      TYPEATTR typeAttrForTypeInfo = ComRuntimeHelpers.GetTypeAttrForTypeInfo(typeInfo);
      this.Guid = typeAttrForTypeInfo.guid;
      for (int index = 0; index < (int) typeAttrForTypeInfo.cImplTypes; ++index)
      {
        int href;
        typeInfo.GetRefTypeOfImplType(index, out href);
        ITypeInfo ppTI;
        typeInfo.GetRefTypeInfo(href, out ppTI);
        IMPLTYPEFLAGS pImplTypeFlags;
        typeInfo.GetImplTypeFlags(index, out pImplTypeFlags);
        bool isSourceItf = (pImplTypeFlags & IMPLTYPEFLAGS.IMPLTYPEFLAG_FSOURCE) != 0;
        this.AddInterface(ppTI, isSourceItf);
      }
    }

    private void AddInterface(ITypeInfo itfTypeInfo, bool isSourceItf)
    {
      string nameOfType = ComRuntimeHelpers.GetNameOfType(itfTypeInfo);
      if (isSourceItf)
      {
        if (this._sourceItfs == null)
          this._sourceItfs = new LinkedList<string>();
        this._sourceItfs.AddLast(nameOfType);
      }
      else
      {
        if (this._itfs == null)
          this._itfs = new LinkedList<string>();
        this._itfs.AddLast(nameOfType);
      }
    }

    internal bool Implements(string itfName, bool isSourceItf)
    {
      return isSourceItf ? this._sourceItfs.Contains(itfName) : this._itfs.Contains(itfName);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public DynamicMetaObject GetMetaObject(Expression parameter)
    {
      return (DynamicMetaObject) new ComClassMetaObject(parameter, this);
    }
  }
}
