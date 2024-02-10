// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiStoragePairPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiStoragePairPtr
  {
    public unsafe ImGuiStoragePair* NativePtr { get; }

    public unsafe ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiStoragePairPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiStoragePair*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr)
    {
      return new ImGuiStoragePairPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiStoragePair*(ImGuiStoragePairPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiStoragePairPtr(IntPtr nativePtr)
    {
      return new ImGuiStoragePairPtr(nativePtr);
    }
  }
}
