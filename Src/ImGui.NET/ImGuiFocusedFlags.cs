// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiFocusedFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiFocusedFlags
  {
    None = 0,
    ChildWindows = 1,
    RootWindow = 2,
    AnyWindow = 4,
    NoPopupHierarchy = 8,
    DockHierarchy = 16, // 0x00000010
    RootAndChildWindows = RootWindow | ChildWindows, // 0x00000003
  }
}
