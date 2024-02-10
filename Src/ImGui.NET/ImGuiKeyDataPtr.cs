// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiKeyDataPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiKeyDataPtr
  {
    public unsafe ImGuiKeyData* NativePtr { get; }

    public unsafe ImGuiKeyDataPtr(ImGuiKeyData* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiKeyDataPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiKeyData*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiKeyDataPtr(ImGuiKeyData* nativePtr)
    {
      return new ImGuiKeyDataPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiKeyData*(ImGuiKeyDataPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiKeyDataPtr(IntPtr nativePtr)
    {
      return new ImGuiKeyDataPtr(nativePtr);
    }

    public unsafe ref bool Down => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->Down);

    public unsafe ref float DownDuration
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->DownDuration);
    }

    public unsafe ref float DownDurationPrev
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->DownDurationPrev);
    }

    public unsafe ref float AnalogValue
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->AnalogValue);
    }
  }
}
