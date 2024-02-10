// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawDataPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawDataPtr
  {
    public unsafe ImDrawData* NativePtr { get; }

    public unsafe ImDrawDataPtr(ImDrawData* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImDrawDataPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImDrawData*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImDrawDataPtr(ImDrawData* nativePtr)
    {
      return new ImDrawDataPtr(nativePtr);
    }

    public static unsafe implicit operator ImDrawData*(ImDrawDataPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImDrawDataPtr(IntPtr nativePtr) => new ImDrawDataPtr(nativePtr);

    public unsafe ref bool Valid => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->Valid);

    public unsafe ref int CmdListsCount
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->CmdListsCount);
    }

    public unsafe ref int TotalIdxCount
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->TotalIdxCount);
    }

    public unsafe ref int TotalVtxCount
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->TotalVtxCount);
    }

    public unsafe IntPtr CmdLists
    {
      get => (IntPtr) (void*) this.NativePtr->CmdLists;
      set => this.NativePtr->CmdLists = (ImDrawList**) (void*) value;
    }

    public unsafe ref Vector2 DisplayPos
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->DisplayPos);
    }

    public unsafe ref Vector2 DisplaySize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->DisplaySize);
    }

    public unsafe ref Vector2 FramebufferScale
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->FramebufferScale);
    }

    public unsafe ImGuiViewportPtr OwnerViewport
    {
      get => new ImGuiViewportPtr(this.NativePtr->OwnerViewport);
    }

    public unsafe void Clear() => ImGuiNative.ImDrawData_Clear(this.NativePtr);

    public unsafe void DeIndexAllBuffers()
    {
      ImGuiNative.ImDrawData_DeIndexAllBuffers(this.NativePtr);
    }

    public unsafe void Destroy() => ImGuiNative.ImDrawData_destroy(this.NativePtr);

    public unsafe void ScaleClipRects(Vector2 fb_scale)
    {
      ImGuiNative.ImDrawData_ScaleClipRects(this.NativePtr, fb_scale);
    }

    public unsafe RangePtrAccessor<ImDrawListPtr> CmdListsRange
    {
      get => new RangePtrAccessor<ImDrawListPtr>(this.CmdLists.ToPointer(), this.CmdListsCount);
    }
  }
}
