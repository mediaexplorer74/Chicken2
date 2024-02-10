// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiStoragePtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiStoragePtr
  {
    public unsafe ImGuiStorage* NativePtr { get; }

    public unsafe ImGuiStoragePtr(ImGuiStorage* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiStoragePtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiStorage*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiStoragePtr(ImGuiStorage* nativePtr)
    {
      return new ImGuiStoragePtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiStorage*(ImGuiStoragePtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiStoragePtr(IntPtr nativePtr)
    {
      return new ImGuiStoragePtr(nativePtr);
    }

    public unsafe ImPtrVector<ImGuiStoragePairPtr> Data
    {
      get
      {
        return new ImPtrVector<ImGuiStoragePairPtr>(this.NativePtr->Data, Unsafe.SizeOf<ImGuiStoragePair>());
      }
    }

    public unsafe void BuildSortByKey() => ImGuiNative.ImGuiStorage_BuildSortByKey(this.NativePtr);

    public unsafe void Clear() => ImGuiNative.ImGuiStorage_Clear(this.NativePtr);

    public unsafe bool GetBool(uint key)
    {
      byte default_val = 0;
      return ImGuiNative.ImGuiStorage_GetBool(this.NativePtr, key, default_val) > (byte) 0;
    }

    public unsafe bool GetBool(uint key, bool default_val)
    {
      byte default_val1 = default_val ? (byte) 1 : (byte) 0;
      return ImGuiNative.ImGuiStorage_GetBool(this.NativePtr, key, default_val1) > (byte) 0;
    }

    public unsafe byte* GetBoolRef(uint key)
    {
      byte default_val = 0;
      return ImGuiNative.ImGuiStorage_GetBoolRef(this.NativePtr, key, default_val);
    }

    public unsafe byte* GetBoolRef(uint key, bool default_val)
    {
      byte default_val1 = default_val ? (byte) 1 : (byte) 0;
      return ImGuiNative.ImGuiStorage_GetBoolRef(this.NativePtr, key, default_val1);
    }

    public unsafe float GetFloat(uint key)
    {
      float default_val = 0.0f;
      return ImGuiNative.ImGuiStorage_GetFloat(this.NativePtr, key, default_val);
    }

    public unsafe float GetFloat(uint key, float default_val)
    {
      return ImGuiNative.ImGuiStorage_GetFloat(this.NativePtr, key, default_val);
    }

    public unsafe float* GetFloatRef(uint key)
    {
      float default_val = 0.0f;
      return ImGuiNative.ImGuiStorage_GetFloatRef(this.NativePtr, key, default_val);
    }

    public unsafe float* GetFloatRef(uint key, float default_val)
    {
      return ImGuiNative.ImGuiStorage_GetFloatRef(this.NativePtr, key, default_val);
    }

    public unsafe int GetInt(uint key)
    {
      int default_val = 0;
      return ImGuiNative.ImGuiStorage_GetInt(this.NativePtr, key, default_val);
    }

    public unsafe int GetInt(uint key, int default_val)
    {
      return ImGuiNative.ImGuiStorage_GetInt(this.NativePtr, key, default_val);
    }

    public unsafe int* GetIntRef(uint key)
    {
      int default_val = 0;
      return ImGuiNative.ImGuiStorage_GetIntRef(this.NativePtr, key, default_val);
    }

    public unsafe int* GetIntRef(uint key, int default_val)
    {
      return ImGuiNative.ImGuiStorage_GetIntRef(this.NativePtr, key, default_val);
    }

    public unsafe IntPtr GetVoidPtr(uint key)
    {
      return (IntPtr) ImGuiNative.ImGuiStorage_GetVoidPtr(this.NativePtr, key);
    }

    public unsafe void** GetVoidPtrRef(uint key)
    {
      void* default_val = (void*) null;
      return ImGuiNative.ImGuiStorage_GetVoidPtrRef(this.NativePtr, key, default_val);
    }

    public unsafe void** GetVoidPtrRef(uint key, IntPtr default_val)
    {
      void* pointer = default_val.ToPointer();
      return ImGuiNative.ImGuiStorage_GetVoidPtrRef(this.NativePtr, key, pointer);
    }

    public unsafe void SetAllInt(int val)
    {
      ImGuiNative.ImGuiStorage_SetAllInt(this.NativePtr, val);
    }

    public unsafe void SetBool(uint key, bool val)
    {
      byte val1 = val ? (byte) 1 : (byte) 0;
      ImGuiNative.ImGuiStorage_SetBool(this.NativePtr, key, val1);
    }

    public unsafe void SetFloat(uint key, float val)
    {
      ImGuiNative.ImGuiStorage_SetFloat(this.NativePtr, key, val);
    }

    public unsafe void SetInt(uint key, int val)
    {
      ImGuiNative.ImGuiStorage_SetInt(this.NativePtr, key, val);
    }

    public unsafe void SetVoidPtr(uint key, IntPtr val)
    {
      void* pointer = val.ToPointer();
      ImGuiNative.ImGuiStorage_SetVoidPtr(this.NativePtr, key, pointer);
    }
  }
}
