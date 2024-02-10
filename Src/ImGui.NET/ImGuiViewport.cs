// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiViewport
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiViewport
  {
    public uint ID;
    public ImGuiViewportFlags Flags;
    public Vector2 Pos;
    public Vector2 Size;
    public Vector2 WorkPos;
    public Vector2 WorkSize;
    public float DpiScale;
    public uint ParentViewportId;
    public unsafe ImDrawData* DrawData;
    public unsafe void* RendererUserData;
    public unsafe void* PlatformUserData;
    public unsafe void* PlatformHandle;
    public unsafe void* PlatformHandleRaw;
    public byte PlatformRequestMove;
    public byte PlatformRequestResize;
    public byte PlatformRequestClose;
  }
}
