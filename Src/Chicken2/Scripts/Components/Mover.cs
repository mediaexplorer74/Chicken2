// Decompiled with JetBrains decompiler
// Type: ChickenRemake.Mover
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;

#nullable disable
namespace ChickenRemake
{
  public class Mover : Component
  {
    public Vector2 Direction { get; set; } = -Vector2.UnitX;

    public float Speed { get; set; } = 100f;

    protected override void Update()
    {
      this.Transform.Translate(this.Direction * this.Speed * Time.DeltaTime);
    }

    public override void Reset() => this.Speed = 100f;
  }
}
