// Decompiled with JetBrains decompiler
// Type: JuicyChicken.MouseKeyState
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;

#nullable disable
namespace JuicyChicken
{
  public class MouseKeyState : InputState
  {
    public Vector2 MousePosition { get; set; }

    public bool LeftClicked { get; set; }

    public bool RightClicked { get; set; }

    public bool LeftUp { get; set; }

    public bool RightUp { get; set; }

    public bool LeftHeld { get; set; }

    public bool RightHeld { get; set; }

    public float LeftHeldTime { get; set; }

    public float RightHeldTime { get; set; }

    public float MouseWheel { get; set; }

    public MouseKeyState()
    {
      this.MousePosition = Vector2.Zero;
      this.LeftClicked = false;
      this.LeftUp = false;
      this.LeftHeld = false;
      this.LeftHeldTime = 0.0f;
      this.RightClicked = false;
      this.RightUp = false;
      this.RightHeld = false;
      this.RightHeldTime = 0.0f;
    }

    public bool LeftHoldDuration(float time)
    {
      if ((double) this.LeftHeldTime < (double) time)
        return false;
      this.LeftHeldTime = 0.0f;
      return true;
    }

    public bool RightHoldDuration(float time)
    {
      if ((double) this.RightHeldTime < (double) time)
        return false;
      this.RightHeldTime = 0.0f;
      return true;
    }
  }
}
