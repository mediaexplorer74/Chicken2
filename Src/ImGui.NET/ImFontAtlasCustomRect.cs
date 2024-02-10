// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontAtlasCustomRect
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontAtlasCustomRect
  {
    public ushort Width;
    public ushort Height;
    public ushort X;
    public ushort Y;
    public uint GlyphID;
    public float GlyphAdvanceX;
    public Vector2 GlyphOffset;
    public unsafe ImFont* Font;
  }
}
