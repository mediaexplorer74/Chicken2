// Decompiled with JetBrains decompiler
// Type: JuicyChicken.ButtonState
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

#nullable disable
namespace JuicyChicken
{
  public class ButtonState : InputState
  {
    public bool Down { get; set; }

    public bool Up { get; set; }

    public float HeldTime { get; set; }

    public bool HeldDown { get; set; }

    public ButtonState(float heldTime = 0.0f, bool down = false, bool up = false, bool currentDown = false)
    {
      this.Down = down;
      this.Up = up;
      this.HeldTime = 0.0f;
      this.HeldDown = currentDown;
      this.HeldTime = heldTime;
    }

    public bool Hold(float time)
    {
      if ((double) this.HeldTime <= (double) time)
        return false;
      this.HeldTime = 0.0f;
      return true;
    }
  }
}
