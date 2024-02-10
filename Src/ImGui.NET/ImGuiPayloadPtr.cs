// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiPayloadPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiPayloadPtr
  {
    public unsafe ImGuiPayload* NativePtr { get; }

    public unsafe ImGuiPayloadPtr(ImGuiPayload* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiPayloadPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiPayload*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiPayloadPtr(ImGuiPayload* nativePtr)
    {
      return new ImGuiPayloadPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiPayload*(ImGuiPayloadPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiPayloadPtr(IntPtr nativePtr)
    {
      return new ImGuiPayloadPtr(nativePtr);
    }

    public unsafe IntPtr Data
    {
      get => (IntPtr) this.NativePtr->Data;
      set => this.NativePtr->Data = (void*) value;
    }

    public unsafe ref int DataSize => ref Unsafe.AsRef<int>((void*) &this.NativePtr->DataSize);

    public unsafe ref uint SourceId => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->SourceId);

    public unsafe ref uint SourceParentId
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->SourceParentId);
    }

    public unsafe ref int DataFrameCount
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->DataFrameCount);
    }

    public unsafe RangeAccessor<byte> DataType
    {
      get => new RangeAccessor<byte>((void*) this.NativePtr->DataType, 33);
    }

    public unsafe ref bool Preview => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->Preview);

    public unsafe ref bool Delivery => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->Delivery);

    public unsafe void Clear() => ImGuiNative.ImGuiPayload_Clear(this.NativePtr);

    public unsafe void Destroy() => ImGuiNative.ImGuiPayload_destroy(this.NativePtr);

    public unsafe bool IsDataType(string type)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (type != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(type);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(type, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.ImGuiPayload_IsDataType(this.NativePtr, numPtr);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public unsafe bool IsDelivery()
    {
      return ImGuiNative.ImGuiPayload_IsDelivery(this.NativePtr) > (byte) 0;
    }

    public unsafe bool IsPreview() => ImGuiNative.ImGuiPayload_IsPreview(this.NativePtr) > (byte) 0;
  }
}
