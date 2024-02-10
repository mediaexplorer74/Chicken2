// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTabItemFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiTabItemFlags
  {
    None = 0,
    UnsavedDocument = 1,
    SetSelected = 2,
    NoCloseWithMiddleMouseButton = 4,
    NoPushId = 8,
    NoTooltip = 16, // 0x00000010
    NoReorder = 32, // 0x00000020
    Leading = 64, // 0x00000040
    Trailing = 128, // 0x00000080
  }
}
