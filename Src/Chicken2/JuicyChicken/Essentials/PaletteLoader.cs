// Decompiled with JetBrains decompiler
// Type: JuicyChicken.PaletteLoader
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace JuicyChicken
{
  public static class PaletteLoader
  {
    private static Color[] currentPalette;
    private static List<IntPtr> pointers = new List<IntPtr>();

    public static void LoadPalette(Texture2D texture)
    {
      IntPtr num = JuicyChicken.Graphics.GuiRenderer.BindTexture(texture);
      PaletteLoader.pointers.Add(num);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
      interpolatedStringHandler.AppendLiteral("Added palette texture | ID: ");
      interpolatedStringHandler.AppendFormatted<IntPtr>(num);
      Debug.Log<string>(interpolatedStringHandler.ToStringAndClear());
      Color[] data = new Color[texture.Width * texture.Height];
      texture.GetData<Color>(data);
      PaletteLoader.currentPalette = data;
    }

    public static Color GetColor(int index)
    {
      return PaletteLoader.currentPalette == null || index > PaletteLoader.currentPalette.Length - 1 ? Color.White : PaletteLoader.currentPalette[index];
    }
  }
}
