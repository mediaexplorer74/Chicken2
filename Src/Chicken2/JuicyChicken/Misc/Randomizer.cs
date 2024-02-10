// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Randomizer
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System;

#nullable disable
namespace JuicyChicken
{
  public static class Randomizer
  {
    private static Random random = new Random();
    private static int seed = 0;

    public static int Seed
    {
      get => Randomizer.seed;
      set
      {
        Randomizer.seed = value;
        Randomizer.random = new Random(Randomizer.seed);
      }
    }

    public static int Next(int min, int max) => Randomizer.random.Next(min, max);

    public static float Next(float min, float max) => Randomizer.random.Next(min, max);

    public static bool Chance(float chance)
    {
     float clamp = chance;
     if (chance > 1f)
        clamp = 1f;

     if (chance < 0.0f)
        clamp = 0.0f;

     chance = clamp;//Math.Clamp(chance, 0.0f, 1f);
      return (double) chance > Randomizer.random.NextDouble();
    }

    public static T Choose<T>(params T[] values)
    {
      return values[Randomizer.random.Next(0, values.Length)];
    }
  }
}
