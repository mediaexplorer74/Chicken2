// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontConfig
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontConfig
  {
    public unsafe void* FontData;
    public int FontDataSize;
    public byte FontDataOwnedByAtlas;
    public int FontNo;
    public float SizePixels;
    public int OversampleH;
    public int OversampleV;
    public byte PixelSnapH;
    public Vector2 GlyphExtraSpacing;
    public Vector2 GlyphOffset;
    public unsafe ushort* GlyphRanges;
    public float GlyphMinAdvanceX;
    public float GlyphMaxAdvanceX;
    public byte MergeMode;
    public uint FontBuilderFlags;
    public float RasterizerMultiply;
    public ushort EllipsisChar;
    public unsafe fixed byte Name[40];
    public unsafe ImFont* DstFont;
  }
}
