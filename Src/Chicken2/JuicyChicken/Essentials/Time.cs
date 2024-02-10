// JuicyChicken.Time


using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace JuicyChicken
{
  public static class Time
  {
    private static float timeScale = 1f;

    [ConsoleVariable("")]
    public static float TimeScale
    {
      get => Time.timeScale;
      set
      {
        if ((double) value == (double) Time.timeScale)
          return;
        Time.timeScale = value;
        Action timeScaleChanged = Time.OnTimeScaleChanged;
        if (timeScaleChanged == null)
          return;
        timeScaleChanged();
      }
    }

    public static event Action OnTimeScaleChanged;

    public static float DeltaTime { get; private set; }

    public static float UnscaledDeltaTime { get; private set; }

    [ConsoleVariable("")]
    public static float TotalTime { get; private set; }

    public static float UnscaledTotalTime { get; private set; }

    public static void Update(GameTime gameTime)
    {
      Time.DeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds * Time.TimeScale;
      Time.UnscaledDeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
      Time.TotalTime += Time.DeltaTime;
      Time.UnscaledTotalTime = (float) gameTime.TotalGameTime.TotalSeconds;
    }
  }
}
