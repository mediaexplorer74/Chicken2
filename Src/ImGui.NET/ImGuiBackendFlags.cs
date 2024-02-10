// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiBackendFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiBackendFlags
  {
    None = 0,
    HasGamepad = 1,
    HasMouseCursors = 2,
    HasSetMousePos = 4,
    RendererHasVtxOffset = 8,
    PlatformHasViewports = 1024, // 0x00000400
    HasMouseHoveredViewport = 2048, // 0x00000800
    RendererHasViewports = 4096, // 0x00001000
  }
}
