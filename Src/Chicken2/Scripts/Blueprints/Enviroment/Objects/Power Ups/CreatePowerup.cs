// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreatePowerUp
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public abstract class CreatePowerUp : CreateCollectable
  {
    protected abstract float Duration { get; }

    protected override float Scale => 0.75f;

    protected abstract string PowerUpName { get; }

    protected abstract Color PowerUpColor { get; }

    protected override void Construct()
    {
      base.Construct();
      PowerUp powerUp = this.GameObject.AddComponent<PowerUp>();
      powerUp.Enabled = false;
      powerUp.Duration = this.Duration;
      powerUp.ResetTime();
    }

    protected override void GetCollectAction(Player player)
    {
      PowerUp component = this.GameObject.GetComponent<PowerUp>();
      component.Enabled = true;
      this.GameObject.GetComponent<Sprite>().Enabled = false;
      this.GameObject.GetComponent<Collider>().Enabled = false;
      this.GameObject.SetParent((GameObject) null);
      Level.Instance.Owner.OnDespawn += (Action) (() => GameObject.Despawn(this.GameObject));
      if (!Stats.ActivePowerUps.ContainsKey(this.GetType()))
      {
        this.GetStartAction();
        Stats.ActivePowerUps.Add(this.GetType(), this.GameObject.GetComponent<PowerUp>());
        component.OnEnd += (Action) (() =>
        {
          Stats.ActivePowerUps.Remove(this.GetType());
          this.GetEndAction();
        });
      }
      else
        Stats.ActivePowerUps[this.GetType()].ResetTime();
      Audio.Play("Pickup");
      GameObject.Find((Predicate<GameObject>) (x => x.Tag == "PowerUpTextMan")).GetComponent<PowerUpTextManager>().SpawnText(this.PowerUpName, this.PowerUpColor, this.Duration);
    }

    protected abstract void GetStartAction();

    protected abstract void GetEndAction();
  }
}
