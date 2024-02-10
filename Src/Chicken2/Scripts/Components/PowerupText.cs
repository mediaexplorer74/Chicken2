// Decompiled with JetBrains decompiler
// Type: ChickenRemake.PowerupText
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  internal class PowerupText : Component
  {
    private TextComponent text;
    private bool shouldAnimate;
    private float elapsedTime;
    private float fadeOutElapse;
    private float duration;
    private float sineOffset;
    private float scale;

    public event Action OnFinish;

    protected override void Start()
    {
      this.text = this.Owner.GetComponent<TextComponent>();
      this.text.Origin = OriginPoint.Center;
      this.Owner.Transform.Scale = Vector2.Zero;
      this.sineOffset = Randomizer.Next(0.0f, 10f);
    }

    public override void Reset() => this.text = (TextComponent) null;

    public void ResetTimer() => this.elapsedTime = 0.0f;

    public void StartAnimation(string input, Color color, float duration = 3f, float scale = 3f)
    {
      this.text.Text = input;
      this.text.Color = color;
      this.duration = duration;
      this.scale = scale;
      this.shouldAnimate = true;
    }

    protected override void Update()
    {
      if (!this.shouldAnimate)
        return;
      if ((double) this.elapsedTime < (double) this.duration)
      {
        this.Owner.Transform.Scale = Vector2.Lerp(this.Owner.Transform.Scale, Vector2.One * this.scale, 4f * this.elapsedTime / this.duration);
        this.Owner.Transform.Rotation = 10f * (float) Math.Sin(((double) Time.TotalTime + (double) this.sineOffset) * 2.0);
        this.elapsedTime += Time.DeltaTime;
      }
      else
      {
        this.Owner.Transform.Scale = Vector2.Lerp(this.Owner.Transform.Scale, Vector2.Zero, this.fadeOutElapse / 0.8f);
        this.Owner.Transform.Rotate(360f * Time.DeltaTime);
        this.fadeOutElapse += Time.DeltaTime;
        if ((double) this.fadeOutElapse < 0.800000011920929)
          return;
        this.shouldAnimate = false;
        Action onFinish = this.OnFinish;
        if (onFinish == null)
          return;
        onFinish();
      }
    }
  }
}
