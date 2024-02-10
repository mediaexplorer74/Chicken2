// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTextFilter
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiTextFilter
  {
    public unsafe fixed byte InputBuf[256];
    public ImVector Filters;
    public int CountGrep;
  }
}
