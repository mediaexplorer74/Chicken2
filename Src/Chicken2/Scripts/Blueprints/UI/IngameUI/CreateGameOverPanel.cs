// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateGameOverPanel
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;
using System.Collections;

#nullable disable
namespace ChickenRemake
{
  public class CreateGameOverPanel : Blueprint
  {
    private int coinCount;
    private int totalCoins;

    protected override void Construct()
    {
      this.totalCoins = Stats.IngameCoins;
      GameObject gameObject1 = GameObject.Spawn(new Vector2(Graphics.CurrentResolution.X / 2f, (float) ((double) Graphics.CurrentResolution.Y / 2.0 - 100.0)), scale: Vector2.One * 10f, parent: this.GameObject);
      gameObject1.Tag = "gameoverText";
      IndividualTextComponent individualTextComponent = gameObject1.AddComponent<IndividualTextComponent>();
      individualTextComponent.Origin = OriginPoint.Center;
      individualTextComponent.Text = "GAME OVER";
      individualTextComponent.OutlineColor = PaletteLoader.GetColor(6);
      for (int index = 0; index < individualTextComponent.Text.Length; ++index)
        individualTextComponent.SetCharacterColor(index, PaletteLoader.GetColor(8));
      GameObject gameObject2 = GameObject.Spawn(new Vector2(Graphics.CurrentResolution.X / 2f, Graphics.CurrentResolution.Y / 2f), scale: Vector2.One * 5f, parent: this.GameObject);
      gameObject2.Tag = "coinTextObj";
      TextComponent textComponent = gameObject2.AddComponent<TextComponent>();
      textComponent.Color = PaletteLoader.GetColor(11);
      textComponent.OutlineColor = PaletteLoader.GetColor(1);
      textComponent.Text = this.coinCount.ToString() + "$";
      if (this.totalCoins > 0)
        Coroutine.Start(this.CoinCount());
      Coroutine.Start(this.Animate());
      CreateMenuButton createMenuButton1 = Blueprint.Spawn<CreateMenuButton>(new Vector2(Graphics.CurrentResolution.X / 2f, (float) ((double) Graphics.CurrentResolution.Y / 2.0 + 100.0)), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton1.SetText("Restart");
      createMenuButton1.SetLeftClickAction((Action) (() =>
      {
        StateManager.SetState<MainMenuState>();
        StateManager.SetState<IngameState>();
      }));
      CreateMenuButton createMenuButton2 = Blueprint.Spawn<CreateMenuButton>(new Vector2(Graphics.CurrentResolution.X / 2f, (float) ((double) Graphics.CurrentResolution.Y / 2.0 + 200.0)), scale: Vector2.One * 3f, parent: this.GameObject);
      createMenuButton2.SetText("Menu");
      createMenuButton2.SetLeftClickAction((Action) (() => StateManager.SetState<MainMenuState>()));
      Blueprint.Spawn<CreateBlackBackground>(parent: this.GameObject);
    }

    private IEnumerator Animate()
    {
      CreateGameOverPanel createGameOverPanel = this;
      IndividualTextComponent text = createGameOverPanel.GameObject.FindChild((Predicate<GameObject>) (x => x.Tag == "gameoverText")).GetComponent<IndividualTextComponent>();
      TextComponent coinText = createGameOverPanel.GameObject.FindChild((Predicate<GameObject>) (x => x.Tag == "coinTextObj")).GetComponent<TextComponent>();
      while (StateManager.CurrentState is GameoverState)
      {
        for (int index = 0; index < text.Text.Length; ++index)
          text.SetCharacterOffset(index, new Vector2(0.0f, (float) Math.Sin((double) Time.UnscaledTotalTime * 5.0 + (double) index) * 10f));
        coinText.Transform.Scale = Vector2.Lerp(coinText.Transform.Scale, Vector2.One * 3f, 10f * Time.UnscaledDeltaTime);
        coinText.Color = Color.Lerp(coinText.Color, PaletteLoader.GetColor(11), 10f * Time.UnscaledDeltaTime);
        yield return (object) new WaitForSeconds(Time.UnscaledDeltaTime);
      }
    }

    private IEnumerator CoinCount()
    {
      CreateGameOverPanel createGameOverPanel = this;
      TextComponent text = createGameOverPanel.GameObject.FindChild((Predicate<GameObject>) (x => x.Tag == "coinTextObj")).GetComponent<TextComponent>();
      int num = 10;
      int body = createGameOverPanel.totalCoins - createGameOverPanel.totalCoins % num;
      int remainder = createGameOverPanel.totalCoins % num;
      float waitTime = 0.1f;
      int increment = body / num;
      while (createGameOverPanel.coinCount < body)
      {
        yield return (object) new WaitForSeconds(waitTime);
        if (!(StateManager.CurrentState is GameoverState))
        {
          createGameOverPanel.coinCount = createGameOverPanel.totalCoins;
          break;
        }
        Audio.Play("coin", 0.05f, new Vector2(-0.2f, 0.2f), timePitch: false);
        createGameOverPanel.coinCount += increment;
        text.Owner.Transform.Scale = Vector2.One * 4f;
        text.Color = Color.White;
        text.Text = createGameOverPanel.coinCount.ToString() + "$";
      }
      if (remainder > 0 && StateManager.CurrentState is GameoverState)
      {
        createGameOverPanel.coinCount += remainder;
        text.Owner.Transform.Scale = Vector2.One * 4f;
        text.Color = Color.White;
        text.Text = createGameOverPanel.coinCount.ToString() + "$";
      }
    }
  }
}
