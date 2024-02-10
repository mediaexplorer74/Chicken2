// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateCollectable
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
  public abstract class CreateCollectable : Blueprint
  {
    protected abstract float Scale { get; }

    protected abstract Texture2D Texture { get; }

    public virtual bool UseMagnet { get; }

    protected virtual float MagnetSpeed { get; } = 10f;

    protected virtual float MagnetDistance { get; } = 30f;

    protected virtual float SuperMagnetDistance { get; } = 100f;

    protected override void Construct()
    {
      this.GameObject.Tag = "Collectable";
      this.GameObject.Transform.Scale = Vector2.One * this.Scale;
      Sprite sprite = this.GameObject.AddComponent<Sprite>();
      sprite.Texture = this.Texture;
      sprite.Origin = OriginPoint.Center;
      sprite.Layer = 100;
      this.ConfigureAnimator(this.GameObject.AddComponent<Animator>());
      Collider collider = this.GameObject.AddComponent<Collider>();
      collider.Size = sprite.Texture.GetSize() * this.Scale;
      collider.IsTrigger = true;
      collider.OnCollisionEnter += (Action<CollisionData>) (data =>
      {
        if (!data.Other.Owner.CompareTag("Player"))
          return;
        this.GetCollectAction(data.Other.Owner.GetComponent<Player>());
      });
      if (!this.UseMagnet)
        return;
      Magnet magnet = this.GameObject.AddComponent<Magnet>();
      magnet.Target = StateManager.Player;
      magnet.Distance = Stats.ActivePowerUps.ContainsKey(typeof (CreateSuperMagnet)) ? this.SuperMagnetDistance : this.MagnetDistance;
      magnet.Speed = this.MagnetSpeed;
    }

    protected abstract void GetCollectAction(Player player);

    protected virtual void ConfigureAnimator(Animator animator)
    {
    }
  }
}
