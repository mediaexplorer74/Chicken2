// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiHoveredFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiHoveredFlags
  {
    None = 0,
    ChildWindows = 1,
    RootWindow = 2,
    AnyWindow = 4,
    NoPopupHierarchy = 8,
    DockHierarchy = 16, // 0x00000010
    AllowWhenBlockedByPopup = 32, // 0x00000020
    AllowWhenBlockedByActiveItem = 128, // 0x00000080
    AllowWhenOverlapped = 256, // 0x00000100
    AllowWhenDisabled = 512, // 0x00000200
    NoNavOverride = 1024, // 0x00000400
    RectOnly = AllowWhenOverlapped | AllowWhenBlockedByActiveItem | AllowWhenBlockedByPopup, // 0x000001A0
    RootAndChildWindows = RootWindow | ChildWindows, // 0x00000003
  }
}
