// Decompiled with JetBrains decompiler
// Type: JuicyChicken.DirectionAction
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public class DirectionAction : InputAction
  {
    private Keys keyUp;
    private Keys keyDown;
    private Keys keyLeft;
    private Keys keyRight;

    public List<Keys> DirectionKeys { get; private set; }

    public event Action<Vector2> OnDirectionInput;

    public DirectionAction(Keys keyUp = Keys.W, Keys keyDown = Keys.S, Keys keyLeft = Keys.A, Keys keyRight = Keys.D)
    {
      this.keyUp = keyUp;
      this.keyDown = keyDown;
      this.keyLeft = keyLeft;
      this.keyRight = keyRight;
      this.DirectionKeys = new List<Keys>()
      {
        keyUp,
        keyDown,
        keyLeft,
        keyRight
      };
    }

    public override void CheckInput()
    {
      Vector2 zero = Vector2.Zero;
      Dictionary<Direction, bool> dictionary = new Dictionary<Direction, bool>();
      dictionary.Add(Direction.Up, JuicyChicken.Input.GetKeyState(this.keyUp).HeldDown);
      dictionary.Add(Direction.Down, JuicyChicken.Input.GetKeyState(this.keyDown).HeldDown);
      dictionary.Add(Direction.Left, JuicyChicken.Input.GetKeyState(this.keyLeft).HeldDown);
      dictionary.Add(Direction.Right, JuicyChicken.Input.GetKeyState(this.keyRight).HeldDown);
      foreach (int key in dictionary.Keys)
      {
        switch (key)
        {
          case 0:
            if (dictionary[Direction.Up])
            {
              zero += new Vector2(0.0f, -1f);
              continue;
            }
            continue;
          case 1:
            if (dictionary[Direction.Down])
            {
              zero += new Vector2(0.0f, 1f);
              continue;
            }
            continue;
          case 2:
            if (dictionary[Direction.Left])
            {
              zero += new Vector2(-1f, 0.0f);
              continue;
            }
            continue;
          case 3:
            if (dictionary[Direction.Right])
            {
              zero += new Vector2(1f, 0.0f);
              continue;
            }
            continue;
          default:
            continue;
        }
      }
      if ((double) zero.Length() <= 0.0)
        return;
      Action<Vector2> onDirectionInput = this.OnDirectionInput;
      if (onDirectionInput == null)
        return;
      onDirectionInput(zero);
    }

    public override void Clear() => this.OnDirectionInput = (Action<Vector2>) null;
  }
}
