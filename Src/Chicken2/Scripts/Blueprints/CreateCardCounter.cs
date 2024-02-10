// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateCardCounter
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;

#nullable disable
namespace ChickenRemake
{
  public class CreateCardCounter : Blueprint
  {
    protected override void Construct()
    {
      TextComponent textComponent = this.GameObject.AddComponent<TextComponent>();
      textComponent.Origin = OriginPoint.Left;
      textComponent.OutlineColor = PaletteLoader.GetColor(22);
    }
  }
}
