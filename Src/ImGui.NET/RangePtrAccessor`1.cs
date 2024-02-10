// Decompiled with JetBrains decompiler
// Type: ImGuiNET.RangePtrAccessor`1
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct RangePtrAccessor<T> where T : struct
  {
    public readonly unsafe void* Data;
    public readonly int Count;

    public unsafe RangePtrAccessor(IntPtr data, int count)
      : this(data.ToPointer(), count)
    {
    }

    public unsafe RangePtrAccessor(void* data, int count)
    {
      this.Data = data;
      this.Count = count;
    }

    public unsafe T this[int index]
    {
      get
      {
        return index >= 0 && index < this.Count ? Unsafe.Read<T>((void*) ((IntPtr) this.Data + sizeof (void*) * index)) : throw new IndexOutOfRangeException();
      }
    }
  }
}
