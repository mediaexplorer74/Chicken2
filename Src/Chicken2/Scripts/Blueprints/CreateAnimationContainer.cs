// Decompiled with JetBrains decompiler
// Type: ChickenRemake.CreateAnimationContainer
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;

#nullable disable
namespace ChickenRemake
{
  internal class CreateAnimationContainer : Blueprint
  {
    protected override void Construct()
    {
      this.GameObject.Tag = "animContainer";
      AnimationContainer animationContainer = this.GameObject.AddComponent<AnimationContainer>();
      animationContainer.AddAnimation("jump", new Animation(Content.GetTexture("jump"), 5, 1, 16, 16, 25, false));
      animationContainer.AddAnimation("rock", new Animation(Content.GetTexture("RockBreak"), 5, 1, 24, 16, 20, false));
    }
  }
}
