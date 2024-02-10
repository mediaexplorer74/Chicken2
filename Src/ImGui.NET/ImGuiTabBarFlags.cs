// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTabBarFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiTabBarFlags
  {
    None = 0,
    Reorderable = 1,
    AutoSelectNewTabs = 2,
    TabListPopupButton = 4,
    NoCloseWithMiddleMouseButton = 8,
    NoTabListScrollingButtons = 16, // 0x00000010
    NoTooltip = 32, // 0x00000020
    FittingPolicyResizeDown = 64, // 0x00000040
    FittingPolicyScroll = 128, // 0x00000080
    FittingPolicyMask = FittingPolicyScroll | FittingPolicyResizeDown, // 0x000000C0
    FittingPolicyDefault = FittingPolicyResizeDown, // 0x00000040
  }
}
