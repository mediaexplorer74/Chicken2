// Decompiled with JetBrains decompiler
// Type: ChickenRemake.PowerUp
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using System;

#nullable disable
namespace ChickenRemake
{
  public class PowerUp : Component
  {
    private float currentTime;

    public float Duration { get; set; }

    public event Action OnEnd;

    protected override void Update()
    {
      if ((double) this.currentTime > 0.0)
      {
        this.currentTime -= Time.DeltaTime;
      }
      else
      {
        Action onEnd = this.OnEnd;
        if (onEnd != null)
          onEnd();
        GameObject.Despawn(this.Owner);
      }
    }

    public void ResetTime() => this.currentTime = this.Duration;

    public override void Reset() => this.OnEnd = (Action) null;
  }
}
