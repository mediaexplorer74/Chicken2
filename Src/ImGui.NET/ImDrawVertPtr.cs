// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawVertPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawVertPtr
  {
    public unsafe ImDrawVert* NativePtr { get; }

    public unsafe ImDrawVertPtr(ImDrawVert* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImDrawVertPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImDrawVert*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImDrawVertPtr(ImDrawVert* nativePtr)
    {
      return new ImDrawVertPtr(nativePtr);
    }

    public static unsafe implicit operator ImDrawVert*(ImDrawVertPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImDrawVertPtr(IntPtr nativePtr) => new ImDrawVertPtr(nativePtr);

    public unsafe ref Vector2 pos => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->pos);

    public unsafe ref Vector2 uv => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->uv);

    public unsafe ref uint col => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->col);
  }
}
