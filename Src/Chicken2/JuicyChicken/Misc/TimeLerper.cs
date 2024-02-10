// Decompiled with JetBrains decompiler
// Type: JuicyChicken.TimeLerper
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using System;
using System.Collections;

#nullable disable
namespace JuicyChicken
{
  public static class TimeLerper
  {
    private static float targetTimeScale = 1f;
    private static float transitionTime = 1.5f;
    private static float elapsedTime = 0.0f;
    private static float currentReturnTime = 1f;

    static TimeLerper() => GameLoop.OnUpdate += new Action(TimeLerper.Update);

    private static void Update()
    {
      if ((double) TimeLerper.elapsedTime > (double) TimeLerper.transitionTime)
        return;
      float amount = TimeLerper.elapsedTime / TimeLerper.transitionTime;
      Time.TimeScale = MathHelper.Lerp(Time.TimeScale, TimeLerper.targetTimeScale, amount);
      TimeLerper.elapsedTime += Time.UnscaledDeltaTime;
    }

    public static void Lerp(float target, float duration = 1.5f)
    {
      TimeLerper.elapsedTime = 0.0f;
      TimeLerper.transitionTime = duration;
      TimeLerper.targetTimeScale = target;
      TimeLerper.currentReturnTime = target;
    }

    [ConsoleCommand("", "No Description", 0)]
    public static void Sting(float downTime, float returnTime = 0.0f, float stingTime = 0.1f, float recoverTime = 1f)
    {
      if ((double) returnTime == 0.0)
      {
        Coroutine.Start(TimeLerper.Stinger(downTime, TimeLerper.currentReturnTime, stingTime, recoverTime));
      }
      else
      {
        TimeLerper.currentReturnTime = returnTime;
        Coroutine.Start(TimeLerper.Stinger(downTime, TimeLerper.currentReturnTime, stingTime, recoverTime));
      }
    }

    private static IEnumerator Stinger(
      float lowTime,
      float returnTime,
      float stingTime,
      float recoverTime)
    {
      TimeLerper.Lerp(lowTime, stingTime);
      yield return (object) new WaitForSeconds(stingTime);
      TimeLerper.Lerp(returnTime, recoverTime);
    }
  }
}
