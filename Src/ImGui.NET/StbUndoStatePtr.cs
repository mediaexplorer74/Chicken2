// Decompiled with JetBrains decompiler
// Type: ImGuiNET.StbUndoStatePtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct StbUndoStatePtr
  {
    public unsafe StbUndoState* NativePtr { get; }

    public unsafe StbUndoStatePtr(StbUndoState* nativePtr) => this.NativePtr = nativePtr;

    public unsafe StbUndoStatePtr(IntPtr nativePtr)
    {
      this.NativePtr = (StbUndoState*) (void*) nativePtr;
    }

    public static unsafe implicit operator StbUndoStatePtr(StbUndoState* nativePtr)
    {
      return new StbUndoStatePtr(nativePtr);
    }

    public static unsafe implicit operator StbUndoState*(StbUndoStatePtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator StbUndoStatePtr(IntPtr nativePtr)
    {
      return new StbUndoStatePtr(nativePtr);
    }

    public unsafe RangeAccessor<StbUndoRecord> undo_rec
    {
      get => new RangeAccessor<StbUndoRecord>((void*) &this.NativePtr->undo_rec_0, 99);
    }

    public unsafe RangeAccessor<ushort> undo_char
    {
      get => new RangeAccessor<ushort>((void*) this.NativePtr->undo_char, 999);
    }

    public unsafe ref short undo_point
    {
      get => ref Unsafe.AsRef<short>((void*) &this.NativePtr->undo_point);
    }

    public unsafe ref short redo_point
    {
      get => ref Unsafe.AsRef<short>((void*) &this.NativePtr->redo_point);
    }

    public unsafe ref int undo_char_point
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->undo_char_point);
    }

    public unsafe ref int redo_char_point
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->redo_char_point);
    }
  }
}
