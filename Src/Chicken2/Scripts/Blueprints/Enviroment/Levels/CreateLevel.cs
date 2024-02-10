// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateLevel
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace ChickenRemake
{
  public abstract class CreateLevel : Blueprint
  {
    protected abstract Texture2D FrontBackground { get; }

    protected abstract Texture2D MidBackground { get; }

    protected abstract Texture2D BackBackground { get; }

    protected abstract Texture2D TotallyBackBackground { get; }

    protected abstract Texture2D BackdropBackground { get; }

    protected override void Construct()
    {
      Level level = this.GameObject.AddComponent<Level>();
      level.SetBackground(this.FrontBackground, this.MidBackground, this.BackBackground, this.TotallyBackBackground, this.BackdropBackground);
      level.EventSpawner = this.GameObject.AddComponent<EventSpawner>();
      level.ChunkSpawner = this.GameObject.AddComponent<ChunkSpawner>();
      this.GetChunks(level.ChunkSpawner);
      level.ChunkSpawner.Begin();
    }

    protected abstract void GetChunks(ChunkSpawner chunkSpawner);
  }
}
