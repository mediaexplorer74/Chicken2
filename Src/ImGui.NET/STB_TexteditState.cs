// Decompiled with JetBrains decompiler
// Type: ImGuiNET.STB_TexteditState
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

#nullable disable
namespace ImGuiNET
{
  public struct STB_TexteditState
  {
    public int cursor;
    public int select_start;
    public int select_end;
    public byte insert_mode;
    public int row_count_per_page;
    public byte cursor_at_end_of_line;
    public byte initialized;
    public byte has_preferred_x;
    public byte single_line;
    public byte padding1;
    public byte padding2;
    public byte padding3;
    public float preferred_x;
    public StbUndoState undostate;
  }
}
