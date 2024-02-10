// Decompiled with JetBrains decompiler
// Type: ChickenRemake.PlayerSkin
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public class PlayerSkin
  {
    public static List<PlayerSkin> Skins { get; } = new List<PlayerSkin>();

    public static PlayerSkin CurrentSkin { get; set; }

    public static List<string> OwnedSkins { get; set; } = new List<string>();

    public string Name { get; }

    public Texture2D Icon { get; }

    public Texture2D Head { get; }

    public Texture2D Wing { get; }

    public Texture2D Body { get; }

    public Texture2D Foot { get; }

    public int Price { get; } = 500;

    public PlayerSkin(
      string name,
      string head,
      string wing,
      string body,
      string foot,
      int price)
    {
      this.Name = name;
      this.Icon = Content.GetTexture(name);
      this.Head = Content.GetTexture(head);
      this.Wing = Content.GetTexture(wing);
      this.Body = Content.GetTexture(body);
      this.Foot = Content.GetTexture(foot);
      this.Price = price;
    }

    public PlayerSkin(
      string name,
      Texture2D head,
      Texture2D wing,
      Texture2D body,
      Texture2D foot)
    {
      this.Name = name;
      this.Icon = Content.GetTexture(name);
      this.Head = head;
      this.Wing = wing;
      this.Body = body;
      this.Foot = foot;
    }

    public static PlayerSkin FindSkin(string name)
    {
      for (int index = 0; index < PlayerSkin.Skins.Count; ++index)
      {
        if (PlayerSkin.Skins[index].Name == name)
          return PlayerSkin.Skins[index];
      }
      return PlayerSkin.Skins[0];
    }

    public static void Initialize()
    {
      PlayerSkin.Skins.Add(new PlayerSkin("chicken", "head", "wing", "body", "foot", 0));
      PlayerSkin.Skins.Add(new PlayerSkin("sunglasses", "sunglasseshead", "wing", "body", "foot", 500));
      PlayerSkin.Skins.Add(new PlayerSkin("dove", "dovehead", "dovewing", "dovebody", "foot", 500));
      PlayerSkin.Skins.Add(new PlayerSkin("retrochicken", "chickhead", "chickwing", "chickbody", "chickfoot", 10000));
      PlayerSkin.Skins.Add(new PlayerSkin("cock", "cockhead", "wing", "body", "foot", 1000));
      PlayerSkin.Skins.Add(new PlayerSkin("blackbird", "blackbirdhead", "blackbirdwing", "blackbirdbody", "blackbirdfoot", 700));
      PlayerSkin.Skins.Add(new PlayerSkin("rambo", "head", "wing", "body", "foot", 1500));
      PlayerSkin.Skins.Add(new PlayerSkin("chick", "chickhead", "chickwing", "chickbody", "chickfoot", 100));
      PlayerSkin.Skins.Add(new PlayerSkin("disco", "cockhead", "wing", "body", "foot", 2000));
    }
  }
}
