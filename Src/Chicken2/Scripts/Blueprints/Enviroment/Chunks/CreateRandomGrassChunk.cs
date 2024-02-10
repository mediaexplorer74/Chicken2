// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateRandomGrassChunk
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace ChickenRemake
{
  public class CreateRandomGrassChunk : CreateChunk
  {
    protected override Texture2D GetTexture()
    {
      return Content.GetTexture(Randomizer.Choose<string>("chunk1", "chunk2", "chunk3", "chunk4", "chunk5", "chunk6"));
    }

    public override void Decorate()
    {
      Func<CreateObstacle>[] obstacles = new Func<CreateObstacle>[3]
      {
        (Func<CreateObstacle>) (() => (CreateObstacle) Blueprint.Spawn<CreateRock>()),
        (Func<CreateObstacle>) (() => (CreateObstacle) Blueprint.Spawn<CreateRock>()),
        (Func<CreateObstacle>) (() => (CreateObstacle) Blueprint.Spawn<CreateMushroom>())
      };
      Func<CreateCoin>[] coins = new Func<CreateCoin>[1]
      {
        (Func<CreateCoin>) (() => (CreateCoin) Blueprint.Spawn<CreateDefaultCoin>())
      };
      this.RandomDecorate(obstacles, coins);
      this.PlaceRandomCoins(coins);
    }
  }
}
