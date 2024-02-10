// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiTableColumnSortSpecsPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiTableColumnSortSpecsPtr
  {
    public unsafe ImGuiTableColumnSortSpecs* NativePtr { get; }

    public unsafe ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr)
    {
      this.NativePtr = nativePtr;
    }

    public unsafe ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiTableColumnSortSpecs*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiTableColumnSortSpecsPtr(
      ImGuiTableColumnSortSpecs* nativePtr)
    {
      return new ImGuiTableColumnSortSpecsPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiTableColumnSortSpecs*(
      ImGuiTableColumnSortSpecsPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr)
    {
      return new ImGuiTableColumnSortSpecsPtr(nativePtr);
    }

    public unsafe ref uint ColumnUserID
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->ColumnUserID);
    }

    public unsafe ref short ColumnIndex
    {
      get => ref Unsafe.AsRef<short>((void*) &this.NativePtr->ColumnIndex);
    }

    public unsafe ref short SortOrder
    {
      get => ref Unsafe.AsRef<short>((void*) &this.NativePtr->SortOrder);
    }

    public unsafe ref ImGuiSortDirection SortDirection
    {
      get => ref Unsafe.AsRef<ImGuiSortDirection>((void*) &this.NativePtr->SortDirection);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiTableColumnSortSpecs_destroy(this.NativePtr);
  }
}
