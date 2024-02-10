// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTextRangePtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiTextRangePtr
  {
    public unsafe ImGuiTextRange* NativePtr { get; }

    public unsafe ImGuiTextRangePtr(ImGuiTextRange* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiTextRangePtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiTextRange*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiTextRangePtr(ImGuiTextRange* nativePtr)
    {
      return new ImGuiTextRangePtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiTextRange*(ImGuiTextRangePtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiTextRangePtr(IntPtr nativePtr)
    {
      return new ImGuiTextRangePtr(nativePtr);
    }

    public unsafe IntPtr b
    {
      get => (IntPtr) (void*) this.NativePtr->b;
      set => this.NativePtr->b = (byte*) (void*) value;
    }

    public unsafe IntPtr e
    {
      get => (IntPtr) (void*) this.NativePtr->e;
      set => this.NativePtr->e = (byte*) (void*) value;
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiTextRange_destroy(this.NativePtr);

    public unsafe bool empty() => ImGuiNative.ImGuiTextRange_empty(this.NativePtr) > (byte) 0;

    public unsafe void split(byte separator, out ImVector @out)
    {
      fixed (ImVector* out1 = &@out)
        ImGuiNative.ImGuiTextRange_split(this.NativePtr, separator, out1);
    }
  }
}
