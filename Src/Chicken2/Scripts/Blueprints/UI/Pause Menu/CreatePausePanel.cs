// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreatePausePanel
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public class CreatePausePanel : CreateScreenUI
  {
    protected override void Construct()
    {
      base.Construct();
      CreateMenuButton createMenuButton1 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 350f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton1.SetText("Resume");
      createMenuButton1.SetLeftClickAction((Action) (() => StateManager.SetState<IngameState>()));
      CreateMenuButton createMenuButton2 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 450f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton2.SetText("Restart");
      createMenuButton2.SetLeftClickAction((Action) (() =>
      {
        StateManager.SetState<MainMenuState>();
        StateManager.SetState<IngameState>();
      }));
      CreateMenuButton createMenuButton3 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 550f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton3.SetText("Menu");
      createMenuButton3.SetLeftClickAction((Action) (() => StateManager.SetState<MainMenuState>()));
      CreateMenuButton createMenuButton4 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 650f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton4.SetText("Quit");
      createMenuButton4.SetLeftClickAction((Action) (() => StateManager.Quit()));
      Blueprint.Spawn<CreateBlackBackground>(parent: this.GameObject);
    }
  }
}
