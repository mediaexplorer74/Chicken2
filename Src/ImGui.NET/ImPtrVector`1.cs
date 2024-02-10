// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImPtrVector`1
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImPtrVector<T>
  {
    public readonly int Size;
    public readonly int Capacity;
    public readonly IntPtr Data;
    private readonly int _stride;

    public ImPtrVector(ImVector vector, int stride)
      : this(vector.Size, vector.Capacity, vector.Data, stride)
    {
    }

    public ImPtrVector(int size, int capacity, IntPtr data, int stride)
    {
      this.Size = size;
      this.Capacity = capacity;
      this.Data = data;
      this._stride = stride;
    }

    public unsafe T this[int index]
    {
      get => Unsafe.Read<T>((void*) &(byte*) ((IntPtr) (void*) this.Data + index * this._stride));
    }
  }
}
