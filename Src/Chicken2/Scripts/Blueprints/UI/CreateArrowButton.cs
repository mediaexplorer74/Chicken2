// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateArrowButton
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace ChickenRemake
{
  public class CreateArrowButton : CreateButton
  {
    protected override Texture2D GetTexture() => Content.GetTexture("arrow");

    protected override void GetClickSound()
    {
      this.GameObject.GetComponent<Button>().OnLeftClick += (Action) (() => Audio.Play("buttonclick", allowPitching: false));
    }

    protected override void OnHoverEnterAction()
    {
      this.GameObject.GetComponent<Sprite>().Texture = Content.GetTexture("arrowhover");
    }

    protected override void OnHoverExitAction()
    {
      this.GameObject.GetComponent<Sprite>().Texture = Content.GetTexture("arrow");
    }
  }
}
