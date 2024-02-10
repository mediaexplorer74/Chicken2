// ChickenRemake.PowerUpTextManager

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace ChickenRemake
{
  internal class PowerUpTextManager : Component
  {
    private Dictionary<string, GameObject> powerupTexts = new Dictionary<string, GameObject>();

    public override void Reset()
    {
        try
        {
            foreach (string key in this.powerupTexts.Keys)
            {
                this.Remove(key);
            }
        }
        catch (Exception ex)
        { }

        this.powerupTexts.Clear();
        this.powerupTexts = (Dictionary<string, GameObject>) null;
    }

    public void SpawnText(string name, Color color, float duration)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = 
                new DefaultInterpolatedStringHandler(3, 2);
      interpolatedStringHandler.AppendFormatted(name);
      interpolatedStringHandler.AppendLiteral(" | ");
      interpolatedStringHandler.AppendFormatted<float>(duration);
      Debug.Log<string>(interpolatedStringHandler.ToStringAndClear());
      if (this.powerupTexts.ContainsKey(name))
      {
        this.powerupTexts[name].GetComponent<PowerupText>().ResetTimer();
      }
      else
      {
        GameObject gameObject = Blueprint.Spawn<CreatePopupText>(new Vector2(
            Graphics.CurrentResolution.X / 2f, 
            (float) (30 + 30 * this.powerupTexts.Count - 1))).GameObject;
        PowerupText component = gameObject.GetComponent<PowerupText>();
        component.StartAnimation(name, color, duration);
        component.OnFinish += (Action) (() => this.Remove(name));
        this.powerupTexts.Add(name, gameObject);
      }
    }

    private void Remove(string name)
    {
      GameObject gameObject;
      if (!this.powerupTexts.TryGetValue(name, out gameObject))
        return;

      this.powerupTexts.Remove(name);
      GameObject.Despawn(gameObject);
    }
  }
}
