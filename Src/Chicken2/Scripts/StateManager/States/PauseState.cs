// Decompiled with JetBrains decompiler
// Type: ChickenRemake.PauseState
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace ChickenRemake
{
  public class PauseState : IState
  {
    private GameObject pausePanel;
    private KeyAction keyUnpause = JuicyChicken.Input.AddKeyAction(Keys.Escape);
    private PadAction padUnpause = JuicyChicken.Input.AddPadAction(Buttons.Start);

    public void Start(IState previousState)
    {
      this.keyUnpause.OnDownEvent += new Action(StateManager.SetState<IngameState>);
      this.padUnpause.OnDownEvent += new Action(StateManager.SetState<IngameState>);
      this.pausePanel = Blueprint.Spawn<CreatePausePanel>().GameObject;
      StateManager.Player.GetComponent<InputHandler>().Enabled = false;
      TimeLerper.Lerp(0.0f);
    }

    public void Exit(IState newState)
    {
      TimeLerper.Lerp(1f);
      StateManager.Player.GetComponent<InputHandler>().Enabled = true;
      this.keyUnpause.OnDownEvent -= new Action(StateManager.SetState<IngameState>);
      this.padUnpause.OnDownEvent -= new Action(StateManager.SetState<IngameState>);
      JuicyChicken.Input.RemoveAction((InputAction) this.keyUnpause);
      JuicyChicken.Input.RemoveAction((InputAction) this.padUnpause);
      GameObject.Despawn(this.pausePanel);
      switch (newState)
      {
        case IngameState _:
          break;
        case GameoverState _:
          break;
        default:
          GameObject.Despawn(Level.Instance.Owner);
          StateManager.GameOver();
          StateManager.Music.Stop();
          break;
      }
    }
  }
}
