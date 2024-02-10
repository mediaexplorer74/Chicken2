// Decompiled with JetBrains decompiler
// Type: ImGuiNET.StbTexteditRowPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct StbTexteditRowPtr
  {
    public unsafe StbTexteditRow* NativePtr { get; }

    public unsafe StbTexteditRowPtr(StbTexteditRow* nativePtr) => this.NativePtr = nativePtr;

    public unsafe StbTexteditRowPtr(IntPtr nativePtr)
    {
      this.NativePtr = (StbTexteditRow*) (void*) nativePtr;
    }

    public static unsafe implicit operator StbTexteditRowPtr(StbTexteditRow* nativePtr)
    {
      return new StbTexteditRowPtr(nativePtr);
    }

    public static unsafe implicit operator StbTexteditRow*(StbTexteditRowPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator StbTexteditRowPtr(IntPtr nativePtr)
    {
      return new StbTexteditRowPtr(nativePtr);
    }

    public unsafe ref float x0 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->x0);

    public unsafe ref float x1 => ref Unsafe.AsRef<float>((void*) &this.NativePtr->x1);

    public unsafe ref float baseline_y_delta
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->baseline_y_delta);
    }

    public unsafe ref float ymin => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ymin);

    public unsafe ref float ymax => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ymax);

    public unsafe ref int num_chars => ref Unsafe.AsRef<int>((void*) &this.NativePtr->num_chars);
  }
}
