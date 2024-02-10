// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawCmdPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawCmdPtr
  {
    public unsafe ImDrawCmd* NativePtr { get; }

    public unsafe ImDrawCmdPtr(ImDrawCmd* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImDrawCmdPtr(IntPtr nativePtr) => this.NativePtr = (ImDrawCmd*) (void*) nativePtr;

    public static unsafe implicit operator ImDrawCmdPtr(ImDrawCmd* nativePtr)
    {
      return new ImDrawCmdPtr(nativePtr);
    }

    public static unsafe implicit operator ImDrawCmd*(ImDrawCmdPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImDrawCmdPtr(IntPtr nativePtr) => new ImDrawCmdPtr(nativePtr);

    public unsafe ref Vector4 ClipRect
    {
      get => ref Unsafe.AsRef<Vector4>((void*) &this.NativePtr->ClipRect);
    }

    public unsafe ref IntPtr TextureId
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->TextureId);
    }

    public unsafe ref uint VtxOffset => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->VtxOffset);

    public unsafe ref uint IdxOffset => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->IdxOffset);

    public unsafe ref uint ElemCount => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->ElemCount);

    public unsafe ref IntPtr UserCallback
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->UserCallback);
    }

    public unsafe IntPtr UserCallbackData
    {
      get => (IntPtr) this.NativePtr->UserCallbackData;
      set => this.NativePtr->UserCallbackData = (void*) value;
    }

    public unsafe void Destroy() => ImGuiNative.ImDrawCmd_destroy(this.NativePtr);

    public unsafe IntPtr GetTexID() => ImGuiNative.ImDrawCmd_GetTexID(this.NativePtr);
  }
}
