// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiPlatformImeDataPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiPlatformImeDataPtr
  {
    public unsafe ImGuiPlatformImeData* NativePtr { get; }

    public unsafe ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImGuiPlatformImeDataPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiPlatformImeData*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr)
    {
      return new ImGuiPlatformImeDataPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiPlatformImeData*(ImGuiPlatformImeDataPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiPlatformImeDataPtr(IntPtr nativePtr)
    {
      return new ImGuiPlatformImeDataPtr(nativePtr);
    }

    public unsafe ref bool WantVisible
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->WantVisible);
    }

    public unsafe ref Vector2 InputPos
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->InputPos);
    }

    public unsafe ref float InputLineHeight
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->InputLineHeight);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiPlatformImeData_destroy(this.NativePtr);
  }
}
