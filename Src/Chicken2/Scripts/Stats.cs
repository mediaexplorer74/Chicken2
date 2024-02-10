// Decompiled with JetBrains decompiler
// Type: ChickenRemake.Stats
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using System;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public static class Stats
  {
    public static Dictionary<Type, PowerUp> ActivePowerUps = new Dictionary<Type, PowerUp>();

    public static int CoinMultiplier { get; set; } = 1;

    public static int IngameCoins { get; set; } = 0;

    public static int CurrentCoins { get; set; }

    public static float IngameDistance { get; set; } = 0.0f;

    public static float HighScore { get; set; } = 0.0f;

    public static int TotalCoins { get; set; }

    public static float TotalPlaytime { get; set; }

    public static int TotalJumps { get; set; }

    public static void Initialize() => GameLoop.OnUpdate += new Action(Stats.Update);

    private static void Update() => Stats.TotalPlaytime += Time.DeltaTime;

    public static void AddCoin(int amount) => Stats.IngameCoins += amount * Stats.CoinMultiplier;

    public static void ResetStats()
    {
      Stats.CurrentCoins += Stats.IngameCoins;
      Stats.TotalCoins += Stats.IngameCoins;
      if ((double) Stats.IngameDistance > (double) Stats.HighScore)
        Stats.HighScore = Stats.IngameDistance;
      Stats.IngameDistance = 0.0f;
      Stats.IngameCoins = 0;
    }
  }
}
