// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateMainMenuPanel
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ChickenRemake
{
  public class CreateMainMenuPanel : Blueprint
  {
    protected override void Construct()
    {
      GameObject gameObject = GameObject.Spawn();
      gameObject.Transform.Position = Vector2.One * 20f;
      gameObject.Transform.Scale = Vector2.One * 2f;
      gameObject.SetParent(this.GameObject);
      TextComponent textComponent = gameObject.AddComponent<TextComponent>();
      textComponent.OutlineColor = PaletteLoader.GetColor(22);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
      interpolatedStringHandler.AppendLiteral("highscore: ");
      interpolatedStringHandler.AppendFormatted<int>((int) Stats.HighScore);
      interpolatedStringHandler.AppendLiteral("m");
      textComponent.Text = interpolatedStringHandler.ToStringAndClear();
      textComponent.Origin = OriginPoint.TopLeft;
      CreateMenuButton createMenuButton1 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 350f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton1.SetText("Play");
      createMenuButton1.SetLeftClickAction((Action) (() => StateManager.SetState<IngameState>()));
      CreateMenuButton createMenuButton2 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 450f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton2.SetText("Skins");
      createMenuButton2.SetLeftClickAction((Action) (() => StateManager.SetState<ShopState>()));
      CreateMenuButton createMenuButton3 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 550f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton3.SetText("Options");
      createMenuButton3.SetLeftClickAction((Action) (() => StateManager.SetState<OptionsState>()));
      CreateMenuButton createMenuButton4 = Blueprint.Spawn<CreateMenuButton>(new Vector2(150f, 650f), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton4.SetText("Quit");
      createMenuButton4.SetLeftClickAction((Action) (() => StateManager.Quit()));
    }
  }
}
