// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiStylePtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiStylePtr
  {
    public unsafe ImGuiStyle* NativePtr { get; }

    public unsafe ImGuiStylePtr(ImGuiStyle* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiStylePtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImGuiStyle*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImGuiStylePtr(ImGuiStyle* nativePtr)
    {
      return new ImGuiStylePtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiStyle*(ImGuiStylePtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImGuiStylePtr(IntPtr nativePtr) => new ImGuiStylePtr(nativePtr);

    public unsafe ref float Alpha => ref Unsafe.AsRef<float>((void*) &this.NativePtr->Alpha);

    public unsafe ref float DisabledAlpha
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->DisabledAlpha);
    }

    public unsafe ref Vector2 WindowPadding
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->WindowPadding);
    }

    public unsafe ref float WindowRounding
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->WindowRounding);
    }

    public unsafe ref float WindowBorderSize
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->WindowBorderSize);
    }

    public unsafe ref Vector2 WindowMinSize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->WindowMinSize);
    }

    public unsafe ref Vector2 WindowTitleAlign
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->WindowTitleAlign);
    }

    public unsafe ref ImGuiDir WindowMenuButtonPosition
    {
      get => ref Unsafe.AsRef<ImGuiDir>((void*) &this.NativePtr->WindowMenuButtonPosition);
    }

    public unsafe ref float ChildRounding
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ChildRounding);
    }

    public unsafe ref float ChildBorderSize
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ChildBorderSize);
    }

    public unsafe ref float PopupRounding
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->PopupRounding);
    }

    public unsafe ref float PopupBorderSize
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->PopupBorderSize);
    }

    public unsafe ref Vector2 FramePadding
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->FramePadding);
    }

    public unsafe ref float FrameRounding
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->FrameRounding);
    }

    public unsafe ref float FrameBorderSize
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->FrameBorderSize);
    }

    public unsafe ref Vector2 ItemSpacing
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->ItemSpacing);
    }

    public unsafe ref Vector2 ItemInnerSpacing
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->ItemInnerSpacing);
    }

    public unsafe ref Vector2 CellPadding
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->CellPadding);
    }

    public unsafe ref Vector2 TouchExtraPadding
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->TouchExtraPadding);
    }

    public unsafe ref float IndentSpacing
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->IndentSpacing);
    }

    public unsafe ref float ColumnsMinSpacing
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ColumnsMinSpacing);
    }

    public unsafe ref float ScrollbarSize
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ScrollbarSize);
    }

    public unsafe ref float ScrollbarRounding
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ScrollbarRounding);
    }

    public unsafe ref float GrabMinSize
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->GrabMinSize);
    }

    public unsafe ref float GrabRounding
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->GrabRounding);
    }

    public unsafe ref float LogSliderDeadzone
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->LogSliderDeadzone);
    }

    public unsafe ref float TabRounding
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->TabRounding);
    }

    public unsafe ref float TabBorderSize
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->TabBorderSize);
    }

    public unsafe ref float TabMinWidthForCloseButton
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->TabMinWidthForCloseButton);
    }

    public unsafe ref ImGuiDir ColorButtonPosition
    {
      get => ref Unsafe.AsRef<ImGuiDir>((void*) &this.NativePtr->ColorButtonPosition);
    }

    public unsafe ref Vector2 ButtonTextAlign
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->ButtonTextAlign);
    }

    public unsafe ref Vector2 SelectableTextAlign
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->SelectableTextAlign);
    }

    public unsafe ref Vector2 DisplayWindowPadding
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->DisplayWindowPadding);
    }

    public unsafe ref Vector2 DisplaySafeAreaPadding
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->DisplaySafeAreaPadding);
    }

    public unsafe ref float MouseCursorScale
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->MouseCursorScale);
    }

    public unsafe ref bool AntiAliasedLines
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->AntiAliasedLines);
    }

    public unsafe ref bool AntiAliasedLinesUseTex
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->AntiAliasedLinesUseTex);
    }

    public unsafe ref bool AntiAliasedFill
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->AntiAliasedFill);
    }

    public unsafe ref float CurveTessellationTol
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->CurveTessellationTol);
    }

    public unsafe ref float CircleTessellationMaxError
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->CircleTessellationMaxError);
    }

    public unsafe RangeAccessor<Vector4> Colors
    {
      get => new RangeAccessor<Vector4>((void*) &this.NativePtr->Colors_0, 55);
    }

    public unsafe void Destroy() => ImGuiNative.ImGuiStyle_destroy(this.NativePtr);

    public unsafe void ScaleAllSizes(float scale_factor)
    {
      ImGuiNative.ImGuiStyle_ScaleAllSizes(this.NativePtr, scale_factor);
    }
  }
}
