// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiPayload
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiPayload
  {
    public unsafe void* Data;
    public int DataSize;
    public uint SourceId;
    public uint SourceParentId;
    public int DataFrameCount;
    public unsafe fixed byte DataType[33];
    public byte Preview;
    public byte Delivery;
  }
}
