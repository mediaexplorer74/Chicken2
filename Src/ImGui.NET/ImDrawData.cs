// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawData
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawData
  {
    public byte Valid;
    public int CmdListsCount;
    public int TotalIdxCount;
    public int TotalVtxCount;
    public unsafe ImDrawList** CmdLists;
    public Vector2 DisplayPos;
    public Vector2 DisplaySize;
    public Vector2 FramebufferScale;
    public unsafe ImGuiViewport* OwnerViewport;
  }
}
