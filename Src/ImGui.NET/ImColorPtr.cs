// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImColorPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImColorPtr
  {
    public unsafe ImColor* NativePtr { get; }

    public unsafe ImColorPtr(ImColor* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImColorPtr(IntPtr nativePtr) => this.NativePtr = (ImColor*) (void*) nativePtr;

    public static unsafe implicit operator ImColorPtr(ImColor* nativePtr)
    {
      return new ImColorPtr(nativePtr);
    }

    public static unsafe implicit operator ImColor*(ImColorPtr wrappedPtr) => wrappedPtr.NativePtr;

    public static implicit operator ImColorPtr(IntPtr nativePtr) => new ImColorPtr(nativePtr);

    public unsafe ref Vector4 Value => ref Unsafe.AsRef<Vector4>((void*) &this.NativePtr->Value);

    public unsafe void Destroy() => ImGuiNative.ImColor_destroy(this.NativePtr);

    public unsafe ImColor HSV(float h, float s, float v)
    {
      float a = 1f;
      ImColor imColor;
      ImGuiNative.ImColor_HSV(&imColor, h, s, v, a);
      return imColor;
    }

    public unsafe ImColor HSV(float h, float s, float v, float a)
    {
      ImColor imColor;
      ImGuiNative.ImColor_HSV(&imColor, h, s, v, a);
      return imColor;
    }

    public unsafe void SetHSV(float h, float s, float v)
    {
      float a = 1f;
      ImGuiNative.ImColor_SetHSV(this.NativePtr, h, s, v, a);
    }

    public unsafe void SetHSV(float h, float s, float v, float a)
    {
      ImGuiNative.ImColor_SetHSV(this.NativePtr, h, s, v, a);
    }
  }
}
