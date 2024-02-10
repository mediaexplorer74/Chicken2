// Decompiled with JetBrains decompiler
// Type: JuicyChicken.GameLoop
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

#nullable disable
namespace JuicyChicken
{
  public static class GameLoop
  {
    private static RenderTarget2D target;

    public static event Action OnUpdate;

    public static event Action OnLateUpdate;

    public static event Action<Space> OnDraw;

    public static event Action OnGUI;

    static GameLoop()
    {
      Coroutine.Start(GameLoop.LateUpdate());
      GameLoop.target = new RenderTarget2D(JuicyChicken.Graphics.Device, (int) JuicyChicken.Graphics.CurrentResolution.X, (int) JuicyChicken.Graphics.CurrentResolution.Y);
      JuicyChicken.Graphics.OnResolutionChanged += (Action) (() => GameLoop.target = new RenderTarget2D(JuicyChicken.Graphics.Device, (int) JuicyChicken.Graphics.CurrentResolution.X, (int) JuicyChicken.Graphics.CurrentResolution.Y));
    }

    public static void InvokeUpdate(GameTime gameTime)
    {
      Time.Update(gameTime);
      Action onUpdate = GameLoop.OnUpdate;
      if (onUpdate == null)
        return;
      onUpdate();
    }

    private static IEnumerator LateUpdate()
    {
      yield return (object) null;
      while (true)
      {
        Action onLateUpdate;
        do
        {
          yield return (object) null;
          onLateUpdate = GameLoop.OnLateUpdate;
        }
        while (onLateUpdate == null);
        onLateUpdate();
      }
    }

    public static void InvokeDraw(BlendState blendState, SamplerState samplerState)
    {
      JuicyChicken.Graphics.Device.SetRenderTarget(GameLoop.target);
      JuicyChicken.Graphics.Device.Clear(JuicyChicken.Graphics.ClearColor);
      JuicyChicken.Graphics.SpriteBatch.Begin(SpriteSortMode.FrontToBack, blendState, SamplerState.PointWrap, transformMatrix: new Matrix?(Camera.Matrix));
      Action<Space> onDraw1 = GameLoop.OnDraw;
      if (onDraw1 != null)
        onDraw1(Space.WrappedWorld);
      JuicyChicken.Graphics.SpriteBatch.End();
      JuicyChicken.Graphics.SpriteBatch.Begin(SpriteSortMode.FrontToBack, blendState, samplerState, transformMatrix: new Matrix?(Camera.Matrix));
      Action<Space> onDraw2 = GameLoop.OnDraw;
      if (onDraw2 != null)
        onDraw2(Space.World);
      JuicyChicken.Graphics.SpriteBatch.End();
      JuicyChicken.Graphics.Device.SetRenderTarget((RenderTarget2D) null);
      JuicyChicken.Graphics.SpriteBatch.Begin(SpriteSortMode.FrontToBack, blendState, samplerState, effect: JuicyChicken.Graphics.ScreenEffect);
      JuicyChicken.Graphics.SpriteBatch.Draw((Texture2D) GameLoop.target, new Rectangle(0, 0, (int) JuicyChicken.Graphics.CurrentResolution.X, (int) JuicyChicken.Graphics.CurrentResolution.Y), Color.White);
      JuicyChicken.Graphics.SpriteBatch.End();
      JuicyChicken.Graphics.GuiRenderer.RenderBuffer((Texture2D) GameLoop.target);
      JuicyChicken.Graphics.SpriteBatch.Begin(SpriteSortMode.FrontToBack, blendState, samplerState);
      Action<Space> onDraw3 = GameLoop.OnDraw;
      if (onDraw3 != null)
        onDraw3(Space.Screen);
      JuicyChicken.Graphics.SpriteBatch.End();
      JuicyChicken.Graphics.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive, samplerState);
      Action<Space> onDraw4 = GameLoop.OnDraw;
      if (onDraw4 != null)
        onDraw4(Space.AdditiveScreen);
      JuicyChicken.Graphics.SpriteBatch.End();
      JuicyChicken.Graphics.GuiRenderer.BeforeLayout();
      Action onGui = GameLoop.OnGUI;
      if (onGui != null)
        onGui();
      JuicyChicken.Graphics.GuiRenderer.AfterLayout();
    }
  }
}
