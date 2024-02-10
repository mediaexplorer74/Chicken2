// ChickenRemake.GameoverState

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

#nullable disable
namespace ChickenRemake
{
  public class GameoverState : IState
  {
    private SoundEffectInstance deathSound;

    public void Start(IState previousState)
    {
      this.deathSound = JuicyChicken.Audio.Play("scratch", 0.2f, new Vector2(-0.3f, 0.0f));
      Stats.ActivePowerUps.Clear();
      TimeLerper.Lerp(0.2f, 1f);
      GameObject gameObject = Blueprint.Spawn<CreateGameOverPanel>().GameObject;
      Level.Instance.Speed = 30f;
      gameObject.Tag = "gameoverPanel";
      StateManager.GameOver();
    }

    public void Exit(IState newState)
    {
      GameObject.Despawn(Level.Instance.Owner);
      TimeLerper.Lerp(1f, 1f);
      JuicyChicken.Audio.Stop(this.deathSound);
      GameObject.Despawn(GameObject.Find((Predicate<GameObject>) (x => x.Tag == "gameoverPanel")));
      StateManager.Music.Stop();
      this.deathSound = (SoundEffectInstance) null;
    }
  }
}
