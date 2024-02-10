// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawCmd
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawCmd
  {
    public Vector4 ClipRect;
    public IntPtr TextureId;
    public uint VtxOffset;
    public uint IdxOffset;
    public uint ElemCount;
    public IntPtr UserCallback;
    public unsafe void* UserCallbackData;
  }
}
