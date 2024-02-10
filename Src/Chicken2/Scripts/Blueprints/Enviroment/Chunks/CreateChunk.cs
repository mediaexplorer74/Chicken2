// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateChunk
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public abstract class CreateChunk : Blueprint
  {
    protected override void Construct()
    {
      this.GameObject.Tag = "Ground";
      this.GameObject.Layer = (Enum) ObjectLayer.Ground;
      this.GameObject.Static = true;
      Sprite sprite = this.GameObject.AddComponent<Sprite>();
      sprite.Texture = this.GetTexture();
      sprite.Origin = OriginPoint.TopLeft;
      ColliderGenerator.Generate(this.GameObject, ChunkReader.GetData(sprite.Texture, 16, 16), 0.33f);
    }

    public ChunkData GetChunkData()
    {
      return ChunkReader.GetData(this.GameObject.GetComponent<Sprite>().Texture, 16, 16);
    }

    protected void RandomDecorate(Func<CreateObstacle>[] obstacles, Func<CreateCoin>[] coins)
    {
      ChunkData chunkData = this.GetChunkData();
      int num1 = 4;
      int num2 = chunkData.Width / num1;
      List<TileData> tileDataList = new List<TileData>();
      for (int index1 = 0; index1 < chunkData.Width; ++index1)
      {
        for (int index2 = 0; index2 < chunkData.Height; ++index2)
        {
          TileData other = chunkData.TileData[index1, index2];
          TileData tileData = index2 == 0 ? other : chunkData.TileData[index1, index2 - 1];
          if (!other.IsEmpty(0.95f) && tileData.Equals(other) || !other.IsEmpty(0.95f) && tileData.IsEmpty(0.33f))
            tileDataList.Add(other);
        }
      }
      for (int index = 0; index < num2; ++index)
      {
        if (!Randomizer.Chance(0.5f))
        {
          TileData tileData = tileDataList[Randomizer.Next(0, tileDataList.Count)];
          tileDataList.Remove(tileData);
          Vector2 vector2 = new Vector2((float) tileData.X, (float) tileData.Y) * 16f + Vector2.UnitX * 8f;
          CreateObstacle createObstacle = Randomizer.Choose<Func<CreateObstacle>>(obstacles)();
          createObstacle.GameObject.SetParent(this.GameObject);
          createObstacle.GameObject.Transform.Position = vector2;
        }
      }
    }

    protected void PlaceRandomCoins(Func<CreateCoin>[] coins)
    {
      ChunkData chunkData = this.GetChunkData();
      int num1 = Randomizer.Next(chunkData.Width / 4, chunkData.Width);
      float num2 = Randomizer.Next(6f, 16f);
      Curve curve = new Curve();
      curve.Keys.Add(new CurveKey(0.0f, 0.0f));
      curve.Keys.Add(new CurveKey(0.5f, 1f));
      curve.Keys.Add(new CurveKey(1f, 0.0f));
      curve.ComputeTangents(CurveTangent.Smooth);
      for (int index = 0; index < num1; ++index)
      {
        TileData tileData = chunkData.TileData[index, 0];
        float position = (float) index / (float) num1;
        Vector2 vector2 = new Vector2((float) tileData.X, (float) tileData.Y) * 16f + Vector2.UnitX * 8f - Vector2.UnitY * num2 * curve.Evaluate(position);
        CreateCoin createCoin = Randomizer.Choose<Func<CreateCoin>>(coins)();
        createCoin.GameObject.SetParent(this.GameObject);
        createCoin.GameObject.Transform.Position = vector2;
      }
    }

    public abstract void Decorate();

    protected abstract Texture2D GetTexture();
  }
}
