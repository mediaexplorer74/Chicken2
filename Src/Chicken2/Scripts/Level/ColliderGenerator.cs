// Decompiled with JetBrains decompiler
// Type: ChickenRemake.ColliderGenerator
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public static class ColliderGenerator
  {
    private static GameObject gameObject;
    private static ChunkData chunkData;
    private static float emptyThreshold;

    public static void Generate(GameObject gameObject, ChunkData chunkData, float emptyThreshold)
    {
      ColliderGenerator.gameObject = gameObject;
      ColliderGenerator.chunkData = chunkData;
      ColliderGenerator.emptyThreshold = emptyThreshold;
      ColliderGenerator.Calculate();
    }

    private static void Calculate()
    {
      List<TileData> availableTiles = new List<TileData>();
      for (int index1 = 0; index1 < ColliderGenerator.chunkData.TileData.GetLength(1); ++index1)
      {
        for (int index2 = 0; index2 < ColliderGenerator.chunkData.TileData.GetLength(0); ++index2)
        {
          TileData tileData = ColliderGenerator.chunkData.TileData[index2, index1];
          if (!tileData.IsEmpty(ColliderGenerator.emptyThreshold))
            availableTiles.Add(tileData);
        }
      }
      while (availableTiles.Count > 0)
      {
        TileData tile = availableTiles[0];
        int lineLength1 = ColliderGenerator.GetLineLength(tile, availableTiles, true);
        int num = int.MaxValue;
        for (int index = 0; index < lineLength1; ++index)
        {
          int lineLength2 = ColliderGenerator.GetLineLength(ColliderGenerator.chunkData.TileData[tile.X + index, tile.Y], availableTiles, false);
          if (lineLength2 < num)
            num = lineLength2;
        }
        for (int index3 = 0; index3 < lineLength1; ++index3)
        {
          for (int index4 = 0; index4 < num; ++index4)
            availableTiles.Remove(ColliderGenerator.chunkData.TileData[tile.X + index3, tile.Y + index4]);
        }
        Collider collider = ColliderGenerator.gameObject.AddComponent<Collider>();
        collider.Size = new Vector2((float) (lineLength1 * ColliderGenerator.chunkData.TileWidth + 2), (float) (num * ColliderGenerator.chunkData.TileHeight));
        collider.Offset = new Vector2((float) (tile.X * ColliderGenerator.chunkData.TileWidth) + (float) (lineLength1 * ColliderGenerator.chunkData.TileWidth) * 0.5f, (float) (tile.Y * ColliderGenerator.chunkData.TileHeight) + (float) (num * ColliderGenerator.chunkData.TileHeight) * 0.5f);
      }
    }

    private static int GetLineLength(TileData tile, List<TileData> availableTiles, bool horizontal)
    {
      int lineLength = 0;
      int num = 0;
      bool flag = false;
      while (!flag)
      {
        int index1;
        int index2;
        if (horizontal)
        {
          index1 = tile.X + num;
          index2 = tile.Y;
        }
        else
        {
          index1 = tile.X;
          index2 = tile.Y + num;
        }
        ++num;
        if (index1 >= ColliderGenerator.chunkData.TileData.GetLength(0) || index2 >= ColliderGenerator.chunkData.TileData.GetLength(1) || !availableTiles.Contains(ColliderGenerator.chunkData.TileData[index1, index2]))
          flag = true;
        else if (ColliderGenerator.chunkData.TileData[index1, index2].IsEmpty(ColliderGenerator.emptyThreshold))
          flag = true;
        else
          ++lineLength;
      }
      return lineLength;
    }
  }
}
