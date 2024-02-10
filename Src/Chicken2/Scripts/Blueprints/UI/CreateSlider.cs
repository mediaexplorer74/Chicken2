// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateSlider
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  internal class CreateSlider : Blueprint
  {
    protected override void Construct()
    {
      CreateMenuButton createMenuButton1 = Blueprint.Spawn<CreateMenuButton>(new Vector2(-100f, 0.0f), scale: Vector2.One, parent: this.GameObject);
      createMenuButton1.GameObject.Tag = "DecreaseButton";
      createMenuButton1.SetText("-");
      CreateMenuButton createMenuButton2 = Blueprint.Spawn<CreateMenuButton>(new Vector2(100f, 0.0f), scale: Vector2.One, parent: this.GameObject);
      createMenuButton2.GameObject.Tag = "IncreaseButton";
      createMenuButton2.SetText("+");
      Vector2 position = new Vector2(0.0f, -30f);
      GameObject gameObject1 = this.GameObject;
      Vector2 scale = Vector2.One * 2f;
      GameObject parent = gameObject1;
      GameObject gameObject2 = GameObject.Spawn(position, scale: scale, parent: parent);
      gameObject2.Tag = "titleText";
      TextComponent textComponent1 = gameObject2.AddComponent<TextComponent>();
      textComponent1.Origin = OriginPoint.Center;
      textComponent1.Text = "VALUE";
      textComponent1.OutlineColor = Color.Black * 0.3f;
      textComponent1.LayerDepth = 13;
      GameObject gameObject3 = GameObject.Spawn(scale: Vector2.One * 1.5f, parent: this.GameObject);
      gameObject3.Tag = "valueText";
      TextComponent textComponent2 = gameObject3.AddComponent<TextComponent>();
      textComponent2.Origin = OriginPoint.Center;
      textComponent2.Text = "VALUE";
      textComponent2.OutlineColor = Color.Black * 0.3f;
      textComponent2.LayerDepth = 13;
    }

    public void SetIncreaseAction(Action action)
    {
      GameObject.Find((Predicate<GameObject>) (x => x.Tag == "IncreaseButton")).GetComponent<Button>().OnLeftClick += action;
    }

    public void SetDecreaseAction(Action action)
    {
      GameObject.Find((Predicate<GameObject>) (x => x.Tag == "DecreaseButton")).GetComponent<Button>().OnLeftClick += action;
    }

    public void SetTitle(string title)
    {
      GameObject.Find((Predicate<GameObject>) (x => x.Tag == "titleText")).GetComponent<TextComponent>().Text = title;
    }

    public void BindText(ModValue value)
    {
      GameObject.Find((Predicate<GameObject>) (x => x.Tag == "valueText")).GetComponent<TextComponent>().BindValue(value);
    }
  }
}
