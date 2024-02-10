// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateRock
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
  public class CreateRock : CreateObstacle
  {
    public override void GetHitAction(Player player, Side side, Vector2 normal)
    {
      Vector2 vector2;
      if (side == Side.Right)
      {
        vector2 = new Vector2(-300f, player.Velocity.Y);

        float clamp = Time.TimeScale - 0.8f;

        if (Time.TimeScale - 0.8f > 1f)
            clamp = 1f;

        if (Time.TimeScale - 0.8f < 0.0f)
            clamp = 0.0f;

        TimeLerper.Sting(clamp);//Math.Clamp(Time.TimeScale - 0.8f, 0.0f, 1f));
        
        Input.Rumble(Vector2.One);
      }
      else
        vector2 = new Vector2(player.Velocity.X, -150f);
      Audio.Play("hit", pitchRange: new Vector2(-0.5f, 0.5f));
      player.Transform.Scale = new Vector2(0.1f, 1f);
      Animation animation;
      if (GameObject.Find((Predicate<GameObject>) (x => x.Tag == "animContainer")).GetComponent<AnimationContainer>().GetAnimation("rock", out animation))
        Blueprint.Spawn<CreateBasicParticle>(this.GameObject.Transform.Position).StartAnimation(animation);
      player.Velocity = vector2;
      GameObject.Despawn(this.GameObject);
    }

    public override Texture2D GetTexture()
    {
      return Content.GetTexture(Randomizer.Choose<string>("rock", "rock2"));
    }
  }
}
