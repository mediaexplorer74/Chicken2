// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateDefaultCoin
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;

#nullable disable
namespace ChickenRemake
{
  public class CreateDefaultCoin : CreateCoin
  {
    private static Animation animation = new Animation(Content.GetTexture("coin"), 9, 1, 16, 16, 12, true);

    protected override float MagnetDistance => 20f;

    protected override int Amount => 1;

    protected override string AudioName => "coin";

    protected override void ConfigureAnimator(Animator animator)
    {
      animator.AddAnimation("rotate", CreateDefaultCoin.animation);
      animator.Play("rotate");
    }
  }
}
