// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiDragDropFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiDragDropFlags
  {
    None = 0,
    SourceNoPreviewTooltip = 1,
    SourceNoDisableHover = 2,
    SourceNoHoldToOpenOthers = 4,
    SourceAllowNullID = 8,
    SourceExtern = 16, // 0x00000010
    SourceAutoExpirePayload = 32, // 0x00000020
    AcceptBeforeDelivery = 1024, // 0x00000400
    AcceptNoDrawDefaultRect = 2048, // 0x00000800
    AcceptNoPreviewTooltip = 4096, // 0x00001000
    AcceptPeekOnly = AcceptNoDrawDefaultRect | AcceptBeforeDelivery, // 0x00000C00
  }
}
