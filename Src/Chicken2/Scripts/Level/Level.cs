// Decompiled with JetBrains decompiler
// Type: ChickenRemake.Level
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace ChickenRemake
{
  public class Level : Component
  {
    private Texture2D front;
    private Texture2D mid;
    private Texture2D back;
    private Texture2D totallyBack;
    private Texture2D backdrop;
    private float scroll;

    public static Level Instance { get; private set; }

    public Func<CreateObstacle>[] ObstacleActions { get; set; }

    public EventSpawner EventSpawner { get; set; }

    public ChunkSpawner ChunkSpawner { get; set; }

    public float Speed { get; set; } = 100f;

    public void SetBackground(
      Texture2D front,
      Texture2D mid,
      Texture2D back,
      Texture2D totallyBack,
      Texture2D backdrop)
    {
      this.front = front;
      this.mid = mid;
      this.back = back;
      this.totallyBack = totallyBack;
      this.backdrop = backdrop;
    }

    protected override void Start()
    {
      if (Level.Instance != null)
        GameObject.Despawn(this.Owner);
      else
        Level.Instance = this;
    }

    protected override void Update()
    {
      this.Speed += 0.7f * Time.DeltaTime;
      Stats.IngameDistance += (float) ((double) this.Speed * (double) Time.DeltaTime / 32.0);
    }

    protected override void Draw(Space space)
    {
      if (space != Space.WrappedWorld)
        return;
      this.scroll += this.Speed * 0.75f * Time.DeltaTime;
      JuicyChicken.Graphics.SpriteBatch.Draw(this.front, new Rectangle(0, 25, (int) ((double) JuicyChicken.Graphics.CurrentResolution.X * 2.0 / (double) Camera.Zoom), (int) ((double) JuicyChicken.Graphics.CurrentResolution.Y / (double) Camera.Zoom)), new Rectangle?(new Rectangle((int) ((double) this.scroll * 0.699999988079071), 0, this.front.Width * 2, this.front.Height)), Color.White, 0.0f, this.front.GetPoint(OriginPoint.Center), SpriteEffects.None, 1f);
      JuicyChicken.Graphics.SpriteBatch.Draw(this.mid, new Rectangle(0, -20, (int) ((double) JuicyChicken.Graphics.CurrentResolution.X * 2.0 / (double) Camera.Zoom), (int) ((double) JuicyChicken.Graphics.CurrentResolution.Y / (double) Camera.Zoom)), new Rectangle?(new Rectangle((int) ((double) this.scroll * 0.5), 0, this.mid.Width * 2, this.mid.Height)), Color.White, 0.0f, this.mid.GetPoint(OriginPoint.Center), SpriteEffects.None, 0.9f);
      JuicyChicken.Graphics.SpriteBatch.Draw(this.back, new Rectangle(0, -20, (int) ((double) JuicyChicken.Graphics.CurrentResolution.X * 2.0 / (double) Camera.Zoom), (int) ((double) JuicyChicken.Graphics.CurrentResolution.Y / (double) Camera.Zoom)), new Rectangle?(new Rectangle((int) ((double) this.scroll * 0.30000001192092896), 0, this.back.Width * 2, this.back.Height)), Color.White, 0.0f, this.back.GetPoint(OriginPoint.Center), SpriteEffects.None, 0.8f);
      JuicyChicken.Graphics.SpriteBatch.Draw(this.totallyBack, new Rectangle(0, -20, (int) ((double) JuicyChicken.Graphics.CurrentResolution.X * 2.0 / (double) Camera.Zoom), (int) ((double) JuicyChicken.Graphics.CurrentResolution.Y / (double) Camera.Zoom)), new Rectangle?(new Rectangle((int) ((double) this.scroll * 0.15000000596046448), 0, this.totallyBack.Width * 2, this.totallyBack.Height)), Color.White, 0.0f, this.totallyBack.GetPoint(OriginPoint.Center), SpriteEffects.None, 0.7f);
    }

    public override void Reset() => Level.Instance = (Level) null;
  }
}
