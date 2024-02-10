// Decompiled with JetBrains decompiler
// Type: ChickenRemake.Database
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

#nullable disable
namespace ChickenRemake
{
  public static class Database
  {
    private static object loadLockObject = new object();
    private static object saveLockObject = new object();

    public static string CurrentUser { get; set; } = "testuser";

    public static void Load()
    {
      new Thread((ThreadStart) (() =>
      {
        lock (Database.loadLockObject)
        {
          Stats.CurrentCoins = SQL.GetValue<int>("statistics", "coins", Database.CurrentUser,0);
          Stats.TotalCoins = SQL.GetValue<int>("statistics", "totalcoins", Database.CurrentUser,0);
          Stats.TotalPlaytime = SQL.GetValue<int>("statistics", "playtime", Database.CurrentUser,0);
          Stats.TotalJumps = SQL.GetValue<int>("statistics", "totaljumps", Database.CurrentUser,0);
          Stats.HighScore = SQL.GetValue<int>("statistics", "highscore", Database.CurrentUser,0);
          PlayerSkin.CurrentSkin = PlayerSkin.FindSkin(SQL.GetValue<string>("skins", "currentskin", 
              Database.CurrentUser, "chicken"));
        }
      })).Start();
    }

    public static void ResetSaveFile()
    {
      SQL.SetValue<int>("statistics", "coins", Database.CurrentUser, 0);
      SQL.SetValue<int>("statistics", "totalcoins", Database.CurrentUser, 0);
      SQL.SetValue<int>("statistics", "playtime", Database.CurrentUser, 0);
      SQL.SetValue<int>("statistics", "totaljumps", Database.CurrentUser, 0);
      SQL.SetValue<int>("statistics", "highscore", Database.CurrentUser, 0);
      SQL.SetValue<int>("settings", "joyMouseSpeed", Database.CurrentUser, 5);
      SQL.SetValue<string>("skins", "currentskin", Database.CurrentUser, "Chicken");
      SQL.SetValue<string>("skins", "allSkins", Database.CurrentUser, "");
      Database.BlockingLoad();
      StateManager.SetState<MainMenuState>();
    }

    public static void BlockingLoad()
    {
      Stats.CurrentCoins = SQL.GetValue<int>("statistics", "coins", Database.CurrentUser, 0);
      Stats.TotalCoins = SQL.GetValue<int>("statistics", "totalcoins", Database.CurrentUser, 0);
      Stats.TotalPlaytime = (float) SQL.GetValue<int>("statistics", "playtime", Database.CurrentUser, 0);
      Stats.TotalJumps = SQL.GetValue<int>("statistics", "totaljumps", Database.CurrentUser, 0);
      Stats.HighScore = SQL.GetValue<int>("statistics", "highscore", Database.CurrentUser, 0);
      Input.JoyMouseSpeed = new ModValue((float) SQL.GetValue<int>("settings", "joyMouseSpeed", Database.CurrentUser, 5));
      PlayerSkin.CurrentSkin = PlayerSkin.FindSkin(SQL.GetValue<string>("skins", "currentskin", Database.CurrentUser, "chicken"));
     
     //RnD
     PlayerSkin.OwnedSkins = default;//((IEnumerable<string>) SQL.GetValue<string>("skins", 
                          //"allSkins", Database.CurrentUser, "").Split(',')).ToList<string>();
    }

    public static void Save()
    {
      new Thread((ThreadStart) (() =>
      {
        lock (Database.saveLockObject)
        {
          Stats.ResetStats();
          SQL.SetValue<int>("statistics", "coins", Database.CurrentUser, Stats.CurrentCoins);
          SQL.SetValue<int>("statistics", "totalcoins", Database.CurrentUser, Stats.TotalCoins);
          SQL.SetValue<double>("statistics", "playtime", Database.CurrentUser, Math.Round((double) Stats.TotalPlaytime, 0));
          SQL.SetValue<int>("statistics", "totaljumps", Database.CurrentUser, Stats.TotalJumps);
          SQL.SetValue<float>("statistics", "highscore", Database.CurrentUser, Stats.HighScore);
          SQL.SetValue<float>("settings", "joyMouseSpeed", Database.CurrentUser, Input.JoyMouseSpeed.Value);
          SQL.SetValue<string>("skins", "currentskin", Database.CurrentUser, PlayerSkin.CurrentSkin.Name);
          //RnD
          //SQL.SetValue<string>("skins", "allSkins", Database.CurrentUser, string.Join<string>(",",
          //    (IEnumerable<string>) PlayerSkin.OwnedSkins));
          Debug.Log<string>("SAVED DATA");
        }
      })).Start();
    }
  }
}
