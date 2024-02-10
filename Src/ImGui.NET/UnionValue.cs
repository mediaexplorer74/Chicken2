// Decompiled with JetBrains decompiler
// Type: ImGuiNET.UnionValue
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace ImGuiNET
{
  [StructLayout(LayoutKind.Explicit)]
  public struct UnionValue
  {
    [FieldOffset(0)]
    public int ValueI32;
    [FieldOffset(0)]
    public float ValueF32;
    [FieldOffset(0)]
    public IntPtr ValuePtr;
  }
}
