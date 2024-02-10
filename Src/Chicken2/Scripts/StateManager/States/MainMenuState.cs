// Decompiled with JetBrains decompiler
// Type: ChickenRemake.MainMenuState
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public class MainMenuState : IState
  {
    private GameObject menuObject;

    public void Start(IState previousState)
    {
      Graphics.ClearColor = Color.LightBlue;
      foreach (GameObject gameObject in GameObject.FindAll((Predicate<GameObject>) (x => x.Tag == "Collectable")))
        GameObject.Despawn(gameObject);
      this.menuObject = Blueprint.Spawn<CreateMainMenuPanel>().GameObject;
      Blueprint.Spawn<CreateGrassLands>();
    }

    public void Exit(IState newState)
    {
      GameObject.Despawn(Level.Instance.Owner);
      StateManager.GameOver();
      GameObject.Despawn(this.menuObject);
    }
  }
}
