// Decompiled with JetBrains decompiler
// Type: JuicyChicken.CharacterData
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;

#nullable disable
namespace JuicyChicken
{
  public struct CharacterData
  {
    private Vector2 offset;
    private Vector2 scale;
    private Color color;

    public Vector2 Offset
    {
      get => this.offset;
      set => this.offset = value;
    }

    public Vector2 Scale
    {
      get => this.scale;
      set => this.scale = value;
    }

    public Color Color
    {
      get => this.color;
      set => this.color = value;
    }

    public CharacterData(Vector2 offset, Vector2 scale, Color color)
    {
      this.offset = offset;
      this.scale = scale;
      this.color = color;
    }
  }
}
