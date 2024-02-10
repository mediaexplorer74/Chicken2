// Decompiled with JetBrains decompiler
// Type: JuicyChicken.PooledThread
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System;
using System.Threading;

#nullable disable
namespace JuicyChicken
{
  public static class PooledThread
  {
    public static void Begin(Action action)
    {
      ThreadPool.QueueUserWorkItem((WaitCallback) (obj => action()));
    }
  }
}
