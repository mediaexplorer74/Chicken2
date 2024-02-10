// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.IDispatch
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("00020400-0000-0000-C000-000000000046")]
  [ComImport]
  internal interface IDispatch
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int TryGetTypeInfoCount(out uint pctinfo);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int TryGetTypeInfo(uint iTInfo, int lcid, out IntPtr info);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int TryGetIDsOfNames(ref Guid iid, [MarshalAs((UnmanagedType) 42, SizeParamIndex = 2, ArraySubType = (UnmanagedType) 21)] string[] names, uint cNames, int lcid, [MarshalAs((UnmanagedType) 42, SizeParamIndex = 2, ArraySubType = (UnmanagedType) 7), Out] int[] rgDispId);
  }
}
