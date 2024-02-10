// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComRuntimeHelpers
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class ComRuntimeHelpers
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static void CheckThrowException(
      int hresult,
      ref ExcepInfo excepInfo,
      uint argErr,
      string message)
    {
      if (ComHresults.IsSuccess(hresult))
        return;
      switch (hresult)
      {
        case -2147352573:
          throw Error.DispMemberNotFound((object) message);
        case -2147352571:
          throw Error.DispTypeMismatch((object) argErr, (object) message);
        case -2147352569:
          throw Error.DispNoNamedArgs((object) message);
        case -2147352567:
          throw excepInfo.GetException();
        case -2147352566:
          throw Error.DispOverflow((object) message);
        case -2147352562:
          throw Error.DispBadParamCount((object) message);
        case -2147352561:
          throw Error.DispParamNotOptional((object) message);
        default:
          Marshal.ThrowExceptionForHR(hresult);
          break;
      }
    }

    internal static void GetInfoFromType(
      ITypeInfo typeInfo,
      out string name,
      out string documentation)
    {
      typeInfo.GetDocumentation(-1, out name, out documentation, out int _, out string _);
    }

    internal static string GetNameOfMethod(ITypeInfo typeInfo, int memid)
    {
      string[] rgBstrNames = new string[1];
      typeInfo.GetNames(memid, rgBstrNames, 1, out int _);
      return rgBstrNames[0];
    }

    internal static string GetNameOfLib(ITypeLib typeLib)
    {
      string strName;
      typeLib.GetDocumentation(-1, out strName, out string _, out int _, out string _);
      return strName;
    }

    internal static string GetNameOfType(ITypeInfo typeInfo)
    {
      string name;
      ComRuntimeHelpers.GetInfoFromType(typeInfo, out name, out string _);
      return name;
    }

    internal static ITypeInfo GetITypeInfoFromIDispatch(IDispatch dispatch)
    {
      uint pctinfo;
      int typeInfoCount = dispatch.TryGetTypeInfoCount(out pctinfo);
      if (pctinfo == 0U)
        return (ITypeInfo) null;
      Marshal.ThrowExceptionForHR(typeInfoCount);
      IntPtr info;
      int typeInfo = dispatch.TryGetTypeInfo(0U, 0, out info);
      if (!ComHresults.IsSuccess(typeInfo))
      {
        if (typeInfo == -2147467262)
          return (ITypeInfo) null;
        Marshal.ThrowExceptionForHR(typeInfo);
      }
      if (info == IntPtr.Zero)
        Marshal.ThrowExceptionForHR(-2147467259);
      try
      {
        return Marshal.GetObjectForIUnknown(info) as ITypeInfo;
      }
      finally
      {
        Marshal.Release(info);
      }
    }

    internal static TYPEATTR GetTypeAttrForTypeInfo(ITypeInfo typeInfo)
    {
      IntPtr ppTypeAttr;
      typeInfo.GetTypeAttr(out ppTypeAttr);
      if (ppTypeAttr == IntPtr.Zero)
        throw Error.CannotRetrieveTypeInformation();
      try
      {
        return (TYPEATTR) Marshal.PtrToStructure(ppTypeAttr, typeof (TYPEATTR));
      }
      finally
      {
        typeInfo.ReleaseTypeAttr(ppTypeAttr);
      }
    }

    internal static TYPELIBATTR GetTypeAttrForTypeLib(ITypeLib typeLib)
    {
      IntPtr ppTLibAttr;
      typeLib.GetLibAttr(out ppTLibAttr);
      if (ppTLibAttr == IntPtr.Zero)
        throw Error.CannotRetrieveTypeInformation();
      try
      {
        return (TYPELIBATTR) Marshal.PtrToStructure(ppTLibAttr, typeof (TYPELIBATTR));
      }
      finally
      {
        typeLib.ReleaseTLibAttr(ppTLibAttr);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static BoundDispEvent CreateComEvent(object rcw, Guid sourceIid, int dispid)
    {
      return new BoundDispEvent(rcw, sourceIid, dispid);
    }

    public static DispCallable CreateDispCallable(IDispatchComObject dispatch, ComMethodDesc method)
    {
      return new DispCallable(dispatch, method.Name, method.DispId);
    }
  }
}
