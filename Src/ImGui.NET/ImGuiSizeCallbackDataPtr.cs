// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiSizeCallbackDataPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiSizeCallbackDataPtr
  {
    public unsafe ImGuiSizeCallbackData* NativePtr { get; }

    public unsafe ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImGuiSizeCallbackDataPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiSizeCallbackData*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr)
    {
      return new ImGuiSizeCallbackDataPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiSizeCallbackData*(
      ImGuiSizeCallbackDataPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiSizeCallbackDataPtr(IntPtr nativePtr)
    {
      return new ImGuiSizeCallbackDataPtr(nativePtr);
    }

    public unsafe IntPtr UserData
    {
      get => (IntPtr) this.NativePtr->UserData;
      set => this.NativePtr->UserData = (void*) value;
    }

    public unsafe ref Vector2 Pos => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->Pos);

    public unsafe ref Vector2 CurrentSize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->CurrentSize);
    }

    public unsafe ref Vector2 DesiredSize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->DesiredSize);
    }
  }
}
