// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiListClipperPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiListClipperPtr
  {
    public unsafe ImGuiListClipper* NativePtr { get; }

    public unsafe ImGuiListClipperPtr(ImGuiListClipper* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiListClipperPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiListClipper*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiListClipperPtr(ImGuiListClipper* nativePtr)
    {
      return new ImGuiListClipperPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiListClipper*(ImGuiListClipperPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiListClipperPtr(IntPtr nativePtr)
    {
      return new ImGuiListClipperPtr(nativePtr);
    }

    public unsafe ref int DisplayStart
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->DisplayStart);
    }

    public unsafe ref int DisplayEnd => ref Unsafe.AsRef<int>((void*) &this.NativePtr->DisplayEnd);

    public unsafe ref int ItemsCount => ref Unsafe.AsRef<int>((void*) &this.NativePtr->ItemsCount);

    public unsafe ref float ItemsHeight
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ItemsHeight);
    }

    public unsafe ref float StartPosY
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->StartPosY);
    }

    public unsafe IntPtr TempData
    {
      get => (IntPtr) this.NativePtr->TempData;
      set => this.NativePtr->TempData = (void*) value;
    }

    public unsafe void Begin(int items_count)
    {
      float items_height = -1f;
      ImGuiNative.ImGuiListClipper_Begin(this.NativePtr, items_count, items_height);
    }

    public unsafe void Begin(int items_count, float items_height)
    {
      ImGuiNative.ImGuiListClipper_Begin(this.NativePtr, items_count, items_height);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiListClipper_destroy(this.NativePtr);

    public unsafe void End() => ImGuiNative.ImGuiListClipper_End(this.NativePtr);

    public unsafe void ForceDisplayRangeByIndices(int item_min, int item_max)
    {
      ImGuiNative.ImGuiListClipper_ForceDisplayRangeByIndices(this.NativePtr, item_min, item_max);
    }

    public unsafe bool Step() => ImGuiNative.ImGuiListClipper_Step(this.NativePtr) > (byte) 0;
  }
}
