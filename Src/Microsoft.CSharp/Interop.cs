// Decompiled with JetBrains decompiler
// Type: Interop
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Runtime.InteropServices;

#nullable disable
internal static class Interop
{
  internal static class OleAut32
  {
    [DllImport("oleaut32.dll")]
    internal static extern void VariantClear(IntPtr variant);
  }
}
