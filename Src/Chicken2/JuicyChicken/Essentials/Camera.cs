// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Camera
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace JuicyChicken
{
  public static class Camera
  {
    private static float zoom = 1f;
    private static Vector2 currentPosition;
    private static Vector2 shakePosition;
    private static float shakeAmplitude;
    private static float shakeDuration;
    private static Random random = new Random();

    public static Matrix Matrix { get; private set; }

    public static Vector2 Target { get; set; } = Vector2.Zero;

    [ConsoleVariable("")]
    public static float Zoom
    {
      get => Camera.zoom;
      set
      {
        Camera.zoom = value * (float) (((double) Graphics.AspectRatio.X
                    + (double) Graphics.AspectRatio.Y) / 2.0);
      }
    }

    static Camera() => GameLoop.OnUpdate += new Action(Camera.Update);

    private static void Update()
    {
      Camera.shakePosition += new Vector2(Camera.random.Next(-Camera.shakeAmplitude, Camera.shakeAmplitude), Camera.random.Next(-Camera.shakeAmplitude, Camera.shakeAmplitude));
      Camera.shakePosition = Vector2.Lerp(Camera.shakePosition, Vector2.Zero, 50f * Time.DeltaTime);
      Camera.shakeAmplitude = MathHelper.Lerp(Camera.shakeAmplitude, 0.0f, Camera.shakeDuration * Time.DeltaTime);
      Camera.currentPosition = Vector2.Lerp(Camera.currentPosition, Camera.Target + Camera.shakePosition, 10f * Time.DeltaTime);
      float num1 = Graphics.CurrentResolution.X / 2f;
      float num2 = Graphics.CurrentResolution.Y / 2f;
      Camera.Matrix = Matrix.CreateScale(new Vector3(Camera.Zoom, Camera.Zoom, 1f)) * Matrix.CreateTranslation(new Vector3(-Camera.currentPosition.X * Camera.Zoom + num1, -Camera.currentPosition.Y * Camera.Zoom + num2, 0.0f));
    }

    [ConsoleCommand("", "No Description", 0)]
    public static void Shake(float amplitude, float duration)
    {
      Camera.shakeAmplitude = amplitude;
      Camera.shakeDuration = duration;
    }

    public static Vector2 ScreenToWorld(Vector2 pos)
    {
      Matrix matrix = Matrix.Invert(Camera.Matrix);
      return Vector2.Transform(pos, matrix);
    }
  }
}
