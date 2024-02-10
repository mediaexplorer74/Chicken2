// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawChannelPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawChannelPtr
  {
    public unsafe ImDrawChannel* NativePtr { get; }

    public unsafe ImDrawChannelPtr(ImDrawChannel* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImDrawChannelPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImDrawChannel*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImDrawChannelPtr(ImDrawChannel* nativePtr)
    {
      return new ImDrawChannelPtr(nativePtr);
    }

    public static unsafe implicit operator ImDrawChannel*(ImDrawChannelPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImDrawChannelPtr(IntPtr nativePtr)
    {
      return new ImDrawChannelPtr(nativePtr);
    }

    public unsafe ImPtrVector<ImDrawCmdPtr> _CmdBuffer
    {
      get => new ImPtrVector<ImDrawCmdPtr>(this.NativePtr->_CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());
    }

    public unsafe ImVector<ushort> _IdxBuffer => new ImVector<ushort>(this.NativePtr->_IdxBuffer);
  }
}
