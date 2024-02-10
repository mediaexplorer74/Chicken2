// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiButtonFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiButtonFlags
  {
    None = 0,
    MouseButtonLeft = 1,
    MouseButtonRight = 2,
    MouseButtonMiddle = 4,
    MouseButtonMask = MouseButtonMiddle | MouseButtonRight | MouseButtonLeft, // 0x00000007
    MouseButtonDefault = MouseButtonLeft, // 0x00000001
  }
}
