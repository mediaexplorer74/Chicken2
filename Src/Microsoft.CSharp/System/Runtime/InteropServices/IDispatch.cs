// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.IDispatch
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace System.Runtime.InteropServices
{
  [Guid("00020400-0000-0000-C000-000000000046")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  internal interface IDispatch
  {
    int GetTypeInfoCount();

    ITypeInfo GetTypeInfo(int iTInfo, int lcid);

    void GetIDsOfNames(ref Guid riid, [MarshalAs((UnmanagedType) 42, SizeParamIndex = 2, ArraySubType = (UnmanagedType) 21), In] string[] rgszNames, int cNames, int lcid, [Out] int[] rgDispId);

    void Invoke(
      int dispIdMember,
      ref Guid riid,
      int lcid,
      InvokeFlags wFlags,
      ref DISPPARAMS pDispParams,
      IntPtr pVarResult,
      IntPtr pExcepInfo,
      IntPtr puArgErr);
  }
}
