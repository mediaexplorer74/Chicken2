// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Line
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;

#nullable disable
namespace JuicyChicken
{
  internal struct Line
  {
    public string Text { get; set; }

    public Color LineColor { get; set; }

    public Line(string s, Color c)
    {
      this.Text = s;
      this.LineColor = c;
    }
  }
}
