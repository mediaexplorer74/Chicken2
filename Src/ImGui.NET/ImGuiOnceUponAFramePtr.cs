// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiOnceUponAFramePtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiOnceUponAFramePtr
  {
    public unsafe ImGuiOnceUponAFrame* NativePtr { get; }

    public unsafe ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImGuiOnceUponAFramePtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiOnceUponAFrame*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr)
    {
      return new ImGuiOnceUponAFramePtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiOnceUponAFrame*(ImGuiOnceUponAFramePtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiOnceUponAFramePtr(IntPtr nativePtr)
    {
      return new ImGuiOnceUponAFramePtr(nativePtr);
    }

    public unsafe ref int RefFrame => ref Unsafe.AsRef<int>((void*) &this.NativePtr->RefFrame);

    public unsafe void Destroy() => ImGuiNative.ImGuiOnceUponAFrame_destroy(this.NativePtr);
  }
}
