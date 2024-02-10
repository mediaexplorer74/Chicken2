// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateCoinBoost
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace ChickenRemake
{
  public class CreateCoinBoost : CreatePowerUp
  {
    protected override float Duration => 15f;

    protected override Texture2D Texture => Content.GetTexture("coinboost");

    protected override string PowerUpName => "Coins x2";

    protected override Color PowerUpColor => PaletteLoader.GetColor(11);

    protected override void GetStartAction() => Stats.CoinMultiplier = 2;

    protected override void GetEndAction() => Stats.CoinMultiplier = 1;
  }
}
