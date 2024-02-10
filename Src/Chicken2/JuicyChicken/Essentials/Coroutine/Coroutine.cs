// JuicyChicken.Coroutine

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public static class Coroutine
  {
    private static readonly List<CoroutineHandler> handlers = new List<CoroutineHandler>();

    static Coroutine()
    {
      Coroutine.handlers = new List<CoroutineHandler>();
      GameLoop.OnUpdate += new Action(Coroutine.Update);
    }

    public static void Start(IEnumerator method)
    {
      CoroutineHandler coroutineHandler = new CoroutineHandler(method);
      Coroutine.handlers.Add(coroutineHandler);
      coroutineHandler.Step();
    }

    public static void Stop(IEnumerator method)
    {
      CoroutineHandler coroutineHandler = new CoroutineHandler(method);
      Coroutine.handlers.Remove(coroutineHandler);
    }

    public static void Update()
    {
      for (int index = 0; index < Coroutine.handlers.Count; ++index)
      {
        CoroutineHandler handler = Coroutine.handlers[index];
        handler.Update();
        if (handler.IsDone)
          Coroutine.handlers.Remove(handler);
      }
    }
  }
}
