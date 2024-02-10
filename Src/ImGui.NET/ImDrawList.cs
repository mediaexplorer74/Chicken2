// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawList
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawList
  {
    public ImVector CmdBuffer;
    public ImVector IdxBuffer;
    public ImVector VtxBuffer;
    public ImDrawListFlags Flags;
    public uint _VtxCurrentIdx;
    public IntPtr _Data;
    public unsafe byte* _OwnerName;
    public unsafe ImDrawVert* _VtxWritePtr;
    public unsafe ushort* _IdxWritePtr;
    public ImVector _ClipRectStack;
    public ImVector _TextureIdStack;
    public ImVector _Path;
    public ImDrawCmdHeader _CmdHeader;
    public ImDrawListSplitter _Splitter;
    public float _FringeScale;
  }
}
