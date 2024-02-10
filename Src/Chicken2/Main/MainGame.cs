// ChickenRemake.MainGame

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

#nullable disable
namespace ChickenRemake
{
  public class MainGame : Game
  {
    private Stopwatch stopwatch;

    public MainGame()
    {
      this.stopwatch = new Stopwatch();
      this.stopwatch.Start();
      JuicyChicken.Graphics.Initialize((Game) this, /*1280*/1024, /*800*/768);
      Input.Initialize(this.Window);
      this.IsFixedTimeStep = false;
      this.IsMouseVisible = true;
      this.Window.Title = "Chicken? 2";
      this.Deactivated += (EventHandler<EventArgs>) ((sender, args) =>
      {
        if (!(StateManager.CurrentState is IngameState))
          return;
        StateManager.SetState<PauseState>();
      });
    }

    protected override void LoadContent()
    {
      string currentDirectory = Directory.GetCurrentDirectory();
      
      JuicyChicken.Content.Load(this.Content, Path.Combine(currentDirectory, "Content", "Textures"), 
          Path.Combine(currentDirectory, "Content", "Audio"), Path.Combine(currentDirectory, 
          "Content", "Fonts"), Path.Combine(currentDirectory, "Content", "Effects"));

      PaletteLoader.LoadPalette(JuicyChicken.Content.GetTexture("endesga32"));
      DebugConsole.Initialize();
      PlayerSkin.Initialize();

      //RnD
      SQL.Initialize();
      SQL.VerifyUser(Database.CurrentUser);

      Database.BlockingLoad();
      Stats.Initialize();
      Camera.Zoom = 5f;
      Camera.Target = new Vector2(5f, -15f);
      
      this.stopwatch.Stop();

      DefaultInterpolatedStringHandler interpolatedStringHandler 
                = new DefaultInterpolatedStringHandler(17, 1);
      interpolatedStringHandler.AppendLiteral("Game loaded in ");
      interpolatedStringHandler.AppendFormatted<long>(this.stopwatch.ElapsedMilliseconds);
      interpolatedStringHandler.AppendLiteral("ms");
      JuicyChicken.Debug.Log<string>(interpolatedStringHandler.ToStringAndClear(), 
          JuicyChicken.Debug.SuccesColor);
      JuicyChicken.Graphics.ClearColor = Color.LightBlue;
      StateManager.SetState<MainMenuState>();
    }

    protected override void Update(GameTime gameTime)
    {
        GameLoop.InvokeUpdate(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GameLoop.InvokeDraw(BlendState.AlphaBlend, SamplerState.PointClamp);
    }
  }
}
