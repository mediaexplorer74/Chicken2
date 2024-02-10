// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiPlatformMonitorPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiPlatformMonitorPtr
  {
    public unsafe ImGuiPlatformMonitor* NativePtr { get; }

    public unsafe ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImGuiPlatformMonitorPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiPlatformMonitor*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr)
    {
      return new ImGuiPlatformMonitorPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiPlatformMonitor*(ImGuiPlatformMonitorPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiPlatformMonitorPtr(IntPtr nativePtr)
    {
      return new ImGuiPlatformMonitorPtr(nativePtr);
    }

    public unsafe ref Vector2 MainPos
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->MainPos);
    }

    public unsafe ref Vector2 MainSize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->MainSize);
    }

    public unsafe ref Vector2 WorkPos
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->WorkPos);
    }

    public unsafe ref Vector2 WorkSize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->WorkSize);
    }

    public unsafe ref float DpiScale => ref Unsafe.AsRef<float>((void*) &this.NativePtr->DpiScale);

    public unsafe void Destroy() => ImGuiNative.ImGuiPlatformMonitor_destroy(this.NativePtr);
  }
}
