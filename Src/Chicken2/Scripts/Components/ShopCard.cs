// Decompiled with JetBrains decompiler
// Type: ChickenRemake.ShopCard
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public class ShopCard : Component
  {
    private Action buyAction;
    private int cost;

    public Vector2 DesiredScale { get; set; } = Vector2.One;

    public void Purchase()
    {
      if (Stats.CurrentCoins < this.cost)
      {
        Audio.Play("error", 0.2f);
      }
      else
      {
        if (this.cost == 0)
          Audio.Play("ButtonClick");
        else
          Audio.Play("purchase", 0.4f);
        Action buyAction = this.buyAction;
        if (buyAction != null)
          buyAction();
        Database.Save();
      }
    }

    protected override void Update()
    {
      this.Transform.Scale = Vector2.Lerp(this.Transform.Scale, this.DesiredScale, 30f * Time.DeltaTime);
    }

    public void SetValues(int cost, Action buyAction)
    {
      this.buyAction = buyAction;
      this.cost = cost;
    }

    public override void Reset() => this.buyAction = (Action) null;
  }
}
