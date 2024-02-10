// Decompiled with JetBrains decompiler
// Type: JuicyChicken.InputHandler
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public class InputHandler : Component
  {
    private List<InputAction> inputActions;

    public KeyAction AddKeyAction(Keys k, float holdTime = 0.5f)
    {
      KeyAction keyAction = new KeyAction(k, holdTime);
      this.inputActions.Add((InputAction) keyAction);
      return keyAction;
    }

    public PadAction AddPadAction(Buttons b, float holdTime = 0.5f)
    {
      PadAction padAction = new PadAction(b, holdTime);
      this.inputActions.Add((InputAction) padAction);
      return padAction;
    }

    public DirectionAction AddDirectionAction(Keys up = Keys.W, Keys down = Keys.S, Keys left = Keys.A, Keys right = Keys.D)
    {
      DirectionAction directionAction = new DirectionAction(up, down, left, right);
      this.inputActions.Add((InputAction) directionAction);
      return directionAction;
    }

    public MouseAction AddMouseAction(float holdTime = 1f)
    {
      MouseAction mouseAction = new MouseAction(holdTime);
      this.inputActions.Add((InputAction) mouseAction);
      return mouseAction;
    }

    protected override void Start() => this.inputActions = new List<InputAction>();

    protected override void Update()
    {
      foreach (InputAction inputAction in this.inputActions)
        inputAction.CheckInput();
    }

    public override void Reset()
    {
      foreach (InputAction inputAction in this.inputActions)
        inputAction.Clear();
      this.inputActions.Clear();
    }
  }
}
