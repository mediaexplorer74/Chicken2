// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiInputTextFlags
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;

#nullable disable
namespace ImGuiNET
{
  [Flags]
  public enum ImGuiInputTextFlags
  {
    None = 0,
    CharsDecimal = 1,
    CharsHexadecimal = 2,
    CharsUppercase = 4,
    CharsNoBlank = 8,
    AutoSelectAll = 16, // 0x00000010
    EnterReturnsTrue = 32, // 0x00000020
    CallbackCompletion = 64, // 0x00000040
    CallbackHistory = 128, // 0x00000080
    CallbackAlways = 256, // 0x00000100
    CallbackCharFilter = 512, // 0x00000200
    AllowTabInput = 1024, // 0x00000400
    CtrlEnterForNewLine = 2048, // 0x00000800
    NoHorizontalScroll = 4096, // 0x00001000
    AlwaysOverwrite = 8192, // 0x00002000
    ReadOnly = 16384, // 0x00004000
    Password = 32768, // 0x00008000
    NoUndoRedo = 65536, // 0x00010000
    CharsScientific = 131072, // 0x00020000
    CallbackResize = 262144, // 0x00040000
    CallbackEdit = 524288, // 0x00080000
  }
}
