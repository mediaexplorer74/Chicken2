// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiInputTextCallbackDataPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiInputTextCallbackDataPtr
  {
    public unsafe ImGuiInputTextCallbackData* NativePtr { get; }

    public unsafe ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImGuiInputTextCallbackDataPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiInputTextCallbackData*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiInputTextCallbackDataPtr(
      ImGuiInputTextCallbackData* nativePtr)
    {
      return new ImGuiInputTextCallbackDataPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiInputTextCallbackData*(
      ImGuiInputTextCallbackDataPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiInputTextCallbackDataPtr(IntPtr nativePtr)
    {
      return new ImGuiInputTextCallbackDataPtr(nativePtr);
    }

    public unsafe ref ImGuiInputTextFlags EventFlag
    {
      get => ref Unsafe.AsRef<ImGuiInputTextFlags>((void*) &this.NativePtr->EventFlag);
    }

    public unsafe ref ImGuiInputTextFlags Flags
    {
      get => ref Unsafe.AsRef<ImGuiInputTextFlags>((void*) &this.NativePtr->Flags);
    }

    public unsafe IntPtr UserData
    {
      get => (IntPtr) this.NativePtr->UserData;
      set => this.NativePtr->UserData = (void*) value;
    }

    public unsafe ref ushort EventChar
    {
      get => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->EventChar);
    }

    public unsafe ref ImGuiKey EventKey
    {
      get => ref Unsafe.AsRef<ImGuiKey>((void*) &this.NativePtr->EventKey);
    }

    public unsafe IntPtr Buf
    {
      get => (IntPtr) (void*) this.NativePtr->Buf;
      set => this.NativePtr->Buf = (byte*) (void*) value;
    }

    public unsafe ref int BufTextLen => ref Unsafe.AsRef<int>((void*) &this.NativePtr->BufTextLen);

    public unsafe ref int BufSize => ref Unsafe.AsRef<int>((void*) &this.NativePtr->BufSize);

    public unsafe ref bool BufDirty => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->BufDirty);

    public unsafe ref int CursorPos => ref Unsafe.AsRef<int>((void*) &this.NativePtr->CursorPos);

    public unsafe ref int SelectionStart
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->SelectionStart);
    }

    public unsafe ref int SelectionEnd
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->SelectionEnd);
    }

    public unsafe void ClearSelection()
    {
      ImGuiNative.ImGuiInputTextCallbackData_ClearSelection(this.NativePtr);
    }

    public unsafe void DeleteChars(int pos, int bytes_count)
    {
      ImGuiNative.ImGuiInputTextCallbackData_DeleteChars(this.NativePtr, pos, bytes_count);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiInputTextCallbackData_destroy(this.NativePtr);

    public unsafe bool HasSelection()
    {
      return ImGuiNative.ImGuiInputTextCallbackData_HasSelection(this.NativePtr) > (byte) 0;
    }

    public unsafe void InsertChars(int pos, string text)
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
      ImGuiNative.ImGuiInputTextCallbackData_InsertChars(this.NativePtr, pos, numPtr, text_end);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public unsafe void SelectAll()
    {
      ImGuiNative.ImGuiInputTextCallbackData_SelectAll(this.NativePtr);
    }
  }
}
