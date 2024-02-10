// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImDrawFlags
  {
    None = 0,
    Closed = 1,
    RoundCornersTopLeft = 16, // 0x00000010
    RoundCornersTopRight = 32, // 0x00000020
    RoundCornersBottomLeft = 64, // 0x00000040
    RoundCornersBottomRight = 128, // 0x00000080
    RoundCornersNone = 256, // 0x00000100
    RoundCornersTop = RoundCornersTopRight | RoundCornersTopLeft, // 0x00000030
    RoundCornersBottom = RoundCornersBottomRight | RoundCornersBottomLeft, // 0x000000C0
    RoundCornersLeft = RoundCornersBottomLeft | RoundCornersTopLeft, // 0x00000050
    RoundCornersRight = RoundCornersBottomRight | RoundCornersTopRight, // 0x000000A0
    RoundCornersAll = RoundCornersRight | RoundCornersLeft, // 0x000000F0
    RoundCornersDefault = RoundCornersAll, // 0x000000F0
    RoundCornersMask = RoundCornersDefault | RoundCornersNone, // 0x000001F0
  }
}
