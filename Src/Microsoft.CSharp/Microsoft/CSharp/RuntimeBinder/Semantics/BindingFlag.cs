// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.BindingFlag
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  [Flags]
  internal enum BindingFlag
  {
    BIND_RVALUEREQUIRED = 1,
    BIND_MEMBERSET = 2,
    BIND_FIXEDVALUE = 16, // 0x00000010
    BIND_ARGUMENTS = 32, // 0x00000020
    BIND_BASECALL = 64, // 0x00000040
    BIND_USINGVALUE = 128, // 0x00000080
    BIND_STMTEXPRONLY = 256, // 0x00000100
    BIND_TYPEOK = 512, // 0x00000200
    BIND_MAYBECONFUSEDNEGATIVECAST = 1024, // 0x00000400
    BIND_METHODNOTOK = 2048, // 0x00000800
    BIND_DECLNOTOK = 4096, // 0x00001000
    BIND_NOPARAMS = 8192, // 0x00002000
    BIND_SPECULATIVELY = 16384, // 0x00004000
  }
}
