// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiColorEditFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiColorEditFlags
  {
    None = 0,
    NoAlpha = 2,
    NoPicker = 4,
    NoOptions = 8,
    NoSmallPreview = 16, // 0x00000010
    NoInputs = 32, // 0x00000020
    NoTooltip = 64, // 0x00000040
    NoLabel = 128, // 0x00000080
    NoSidePreview = 256, // 0x00000100
    NoDragDrop = 512, // 0x00000200
    NoBorder = 1024, // 0x00000400
    AlphaBar = 65536, // 0x00010000
    AlphaPreview = 131072, // 0x00020000
    AlphaPreviewHalf = 262144, // 0x00040000
    HDR = 524288, // 0x00080000
    DisplayRGB = 1048576, // 0x00100000
    DisplayHSV = 2097152, // 0x00200000
    DisplayHex = 4194304, // 0x00400000
    Uint8 = 8388608, // 0x00800000
    Float = 16777216, // 0x01000000
    PickerHueBar = 33554432, // 0x02000000
    PickerHueWheel = 67108864, // 0x04000000
    InputRGB = 134217728, // 0x08000000
    InputHSV = 268435456, // 0x10000000
    DefaultOptions = InputRGB | PickerHueBar | Uint8 | DisplayRGB, // 0x0A900000
    DisplayMask = DisplayHex | DisplayHSV | DisplayRGB, // 0x00700000
    DataTypeMask = Float | Uint8, // 0x01800000
    PickerMask = PickerHueWheel | PickerHueBar, // 0x06000000
    InputMask = InputHSV | InputRGB, // 0x18000000
  }
}
