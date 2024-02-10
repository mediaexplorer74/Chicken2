// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTextFilterPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiTextFilterPtr
  {
    public unsafe ImGuiTextFilter* NativePtr { get; }

    public unsafe ImGuiTextFilterPtr(ImGuiTextFilter* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiTextFilterPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiTextFilter*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiTextFilterPtr(ImGuiTextFilter* nativePtr)
    {
      return new ImGuiTextFilterPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiTextFilter*(ImGuiTextFilterPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiTextFilterPtr(IntPtr nativePtr)
    {
      return new ImGuiTextFilterPtr(nativePtr);
    }

    public unsafe RangeAccessor<byte> InputBuf
    {
      get => new RangeAccessor<byte>((void*) this.NativePtr->InputBuf, 256);
    }

    public unsafe ImPtrVector<ImGuiTextRangePtr> Filters
    {
      get
      {
        return new ImPtrVector<ImGuiTextRangePtr>(this.NativePtr->Filters, Unsafe.SizeOf<ImGuiTextRange>());
      }
    }

    public unsafe ref int CountGrep => ref Unsafe.AsRef<int>((void*) &this.NativePtr->CountGrep);

    public unsafe void Build() => ImGuiNative.ImGuiTextFilter_Build(this.NativePtr);

    public unsafe void Clear() => ImGuiNative.ImGuiTextFilter_Clear(this.NativePtr);

    public unsafe void Destroy() => ImGuiNative.ImGuiTextFilter_destroy(this.NativePtr);

    public unsafe bool Draw()
    {
      int byteCount = Encoding.UTF8.GetByteCount("Filter(inc,-exc)");
      byte* numPtr = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8 = Util.GetUtf8("Filter(inc,-exc)", numPtr, byteCount);
      numPtr[utf8] = (byte) 0;
      float width = 0.0f;
      int num = (int) ImGuiNative.ImGuiTextFilter_Draw(this.NativePtr, numPtr, width);
      if (byteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public unsafe bool Draw(string label)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      float width = 0.0f;
      int num = (int) ImGuiNative.ImGuiTextFilter_Draw(this.NativePtr, numPtr, width);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public unsafe bool Draw(string label, float width)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.ImGuiTextFilter_Draw(this.NativePtr, numPtr, width);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public unsafe bool IsActive()
    {
      return ImGuiNative.ImGuiTextFilter_IsActive(this.NativePtr) > (byte) 0;
    }

    public unsafe bool PassFilter(string text)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (text != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(text);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(text, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte* text_end = (byte*) null;
      int num = (int) ImGuiNative.ImGuiTextFilter_PassFilter(this.NativePtr, numPtr, text_end);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }
  }
}
