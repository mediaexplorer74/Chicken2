// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateSuperMagnet
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public class CreateSuperMagnet : CreatePowerUp
  {
    protected override float Duration => 15f;

    protected override Texture2D Texture => Content.GetTexture("magnet");

    protected override string PowerUpName => "Coin Magnet!";

    protected override Color PowerUpColor => PaletteLoader.GetColor(17);

    protected override void GetStartAction()
    {
      List<GameObject> gameObjectList = new List<GameObject>();
      List<GameObject> all = GameObject.FindAll((Predicate<GameObject>) (x => x.HasComponent<Magnet>()));
      for (int index = 0; index < all.Count; ++index)
        all[index].GetComponent<Magnet>().Distance = this.SuperMagnetDistance;
    }

    protected override void GetEndAction()
    {
      List<GameObject> gameObjectList = new List<GameObject>();
      List<GameObject> all = GameObject.FindAll((Predicate<GameObject>) (x => x.HasComponent<Magnet>()));
      for (int index = 0; index < all.Count; ++index)
        all[index].GetComponent<Magnet>().Distance = this.MagnetDistance;
    }
  }
}
