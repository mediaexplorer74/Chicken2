// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawListSplitterPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawListSplitterPtr
  {
    public unsafe ImDrawListSplitter* NativePtr { get; }

    public unsafe ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImDrawListSplitterPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImDrawListSplitter*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr)
    {
      return new ImDrawListSplitterPtr(nativePtr);
    }

    public static unsafe implicit operator ImDrawListSplitter*(ImDrawListSplitterPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImDrawListSplitterPtr(IntPtr nativePtr)
    {
      return new ImDrawListSplitterPtr(nativePtr);
    }

    public unsafe ref int _Current => ref Unsafe.AsRef<int>((void*) &this.NativePtr->_Current);

    public unsafe ref int _Count => ref Unsafe.AsRef<int>((void*) &this.NativePtr->_Count);

    public unsafe ImPtrVector<ImDrawChannelPtr> _Channels
    {
      get
      {
        return new ImPtrVector<ImDrawChannelPtr>(this.NativePtr->_Channels, Unsafe.SizeOf<ImDrawChannel>());
      }
    }

    public unsafe void Clear() => ImGuiNative.ImDrawListSplitter_Clear(this.NativePtr);

    public unsafe void ClearFreeMemory()
    {
      ImGuiNative.ImDrawListSplitter_ClearFreeMemory(this.NativePtr);
    }

    public unsafe void Destroy() => ImGuiNative.ImDrawListSplitter_destroy(this.NativePtr);

    public unsafe void Merge(ImDrawListPtr draw_list)
    {
      ImGuiNative.ImDrawListSplitter_Merge(this.NativePtr, draw_list.NativePtr);
    }

    public unsafe void SetCurrentChannel(ImDrawListPtr draw_list, int channel_idx)
    {
      ImGuiNative.ImDrawListSplitter_SetCurrentChannel(this.NativePtr, draw_list.NativePtr, channel_idx);
    }

    public unsafe void Split(ImDrawListPtr draw_list, int count)
    {
      ImGuiNative.ImDrawListSplitter_Split(this.NativePtr, draw_list.NativePtr, count);
    }
  }
}
