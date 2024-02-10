// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiViewportFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiViewportFlags
  {
    None = 0,
    IsPlatformWindow = 1,
    IsPlatformMonitor = 2,
    OwnedByApp = 4,
    NoDecoration = 8,
    NoTaskBarIcon = 16, // 0x00000010
    NoFocusOnAppearing = 32, // 0x00000020
    NoFocusOnClick = 64, // 0x00000040
    NoInputs = 128, // 0x00000080
    NoRendererClear = 256, // 0x00000100
    TopMost = 512, // 0x00000200
    Minimized = 1024, // 0x00000400
    NoAutoMerge = 2048, // 0x00000800
    CanHostOtherWindows = 4096, // 0x00001000
  }
}
