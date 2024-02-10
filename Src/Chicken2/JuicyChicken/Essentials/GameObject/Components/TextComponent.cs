// Decompiled with JetBrains decompiler
// Type: JuicyChicken.TextComponent
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace JuicyChicken
{
  public class TextComponent : Component
  {
    private Vector2 origin;
    private OriginPoint originPoint = OriginPoint.Top;
    private string text = "empty";
    private Vector2 scale;
    private Vector2 position;
    private Vector2 outlinePosition;
    private ModValue bindingValue;

    public string Text
    {
      get => this.text;
      set
      {
        this.text = value;
        this.SetAlignmentType();
      }
    }

    public OriginPoint Origin
    {
      get => this.originPoint;
      set
      {
        this.originPoint = value;
        this.SetAlignmentType();
      }
    }

    public Vector2 Offset { get; set; } = Vector2.Zero;

    public Vector2 ScaleModifier { get; set; } = Vector2.One;

    public Color Color { get; set; } = Color.White;

    public Color OutlineColor { get; set; } = Color.Black;

    public bool OutlineEnabled { get; set; } = true;

    public SpriteFont Font { get; set; } = Content.GetFont("font");

    public int LayerDepth { get; set; } = 10;

    public Space Space { get; set; } = Space.Screen;

    private void SetAlignmentType()
    {
      if (this.Font == null || this.Text == null)
        return;
      Vector2 vector2 = this.Font.MeasureString(this.text);
      switch (this.Origin)
      {
        case OriginPoint.Center:
          this.origin = vector2 / 2f;
          break;
        case OriginPoint.Top:
          this.origin = new Vector2(vector2.X / 2f, 0.0f);
          break;
        case OriginPoint.Bottom:
          this.origin = new Vector2(vector2.X / 2f, vector2.Y);
          break;
        case OriginPoint.Left:
          this.origin = new Vector2(0.0f, vector2.Y / 2f);
          break;
        case OriginPoint.Right:
          this.origin = new Vector2(vector2.X, vector2.Y / 2f);
          break;
        case OriginPoint.TopLeft:
          this.origin = Vector2.Zero;
          break;
        case OriginPoint.TopRight:
          this.origin = new Vector2(vector2.X, 0.0f);
          break;
        case OriginPoint.BottomLeft:
          this.origin = new Vector2(0.0f, vector2.Y);
          break;
        case OriginPoint.BottomRight:
          this.origin = vector2;
          break;
      }
    }

    public void BindValue(ModValue value) => this.bindingValue = value;

    public void Unbind() => this.bindingValue = (ModValue) null;

    protected override void Draw(Space space)
    {
      if (this.Space != space)
        return;
      if (this.Space == Space.Screen)
      {
        this.scale = this.Owner.Transform.Scale;
        this.position = this.Owner.Transform.Position + this.Offset;
        this.outlinePosition = this.Owner.Transform.Position + this.Offset + this.scale * this.ScaleModifier;
      }
      else if (this.Space == Space.World)
      {
        this.scale = this.Owner.Transform.Scale / Camera.Zoom;
        this.position = Camera.ScreenToWorld(this.Owner.Transform.Position + this.Offset);
        this.outlinePosition = Camera.ScreenToWorld(this.Owner.Transform.Position + this.Offset) + Vector2.One * this.scale * this.ScaleModifier;
      }
      if (this.bindingValue != null)
      {
        this.text = this.bindingValue.Value.ToString();
        Debug.Log<float>(this.bindingValue.Value);
      }
      JuicyChicken.Graphics.SpriteBatch.DrawString(this.Font, this.Text, this.position, this.Color, MathHelper.ToRadians(this.Owner.Transform.Rotation), this.origin, this.scale * this.ScaleModifier, SpriteEffects.None, Sprite.ConvertToLayerDepth(this.LayerDepth));
      if (!this.OutlineEnabled || !(this.OutlineColor != Color.Transparent))
        return;
      JuicyChicken.Graphics.SpriteBatch.DrawString(this.Font, this.Text, this.outlinePosition, this.OutlineColor, MathHelper.ToRadians(this.Owner.Transform.Rotation), this.origin, this.scale * this.ScaleModifier, SpriteEffects.None, Sprite.ConvertToLayerDepth(this.LayerDepth - 1));
    }

    public override void Reset()
    {
      this.text = (string) null;
      this.origin = new Vector2();
      this.Offset = new Vector2();
      this.Color = new Color();
      this.OutlineColor = new Color();
      this.outlinePosition = new Vector2();
      this.scale = new Vector2();
      this.position = new Vector2();
      this.OutlineEnabled = false;
      this.LayerDepth = 0;
      this.Space = Space.World;
      this.bindingValue = (ModValue) null;
      this.Font = Content.GetFont("font");
    }
  }
}
