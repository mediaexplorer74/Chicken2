// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiIOPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiIOPtr
  {
    public unsafe ImGuiIO* NativePtr { get; }

    public unsafe ImGuiIOPtr(ImGuiIO* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImGuiIOPtr(IntPtr nativePtr) => this.NativePtr = (ImGuiIO*) (void*) nativePtr;

    public static unsafe implicit operator ImGuiIOPtr(ImGuiIO* nativePtr)
    {
      return new ImGuiIOPtr(nativePtr);
    }

    public static unsafe implicit operator ImGuiIO*(ImGuiIOPtr wrappedPtr) => wrappedPtr.NativePtr;

    public static implicit operator ImGuiIOPtr(IntPtr nativePtr) => new ImGuiIOPtr(nativePtr);

    public unsafe ref ImGuiConfigFlags ConfigFlags
    {
      get => ref Unsafe.AsRef<ImGuiConfigFlags>((void*) &this.NativePtr->ConfigFlags);
    }

    public unsafe ref ImGuiBackendFlags BackendFlags
    {
      get => ref Unsafe.AsRef<ImGuiBackendFlags>((void*) &this.NativePtr->BackendFlags);
    }

    public unsafe ref Vector2 DisplaySize
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->DisplaySize);
    }

    public unsafe ref float DeltaTime
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->DeltaTime);
    }

    public unsafe ref float IniSavingRate
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->IniSavingRate);
    }

    public unsafe NullTerminatedString IniFilename
    {
      get => new NullTerminatedString(this.NativePtr->IniFilename);
    }

    public unsafe NullTerminatedString LogFilename
    {
      get => new NullTerminatedString(this.NativePtr->LogFilename);
    }

    public unsafe ref float MouseDoubleClickTime
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->MouseDoubleClickTime);
    }

    public unsafe ref float MouseDoubleClickMaxDist
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->MouseDoubleClickMaxDist);
    }

    public unsafe ref float MouseDragThreshold
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->MouseDragThreshold);
    }

    public unsafe ref float KeyRepeatDelay
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->KeyRepeatDelay);
    }

    public unsafe ref float KeyRepeatRate
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->KeyRepeatRate);
    }

    public unsafe IntPtr UserData
    {
      get => (IntPtr) this.NativePtr->UserData;
      set => this.NativePtr->UserData = (void*) value;
    }

    public unsafe ImFontAtlasPtr Fonts => new ImFontAtlasPtr(this.NativePtr->Fonts);

    public unsafe ref float FontGlobalScale
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->FontGlobalScale);
    }

    public unsafe ref bool FontAllowUserScaling
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->FontAllowUserScaling);
    }

    public unsafe ImFontPtr FontDefault => new ImFontPtr(this.NativePtr->FontDefault);

    public unsafe ref Vector2 DisplayFramebufferScale
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->DisplayFramebufferScale);
    }

    public unsafe ref bool ConfigDockingNoSplit
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigDockingNoSplit);
    }

    public unsafe ref bool ConfigDockingWithShift
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigDockingWithShift);
    }

    public unsafe ref bool ConfigDockingAlwaysTabBar
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigDockingAlwaysTabBar);
    }

    public unsafe ref bool ConfigDockingTransparentPayload
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigDockingTransparentPayload);
    }

    public unsafe ref bool ConfigViewportsNoAutoMerge
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigViewportsNoAutoMerge);
    }

    public unsafe ref bool ConfigViewportsNoTaskBarIcon
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigViewportsNoTaskBarIcon);
    }

    public unsafe ref bool ConfigViewportsNoDecoration
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigViewportsNoDecoration);
    }

    public unsafe ref bool ConfigViewportsNoDefaultParent
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigViewportsNoDefaultParent);
    }

    public unsafe ref bool MouseDrawCursor
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->MouseDrawCursor);
    }

    public unsafe ref bool ConfigMacOSXBehaviors
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigMacOSXBehaviors);
    }

    public unsafe ref bool ConfigInputTrickleEventQueue
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigInputTrickleEventQueue);
    }

    public unsafe ref bool ConfigInputTextCursorBlink
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigInputTextCursorBlink);
    }

    public unsafe ref bool ConfigDragClickToInputText
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigDragClickToInputText);
    }

    public unsafe ref bool ConfigWindowsResizeFromEdges
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigWindowsResizeFromEdges);
    }

    public unsafe ref bool ConfigWindowsMoveFromTitleBarOnly
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->ConfigWindowsMoveFromTitleBarOnly);
    }

    public unsafe ref float ConfigMemoryCompactTimer
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->ConfigMemoryCompactTimer);
    }

    public unsafe NullTerminatedString BackendPlatformName
    {
      get => new NullTerminatedString(this.NativePtr->BackendPlatformName);
    }

    public unsafe NullTerminatedString BackendRendererName
    {
      get => new NullTerminatedString(this.NativePtr->BackendRendererName);
    }

    public unsafe IntPtr BackendPlatformUserData
    {
      get => (IntPtr) this.NativePtr->BackendPlatformUserData;
      set => this.NativePtr->BackendPlatformUserData = (void*) value;
    }

    public unsafe IntPtr BackendRendererUserData
    {
      get => (IntPtr) this.NativePtr->BackendRendererUserData;
      set => this.NativePtr->BackendRendererUserData = (void*) value;
    }

    public unsafe IntPtr BackendLanguageUserData
    {
      get => (IntPtr) this.NativePtr->BackendLanguageUserData;
      set => this.NativePtr->BackendLanguageUserData = (void*) value;
    }

    public unsafe ref IntPtr GetClipboardTextFn
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->GetClipboardTextFn);
    }

    public unsafe ref IntPtr SetClipboardTextFn
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->SetClipboardTextFn);
    }

    public unsafe IntPtr ClipboardUserData
    {
      get => (IntPtr) this.NativePtr->ClipboardUserData;
      set => this.NativePtr->ClipboardUserData = (void*) value;
    }

    public unsafe ref IntPtr SetPlatformImeDataFn
    {
      get => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->SetPlatformImeDataFn);
    }

    public unsafe IntPtr _UnusedPadding
    {
      get => (IntPtr) this.NativePtr->_UnusedPadding;
      set => this.NativePtr->_UnusedPadding = (void*) value;
    }

    public unsafe ref bool WantCaptureMouse
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->WantCaptureMouse);
    }

    public unsafe ref bool WantCaptureKeyboard
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->WantCaptureKeyboard);
    }

    public unsafe ref bool WantTextInput
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->WantTextInput);
    }

    public unsafe ref bool WantSetMousePos
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->WantSetMousePos);
    }

    public unsafe ref bool WantSaveIniSettings
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->WantSaveIniSettings);
    }

    public unsafe ref bool NavActive => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->NavActive);

    public unsafe ref bool NavVisible
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->NavVisible);
    }

    public unsafe ref float Framerate
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->Framerate);
    }

    public unsafe ref int MetricsRenderVertices
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->MetricsRenderVertices);
    }

    public unsafe ref int MetricsRenderIndices
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->MetricsRenderIndices);
    }

    public unsafe ref int MetricsRenderWindows
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->MetricsRenderWindows);
    }

    public unsafe ref int MetricsActiveWindows
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->MetricsActiveWindows);
    }

    public unsafe ref int MetricsActiveAllocations
    {
      get => ref Unsafe.AsRef<int>((void*) &this.NativePtr->MetricsActiveAllocations);
    }

    public unsafe ref Vector2 MouseDelta
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->MouseDelta);
    }

    public unsafe RangeAccessor<int> KeyMap
    {
      get => new RangeAccessor<int>((void*) this.NativePtr->KeyMap, 645);
    }

    public unsafe RangeAccessor<bool> KeysDown
    {
      get => new RangeAccessor<bool>((void*) this.NativePtr->KeysDown, 645);
    }

    public unsafe ref Vector2 MousePos
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->MousePos);
    }

    public unsafe RangeAccessor<bool> MouseDown
    {
      get => new RangeAccessor<bool>((void*) this.NativePtr->MouseDown, 5);
    }

    public unsafe ref float MouseWheel
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->MouseWheel);
    }

    public unsafe ref float MouseWheelH
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->MouseWheelH);
    }

    public unsafe ref uint MouseHoveredViewport
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->MouseHoveredViewport);
    }

    public unsafe ref bool KeyCtrl => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->KeyCtrl);

    public unsafe ref bool KeyShift => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->KeyShift);

    public unsafe ref bool KeyAlt => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->KeyAlt);

    public unsafe ref bool KeySuper => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->KeySuper);

    public unsafe RangeAccessor<float> NavInputs
    {
      get => new RangeAccessor<float>((void*) this.NativePtr->NavInputs, 20);
    }

    public unsafe ref ImGuiModFlags KeyMods
    {
      get => ref Unsafe.AsRef<ImGuiModFlags>((void*) &this.NativePtr->KeyMods);
    }

    public unsafe RangeAccessor<ImGuiKeyData> KeysData
    {
      get => new RangeAccessor<ImGuiKeyData>((void*) &this.NativePtr->KeysData_0, 645);
    }

    public unsafe ref bool WantCaptureMouseUnlessPopupClose
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->WantCaptureMouseUnlessPopupClose);
    }

    public unsafe ref Vector2 MousePosPrev
    {
      get => ref Unsafe.AsRef<Vector2>((void*) &this.NativePtr->MousePosPrev);
    }

    public unsafe RangeAccessor<Vector2> MouseClickedPos
    {
      get => new RangeAccessor<Vector2>((void*) &this.NativePtr->MouseClickedPos_0, 5);
    }

    public unsafe RangeAccessor<double> MouseClickedTime
    {
      get => new RangeAccessor<double>((void*) this.NativePtr->MouseClickedTime, 5);
    }

    public unsafe RangeAccessor<bool> MouseClicked
    {
      get => new RangeAccessor<bool>((void*) this.NativePtr->MouseClicked, 5);
    }

    public unsafe RangeAccessor<bool> MouseDoubleClicked
    {
      get => new RangeAccessor<bool>((void*) this.NativePtr->MouseDoubleClicked, 5);
    }

    public unsafe RangeAccessor<ushort> MouseClickedCount
    {
      get => new RangeAccessor<ushort>((void*) this.NativePtr->MouseClickedCount, 5);
    }

    public unsafe RangeAccessor<ushort> MouseClickedLastCount
    {
      get => new RangeAccessor<ushort>((void*) this.NativePtr->MouseClickedLastCount, 5);
    }

    public unsafe RangeAccessor<bool> MouseReleased
    {
      get => new RangeAccessor<bool>((void*) this.NativePtr->MouseReleased, 5);
    }

    public unsafe RangeAccessor<bool> MouseDownOwned
    {
      get => new RangeAccessor<bool>((void*) this.NativePtr->MouseDownOwned, 5);
    }

    public unsafe RangeAccessor<bool> MouseDownOwnedUnlessPopupClose
    {
      get => new RangeAccessor<bool>((void*) this.NativePtr->MouseDownOwnedUnlessPopupClose, 5);
    }

    public unsafe RangeAccessor<float> MouseDownDuration
    {
      get => new RangeAccessor<float>((void*) this.NativePtr->MouseDownDuration, 5);
    }

    public unsafe RangeAccessor<float> MouseDownDurationPrev
    {
      get => new RangeAccessor<float>((void*) this.NativePtr->MouseDownDurationPrev, 5);
    }

    public unsafe RangeAccessor<Vector2> MouseDragMaxDistanceAbs
    {
      get => new RangeAccessor<Vector2>((void*) &this.NativePtr->MouseDragMaxDistanceAbs_0, 5);
    }

    public unsafe RangeAccessor<float> MouseDragMaxDistanceSqr
    {
      get => new RangeAccessor<float>((void*) this.NativePtr->MouseDragMaxDistanceSqr, 5);
    }

    public unsafe RangeAccessor<float> NavInputsDownDuration
    {
      get => new RangeAccessor<float>((void*) this.NativePtr->NavInputsDownDuration, 20);
    }

    public unsafe RangeAccessor<float> NavInputsDownDurationPrev
    {
      get => new RangeAccessor<float>((void*) this.NativePtr->NavInputsDownDurationPrev, 20);
    }

    public unsafe ref float PenPressure
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->PenPressure);
    }

    public unsafe ref bool AppFocusLost
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->AppFocusLost);
    }

    public unsafe ref bool AppAcceptingEvents
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->AppAcceptingEvents);
    }

    public unsafe ref sbyte BackendUsingLegacyKeyArrays
    {
      get => ref Unsafe.AsRef<sbyte>((void*) &this.NativePtr->BackendUsingLegacyKeyArrays);
    }

    public unsafe ref bool BackendUsingLegacyNavInputArray
    {
      get => ref Unsafe.AsRef<bool>((void*) &this.NativePtr->BackendUsingLegacyNavInputArray);
    }

    public unsafe ref ushort InputQueueSurrogate
    {
      get => ref Unsafe.AsRef<ushort>((void*) &this.NativePtr->InputQueueSurrogate);
    }

    public unsafe ImVector<ushort> InputQueueCharacters
    {
      get => new ImVector<ushort>(this.NativePtr->InputQueueCharacters);
    }

    public unsafe void AddFocusEvent(bool focused)
    {
      ImGuiNative.ImGuiIO_AddFocusEvent(this.NativePtr, focused ? (byte) 1 : (byte) 0);
    }

    public unsafe void AddInputCharacter(uint c)
    {
      ImGuiNative.ImGuiIO_AddInputCharacter(this.NativePtr, c);
    }

    public unsafe void AddInputCharactersUTF8(string str)
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
      ImGuiNative.ImGuiIO_AddInputCharactersUTF8(this.NativePtr, numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public unsafe void AddInputCharacterUTF16(ushort c)
    {
      ImGuiNative.ImGuiIO_AddInputCharacterUTF16(this.NativePtr, c);
    }

    public unsafe void AddKeyAnalogEvent(ImGuiKey key, bool down, float v)
    {
      byte down1 = down ? (byte) 1 : (byte) 0;
      ImGuiNative.ImGuiIO_AddKeyAnalogEvent(this.NativePtr, key, down1, v);
    }

    public unsafe void AddKeyEvent(ImGuiKey key, bool down)
    {
      byte down1 = down ? (byte) 1 : (byte) 0;
      ImGuiNative.ImGuiIO_AddKeyEvent(this.NativePtr, key, down1);
    }

    public unsafe void AddMouseButtonEvent(int button, bool down)
    {
      byte down1 = down ? (byte) 1 : (byte) 0;
      ImGuiNative.ImGuiIO_AddMouseButtonEvent(this.NativePtr, button, down1);
    }

    public unsafe void AddMousePosEvent(float x, float y)
    {
      ImGuiNative.ImGuiIO_AddMousePosEvent(this.NativePtr, x, y);
    }

    public unsafe void AddMouseViewportEvent(uint id)
    {
      ImGuiNative.ImGuiIO_AddMouseViewportEvent(this.NativePtr, id);
    }

    public unsafe void AddMouseWheelEvent(float wh_x, float wh_y)
    {
      ImGuiNative.ImGuiIO_AddMouseWheelEvent(this.NativePtr, wh_x, wh_y);
    }

    public unsafe void ClearInputCharacters()
    {
      ImGuiNative.ImGuiIO_ClearInputCharacters(this.NativePtr);
    }

    public unsafe void ClearInputKeys() => ImGuiNative.ImGuiIO_ClearInputKeys(this.NativePtr);

    public unsafe void Destroy() => ImGuiNative.ImGuiIO_destroy(this.NativePtr);

    public unsafe void SetAppAcceptingEvents(bool accepting_events)
    {
      ImGuiNative.ImGuiIO_SetAppAcceptingEvents(this.NativePtr, accepting_events ? (byte) 1 : (byte) 0);
    }

    public unsafe void SetKeyEventNativeData(ImGuiKey key, int native_keycode, int native_scancode)
    {
      int native_legacy_index = -1;
      ImGuiNative.ImGuiIO_SetKeyEventNativeData(this.NativePtr, key, native_keycode, native_scancode, native_legacy_index);
    }

    public unsafe void SetKeyEventNativeData(
      ImGuiKey key,
      int native_keycode,
      int native_scancode,
      int native_legacy_index)
    {
      ImGuiNative.ImGuiIO_SetKeyEventNativeData(this.NativePtr, key, native_keycode, native_scancode, native_legacy_index);
    }
  }
}
