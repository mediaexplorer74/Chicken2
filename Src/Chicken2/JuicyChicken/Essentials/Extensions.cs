// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Extensions
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace JuicyChicken
{
  public static class Extensions
  {
    public static float Next(this Random random, float minValue, float maxValue)
    {
      return (float) (random.NextDouble() * ((double) maxValue - (double) minValue)) + minValue;
    }

    public static float Remap(this float value, Vector2 oldRange, Vector2 newRange)
    {
      return (float) (((double) value - (double) oldRange.X) / ((double) oldRange.Y - (double) oldRange.X) * ((double) newRange.Y - (double) newRange.X)) + newRange.X;
    }

    public static Vector2 GetPoint(this Texture2D texture, OriginPoint point)
    {
      if (texture == null)
        return Vector2.Zero;
      switch (point)
      {
        case OriginPoint.Top:
          return new Vector2((float) (texture.Width / 2), 0.0f);
        case OriginPoint.Bottom:
          return new Vector2((float) (texture.Width / 2), (float) texture.Height);
        case OriginPoint.Left:
          return new Vector2(0.0f, (float) (texture.Height / 2));
        case OriginPoint.Right:
          return new Vector2((float) texture.Width, (float) (texture.Height / 2));
        case OriginPoint.TopLeft:
          return Vector2.Zero;
        case OriginPoint.TopRight:
          return new Vector2((float) texture.Width, 0.0f);
        case OriginPoint.BottomLeft:
          return new Vector2(0.0f, (float) texture.Height);
        case OriginPoint.BottomRight:
          return new Vector2((float) texture.Width, (float) texture.Height);
        default:
          return new Vector2((float) (texture.Width / 2), (float) (texture.Height / 2));
      }
    }

    public static Vector2 GetSize(this Texture2D texture)
    {
      return new Vector2((float) texture.Width, (float) texture.Height);
    }

    public static Color[,] GetData(this Texture2D texture)
    {
      Color[] data1 = new Color[texture.Width * texture.Height];
      texture.GetData<Color>(data1);
      Color[,] data2 = new Color[texture.Width, texture.Height];
      for (int index1 = 0; index1 < texture.Width; ++index1)
      {
        for (int index2 = 0; index2 < texture.Height; ++index2)
          data2[index1, index2] = data1[index1 + index2 * texture.Width];
      }
      return data2;
    }

    public static void SetData(this Texture2D texture, Color[,] data)
    {
      Color[] data1 = new Color[texture.Width * texture.Height];
      int num = 0;
      for (int index1 = 0; index1 < data.GetLength(1); ++index1)
      {
        for (int index2 = 0; index2 < data.GetLength(0); ++index2)
          data1[num++] = data[index2, index1];
      }
      texture.SetData<Color>(data1);
    }

    public static Texture2D Slice(
      this Texture2D texture,
      int xIndex,
      int yIndex,
      int width,
      int height)
    {
      Color[,] data1 = texture.GetData();
      Texture2D texture1 = new Texture2D(JuicyChicken.Graphics.Device, width, height);
      Color[,] data2 = new Color[width, height];
      int num1 = xIndex * width;
      int num2 = yIndex * height;
      for (int index1 = num2; index1 < num2 + height; ++index1)
      {
        for (int index2 = num1; index2 < num1 + width; ++index2)
          data2[index2 - num1, index1 - num2] = data1[index2, index1];
      }
      texture1.SetData(data2);
      return texture1;
    }

    public static bool PointInside(this Vector2 position, Vector2 bounds, Vector2 point)
    {
      return (double) point.X < (double) position.X + (double) bounds.X && (double) point.X > (double) position.X && (double) point.Y < (double) position.Y + (double) bounds.Y && (double) point.Y > (double) position.Y;
    }
  }
}
