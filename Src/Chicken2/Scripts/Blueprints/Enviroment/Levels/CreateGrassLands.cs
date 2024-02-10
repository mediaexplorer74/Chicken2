// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateGrassLands
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace ChickenRemake
{
  public class CreateGrassLands : CreateLevel
  {
    protected override Texture2D FrontBackground => Content.GetTexture("front");

    protected override Texture2D MidBackground => Content.GetTexture("mid");

    protected override Texture2D BackBackground => Content.GetTexture("back");

    protected override Texture2D TotallyBackBackground => Content.GetTexture("totallyback");

    protected override Texture2D BackdropBackground => Content.GetTexture("backdrop");

    protected override void GetChunks(ChunkSpawner chunkSpawner)
    {
      for (int index = 0; index < 10; ++index)
        chunkSpawner.AddBlueprint<CreateRandomGrassChunk>();
      chunkSpawner.AddBlueprint<CreateGrassPowerupChunk>();
    }
  }
}
