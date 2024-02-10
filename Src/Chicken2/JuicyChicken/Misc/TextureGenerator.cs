// Decompiled with JetBrains decompiler
// Type: JuicyChicken.TextureGenerator
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace JuicyChicken
{
  public static class TextureGenerator
  {
    public static Texture2D CreateBox(
      int width,
      int height,
      int outlineWidth,
      Color color,
      Color outlineColor)
    {
      Texture2D texture = new Texture2D(JuicyChicken.Graphics.Device, width, height);
      Color[,] data = new Color[width, height];
      for (int index1 = 0; index1 < height; ++index1)
      {
        for (int index2 = 0; index2 < width; ++index2)
          data[index2, index1] = index2 < outlineWidth || index2 >= width - outlineWidth || index1 < outlineWidth || index1 >= height - outlineWidth ? outlineColor : color;
      }
      texture.SetData(data);
      return texture;
    }
  }
}
