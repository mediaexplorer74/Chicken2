// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateMenuButton
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

#nullable disable
namespace ChickenRemake
{
  public class CreateMenuButton : CreateButton
  {
    protected override Texture2D GetTexture() => Content.GetTexture("button");

    protected override void OnHoverEnterAction()
    {
      Sprite component1 = this.GameObject.GetComponent<Sprite>();
      TextComponent component2 = this.GameObject.GetComponent<TextComponent>();
      component1.Texture = Content.GetTexture("buttonHover");
      component1.ColorMask = Color.Azure * 0.3f;
      Audio.Play("buttonFlick", 0.1f, new Vector2(0.3f, 0.8f), allowPitching: false);
      this.GameObject.Transform.Scale = this.GameObject.Transform.Scale * 1.07f;
      component2.Offset = Vector2.UnitY * 3f;
    }

    protected override void OnLeftClickAction()
    {
      Sprite component1 = this.GameObject.GetComponent<Sprite>();
      TextComponent component2 = this.GameObject.GetComponent<TextComponent>();
      Texture2D texture = Content.GetTexture("buttonclick");
      component1.Texture = texture;
      component2.Offset = Vector2.UnitY * 6f;
    }

    protected override void OnHoverExitAction()
    {
      Sprite component1 = this.GameObject.GetComponent<Sprite>();
      TextComponent component2 = this.GameObject.GetComponent<TextComponent>();
      component1.Texture = Content.GetTexture("button");
      component1.ColorMask = Color.Transparent;
      this.GameObject.Transform.Scale = this.GameObject.Transform.Scale / 1.07f;
      component2.Offset = Vector2.Zero;
    }

    protected override void GetClickSound()
    {
      this.GameObject.GetComponent<Button>().OnLeftClick += (Action) (() => Audio.Play("buttonclick", allowPitching: false));
    }

    private IEnumerator LerpScale(Vector2 scale, float duration)
    {
      CreateMenuButton createMenuButton = this;
      float elapsedTime = 0.0f;
      while (true)
      {
        createMenuButton.GameObject.Transform.Scale = Vector2.Lerp(createMenuButton.GameObject.Transform.Scale, scale, elapsedTime / duration);
        elapsedTime += Time.UnscaledDeltaTime;
        if ((double) elapsedTime < (double) duration)
          yield return (object) new WaitForSeconds(Time.UnscaledDeltaTime);
        else
          break;
      }
    }
  }
}
