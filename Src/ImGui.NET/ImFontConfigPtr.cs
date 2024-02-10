// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontConfigPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontConfigPtr
  {
    public unsafe ImFontConfig* NativePtr { get; }

    public unsafe ImFontConfigPtr(ImFontConfig* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImFontConfigPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImFontConfig*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImFontConfigPtr(ImFontConfig* nativePtr)
    {
      return new ImFontConfigPtr(nativePtr);
    }

    public static unsafe implicit operator ImFontConfig*(ImFontConfigPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImFontConfigPtr(IntPtr nativePtr)
    {
      return new ImFontConfigPtr(nativePtr);
    }

    public unsafe IntPtr FontData
    {
      get => (IntPtr) this.NativePtr->FontData;
      set => this.NativePtr->FontData = (void*) value;
    }

    public unsafe ref int FontDataSize
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->FontDataSize);
    }

    public unsafe ref bool FontDataOwnedByAtlas
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->FontDataOwnedByAtlas);
    }

    public unsafe ref int FontNo => ref Unsafe.AsRef<int>((void*) &this.NativePtr->FontNo);

    public unsafe ref float SizePixels
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->SizePixels);
    }

    public unsafe ref int OversampleH
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->OversampleH);
    }

    public unsafe ref int OversampleV
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->OversampleV);
    }

    public unsafe ref bool PixelSnapH
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->PixelSnapH);
    }

    public unsafe ref Vector2 GlyphExtraSpacing
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->GlyphExtraSpacing);
    }

    public unsafe ref Vector2 GlyphOffset
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->GlyphOffset);
    }

    public unsafe IntPtr GlyphRanges
    {
      get => (IntPtr) (void*) this.NativePtr->GlyphRanges;
      set => this.NativePtr->GlyphRanges = (ushort*) (void*) value;
    }

    public unsafe ref float GlyphMinAdvanceX
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->GlyphMinAdvanceX);
    }

    public unsafe ref float GlyphMaxAdvanceX
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->GlyphMaxAdvanceX);
    }

    public unsafe ref bool MergeMode => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->MergeMode);

    public unsafe ref uint FontBuilderFlags
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->FontBuilderFlags);
    }

    public unsafe ref float RasterizerMultiply
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->RasterizerMultiply);
    }

    public unsafe ref ushort EllipsisChar
    {
      get => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->EllipsisChar);
    }

    public unsafe RangeAccessor<byte> Name
    {
      get => new RangeAccessor<byte>((void*) this.NativePtr->Name, 40);
    }

    public unsafe ImFontPtr DstFont => new ImFontPtr(this.NativePtr->DstFont);

    public unsafe void Destroy() => ImGuiNative.ImFontConfig_destroy(this.NativePtr);
  }
}
