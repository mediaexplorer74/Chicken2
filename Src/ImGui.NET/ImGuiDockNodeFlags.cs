// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiDockNodeFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiDockNodeFlags
  {
    None = 0,
    KeepAliveOnly = 1,
    NoDockingInCentralNode = 4,
    PassthruCentralNode = 8,
    NoSplit = 16, // 0x00000010
    NoResize = 32, // 0x00000020
    AutoHideTabBar = 64, // 0x00000040
  }
}
