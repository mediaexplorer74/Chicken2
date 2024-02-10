// ChickenRemake.CreateObstacle

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace ChickenRemake
{
  public abstract class CreateObstacle : Blueprint
  {
    protected override void Construct()
    {
      this.GameObject.Static = false;
      this.GameObject.Layer = (Enum) ObjectLayer.Obstacle;
      this.GameObject.Tag = "Obstacle";
      Sprite sprite = this.GameObject.AddComponent<Sprite>();
      sprite.Texture = this.GetTexture();
      sprite.Origin = OriginPoint.Bottom;
      sprite.Layer = 10;
      Collider collider = this.GameObject.AddComponent<Collider>();
      collider.Size = sprite.Texture.GetSize();
      collider.Offset = new Vector2(0.0f, (float) (-sprite.Texture.Height / 2));
      collider.IsTrigger = true;
      collider.OnCollisionEnter += (Action<CollisionData>) (data =>
      {
        if (!data.Other.Owner.CompareTag("Player"))
          return;

        this.GetHitAction(data.Other.Owner.GetComponent<Player>(), data.Side, data.Normal);
      });
    }

    public abstract Texture2D GetTexture();

    public abstract void GetHitAction(Player player, Side side, Vector2 normal);
  }
}
