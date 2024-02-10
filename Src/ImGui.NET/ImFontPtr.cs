// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontPtr
  {
    public unsafe ImFont* NativePtr { get; }

    public unsafe ImFontPtr(ImFont* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImFontPtr(IntPtr nativePtr) => this.NativePtr = (ImFont*) (void*) nativePtr;

    public static unsafe implicit operator ImFontPtr(ImFont* nativePtr) => new ImFontPtr(nativePtr);

    public static unsafe implicit operator ImFont*(ImFontPtr wrappedPtr) => wrappedPtr.NativePtr;

    public static implicit operator ImFontPtr(IntPtr nativePtr) => new ImFontPtr(nativePtr);

    public unsafe ImVector<float> IndexAdvanceX
    {
      get => new ImVector<float>(this.NativePtr->IndexAdvanceX);
    }

    public unsafe ref float FallbackAdvanceX
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->FallbackAdvanceX);
    }

    public unsafe ref float FontSize => ref Unsafe.AsRef<float>((void*) &this.NativePtr->FontSize);

    public unsafe ImVector<ushort> IndexLookup => new ImVector<ushort>(this.NativePtr->IndexLookup);

    public unsafe ImPtrVector<ImFontGlyphPtr> Glyphs
    {
      get => new ImPtrVector<ImFontGlyphPtr>(this.NativePtr->Glyphs, Unsafe.SizeOf<ImFontGlyph>());
    }

    public unsafe ImFontGlyphPtr FallbackGlyph => new ImFontGlyphPtr(this.NativePtr->FallbackGlyph);

    public unsafe ImFontAtlasPtr ContainerAtlas
    {
      get => new ImFontAtlasPtr(this.NativePtr->ContainerAtlas);
    }

    public unsafe ImFontConfigPtr ConfigData => new ImFontConfigPtr(this.NativePtr->ConfigData);

    public unsafe ref short ConfigDataCount
    {
      get => ref Unsafe.AsRef<short>((void*) &this.NativePtr->ConfigDataCount);
    }

    public unsafe ref ushort FallbackChar
    {
      get => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->FallbackChar);
    }

    public unsafe ref ushort EllipsisChar
    {
      get => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->EllipsisChar);
    }

    public unsafe ref ushort DotChar => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->DotChar);

    public unsafe ref bool DirtyLookupTables
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->DirtyLookupTables);
    }

    public unsafe ref float Scale => ref Unsafe.AsRef<float>((void*) &this.NativePtr->Scale);

    public unsafe ref float Ascent => ref Unsafe.AsRef<float>((void*) &this.NativePtr->Ascent);

    public unsafe ref float Descent => ref Unsafe.AsRef<float>((void*) &this.NativePtr->Descent);

    public unsafe ref int MetricsTotalSurface
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->MetricsTotalSurface);
    }

    public unsafe RangeAccessor<byte> Used4kPagesMap
    {
      get => new RangeAccessor<byte>((void*) this.NativePtr->Used4kPagesMap, 2);
    }

    public unsafe void AddGlyph(
      ImFontConfigPtr src_cfg,
      ushort c,
      float x0,
      float y0,
      float x1,
      float y1,
      float u0,
      float v0,
      float u1,
      float v1,
      float advance_x)
    {
      ImGuiNative.ImFont_AddGlyph(this.NativePtr, src_cfg.NativePtr, c, x0, y0, x1, y1, u0, v0, u1, v1, advance_x);
    }

    public unsafe void AddRemapChar(ushort dst, ushort src)
    {
      byte overwrite_dst = 1;
      ImGuiNative.ImFont_AddRemapChar(this.NativePtr, dst, src, overwrite_dst);
    }

    public unsafe void AddRemapChar(ushort dst, ushort src, bool overwrite_dst)
    {
      byte overwrite_dst1 = overwrite_dst ? (byte) 1 : (byte) 0;
      ImGuiNative.ImFont_AddRemapChar(this.NativePtr, dst, src, overwrite_dst1);
    }

    public unsafe void BuildLookupTable() => ImGuiNative.ImFont_BuildLookupTable(this.NativePtr);

    public unsafe void ClearOutputData() => ImGuiNative.ImFont_ClearOutputData(this.NativePtr);

    public unsafe void Destroy() => ImGuiNative.ImFont_destroy(this.NativePtr);

    public unsafe ImFontGlyphPtr FindGlyph(ushort c)
    {
      return new ImFontGlyphPtr(ImGuiNative.ImFont_FindGlyph(this.NativePtr, c));
    }

    public unsafe ImFontGlyphPtr FindGlyphNoFallback(ushort c)
    {
      return new ImFontGlyphPtr(ImGuiNative.ImFont_FindGlyphNoFallback(this.NativePtr, c));
    }

    public unsafe float GetCharAdvance(ushort c)
    {
      return ImGuiNative.ImFont_GetCharAdvance(this.NativePtr, c);
    }

    public unsafe string GetDebugName()
    {
      return Util.StringFromPtr(ImGuiNative.ImFont_GetDebugName(this.NativePtr));
    }

    public unsafe void GrowIndex(int new_size)
    {
      ImGuiNative.ImFont_GrowIndex(this.NativePtr, new_size);
    }

    public unsafe bool IsLoaded() => ImGuiNative.ImFont_IsLoaded(this.NativePtr) > (byte) 0;

    public unsafe void RenderChar(
      ImDrawListPtr draw_list,
      float size,
      Vector2 pos,
      uint col,
      ushort c)
    {
      ImGuiNative.ImFont_RenderChar(this.NativePtr, draw_list.NativePtr, size, pos, col, c);
    }

    public unsafe void SetGlyphVisible(ushort c, bool visible)
    {
      byte visible1 = visible ? (byte) 1 : (byte) 0;
      ImGuiNative.ImFont_SetGlyphVisible(this.NativePtr, c, visible1);
    }
  }
}
