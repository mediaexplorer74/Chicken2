// Decompiled with JetBrains decompiler
// Type: ChickenRemake.TileData
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public struct TileData : IEquatable<TileData>
  {
    private float fillPercentage;
    private Color[,] tileTexture;
    private float width;
    private float height;

    public int X { get; private set; }

    public int Y { get; private set; }

    public TileData(int x, int y, Color[,] tileTexture)
    {
      this.X = x;
      this.Y = y;
      this.tileTexture = tileTexture;
      this.width = (float) tileTexture.GetLength(0);
      this.height = (float) tileTexture.GetLength(1);
      this.fillPercentage = 0.0f;
      this.fillPercentage = this.GetFillPercentage();
    }

    private float GetFillPercentage()
    {
      float num1 = this.width * this.height;
      int num2 = 0;
      for (int index1 = 0; (double) index1 < (double) this.width; ++index1)
      {
        for (int index2 = 0; (double) index2 < (double) this.height; ++index2)
        {
          if (this.tileTexture[index1, index2] != Color.Transparent)
            ++num2;
        }
      }
      return (float) num2 / num1;
    }

    public bool IsEmpty(float threshold)
    {
      threshold = MathHelper.Clamp(threshold, 0.0f, 1f);
      return (double) this.fillPercentage < (double) threshold;
    }

    public bool Equals(TileData other) => this.X == other.X && this.Y == other.Y;
  }
}
