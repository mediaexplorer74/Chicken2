// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontGlyphPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontGlyphPtr
  {
    public unsafe ImFontGlyph* NativePtr { get; }

    public unsafe ImFontGlyphPtr(ImFontGlyph* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImFontGlyphPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImFontGlyph*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImFontGlyphPtr(ImFontGlyph* nativePtr)
    {
      return new ImFontGlyphPtr(nativePtr);
    }

    public static unsafe implicit operator ImFontGlyph*(ImFontGlyphPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImFontGlyphPtr(IntPtr nativePtr)
    {
      return new ImFontGlyphPtr(nativePtr);
    }

    public unsafe ref uint Colored => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->Colored);

    public unsafe ref uint Visible => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->Visible);

    public unsafe ref uint Codepoint => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->Codepoint);

    public unsafe ref float AdvanceX => ref Unsafe.AsRef<float>((void*) &this.NativePtr->AdvanceX);

    public unsafe ref float X0 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->X0);

    public unsafe ref float Y0 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->Y0);

    public unsafe ref float X1 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->X1);

    public unsafe ref float Y1 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->Y1);

    public unsafe ref float U0 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->U0);

    public unsafe ref float V0 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->V0);

    public unsafe ref float U1 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->U1);

    public unsafe ref float V1 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->V1);
  }
}
