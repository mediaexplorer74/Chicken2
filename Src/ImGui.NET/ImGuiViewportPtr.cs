// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiViewportPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiViewportPtr
  {
    public unsafe ImGuiViewport* NativePtr { get; }

    public unsafe ImGuiViewportPtr(ImGuiViewport* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiViewportPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiViewport*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiViewportPtr(ImGuiViewport* nativePtr)
    {
      return new ImGuiViewportPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiViewport*(ImGuiViewportPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiViewportPtr(IntPtr nativePtr)
    {
      return new ImGuiViewportPtr(nativePtr);
    }

    public unsafe ref uint ID => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->ID);

    public unsafe ref ImGuiViewportFlags Flags
    {
      get => ref Unsafe.AsRef<ImGuiViewportFlags>((void*) &this.NativePtr->Flags);
    }

    public unsafe ref Vector2 Pos => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->Pos);

    public unsafe ref Vector2 Size => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->Size);

    public unsafe ref Vector2 WorkPos
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->WorkPos);
    }

    public unsafe ref Vector2 WorkSize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->WorkSize);
    }

    public unsafe ref float DpiScale => ref Unsafe.AsRef<float>((void*) &this.NativePtr->DpiScale);

    public unsafe ref uint ParentViewportId
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->ParentViewportId);
    }

    public unsafe ImDrawDataPtr DrawData => new ImDrawDataPtr(this.NativePtr->DrawData);

    public unsafe IntPtr RendererUserData
    {
      get => (IntPtr) this.NativePtr->RendererUserData;
      set => this.NativePtr->RendererUserData = (void*) value;
    }

    public unsafe IntPtr PlatformUserData
    {
      get => (IntPtr) this.NativePtr->PlatformUserData;
      set => this.NativePtr->PlatformUserData = (void*) value;
    }

    public unsafe IntPtr PlatformHandle
    {
      get => (IntPtr) this.NativePtr->PlatformHandle;
      set => this.NativePtr->PlatformHandle = (void*) value;
    }

    public unsafe IntPtr PlatformHandleRaw
    {
      get => (IntPtr) this.NativePtr->PlatformHandleRaw;
      set => this.NativePtr->PlatformHandleRaw = (void*) value;
    }

    public unsafe ref bool PlatformRequestMove
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->PlatformRequestMove);
    }

    public unsafe ref bool PlatformRequestResize
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->PlatformRequestResize);
    }

    public unsafe ref bool PlatformRequestClose
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->PlatformRequestClose);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiViewport_destroy(this.NativePtr);

    public unsafe Vector2 GetCenter()
    {
      Vector2 center;
      ImGuiNative.ImGuiViewport_GetCenter(&center, this.NativePtr);
      return center;
    }

    public unsafe Vector2 GetWorkCenter()
    {
      Vector2 workCenter;
      ImGuiNative.ImGuiViewport_GetWorkCenter(&workCenter, this.NativePtr);
      return workCenter;
    }
  }
}
