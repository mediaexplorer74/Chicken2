// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTableSortSpecsPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiTableSortSpecsPtr
  {
    public unsafe ImGuiTableSortSpecs* NativePtr { get; }

    public unsafe ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImGuiTableSortSpecsPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiTableSortSpecs*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr)
    {
      return new ImGuiTableSortSpecsPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiTableSortSpecs*(ImGuiTableSortSpecsPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiTableSortSpecsPtr(IntPtr nativePtr)
    {
      return new ImGuiTableSortSpecsPtr(nativePtr);
    }

    public unsafe ImGuiTableColumnSortSpecsPtr Specs
    {
      get => new ImGuiTableColumnSortSpecsPtr(this.NativePtr->Specs);
    }

    public unsafe ref int SpecsCount => ref Unsafe.AsRef<int>((void*) &this.NativePtr->SpecsCount);

    public unsafe ref bool SpecsDirty
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->SpecsDirty);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiTableSortSpecs_destroy(this.NativePtr);
  }
}
