// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFont
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

#nullable disable
namespace ImGuiNET
{
  public struct ImFont
  {
    public ImVector IndexAdvanceX;
    public float FallbackAdvanceX;
    public float FontSize;
    public ImVector IndexLookup;
    public ImVector Glyphs;
    public unsafe ImFontGlyph* FallbackGlyph;
    public unsafe ImFontAtlas* ContainerAtlas;
    public unsafe ImFontConfig* ConfigData;
    public short ConfigDataCount;
    public ushort FallbackChar;
    public ushort EllipsisChar;
    public ushort DotChar;
    public byte DirtyLookupTables;
    public float Scale;
    public float Ascent;
    public float Descent;
    public int MetricsTotalSurface;
    public unsafe fixed byte Used4kPagesMap[2];
  }
}
