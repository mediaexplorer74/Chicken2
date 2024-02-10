// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Sprite
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace JuicyChicken
{
  public class Sprite : Component
  {
    private Texture2D texture;
    private OriginPoint originPoint;
    private Vector2 originPosition;
    private float opacity = 1f;
    private Texture2D colorMaskTexture;

    public Texture2D Texture
    {
      get => this.texture;
      set
      {
        this.texture = value;
        this.originPosition = this.texture.GetPoint(this.Origin);
      }
    }

    public int Layer { get; set; }

    public bool AutoLayer { get; set; }

    public OriginPoint Origin
    {
      get => this.originPoint;
      set
      {
        this.originPoint = value;
        if (this.texture == null)
          return;
        this.originPosition = this.texture.GetPoint(this.originPoint);
      }
    }

    public Vector2 Offset { get; set; }

    public SpriteEffects FlipMode { get; set; }

    public float Opacity
        {
            get => this.opacity;
            set
            {
                // Math.Clamp(value, 0.0f, 1f) emu
                var clamp = value;
                if (value > 1f)
                    clamp = 1f;
                if (value < 0.0f)
                    clamp = 0.0f;

                this.opacity = clamp;//Math.Clamp(value, 0.0f, 1f);
            }
        }

        public Color ColorMask { get; set; }

    public Space Space { get; set; }

    protected override void Update()
    {
      this.Layer = this.AutoLayer ? (int) this.Owner.Transform.Position.Y - (int) this.Offset.Y : this.Layer;
    }

    protected override void Draw(Space space)
    {
      if (this.Texture == null || this.Space != space)
        return;
      float layerDepth = Sprite.ConvertToLayerDepth(this.Layer);
      JuicyChicken.Graphics.SpriteBatch.Draw(this.Texture, this.Owner.Transform.Position + this.Offset, new Rectangle?(), Color.White * this.Opacity, MathHelper.ToRadians(this.Owner.Transform.Rotation), this.originPosition, this.Owner.Transform.Scale, this.FlipMode, layerDepth);
      if ((double) this.ColorMask.A <= 0.0099999997764825821)
        return;
      if (this.colorMaskTexture == null)
        this.colorMaskTexture = new Texture2D(JuicyChicken.Graphics.Device, this.Texture.Width, this.Texture.Height);
      Color[] data = new Color[this.colorMaskTexture.Width * this.colorMaskTexture.Height];
      this.Texture.GetData<Color>(data);
      this.colorMaskTexture.SetData<Color>(data);
      this.colorMaskTexture.GetData<Color>(data);
      for (int index = 0; index < data.Length; ++index)
      {
        if ((double) data[index].A > 0.0)
          data[index] = this.ColorMask;
      }
      this.colorMaskTexture.SetData<Color>(data);
      JuicyChicken.Graphics.SpriteBatch.Draw(this.colorMaskTexture, this.Owner.Transform.Position + this.Offset, new Rectangle?(), this.ColorMask, MathHelper.ToRadians(this.Owner.Transform.Rotation), this.originPosition, this.Owner.Transform.Scale, this.FlipMode, Sprite.ConvertToLayerDepth(this.Layer + 1));
    }

    public override void Reset()
    {
      this.Texture = (Texture2D) null;
      this.Layer = 0;
      this.AutoLayer = false;
      this.Origin = OriginPoint.Center;
      this.Offset = Vector2.Zero;
      this.FlipMode = SpriteEffects.None;
      this.Opacity = 1f;
      this.ColorMask = Color.Transparent;
      this.Space = Space.World;
    }

    public static float ConvertToLayerDepth(int layer)
    {
      return (float) ((double) layer / 1999998.0 + 0.5);
    }
  }
}
