// ChickenRemake.StateManager

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

#nullable disable
namespace ChickenRemake
{
  public static class StateManager
  {
    private static IState currentState;
    private static bool paused;

    public static SoundEffectInstance Music { get; set; }

    public static GameObject Player { get; private set; }

    public static IState CurrentState => StateManager.currentState;

    public static event Action OnGameOver;

    public static void SetState<T>() where T : IState, new()
    {
      IState currentState = StateManager.currentState;
      T newState = new T();
      if (StateManager.currentState != null)
        StateManager.currentState.Exit((IState) newState);
      StateManager.currentState = (IState) newState;
      newState.Start(currentState);
      Debug.Log<string>("Game state set to: " + newState.GetType().Name.Replace("State", ""));
    }

    public static void StartGame()
    {
        StateManager.Player = Blueprint.Spawn<CreatePlayer>(new Vector2(-15f, -50f)).GameObject;

        if (StateManager.Music == null || StateManager.Music.State == SoundState.Stopped)
        {
            StateManager.Music = JuicyChicken.Audio.Play(
                "mainMusic", 0.2f, loop: true, allowMultiple: false);
        }
        else
        {
            StateManager.Music.Volume = 0.2f;
        }
    }

    public static void GameOver()
    {
      if (StateManager.Music != null)
        StateManager.Music.Volume = 0.1f;

      if (StateManager.Player != null)
      {
        GameObject.Despawn(StateManager.Player);
        StateManager.Player = (GameObject) null;
      }
      Action onGameOver = StateManager.OnGameOver;
      
      if (onGameOver != null)
        onGameOver();

      StateManager.OnGameOver = (Action) null;
      Stats.ActivePowerUps.Clear();
      Database.Save();
    }

    public static void Quit()
    {
      Database.Save();
      Environment.Exit(0);
    }

    [ConsoleCommand("Pause", "Pause or unpause the game", 0)]
    private static void PauseToggle()
    {
      StateManager.paused = StateManager.currentState is IngameState;

      if (StateManager.paused)
        StateManager.SetState<PauseState>();
      else if (StateManager.currentState is PauseState)
        StateManager.SetState<IngameState>();
      else
        Debug.Log<string>("Cannot pause; Not current ingame", Debug.ErrorColor);
    }
  }
}
