// ChickenRemake.PlayerVisual

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public class PlayerVisual : Component
  {
    private GameObject body;
    private GameObject head;
    private GameObject wing;
    private GameObject leftFoot;
    private GameObject rightFoot;

    public void Setup() => this.SpawnParts();

    private void SpawnParts()
    {
      this.body = GameObject.Spawn(parent: this.Owner);
      this.body.Tag = "Root";
      Sprite sprite1 = this.body.AddComponent<Sprite>();
      sprite1.Texture = PlayerSkin.CurrentSkin.Body;
      sprite1.Origin = OriginPoint.Bottom;
      sprite1.Layer = 5;
      Vector2 position1 = new Vector2(1f, -3f);
      GameObject body1 = this.body;
      Vector2 scale1 = new Vector2();
      GameObject parent1 = body1;
      this.head = GameObject.Spawn(position1, scale: scale1, parent: parent1);
      this.head.Tag = "head";
      Sprite sprite2 = this.head.AddComponent<Sprite>();
      sprite2.Texture = PlayerSkin.CurrentSkin.Head;
      sprite2.Origin = OriginPoint.Bottom;
      sprite2.Layer = 10;
      Vector2 position2 = new Vector2(-1.25f, -6.4f);
      GameObject body2 = this.body;
      Vector2 scale2 = new Vector2();
      GameObject parent2 = body2;
      this.wing = GameObject.Spawn(position2, scale: scale2, parent: parent2);
      this.wing.Tag = "wing";
      Sprite sprite3 = this.wing.AddComponent<Sprite>();
      sprite3.Texture = PlayerSkin.CurrentSkin.Wing;
      sprite3.Origin = OriginPoint.TopRight;
      sprite3.Layer = 15;
      Vector2 position3 = new Vector2(-2f, -1.5f);
      GameObject body3 = this.body;
      Vector2 scale3 = new Vector2();
      GameObject parent3 = body3;
      this.leftFoot = GameObject.Spawn(position3, scale: scale3, parent: parent3);
      this.leftFoot.Tag = "leftFoot";
      Sprite sprite4 = this.leftFoot.AddComponent<Sprite>();
      sprite4.Texture = PlayerSkin.CurrentSkin.Foot;
      sprite4.Origin = OriginPoint.Top;
      sprite4.Layer = 2;
      Vector2 position4 = new Vector2(3f, -1.5f);
      GameObject body4 = this.body;
      Vector2 scale4 = new Vector2();
      GameObject parent4 = body4;
      this.rightFoot = GameObject.Spawn(position4, scale: scale4, parent: parent4);
      this.rightFoot.Tag = "rightFoot";
      Sprite sprite5 = this.rightFoot.AddComponent<Sprite>();
      sprite5.Texture = PlayerSkin.CurrentSkin.Foot;
      sprite5.Origin = OriginPoint.Top;
      sprite5.Layer = 2;
    }

    protected override void Update()
    {
      this.Transform.Scale = Vector2.Lerp(this.Transform.Scale, Vector2.One, 7f * Time.DeltaTime);
      this.Transform.Rotation = MathHelper.Lerp(this.Transform.Rotation, 0.0f, 10f * Time.DeltaTime);
      this.body.Transform.Position = new Vector2(this.body.Transform.InitialPosition.X, this.body.Transform.InitialPosition.Y + (float) Math.Sin(15.0 * (double) Time.TotalTime) * 1f);
      this.body.Transform.Rotation = this.body.Transform.InitialRotation + (float) Math.Sin(20.0 * (double) Time.TotalTime) * 5f;
      this.head.Transform.Position = new Vector2(this.head.Transform.InitialPosition.X, this.head.Transform.InitialPosition.Y + (float) Math.Sin(20.0 * (double) Time.TotalTime) * 1f);
      this.leftFoot.Transform.Position = new Vector2(this.leftFoot.Transform.InitialPosition.X, this.leftFoot.Transform.InitialPosition.Y + (float) Math.Sin(20.0 * (double) Time.TotalTime) * 0.75f);
      this.rightFoot.Transform.Position = new Vector2(this.rightFoot.Transform.InitialPosition.X, this.rightFoot.Transform.InitialPosition.Y + (float) Math.Sin(-20.0 * (double) Time.TotalTime) * 0.75f);
    }

    public override void Reset()
    {
    }
  }
}
