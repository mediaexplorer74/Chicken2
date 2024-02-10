// Decompiled with JetBrains decompiler
// Type: ChickenRemake.ShopCardHandler
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable disable
namespace ChickenRemake
{
  public class ShopCardHandler : Component
  {
    private const int cardCount = 5;
    private int page;
    private int totalPages;
    private List<GameObject> cards = new List<GameObject>();
    private GameObject cardCounter;

    protected override void Start()
    {
      this.totalPages = PlayerSkin.Skins.Count / 5;
      this.totalPages -= PlayerSkin.Skins.Count % 5 == 0 ? 1 : 0;
      this.SpawnCards();
      this.cardCounter = Blueprint.Spawn<CreateCardCounter>(parent: this.Owner).GameObject;
      this.cardCounter.Transform.Position = new Vector2(240f, Graphics.CurrentResolution.Y * 0.33f);
      this.cardCounter.Transform.Scale = Vector2.One * 3f;
      this.SetPageText();
    }

    private void SpawnCards()
    {
      Vector2 vector2 = new Vector2(300f, Graphics.CurrentResolution.Y / 2f);
      int min = this.page * 5;

      int clamp = PlayerSkin.Skins.Count;

       if (PlayerSkin.Skins.Count > min + 5)
            clamp = min + 5;

       if (PlayerSkin.Skins.Count < min)
            clamp = min;

        for
        (
            int index1 = min;
            index1 < clamp/*Math.Clamp(PlayerSkin.Skins.Count, min, min + 5)*/;
            ++index1
        )
        {
            int index = index1;
            CreateShopCard createShopCard = Blueprint.Spawn<CreateShopCard>(parent: this.Owner);

            if (1==0)//(PlayerSkin.OwnedSkins.Contains(PlayerSkin.Skins[index].Name))
            {
                createShopCard.SetItem(PlayerSkin.Skins[index].Icon, 0,
                    (Action)(() => this.SetSkin(index)),
                    PlayerSkin.CurrentSkin.Name == PlayerSkin.Skins[index].Name);
            }
            else
            { 
                createShopCard.SetItem(/*PlayerSkin.Skins[index].Icon*/default, /*PlayerSkin.Skins[index].Price*/100, 
                    (Action)(() => this.SetSkin(index)));
            }

           createShopCard.GameObject.Transform.Position = vector2 
                    + Vector2.UnitX * (float) (index1 - min) * 165f;
           this.cards.Add(createShopCard.GameObject);
        }
    }

    private void SetSkin(int index)
    {
      PlayerSkin skin = default;//PlayerSkin.Skins[index];

      PlayerSkin.CurrentSkin = skin;
      if (!PlayerSkin.OwnedSkins.Contains(skin.Name))
      {
        PlayerSkin.OwnedSkins.Add("skin.Name");
        Stats.CurrentCoins -= PlayerSkin.Skins[index].Price;
      }
      StateManager.SetState<ShopState>();
    }

    private void DespawnCards()
    {
      foreach (GameObject card in this.cards)
        GameObject.Despawn(card);
      this.cards.Clear();
    }

    private void SetPageText()
    {
      TextComponent component = this.cardCounter.GetComponent<TextComponent>();
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
      interpolatedStringHandler.AppendFormatted<int>(this.page + 1);
      interpolatedStringHandler.AppendLiteral(" / ");
      interpolatedStringHandler.AppendFormatted<int>(this.totalPages + 1);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      component.Text = stringAndClear;
    }

    public void SetPage(bool pageUp)
    {
      if (pageUp)
      {
        if (this.page < this.totalPages)
          ++this.page;
        else
          this.page = 0;
      }
      else if (this.page > 0)
        --this.page;
      else
        this.page = this.totalPages;
      this.SetPageText();
      this.DespawnCards();
      this.SpawnCards();
    }

    public override void Reset() => this.cards.Clear();
  }
}
