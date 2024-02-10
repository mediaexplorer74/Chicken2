// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontAtlasCustomRectPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontAtlasCustomRectPtr
  {
    public unsafe ImFontAtlasCustomRect* NativePtr { get; }

    public unsafe ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImFontAtlasCustomRectPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImFontAtlasCustomRect*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr)
    {
      return new ImFontAtlasCustomRectPtr(nativePtr);
    }

    public static unsafe implicit operator ImFontAtlasCustomRect*(
      ImFontAtlasCustomRectPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImFontAtlasCustomRectPtr(IntPtr nativePtr)
    {
      return new ImFontAtlasCustomRectPtr(nativePtr);
    }

    public unsafe ref ushort Width => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->Width);

    public unsafe ref ushort Height => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->Height);

    public unsafe ref ushort X => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->X);

    public unsafe ref ushort Y => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->Y);

    public unsafe ref uint GlyphID => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->GlyphID);

    public unsafe ref float GlyphAdvanceX
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->GlyphAdvanceX);
    }

    public unsafe ref Vector2 GlyphOffset
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->GlyphOffset);
    }

    public unsafe ImFontPtr Font => new ImFontPtr(this.NativePtr->Font);

    public unsafe void Destroy() => ImGuiNative.ImFontAtlasCustomRect_destroy(this.NativePtr);

    public unsafe bool IsPacked()
    {
      return ImGuiNative.ImFontAtlasCustomRect_IsPacked(this.NativePtr) > (byte) 0;
    }
  }
}
