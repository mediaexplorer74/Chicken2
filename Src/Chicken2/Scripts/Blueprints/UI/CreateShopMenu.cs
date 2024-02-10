// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateShopMenu
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace ChickenRemake
{
  public class CreateShopMenu : Blueprint
  {
    protected override void Construct()
    {
      ShopCardHandler CardHandler = GameObject.Spawn(parent: this.GameObject).AddComponent<ShopCardHandler>();
      TextComponent textComponent = this.GameObject.AddComponent<TextComponent>();
      textComponent.Color = PaletteLoader.GetColor(11);
      textComponent.ScaleModifier = Vector2.One * 3f;
      textComponent.Origin = OriginPoint.TopLeft;
      textComponent.Tag = "Coin";
      textComponent.Offset = new Vector2(10f, 10f);
      textComponent.OutlineColor = PaletteLoader.GetColor(1);
      textComponent.Text = Stats.CurrentCoins.ToString() + "$";
      CreateMenuButton createMenuButton = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 600f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton.SetLeftClickAction(new Action(StateManager.SetState<MainMenuState>));
      createMenuButton.SetText("menu");
      Vector2 position1 = new Vector2(185f, JuicyChicken.Graphics.CurrentResolution.Y / 2f);
      GameObject gameObject1 = this.GameObject;
      Vector2 scale1 = new Vector2();
      GameObject parent1 = gameObject1;
      GameObject gameObject2 = Blueprint.Spawn<CreateArrowButton>(position1, scale: scale1, parent: parent1).GameObject;
      gameObject2.GetComponent<Sprite>().FlipMode = SpriteEffects.FlipHorizontally;
      gameObject2.GetComponent<Button>().OnLeftClick += (Action) (() => CardHandler.SetPage(false));
      Vector2 position2 = new Vector2(JuicyChicken.Graphics.CurrentResolution.X - 200f, JuicyChicken.Graphics.CurrentResolution.Y / 2f);
      GameObject gameObject3 = this.GameObject;
      Vector2 scale2 = new Vector2();
      GameObject parent2 = gameObject3;
      Blueprint.Spawn<CreateArrowButton>(position2, scale: scale2, parent: parent2).GameObject.GetComponent<Button>().OnLeftClick += (Action) (() => CardHandler.SetPage(true));
    }
  }
}
