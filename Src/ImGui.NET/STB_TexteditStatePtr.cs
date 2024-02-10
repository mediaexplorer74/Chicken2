// Decompiled with JetBrains decompiler
// Type: ImGuiNET.STB_TexteditStatePtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct STB_TexteditStatePtr
  {
    public unsafe STB_TexteditState* NativePtr { get; }

    public unsafe STB_TexteditStatePtr(STB_TexteditState* nativePtr) => this.NativePtr = nativePtr;

    public unsafe STB_TexteditStatePtr(IntPtr nativePtr)
    {
      this.NativePtr = (STB_TexteditState*) (void*) nativePtr;
    }

    public static unsafe implicit operator STB_TexteditStatePtr(STB_TexteditState* nativePtr)
    {
      return new STB_TexteditStatePtr(nativePtr);
    }

    public static unsafe implicit operator STB_TexteditState*(STB_TexteditStatePtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator STB_TexteditStatePtr(IntPtr nativePtr)
    {
      return new STB_TexteditStatePtr(nativePtr);
    }

    public unsafe ref int cursor => ref Unsafe.AsRef<int>((void*) &this.NativePtr->cursor);

    public unsafe ref int select_start
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->select_start);
    }

    public unsafe ref int select_end => ref Unsafe.AsRef<int>((void*) &this.NativePtr->select_end);

    public unsafe ref byte insert_mode
    {
      get => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->insert_mode);
    }

    public unsafe ref int row_count_per_page
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->row_count_per_page);
    }

    public unsafe ref byte cursor_at_end_of_line
    {
      get => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->cursor_at_end_of_line);
    }

    public unsafe ref byte initialized
    {
      get => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->initialized);
    }

    public unsafe ref byte has_preferred_x
    {
      get => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->has_preferred_x);
    }

    public unsafe ref byte single_line
    {
      get => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->single_line);
    }

    public unsafe ref byte padding1 => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->padding1);

    public unsafe ref byte padding2 => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->padding2);

    public unsafe ref byte padding3 => ref Unsafe.AsRef<byte>((void*) &this.NativePtr->padding3);

    public unsafe ref float preferred_x
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->preferred_x);
    }

    public unsafe ref StbUndoState undostate
    {
      get => ref Unsafe.AsRef<StbUndoState>((void*) &this.NativePtr->undostate);
    }
  }
}
