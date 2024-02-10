// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateButton
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
  public abstract class CreateButton : Blueprint
  {
    protected override void Construct()
    {
      Button button = this.GameObject.AddComponent<Button>();
      Sprite sprite = this.GameObject.AddComponent<Sprite>();
      sprite.Texture = this.GetTexture();
      sprite.Space = Space.Screen;
      sprite.Origin = OriginPoint.Center;
      sprite.Layer = 12;
      button.Bounds = sprite.Texture.GetSize();
      button.Origin = sprite.Texture.GetPoint(OriginPoint.Center);
      button.OnHoverEnter += new Action(this.OnHoverEnterAction);
      button.OnLeftClick += new Action(this.OnLeftClickAction);
      button.OnHoverExit += new Action(this.OnHoverExitAction);
      this.GetClickSound();
    }

    protected abstract Texture2D GetTexture();

    protected virtual void OnHoverEnterAction()
    {
    }

    protected virtual void OnLeftClickAction()
    {
    }

    protected virtual void OnHoverExitAction()
    {
    }

    protected virtual void GetClickSound()
    {
    }

    public void SetText(string input)
    {
      TextComponent textComponent = this.GameObject.HasComponent<TextComponent>() ? this.GameObject.GetComponent<TextComponent>() : this.GameObject.AddComponent<TextComponent>();
      textComponent.Text = input;
      textComponent.Origin = OriginPoint.Center;
      textComponent.OutlineColor = Color.Black * 0.3f;
      textComponent.LayerDepth = 13;
    }

    public void SetTextScale(Vector2 scale)
    {
      (this.GameObject.HasComponent<TextComponent>() ? this.GameObject.GetComponent<TextComponent>() : this.GameObject.AddComponent<TextComponent>()).ScaleModifier = scale;
    }

    public virtual void SetLeftClickAction(Action newAction)
    {
      this.GameObject.GetComponent<Button>().OnLeftClick += newAction;
    }

    public virtual void SetRightClickAction(Action newAction)
    {
      this.GameObject.GetComponent<Button>().OnRightClick += newAction;
    }
  }
}
