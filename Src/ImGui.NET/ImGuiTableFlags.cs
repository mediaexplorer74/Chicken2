// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTableFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiTableFlags
  {
    None = 0,
    Resizable = 1,
    Reorderable = 2,
    Hideable = 4,
    Sortable = 8,
    NoSavedSettings = 16, // 0x00000010
    ContextMenuInBody = 32, // 0x00000020
    RowBg = 64, // 0x00000040
    BordersInnerH = 128, // 0x00000080
    BordersOuterH = 256, // 0x00000100
    BordersInnerV = 512, // 0x00000200
    BordersOuterV = 1024, // 0x00000400
    BordersH = BordersOuterH | BordersInnerH, // 0x00000180
    BordersV = BordersOuterV | BordersInnerV, // 0x00000600
    BordersInner = BordersInnerV | BordersInnerH, // 0x00000280
    BordersOuter = BordersOuterV | BordersOuterH, // 0x00000500
    Borders = BordersOuter | BordersInner, // 0x00000780
    NoBordersInBody = 2048, // 0x00000800
    NoBordersInBodyUntilResize = 4096, // 0x00001000
    SizingFixedFit = 8192, // 0x00002000
    SizingFixedSame = 16384, // 0x00004000
    SizingStretchProp = SizingFixedSame | SizingFixedFit, // 0x00006000
    SizingStretchSame = 32768, // 0x00008000
    NoHostExtendX = 65536, // 0x00010000
    NoHostExtendY = 131072, // 0x00020000
    NoKeepColumnsVisible = 262144, // 0x00040000
    PreciseWidths = 524288, // 0x00080000
    NoClip = 1048576, // 0x00100000
    PadOuterX = 2097152, // 0x00200000
    NoPadOuterX = 4194304, // 0x00400000
    NoPadInnerX = 8388608, // 0x00800000
    ScrollX = 16777216, // 0x01000000
    ScrollY = 33554432, // 0x02000000
    SortMulti = 67108864, // 0x04000000
    SortTristate = 134217728, // 0x08000000
    SizingMask = SizingStretchSame | SizingStretchProp, // 0x0000E000
  }
}
