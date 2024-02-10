// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiInputTextCallbackData
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiInputTextCallbackData
  {
    public ImGuiInputTextFlags EventFlag;
    public ImGuiInputTextFlags Flags;
    public unsafe void* UserData;
    public ushort EventChar;
    public ImGuiKey EventKey;
    public unsafe byte* Buf;
    public int BufTextLen;
    public int BufSize;
    public byte BufDirty;
    public int CursorPos;
    public int SelectionStart;
    public int SelectionEnd;
  }
}
