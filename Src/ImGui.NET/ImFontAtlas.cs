﻿// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImFontAtlas
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImFontAtlas
  {
    public ImFontAtlasFlags Flags;
    public IntPtr TexID;
    public int TexDesiredWidth;
    public int TexGlyphPadding;
    public byte Locked;
    public byte TexReady;
    public byte TexPixelsUseColors;
    public unsafe byte* TexPixelsAlpha8;
    public unsafe uint* TexPixelsRGBA32;
    public int TexWidth;
    public int TexHeight;
    public Vector2 TexUvScale;
    public Vector2 TexUvWhitePixel;
    public ImVector Fonts;
    public ImVector CustomRects;
    public ImVector ConfigData;
    public Vector4 TexUvLines_0;
    public Vector4 TexUvLines_1;
    public Vector4 TexUvLines_2;
    public Vector4 TexUvLines_3;
    public Vector4 TexUvLines_4;
    public Vector4 TexUvLines_5;
    public Vector4 TexUvLines_6;
    public Vector4 TexUvLines_7;
    public Vector4 TexUvLines_8;
    public Vector4 TexUvLines_9;
    public Vector4 TexUvLines_10;
    public Vector4 TexUvLines_11;
    public Vector4 TexUvLines_12;
    public Vector4 TexUvLines_13;
    public Vector4 TexUvLines_14;
    public Vector4 TexUvLines_15;
    public Vector4 TexUvLines_16;
    public Vector4 TexUvLines_17;
    public Vector4 TexUvLines_18;
    public Vector4 TexUvLines_19;
    public Vector4 TexUvLines_20;
    public Vector4 TexUvLines_21;
    public Vector4 TexUvLines_22;
    public Vector4 TexUvLines_23;
    public Vector4 TexUvLines_24;
    public Vector4 TexUvLines_25;
    public Vector4 TexUvLines_26;
    public Vector4 TexUvLines_27;
    public Vector4 TexUvLines_28;
    public Vector4 TexUvLines_29;
    public Vector4 TexUvLines_30;
    public Vector4 TexUvLines_31;
    public Vector4 TexUvLines_32;
    public Vector4 TexUvLines_33;
    public Vector4 TexUvLines_34;
    public Vector4 TexUvLines_35;
    public Vector4 TexUvLines_36;
    public Vector4 TexUvLines_37;
    public Vector4 TexUvLines_38;
    public Vector4 TexUvLines_39;
    public Vector4 TexUvLines_40;
    public Vector4 TexUvLines_41;
    public Vector4 TexUvLines_42;
    public Vector4 TexUvLines_43;
    public Vector4 TexUvLines_44;
    public Vector4 TexUvLines_45;
    public Vector4 TexUvLines_46;
    public Vector4 TexUvLines_47;
    public Vector4 TexUvLines_48;
    public Vector4 TexUvLines_49;
    public Vector4 TexUvLines_50;
    public Vector4 TexUvLines_51;
    public Vector4 TexUvLines_52;
    public Vector4 TexUvLines_53;
    public Vector4 TexUvLines_54;
    public Vector4 TexUvLines_55;
    public Vector4 TexUvLines_56;
    public Vector4 TexUvLines_57;
    public Vector4 TexUvLines_58;
    public Vector4 TexUvLines_59;
    public Vector4 TexUvLines_60;
    public Vector4 TexUvLines_61;
    public Vector4 TexUvLines_62;
    public Vector4 TexUvLines_63;
    public unsafe IntPtr* FontBuilderIO;
    public uint FontBuilderFlags;
    public int PackIdMouseCursors;
    public int PackIdLines;
  }
}
