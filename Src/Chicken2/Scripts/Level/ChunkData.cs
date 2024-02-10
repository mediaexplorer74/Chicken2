// Decompiled with JetBrains decompiler
// Type: ChickenRemake.ChunkData
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public struct ChunkData
  {
    private Color[,] textureData;
    private ChickenRemake.TileData[,] tileData;
    private int tileWidth;
    private int tileHeight;

    public Color[,] TextureData => this.textureData;

    public ChickenRemake.TileData[,] TileData => this.tileData;

    public int TextureWidth => this.TextureData.GetLength(0);

    public int TextureHeight => this.TextureData.GetLength(1);

    public int Width => this.TileData.GetLength(0);

    public int Height => this.TileData.GetLength(1);

    public int TileWidth => this.tileWidth;

    public int TileHeight => this.tileHeight;

    public ChunkData(Texture2D texture, int tileWidth, int tileHeight)
    {
      if (tileWidth <= 0)
        tileWidth = 1;
      if (tileHeight <= 0)
        tileHeight = 1;
      this.textureData = texture.GetData();
      this.tileData = new ChickenRemake.TileData[this.textureData.GetLength(0) / tileWidth, this.textureData.GetLength(1) / tileHeight];
      this.tileWidth = tileWidth;
      this.tileHeight = tileHeight;
      this.SetTileData();
    }

    private void SetTileData()
    {
      for (int y = 0; y < this.textureData.GetLength(1) / this.tileHeight; ++y)
      {
        for (int x = 0; x < this.textureData.GetLength(0) / this.tileWidth; ++x)
        {
          Color[,] tileTexture = this.GetTileTexture(x * this.tileWidth, y * this.tileHeight);
          this.tileData[x, y] = new ChickenRemake.TileData(x, y, tileTexture);
        }
      }
    }

    private Color[,] GetTileTexture(int xPosition, int yPosition)
    {
      Color[,] tileTexture = new Color[this.tileWidth, this.tileHeight];
      for (int index1 = 0; index1 < this.tileWidth; ++index1)
      {
        for (int index2 = 0; index2 < this.tileHeight; ++index2)
          tileTexture[index1, index2] = this.textureData[xPosition + index1, yPosition + index2];
      }
      return tileTexture;
    }

    public List<ChickenRemake.TileData> GetColumn(int x)
    {
      List<ChickenRemake.TileData> column = new List<ChickenRemake.TileData>();
      for (int index = 0; index < this.Height; ++index)
        column.Add(this.TileData[x, index]);
      return column;
    }
  }
}
