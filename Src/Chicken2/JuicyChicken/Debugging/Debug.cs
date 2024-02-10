// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Debug
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace JuicyChicken
{
  public static class Debug
  {
    public static float Framerate => 1f / Time.UnscaledDeltaTime;

    public static Color SpawnColor { get; private set; } = Color.MediumSpringGreen;

    public static Color SuccesColor { get; private set; } = Color.LimeGreen;

    public static Color AlertColor { get; private set; } = Color.Gold;

    public static Color ErrorColor { get; private set; } = Color.Crimson;

    public static Color CommentColor { get; private set; } = Color.SlateGray;

    public static void Log<T>(T value, Color color = default (Color))
    {
      MethodBase method = new StackTrace().GetFrame(1).GetMethod();
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 4);
      interpolatedStringHandler.AppendLiteral("[");
      interpolatedStringHandler.AppendFormatted(DateTime.Now.ToString("HH:mm:ss"));
      interpolatedStringHandler.AppendLiteral("|");
      interpolatedStringHandler.AppendFormatted(method.ReflectedType.Name);
      interpolatedStringHandler.AppendLiteral(".");
      interpolatedStringHandler.AppendFormatted(method.Name);
      interpolatedStringHandler.AppendLiteral("] - ");
      interpolatedStringHandler.AppendFormatted<T>(value);
      DebugConsole.Write<string>(interpolatedStringHandler.ToStringAndClear(), color);
    }
  }
}
