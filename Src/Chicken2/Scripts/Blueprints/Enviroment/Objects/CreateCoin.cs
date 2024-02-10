// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateCoin
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace ChickenRemake
{
  public abstract class CreateCoin : CreateCollectable
  {
    protected abstract int Amount { get; }

    protected abstract string AudioName { get; }

    protected override Texture2D Texture => Content.GetTexture("coin");

    protected override float Scale => 0.5f;

    public override bool UseMagnet => true;

    protected override void GetCollectAction(Player player)
    {
      Stats.AddCoin(this.Amount);
      Audio.Play(this.AudioName, 0.3f, new Vector2(-0.2f, 0.2f));
      GameObject.Despawn(this.GameObject);
    }
  }
}
