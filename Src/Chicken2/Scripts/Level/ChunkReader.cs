// Decompiled with JetBrains decompiler
// Type: ChickenRemake.ChunkReader
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public static class ChunkReader
  {
    private static Dictionary<Texture2D, ChunkData> data = new Dictionary<Texture2D, ChunkData>();

    public static ChunkData GetData(Texture2D texture, int tileWidth, int tileHeight)
    {
      ChunkData data1;
      if (ChunkReader.data.TryGetValue(texture, out data1))
        return data1;
      ChunkData data2 = new ChunkData(texture, tileWidth, tileHeight);
      ChunkReader.data.Add(texture, data2);
      return data2;
    }
  }
}
