// Decompiled with JetBrains decompiler
// Type: ImGuiNET.RangeAccessorExtensions
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System.Text;

#nullable disable
namespace ImGuiNET
{
  public static class RangeAccessorExtensions
  {
    public static unsafe string GetStringASCII(this RangeAccessor<byte> stringAccessor)
    {
      return Encoding.ASCII.GetString((byte*) stringAccessor.Data, stringAccessor.Count);
    }
  }
}
