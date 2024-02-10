// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateDoubleJump
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace ChickenRemake
{
  public class CreateDoubleJump : CreatePowerUp
  {
    protected override float Duration => 15f;

    protected override Texture2D Texture => Content.GetTexture("doublejump");

    protected override string PowerUpName => "Double Jump!";

    protected override Color PowerUpColor => PaletteLoader.GetColor(26);

    protected override void GetStartAction()
    {
      (StateManager.Player.GetComponent<Player>().CurrentBehaviour as PlayerDefaultBehaviour).MaxJumpAmount = 2;
    }

    protected override void GetEndAction()
    {
      Player component = StateManager.Player.GetComponent<Player>();
      if (component == null || !(component.CurrentBehaviour is PlayerDefaultBehaviour currentBehaviour))
        return;
      currentBehaviour.CurrentJumpAmount = 1;
      currentBehaviour.MaxJumpAmount = 1;
    }
  }
}
