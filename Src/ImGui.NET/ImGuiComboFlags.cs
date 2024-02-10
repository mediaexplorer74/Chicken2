// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiComboFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiComboFlags
  {
    None = 0,
    PopupAlignLeft = 1,
    HeightSmall = 2,
    HeightRegular = 4,
    HeightLarge = 8,
    HeightLargest = 16, // 0x00000010
    NoArrowButton = 32, // 0x00000020
    NoPreview = 64, // 0x00000040
    HeightMask = HeightLargest | HeightLarge | HeightRegular | HeightSmall, // 0x0000001E
  }
}
