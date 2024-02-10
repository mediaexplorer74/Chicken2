// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateGrassPowerupChunk
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace ChickenRemake
{
  public class CreateGrassPowerupChunk : CreateChunk
  {
    public override void Decorate()
    {
      ChunkData data = this.GetChunkData();
      CreatePowerUp createPowerUp = Randomizer.Choose<Func<CreatePowerUp>>((Func<CreatePowerUp>) (() =>
      {
        Vector2 position = new Vector2((float) (data.Width / 2 * 16), -20f);
        GameObject gameObject = this.GameObject;
        Vector2 scale = new Vector2();
        GameObject parent = gameObject;
        return (CreatePowerUp) Blueprint.Spawn<CreateCoinBoost>(position, scale: scale, parent: parent);
      }), (Func<CreatePowerUp>) (() =>
      {
        Vector2 position = new Vector2((float) (data.Width / 2 * 16), -20f);
        GameObject gameObject = this.GameObject;
        Vector2 scale = new Vector2();
        GameObject parent = gameObject;
        return (CreatePowerUp) Blueprint.Spawn<CreateDoubleJump>(position, scale: scale, parent: parent);
      }), (Func<CreatePowerUp>) (() =>
      {
        Vector2 position = new Vector2((float) (data.Width / 2 * 16), -20f);
        GameObject gameObject = this.GameObject;
        Vector2 scale = new Vector2();
        GameObject parent = gameObject;
        return (CreatePowerUp) Blueprint.Spawn<CreateSuperMagnet>(position, scale: scale, parent: parent);
      }))();
    }

    protected override Texture2D GetTexture() => Content.GetTexture("chunk1");
  }
}
