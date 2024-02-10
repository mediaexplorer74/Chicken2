// Decompiled with JetBrains decompiler
// Type: ChickenRemake.Cheatcodes
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using System;

#nullable disable
namespace ChickenRemake
{
  public static class Cheatcodes
  {
    private static bool isNoclipped;

    [ConsoleCommand("Noclip", "Disables player colissions", 0)]
    private static void NoClip()
    {
      try
      {
        Collider component = StateManager.Player.GetComponent<Collider>();

        if (!Cheatcodes.isNoclipped)
        {
          component.AddToBlackList((Enum) ObjectLayer.Obstacle);
          Debug.Log<string>("NoClip ON", Debug.SuccesColor);
          Cheatcodes.isNoclipped = true;
        }
        else
        {
          component.RemoveFromBlackList((Enum) ObjectLayer.Obstacle);
          Debug.Log<string>("NoClip OFF", Debug.ErrorColor);
          Cheatcodes.isNoclipped = false;
        }
      }
      catch
      {
        Debug.Log<string>("Player not found", Debug.AlertColor);
      }
    }

    [ConsoleCommand("AddCoins", "Adds coins", 0)]
    private static void Coins(int amount) => Stats.IngameCoins += amount;

    [ConsoleCommand("FMode", "Activates FMode", 0)]
    private static void FMode() => Audio.Play("Fart");
  }
}
