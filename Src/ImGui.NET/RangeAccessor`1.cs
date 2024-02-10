// Decompiled with JetBrains decompiler
// Type: ImGuiNET.RangeAccessor`1
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct RangeAccessor<T> where T : struct
  {
    private static readonly int s_sizeOfT = Unsafe.SizeOf<T>();
    public readonly unsafe void* Data;
    public readonly int Count;

    public unsafe RangeAccessor(IntPtr data, int count)
      : this(data.ToPointer(), count)
    {
    }

    public unsafe RangeAccessor(void* data, int count)
    {
      this.Data = data;
      this.Count = count;
    }

    public unsafe ref T this[int index]
    {
      get
      {
        if (index < 0 || index >= this.Count)
          throw new IndexOutOfRangeException();
        return ref Unsafe.AsRef<T>((void*) ((IntPtr) this.Data + RangeAccessor<T>.s_sizeOfT * index));
      }
    }
  }
}
