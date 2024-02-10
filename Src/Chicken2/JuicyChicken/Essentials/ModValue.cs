// Decompiled with JetBrains decompiler
// Type: JuicyChicken.ModValue
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public class ModValue
  {
    private float baseValue;
    private List<float> modifiers = new List<float>();
    private List<float> multipliers = new List<float>();

    public float Value
    {
      get
      {
        float finalValue = this.baseValue;
        this.modifiers.ForEach((Action<float>) (x => finalValue += x));
        float multiplier = 1f;
        this.multipliers.ForEach((Action<float>) (x => multiplier += x));
        finalValue *= multiplier;
        return finalValue;
      }
    }

    public ModValue(float baseValue) => this.baseValue = baseValue;

    public void AddModifier(float modifier) => this.modifiers.Add(modifier);

    public void AddMultiplier(float multiplier) => this.multipliers.Add(multiplier);

    public void RemoveModifier(float modifier)
    {
      if (!this.modifiers.Contains(modifier))
        return;
      this.modifiers.Remove(modifier);
    }

    public void RemoveMultiplier(float multiplier)
    {
      if (!this.multipliers.Contains(multiplier))
        return;
      this.multipliers.Remove(multiplier);
    }
  }
}
