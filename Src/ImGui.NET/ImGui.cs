// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGui
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
  public static class ImGui
  {
    public static unsafe ImGuiPayloadPtr AcceptDragDropPayload(string type)
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
      ImGuiDragDropFlags flags = ImGuiDragDropFlags.None;
      ImGuiPayload* nativePtr = ImGuiNative.igAcceptDragDropPayload(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImGuiPayloadPtr(nativePtr);
    }

    public static unsafe ImGuiPayloadPtr AcceptDragDropPayload(
      string type,
      ImGuiDragDropFlags flags)
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
      ImGuiPayload* nativePtr = ImGuiNative.igAcceptDragDropPayload(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return new ImGuiPayloadPtr(nativePtr);
    }

    public static void AlignTextToFramePadding() => ImGuiNative.igAlignTextToFramePadding();

    public static unsafe bool ArrowButton(string str_id, ImGuiDir dir)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igArrowButton(numPtr, dir);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool Begin(string name)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte* p_open = (byte*) null;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num = (int) ImGuiNative.igBegin(numPtr, p_open, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool Begin(string name, ref bool p_open)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte num1 = p_open ? (byte) 1 : (byte) 0;
      byte* p_open1 = &num1;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num2 = (int) ImGuiNative.igBegin(numPtr, p_open1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_open = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool Begin(string name, ref bool p_open, ImGuiWindowFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte num1 = p_open ? (byte) 1 : (byte) 0;
      byte* p_open1 = &num1;
      int num2 = (int) ImGuiNative.igBegin(numPtr, p_open1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_open = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool BeginChild(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      Vector2 size = new Vector2();
      byte border = 0;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num = (int) ImGuiNative.igBeginChild_Str(numPtr, size, border, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginChild(string str_id, Vector2 size)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte border = 0;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num = (int) ImGuiNative.igBeginChild_Str(numPtr, size, border, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginChild(string str_id, Vector2 size, bool border)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte border1 = border ? (byte) 1 : (byte) 0;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num = (int) ImGuiNative.igBeginChild_Str(numPtr, size, border1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginChild(
      string str_id,
      Vector2 size,
      bool border,
      ImGuiWindowFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte border1 = border ? (byte) 1 : (byte) 0;
      int num = (int) ImGuiNative.igBeginChild_Str(numPtr, size, border1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static bool BeginChild(uint id)
    {
      Vector2 size = new Vector2();
      byte border = 0;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      return ImGuiNative.igBeginChild_ID(id, size, border, flags) > (byte) 0;
    }

    public static bool BeginChild(uint id, Vector2 size)
    {
      byte border = 0;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      return ImGuiNative.igBeginChild_ID(id, size, border, flags) > (byte) 0;
    }

    public static bool BeginChild(uint id, Vector2 size, bool border)
    {
      byte border1 = border ? (byte) 1 : (byte) 0;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      return ImGuiNative.igBeginChild_ID(id, size, border1, flags) > (byte) 0;
    }

    public static bool BeginChild(uint id, Vector2 size, bool border, ImGuiWindowFlags flags)
    {
      byte border1 = border ? (byte) 1 : (byte) 0;
      return ImGuiNative.igBeginChild_ID(id, size, border1, flags) > (byte) 0;
    }

    public static bool BeginChildFrame(uint id, Vector2 size)
    {
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      return ImGuiNative.igBeginChildFrame(id, size, flags) > (byte) 0;
    }

    public static bool BeginChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags)
    {
      return ImGuiNative.igBeginChildFrame(id, size, flags) > (byte) 0;
    }

    public static unsafe bool BeginCombo(string label, string preview_value)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (preview_value != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(preview_value);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(preview_value, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiComboFlags flags = ImGuiComboFlags.None;
      int num = (int) ImGuiNative.igBeginCombo(numPtr1, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginCombo(string label, string preview_value, ImGuiComboFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (preview_value != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(preview_value);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(preview_value, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igBeginCombo(numPtr1, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static void BeginDisabled() => ImGuiNative.igBeginDisabled((byte) 1);

    public static void BeginDisabled(bool disabled)
    {
      ImGuiNative.igBeginDisabled(disabled ? (byte) 1 : (byte) 0);
    }

    public static bool BeginDragDropSource()
    {
      return ImGuiNative.igBeginDragDropSource(ImGuiDragDropFlags.None) > (byte) 0;
    }

    public static bool BeginDragDropSource(ImGuiDragDropFlags flags)
    {
      return ImGuiNative.igBeginDragDropSource(flags) > (byte) 0;
    }

    public static bool BeginDragDropTarget() => ImGuiNative.igBeginDragDropTarget() > (byte) 0;

    public static void BeginGroup() => ImGuiNative.igBeginGroup();

    public static unsafe bool BeginListBox(string label)
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
      Vector2 size = new Vector2();
      int num = (int) ImGuiNative.igBeginListBox(numPtr, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginListBox(string label, Vector2 size)
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
      int num = (int) ImGuiNative.igBeginListBox(numPtr, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static bool BeginMainMenuBar() => ImGuiNative.igBeginMainMenuBar() > (byte) 0;

    public static unsafe bool BeginMenu(string label)
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
      byte enabled = 1;
      int num = (int) ImGuiNative.igBeginMenu(numPtr, enabled);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginMenu(string label, bool enabled)
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
      byte enabled1 = enabled ? (byte) 1 : (byte) 0;
      int num = (int) ImGuiNative.igBeginMenu(numPtr, enabled1);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static bool BeginMenuBar() => ImGuiNative.igBeginMenuBar() > (byte) 0;

    public static unsafe bool BeginPopup(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num = (int) ImGuiNative.igBeginPopup(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopup(string str_id, ImGuiWindowFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igBeginPopup(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupContextItem()
    {
      return ImGuiNative.igBeginPopupContextItem((byte*) null, ImGuiPopupFlags.MouseButtonRight) > (byte) 0;
    }

    public static unsafe bool BeginPopupContextItem(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
      int num = (int) ImGuiNative.igBeginPopupContextItem(numPtr, popup_flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupContextItem(string str_id, ImGuiPopupFlags popup_flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igBeginPopupContextItem(numPtr, popup_flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupContextVoid()
    {
      return ImGuiNative.igBeginPopupContextVoid((byte*) null, ImGuiPopupFlags.MouseButtonRight) > (byte) 0;
    }

    public static unsafe bool BeginPopupContextVoid(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
      int num = (int) ImGuiNative.igBeginPopupContextVoid(numPtr, popup_flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupContextVoid(string str_id, ImGuiPopupFlags popup_flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igBeginPopupContextVoid(numPtr, popup_flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupContextWindow()
    {
      return ImGuiNative.igBeginPopupContextWindow((byte*) null, ImGuiPopupFlags.MouseButtonRight) > (byte) 0;
    }

    public static unsafe bool BeginPopupContextWindow(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
      int num = (int) ImGuiNative.igBeginPopupContextWindow(numPtr, popup_flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupContextWindow(string str_id, ImGuiPopupFlags popup_flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igBeginPopupContextWindow(numPtr, popup_flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupModal(string name)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte* p_open = (byte*) null;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num = (int) ImGuiNative.igBeginPopupModal(numPtr, p_open, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginPopupModal(string name, ref bool p_open)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte num1 = p_open ? (byte) 1 : (byte) 0;
      byte* p_open1 = &num1;
      ImGuiWindowFlags flags = ImGuiWindowFlags.None;
      int num2 = (int) ImGuiNative.igBeginPopupModal(numPtr, p_open1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_open = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool BeginPopupModal(string name, ref bool p_open, ImGuiWindowFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte num1 = p_open ? (byte) 1 : (byte) 0;
      byte* p_open1 = &num1;
      int num2 = (int) ImGuiNative.igBeginPopupModal(numPtr, p_open1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_open = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool BeginTabBar(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiTabBarFlags flags = ImGuiTabBarFlags.None;
      int num = (int) ImGuiNative.igBeginTabBar(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginTabBar(string str_id, ImGuiTabBarFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igBeginTabBar(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginTabItem(string label)
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
      byte* p_open = (byte*) null;
      ImGuiTabItemFlags flags = ImGuiTabItemFlags.None;
      int num = (int) ImGuiNative.igBeginTabItem(numPtr, p_open, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginTabItem(string label, ref bool p_open)
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
      byte num1 = p_open ? (byte) 1 : (byte) 0;
      byte* p_open1 = &num1;
      ImGuiTabItemFlags flags = ImGuiTabItemFlags.None;
      int num2 = (int) ImGuiNative.igBeginTabItem(numPtr, p_open1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_open = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool BeginTabItem(string label, ref bool p_open, ImGuiTabItemFlags flags)
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
      byte num1 = p_open ? (byte) 1 : (byte) 0;
      byte* p_open1 = &num1;
      int num2 = (int) ImGuiNative.igBeginTabItem(numPtr, p_open1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_open = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool BeginTable(string str_id, int column)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiTableFlags flags = ImGuiTableFlags.None;
      Vector2 outer_size = new Vector2();
      float inner_width = 0.0f;
      int num = (int) ImGuiNative.igBeginTable(numPtr, column, flags, outer_size, inner_width);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginTable(string str_id, int column, ImGuiTableFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      Vector2 outer_size = new Vector2();
      float inner_width = 0.0f;
      int num = (int) ImGuiNative.igBeginTable(numPtr, column, flags, outer_size, inner_width);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginTable(
      string str_id,
      int column,
      ImGuiTableFlags flags,
      Vector2 outer_size)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      float inner_width = 0.0f;
      int num = (int) ImGuiNative.igBeginTable(numPtr, column, flags, outer_size, inner_width);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool BeginTable(
      string str_id,
      int column,
      ImGuiTableFlags flags,
      Vector2 outer_size,
      float inner_width)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igBeginTable(numPtr, column, flags, outer_size, inner_width);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static void BeginTooltip() => ImGuiNative.igBeginTooltip();

    public static void Bullet() => ImGuiNative.igBullet();

    public static unsafe void BulletText(string fmt)
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
      ImGuiNative.igBulletText(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe bool Button(string label)
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
      Vector2 size = new Vector2();
      int num = (int) ImGuiNative.igButton(numPtr, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool Button(string label, Vector2 size)
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
      int num = (int) ImGuiNative.igButton(numPtr, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static float CalcItemWidth() => ImGuiNative.igCalcItemWidth();

    public static unsafe bool Checkbox(string label, ref bool v)
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
      byte num1 = v ? (byte) 1 : (byte) 0;
      byte* v1 = &num1;
      int num2 = (int) ImGuiNative.igCheckbox(numPtr, v1);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      v = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool CheckboxFlags(string label, ref int flags, int flags_value)
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
      fixed (int* flags1 = &flags)
      {
        int num = (int) ImGuiNative.igCheckboxFlags_IntPtr(numPtr, flags1, flags_value);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool CheckboxFlags(string label, ref uint flags, uint flags_value)
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
      fixed (uint* flags1 = &flags)
      {
        int num = (int) ImGuiNative.igCheckboxFlags_UintPtr(numPtr, flags1, flags_value);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static void CloseCurrentPopup() => ImGuiNative.igCloseCurrentPopup();

    public static unsafe bool CollapsingHeader(string label)
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
      ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
      int num = (int) ImGuiNative.igCollapsingHeader_TreeNodeFlags(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool CollapsingHeader(string label, ImGuiTreeNodeFlags flags)
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
      int num = (int) ImGuiNative.igCollapsingHeader_TreeNodeFlags(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool CollapsingHeader(string label, ref bool p_visible)
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
      byte num1 = p_visible ? (byte) 1 : (byte) 0;
      byte* p_visible1 = &num1;
      ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
      int num2 = (int) ImGuiNative.igCollapsingHeader_BoolPtr(numPtr, p_visible1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_visible = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool CollapsingHeader(
      string label,
      ref bool p_visible,
      ImGuiTreeNodeFlags flags)
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
      byte num1 = p_visible ? (byte) 1 : (byte) 0;
      byte* p_visible1 = &num1;
      int num2 = (int) ImGuiNative.igCollapsingHeader_BoolPtr(numPtr, p_visible1, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_visible = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool ColorButton(string desc_id, Vector4 col)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (desc_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(desc_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(desc_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
      Vector2 size = new Vector2();
      int num = (int) ImGuiNative.igColorButton(numPtr, col, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool ColorButton(string desc_id, Vector4 col, ImGuiColorEditFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (desc_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(desc_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(desc_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      Vector2 size = new Vector2();
      int num = (int) ImGuiNative.igColorButton(numPtr, col, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool ColorButton(
      string desc_id,
      Vector4 col,
      ImGuiColorEditFlags flags,
      Vector2 size)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (desc_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(desc_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(desc_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igColorButton(numPtr, col, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static uint ColorConvertFloat4ToU32(Vector4 @in)
    {
      return ImGuiNative.igColorConvertFloat4ToU32(@in);
    }

    public static unsafe void ColorConvertHSVtoRGB(
      float h,
      float s,
      float v,
      out float out_r,
      out float out_g,
      out float out_b)
    {
      fixed (float* out_r1 = &out_r)
        fixed (float* out_g1 = &out_g)
          fixed (float* out_b1 = &out_b)
            ImGuiNative.igColorConvertHSVtoRGB(h, s, v, out_r1, out_g1, out_b1);
    }

    public static unsafe void ColorConvertRGBtoHSV(
      float r,
      float g,
      float b,
      out float out_h,
      out float out_s,
      out float out_v)
    {
      fixed (float* out_h1 = &out_h)
        fixed (float* out_s1 = &out_s)
          fixed (float* out_v1 = &out_v)
            ImGuiNative.igColorConvertRGBtoHSV(r, g, b, out_h1, out_s1, out_v1);
    }

    public static unsafe Vector4 ColorConvertU32ToFloat4(uint @in)
    {
      Vector4 float4;
      ImGuiNative.igColorConvertU32ToFloat4(&float4, @in);
      return float4;
    }

    public static unsafe bool ColorEdit3(string label, ref Vector3 col)
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
      ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
      fixed (Vector3* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorEdit3(numPtr, col1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorEdit3(string label, ref Vector3 col, ImGuiColorEditFlags flags)
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
      fixed (Vector3* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorEdit3(numPtr, col1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorEdit4(string label, ref Vector4 col)
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
      ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
      fixed (Vector4* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorEdit4(numPtr, col1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorEdit4(string label, ref Vector4 col, ImGuiColorEditFlags flags)
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
      fixed (Vector4* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorEdit4(numPtr, col1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorPicker3(string label, ref Vector3 col)
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
      ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
      fixed (Vector3* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorPicker3(numPtr, col1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorPicker3(
      string label,
      ref Vector3 col,
      ImGuiColorEditFlags flags)
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
      fixed (Vector3* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorPicker3(numPtr, col1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorPicker4(string label, ref Vector4 col)
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
      ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
      float* ref_col = (float*) null;
      fixed (Vector4* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorPicker4(numPtr, col1, flags, ref_col);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorPicker4(
      string label,
      ref Vector4 col,
      ImGuiColorEditFlags flags)
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
      float* ref_col = (float*) null;
      fixed (Vector4* col1 = &col)
      {
        int num = (int) ImGuiNative.igColorPicker4(numPtr, col1, flags, ref_col);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool ColorPicker4(
      string label,
      ref Vector4 col,
      ImGuiColorEditFlags flags,
      ref float ref_col)
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
      fixed (Vector4* col1 = &col)
        fixed (float* ref_col1 = &ref_col)
        {
          int num = (int) ImGuiNative.igColorPicker4(numPtr, col1, flags, ref_col1);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr);
          return (uint) num > 0U;
        }
    }

    public static unsafe void Columns() => ImGuiNative.igColumns(1, (byte*) null, (byte) 1);

    public static unsafe void Columns(int count)
    {
      byte* id = (byte*) null;
      byte border = 1;
      ImGuiNative.igColumns(count, id, border);
    }

    public static unsafe void Columns(int count, string id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte border = 1;
      ImGuiNative.igColumns(count, numPtr, border);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void Columns(int count, string id, bool border)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte border1 = border ? (byte) 1 : (byte) 0;
      ImGuiNative.igColumns(count, numPtr, border1);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe bool Combo(
      string label,
      ref int current_item,
      string[] items,
      int items_count)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int* numPtr2 = stackalloc int[items.Length];
      int num1 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        string s = items[index];
        numPtr2[index] = Encoding.UTF8.GetByteCount(s);
        num1 += numPtr2[index] + 1;
      }
      byte* numPtr3 = stackalloc byte[num1];
      int num2 = 0;
      for (int index1 = 0; index1 < items.Length; ++index1)
      {
        string str = items[index1];
        IntPtr num3;
        if (str == null)
        {
          num3 = IntPtr.Zero;
        }
        else
        {
          fixed (char* chPtr = &str.GetPinnableReference())
            num3 = (IntPtr) chPtr;
        }
        char* chars = (char*) num3;
        int index2 = num2 + Encoding.UTF8.GetBytes(chars, str.Length, numPtr3 + num2, numPtr2[index1]);
        numPtr3[index2] = (byte) 0;
        num2 = index2 + 1;
        // ISSUE: fixed variable is out of scope
        // ISSUE: __unpin statement
        __unpin(chPtr);
      }
      byte** items1 = stackalloc byte*[items.Length];
      int num4 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        items1[index] = numPtr3 + num4;
        num4 += numPtr2[index] + 1;
      }
      int popup_max_height_in_items = -1;
      fixed (int* current_item1 = &current_item)
      {
        int num5 = (int) ImGuiNative.igCombo_Str_arr(numPtr1, current_item1, items1, items_count, popup_max_height_in_items);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        return (uint) num5 > 0U;
      }
    }

    public static unsafe bool Combo(
      string label,
      ref int current_item,
      string[] items,
      int items_count,
      int popup_max_height_in_items)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int* numPtr2 = stackalloc int[items.Length];
      int num1 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        string s = items[index];
        numPtr2[index] = Encoding.UTF8.GetByteCount(s);
        num1 += numPtr2[index] + 1;
      }
      byte* numPtr3 = stackalloc byte[num1];
      int num2 = 0;
      for (int index1 = 0; index1 < items.Length; ++index1)
      {
        string str = items[index1];
        IntPtr num3;
        if (str == null)
        {
          num3 = IntPtr.Zero;
        }
        else
        {
          fixed (char* chPtr = &str.GetPinnableReference())
            num3 = (IntPtr) chPtr;
        }
        char* chars = (char*) num3;
        int index2 = num2 + Encoding.UTF8.GetBytes(chars, str.Length, numPtr3 + num2, numPtr2[index1]);
        numPtr3[index2] = (byte) 0;
        num2 = index2 + 1;
        // ISSUE: fixed variable is out of scope
        // ISSUE: __unpin statement
        __unpin(chPtr);
      }
      byte** items1 = stackalloc byte*[items.Length];
      int num4 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        items1[index] = numPtr3 + num4;
        num4 += numPtr2[index] + 1;
      }
      fixed (int* current_item1 = &current_item)
      {
        int num5 = (int) ImGuiNative.igCombo_Str_arr(numPtr1, current_item1, items1, items_count, popup_max_height_in_items);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        return (uint) num5 > 0U;
      }
    }

    public static unsafe bool Combo(
      string label,
      ref int current_item,
      string items_separated_by_zeros)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (items_separated_by_zeros != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(items_separated_by_zeros);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(items_separated_by_zeros, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int popup_max_height_in_items = -1;
      fixed (int* current_item1 = &current_item)
      {
        int num = (int) ImGuiNative.igCombo_Str(numPtr1, current_item1, numPtr2, popup_max_height_in_items);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool Combo(
      string label,
      ref int current_item,
      string items_separated_by_zeros,
      int popup_max_height_in_items)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (items_separated_by_zeros != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(items_separated_by_zeros);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(items_separated_by_zeros, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* current_item1 = &current_item)
      {
        int num = (int) ImGuiNative.igCombo_Str(numPtr1, current_item1, numPtr2, popup_max_height_in_items);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe IntPtr CreateContext() => ImGuiNative.igCreateContext((ImFontAtlas*) null);

    public static unsafe IntPtr CreateContext(ImFontAtlasPtr shared_font_atlas)
    {
      return ImGuiNative.igCreateContext(shared_font_atlas.NativePtr);
    }

    public static unsafe bool DebugCheckVersionAndDataLayout(
      string version_str,
      uint sz_io,
      uint sz_style,
      uint sz_vec2,
      uint sz_vec4,
      uint sz_drawvert,
      uint sz_drawidx)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (version_str != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(version_str);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(version_str, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igDebugCheckVersionAndDataLayout(numPtr, sz_io, sz_style, sz_vec2, sz_vec4, sz_drawvert, sz_drawidx);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe void DebugTextEncoding(string text)
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
      ImGuiNative.igDebugTextEncoding(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void DestroyContext() => ImGuiNative.igDestroyContext(IntPtr.Zero);

    public static void DestroyContext(IntPtr ctx) => ImGuiNative.igDestroyContext(ctx);

    public static void DestroyPlatformWindows() => ImGuiNative.igDestroyPlatformWindows();

    public static unsafe uint DockSpace(uint id)
    {
      Vector2 size = new Vector2();
      ImGuiDockNodeFlags flags = ImGuiDockNodeFlags.None;
      ImGuiWindowClass* window_class = (ImGuiWindowClass*) null;
      return ImGuiNative.igDockSpace(id, size, flags, window_class);
    }

    public static unsafe uint DockSpace(uint id, Vector2 size)
    {
      ImGuiDockNodeFlags flags = ImGuiDockNodeFlags.None;
      ImGuiWindowClass* window_class = (ImGuiWindowClass*) null;
      return ImGuiNative.igDockSpace(id, size, flags, window_class);
    }

    public static unsafe uint DockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags)
    {
      ImGuiWindowClass* window_class = (ImGuiWindowClass*) null;
      return ImGuiNative.igDockSpace(id, size, flags, window_class);
    }

    public static unsafe uint DockSpace(
      uint id,
      Vector2 size,
      ImGuiDockNodeFlags flags,
      ImGuiWindowClassPtr window_class)
    {
      ImGuiWindowClass* nativePtr = window_class.NativePtr;
      return ImGuiNative.igDockSpace(id, size, flags, nativePtr);
    }

    public static unsafe uint DockSpaceOverViewport()
    {
      return ImGuiNative.igDockSpaceOverViewport((ImGuiViewport*) null, ImGuiDockNodeFlags.None, (ImGuiWindowClass*) null);
    }

    public static unsafe uint DockSpaceOverViewport(ImGuiViewportPtr viewport)
    {
      ImGuiViewport* nativePtr = viewport.NativePtr;
      ImGuiDockNodeFlags guiDockNodeFlags = ImGuiDockNodeFlags.None;
      ImGuiWindowClass* imGuiWindowClassPtr = (ImGuiWindowClass*) null;
      int flags = (int) guiDockNodeFlags;
      ImGuiWindowClass* window_class = imGuiWindowClassPtr;
      return ImGuiNative.igDockSpaceOverViewport(nativePtr, (ImGuiDockNodeFlags) flags, window_class);
    }

    public static unsafe uint DockSpaceOverViewport(
      ImGuiViewportPtr viewport,
      ImGuiDockNodeFlags flags)
    {
      ImGuiViewport* nativePtr = viewport.NativePtr;
      ImGuiWindowClass* imGuiWindowClassPtr = (ImGuiWindowClass*) null;
      int flags1 = (int) flags;
      ImGuiWindowClass* window_class = imGuiWindowClassPtr;
      return ImGuiNative.igDockSpaceOverViewport(nativePtr, (ImGuiDockNodeFlags) flags1, window_class);
    }

    public static unsafe uint DockSpaceOverViewport(
      ImGuiViewportPtr viewport,
      ImGuiDockNodeFlags flags,
      ImGuiWindowClassPtr window_class)
    {
      ImGuiViewport* nativePtr1 = viewport.NativePtr;
      ImGuiWindowClass* nativePtr2 = window_class.NativePtr;
      int flags1 = (int) flags;
      ImGuiWindowClass* window_class1 = nativePtr2;
      return ImGuiNative.igDockSpaceOverViewport(nativePtr1, (ImGuiDockNodeFlags) flags1, window_class1);
    }

    public static unsafe bool DragFloat(string label, ref float v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat(string label, ref float v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat(string label, ref float v, float v_speed, float v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat(
      string label,
      ref float v,
      float v_speed,
      float v_min,
      float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat(
      string label,
      ref float v,
      float v_speed,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat(
      string label,
      ref float v,
      float v_speed,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat2(string label, ref Vector2 v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat2(string label, ref Vector2 v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat2(string label, ref Vector2 v, float v_speed, float v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat2(
      string label,
      ref Vector2 v,
      float v_speed,
      float v_min,
      float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat2(
      string label,
      ref Vector2 v,
      float v_speed,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat2(
      string label,
      ref Vector2 v,
      float v_speed,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat3(string label, ref Vector3 v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat3(string label, ref Vector3 v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat3(string label, ref Vector3 v, float v_speed, float v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat3(
      string label,
      ref Vector3 v,
      float v_speed,
      float v_min,
      float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat3(
      string label,
      ref Vector3 v,
      float v_speed,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat3(
      string label,
      ref Vector3 v,
      float v_speed,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat4(string label, ref Vector4 v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat4(string label, ref Vector4 v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat4(string label, ref Vector4 v, float v_speed, float v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat4(
      string label,
      ref Vector4 v,
      float v_speed,
      float v_min,
      float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat4(
      string label,
      ref Vector4 v,
      float v_speed,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloat4(
      string label,
      ref Vector4 v,
      float v_speed,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragFloat4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragFloatRange2(
      string label,
      ref float v_current_min,
      ref float v_current_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_current_min1 = &v_current_min)
        fixed (float* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragFloatRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragFloatRange2(
      string label,
      ref float v_current_min,
      ref float v_current_max,
      float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_min = 0.0f;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_current_min1 = &v_current_min)
        fixed (float* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragFloatRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragFloatRange2(
      string label,
      ref float v_current_min,
      ref float v_current_max,
      float v_speed,
      float v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_max = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_current_min1 = &v_current_min)
        fixed (float* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragFloatRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragFloatRange2(
      string label,
      ref float v_current_min,
      ref float v_current_max,
      float v_speed,
      float v_min,
      float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_current_min1 = &v_current_min)
        fixed (float* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragFloatRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragFloatRange2(
      string label,
      ref float v_current_min,
      ref float v_current_max,
      float v_speed,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_current_min1 = &v_current_min)
        fixed (float* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragFloatRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount1 > 2048)
            Util.Free(numPtr1);
          if (utf8ByteCount2 > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragFloatRange2(
      string label,
      ref float v_current_min,
      ref float v_current_max,
      float v_speed,
      float v_min,
      float v_max,
      string format,
      string format_max)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int utf8ByteCount3 = 0;
      byte* numPtr3;
      if (format_max != null)
      {
        utf8ByteCount3 = Encoding.UTF8.GetByteCount(format_max);
        numPtr3 = utf8ByteCount3 <= 2048 ? stackalloc byte[utf8ByteCount3 + 1] : Util.Allocate(utf8ByteCount3 + 1);
        int utf8 = Util.GetUtf8(format_max, numPtr3, utf8ByteCount3);
        numPtr3[utf8] = (byte) 0;
      }
      else
        numPtr3 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_current_min1 = &v_current_min)
        fixed (float* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragFloatRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, numPtr3, flags);
          if (utf8ByteCount1 > 2048)
            Util.Free(numPtr1);
          if (utf8ByteCount2 > 2048)
            Util.Free(numPtr2);
          if (utf8ByteCount3 > 2048)
            Util.Free(numPtr3);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragFloatRange2(
      string label,
      ref float v_current_min,
      ref float v_current_max,
      float v_speed,
      float v_min,
      float v_max,
      string format,
      string format_max,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int utf8ByteCount3 = 0;
      byte* numPtr3;
      if (format_max != null)
      {
        utf8ByteCount3 = Encoding.UTF8.GetByteCount(format_max);
        numPtr3 = utf8ByteCount3 <= 2048 ? stackalloc byte[utf8ByteCount3 + 1] : Util.Allocate(utf8ByteCount3 + 1);
        int utf8 = Util.GetUtf8(format_max, numPtr3, utf8ByteCount3);
        numPtr3[utf8] = (byte) 0;
      }
      else
        numPtr3 = (byte*) null;
      fixed (float* v_current_min1 = &v_current_min)
        fixed (float* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragFloatRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, numPtr3, flags);
          if (utf8ByteCount1 > 2048)
            Util.Free(numPtr1);
          if (utf8ByteCount2 > 2048)
            Util.Free(numPtr2);
          if (utf8ByteCount3 > 2048)
            Util.Free(numPtr3);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragInt(string label, ref int v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt(string label, ref int v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt(string label, ref int v, float v_speed, int v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt2(string label, ref int v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt2(string label, ref int v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt2(string label, ref int v, float v_speed, int v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt2(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt2(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt2(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt2(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt3(string label, ref int v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt3(string label, ref int v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt3(string label, ref int v, float v_speed, int v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt3(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt3(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt3(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt3(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt4(string label, ref int v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt4(string label, ref int v, float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt4(string label, ref int v, float v_speed, int v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt4(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt4(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragInt4(
      string label,
      ref int v,
      float v_speed,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igDragInt4(numPtr1, v1, v_speed, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool DragIntRange2(
      string label,
      ref int v_current_min,
      ref int v_current_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_speed = 1f;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v_current_min1 = &v_current_min)
        fixed (int* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragIntRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragIntRange2(
      string label,
      ref int v_current_min,
      ref int v_current_max,
      float v_speed)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_min = 0;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v_current_min1 = &v_current_min)
        fixed (int* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragIntRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragIntRange2(
      string label,
      ref int v_current_min,
      ref int v_current_max,
      float v_speed,
      int v_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int v_max = 0;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v_current_min1 = &v_current_min)
        fixed (int* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragIntRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragIntRange2(
      string label,
      ref int v_current_min,
      ref int v_current_max,
      float v_speed,
      int v_min,
      int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v_current_min1 = &v_current_min)
        fixed (int* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragIntRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount > 2048)
            Util.Free(numPtr1);
          if (byteCount > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragIntRange2(
      string label,
      ref int v_current_min,
      ref int v_current_max,
      float v_speed,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      byte* format_max = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v_current_min1 = &v_current_min)
        fixed (int* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragIntRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, format_max, flags);
          if (utf8ByteCount1 > 2048)
            Util.Free(numPtr1);
          if (utf8ByteCount2 > 2048)
            Util.Free(numPtr2);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragIntRange2(
      string label,
      ref int v_current_min,
      ref int v_current_max,
      float v_speed,
      int v_min,
      int v_max,
      string format,
      string format_max)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int utf8ByteCount3 = 0;
      byte* numPtr3;
      if (format_max != null)
      {
        utf8ByteCount3 = Encoding.UTF8.GetByteCount(format_max);
        numPtr3 = utf8ByteCount3 <= 2048 ? stackalloc byte[utf8ByteCount3 + 1] : Util.Allocate(utf8ByteCount3 + 1);
        int utf8 = Util.GetUtf8(format_max, numPtr3, utf8ByteCount3);
        numPtr3[utf8] = (byte) 0;
      }
      else
        numPtr3 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v_current_min1 = &v_current_min)
        fixed (int* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragIntRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, numPtr3, flags);
          if (utf8ByteCount1 > 2048)
            Util.Free(numPtr1);
          if (utf8ByteCount2 > 2048)
            Util.Free(numPtr2);
          if (utf8ByteCount3 > 2048)
            Util.Free(numPtr3);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragIntRange2(
      string label,
      ref int v_current_min,
      ref int v_current_max,
      float v_speed,
      int v_min,
      int v_max,
      string format,
      string format_max,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int utf8ByteCount3 = 0;
      byte* numPtr3;
      if (format_max != null)
      {
        utf8ByteCount3 = Encoding.UTF8.GetByteCount(format_max);
        numPtr3 = utf8ByteCount3 <= 2048 ? stackalloc byte[utf8ByteCount3 + 1] : Util.Allocate(utf8ByteCount3 + 1);
        int utf8 = Util.GetUtf8(format_max, numPtr3, utf8ByteCount3);
        numPtr3[utf8] = (byte) 0;
      }
      else
        numPtr3 = (byte*) null;
      fixed (int* v_current_min1 = &v_current_min)
        fixed (int* v_current_max1 = &v_current_max)
        {
          int num = (int) ImGuiNative.igDragIntRange2(numPtr1, v_current_min1, v_current_max1, v_speed, v_min, v_max, numPtr2, numPtr3, flags);
          if (utf8ByteCount1 > 2048)
            Util.Free(numPtr1);
          if (utf8ByteCount2 > 2048)
            Util.Free(numPtr2);
          if (utf8ByteCount3 > 2048)
            Util.Free(numPtr3);
          return (uint) num > 0U;
        }
    }

    public static unsafe bool DragScalar(string label, ImGuiDataType data_type, IntPtr p_data)
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
      void* pointer = p_data.ToPointer();
      float v_speed = 1f;
      void* p_min = (void*) null;
      void* p_max = (void*) null;
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalar(numPtr, data_type, pointer, v_speed, p_min, p_max, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      float v_speed)
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
      void* pointer = p_data.ToPointer();
      void* p_min = (void*) null;
      void* p_max = (void*) null;
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalar(numPtr, data_type, pointer, v_speed, p_min, p_max, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      float v_speed,
      IntPtr p_min)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* p_max = (void*) null;
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalar(numPtr, data_type, pointer1, v_speed, pointer2, p_max, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      float v_speed,
      IntPtr p_min,
      IntPtr p_max)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalar(numPtr, data_type, pointer1, v_speed, pointer2, pointer3, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      float v_speed,
      IntPtr p_min,
      IntPtr p_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalar(numPtr1, data_type, pointer1, v_speed, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      float v_speed,
      IntPtr p_min,
      IntPtr p_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igDragScalar(numPtr1, data_type, pointer1, v_speed, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components)
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
      void* pointer = p_data.ToPointer();
      float v_speed = 1f;
      void* p_min = (void*) null;
      void* p_max = (void*) null;
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalarN(numPtr, data_type, pointer, components, v_speed, p_min, p_max, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      float v_speed)
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
      void* pointer = p_data.ToPointer();
      void* p_min = (void*) null;
      void* p_max = (void*) null;
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalarN(numPtr, data_type, pointer, components, v_speed, p_min, p_max, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      float v_speed,
      IntPtr p_min)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* p_max = (void*) null;
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalarN(numPtr, data_type, pointer1, components, v_speed, pointer2, p_max, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      float v_speed,
      IntPtr p_min,
      IntPtr p_max)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalarN(numPtr, data_type, pointer1, components, v_speed, pointer2, pointer3, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      float v_speed,
      IntPtr p_min,
      IntPtr p_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igDragScalarN(numPtr1, data_type, pointer1, components, v_speed, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool DragScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      float v_speed,
      IntPtr p_min,
      IntPtr p_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igDragScalarN(numPtr1, data_type, pointer1, components, v_speed, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static void Dummy(Vector2 size) => ImGuiNative.igDummy(size);

    public static void End() => ImGuiNative.igEnd();

    public static void EndChild() => ImGuiNative.igEndChild();

    public static void EndChildFrame() => ImGuiNative.igEndChildFrame();

    public static void EndCombo() => ImGuiNative.igEndCombo();

    public static void EndDisabled() => ImGuiNative.igEndDisabled();

    public static void EndDragDropSource() => ImGuiNative.igEndDragDropSource();

    public static void EndDragDropTarget() => ImGuiNative.igEndDragDropTarget();

    public static void EndFrame() => ImGuiNative.igEndFrame();

    public static void EndGroup() => ImGuiNative.igEndGroup();

    public static void EndListBox() => ImGuiNative.igEndListBox();

    public static void EndMainMenuBar() => ImGuiNative.igEndMainMenuBar();

    public static void EndMenu() => ImGuiNative.igEndMenu();

    public static void EndMenuBar() => ImGuiNative.igEndMenuBar();

    public static void EndPopup() => ImGuiNative.igEndPopup();

    public static void EndTabBar() => ImGuiNative.igEndTabBar();

    public static void EndTabItem() => ImGuiNative.igEndTabItem();

    public static void EndTable() => ImGuiNative.igEndTable();

    public static void EndTooltip() => ImGuiNative.igEndTooltip();

    public static unsafe ImGuiViewportPtr FindViewportByID(uint id)
    {
      return new ImGuiViewportPtr(ImGuiNative.igFindViewportByID(id));
    }

    public static unsafe ImGuiViewportPtr FindViewportByPlatformHandle(IntPtr platform_handle)
    {
      return new ImGuiViewportPtr(ImGuiNative.igFindViewportByPlatformHandle(platform_handle.ToPointer()));
    }

    public static unsafe void GetAllocatorFunctions(
      ref IntPtr p_alloc_func,
      ref IntPtr p_free_func,
      ref void* p_user_data)
    {
      fixed (IntPtr* p_alloc_func1 = &p_alloc_func)
        fixed (IntPtr* numPtr = &p_free_func)
          fixed (void** voidPtr = &p_user_data)
          {
            IntPtr* p_free_func1 = numPtr;
            void** p_user_data1 = voidPtr;
            ImGuiNative.igGetAllocatorFunctions(p_alloc_func1, p_free_func1, p_user_data1);
          }
    }

    public static unsafe ImDrawListPtr GetBackgroundDrawList()
    {
      return new ImDrawListPtr(ImGuiNative.igGetBackgroundDrawList_Nil());
    }

    public static unsafe ImDrawListPtr GetBackgroundDrawList(ImGuiViewportPtr viewport)
    {
      return new ImDrawListPtr(ImGuiNative.igGetBackgroundDrawList_ViewportPtr(viewport.NativePtr));
    }

    public static unsafe string GetClipboardText()
    {
      return Util.StringFromPtr(ImGuiNative.igGetClipboardText());
    }

    public static uint GetColorU32(ImGuiCol idx)
    {
      float alpha_mul = 1f;
      return ImGuiNative.igGetColorU32_Col(idx, alpha_mul);
    }

    public static uint GetColorU32(ImGuiCol idx, float alpha_mul)
    {
      return ImGuiNative.igGetColorU32_Col(idx, alpha_mul);
    }

    public static uint GetColorU32(Vector4 col) => ImGuiNative.igGetColorU32_Vec4(col);

    public static uint GetColorU32(uint col) => ImGuiNative.igGetColorU32_U32(col);

    public static int GetColumnIndex() => ImGuiNative.igGetColumnIndex();

    public static float GetColumnOffset() => ImGuiNative.igGetColumnOffset(-1);

    public static float GetColumnOffset(int column_index)
    {
      return ImGuiNative.igGetColumnOffset(column_index);
    }

    public static int GetColumnsCount() => ImGuiNative.igGetColumnsCount();

    public static float GetColumnWidth() => ImGuiNative.igGetColumnWidth(-1);

    public static float GetColumnWidth(int column_index)
    {
      return ImGuiNative.igGetColumnWidth(column_index);
    }

    public static unsafe Vector2 GetContentRegionAvail()
    {
      Vector2 contentRegionAvail;
      ImGuiNative.igGetContentRegionAvail(&contentRegionAvail);
      return contentRegionAvail;
    }

    public static unsafe Vector2 GetContentRegionMax()
    {
      Vector2 contentRegionMax;
      ImGuiNative.igGetContentRegionMax(&contentRegionMax);
      return contentRegionMax;
    }

    public static IntPtr GetCurrentContext() => ImGuiNative.igGetCurrentContext();

    public static unsafe Vector2 GetCursorPos()
    {
      Vector2 cursorPos;
      ImGuiNative.igGetCursorPos(&cursorPos);
      return cursorPos;
    }

    public static float GetCursorPosX() => ImGuiNative.igGetCursorPosX();

    public static float GetCursorPosY() => ImGuiNative.igGetCursorPosY();

    public static unsafe Vector2 GetCursorScreenPos()
    {
      Vector2 cursorScreenPos;
      ImGuiNative.igGetCursorScreenPos(&cursorScreenPos);
      return cursorScreenPos;
    }

    public static unsafe Vector2 GetCursorStartPos()
    {
      Vector2 cursorStartPos;
      ImGuiNative.igGetCursorStartPos(&cursorStartPos);
      return cursorStartPos;
    }

    public static unsafe ImGuiPayloadPtr GetDragDropPayload()
    {
      return new ImGuiPayloadPtr(ImGuiNative.igGetDragDropPayload());
    }

    public static unsafe ImDrawDataPtr GetDrawData()
    {
      return new ImDrawDataPtr(ImGuiNative.igGetDrawData());
    }

    public static IntPtr GetDrawListSharedData() => ImGuiNative.igGetDrawListSharedData();

    public static unsafe ImFontPtr GetFont() => new ImFontPtr(ImGuiNative.igGetFont());

    public static float GetFontSize() => ImGuiNative.igGetFontSize();

    public static unsafe Vector2 GetFontTexUvWhitePixel()
    {
      Vector2 fontTexUvWhitePixel;
      ImGuiNative.igGetFontTexUvWhitePixel(&fontTexUvWhitePixel);
      return fontTexUvWhitePixel;
    }

    public static unsafe ImDrawListPtr GetForegroundDrawList()
    {
      return new ImDrawListPtr(ImGuiNative.igGetForegroundDrawList_Nil());
    }

    public static unsafe ImDrawListPtr GetForegroundDrawList(ImGuiViewportPtr viewport)
    {
      return new ImDrawListPtr(ImGuiNative.igGetForegroundDrawList_ViewportPtr(viewport.NativePtr));
    }

    public static int GetFrameCount() => ImGuiNative.igGetFrameCount();

    public static float GetFrameHeight() => ImGuiNative.igGetFrameHeight();

    public static float GetFrameHeightWithSpacing() => ImGuiNative.igGetFrameHeightWithSpacing();

    public static unsafe uint GetID(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int idStr = (int) ImGuiNative.igGetID_Str(numPtr);
      if (utf8ByteCount <= 2048)
        return (uint) idStr;
      Util.Free(numPtr);
      return (uint) idStr;
    }

    public static unsafe uint GetID(IntPtr ptr_id) => ImGuiNative.igGetID_Ptr(ptr_id.ToPointer());

    public static unsafe ImGuiIOPtr GetIO() => new ImGuiIOPtr(ImGuiNative.igGetIO());

    public static unsafe Vector2 GetItemRectMax()
    {
      Vector2 itemRectMax;
      ImGuiNative.igGetItemRectMax(&itemRectMax);
      return itemRectMax;
    }

    public static unsafe Vector2 GetItemRectMin()
    {
      Vector2 itemRectMin;
      ImGuiNative.igGetItemRectMin(&itemRectMin);
      return itemRectMin;
    }

    public static unsafe Vector2 GetItemRectSize()
    {
      Vector2 itemRectSize;
      ImGuiNative.igGetItemRectSize(&itemRectSize);
      return itemRectSize;
    }

    public static int GetKeyIndex(ImGuiKey key) => ImGuiNative.igGetKeyIndex(key);

    public static unsafe string GetKeyName(ImGuiKey key)
    {
      return Util.StringFromPtr(ImGuiNative.igGetKeyName(key));
    }

    public static int GetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate)
    {
      return ImGuiNative.igGetKeyPressedAmount(key, repeat_delay, rate);
    }

    public static unsafe ImGuiViewportPtr GetMainViewport()
    {
      return new ImGuiViewportPtr(ImGuiNative.igGetMainViewport());
    }

    public static int GetMouseClickedCount(ImGuiMouseButton button)
    {
      return ImGuiNative.igGetMouseClickedCount(button);
    }

    public static ImGuiMouseCursor GetMouseCursor() => ImGuiNative.igGetMouseCursor();

    public static unsafe Vector2 GetMouseDragDelta()
    {
      ImGuiMouseButton button = ImGuiMouseButton.Left;
      float lock_threshold = -1f;
      Vector2 mouseDragDelta;
      ImGuiNative.igGetMouseDragDelta(&mouseDragDelta, button, lock_threshold);
      return mouseDragDelta;
    }

    public static unsafe Vector2 GetMouseDragDelta(ImGuiMouseButton button)
    {
      float lock_threshold = -1f;
      Vector2 mouseDragDelta;
      ImGuiNative.igGetMouseDragDelta(&mouseDragDelta, button, lock_threshold);
      return mouseDragDelta;
    }

    public static unsafe Vector2 GetMouseDragDelta(ImGuiMouseButton button, float lock_threshold)
    {
      Vector2 mouseDragDelta;
      ImGuiNative.igGetMouseDragDelta(&mouseDragDelta, button, lock_threshold);
      return mouseDragDelta;
    }

    public static unsafe Vector2 GetMousePos()
    {
      Vector2 mousePos;
      ImGuiNative.igGetMousePos(&mousePos);
      return mousePos;
    }

    public static unsafe Vector2 GetMousePosOnOpeningCurrentPopup()
    {
      Vector2 openingCurrentPopup;
      ImGuiNative.igGetMousePosOnOpeningCurrentPopup(&openingCurrentPopup);
      return openingCurrentPopup;
    }

    public static unsafe ImGuiPlatformIOPtr GetPlatformIO()
    {
      return new ImGuiPlatformIOPtr(ImGuiNative.igGetPlatformIO());
    }

    public static float GetScrollMaxX() => ImGuiNative.igGetScrollMaxX();

    public static float GetScrollMaxY() => ImGuiNative.igGetScrollMaxY();

    public static float GetScrollX() => ImGuiNative.igGetScrollX();

    public static float GetScrollY() => ImGuiNative.igGetScrollY();

    public static unsafe ImGuiStoragePtr GetStateStorage()
    {
      return new ImGuiStoragePtr(ImGuiNative.igGetStateStorage());
    }

    public static unsafe ImGuiStylePtr GetStyle() => new ImGuiStylePtr(ImGuiNative.igGetStyle());

    public static unsafe string GetStyleColorName(ImGuiCol idx)
    {
      return Util.StringFromPtr(ImGuiNative.igGetStyleColorName(idx));
    }

    public static unsafe Vector4* GetStyleColorVec4(ImGuiCol idx)
    {
      return ImGuiNative.igGetStyleColorVec4(idx);
    }

    public static float GetTextLineHeight() => ImGuiNative.igGetTextLineHeight();

    public static float GetTextLineHeightWithSpacing()
    {
      return ImGuiNative.igGetTextLineHeightWithSpacing();
    }

    public static double GetTime() => ImGuiNative.igGetTime();

    public static float GetTreeNodeToLabelSpacing() => ImGuiNative.igGetTreeNodeToLabelSpacing();

    public static unsafe string GetVersion() => Util.StringFromPtr(ImGuiNative.igGetVersion());

    public static unsafe Vector2 GetWindowContentRegionMax()
    {
      Vector2 contentRegionMax;
      ImGuiNative.igGetWindowContentRegionMax(&contentRegionMax);
      return contentRegionMax;
    }

    public static unsafe Vector2 GetWindowContentRegionMin()
    {
      Vector2 contentRegionMin;
      ImGuiNative.igGetWindowContentRegionMin(&contentRegionMin);
      return contentRegionMin;
    }

    public static uint GetWindowDockID() => ImGuiNative.igGetWindowDockID();

    public static float GetWindowDpiScale() => ImGuiNative.igGetWindowDpiScale();

    public static unsafe ImDrawListPtr GetWindowDrawList()
    {
      return new ImDrawListPtr(ImGuiNative.igGetWindowDrawList());
    }

    public static float GetWindowHeight() => ImGuiNative.igGetWindowHeight();

    public static unsafe Vector2 GetWindowPos()
    {
      Vector2 windowPos;
      ImGuiNative.igGetWindowPos(&windowPos);
      return windowPos;
    }

    public static unsafe Vector2 GetWindowSize()
    {
      Vector2 windowSize;
      ImGuiNative.igGetWindowSize(&windowSize);
      return windowSize;
    }

    public static unsafe ImGuiViewportPtr GetWindowViewport()
    {
      return new ImGuiViewportPtr(ImGuiNative.igGetWindowViewport());
    }

    public static float GetWindowWidth() => ImGuiNative.igGetWindowWidth();

    public static void Image(IntPtr user_texture_id, Vector2 size)
    {
      Vector2 uv0 = new Vector2();
      Vector2 uv1 = new Vector2(1f, 1f);
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      Vector4 border_col = new Vector4();
      ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, border_col);
    }

    public static void Image(IntPtr user_texture_id, Vector2 size, Vector2 uv0)
    {
      Vector2 uv1 = new Vector2(1f, 1f);
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      Vector4 border_col = new Vector4();
      ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, border_col);
    }

    public static void Image(IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1)
    {
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      Vector4 border_col = new Vector4();
      ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, border_col);
    }

    public static void Image(
      IntPtr user_texture_id,
      Vector2 size,
      Vector2 uv0,
      Vector2 uv1,
      Vector4 tint_col)
    {
      Vector4 border_col = new Vector4();
      ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, border_col);
    }

    public static void Image(
      IntPtr user_texture_id,
      Vector2 size,
      Vector2 uv0,
      Vector2 uv1,
      Vector4 tint_col,
      Vector4 border_col)
    {
      ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, border_col);
    }

    public static bool ImageButton(IntPtr user_texture_id, Vector2 size)
    {
      Vector2 uv0 = new Vector2();
      Vector2 uv1 = new Vector2(1f, 1f);
      int frame_padding = -1;
      Vector4 bg_col = new Vector4();
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      return ImGuiNative.igImageButton(user_texture_id, size, uv0, uv1, frame_padding, bg_col, tint_col) > (byte) 0;
    }

    public static bool ImageButton(IntPtr user_texture_id, Vector2 size, Vector2 uv0)
    {
      Vector2 uv1 = new Vector2(1f, 1f);
      int frame_padding = -1;
      Vector4 bg_col = new Vector4();
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      return ImGuiNative.igImageButton(user_texture_id, size, uv0, uv1, frame_padding, bg_col, tint_col) > (byte) 0;
    }

    public static bool ImageButton(IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1)
    {
      int frame_padding = -1;
      Vector4 bg_col = new Vector4();
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      return ImGuiNative.igImageButton(user_texture_id, size, uv0, uv1, frame_padding, bg_col, tint_col) > (byte) 0;
    }

    public static bool ImageButton(
      IntPtr user_texture_id,
      Vector2 size,
      Vector2 uv0,
      Vector2 uv1,
      int frame_padding)
    {
      Vector4 bg_col = new Vector4();
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      return ImGuiNative.igImageButton(user_texture_id, size, uv0, uv1, frame_padding, bg_col, tint_col) > (byte) 0;
    }

    public static bool ImageButton(
      IntPtr user_texture_id,
      Vector2 size,
      Vector2 uv0,
      Vector2 uv1,
      int frame_padding,
      Vector4 bg_col)
    {
      Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
      return ImGuiNative.igImageButton(user_texture_id, size, uv0, uv1, frame_padding, bg_col, tint_col) > (byte) 0;
    }

    public static bool ImageButton(
      IntPtr user_texture_id,
      Vector2 size,
      Vector2 uv0,
      Vector2 uv1,
      int frame_padding,
      Vector4 bg_col,
      Vector4 tint_col)
    {
      return ImGuiNative.igImageButton(user_texture_id, size, uv0, uv1, frame_padding, bg_col, tint_col) > (byte) 0;
    }

    public static void Indent() => ImGuiNative.igIndent(0.0f);

    public static void Indent(float indent_w) => ImGuiNative.igIndent(indent_w);

    public static unsafe bool InputDouble(string label, ref double v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      double step = 0.0;
      double step_fast = 0.0;
      int byteCount = Encoding.UTF8.GetByteCount("%.6f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.6f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (double* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputDouble(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputDouble(string label, ref double v, double step)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      double step_fast = 0.0;
      int byteCount = Encoding.UTF8.GetByteCount("%.6f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.6f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (double* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputDouble(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputDouble(
      string label,
      ref double v,
      double step,
      double step_fast)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.6f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.6f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (double* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputDouble(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputDouble(
      string label,
      ref double v,
      double step,
      double step_fast,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (double* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputDouble(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputDouble(
      string label,
      ref double v,
      double step,
      double step_fast,
      string format,
      ImGuiInputTextFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (double* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputDouble(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat(string label, ref float v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float step = 0.0f;
      float step_fast = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat(string label, ref float v, float step)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float step_fast = 0.0f;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat(string label, ref float v, float step, float step_fast)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat(
      string label,
      ref float v,
      float step,
      float step_fast,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat(
      string label,
      ref float v,
      float step,
      float step_fast,
      string format,
      ImGuiInputTextFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat(numPtr1, v1, step, step_fast, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat2(string label, ref Vector2 v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat2(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat2(string label, ref Vector2 v, string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat2(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat2(
      string label,
      ref Vector2 v,
      string format,
      ImGuiInputTextFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat2(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat3(string label, ref Vector3 v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat3(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat3(string label, ref Vector3 v, string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat3(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat3(
      string label,
      ref Vector3 v,
      string format,
      ImGuiInputTextFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat3(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat4(string label, ref Vector4 v)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat4(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat4(string label, ref Vector4 v, string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat4(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputFloat4(
      string label,
      ref Vector4 v,
      string format,
      ImGuiInputTextFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputFloat4(numPtr1, v1, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt(string label, ref int v)
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
      int step = 1;
      int step_fast = 100;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt(numPtr, v1, step, step_fast, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt(string label, ref int v, int step)
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
      int step_fast = 100;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt(numPtr, v1, step, step_fast, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt(string label, ref int v, int step, int step_fast)
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
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt(numPtr, v1, step, step_fast, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt(
      string label,
      ref int v,
      int step,
      int step_fast,
      ImGuiInputTextFlags flags)
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
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt(numPtr, v1, step, step_fast, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt2(string label, ref int v)
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
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt2(numPtr, v1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt2(string label, ref int v, ImGuiInputTextFlags flags)
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
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt2(numPtr, v1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt3(string label, ref int v)
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
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt3(numPtr, v1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt3(string label, ref int v, ImGuiInputTextFlags flags)
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
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt3(numPtr, v1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt4(string label, ref int v)
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
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt4(numPtr, v1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputInt4(string label, ref int v, ImGuiInputTextFlags flags)
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
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igInputInt4(numPtr, v1, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data)
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
      void* pointer = p_data.ToPointer();
      void* p_step = (void*) null;
      void* p_step_fast = (void*) null;
      byte* format = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalar(numPtr, data_type, pointer, p_step, p_step_fast, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_step)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* p_step_fast = (void*) null;
      byte* format = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalar(numPtr, data_type, pointer1, pointer2, p_step_fast, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_step,
      IntPtr p_step_fast)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* pointer3 = p_step_fast.ToPointer();
      byte* format = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalar(numPtr, data_type, pointer1, pointer2, pointer3, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_step,
      IntPtr p_step_fast,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* pointer3 = p_step_fast.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalar(numPtr1, data_type, pointer1, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_step,
      IntPtr p_step_fast,
      string format,
      ImGuiInputTextFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* pointer3 = p_step_fast.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igInputScalar(numPtr1, data_type, pointer1, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components)
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
      void* pointer = p_data.ToPointer();
      void* p_step = (void*) null;
      void* p_step_fast = (void*) null;
      byte* format = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalarN(numPtr, data_type, pointer, components, p_step, p_step_fast, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      IntPtr p_step)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* p_step_fast = (void*) null;
      byte* format = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalarN(numPtr, data_type, pointer1, components, pointer2, p_step_fast, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      IntPtr p_step,
      IntPtr p_step_fast)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* pointer3 = p_step_fast.ToPointer();
      byte* format = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalarN(numPtr, data_type, pointer1, components, pointer2, pointer3, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      IntPtr p_step,
      IntPtr p_step_fast,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* pointer3 = p_step_fast.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
      int num = (int) ImGuiNative.igInputScalarN(numPtr1, data_type, pointer1, components, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool InputScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      IntPtr p_step,
      IntPtr p_step_fast,
      string format,
      ImGuiInputTextFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_step.ToPointer();
      void* pointer3 = p_step_fast.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igInputScalarN(numPtr1, data_type, pointer1, components, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool InvisibleButton(string str_id, Vector2 size)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiButtonFlags flags = ImGuiButtonFlags.None;
      int num = (int) ImGuiNative.igInvisibleButton(numPtr, size, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool InvisibleButton(string str_id, Vector2 size, ImGuiButtonFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igInvisibleButton(numPtr, size, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static bool IsAnyItemActive() => ImGuiNative.igIsAnyItemActive() > (byte) 0;

    public static bool IsAnyItemFocused() => ImGuiNative.igIsAnyItemFocused() > (byte) 0;

    public static bool IsAnyItemHovered() => ImGuiNative.igIsAnyItemHovered() > (byte) 0;

    public static bool IsAnyMouseDown() => ImGuiNative.igIsAnyMouseDown() > (byte) 0;

    public static bool IsItemActivated() => ImGuiNative.igIsItemActivated() > (byte) 0;

    public static bool IsItemActive() => ImGuiNative.igIsItemActive() > (byte) 0;

    public static bool IsItemClicked()
    {
      return ImGuiNative.igIsItemClicked(ImGuiMouseButton.Left) > (byte) 0;
    }

    public static bool IsItemClicked(ImGuiMouseButton mouse_button)
    {
      return ImGuiNative.igIsItemClicked(mouse_button) > (byte) 0;
    }

    public static bool IsItemDeactivated() => ImGuiNative.igIsItemDeactivated() > (byte) 0;

    public static bool IsItemDeactivatedAfterEdit()
    {
      return ImGuiNative.igIsItemDeactivatedAfterEdit() > (byte) 0;
    }

    public static bool IsItemEdited() => ImGuiNative.igIsItemEdited() > (byte) 0;

    public static bool IsItemFocused() => ImGuiNative.igIsItemFocused() > (byte) 0;

    public static bool IsItemHovered()
    {
      return ImGuiNative.igIsItemHovered(ImGuiHoveredFlags.None) > (byte) 0;
    }

    public static bool IsItemHovered(ImGuiHoveredFlags flags)
    {
      return ImGuiNative.igIsItemHovered(flags) > (byte) 0;
    }

    public static bool IsItemToggledOpen() => ImGuiNative.igIsItemToggledOpen() > (byte) 0;

    public static bool IsItemVisible() => ImGuiNative.igIsItemVisible() > (byte) 0;

    public static bool IsKeyDown(ImGuiKey key) => ImGuiNative.igIsKeyDown(key) > (byte) 0;

    public static bool IsKeyPressed(ImGuiKey key)
    {
      byte repeat = 1;
      return ImGuiNative.igIsKeyPressed(key, repeat) > (byte) 0;
    }

    public static bool IsKeyPressed(ImGuiKey key, bool repeat)
    {
      byte repeat1 = repeat ? (byte) 1 : (byte) 0;
      return ImGuiNative.igIsKeyPressed(key, repeat1) > (byte) 0;
    }

    public static bool IsKeyReleased(ImGuiKey key) => ImGuiNative.igIsKeyReleased(key) > (byte) 0;

    public static bool IsMouseClicked(ImGuiMouseButton button)
    {
      byte repeat = 0;
      return ImGuiNative.igIsMouseClicked(button, repeat) > (byte) 0;
    }

    public static bool IsMouseClicked(ImGuiMouseButton button, bool repeat)
    {
      byte repeat1 = repeat ? (byte) 1 : (byte) 0;
      return ImGuiNative.igIsMouseClicked(button, repeat1) > (byte) 0;
    }

    public static bool IsMouseDoubleClicked(ImGuiMouseButton button)
    {
      return ImGuiNative.igIsMouseDoubleClicked(button) > (byte) 0;
    }

    public static bool IsMouseDown(ImGuiMouseButton button)
    {
      return ImGuiNative.igIsMouseDown(button) > (byte) 0;
    }

    public static bool IsMouseDragging(ImGuiMouseButton button)
    {
      float lock_threshold = -1f;
      return ImGuiNative.igIsMouseDragging(button, lock_threshold) > (byte) 0;
    }

    public static bool IsMouseDragging(ImGuiMouseButton button, float lock_threshold)
    {
      return ImGuiNative.igIsMouseDragging(button, lock_threshold) > (byte) 0;
    }

    public static bool IsMouseHoveringRect(Vector2 r_min, Vector2 r_max)
    {
      byte clip = 1;
      return ImGuiNative.igIsMouseHoveringRect(r_min, r_max, clip) > (byte) 0;
    }

    public static bool IsMouseHoveringRect(Vector2 r_min, Vector2 r_max, bool clip)
    {
      byte clip1 = clip ? (byte) 1 : (byte) 0;
      return ImGuiNative.igIsMouseHoveringRect(r_min, r_max, clip1) > (byte) 0;
    }

    public static unsafe bool IsMousePosValid()
    {
      return ImGuiNative.igIsMousePosValid((Vector2*) null) > (byte) 0;
    }

    public static unsafe bool IsMousePosValid(ref Vector2 mouse_pos)
    {
      fixed (Vector2* mouse_pos1 = &mouse_pos)
        return ImGuiNative.igIsMousePosValid(mouse_pos1) > (byte) 0;
    }

    public static bool IsMouseReleased(ImGuiMouseButton button)
    {
      return ImGuiNative.igIsMouseReleased(button) > (byte) 0;
    }

    public static unsafe bool IsPopupOpen(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiPopupFlags flags = ImGuiPopupFlags.None;
      int num = (int) ImGuiNative.igIsPopupOpen_Str(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool IsPopupOpen(string str_id, ImGuiPopupFlags flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      int num = (int) ImGuiNative.igIsPopupOpen_Str(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static bool IsRectVisible(Vector2 size)
    {
      return ImGuiNative.igIsRectVisible_Nil(size) > (byte) 0;
    }

    public static bool IsRectVisible(Vector2 rect_min, Vector2 rect_max)
    {
      return ImGuiNative.igIsRectVisible_Vec2(rect_min, rect_max) > (byte) 0;
    }

    public static bool IsWindowAppearing() => ImGuiNative.igIsWindowAppearing() > (byte) 0;

    public static bool IsWindowCollapsed() => ImGuiNative.igIsWindowCollapsed() > (byte) 0;

    public static bool IsWindowDocked() => ImGuiNative.igIsWindowDocked() > (byte) 0;

    public static bool IsWindowFocused()
    {
      return ImGuiNative.igIsWindowFocused(ImGuiFocusedFlags.None) > (byte) 0;
    }

    public static bool IsWindowFocused(ImGuiFocusedFlags flags)
    {
      return ImGuiNative.igIsWindowFocused(flags) > (byte) 0;
    }

    public static bool IsWindowHovered()
    {
      return ImGuiNative.igIsWindowHovered(ImGuiHoveredFlags.None) > (byte) 0;
    }

    public static bool IsWindowHovered(ImGuiHoveredFlags flags)
    {
      return ImGuiNative.igIsWindowHovered(flags) > (byte) 0;
    }

    public static unsafe void LabelText(string label, string fmt)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (fmt != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(fmt);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(fmt, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiNative.igLabelText(numPtr1, numPtr2);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 <= 2048)
        return;
      Util.Free(numPtr2);
    }

    public static unsafe bool ListBox(
      string label,
      ref int current_item,
      string[] items,
      int items_count)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int* numPtr2 = stackalloc int[items.Length];
      int num1 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        string s = items[index];
        numPtr2[index] = Encoding.UTF8.GetByteCount(s);
        num1 += numPtr2[index] + 1;
      }
      byte* numPtr3 = stackalloc byte[num1];
      int num2 = 0;
      for (int index1 = 0; index1 < items.Length; ++index1)
      {
        string str = items[index1];
        IntPtr num3;
        if (str == null)
        {
          num3 = IntPtr.Zero;
        }
        else
        {
          fixed (char* chPtr = &str.GetPinnableReference())
            num3 = (IntPtr) chPtr;
        }
        char* chars = (char*) num3;
        int index2 = num2 + Encoding.UTF8.GetBytes(chars, str.Length, numPtr3 + num2, numPtr2[index1]);
        numPtr3[index2] = (byte) 0;
        num2 = index2 + 1;
        // ISSUE: fixed variable is out of scope
        // ISSUE: __unpin statement
        __unpin(chPtr);
      }
      byte** items1 = stackalloc byte*[items.Length];
      int num4 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        items1[index] = numPtr3 + num4;
        num4 += numPtr2[index] + 1;
      }
      int height_in_items = -1;
      fixed (int* current_item1 = &current_item)
      {
        int num5 = (int) ImGuiNative.igListBox_Str_arr(numPtr1, current_item1, items1, items_count, height_in_items);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        return (uint) num5 > 0U;
      }
    }

    public static unsafe bool ListBox(
      string label,
      ref int current_item,
      string[] items,
      int items_count,
      int height_in_items)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int* numPtr2 = stackalloc int[items.Length];
      int num1 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        string s = items[index];
        numPtr2[index] = Encoding.UTF8.GetByteCount(s);
        num1 += numPtr2[index] + 1;
      }
      byte* numPtr3 = stackalloc byte[num1];
      int num2 = 0;
      for (int index1 = 0; index1 < items.Length; ++index1)
      {
        string str = items[index1];
        IntPtr num3;
        if (str == null)
        {
          num3 = IntPtr.Zero;
        }
        else
        {
          fixed (char* chPtr = &str.GetPinnableReference())
            num3 = (IntPtr) chPtr;
        }
        char* chars = (char*) num3;
        int index2 = num2 + Encoding.UTF8.GetBytes(chars, str.Length, numPtr3 + num2, numPtr2[index1]);
        numPtr3[index2] = (byte) 0;
        num2 = index2 + 1;
        // ISSUE: fixed variable is out of scope
        // ISSUE: __unpin statement
        __unpin(chPtr);
      }
      byte** items1 = stackalloc byte*[items.Length];
      int num4 = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        items1[index] = numPtr3 + num4;
        num4 += numPtr2[index] + 1;
      }
      fixed (int* current_item1 = &current_item)
      {
        int num5 = (int) ImGuiNative.igListBox_Str_arr(numPtr1, current_item1, items1, items_count, height_in_items);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        return (uint) num5 > 0U;
      }
    }

    public static unsafe void LoadIniSettingsFromDisk(string ini_filename)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (ini_filename != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(ini_filename);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(ini_filename, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igLoadIniSettingsFromDisk(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void LoadIniSettingsFromMemory(string ini_data)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (ini_data != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(ini_data);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(ini_data, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      uint ini_size = 0;
      ImGuiNative.igLoadIniSettingsFromMemory(numPtr, ini_size);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void LoadIniSettingsFromMemory(string ini_data, uint ini_size)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (ini_data != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(ini_data);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(ini_data, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igLoadIniSettingsFromMemory(numPtr, ini_size);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void LogButtons() => ImGuiNative.igLogButtons();

    public static void LogFinish() => ImGuiNative.igLogFinish();

    public static unsafe void LogText(string fmt)
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
      ImGuiNative.igLogText(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void LogToClipboard() => ImGuiNative.igLogToClipboard(-1);

    public static void LogToClipboard(int auto_open_depth)
    {
      ImGuiNative.igLogToClipboard(auto_open_depth);
    }

    public static unsafe void LogToFile() => ImGuiNative.igLogToFile(-1, (byte*) null);

    public static unsafe void LogToFile(int auto_open_depth)
    {
      byte* filename = (byte*) null;
      ImGuiNative.igLogToFile(auto_open_depth, filename);
    }

    public static unsafe void LogToFile(int auto_open_depth, string filename)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (filename != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(filename);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(filename, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igLogToFile(auto_open_depth, numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void LogToTTY() => ImGuiNative.igLogToTTY(-1);

    public static void LogToTTY(int auto_open_depth) => ImGuiNative.igLogToTTY(auto_open_depth);

    public static unsafe IntPtr MemAlloc(uint size) => (IntPtr) ImGuiNative.igMemAlloc(size);

    public static unsafe void MemFree(IntPtr ptr) => ImGuiNative.igMemFree(ptr.ToPointer());

    public static unsafe bool MenuItem(string label)
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
      byte* shortcut = (byte*) null;
      byte selected = 0;
      byte enabled = 1;
      int num = (int) ImGuiNative.igMenuItem_Bool(numPtr, shortcut, selected, enabled);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool MenuItem(string label, string shortcut)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (shortcut != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(shortcut);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(shortcut, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      byte selected = 0;
      byte enabled = 1;
      int num = (int) ImGuiNative.igMenuItem_Bool(numPtr1, numPtr2, selected, enabled);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool MenuItem(string label, string shortcut, bool selected)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (shortcut != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(shortcut);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(shortcut, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      byte selected1 = selected ? (byte) 1 : (byte) 0;
      byte enabled = 1;
      int num = (int) ImGuiNative.igMenuItem_Bool(numPtr1, numPtr2, selected1, enabled);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool MenuItem(string label, string shortcut, bool selected, bool enabled)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (shortcut != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(shortcut);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(shortcut, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      byte selected1 = selected ? (byte) 1 : (byte) 0;
      byte enabled1 = enabled ? (byte) 1 : (byte) 0;
      int num = (int) ImGuiNative.igMenuItem_Bool(numPtr1, numPtr2, selected1, enabled1);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool MenuItem(string label, string shortcut, ref bool p_selected)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (shortcut != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(shortcut);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(shortcut, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      byte num1 = p_selected ? (byte) 1 : (byte) 0;
      byte* p_selected1 = &num1;
      byte enabled = 1;
      int num2 = (int) ImGuiNative.igMenuItem_BoolPtr(numPtr1, numPtr2, p_selected1, enabled);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      p_selected = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool MenuItem(
      string label,
      string shortcut,
      ref bool p_selected,
      bool enabled)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (shortcut != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(shortcut);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(shortcut, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      byte num1 = p_selected ? (byte) 1 : (byte) 0;
      byte* p_selected1 = &num1;
      byte enabled1 = enabled ? (byte) 1 : (byte) 0;
      int num2 = (int) ImGuiNative.igMenuItem_BoolPtr(numPtr1, numPtr2, p_selected1, enabled1);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      p_selected = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static void NewFrame() => ImGuiNative.igNewFrame();

    public static void NewLine() => ImGuiNative.igNewLine();

    public static void NextColumn() => ImGuiNative.igNextColumn();

    public static unsafe void OpenPopup(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiPopupFlags popup_flags = ImGuiPopupFlags.None;
      ImGuiNative.igOpenPopup_Str(numPtr, popup_flags);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void OpenPopup(string str_id, ImGuiPopupFlags popup_flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igOpenPopup_Str(numPtr, popup_flags);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void OpenPopup(uint id)
    {
      ImGuiPopupFlags popup_flags = ImGuiPopupFlags.None;
      ImGuiNative.igOpenPopup_ID(id, popup_flags);
    }

    public static void OpenPopup(uint id, ImGuiPopupFlags popup_flags)
    {
      ImGuiNative.igOpenPopup_ID(id, popup_flags);
    }

    public static unsafe void OpenPopupOnItemClick()
    {
      ImGuiNative.igOpenPopupOnItemClick((byte*) null, ImGuiPopupFlags.MouseButtonRight);
    }

    public static unsafe void OpenPopupOnItemClick(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
      ImGuiNative.igOpenPopupOnItemClick(numPtr, popup_flags);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void OpenPopupOnItemClick(string str_id, ImGuiPopupFlags popup_flags)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igOpenPopupOnItemClick(numPtr, popup_flags);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void PlotHistogram(string label, ref float values, int values_count)
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
      int values_offset = 0;
      byte* overlay_text = (byte*) null;
      float maxValue1 = float.MaxValue;
      float maxValue2 = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotHistogram_FloatPtr(numPtr, values1, values_count, values_offset, overlay_text, maxValue1, maxValue2, graph_size, stride);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
      }
    }

    public static unsafe void PlotHistogram(
      string label,
      ref float values,
      int values_count,
      int values_offset)
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
      byte* overlay_text = (byte*) null;
      float maxValue1 = float.MaxValue;
      float maxValue2 = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotHistogram_FloatPtr(numPtr, values1, values_count, values_offset, overlay_text, maxValue1, maxValue2, graph_size, stride);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
      }
    }

    public static unsafe void PlotHistogram(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      float maxValue1 = float.MaxValue;
      float maxValue2 = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotHistogram_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, maxValue1, maxValue2, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotHistogram(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      float maxValue = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotHistogram_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, maxValue, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotHistogram(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min,
      float scale_max)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotHistogram_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, scale_max, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotHistogram(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min,
      float scale_max,
      Vector2 graph_size)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotHistogram_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, scale_max, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotHistogram(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min,
      float scale_max,
      Vector2 graph_size,
      int stride)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotHistogram_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, scale_max, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotLines(string label, ref float values, int values_count)
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
      int values_offset = 0;
      byte* overlay_text = (byte*) null;
      float maxValue1 = float.MaxValue;
      float maxValue2 = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotLines_FloatPtr(numPtr, values1, values_count, values_offset, overlay_text, maxValue1, maxValue2, graph_size, stride);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
      }
    }

    public static unsafe void PlotLines(
      string label,
      ref float values,
      int values_count,
      int values_offset)
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
      byte* overlay_text = (byte*) null;
      float maxValue1 = float.MaxValue;
      float maxValue2 = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotLines_FloatPtr(numPtr, values1, values_count, values_offset, overlay_text, maxValue1, maxValue2, graph_size, stride);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
      }
    }

    public static unsafe void PlotLines(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      float maxValue1 = float.MaxValue;
      float maxValue2 = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotLines_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, maxValue1, maxValue2, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotLines(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      float maxValue = float.MaxValue;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotLines_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, maxValue, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotLines(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min,
      float scale_max)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      Vector2 graph_size = new Vector2();
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotLines_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, scale_max, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotLines(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min,
      float scale_max,
      Vector2 graph_size)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int stride = 4;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotLines_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, scale_max, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static unsafe void PlotLines(
      string label,
      ref float values,
      int values_count,
      int values_offset,
      string overlay_text,
      float scale_min,
      float scale_max,
      Vector2 graph_size,
      int stride)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (overlay_text != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(overlay_text);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(overlay_text, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (float* values1 = &values)
      {
        ImGuiNative.igPlotLines_FloatPtr(numPtr1, values1, values_count, values_offset, numPtr2, scale_min, scale_max, graph_size, stride);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
      }
    }

    public static void PopAllowKeyboardFocus() => ImGuiNative.igPopAllowKeyboardFocus();

    public static void PopButtonRepeat() => ImGuiNative.igPopButtonRepeat();

    public static void PopClipRect() => ImGuiNative.igPopClipRect();

    public static void PopFont() => ImGuiNative.igPopFont();

    public static void PopID() => ImGuiNative.igPopID();

    public static void PopItemWidth() => ImGuiNative.igPopItemWidth();

    public static void PopStyleColor() => ImGuiNative.igPopStyleColor(1);

    public static void PopStyleColor(int count) => ImGuiNative.igPopStyleColor(count);

    public static void PopStyleVar() => ImGuiNative.igPopStyleVar(1);

    public static void PopStyleVar(int count) => ImGuiNative.igPopStyleVar(count);

    public static void PopTextWrapPos() => ImGuiNative.igPopTextWrapPos();

    public static unsafe void ProgressBar(float fraction)
    {
      Vector2 size_arg = new Vector2(float.MaxValue, 0.0f);
      byte* overlay = (byte*) null;
      ImGuiNative.igProgressBar(fraction, size_arg, overlay);
    }

    public static unsafe void ProgressBar(float fraction, Vector2 size_arg)
    {
      byte* overlay = (byte*) null;
      ImGuiNative.igProgressBar(fraction, size_arg, overlay);
    }

    public static unsafe void ProgressBar(float fraction, Vector2 size_arg, string overlay)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (overlay != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(overlay);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(overlay, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igProgressBar(fraction, size_arg, numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void PushAllowKeyboardFocus(bool allow_keyboard_focus)
    {
      ImGuiNative.igPushAllowKeyboardFocus(allow_keyboard_focus ? (byte) 1 : (byte) 0);
    }

    public static void PushButtonRepeat(bool repeat)
    {
      ImGuiNative.igPushButtonRepeat(repeat ? (byte) 1 : (byte) 0);
    }

    public static void PushClipRect(
      Vector2 clip_rect_min,
      Vector2 clip_rect_max,
      bool intersect_with_current_clip_rect)
    {
      byte intersect_with_current_clip_rect1 = intersect_with_current_clip_rect ? (byte) 1 : (byte) 0;
      ImGuiNative.igPushClipRect(clip_rect_min, clip_rect_max, intersect_with_current_clip_rect1);
    }

    public static unsafe void PushFont(ImFontPtr font) => ImGuiNative.igPushFont(font.NativePtr);

    public static unsafe void PushID(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igPushID_Str(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void PushID(IntPtr ptr_id) => ImGuiNative.igPushID_Ptr(ptr_id.ToPointer());

    public static void PushID(int int_id) => ImGuiNative.igPushID_Int(int_id);

    public static void PushItemWidth(float item_width) => ImGuiNative.igPushItemWidth(item_width);

    public static void PushStyleColor(ImGuiCol idx, uint col)
    {
      ImGuiNative.igPushStyleColor_U32(idx, col);
    }

    public static void PushStyleColor(ImGuiCol idx, Vector4 col)
    {
      ImGuiNative.igPushStyleColor_Vec4(idx, col);
    }

    public static void PushStyleVar(ImGuiStyleVar idx, float val)
    {
      ImGuiNative.igPushStyleVar_Float(idx, val);
    }

    public static void PushStyleVar(ImGuiStyleVar idx, Vector2 val)
    {
      ImGuiNative.igPushStyleVar_Vec2(idx, val);
    }

    public static void PushTextWrapPos() => ImGuiNative.igPushTextWrapPos(0.0f);

    public static void PushTextWrapPos(float wrap_local_pos_x)
    {
      ImGuiNative.igPushTextWrapPos(wrap_local_pos_x);
    }

    public static unsafe bool RadioButton(string label, bool active)
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
      byte active1 = active ? (byte) 1 : (byte) 0;
      int num = (int) ImGuiNative.igRadioButton_Bool(numPtr, active1);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool RadioButton(string label, ref int v, int v_button)
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
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igRadioButton_IntPtr(numPtr, v1, v_button);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr);
        return (uint) num > 0U;
      }
    }

    public static void Render() => ImGuiNative.igRender();

    public static unsafe void RenderPlatformWindowsDefault()
    {
      ImGuiNative.igRenderPlatformWindowsDefault((void*) null, (void*) null);
    }

    public static unsafe void RenderPlatformWindowsDefault(IntPtr platform_render_arg)
    {
      ImGuiNative.igRenderPlatformWindowsDefault(platform_render_arg.ToPointer(), (void*) null);
    }

    public static unsafe void RenderPlatformWindowsDefault(
      IntPtr platform_render_arg,
      IntPtr renderer_render_arg)
    {
      ImGuiNative.igRenderPlatformWindowsDefault(platform_render_arg.ToPointer(), renderer_render_arg.ToPointer());
    }

    public static void ResetMouseDragDelta()
    {
      ImGuiNative.igResetMouseDragDelta(ImGuiMouseButton.Left);
    }

    public static void ResetMouseDragDelta(ImGuiMouseButton button)
    {
      ImGuiNative.igResetMouseDragDelta(button);
    }

    public static void SameLine() => ImGuiNative.igSameLine(0.0f, -1f);

    public static void SameLine(float offset_from_start_x)
    {
      float spacing = -1f;
      ImGuiNative.igSameLine(offset_from_start_x, spacing);
    }

    public static void SameLine(float offset_from_start_x, float spacing)
    {
      ImGuiNative.igSameLine(offset_from_start_x, spacing);
    }

    public static unsafe void SaveIniSettingsToDisk(string ini_filename)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (ini_filename != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(ini_filename);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(ini_filename, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igSaveIniSettingsToDisk(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe string SaveIniSettingsToMemory()
    {
      return Util.StringFromPtr(ImGuiNative.igSaveIniSettingsToMemory((uint*) null));
    }

    public static unsafe string SaveIniSettingsToMemory(out uint out_ini_size)
    {
      fixed (uint* out_ini_size1 = &out_ini_size)
        return Util.StringFromPtr(ImGuiNative.igSaveIniSettingsToMemory(out_ini_size1));
    }

    public static unsafe bool Selectable(string label)
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
      byte selected = 0;
      ImGuiSelectableFlags flags = ImGuiSelectableFlags.None;
      Vector2 size = new Vector2();
      int num = (int) ImGuiNative.igSelectable_Bool(numPtr, selected, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool Selectable(string label, bool selected)
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
      byte selected1 = selected ? (byte) 1 : (byte) 0;
      ImGuiSelectableFlags flags = ImGuiSelectableFlags.None;
      Vector2 size = new Vector2();
      int num = (int) ImGuiNative.igSelectable_Bool(numPtr, selected1, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool Selectable(string label, bool selected, ImGuiSelectableFlags flags)
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
      byte selected1 = selected ? (byte) 1 : (byte) 0;
      Vector2 size = new Vector2();
      int num = (int) ImGuiNative.igSelectable_Bool(numPtr, selected1, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool Selectable(
      string label,
      bool selected,
      ImGuiSelectableFlags flags,
      Vector2 size)
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
      byte selected1 = selected ? (byte) 1 : (byte) 0;
      int num = (int) ImGuiNative.igSelectable_Bool(numPtr, selected1, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool Selectable(string label, ref bool p_selected)
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
      byte num1 = p_selected ? (byte) 1 : (byte) 0;
      byte* p_selected1 = &num1;
      ImGuiSelectableFlags flags = ImGuiSelectableFlags.None;
      Vector2 size = new Vector2();
      int num2 = (int) ImGuiNative.igSelectable_BoolPtr(numPtr, p_selected1, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_selected = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool Selectable(
      string label,
      ref bool p_selected,
      ImGuiSelectableFlags flags)
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
      byte num1 = p_selected ? (byte) 1 : (byte) 0;
      byte* p_selected1 = &num1;
      Vector2 size = new Vector2();
      int num2 = (int) ImGuiNative.igSelectable_BoolPtr(numPtr, p_selected1, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_selected = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static unsafe bool Selectable(
      string label,
      ref bool p_selected,
      ImGuiSelectableFlags flags,
      Vector2 size)
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
      byte num1 = p_selected ? (byte) 1 : (byte) 0;
      byte* p_selected1 = &num1;
      int num2 = (int) ImGuiNative.igSelectable_BoolPtr(numPtr, p_selected1, flags, size);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      p_selected = num1 > (byte) 0;
      return (uint) num2 > 0U;
    }

    public static void Separator() => ImGuiNative.igSeparator();

    public static unsafe void SetAllocatorFunctions(IntPtr alloc_func, IntPtr free_func)
    {
      void* user_data = (void*) null;
      ImGuiNative.igSetAllocatorFunctions(alloc_func, free_func, user_data);
    }

    public static unsafe void SetAllocatorFunctions(
      IntPtr alloc_func,
      IntPtr free_func,
      IntPtr user_data)
    {
      void* pointer = user_data.ToPointer();
      ImGuiNative.igSetAllocatorFunctions(alloc_func, free_func, pointer);
    }

    public static unsafe void SetClipboardText(string text)
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
      ImGuiNative.igSetClipboardText(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void SetColorEditOptions(ImGuiColorEditFlags flags)
    {
      ImGuiNative.igSetColorEditOptions(flags);
    }

    public static void SetColumnOffset(int column_index, float offset_x)
    {
      ImGuiNative.igSetColumnOffset(column_index, offset_x);
    }

    public static void SetColumnWidth(int column_index, float width)
    {
      ImGuiNative.igSetColumnWidth(column_index, width);
    }

    public static void SetCurrentContext(IntPtr ctx) => ImGuiNative.igSetCurrentContext(ctx);

    public static void SetCursorPos(Vector2 local_pos) => ImGuiNative.igSetCursorPos(local_pos);

    public static void SetCursorPosX(float local_x) => ImGuiNative.igSetCursorPosX(local_x);

    public static void SetCursorPosY(float local_y) => ImGuiNative.igSetCursorPosY(local_y);

    public static void SetCursorScreenPos(Vector2 pos) => ImGuiNative.igSetCursorScreenPos(pos);

    public static unsafe bool SetDragDropPayload(string type, IntPtr data, uint sz)
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
      void* pointer = data.ToPointer();
      ImGuiCond cond = ImGuiCond.None;
      int num = (int) ImGuiNative.igSetDragDropPayload(numPtr, pointer, sz, cond);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool SetDragDropPayload(
      string type,
      IntPtr data,
      uint sz,
      ImGuiCond cond)
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
      void* pointer = data.ToPointer();
      int num = (int) ImGuiNative.igSetDragDropPayload(numPtr, pointer, sz, cond);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static void SetItemAllowOverlap() => ImGuiNative.igSetItemAllowOverlap();

    public static void SetItemDefaultFocus() => ImGuiNative.igSetItemDefaultFocus();

    public static void SetKeyboardFocusHere() => ImGuiNative.igSetKeyboardFocusHere(0);

    public static void SetKeyboardFocusHere(int offset)
    {
      ImGuiNative.igSetKeyboardFocusHere(offset);
    }

    public static void SetMouseCursor(ImGuiMouseCursor cursor_type)
    {
      ImGuiNative.igSetMouseCursor(cursor_type);
    }

    public static void SetNextFrameWantCaptureKeyboard(bool want_capture_keyboard)
    {
      ImGuiNative.igSetNextFrameWantCaptureKeyboard(want_capture_keyboard ? (byte) 1 : (byte) 0);
    }

    public static void SetNextFrameWantCaptureMouse(bool want_capture_mouse)
    {
      ImGuiNative.igSetNextFrameWantCaptureMouse(want_capture_mouse ? (byte) 1 : (byte) 0);
    }

    public static void SetNextItemOpen(bool is_open)
    {
      ImGuiNative.igSetNextItemOpen(is_open ? (byte) 1 : (byte) 0, ImGuiCond.None);
    }

    public static void SetNextItemOpen(bool is_open, ImGuiCond cond)
    {
      ImGuiNative.igSetNextItemOpen(is_open ? (byte) 1 : (byte) 0, cond);
    }

    public static void SetNextItemWidth(float item_width)
    {
      ImGuiNative.igSetNextItemWidth(item_width);
    }

    public static void SetNextWindowBgAlpha(float alpha)
    {
      ImGuiNative.igSetNextWindowBgAlpha(alpha);
    }

    public static unsafe void SetNextWindowClass(ImGuiWindowClassPtr window_class)
    {
      ImGuiNative.igSetNextWindowClass(window_class.NativePtr);
    }

    public static void SetNextWindowCollapsed(bool collapsed)
    {
      ImGuiNative.igSetNextWindowCollapsed(collapsed ? (byte) 1 : (byte) 0, ImGuiCond.None);
    }

    public static void SetNextWindowCollapsed(bool collapsed, ImGuiCond cond)
    {
      ImGuiNative.igSetNextWindowCollapsed(collapsed ? (byte) 1 : (byte) 0, cond);
    }

    public static void SetNextWindowContentSize(Vector2 size)
    {
      ImGuiNative.igSetNextWindowContentSize(size);
    }

    public static void SetNextWindowDockID(uint dock_id)
    {
      ImGuiCond cond = ImGuiCond.None;
      ImGuiNative.igSetNextWindowDockID(dock_id, cond);
    }

    public static void SetNextWindowDockID(uint dock_id, ImGuiCond cond)
    {
      ImGuiNative.igSetNextWindowDockID(dock_id, cond);
    }

    public static void SetNextWindowFocus() => ImGuiNative.igSetNextWindowFocus();

    public static void SetNextWindowPos(Vector2 pos)
    {
      ImGuiCond cond = ImGuiCond.None;
      Vector2 pivot = new Vector2();
      ImGuiNative.igSetNextWindowPos(pos, cond, pivot);
    }

    public static void SetNextWindowPos(Vector2 pos, ImGuiCond cond)
    {
      Vector2 pivot = new Vector2();
      ImGuiNative.igSetNextWindowPos(pos, cond, pivot);
    }

    public static void SetNextWindowPos(Vector2 pos, ImGuiCond cond, Vector2 pivot)
    {
      ImGuiNative.igSetNextWindowPos(pos, cond, pivot);
    }

    public static void SetNextWindowSize(Vector2 size)
    {
      ImGuiCond cond = ImGuiCond.None;
      ImGuiNative.igSetNextWindowSize(size, cond);
    }

    public static void SetNextWindowSize(Vector2 size, ImGuiCond cond)
    {
      ImGuiNative.igSetNextWindowSize(size, cond);
    }

    public static unsafe void SetNextWindowSizeConstraints(Vector2 size_min, Vector2 size_max)
    {
      ImGuiSizeCallback custom_callback = (ImGuiSizeCallback) null;
      void* custom_callback_data = (void*) null;
      ImGuiNative.igSetNextWindowSizeConstraints(size_min, size_max, custom_callback, custom_callback_data);
    }

    public static unsafe void SetNextWindowSizeConstraints(
      Vector2 size_min,
      Vector2 size_max,
      ImGuiSizeCallback custom_callback)
    {
      void* custom_callback_data = (void*) null;
      ImGuiNative.igSetNextWindowSizeConstraints(size_min, size_max, custom_callback, custom_callback_data);
    }

    public static unsafe void SetNextWindowSizeConstraints(
      Vector2 size_min,
      Vector2 size_max,
      ImGuiSizeCallback custom_callback,
      IntPtr custom_callback_data)
    {
      void* pointer = custom_callback_data.ToPointer();
      ImGuiNative.igSetNextWindowSizeConstraints(size_min, size_max, custom_callback, pointer);
    }

    public static void SetNextWindowViewport(uint viewport_id)
    {
      ImGuiNative.igSetNextWindowViewport(viewport_id);
    }

    public static void SetScrollFromPosX(float local_x)
    {
      float center_x_ratio = 0.5f;
      ImGuiNative.igSetScrollFromPosX_Float(local_x, center_x_ratio);
    }

    public static void SetScrollFromPosX(float local_x, float center_x_ratio)
    {
      ImGuiNative.igSetScrollFromPosX_Float(local_x, center_x_ratio);
    }

    public static void SetScrollFromPosY(float local_y)
    {
      float center_y_ratio = 0.5f;
      ImGuiNative.igSetScrollFromPosY_Float(local_y, center_y_ratio);
    }

    public static void SetScrollFromPosY(float local_y, float center_y_ratio)
    {
      ImGuiNative.igSetScrollFromPosY_Float(local_y, center_y_ratio);
    }

    public static void SetScrollHereX() => ImGuiNative.igSetScrollHereX(0.5f);

    public static void SetScrollHereX(float center_x_ratio)
    {
      ImGuiNative.igSetScrollHereX(center_x_ratio);
    }

    public static void SetScrollHereY() => ImGuiNative.igSetScrollHereY(0.5f);

    public static void SetScrollHereY(float center_y_ratio)
    {
      ImGuiNative.igSetScrollHereY(center_y_ratio);
    }

    public static void SetScrollX(float scroll_x) => ImGuiNative.igSetScrollX_Float(scroll_x);

    public static void SetScrollY(float scroll_y) => ImGuiNative.igSetScrollY_Float(scroll_y);

    public static unsafe void SetStateStorage(ImGuiStoragePtr storage)
    {
      ImGuiNative.igSetStateStorage(storage.NativePtr);
    }

    public static unsafe void SetTabItemClosed(string tab_or_docked_window_label)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (tab_or_docked_window_label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(tab_or_docked_window_label);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(tab_or_docked_window_label, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igSetTabItemClosed(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void SetTooltip(string fmt)
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
      ImGuiNative.igSetTooltip(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void SetWindowCollapsed(bool collapsed)
    {
      ImGuiNative.igSetWindowCollapsed_Bool(collapsed ? (byte) 1 : (byte) 0, ImGuiCond.None);
    }

    public static void SetWindowCollapsed(bool collapsed, ImGuiCond cond)
    {
      ImGuiNative.igSetWindowCollapsed_Bool(collapsed ? (byte) 1 : (byte) 0, cond);
    }

    public static unsafe void SetWindowCollapsed(string name, bool collapsed)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte collapsed1 = collapsed ? (byte) 1 : (byte) 0;
      ImGuiCond cond = ImGuiCond.None;
      ImGuiNative.igSetWindowCollapsed_Str(numPtr, collapsed1, cond);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void SetWindowCollapsed(string name, bool collapsed, ImGuiCond cond)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte collapsed1 = collapsed ? (byte) 1 : (byte) 0;
      ImGuiNative.igSetWindowCollapsed_Str(numPtr, collapsed1, cond);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void SetWindowFocus() => ImGuiNative.igSetWindowFocus_Nil();

    public static unsafe void SetWindowFocus(string name)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igSetWindowFocus_Str(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void SetWindowFontScale(float scale) => ImGuiNative.igSetWindowFontScale(scale);

    public static void SetWindowPos(Vector2 pos)
    {
      ImGuiCond cond = ImGuiCond.None;
      ImGuiNative.igSetWindowPos_Vec2(pos, cond);
    }

    public static void SetWindowPos(Vector2 pos, ImGuiCond cond)
    {
      ImGuiNative.igSetWindowPos_Vec2(pos, cond);
    }

    public static unsafe void SetWindowPos(string name, Vector2 pos)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiCond cond = ImGuiCond.None;
      ImGuiNative.igSetWindowPos_Str(numPtr, pos, cond);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void SetWindowPos(string name, Vector2 pos, ImGuiCond cond)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igSetWindowPos_Str(numPtr, pos, cond);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void SetWindowSize(Vector2 size)
    {
      ImGuiCond cond = ImGuiCond.None;
      ImGuiNative.igSetWindowSize_Vec2(size, cond);
    }

    public static void SetWindowSize(Vector2 size, ImGuiCond cond)
    {
      ImGuiNative.igSetWindowSize_Vec2(size, cond);
    }

    public static unsafe void SetWindowSize(string name, Vector2 size)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiCond cond = ImGuiCond.None;
      ImGuiNative.igSetWindowSize_Str(numPtr, size, cond);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void SetWindowSize(string name, Vector2 size, ImGuiCond cond)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (name != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(name);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(name, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igSetWindowSize_Str(numPtr, size, cond);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void ShowAboutWindow() => ImGuiNative.igShowAboutWindow((byte*) null);

    public static unsafe void ShowAboutWindow(ref bool p_open)
    {
      byte num = p_open ? (byte) 1 : (byte) 0;
      ImGuiNative.igShowAboutWindow(&num);
      p_open = num > (byte) 0;
    }

    public static unsafe void ShowDebugLogWindow()
    {
      ImGuiNative.igShowDebugLogWindow((byte*) null);
    }

    public static unsafe void ShowDebugLogWindow(ref bool p_open)
    {
      byte num = p_open ? (byte) 1 : (byte) 0;
      ImGuiNative.igShowDebugLogWindow(&num);
      p_open = num > (byte) 0;
    }

    public static unsafe void ShowDemoWindow() => ImGuiNative.igShowDemoWindow((byte*) null);

    public static unsafe void ShowDemoWindow(ref bool p_open)
    {
      byte num = p_open ? (byte) 1 : (byte) 0;
      ImGuiNative.igShowDemoWindow(&num);
      p_open = num > (byte) 0;
    }

    public static unsafe void ShowFontSelector(string label)
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
      ImGuiNative.igShowFontSelector(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void ShowMetricsWindow() => ImGuiNative.igShowMetricsWindow((byte*) null);

    public static unsafe void ShowMetricsWindow(ref bool p_open)
    {
      byte num = p_open ? (byte) 1 : (byte) 0;
      ImGuiNative.igShowMetricsWindow(&num);
      p_open = num > (byte) 0;
    }

    public static unsafe void ShowStackToolWindow()
    {
      ImGuiNative.igShowStackToolWindow((byte*) null);
    }

    public static unsafe void ShowStackToolWindow(ref bool p_open)
    {
      byte num = p_open ? (byte) 1 : (byte) 0;
      ImGuiNative.igShowStackToolWindow(&num);
      p_open = num > (byte) 0;
    }

    public static unsafe void ShowStyleEditor()
    {
      ImGuiNative.igShowStyleEditor((ImGuiStyle*) null);
    }

    public static unsafe void ShowStyleEditor(ImGuiStylePtr @ref)
    {
      ImGuiNative.igShowStyleEditor(@ref.NativePtr);
    }

    public static unsafe bool ShowStyleSelector(string label)
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
      int num = (int) ImGuiNative.igShowStyleSelector(numPtr);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static void ShowUserGuide() => ImGuiNative.igShowUserGuide();

    public static unsafe bool SliderAngle(string label, ref float v_rad)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_degrees_min = -360f;
      float v_degrees_max = 360f;
      int byteCount = Encoding.UTF8.GetByteCount("%.0f deg");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.0f deg", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_rad1 = &v_rad)
      {
        int num = (int) ImGuiNative.igSliderAngle(numPtr1, v_rad1, v_degrees_min, v_degrees_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderAngle(string label, ref float v_rad, float v_degrees_min)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      float v_degrees_max = 360f;
      int byteCount = Encoding.UTF8.GetByteCount("%.0f deg");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.0f deg", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_rad1 = &v_rad)
      {
        int num = (int) ImGuiNative.igSliderAngle(numPtr1, v_rad1, v_degrees_min, v_degrees_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderAngle(
      string label,
      ref float v_rad,
      float v_degrees_min,
      float v_degrees_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.0f deg");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.0f deg", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_rad1 = &v_rad)
      {
        int num = (int) ImGuiNative.igSliderAngle(numPtr1, v_rad1, v_degrees_min, v_degrees_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderAngle(
      string label,
      ref float v_rad,
      float v_degrees_min,
      float v_degrees_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v_rad1 = &v_rad)
      {
        int num = (int) ImGuiNative.igSliderAngle(numPtr1, v_rad1, v_degrees_min, v_degrees_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderAngle(
      string label,
      ref float v_rad,
      float v_degrees_min,
      float v_degrees_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (float* v_rad1 = &v_rad)
      {
        int num = (int) ImGuiNative.igSliderAngle(numPtr1, v_rad1, v_degrees_min, v_degrees_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat(string label, ref float v, float v_min, float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat(
      string label,
      ref float v,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat(
      string label,
      ref float v,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat2(string label, ref Vector2 v, float v_min, float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat2(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat2(
      string label,
      ref Vector2 v,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat2(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat2(
      string label,
      ref Vector2 v,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector2* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat2(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat3(string label, ref Vector3 v, float v_min, float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat3(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat3(
      string label,
      ref Vector3 v,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat3(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat3(
      string label,
      ref Vector3 v,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector3* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat3(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat4(string label, ref Vector4 v, float v_min, float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat4(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat4(
      string label,
      ref Vector4 v,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat4(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderFloat4(
      string label,
      ref Vector4 v,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (Vector4* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderFloat4(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt(string label, ref int v, int v_min, int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt2(string label, ref int v, int v_min, int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt2(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt2(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt2(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt2(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt2(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt3(string label, ref int v, int v_min, int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt3(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt3(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt3(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt3(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt3(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt4(string label, ref int v, int v_min, int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt4(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt4(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt4(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderInt4(
      string label,
      ref int v,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igSliderInt4(numPtr1, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool SliderScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_min,
      IntPtr p_max)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igSliderScalar(numPtr, data_type, pointer1, pointer2, pointer3, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool SliderScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_min,
      IntPtr p_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igSliderScalar(numPtr1, data_type, pointer1, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool SliderScalar(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_min,
      IntPtr p_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igSliderScalar(numPtr1, data_type, pointer1, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool SliderScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      IntPtr p_min,
      IntPtr p_max)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igSliderScalarN(numPtr, data_type, pointer1, components, pointer2, pointer3, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool SliderScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      IntPtr p_min,
      IntPtr p_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igSliderScalarN(numPtr1, data_type, pointer1, components, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool SliderScalarN(
      string label,
      ImGuiDataType data_type,
      IntPtr p_data,
      int components,
      IntPtr p_min,
      IntPtr p_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igSliderScalarN(numPtr1, data_type, pointer1, components, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool SmallButton(string label)
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
      int num = (int) ImGuiNative.igSmallButton(numPtr);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static void Spacing() => ImGuiNative.igSpacing();

    public static unsafe void StyleColorsClassic()
    {
      ImGuiNative.igStyleColorsClassic((ImGuiStyle*) null);
    }

    public static unsafe void StyleColorsClassic(ImGuiStylePtr dst)
    {
      ImGuiNative.igStyleColorsClassic(dst.NativePtr);
    }

    public static unsafe void StyleColorsDark()
    {
      ImGuiNative.igStyleColorsDark((ImGuiStyle*) null);
    }

    public static unsafe void StyleColorsDark(ImGuiStylePtr dst)
    {
      ImGuiNative.igStyleColorsDark(dst.NativePtr);
    }

    public static unsafe void StyleColorsLight()
    {
      ImGuiNative.igStyleColorsLight((ImGuiStyle*) null);
    }

    public static unsafe void StyleColorsLight(ImGuiStylePtr dst)
    {
      ImGuiNative.igStyleColorsLight(dst.NativePtr);
    }

    public static unsafe bool TabItemButton(string label)
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
      ImGuiTabItemFlags flags = ImGuiTabItemFlags.None;
      int num = (int) ImGuiNative.igTabItemButton(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool TabItemButton(string label, ImGuiTabItemFlags flags)
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
      int num = (int) ImGuiNative.igTabItemButton(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static int TableGetColumnCount() => ImGuiNative.igTableGetColumnCount();

    public static ImGuiTableColumnFlags TableGetColumnFlags()
    {
      return ImGuiNative.igTableGetColumnFlags(-1);
    }

    public static ImGuiTableColumnFlags TableGetColumnFlags(int column_n)
    {
      return ImGuiNative.igTableGetColumnFlags(column_n);
    }

    public static int TableGetColumnIndex() => ImGuiNative.igTableGetColumnIndex();

    public static unsafe string TableGetColumnName()
    {
      return Util.StringFromPtr(ImGuiNative.igTableGetColumnName_Int(-1));
    }

    public static unsafe string TableGetColumnName(int column_n)
    {
      return Util.StringFromPtr(ImGuiNative.igTableGetColumnName_Int(column_n));
    }

    public static int TableGetRowIndex() => ImGuiNative.igTableGetRowIndex();

    public static unsafe ImGuiTableSortSpecsPtr TableGetSortSpecs()
    {
      return new ImGuiTableSortSpecsPtr(ImGuiNative.igTableGetSortSpecs());
    }

    public static unsafe void TableHeader(string label)
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
      ImGuiNative.igTableHeader(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void TableHeadersRow() => ImGuiNative.igTableHeadersRow();

    public static bool TableNextColumn() => ImGuiNative.igTableNextColumn() > (byte) 0;

    public static void TableNextRow() => ImGuiNative.igTableNextRow(ImGuiTableRowFlags.None, 0.0f);

    public static void TableNextRow(ImGuiTableRowFlags row_flags)
    {
      float min_row_height = 0.0f;
      ImGuiNative.igTableNextRow(row_flags, min_row_height);
    }

    public static void TableNextRow(ImGuiTableRowFlags row_flags, float min_row_height)
    {
      ImGuiNative.igTableNextRow(row_flags, min_row_height);
    }

    public static void TableSetBgColor(ImGuiTableBgTarget target, uint color)
    {
      int column_n = -1;
      ImGuiNative.igTableSetBgColor(target, color, column_n);
    }

    public static void TableSetBgColor(ImGuiTableBgTarget target, uint color, int column_n)
    {
      ImGuiNative.igTableSetBgColor(target, color, column_n);
    }

    public static void TableSetColumnEnabled(int column_n, bool v)
    {
      byte v1 = v ? (byte) 1 : (byte) 0;
      ImGuiNative.igTableSetColumnEnabled(column_n, v1);
    }

    public static bool TableSetColumnIndex(int column_n)
    {
      return ImGuiNative.igTableSetColumnIndex(column_n) > (byte) 0;
    }

    public static unsafe void TableSetupColumn(string label)
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
      ImGuiTableColumnFlags flags = ImGuiTableColumnFlags.None;
      float init_width_or_weight = 0.0f;
      uint user_id = 0;
      ImGuiNative.igTableSetupColumn(numPtr, flags, init_width_or_weight, user_id);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TableSetupColumn(string label, ImGuiTableColumnFlags flags)
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
      float init_width_or_weight = 0.0f;
      uint user_id = 0;
      ImGuiNative.igTableSetupColumn(numPtr, flags, init_width_or_weight, user_id);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TableSetupColumn(
      string label,
      ImGuiTableColumnFlags flags,
      float init_width_or_weight)
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
      uint user_id = 0;
      ImGuiNative.igTableSetupColumn(numPtr, flags, init_width_or_weight, user_id);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TableSetupColumn(
      string label,
      ImGuiTableColumnFlags flags,
      float init_width_or_weight,
      uint user_id)
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
      ImGuiNative.igTableSetupColumn(numPtr, flags, init_width_or_weight, user_id);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static void TableSetupScrollFreeze(int cols, int rows)
    {
      ImGuiNative.igTableSetupScrollFreeze(cols, rows);
    }

    public static unsafe void Text(string fmt)
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
      ImGuiNative.igText(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TextColored(Vector4 col, string fmt)
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
      ImGuiNative.igTextColored(col, numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TextDisabled(string fmt)
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
      ImGuiNative.igTextDisabled(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TextUnformatted(string text)
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
      ImGuiNative.igTextUnformatted(numPtr, text_end);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TextWrapped(string fmt)
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
      ImGuiNative.igTextWrapped(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe bool TreeNode(string label)
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
      int num = (int) ImGuiNative.igTreeNode_Str(numPtr);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool TreeNode(string str_id, string fmt)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (str_id != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(str_id);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (fmt != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(fmt);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(fmt, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igTreeNode_StrStr(numPtr1, numPtr2);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool TreeNode(IntPtr ptr_id, string fmt)
    {
      void* pointer = ptr_id.ToPointer();
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
      int num = (int) ImGuiNative.igTreeNode_Ptr(pointer, numPtr);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool TreeNodeEx(string label)
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
      ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
      int num = (int) ImGuiNative.igTreeNodeEx_Str(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool TreeNodeEx(string label, ImGuiTreeNodeFlags flags)
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
      int num = (int) ImGuiNative.igTreeNodeEx_Str(numPtr, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool TreeNodeEx(string str_id, ImGuiTreeNodeFlags flags, string fmt)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (str_id != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(str_id);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (fmt != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(fmt);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(fmt, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igTreeNodeEx_StrStr(numPtr1, flags, numPtr2);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool TreeNodeEx(IntPtr ptr_id, ImGuiTreeNodeFlags flags, string fmt)
    {
      void* pointer = ptr_id.ToPointer();
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
      int num = (int) ImGuiNative.igTreeNodeEx_Ptr(pointer, flags, numPtr);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static void TreePop() => ImGuiNative.igTreePop();

    public static unsafe void TreePush(string str_id)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (str_id != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(str_id);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(str_id, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igTreePush_Str(numPtr);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void TreePush() => ImGuiNative.igTreePush_Ptr((void*) null);

    public static unsafe void TreePush(IntPtr ptr_id)
    {
      ImGuiNative.igTreePush_Ptr(ptr_id.ToPointer());
    }

    public static void Unindent() => ImGuiNative.igUnindent(0.0f);

    public static void Unindent(float indent_w) => ImGuiNative.igUnindent(indent_w);

    public static void UpdatePlatformWindows() => ImGuiNative.igUpdatePlatformWindows();

    public static unsafe void Value(string prefix, bool b)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (prefix != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(prefix);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(prefix, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte b1 = b ? (byte) 1 : (byte) 0;
      ImGuiNative.igValue_Bool(numPtr, b1);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void Value(string prefix, int v)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (prefix != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(prefix);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(prefix, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igValue_Int(numPtr, v);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void Value(string prefix, uint v)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (prefix != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(prefix);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(prefix, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      ImGuiNative.igValue_Uint(numPtr, v);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void Value(string prefix, float v)
    {
      int utf8ByteCount = 0;
      byte* numPtr;
      if (prefix != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(prefix);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(prefix, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
      }
      else
        numPtr = (byte*) null;
      byte* float_format = (byte*) null;
      ImGuiNative.igValue_Float(numPtr, v, float_format);
      if (utf8ByteCount <= 2048)
        return;
      Util.Free(numPtr);
    }

    public static unsafe void Value(string prefix, float v, string float_format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (prefix != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(prefix);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(prefix, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (float_format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(float_format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(float_format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiNative.igValue_Float(numPtr1, v, numPtr2);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 <= 2048)
        return;
      Util.Free(numPtr2);
    }

    public static unsafe bool VSliderFloat(
      string label,
      Vector2 size,
      ref float v,
      float v_min,
      float v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%.3f");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%.3f", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igVSliderFloat(numPtr1, size, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool VSliderFloat(
      string label,
      Vector2 size,
      ref float v,
      float v_min,
      float v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igVSliderFloat(numPtr1, size, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool VSliderFloat(
      string label,
      Vector2 size,
      ref float v,
      float v_min,
      float v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (float* v1 = &v)
      {
        int num = (int) ImGuiNative.igVSliderFloat(numPtr1, size, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool VSliderInt(
      string label,
      Vector2 size,
      ref int v,
      int v_min,
      int v_max)
    {
      int utf8ByteCount = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int byteCount = Encoding.UTF8.GetByteCount("%d");
      byte* numPtr2 = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      int utf8_1 = Util.GetUtf8("%d", numPtr2, byteCount);
      numPtr2[utf8_1] = (byte) 0;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igVSliderInt(numPtr1, size, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount > 2048)
          Util.Free(numPtr1);
        if (byteCount > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool VSliderInt(
      string label,
      Vector2 size,
      ref int v,
      int v_min,
      int v_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igVSliderInt(numPtr1, size, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool VSliderInt(
      string label,
      Vector2 size,
      ref int v,
      int v_min,
      int v_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      fixed (int* v1 = &v)
      {
        int num = (int) ImGuiNative.igVSliderInt(numPtr1, size, v1, v_min, v_max, numPtr2, flags);
        if (utf8ByteCount1 > 2048)
          Util.Free(numPtr1);
        if (utf8ByteCount2 > 2048)
          Util.Free(numPtr2);
        return (uint) num > 0U;
      }
    }

    public static unsafe bool VSliderScalar(
      string label,
      Vector2 size,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_min,
      IntPtr p_max)
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
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      byte* format = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igVSliderScalar(numPtr, size, data_type, pointer1, pointer2, pointer3, format, flags);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static unsafe bool VSliderScalar(
      string label,
      Vector2 size,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_min,
      IntPtr p_max,
      string format)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      ImGuiSliderFlags flags = ImGuiSliderFlags.None;
      int num = (int) ImGuiNative.igVSliderScalar(numPtr1, size, data_type, pointer1, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static unsafe bool VSliderScalar(
      string label,
      Vector2 size,
      ImGuiDataType data_type,
      IntPtr p_data,
      IntPtr p_min,
      IntPtr p_max,
      string format,
      ImGuiSliderFlags flags)
    {
      int utf8ByteCount1 = 0;
      byte* numPtr1;
      if (label != null)
      {
        utf8ByteCount1 = Encoding.UTF8.GetByteCount(label);
        numPtr1 = utf8ByteCount1 <= 2048 ? stackalloc byte[utf8ByteCount1 + 1] : Util.Allocate(utf8ByteCount1 + 1);
        int utf8 = Util.GetUtf8(label, numPtr1, utf8ByteCount1);
        numPtr1[utf8] = (byte) 0;
      }
      else
        numPtr1 = (byte*) null;
      void* pointer1 = p_data.ToPointer();
      void* pointer2 = p_min.ToPointer();
      void* pointer3 = p_max.ToPointer();
      int utf8ByteCount2 = 0;
      byte* numPtr2;
      if (format != null)
      {
        utf8ByteCount2 = Encoding.UTF8.GetByteCount(format);
        numPtr2 = utf8ByteCount2 <= 2048 ? stackalloc byte[utf8ByteCount2 + 1] : Util.Allocate(utf8ByteCount2 + 1);
        int utf8 = Util.GetUtf8(format, numPtr2, utf8ByteCount2);
        numPtr2[utf8] = (byte) 0;
      }
      else
        numPtr2 = (byte*) null;
      int num = (int) ImGuiNative.igVSliderScalar(numPtr1, size, data_type, pointer1, pointer2, pointer3, numPtr2, flags);
      if (utf8ByteCount1 > 2048)
        Util.Free(numPtr1);
      if (utf8ByteCount2 > 2048)
        Util.Free(numPtr2);
      return (uint) num > 0U;
    }

    public static bool InputText(string label, byte[] buf, uint buf_size)
    {
      return ImGui.InputText(label, buf, buf_size, ImGuiInputTextFlags.None, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputText(
      string label,
      byte[] buf,
      uint buf_size,
      ImGuiInputTextFlags flags)
    {
      return ImGui.InputText(label, buf, buf_size, flags, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputText(
      string label,
      byte[] buf,
      uint buf_size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback)
    {
      return ImGui.InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
    }

    public static unsafe bool InputText(
      string label,
      byte[] buf,
      uint buf_size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      IntPtr user_data)
    {
      int byteCount = Encoding.UTF8.GetByteCount(label);
      byte* numPtr = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      Util.GetUtf8(label, numPtr, byteCount);
      int num;
      fixed (byte* buf1 = buf)
        num = ImGuiNative.igInputText(numPtr, buf1, buf_size, flags, callback, user_data.ToPointer()) > (byte) 0 ? 1 : 0;
      if (byteCount <= 2048)
        return num != 0;
      Util.Free(numPtr);
      return num != 0;
    }

    public static bool InputText(string label, ref string input, uint maxLength)
    {
      return ImGui.InputText(label, ref input, maxLength, ImGuiInputTextFlags.None, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputText(
      string label,
      ref string input,
      uint maxLength,
      ImGuiInputTextFlags flags)
    {
      return ImGui.InputText(label, ref input, maxLength, flags, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputText(
      string label,
      ref string input,
      uint maxLength,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback)
    {
      return ImGui.InputText(label, ref input, maxLength, flags, callback, IntPtr.Zero);
    }

    public static unsafe bool InputText(
      string label,
      ref string input,
      uint maxLength,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      IntPtr user_data)
    {
      int byteCount1 = Encoding.UTF8.GetByteCount(label);
      byte* numPtr1 = byteCount1 <= 2048 ? stackalloc byte[byteCount1 + 1] : Util.Allocate(byteCount1 + 1);
      Util.GetUtf8(label, numPtr1, byteCount1);
      int byteCount2 = Encoding.UTF8.GetByteCount(input);
      int num1 = Math.Max((int) maxLength + 1, byteCount2 + 1);
      byte* numPtr2;
      byte* numPtr3;
      if (num1 > 2048)
      {
        numPtr2 = Util.Allocate(num1);
        numPtr3 = Util.Allocate(num1);
      }
      else
      {
        numPtr2 = stackalloc byte[num1];
        numPtr3 = stackalloc byte[num1];
      }
      Util.GetUtf8(input, numPtr2, num1);
      uint byteCount3 = (uint) (num1 - byteCount2);
      Unsafe.InitBlockUnaligned((void*) (numPtr2 + byteCount2), (byte) 0, byteCount3);
      Unsafe.CopyBlock((void*) numPtr3, (void*) numPtr2, (uint) num1);
      byte num2 = ImGuiNative.igInputText(numPtr1, numPtr2, (uint) num1, flags, callback, user_data.ToPointer());
      if (!Util.AreStringsEqual(numPtr3, num1, numPtr2))
        input = Util.StringFromPtr(numPtr2);
      if (byteCount1 > 2048)
        Util.Free(numPtr1);
      if (num1 > 2048)
      {
        Util.Free(numPtr2);
        Util.Free(numPtr3);
      }
      return num2 > (byte) 0;
    }

    public static bool InputTextMultiline(
      string label,
      ref string input,
      uint maxLength,
      Vector2 size)
    {
      return ImGui.InputTextMultiline(label, ref input, maxLength, size, ImGuiInputTextFlags.None, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputTextMultiline(
      string label,
      ref string input,
      uint maxLength,
      Vector2 size,
      ImGuiInputTextFlags flags)
    {
      return ImGui.InputTextMultiline(label, ref input, maxLength, size, flags, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputTextMultiline(
      string label,
      ref string input,
      uint maxLength,
      Vector2 size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback)
    {
      return ImGui.InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);
    }

    public static unsafe bool InputTextMultiline(
      string label,
      ref string input,
      uint maxLength,
      Vector2 size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      IntPtr user_data)
    {
      int byteCount1 = Encoding.UTF8.GetByteCount(label);
      byte* numPtr1 = byteCount1 <= 2048 ? stackalloc byte[byteCount1 + 1] : Util.Allocate(byteCount1 + 1);
      Util.GetUtf8(label, numPtr1, byteCount1);
      int byteCount2 = Encoding.UTF8.GetByteCount(input);
      int num1 = Math.Max((int) maxLength + 1, byteCount2 + 1);
      byte* numPtr2;
      byte* numPtr3;
      if (num1 > 2048)
      {
        numPtr2 = Util.Allocate(num1);
        numPtr3 = Util.Allocate(num1);
      }
      else
      {
        numPtr2 = stackalloc byte[num1];
        numPtr3 = stackalloc byte[num1];
      }
      Util.GetUtf8(input, numPtr2, num1);
      uint byteCount3 = (uint) (num1 - byteCount2);
      Unsafe.InitBlockUnaligned((void*) (numPtr2 + byteCount2), (byte) 0, byteCount3);
      Unsafe.CopyBlock((void*) numPtr3, (void*) numPtr2, (uint) num1);
      byte num2 = ImGuiNative.igInputTextMultiline(numPtr1, numPtr2, (uint) num1, size, flags, callback, user_data.ToPointer());
      if (!Util.AreStringsEqual(numPtr3, num1, numPtr2))
        input = Util.StringFromPtr(numPtr2);
      if (byteCount1 > 2048)
        Util.Free(numPtr1);
      if (num1 > 2048)
      {
        Util.Free(numPtr2);
        Util.Free(numPtr3);
      }
      return num2 > (byte) 0;
    }

    public static bool InputTextWithHint(
      string label,
      string hint,
      ref string input,
      uint maxLength)
    {
      return ImGui.InputTextWithHint(label, hint, ref input, maxLength, ImGuiInputTextFlags.None, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputTextWithHint(
      string label,
      string hint,
      ref string input,
      uint maxLength,
      ImGuiInputTextFlags flags)
    {
      return ImGui.InputTextWithHint(label, hint, ref input, maxLength, flags, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputTextWithHint(
      string label,
      string hint,
      ref string input,
      uint maxLength,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback)
    {
      return ImGui.InputTextWithHint(label, hint, ref input, maxLength, flags, callback, IntPtr.Zero);
    }

    public static unsafe bool InputTextWithHint(
      string label,
      string hint,
      ref string input,
      uint maxLength,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      IntPtr user_data)
    {
      int byteCount1 = Encoding.UTF8.GetByteCount(label);
      byte* numPtr1 = byteCount1 <= 2048 ? stackalloc byte[byteCount1 + 1] : Util.Allocate(byteCount1 + 1);
      Util.GetUtf8(label, numPtr1, byteCount1);
      int byteCount2 = Encoding.UTF8.GetByteCount(hint);
      byte* numPtr2 = byteCount2 <= 2048 ? stackalloc byte[byteCount2 + 1] : Util.Allocate(byteCount2 + 1);
      Util.GetUtf8(hint, numPtr2, byteCount2);
      int byteCount3 = Encoding.UTF8.GetByteCount(input);
      int num1 = Math.Max((int) maxLength + 1, byteCount3 + 1);
      byte* numPtr3;
      byte* numPtr4;
      if (num1 > 2048)
      {
        numPtr3 = Util.Allocate(num1);
        numPtr4 = Util.Allocate(num1);
      }
      else
      {
        numPtr3 = stackalloc byte[num1];
        numPtr4 = stackalloc byte[num1];
      }
      Util.GetUtf8(input, numPtr3, num1);
      uint byteCount4 = (uint) (num1 - byteCount3);
      Unsafe.InitBlockUnaligned((void*) (numPtr3 + byteCount3), (byte) 0, byteCount4);
      Unsafe.CopyBlock((void*) numPtr4, (void*) numPtr3, (uint) num1);
      byte num2 = ImGuiNative.igInputTextWithHint(numPtr1, numPtr2, numPtr3, (uint) num1, flags, callback, user_data.ToPointer());
      if (!Util.AreStringsEqual(numPtr4, num1, numPtr3))
        input = Util.StringFromPtr(numPtr3);
      if (byteCount1 > 2048)
        Util.Free(numPtr1);
      if (byteCount2 > 2048)
        Util.Free(numPtr2);
      if (num1 > 2048)
      {
        Util.Free(numPtr3);
        Util.Free(numPtr4);
      }
      return num2 > (byte) 0;
    }

    public static Vector2 CalcTextSize(string text) => ImGui.CalcTextSizeImpl(text);

    public static Vector2 CalcTextSize(string text, int start)
    {
      return ImGui.CalcTextSizeImpl(text, start);
    }

    public static Vector2 CalcTextSize(string text, float wrapWidth)
    {
      string text1 = text;
      float num = wrapWidth;
      int? length = new int?();
      double wrapWidth1 = (double) num;
      return ImGui.CalcTextSizeImpl(text1, length: length, wrapWidth: (float) wrapWidth1);
    }

    public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
    {
      string text1 = text;
      bool flag = hideTextAfterDoubleHash;
      int? length = new int?();
      int num = flag ? 1 : 0;
      return ImGui.CalcTextSizeImpl(text1, length: length, hideTextAfterDoubleHash: num != 0);
    }

    public static Vector2 CalcTextSize(string text, int start, int length)
    {
      return ImGui.CalcTextSizeImpl(text, start, new int?(length));
    }

    public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
    {
      string text1 = text;
      int start1 = start;
      bool flag = hideTextAfterDoubleHash;
      int? length = new int?();
      int num = flag ? 1 : 0;
      return ImGui.CalcTextSizeImpl(text1, start1, length, num != 0);
    }

    public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
    {
      string text1 = text;
      int start1 = start;
      float num = wrapWidth;
      int? length = new int?();
      double wrapWidth1 = (double) num;
      return ImGui.CalcTextSizeImpl(text1, start1, length, wrapWidth: (float) wrapWidth1);
    }

    public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
    {
      string text1 = text;
      bool flag = hideTextAfterDoubleHash;
      float num1 = wrapWidth;
      int? length = new int?();
      int num2 = flag ? 1 : 0;
      double wrapWidth1 = (double) num1;
      return ImGui.CalcTextSizeImpl(text1, length: length, hideTextAfterDoubleHash: num2 != 0, wrapWidth: (float) wrapWidth1);
    }

    public static Vector2 CalcTextSize(
      string text,
      int start,
      int length,
      bool hideTextAfterDoubleHash)
    {
      return ImGui.CalcTextSizeImpl(text, start, new int?(length), hideTextAfterDoubleHash);
    }

    public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
    {
      return ImGui.CalcTextSizeImpl(text, start, new int?(length), wrapWidth: wrapWidth);
    }

    public static Vector2 CalcTextSize(
      string text,
      int start,
      int length,
      bool hideTextAfterDoubleHash,
      float wrapWidth)
    {
      return ImGui.CalcTextSizeImpl(text, start, new int?(length), hideTextAfterDoubleHash, wrapWidth);
    }

    private static unsafe Vector2 CalcTextSizeImpl(
      string text,
      int start = 0,
      int? length = null,
      bool hideTextAfterDoubleHash = false,
      float wrapWidth = -1f)
    {
      byte* numPtr = (byte*) null;
      byte* text_end = (byte*) null;
      int utf8ByteCount = 0;
      if (text != null)
      {
        int length1 = length.HasValue ? length.Value : text.Length;
        utf8ByteCount = Util.CalcSizeInUtf8(text, start, length1);
        numPtr = utf8ByteCount <= 2048 ? stackalloc byte[utf8ByteCount + 1] : Util.Allocate(utf8ByteCount + 1);
        int utf8 = Util.GetUtf8(text, start, length1, numPtr, utf8ByteCount);
        numPtr[utf8] = (byte) 0;
        text_end = numPtr + utf8;
      }
      Vector2 vector2;
      ImGuiNative.igCalcTextSize(&vector2, numPtr, text_end, (byte) hideTextAfterDoubleHash, wrapWidth);
      if (utf8ByteCount > 2048)
        Util.Free(numPtr);
      return vector2;
    }

    public static bool InputText(string label, IntPtr buf, uint buf_size)
    {
      return ImGui.InputText(label, buf, buf_size, ImGuiInputTextFlags.None, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputText(
      string label,
      IntPtr buf,
      uint buf_size,
      ImGuiInputTextFlags flags)
    {
      return ImGui.InputText(label, buf, buf_size, flags, (ImGuiInputTextCallback) null, IntPtr.Zero);
    }

    public static bool InputText(
      string label,
      IntPtr buf,
      uint buf_size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback)
    {
      return ImGui.InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
    }

    public static unsafe bool InputText(
      string label,
      IntPtr buf,
      uint buf_size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      IntPtr user_data)
    {
      int byteCount = Encoding.UTF8.GetByteCount(label);
      byte* numPtr = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      Util.GetUtf8(label, numPtr, byteCount);
      int num = ImGuiNative.igInputText(numPtr, (byte*) buf.ToPointer(), buf_size, flags, callback, user_data.ToPointer()) > (byte) 0 ? 1 : 0;
      if (byteCount <= 2048)
        return num != 0;
      Util.Free(numPtr);
      return num != 0;
    }

    public static unsafe bool Begin(string name, ImGuiWindowFlags flags)
    {
      int byteCount = Encoding.UTF8.GetByteCount(name);
      byte* numPtr = byteCount <= 2048 ? stackalloc byte[byteCount + 1] : Util.Allocate(byteCount + 1);
      Util.GetUtf8(name, numPtr, byteCount);
      byte* p_open = (byte*) null;
      int num = (int) ImGuiNative.igBegin(numPtr, p_open, flags);
      if (byteCount > 2048)
        Util.Free(numPtr);
      return (uint) num > 0U;
    }

    public static bool MenuItem(string label, bool enabled)
    {
      return ImGui.MenuItem(label, string.Empty, false, enabled);
    }
  }
}
