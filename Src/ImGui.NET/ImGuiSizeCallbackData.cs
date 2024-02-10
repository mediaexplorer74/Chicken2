// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiSizeCallbackData
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiSizeCallbackData
  {
    public unsafe void* UserData;
    public Vector2 Pos;
    public Vector2 CurrentSize;
    public Vector2 DesiredSize;
  }
}
