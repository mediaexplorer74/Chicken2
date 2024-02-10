// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Graphics
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using ImGuiNET;
using MGUI.MonoUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

#nullable disable
namespace JuicyChicken
{
  public static class Graphics
  {
    private static bool showBuffer = false;

    public static GraphicsDeviceManager Manager { get; private set; }

    public static GraphicsDevice Device => JuicyChicken.Graphics.Manager.GraphicsDevice;

    public static SpriteBatch SpriteBatch { get; private set; }

    public static ImGuiRenderer GuiRenderer { get; private set; }

    public static Microsoft.Xna.Framework.Vector2 DeviceResolution { get; private set; }

    public static Microsoft.Xna.Framework.Vector2 ReferenceResolution { get; set; }

    public static Microsoft.Xna.Framework.Vector2 CurrentResolution
    {
      get
      {
        return new Microsoft.Xna.Framework.Vector2((float) 
            JuicyChicken.Graphics.Manager.PreferredBackBufferWidth,
            (float) JuicyChicken.Graphics.Manager.PreferredBackBufferHeight);
      }
    }

    public static Microsoft.Xna.Framework.Vector2 AspectRatio
    {
      get => JuicyChicken.Graphics.CurrentResolution / JuicyChicken.Graphics.ReferenceResolution;
    }

    public static Color ClearColor { get; set; } = Color.Black;

    public static Effect ScreenEffect { get; set; }

    public static event Action OnResolutionChanged;

    public static void Initialize(Game game, int resolutionWidth, int resolutionHeight)
    {
      JuicyChicken.Graphics.Manager = new GraphicsDeviceManager(game);
      JuicyChicken.Graphics.Manager.ApplyChanges();
      JuicyChicken.Graphics.SpriteBatch = new SpriteBatch(JuicyChicken.Graphics.Device);
      string customFontPath = Path.Combine(Directory.GetCurrentDirectory(), "MonoUI\\roboto.ttf");
      JuicyChicken.Graphics.GuiRenderer = new ImGuiRenderer(game, customFontPath);
      JuicyChicken.Graphics.GuiRenderer.RebuildFontAtlas();
      GameLoop.OnGUI += new Action(JuicyChicken.Graphics.FrameBufferWindow);
      ImGui.GetIO().ConfigFlags = ImGuiConfigFlags.DockingEnable;
      Styler.SetStyle();
      JuicyChicken.Graphics.DeviceResolution = new Microsoft.Xna.Framework.Vector2((float) GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, (float) GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
      JuicyChicken.Graphics.ReferenceResolution = new Microsoft.Xna.Framework.Vector2((float) resolutionWidth, (float) resolutionHeight);
      JuicyChicken.Graphics.SetResolution(resolutionWidth, resolutionHeight);
    }

    [ConsoleCommand("", "No Description", 0)]
    public static void SetResolution(int width, int height, bool adjustZoom = false)
    {
      JuicyChicken.Graphics.SetResolution(new Microsoft.Xna.Framework.Vector2((float) width, (float) height), adjustZoom);
    }

    public static void SetResolution(Microsoft.Xna.Framework.Vector2 resolution, bool adjustZoom = false)
    {
      if (adjustZoom)
        Camera.Zoom *= resolution.X / JuicyChicken.Graphics.CurrentResolution.X;
      JuicyChicken.Graphics.Manager.PreferredBackBufferWidth = (int) resolution.X;
      JuicyChicken.Graphics.Manager.PreferredBackBufferHeight = (int) resolution.Y;
      JuicyChicken.Graphics.Manager.ApplyChanges();
      Action resolutionChanged = JuicyChicken.Graphics.OnResolutionChanged;
      if (resolutionChanged == null)
        return;
      resolutionChanged();
    }

    public static void Draw(
      Texture2D texture,
      Color color = default (Color),
      Microsoft.Xna.Framework.Vector2 position = default (Microsoft.Xna.Framework.Vector2),
      float rotation = 0.0f,
      Microsoft.Xna.Framework.Vector2 scale = default (Microsoft.Xna.Framework.Vector2),
      Microsoft.Xna.Framework.Vector2 origin = default (Microsoft.Xna.Framework.Vector2),
      float layerDepth = 0.0f)
    {
      JuicyChicken.Graphics.SpriteBatch.Draw(texture, position, new Rectangle?(), color, 
          MathHelper.ToRadians(rotation), origin, scale, SpriteEffects.None, layerDepth);
    }

    public static void ToggleFullscreen()
    {
      if (!JuicyChicken.Graphics.Manager.IsFullScreen)
      {
        JuicyChicken.Graphics.Manager.PreferredBackBufferWidth = 
                    (int) JuicyChicken.Graphics.DeviceResolution.X;
        JuicyChicken.Graphics.Manager.PreferredBackBufferHeight = 
                    (int) JuicyChicken.Graphics.DeviceResolution.Y;
        JuicyChicken.Graphics.Manager.IsFullScreen = true;
      }
      else
      {
        JuicyChicken.Graphics.Manager.PreferredBackBufferWidth = 
                    (int) JuicyChicken.Graphics.ReferenceResolution.X;
        JuicyChicken.Graphics.Manager.PreferredBackBufferHeight = 
                    (int) JuicyChicken.Graphics.ReferenceResolution.Y;
        JuicyChicken.Graphics.Manager.IsFullScreen = false;
      }
      JuicyChicken.Graphics.Manager.ApplyChanges();
      Action resolutionChanged = JuicyChicken.Graphics.OnResolutionChanged;
      if (resolutionChanged == null)
        return;
      resolutionChanged();
    }

    public static void FrameBufferWindow()
    {
      if (!JuicyChicken.Graphics.showBuffer)
        return;
      if (!ImGui.Begin("Frame buffer", ref JuicyChicken.Graphics.showBuffer))
      {
        ImGui.End();
      }
      else
      {
        ImGui.Image(new IntPtr(0), new System.Numerics.Vector2(ImGui.GetWindowWidth(), JuicyChicken.Graphics.CurrentResolution.Y * (ImGui.GetWindowWidth() / JuicyChicken.Graphics.CurrentResolution.X)));
        ImGui.End();
      }
    }

    public static void MenuItem() => ImGui.MenuItem("Frame Buffer", "", ref JuicyChicken.Graphics.showBuffer);
  }
}
