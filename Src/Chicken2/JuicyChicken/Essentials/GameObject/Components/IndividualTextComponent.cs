// Decompiled with JetBrains decompiler
// Type: JuicyChicken.IndividualTextComponent
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace JuicyChicken
{
  internal class IndividualTextComponent : Component
  {
    private Vector2 origin;
    private string text = "empty";
    private OriginPoint originPoint = OriginPoint.TopLeft;
    private CharacterData[] characters = new CharacterData[0];

    public string Text
    {
      get => this.text;
      set
      {
        this.text = value;
        this.SetAlignmentType();
        this.UpdateArray();
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

    public Vector2 Offset { get; set; }

    public float Spacing { get; set; } = 1f;

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

    private void UpdateArray()
    {
      Array.Resize<CharacterData>(ref this.characters, this.Text.Length);
    }

    public void SetCharacterOffset(int index, Vector2 offset)
    {
      if (index < 0 || index >= this.characters.Length)
        return;
      this.characters[index].Offset = offset;
    }

    public void SetCharacterColor(int index, Color color)
    {
      if (index < 0 || index >= this.characters.Length)
        return;
      this.characters[index].Color = color;
    }

    protected override void Draw(Space space)
    {
      if (this.Space != space)
        return;
      string text1 = "";
      for (int index = 0; index < this.Text.Length; ++index)
      {
        Vector2 vector2 = this.Font.MeasureString(text1) * this.Owner.Transform.Scale;
        string str1 = text1;
        char ch = this.Text[index];
        string str2 = ch.ToString();
        text1 = str1 + str2;
        SpriteBatch spriteBatch1 = JuicyChicken.Graphics.SpriteBatch;
        SpriteFont font1 = this.Font;
        ch = this.Text[index];
        string text2 = ch.ToString();
        Vector2 position1 = this.Owner.Transform.Position + this.Offset + Vector2.UnitX * this.Spacing + this.characters[index].Offset + Vector2.UnitX * vector2.X;
        Color color = this.characters[index].Color;
        double radians1 = (double) MathHelper.ToRadians(this.Owner.Transform.Rotation);
        Vector2 origin1 = this.origin;
        Vector2 scale1 = this.Owner.Transform.Scale + this.characters[index].Scale;
        double layerDepth1 = (double) Sprite.ConvertToLayerDepth(this.LayerDepth);
        spriteBatch1.DrawString(font1, text2, position1, color, (float) radians1, origin1, scale1, SpriteEffects.None, (float) layerDepth1);
        if (this.OutlineEnabled)
        {
          SpriteBatch spriteBatch2 = JuicyChicken.Graphics.SpriteBatch;
          SpriteFont font2 = this.Font;
          ch = this.Text[index];
          string text3 = ch.ToString();
          Vector2 position2 = this.Owner.Transform.Position + this.Offset + Vector2.UnitX * this.Spacing + this.characters[index].Offset + Vector2.UnitX * vector2.X + Vector2.One * this.Owner.Transform.Scale;
          Color outlineColor = this.OutlineColor;
          double radians2 = (double) MathHelper.ToRadians(this.Owner.Transform.Rotation);
          Vector2 origin2 = this.origin;
          Vector2 scale2 = this.Owner.Transform.Scale + this.characters[index].Scale;
          double layerDepth2 = (double) Sprite.ConvertToLayerDepth(this.LayerDepth - 1);
          spriteBatch2.DrawString(font2, text3, position2, outlineColor, (float) radians2, origin2, scale2, SpriteEffects.None, (float) layerDepth2);
        }
      }
    }

    public override void Reset()
    {
      this.text = (string) null;
      this.origin = new Vector2();
      this.OutlineColor = new Color();
      this.originPoint = OriginPoint.Center;
      this.OutlineEnabled = false;
      this.LayerDepth = 0;
      this.Space = Space.World;
      this.Font = (SpriteFont) null;
    }
  }
}
