// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImVector`1
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImVector<T>
  {
    public readonly int Size;
    public readonly int Capacity;
    public readonly IntPtr Data;

    public ImVector(ImVector vector)
    {
      this.Size = vector.Size;
      this.Capacity = vector.Capacity;
      this.Data = vector.Data;
    }

    public ImVector(int size, int capacity, IntPtr data)
    {
      this.Size = size;
      this.Capacity = capacity;
      this.Data = data;
    }

    public unsafe ref T this[int index]
    {
      get => ref Unsafe.AsRef<T>((void*) ((IntPtr) (void*) this.Data + index * Unsafe.SizeOf<T>()));
    }
  }
}
