// Decompiled with JetBrains decompiler
// Type: ChickenRemake.AnimationContainer
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  internal class AnimationContainer : Component
  {
    private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

    public override void Reset()
    {
      this.animations.Clear();
      this.animations = (Dictionary<string, Animation>) null;
    }

    public void AddAnimation(string name, Animation animation)
    {
      this.animations.Add(name, animation);
    }

    public bool GetAnimation(string name, out Animation animation)
    {
      Animation animation1;
      if (this.animations.TryGetValue(name, out animation1))
      {
        animation = animation1;
        return true;
      }
      animation = new Animation();
      return false;
    }
  }
}
