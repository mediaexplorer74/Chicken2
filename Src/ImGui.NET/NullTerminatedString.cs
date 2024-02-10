// Decompiled with JetBrains decompiler
// Type: ImGuiNET.NullTerminatedString
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct NullTerminatedString
  {
    public readonly unsafe byte* Data;

    public unsafe NullTerminatedString(byte* data) => this.Data = data;

    public override unsafe string ToString()
    {
      int byteCount = 0;
      for (byte* data = this.Data; *data != (byte) 0; ++data)
        ++byteCount;
      return Encoding.ASCII.GetString(this.Data, byteCount);
    }

    public static implicit operator string(NullTerminatedString nts) => nts.ToString();
  }
}
