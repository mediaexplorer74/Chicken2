// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateOptionsMenu
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public class CreateOptionsMenu : Blueprint
  {
    protected override void Construct()
    {
      CreateMenuButton createMenuButton1 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 600f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton1.SetLeftClickAction(new Action(StateManager.SetState<MainMenuState>));
      createMenuButton1.SetText("menu");
      CreateMenuButton createMenuButton2 = Blueprint.Spawn<CreateMenuButton>(new Vector2(Graphics.CurrentResolution.X / 2f, 350f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton2.SetText("Delete savedata");
      createMenuButton2.SetTextScale(Vector2.One * 0.5f);
      createMenuButton2.SetLeftClickAction((Action) (() => Database.ResetSaveFile()));
      Vector2 position = new Vector2(Graphics.CurrentResolution.X / 2f, 500f);
      GameObject gameObject = this.GameObject;
      Vector2 scale = new Vector2();
      GameObject parent = gameObject;
      CreateSlider createSlider = Blueprint.Spawn<CreateSlider>(position, scale: scale, parent: parent);
      createSlider.BindText(Input.JoyMouseSpeed);
      createSlider.SetTitle("Joy mouse speed");
      createSlider.SetIncreaseAction((Action) (() =>
      {
        Input.JoyMouseSpeed.AddModifier(0.5f);
        Database.Save();
      }));
      createSlider.SetDecreaseAction((Action) (() =>
      {
        Input.JoyMouseSpeed.AddModifier(-0.5f);
        Database.Save();
      }));
    }
  }
}
