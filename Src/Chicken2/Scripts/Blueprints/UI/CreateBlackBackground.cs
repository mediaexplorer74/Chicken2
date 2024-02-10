// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateBlackBackground
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;

#nullable disable
namespace ChickenRemake
{
  public class CreateBlackBackground : Blueprint
  {
    protected override void Construct()
    {
      Sprite sprite = this.GameObject.AddComponent<Sprite>();
      sprite.Texture = TextureGenerator.CreateBox((int) Graphics.CurrentResolution.X, (int) Graphics.CurrentResolution.Y, 0, Color.Black * 0.4f, Color.Transparent);
      sprite.Space = Space.Screen;
      sprite.Origin = OriginPoint.TopLeft;
      sprite.Layer = 1;
    }
  }
}
