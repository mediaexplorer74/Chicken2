// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateMushroom
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

#nullable disable
namespace ChickenRemake
{
  public class CreateMushroom : CreateObstacle
  {
    public override void GetHitAction(Player player, Side side, Vector2 normal)
    {
      player.Velocity = new Vector2(player.Velocity.X, -330f);
      player.Transform.Scale = new Vector2(0.2f, 2f);
      Audio.Play("boing", pitchRange: new Vector2(-0.5f, 0.5f));
      Animation animation;
      if (GameObject.Find((Predicate<GameObject>) (x => x.Tag == "animContainer")).GetComponent<AnimationContainer>().GetAnimation("jump", out animation))
        Blueprint.Spawn<CreateBasicParticle>(this.GameObject.Transform.Position, scale: Vector2.One * 1f).StartAnimation(animation);
      this.GameObject.Transform.Scale = new Vector2(1f, 0.2f);
      Coroutine.Start(this.LerpBack(0.5f));
      if (!(player.CurrentBehaviour is PlayerDefaultBehaviour currentBehaviour))
        return;
      ++currentBehaviour.CurrentJumpAmount;
    }

    public override Texture2D GetTexture() => Content.GetTexture("mushroom");

    private IEnumerator LerpBack(float duration)
    {
      CreateMushroom createMushroom = this;
      float elapsedTime = 0.0f;
      while (true)
      {
        createMushroom.GameObject.Transform.Scale = new Vector2(createMushroom.GameObject.Transform.Scale.X, MathHelper.Lerp(createMushroom.GameObject.Transform.Scale.Y, 1f, elapsedTime / duration));
        elapsedTime += Time.UnscaledDeltaTime;
        if ((double) elapsedTime / (double) duration < 1.0)
          yield return (object) new WaitForSeconds(Time.DeltaTime);
        else
          break;
      }
    }
  }
}
