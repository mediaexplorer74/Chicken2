// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreatePowerUpTextManager
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;

#nullable disable
namespace ChickenRemake
{
  internal class CreatePowerUpTextManager : Blueprint
  {
    protected override void Construct()
    {
      this.GameObject.AddComponent<PowerUpTextManager>();
      this.GameObject.Tag = "PowerUpTextMan";
    }
  }
}
