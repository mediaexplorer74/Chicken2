// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateShopCard
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ChickenRemake
{
  public class CreateShopCard : Blueprint
  {
    protected override void Construct()
    {
      ShopCard shopCard = this.GameObject.AddComponent<ShopCard>();
      Sprite sprite1 = this.GameObject.AddComponent<Sprite>();
      Button button = this.GameObject.AddComponent<Button>();
      sprite1.Texture = Content.GetTexture("card");
      sprite1.Tag = "Card";
      sprite1.Space = Space.Screen;
      sprite1.Layer = 10;
      button.Bounds = sprite1.Texture.GetSize();
      button.Origin = sprite1.Texture.GetPoint(OriginPoint.Center);
      button.OnLeftClick += new Action(shopCard.Purchase);
      button.OnHoverExit += (Action) (() => shopCard.DesiredScale = Vector2.One * 1f);
      button.OnHoverEnter += (Action) (() =>
      {
        Audio.Play("cardshuffle", 0.1f, new Vector2(0.1f, 0.2f), timePitch: false);
        shopCard.DesiredScale = Vector2.One * 1.1f;
      });
      GameObject gameObject1 = GameObject.Spawn(parent: this.GameObject);
      gameObject1.Transform.Position = new Vector2(-45f, 50f);
      gameObject1.Tag = "uiCoin";
      Sprite sprite2 = gameObject1.AddComponent<Sprite>();
      sprite2.Texture = Content.GetTexture("uicoin");
      sprite2.Space = Space.Screen;
      sprite2.Layer = 12;
      GameObject gameObject2 = GameObject.Spawn(parent: this.GameObject);
      gameObject2.Transform.Scale = Vector2.One * 6f;
      gameObject2.Transform.Position = -Vector2.UnitY * 40f;
      gameObject2.Tag = "icon";
      Sprite sprite3 = gameObject2.AddComponent<Sprite>();
      sprite3.Space = Space.Screen;
      sprite3.Layer = 12;
      GameObject gameObject3 = GameObject.Spawn(parent: this.GameObject);
      gameObject3.Transform.Position = new Vector2(-28f, 52f);
      gameObject3.Transform.Scale = Vector2.One * 2f;
      gameObject3.Tag = "costtext";
      TextComponent textComponent = gameObject3.AddComponent<TextComponent>();
      textComponent.Origin = OriginPoint.Left;
      textComponent.LayerDepth = 13;
    }

    public void SetItem(Texture2D icon, int cost, Action buyAction, bool equipped = false)
    {
      this.GameObject.GetComponent<ShopCard>().SetValues(cost, buyAction);
      Sprite component1 = this.GameObject.FindChild((Predicate<GameObject>) (x => x.CompareTag(nameof (icon)))).GetComponent<Sprite>();
      component1.Texture = icon;
      Sprite component2 = this.GameObject.GetComponent<Sprite>((Predicate<Sprite>) (x => x.Tag == "Card"));
      if (cost == 0)
      {
        if (!equipped)
          component2.ColorMask = Color.Black * 0.7f;
        GameObject child = this.GameObject.FindChild((Predicate<GameObject>) (x => x.Tag == "costtext"));
        GameObject.Despawn(this.GameObject.FindChild((Predicate<GameObject>) (x => x.Tag == "uiCoin")));
        child.GetComponent<TextComponent>().Text = "Owned";
        child.Transform.Position = new Vector2(-40f, 52f);
      }
      else
      {
        component2.ColorMask = Color.Black * 0.7f;
        component1.ColorMask = Color.Black;
        TextComponent component3 = this.GameObject.FindChild((Predicate<GameObject>) (x => x.Tag == "costtext")).GetComponent<TextComponent>();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
        interpolatedStringHandler.AppendLiteral("$");
        interpolatedStringHandler.AppendFormatted<int>(cost);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        component3.Text = stringAndClear;
      }
    }
  }
}
