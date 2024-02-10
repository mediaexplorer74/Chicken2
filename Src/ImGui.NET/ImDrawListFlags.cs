// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawListFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImDrawListFlags
  {
    None = 0,
    AntiAliasedLines = 1,
    AntiAliasedLinesUseTex = 2,
    AntiAliasedFill = 4,
    AllowVtxOffset = 8,
  }
}
