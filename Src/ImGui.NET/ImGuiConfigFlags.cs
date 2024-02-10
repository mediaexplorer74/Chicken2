// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiConfigFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiConfigFlags
  {
    None = 0,
    NavEnableKeyboard = 1,
    NavEnableGamepad = 2,
    NavEnableSetMousePos = 4,
    NavNoCaptureKeyboard = 8,
    NoMouse = 16, // 0x00000010
    NoMouseCursorChange = 32, // 0x00000020
    DockingEnable = 64, // 0x00000040
    ViewportsEnable = 1024, // 0x00000400
    DpiEnableScaleViewports = 16384, // 0x00004000
    DpiEnableScaleFonts = 32768, // 0x00008000
    IsSRGB = 1048576, // 0x00100000
    IsTouchScreen = 2097152, // 0x00200000
  }
}
