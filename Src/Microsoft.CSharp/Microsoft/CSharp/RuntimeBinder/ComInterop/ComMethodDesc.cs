// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComMethodDesc
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ComMethodDesc
  {
    private readonly INVOKEKIND _invokeKind;

    private ComMethodDesc(int dispId) => this.DispId = dispId;

    internal ComMethodDesc(string name, int dispId)
      : this(dispId)
    {
      this.Name = name;
    }

    internal ComMethodDesc(string name, int dispId, INVOKEKIND invkind)
      : this(name, dispId)
    {
      this._invokeKind = invkind;
    }

    internal ComMethodDesc(ITypeInfo typeInfo, FUNCDESC funcDesc)
      : this(funcDesc.memid)
    {
      this._invokeKind = funcDesc.invkind;
      string[] rgBstrNames = new string[1 + (int) funcDesc.cParams];
      int pcNames;
      typeInfo.GetNames(this.DispId, rgBstrNames, rgBstrNames.Length, out pcNames);
      if (this.IsPropertyPut && rgBstrNames[rgBstrNames.Length - 1] == null)
      {
        rgBstrNames[rgBstrNames.Length - 1] = "value";
        int num = pcNames + 1;
      }
      this.Name = rgBstrNames[0];
      this.ParamCount = (int) funcDesc.cParams;
    }

    public string Name { get; }

    public int DispId { get; }

    public bool IsPropertyGet => (this._invokeKind & INVOKEKIND.INVOKE_PROPERTYGET) != 0;

    public bool IsDataMember => this.IsPropertyGet && this.DispId != -4 && this.ParamCount == 0;

    public bool IsPropertyPut
    {
      get
      {
        return (this._invokeKind & (INVOKEKIND.INVOKE_PROPERTYPUT | INVOKEKIND.INVOKE_PROPERTYPUTREF)) != 0;
      }
    }

    public bool IsPropertyPutRef => (this._invokeKind & INVOKEKIND.INVOKE_PROPERTYPUTREF) != 0;

    internal int ParamCount { get; }
  }
}
