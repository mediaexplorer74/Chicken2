// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImVector
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImVector
  {
    public readonly int Size;
    public readonly int Capacity;
    public readonly IntPtr Data;

    public unsafe ref T Ref<T>(int index)
    {
      return ref Unsafe.AsRef<T>((void*) ((IntPtr) (void*) this.Data + index * Unsafe.SizeOf<T>()));
    }

    public unsafe IntPtr Address<T>(int index)
    {
      return (IntPtr) (void*) ((IntPtr) (void*) this.Data + index * Unsafe.SizeOf<T>());
    }
  }
}
