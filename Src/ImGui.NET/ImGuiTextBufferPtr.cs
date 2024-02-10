// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTextBufferPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiTextBufferPtr
  {
    public unsafe ImGuiTextBuffer* NativePtr { get; }

    public unsafe ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiTextBufferPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiTextBuffer*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr)
    {
      return new ImGuiTextBufferPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiTextBuffer*(ImGuiTextBufferPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiTextBufferPtr(IntPtr nativePtr)
    {
      return new ImGuiTextBufferPtr(nativePtr);
    }

    public unsafe ImVector<byte> Buf => new ImVector<byte>(this.NativePtr->Buf);

    public unsafe void append(string str)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte* str_end = (byte*) null;
      ImGuiNative.ImGuiTextBuffer_append(this.NativePtr, numPtr, str_end);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public unsafe void appendf(string fmt)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (fmt != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(fmt);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(fmt, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.ImGuiTextBuffer_appendf(this.NativePtr, numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public unsafe string begin()
    {
      return Util.StringFromPtr(ImGuiNative.ImGuiTextBuffer_begin(this.NativePtr));
    }

    public unsafe string c_str()
    {
      return Util.StringFromPtr(ImGuiNative.ImGuiTextBuffer_c_str(this.NativePtr));
    }

    public unsafe void clear() => ImGuiNative.ImGuiTextBuffer_clear(this.NativePtr);

    public unsafe void Destroy() => ImGuiNative.ImGuiTextBuffer_destroy(this.NativePtr);

    public unsafe bool empty() => ImGuiNative.ImGuiTextBuffer_empty(this.NativePtr) > (byte) 0;

    public unsafe string end()
    {
      return Util.StringFromPtr(ImGuiNative.ImGuiTextBuffer_end(this.NativePtr));
    }

    public unsafe void reserve(int capacity)
    {
      ImGuiNative.ImGuiTextBuffer_reserve(this.NativePtr, capacity);
    }

    public unsafe int size() => ImGuiNative.ImGuiTextBuffer_size(this.NativePtr);
  }
}
