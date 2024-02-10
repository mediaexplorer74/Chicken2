// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateBasicParticle
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

#nullable disable
namespace ChickenRemake
{
  public class CreateBasicParticle : Blueprint
  {
        private int Some_state;

        protected override void Construct()
    {
      this.GameObject.Tag = "Particle";
      this.GameObject.AddComponent<Sprite>();
      this.GameObject.AddComponent<Animator>();
      this.GameObject.AddComponent<Mover>();
    }

    public void StartAnimation(
      Texture2D texture,
      int framesX,
      int framesY,
      int cellWidth,
      int cellHeight,
      int FPS,
      bool loop = false)
    {
      Sprite component1 = this.GameObject.GetComponent<Sprite>();

      Animator component2 = this.GameObject.GetComponent<Animator>();

      component2.AddAnimation("ani", new Animation(texture, framesX, framesY, 
          cellWidth, cellHeight, FPS, loop));

      component2.Play("ani");
      component1.Origin = OriginPoint.Bottom;
      Coroutine.Start(this.DeleteWhenDone());
    }

    public void StartAnimation(Animation animation)
    {
      Sprite component1 = this.GameObject.GetComponent<Sprite>();
      Animator component2 = this.GameObject.GetComponent<Animator>();
      component2.AddAnimation("ani", animation);
      component2.Play("ani");
      component1.Origin = OriginPoint.Bottom;
      Coroutine.Start(this.DeleteWhenDone());
    }

    private IEnumerator DeleteWhenDone()
    {
      //RnD
      // ISSUE: reference to a compiler-generated field
      int num = this.Some_state;//\u003C\u003E1__state;
      CreateBasicParticle createBasicParticle = this;

      //RnD
      if (num != 0)
      {
        if (num != 1)
            return default;//false;

        // ISSUE: reference to a compiler-generated field
        this.Some_state = -1;
        GameObject.Despawn(createBasicParticle.GameObject);
        return default;//false;
      }

      // ISSUE: reference to a compiler-generated field
      this.Some_state = -1;
      Animator animator = createBasicParticle.GameObject.GetComponent<Animator>();
      
      // ISSUE: reference to a compiler-generated field
      //this.\u003C\u003E2__current 

      object a = (object) new WaitUntil((Func<bool>) (() => !animator.IsPlaying));
      // ISSUE: reference to a compiler-generated field
      this.Some_state = 1;
      return default;//true;
    }
  }
}
