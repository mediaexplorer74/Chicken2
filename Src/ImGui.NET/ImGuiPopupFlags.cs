// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiPopupFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiPopupFlags
  {
    None = 0,
    MouseButtonLeft = 0,
    MouseButtonRight = 1,
    MouseButtonMiddle = 2,
    MouseButtonMask = 31, // 0x0000001F
    MouseButtonDefault = MouseButtonRight, // 0x00000001
    NoOpenOverExistingPopup = 32, // 0x00000020
    NoOpenOverItems = 64, // 0x00000040
    AnyPopupId = 128, // 0x00000080
    AnyPopupLevel = 256, // 0x00000100
    AnyPopup = AnyPopupLevel | AnyPopupId, // 0x00000180
  }
}
