// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateIngamePanel
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;

#nullable disable
namespace ChickenRemake
{
  public class CreateIngamePanel : Blueprint
  {
    protected override void Construct()
    {
      TextComponent textComponent1 = this.GameObject.AddComponent<TextComponent>();
      textComponent1.Color = PaletteLoader.GetColor(11);
      textComponent1.ScaleModifier = Vector2.One * 3f;
      textComponent1.Origin = OriginPoint.TopLeft;
      textComponent1.Tag = "Coin";
      textComponent1.Offset = new Vector2(10f, 10f);
      textComponent1.OutlineColor = PaletteLoader.GetColor(1);
      TextComponent textComponent2 = this.GameObject.AddComponent<TextComponent>();
      textComponent2.ScaleModifier = Vector2.One * 2f;
      textComponent2.Origin = OriginPoint.TopLeft;
      textComponent2.Tag = "Distance";
      textComponent2.Offset = new Vector2(10f, 60f);
      textComponent2.OutlineColor = PaletteLoader.GetColor(22);
      this.GameObject.AddComponent<IngameUIController>();
    }
  }
}
