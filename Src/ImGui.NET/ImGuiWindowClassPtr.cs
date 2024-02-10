// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiWindowClassPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiWindowClassPtr
  {
    public unsafe ImGuiWindowClass* NativePtr { get; }

    public unsafe ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiWindowClassPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiWindowClass*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr)
    {
      return new ImGuiWindowClassPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiWindowClass*(ImGuiWindowClassPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiWindowClassPtr(IntPtr nativePtr)
    {
      return new ImGuiWindowClassPtr(nativePtr);
    }

    public unsafe ref uint ClassId => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->ClassId);

    public unsafe ref uint ParentViewportId
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->ParentViewportId);
    }

    public unsafe ref ImGuiViewportFlags ViewportFlagsOverrideSet
    {
      get
      {
        return ref Unsafe.AsRef<ImGuiViewportFlags>((void*) &this.NativePtr->ViewportFlagsOverrideSet);
      }
    }

    public unsafe ref ImGuiViewportFlags ViewportFlagsOverrideClear
    {
      get
      {
        return ref Unsafe.AsRef<ImGuiViewportFlags>((void*) &this.NativePtr->ViewportFlagsOverrideClear);
      }
    }

    public unsafe ref ImGuiTabItemFlags TabItemFlagsOverrideSet
    {
      get => ref Unsafe.AsRef<ImGuiTabItemFlags>((void*) &this.NativePtr->TabItemFlagsOverrideSet);
    }

    public unsafe ref ImGuiDockNodeFlags DockNodeFlagsOverrideSet
    {
      get
      {
        return ref Unsafe.AsRef<ImGuiDockNodeFlags>((void*) &this.NativePtr->DockNodeFlagsOverrideSet);
      }
    }

    public unsafe ref bool DockingAlwaysTabBar
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->DockingAlwaysTabBar);
    }

    public unsafe ref bool DockingAllowUnclassed
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->DockingAllowUnclassed);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiWindowClass_destroy(this.NativePtr);
  }
}
