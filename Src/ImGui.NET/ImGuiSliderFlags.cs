// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiSliderFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiSliderFlags
  {
    None = 0,
    AlwaysClamp = 16, // 0x00000010
    Logarithmic = 32, // 0x00000020
    NoRoundToFormat = 64, // 0x00000040
    NoInput = 128, // 0x00000080
    InvalidMask = 1879048207, // 0x7000000F
  }
}
