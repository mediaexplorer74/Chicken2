// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTreeNodeFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiTreeNodeFlags
  {
    None = 0,
    Selected = 1,
    Framed = 2,
    AllowItemOverlap = 4,
    NoTreePushOnOpen = 8,
    NoAutoOpenOnLog = 16, // 0x00000010
    DefaultOpen = 32, // 0x00000020
    OpenOnDoubleClick = 64, // 0x00000040
    OpenOnArrow = 128, // 0x00000080
    Leaf = 256, // 0x00000100
    Bullet = 512, // 0x00000200
    FramePadding = 1024, // 0x00000400
    SpanAvailWidth = 2048, // 0x00000800
    SpanFullWidth = 4096, // 0x00001000
    NavLeftJumpsBackHere = 8192, // 0x00002000
    CollapsingHeader = NoAutoOpenOnLog | NoTreePushOnOpen | Framed, // 0x0000001A
  }
}
