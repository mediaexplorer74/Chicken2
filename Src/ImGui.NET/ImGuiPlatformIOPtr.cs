// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiPlatformIOPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiPlatformIOPtr
  {
    public unsafe ImGuiPlatformIO* NativePtr { get; }

    public unsafe ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiPlatformIOPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiPlatformIO*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr)
    {
      return new ImGuiPlatformIOPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiPlatformIO*(ImGuiPlatformIOPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiPlatformIOPtr(IntPtr nativePtr)
    {
      return new ImGuiPlatformIOPtr(nativePtr);
    }

    public unsafe ref IntPtr Platform_CreateWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_CreateWindow);
    }

    public unsafe ref IntPtr Platform_DestroyWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_DestroyWindow);
    }

    public unsafe ref IntPtr Platform_ShowWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_ShowWindow);
    }

    public unsafe ref IntPtr Platform_SetWindowPos
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_SetWindowPos);
    }

    public unsafe ref IntPtr Platform_GetWindowPos
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_GetWindowPos);
    }

    public unsafe ref IntPtr Platform_SetWindowSize
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_SetWindowSize);
    }

    public unsafe ref IntPtr Platform_GetWindowSize
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_GetWindowSize);
    }

    public unsafe ref IntPtr Platform_SetWindowFocus
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_SetWindowFocus);
    }

    public unsafe ref IntPtr Platform_GetWindowFocus
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_GetWindowFocus);
    }

    public unsafe ref IntPtr Platform_GetWindowMinimized
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_GetWindowMinimized);
    }

    public unsafe ref IntPtr Platform_SetWindowTitle
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_SetWindowTitle);
    }

    public unsafe ref IntPtr Platform_SetWindowAlpha
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_SetWindowAlpha);
    }

    public unsafe ref IntPtr Platform_UpdateWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_UpdateWindow);
    }

    public unsafe ref IntPtr Platform_RenderWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_RenderWindow);
    }

    public unsafe ref IntPtr Platform_SwapBuffers
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_SwapBuffers);
    }

    public unsafe ref IntPtr Platform_GetWindowDpiScale
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_GetWindowDpiScale);
    }

    public unsafe ref IntPtr Platform_OnChangedViewport
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_OnChangedViewport);
    }

    public unsafe ref IntPtr Platform_CreateVkSurface
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Platform_CreateVkSurface);
    }

    public unsafe ref IntPtr Renderer_CreateWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Renderer_CreateWindow);
    }

    public unsafe ref IntPtr Renderer_DestroyWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Renderer_DestroyWindow);
    }

    public unsafe ref IntPtr Renderer_SetWindowSize
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Renderer_SetWindowSize);
    }

    public unsafe ref IntPtr Renderer_RenderWindow
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Renderer_RenderWindow);
    }

    public unsafe ref IntPtr Renderer_SwapBuffers
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->Renderer_SwapBuffers);
    }

    public unsafe ImPtrVector<ImGuiPlatformMonitorPtr> Monitors
    {
      get
      {
        return new ImPtrVector<ImGuiPlatformMonitorPtr>(this.NativePtr->Monitors, Unsafe.SizeOf<ImGuiPlatformMonitor>());
      }
    }

    public unsafe ImVector<ImGuiViewportPtr> Viewports
    {
      get => new ImVector<ImGuiViewportPtr>(this.NativePtr->Viewports);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiPlatformIO_destroy(this.NativePtr);
  }
}
