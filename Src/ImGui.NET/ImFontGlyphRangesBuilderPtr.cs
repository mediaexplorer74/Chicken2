// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontGlyphRangesBuilderPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontGlyphRangesBuilderPtr
  {
    public unsafe ImFontGlyphRangesBuilder* NativePtr { get; }

    public unsafe ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImFontGlyphRangesBuilderPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImFontGlyphRangesBuilder*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImFontGlyphRangesBuilderPtr(
      ImFontGlyphRangesBuilder* nativePtr)
    {
      return new ImFontGlyphRangesBuilderPtr(nativePtr);
    }

    public static unsafe implicit operator ImFontGlyphRangesBuilder*(
      ImFontGlyphRangesBuilderPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImFontGlyphRangesBuilderPtr(IntPtr nativePtr)
    {
      return new ImFontGlyphRangesBuilderPtr(nativePtr);
    }

    public unsafe ImVector<uint> UsedChars => new ImVector<uint>(this.NativePtr->UsedChars);

    public unsafe void AddChar(ushort c)
    {
      ImGuiNative.ImFontGlyphRangesBuilder_AddChar(this.NativePtr, c);
    }

    public unsafe void AddRanges(IntPtr ranges)
    {
      ImGuiNative.ImFontGlyphRangesBuilder_AddRanges(this.NativePtr, (ushort*) ranges.ToPointer());
    }

    public unsafe void AddText(string text)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (text != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(text);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(text, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte* text_end = (byte*) null;
      ImGuiNative.ImFontGlyphRangesBuilder_AddText(this.NativePtr, numPtr, text_end);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public unsafe void BuildRanges(out ImVector out_ranges)
    {
      fixed (ImVector* out_ranges1 = &out_ranges)
        ImGuiNative.ImFontGlyphRangesBuilder_BuildRanges(this.NativePtr, out_ranges1);
    }

    public unsafe void Clear() => ImGuiNative.ImFontGlyphRangesBuilder_Clear(this.NativePtr);

    public unsafe void Destroy() => ImGuiNative.ImFontGlyphRangesBuilder_destroy(this.NativePtr);

    public unsafe bool GetBit(uint n)
    {
      return ImGuiNative.ImFontGlyphRangesBuilder_GetBit(this.NativePtr, n) > (byte) 0;
    }

    public unsafe void SetBit(uint n)
    {
      ImGuiNative.ImFontGlyphRangesBuilder_SetBit(this.NativePtr, n);
    }
  }
}
