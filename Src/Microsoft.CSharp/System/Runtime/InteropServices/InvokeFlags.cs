// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.InvokeFlags
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace System.Runtime.InteropServices
{
  [Flags]
  internal enum InvokeFlags : short
  {
    DISPATCH_METHOD = 1,
    DISPATCH_PROPERTYGET = 2,
    DISPATCH_PROPERTYPUT = 4,
    DISPATCH_PROPERTYPUTREF = 8,
  }
}
