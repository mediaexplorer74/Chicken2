// Decompiled with JetBrains decompiler
// Type: ChickenRemake.Magnet
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;

#nullable disable
namespace ChickenRemake
{
  public class Magnet : Component
  {
    private bool locked;

    public GameObject Target { get; set; }

    public float Distance { get; set; } = 30f;

    public float Speed { get; set; } = 10f;

    protected override void Update()
    {
      if (this.Target == null)
        GameObject.Despawn(this.Owner);
      else if (!this.locked)
      {
        if ((double) Vector2.Distance(this.Transform.Position, this.Target.Transform.Position) > (double) this.Distance)
          return;
        this.locked = true;
      }
      else
      {
        if (this.Owner.IsChild)
          this.Owner.SetParent((GameObject) null);
        if (this.Owner.HasComponent<Mover>())
          this.Owner.RemoveComponent<Mover>();
        this.Speed += Time.DeltaTime * 12f;
        this.Transform.Position = Vector2.Lerp(this.Transform.Position, this.Target.Transform.Position - Vector2.UnitY * 8f, this.Speed * Time.DeltaTime);
        this.Transform.Rotation = MathHelper.Lerp(this.Transform.Rotation, this.Transform.GetLookRotation(this.Target.Transform.Position), this.Speed * 0.25f * Time.DeltaTime);
      }
    }

    public override void Reset() => this.Target = (GameObject) null;
  }
}
