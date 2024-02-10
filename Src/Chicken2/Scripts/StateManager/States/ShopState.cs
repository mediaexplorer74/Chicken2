// Decompiled with JetBrains decompiler
// Type: ChickenRemake.ShopState
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace ChickenRemake
{
  public class ShopState : IState
  {
    private KeyAction returnAction = JuicyChicken.Input.AddKeyAction(Keys.Escape);
    private GameObject shopMenu;

    public void Start(IState previousState)
    {
      Graphics.ClearColor = PaletteLoader.GetColor(21);
      this.returnAction.OnDownEvent += new Action(StateManager.SetState<MainMenuState>);
      this.shopMenu = Blueprint.Spawn<CreateShopMenu>().GameObject;
    }

    public void Exit(IState newState)
    {
      Graphics.ClearColor = Color.LightBlue;
      this.returnAction.OnDownEvent -= new Action(StateManager.SetState<MainMenuState>);
      JuicyChicken.Input.RemoveAction((InputAction) this.returnAction);
      GameObject.Despawn(this.shopMenu);
    }
  }
}
