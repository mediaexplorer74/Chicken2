// Decompiled with JetBrains decompiler
// Type: ImGuiNET.StbUndoRecordPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct StbUndoRecordPtr
  {
    public unsafe StbUndoRecord* NativePtr { get; }

    public unsafe StbUndoRecordPtr(StbUndoRecord* nativePtr) => this.NativePtr = nativePtr;

    public unsafe StbUndoRecordPtr(IntPtr nativePtr)
    {
      this.NativePtr = (StbUndoRecord*) (void*) nativePtr;
    }

    public static unsafe implicit operator StbUndoRecordPtr(StbUndoRecord* nativePtr)
    {
      return new StbUndoRecordPtr(nativePtr);
    }

    public static unsafe implicit operator StbUndoRecord*(StbUndoRecordPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator StbUndoRecordPtr(IntPtr nativePtr)
    {
      return new StbUndoRecordPtr(nativePtr);
    }

    public unsafe ref int where => ref Unsafe.AsRef<int>((void*) &this.NativePtr->where);

    public unsafe ref int insert_length
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->insert_length);
    }

    public unsafe ref int delete_length
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->delete_length);
    }

    public unsafe ref int char_storage
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->char_storage);
    }
  }
}
