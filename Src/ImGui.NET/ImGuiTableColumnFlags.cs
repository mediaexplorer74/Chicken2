// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTableColumnFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiTableColumnFlags
  {
    None = 0,
    Disabled = 1,
    DefaultHide = 2,
    DefaultSort = 4,
    WidthStretch = 8,
    WidthFixed = 16, // 0x00000010
    NoResize = 32, // 0x00000020
    NoReorder = 64, // 0x00000040
    NoHide = 128, // 0x00000080
    NoClip = 256, // 0x00000100
    NoSort = 512, // 0x00000200
    NoSortAscending = 1024, // 0x00000400
    NoSortDescending = 2048, // 0x00000800
    NoHeaderLabel = 4096, // 0x00001000
    NoHeaderWidth = 8192, // 0x00002000
    PreferSortAscending = 16384, // 0x00004000
    PreferSortDescending = 32768, // 0x00008000
    IndentEnable = 65536, // 0x00010000
    IndentDisable = 131072, // 0x00020000
    IsEnabled = 16777216, // 0x01000000
    IsVisible = 33554432, // 0x02000000
    IsSorted = 67108864, // 0x04000000
    IsHovered = 134217728, // 0x08000000
    WidthMask = WidthFixed | WidthStretch, // 0x00000018
    IndentMask = IndentDisable | IndentEnable, // 0x00030000
    StatusMask = IsHovered | IsSorted | IsVisible | IsEnabled, // 0x0F000000
    NoDirectResize = 1073741824, // 0x40000000
  }
}
