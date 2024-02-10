// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComTypeEnumDesc
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ComTypeEnumDesc : ComTypeDesc, IDynamicMetaObjectProvider
  {
    private readonly string[] _memberNames;
    private readonly object[] _memberValues;

    public override string ToString() => "<enum '" + this.TypeName + "'>";

    internal ComTypeEnumDesc(ITypeInfo typeInfo, ComTypeLibDesc typeLibDesc)
      : base(typeInfo, typeLibDesc)
    {
      TYPEATTR typeAttrForTypeInfo = ComRuntimeHelpers.GetTypeAttrForTypeInfo(typeInfo);
      string[] strArray = new string[(int) typeAttrForTypeInfo.cVars];
      object[] objArray = new object[(int) typeAttrForTypeInfo.cVars];
      for (int index = 0; index < (int) typeAttrForTypeInfo.cVars; ++index)
      {
        IntPtr ppVarDesc;
        typeInfo.GetVarDesc(index, out ppVarDesc);
        VARDESC structure;
        try
        {
          structure = (VARDESC) Marshal.PtrToStructure(ppVarDesc, typeof (VARDESC));
          if (structure.varkind == VARKIND.VAR_CONST)
            objArray[index] = Marshal.GetObjectForNativeVariant(structure.desc.lpvarValue);
        }
        finally
        {
          typeInfo.ReleaseVarDesc(ppVarDesc);
        }
        strArray[index] = ComRuntimeHelpers.GetNameOfMethod(typeInfo, structure.memid);
      }
      this._memberNames = strArray;
      this._memberValues = objArray;
    }

    DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
    {
      return (DynamicMetaObject) new TypeEnumMetaObject(this, parameter);
    }

    public object GetValue(string enumValueName)
    {
      for (int index = 0; index < this._memberNames.Length; ++index)
      {
        if (this._memberNames[index] == enumValueName)
          return this._memberValues[index];
      }
      throw new MissingMemberException(enumValueName);
    }

    internal bool HasMember(string name)
    {
      for (int index = 0; index < this._memberNames.Length; ++index)
      {
        if (this._memberNames[index] == name)
          return true;
      }
      return false;
    }

    public string[] GetMemberNames() => (string[]) this._memberNames.Clone();
  }
}
