// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawCmdHeaderPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawCmdHeaderPtr
  {
    public unsafe ImDrawCmdHeader* NativePtr { get; }

    public unsafe ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImDrawCmdHeaderPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImDrawCmdHeader*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr)
    {
      return new ImDrawCmdHeaderPtr(nativePtr);
    }

    public static unsafe implicit operator ImDrawCmdHeader*(ImDrawCmdHeaderPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImDrawCmdHeaderPtr(IntPtr nativePtr)
    {
      return new ImDrawCmdHeaderPtr(nativePtr);
    }

    public unsafe ref Vector4 ClipRect
    {
      get => ref Unsafe.AsRef<Vector4>((void*) &this.NativePtr->ClipRect);
    }

    public unsafe ref IntPtr TextureId
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->TextureId);
    }

    public unsafe ref uint VtxOffset => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->VtxOffset);
  }
}
