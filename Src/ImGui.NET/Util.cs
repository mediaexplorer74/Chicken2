// Decompiled with JetBrains decompiler
// Type: ImGuiNET.Util
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  internal static class Util
  {
    internal const int StackAllocationSizeLimit = 2048;

    public static unsafe string StringFromPtr(byte* ptr)
    {
      int byteCount = 0;
      while (ptr[byteCount] != (byte) 0)
        ++byteCount;
      return Encoding.UTF8.GetString(ptr, byteCount);
    }

    internal static unsafe bool AreStringsEqual(byte* a, int aLength, byte* b)
    {
      for (int index = 0; index < aLength; ++index)
      {
        if ((int) a[index] != (int) b[index])
          return false;
      }
      return b[aLength] == (byte) 0;
    }

    internal static unsafe byte* Allocate(int byteCount)
    {
      return (byte*) (void*) Marshal.AllocHGlobal(byteCount);
    }

    internal static unsafe void Free(byte* ptr) => Marshal.FreeHGlobal((IntPtr) (void*) ptr);

    internal static unsafe int CalcSizeInUtf8(string s, int start, int length)
    {
      if (start < 0 || length < 0 || start + length > s.Length)
        throw new ArgumentOutOfRangeException();
      IntPtr num;
      if (s == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &s.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      return Encoding.UTF8.GetByteCount((char*) (num + (IntPtr) start * 2), length);
    }

    internal static unsafe int GetUtf8(string s, byte* utf8Bytes, int utf8ByteCount)
    {
      IntPtr chars;
      if (s == null)
      {
        chars = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &s.GetPinnableReference())
          chars = (IntPtr) chPtr;
      }
      return Encoding.UTF8.GetBytes((char*) chars, s.Length, utf8Bytes, utf8ByteCount);
    }

    internal static unsafe int GetUtf8(
      string s,
      int start,
      int length,
      byte* utf8Bytes,
      int utf8ByteCount)
    {
      if (start < 0 || length < 0 || start + length > s.Length)
        throw new ArgumentOutOfRangeException();
      IntPtr num;
      if (s == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &s.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      return Encoding.UTF8.GetBytes((char*) (num + (IntPtr) start * 2), length, utf8Bytes, utf8ByteCount);
    }
  }
}
