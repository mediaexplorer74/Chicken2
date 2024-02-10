// Decompiled with JetBrains decompiler
// Type: JuicyChicken.KeyAction
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace JuicyChicken
{
  public class KeyAction : InputAction
  {
    private float holdTime;

    public Keys InputKey { get; private set; }

    public event Action OnDownEvent;

    public event Action OnUpEvent;

    public event Action OnHoldEvent;

    public KeyAction(Keys inputKey, float holdTime = 0.5f)
    {
      this.InputKey = inputKey;
      this.holdTime = holdTime;
    }

    public override void CheckInput()
    {
      if (JuicyChicken.Input.GetKeyState(this.InputKey).Down)
      {
        Action onDownEvent = this.OnDownEvent;
        if (onDownEvent == null)
          return;
        onDownEvent();
      }
      else if (JuicyChicken.Input.GetKeyState(this.InputKey).Up)
      {
        Action onUpEvent = this.OnUpEvent;
        if (onUpEvent == null)
          return;
        onUpEvent();
      }
      else
      {
        if (!JuicyChicken.Input.GetKeyState(this.InputKey).Hold(this.holdTime))
          return;
        Action onHoldEvent = this.OnHoldEvent;
        if (onHoldEvent == null)
          return;
        onHoldEvent();
      }
    }

    public override void Clear()
    {
      this.OnDownEvent = (Action) null;
      this.OnUpEvent = (Action) null;
      this.OnHoldEvent = (Action) null;
    }
  }
}
