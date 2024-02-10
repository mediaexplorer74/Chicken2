// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Animator
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public class Animator : Component
  {
    private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
    private Animation currentAnimation;
    private bool isPlaying;
    private float timeSinceLastFrame;

    public bool IsPlaying => this.isPlaying;

    protected override void Update()
    {
      if (!this.IsPlaying || this.currentAnimation.Frames.Length == 0)
        return;
      this.timeSinceLastFrame += Time.DeltaTime;
      int index = (int) ((double) this.timeSinceLastFrame * (double) this.currentAnimation.FramesPerSecond);
      if (index > this.currentAnimation.Frames.Length - 1)
      {
        if (this.currentAnimation.Loop)
        {
          this.timeSinceLastFrame = 0.0f;
          index = 0;
        }
        else
        {
          this.timeSinceLastFrame = 0.0f;
          index = this.currentAnimation.Frames.Length - 1;
          this.isPlaying = false;
        }
      }
      this.Owner.GetComponent<Sprite>().Texture = this.currentAnimation.Frames[index];
    }

    public void AddAnimation(string name, Animation animation)
    {
      if (this.animations.ContainsKey(name))
        return;
      this.animations.Add(name, animation);
    }

    public void Play(string name)
    {
      if (!this.animations.TryGetValue(name, out this.currentAnimation))
        return;
      this.Owner.GetComponent<Sprite>().Texture = this.currentAnimation.Frames[0];
      this.isPlaying = true;
    }

    public void Play(Animation animation)
    {
      this.currentAnimation = animation;
      this.Owner.GetComponent<Sprite>().Texture = this.currentAnimation.Frames[0];
      this.isPlaying = true;
    }

    public void Stop()
    {
      this.Owner.GetComponent<Sprite>().Texture = this.currentAnimation.Frames[0];
      this.isPlaying = false;
    }

    public override void Reset()
    {
      this.animations.Clear();
      this.currentAnimation = new Animation();
      this.isPlaying = false;
      this.timeSinceLastFrame = 0.0f;
    }
  }
}
