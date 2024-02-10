// Decompiled with JetBrains decompiler
// Type: ChickenRemake.IngameState
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace ChickenRemake
{
  public class IngameState : IState
  {
    private KeyAction keyPause = JuicyChicken.Input.AddKeyAction(Keys.Escape);
    private PadAction padPause = JuicyChicken.Input.AddPadAction(Buttons.Start);
    private GameObject powerUpTextManager;
    private GameObject UI;
    private GameObject animContainer;

    public void Start(IState previousState)
    {
      this.keyPause.OnDownEvent += new Action(StateManager.SetState<PauseState>);
      this.padPause.OnDownEvent += new Action(StateManager.SetState<PauseState>);
      this.UI = Blueprint.Spawn<CreateIngamePanel>().GameObject;
      this.powerUpTextManager = Blueprint.Spawn<CreatePowerUpTextManager>().GameObject;
      this.animContainer = Blueprint.Spawn<CreateAnimationContainer>().GameObject;
      if (previousState is PauseState)
        return;
      StateManager.StartGame();
      Blueprint.Spawn<CreateGrassLands>();
    }

    public void Exit(IState newState)
    {
      GameObject.Despawn(this.UI);
      GameObject.Despawn(this.powerUpTextManager);
      GameObject.Despawn(this.animContainer);
      this.keyPause.OnDownEvent -= new Action(StateManager.SetState<PauseState>);
      this.padPause.OnDownEvent -= new Action(StateManager.SetState<PauseState>);
      JuicyChicken.Input.RemoveAction((InputAction) this.keyPause);
      JuicyChicken.Input.RemoveAction((InputAction) this.padPause);
    }
  }
}
