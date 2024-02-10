// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontAtlasPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontAtlasPtr
  {
    public unsafe ImFontAtlas* NativePtr { get; }

    public unsafe ImFontAtlasPtr(ImFontAtlas* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImFontAtlasPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImFontAtlas*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImFontAtlasPtr(ImFontAtlas* nativePtr)
    {
      return new ImFontAtlasPtr(nativePtr);
    }

    public static unsafe implicit operator ImFontAtlas*(ImFontAtlasPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImFontAtlasPtr(IntPtr nativePtr)
    {
      return new ImFontAtlasPtr(nativePtr);
    }

    public unsafe ref ImFontAtlasFlags Flags
    {
      get => ref Unsafe.AsRef<ImFontAtlasFlags>((void*) &this.NativePtr->Flags);
    }

    public unsafe ref IntPtr TexID => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->TexID);

    public unsafe ref int TexDesiredWidth
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->TexDesiredWidth);
    }

    public unsafe ref int TexGlyphPadding
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->TexGlyphPadding);
    }

    public unsafe ref bool Locked => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->Locked);

    public unsafe ref bool TexReady => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->TexReady);

    public unsafe ref bool TexPixelsUseColors
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->TexPixelsUseColors);
    }

    public unsafe IntPtr TexPixelsAlpha8
    {
      get => (IntPtr) (void*) this.NativePtr->TexPixelsAlpha8;
      set => this.NativePtr->TexPixelsAlpha8 = (byte*) (void*) value;
    }

    public unsafe IntPtr TexPixelsRGBA32
    {
      get => (IntPtr) (void*) this.NativePtr->TexPixelsRGBA32;
      set => this.NativePtr->TexPixelsRGBA32 = (uint*) (void*) value;
    }

    public unsafe ref int TexWidth => ref Unsafe.AsRef<int>((void*) &this.NativePtr->TexWidth);

    public unsafe ref int TexHeight => ref Unsafe.AsRef<int>((void*) &this.NativePtr->TexHeight);

    public unsafe ref Vector2 TexUvScale
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->TexUvScale);
    }

    public unsafe ref Vector2 TexUvWhitePixel
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->TexUvWhitePixel);
    }

    public unsafe ImVector<ImFontPtr> Fonts => new ImVector<ImFontPtr>(this.NativePtr->Fonts);

    public unsafe ImPtrVector<ImFontAtlasCustomRectPtr> CustomRects
    {
      get
      {
        return new ImPtrVector<ImFontAtlasCustomRectPtr>(this.NativePtr->CustomRects, Unsafe.SizeOf<ImFontAtlasCustomRect>());
      }
    }

    public unsafe ImPtrVector<ImFontConfigPtr> ConfigData
    {
      get
      {
        return new ImPtrVector<ImFontConfigPtr>(this.NativePtr->ConfigData, Unsafe.SizeOf<ImFontConfig>());
      }
    }

    public unsafe RangeAccessor<Vector4> TexUvLines
    {
      get => new RangeAccessor<Vector4>((void*) &this.NativePtr->TexUvLines_0, 64);
    }

    public unsafe IntPtr FontBuilderIO
    {
      get => (IntPtr) (void*) this.NativePtr->FontBuilderIO;
      set => this.NativePtr->FontBuilderIO = (IntPtr*) (void*) value;
    }

    public unsafe ref uint FontBuilderFlags
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->FontBuilderFlags);
    }

    public unsafe ref int PackIdMouseCursors
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->PackIdMouseCursors);
    }

    public unsafe ref int PackIdLines
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->PackIdLines);
    }

    public unsafe int AddCustomRectFontGlyph(
      ImFontPtr font,
      ushort id,
      int width,
      int height,
      float advance_x)
    {
      ImFont* nativePtr = font.NativePtr;
      Vector2 offset = new Vector2();
      return ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(this.NativePtr, nativePtr, id, width, height, advance_x, offset);
    }

    public unsafe int AddCustomRectFontGlyph(
      ImFontPtr font,
      ushort id,
      int width,
      int height,
      float advance_x,
      Vector2 offset)
    {
      return ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(this.NativePtr, font.NativePtr, id, width, height, advance_x, offset);
    }

    public unsafe int AddCustomRectRegular(int width, int height)
    {
      return ImGuiNative.ImFontAtlas_AddCustomRectRegular(this.NativePtr, width, height);
    }

    public unsafe ImFontPtr AddFont(ImFontConfigPtr font_cfg)
    {
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFont(this.NativePtr, font_cfg.NativePtr));
    }

    public unsafe ImFontPtr AddFontDefault()
    {
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontDefault(this.NativePtr, (ImFontConfig*) null));
    }

    public unsafe ImFontPtr AddFontDefault(ImFontConfigPtr font_cfg)
    {
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontDefault(this.NativePtr, font_cfg.NativePtr));
    }

    public unsafe ImFontPtr AddFontFromFileTTF(string filename, float size_pixels)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (filename != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(filename);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(filename, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImFontConfig* font_cfg = (ImFontConfig*) null;
      ushort* glyph_ranges = (ushort*) null;
      ImFont* nativePtr = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(this.NativePtr, numPtr, size_pixels, font_cfg, glyph_ranges);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImFontPtr(nativePtr);
    }

    public unsafe ImFontPtr AddFontFromFileTTF(
      string filename,
      float size_pixels,
      ImFontConfigPtr font_cfg)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (filename != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(filename);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(filename, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImFontConfig* nativePtr1 = font_cfg.NativePtr;
      ushort* glyph_ranges = (ushort*) null;
      ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(this.NativePtr, numPtr, size_pixels, nativePtr1, glyph_ranges);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImFontPtr(nativePtr2);
    }

    public unsafe ImFontPtr AddFontFromFileTTF(
      string filename,
      float size_pixels,
      ImFontConfigPtr font_cfg,
      IntPtr glyph_ranges)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (filename != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(filename);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(filename, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImFontConfig* nativePtr1 = font_cfg.NativePtr;
      ushort* pointer = (ushort*) glyph_ranges.ToPointer();
      ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(this.NativePtr, numPtr, size_pixels, nativePtr1, pointer);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImFontPtr(nativePtr2);
    }

    public unsafe ImFontPtr AddFontFromMemoryCompressedBase85TTF(
      string compressed_font_data_base85,
      float size_pixels)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (compressed_font_data_base85 != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(compressed_font_data_base85, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImFontConfig* font_cfg = (ImFontConfig*) null;
      ushort* glyph_ranges = (ushort*) null;
      ImFont* nativePtr = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(this.NativePtr, numPtr, size_pixels, font_cfg, glyph_ranges);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImFontPtr(nativePtr);
    }

    public unsafe ImFontPtr AddFontFromMemoryCompressedBase85TTF(
      string compressed_font_data_base85,
      float size_pixels,
      ImFontConfigPtr font_cfg)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (compressed_font_data_base85 != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(compressed_font_data_base85, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImFontConfig* nativePtr1 = font_cfg.NativePtr;
      ushort* glyph_ranges = (ushort*) null;
      ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(this.NativePtr, numPtr, size_pixels, nativePtr1, glyph_ranges);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImFontPtr(nativePtr2);
    }

    public unsafe ImFontPtr AddFontFromMemoryCompressedBase85TTF(
      string compressed_font_data_base85,
      float size_pixels,
      ImFontConfigPtr font_cfg,
      IntPtr glyph_ranges)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (compressed_font_data_base85 != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(compressed_font_data_base85, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImFontConfig* nativePtr1 = font_cfg.NativePtr;
      ushort* pointer = (ushort*) glyph_ranges.ToPointer();
      ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(this.NativePtr, numPtr, size_pixels, nativePtr1, pointer);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImFontPtr(nativePtr2);
    }

    public unsafe ImFontPtr AddFontFromMemoryCompressedTTF(
      IntPtr compressed_font_data,
      int compressed_font_size,
      float size_pixels)
    {
      void* pointer = compressed_font_data.ToPointer();
      ImFontConfig* font_cfg = (ImFontConfig*) null;
      ushort* glyph_ranges = (ushort*) null;
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(this.NativePtr, pointer, compressed_font_size, size_pixels, font_cfg, glyph_ranges));
    }

    public unsafe ImFontPtr AddFontFromMemoryCompressedTTF(
      IntPtr compressed_font_data,
      int compressed_font_size,
      float size_pixels,
      ImFontConfigPtr font_cfg)
    {
      void* pointer = compressed_font_data.ToPointer();
      ImFontConfig* nativePtr = font_cfg.NativePtr;
      ushort* glyph_ranges = (ushort*) null;
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(this.NativePtr, pointer, compressed_font_size, size_pixels, nativePtr, glyph_ranges));
    }

    public unsafe ImFontPtr AddFontFromMemoryCompressedTTF(
      IntPtr compressed_font_data,
      int compressed_font_size,
      float size_pixels,
      ImFontConfigPtr font_cfg,
      IntPtr glyph_ranges)
    {
      void* pointer1 = compressed_font_data.ToPointer();
      ImFontConfig* nativePtr = font_cfg.NativePtr;
      ushort* pointer2 = (ushort*) glyph_ranges.ToPointer();
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(this.NativePtr, pointer1, compressed_font_size, size_pixels, nativePtr, pointer2));
    }

    public unsafe ImFontPtr AddFontFromMemoryTTF(
      IntPtr font_data,
      int font_size,
      float size_pixels)
    {
      void* pointer = font_data.ToPointer();
      ImFontConfig* font_cfg = (ImFontConfig*) null;
      ushort* glyph_ranges = (ushort*) null;
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(this.NativePtr, pointer, font_size, size_pixels, font_cfg, glyph_ranges));
    }

    public unsafe ImFontPtr AddFontFromMemoryTTF(
      IntPtr font_data,
      int font_size,
      float size_pixels,
      ImFontConfigPtr font_cfg)
    {
      void* pointer = font_data.ToPointer();
      ImFontConfig* nativePtr = font_cfg.NativePtr;
      ushort* glyph_ranges = (ushort*) null;
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(this.NativePtr, pointer, font_size, size_pixels, nativePtr, glyph_ranges));
    }

    public unsafe ImFontPtr AddFontFromMemoryTTF(
      IntPtr font_data,
      int font_size,
      float size_pixels,
      ImFontConfigPtr font_cfg,
      IntPtr glyph_ranges)
    {
      void* pointer1 = font_data.ToPointer();
      ImFontConfig* nativePtr = font_cfg.NativePtr;
      ushort* pointer2 = (ushort*) glyph_ranges.ToPointer();
      return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(this.NativePtr, pointer1, font_size, size_pixels, nativePtr, pointer2));
    }

    public unsafe bool Build() => ImGuiNative.ImFontAtlas_Build(this.NativePtr) > (byte) 0;

    public unsafe void CalcCustomRectUV(
      ImFontAtlasCustomRectPtr rect,
      out Vector2 out_uv_min,
      out Vector2 out_uv_max)
    {
      ImFontAtlasCustomRect* nativePtr = rect.NativePtr;
      fixed (Vector2* out_uv_min1 = &out_uv_min)
        fixed (Vector2* out_uv_max1 = &out_uv_max)
          ImGuiNative.ImFontAtlas_CalcCustomRectUV(this.NativePtr, nativePtr, out_uv_min1, out_uv_max1);
    }

    public unsafe void Clear() => ImGuiNative.ImFontAtlas_Clear(this.NativePtr);

    public unsafe void ClearFonts() => ImGuiNative.ImFontAtlas_ClearFonts(this.NativePtr);

    public unsafe void ClearInputData() => ImGuiNative.ImFontAtlas_ClearInputData(this.NativePtr);

    public unsafe void ClearTexData() => ImGuiNative.ImFontAtlas_ClearTexData(this.NativePtr);

    public unsafe void Destroy() => ImGuiNative.ImFontAtlas_destroy(this.NativePtr);

    public unsafe ImFontAtlasCustomRectPtr GetCustomRectByIndex(int index)
    {
      return new ImFontAtlasCustomRectPtr(ImGuiNative.ImFontAtlas_GetCustomRectByIndex(this.NativePtr, index));
    }

    public unsafe IntPtr GetGlyphRangesChineseFull()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesChineseFull(this.NativePtr);
    }

    public unsafe IntPtr GetGlyphRangesChineseSimplifiedCommon()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(this.NativePtr);
    }

    public unsafe IntPtr GetGlyphRangesCyrillic()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesCyrillic(this.NativePtr);
    }

    public unsafe IntPtr GetGlyphRangesDefault()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesDefault(this.NativePtr);
    }

    public unsafe IntPtr GetGlyphRangesJapanese()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesJapanese(this.NativePtr);
    }

    public unsafe IntPtr GetGlyphRangesKorean()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesKorean(this.NativePtr);
    }

    public unsafe IntPtr GetGlyphRangesThai()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesThai(this.NativePtr);
    }

    public unsafe IntPtr GetGlyphRangesVietnamese()
    {
      return (IntPtr) (void*) ImGuiNative.ImFontAtlas_GetGlyphRangesVietnamese(this.NativePtr);
    }

    public unsafe bool GetMouseCursorTexData(
      ImGuiMouseCursor cursor,
      out Vector2 out_offset,
      out Vector2 out_size,
      out Vector2 out_uv_border,
      out Vector2 out_uv_fill)
    {
      fixed (Vector2* out_offset1 = &out_offset)
        fixed (Vector2* out_size1 = &out_size)
          fixed (Vector2* out_uv_border1 = &out_uv_border)
            fixed (Vector2* out_uv_fill1 = &out_uv_fill)
              return ImGuiNative.ImFontAtlas_GetMouseCursorTexData(this.NativePtr, cursor, out_offset1, out_size1, out_uv_border1, out_uv_fill1) > (byte) 0;
    }

    public unsafe void GetTexDataAsAlpha8(
      out byte* out_pixels,
      out int out_width,
      out int out_height)
    {
      int* out_bytes_per_pixel = (int*) null;
      fixed (byte** out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel);
    }

    public unsafe void GetTexDataAsAlpha8(
      out byte* out_pixels,
      out int out_width,
      out int out_height,
      out int out_bytes_per_pixel)
    {
      fixed (byte** out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            fixed (int* out_bytes_per_pixel1 = &out_bytes_per_pixel)
              ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel1);
    }

    public unsafe void GetTexDataAsAlpha8(
      out IntPtr out_pixels,
      out int out_width,
      out int out_height)
    {
      int* out_bytes_per_pixel = (int*) null;
      fixed (IntPtr* out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel);
    }

    public unsafe void GetTexDataAsAlpha8(
      out IntPtr out_pixels,
      out int out_width,
      out int out_height,
      out int out_bytes_per_pixel)
    {
      fixed (IntPtr* out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            fixed (int* out_bytes_per_pixel1 = &out_bytes_per_pixel)
              ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel1);
    }

    public unsafe void GetTexDataAsRGBA32(
      out byte* out_pixels,
      out int out_width,
      out int out_height)
    {
      int* out_bytes_per_pixel = (int*) null;
      fixed (byte** out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel);
    }

    public unsafe void GetTexDataAsRGBA32(
      out byte* out_pixels,
      out int out_width,
      out int out_height,
      out int out_bytes_per_pixel)
    {
      fixed (byte** out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            fixed (int* out_bytes_per_pixel1 = &out_bytes_per_pixel)
              ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel1);
    }

    public unsafe void GetTexDataAsRGBA32(
      out IntPtr out_pixels,
      out int out_width,
      out int out_height)
    {
      int* out_bytes_per_pixel = (int*) null;
      fixed (IntPtr* out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel);
    }

    public unsafe void GetTexDataAsRGBA32(
      out IntPtr out_pixels,
      out int out_width,
      out int out_height,
      out int out_bytes_per_pixel)
    {
      fixed (IntPtr* out_pixels1 = &out_pixels)
        fixed (int* out_width1 = &out_width)
          fixed (int* out_height1 = &out_height)
            fixed (int* out_bytes_per_pixel1 = &out_bytes_per_pixel)
              ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(this.NativePtr, out_pixels1, out_width1, out_height1, out_bytes_per_pixel1);
    }

    public unsafe bool IsBuilt() => ImGuiNative.ImFontAtlas_IsBuilt(this.NativePtr) > (byte) 0;

    public unsafe void SetTexID(IntPtr id) => ImGuiNative.ImFontAtlas_SetTexID(this.NativePtr, id);
  }
}
