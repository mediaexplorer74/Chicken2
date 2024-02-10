// Decompiled with JetBrains decompiler
// Type: JuicyChicken.CollisionData
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace JuicyChicken
{
  public struct CollisionData
  {
    public Collider Other { get; private set; }

    public Side Side { get; private set; }

    public Vector2 Normal { get; private set; }

    public float Penetration { get; private set; }

    public CollisionData(Collider self, Collider other, Side side)
    {
      this.Other = other;
      this.Side = side;
      switch (side)
      {
        case Side.Right:
          this.Normal = Vector2.UnitX;
          this.Penetration = Math.Abs(self.Left - other.Right);
          break;
        case Side.Top:
          this.Normal = -Vector2.UnitY;
          this.Penetration = Math.Abs(self.Bottom - other.Top);
          break;
        case Side.Bottom:
          this.Normal = Vector2.UnitY;
          this.Penetration = Math.Abs(self.Top - other.Bottom);
          break;
        default:
          this.Normal = -Vector2.UnitX;
          this.Penetration = Math.Abs(self.Right - other.Left);
          break;
      }
    }
  }
}
