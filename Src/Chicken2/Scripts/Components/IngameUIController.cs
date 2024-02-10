// Decompiled with JetBrains decompiler
// Type: ChickenRemake.IngameUIController
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ChickenRemake
{
  public class IngameUIController : Component
  {
    private TextComponent coinText;
    private TextComponent distanceText;
    private Color targetCoinColor;
    private Vector2 CoinTargetScale;
    private Vector2 DistanceTargetScale;

    protected override void Start()
    {
      this.coinText = this.Owner.GetComponent<TextComponent>((Predicate<TextComponent>) (x => x.Tag == "Coin"));
      this.distanceText = this.Owner.GetComponent<TextComponent>((Predicate<TextComponent>) (x => x.Tag == "Distance"));
      this.targetCoinColor = this.coinText.Color;
      this.CoinTargetScale = this.coinText.ScaleModifier;
      this.DistanceTargetScale = this.distanceText.ScaleModifier;
    }

    protected override void Update()
    {
      this.coinText.ScaleModifier = Vector2.Lerp(this.coinText.ScaleModifier, this.CoinTargetScale, 10f * Time.UnscaledDeltaTime);
      this.distanceText.ScaleModifier = Vector2.Lerp(this.distanceText.ScaleModifier, this.DistanceTargetScale, 10f * Time.UnscaledDeltaTime);
      this.coinText.Color = Color.Lerp(this.coinText.Color, this.targetCoinColor, 10f * Time.UnscaledDeltaTime);
      this.UpdateCoins();
      this.UpdateDistace();
    }

    private void UpdateDistace()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
      interpolatedStringHandler.AppendFormatted<double>(Math.Round((double) Stats.IngameDistance, 0));
      interpolatedStringHandler.AppendLiteral("m");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      if (!(this.distanceText.Text != stringAndClear))
        return;
      this.distanceText.Text = stringAndClear;
      this.distanceText.ScaleModifier = Vector2.One * 2.1f;
    }

    private void UpdateCoins()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
      interpolatedStringHandler.AppendFormatted<int>(Stats.IngameCoins);
      interpolatedStringHandler.AppendLiteral("$");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      if (!(this.coinText.Text != stringAndClear))
        return;
      this.coinText.Color = Color.White;
      this.coinText.ScaleModifier = Vector2.One * 4f;
      this.coinText.Text = stringAndClear;
    }

    public override void Reset()
    {
    }
  }
}
