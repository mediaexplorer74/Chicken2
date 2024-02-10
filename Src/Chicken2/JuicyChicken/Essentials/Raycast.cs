// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Raycast
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public static class Raycast
  {
    public static bool Cast(
      Vector2 origin,
      Vector2 direction,
      float maxDistance,
      out Vector2 hitPoint,
      params Enum[] layers)
    {
      foreach (Vector2 vector2 in Raycast.GetLine(origin, origin + direction * maxDistance))
      {
        foreach (Collider collider1 in Collider.GetColliders())
        {
          Collider collider = collider1;
          if (layers != null)
          {
            bool isLayer = false;
            Array.ForEach<Enum>(layers, (Action<Enum>) (x => isLayer |= collider.Owner.CompareLayer(x)));
            if (!isLayer)
              continue;
          }
          if ((double) vector2.X > (double) collider.Left && (double) vector2.X < (double) collider.Right && (double) vector2.Y > (double) collider.Top && (double) vector2.Y < (double) collider.Bottom)
          {
            hitPoint = vector2;
            return true;
          }
        }
      }
      hitPoint = new Vector2();
      return false;
    }

    private static List<Vector2> GetLine(Vector2 from, Vector2 to)
    {
      List<Vector2> line = new List<Vector2>();
      int x = (int) from.X;
      int y = (int) from.Y;
      int num1 = (int) to.X - (int) from.X;
      int num2 = (int) to.Y - (int) from.Y;
      bool flag = false;
      int num3 = Math.Sign(num1);
      int num4 = Math.Sign(num2);
      int num5 = Math.Abs(num1);
      int num6 = Math.Abs(num2);
      if (num5 < num6)
      {
        flag = true;
        num5 = Math.Abs(num2);
        num6 = Math.Abs(num1);
        num3 = Math.Sign(num2);
        num4 = Math.Sign(num1);
      }
      int num7 = num5 / 2;
      for (int index = 0; index < num5; ++index)
      {
        line.Add(new Vector2((float) x, (float) y));
        if (flag)
          y += num3;
        else
          x += num3;
        num7 += num6;
        if (num7 >= num5)
        {
          if (flag)
            x += num4;
          else
            y += num4;
          num7 -= num5;
        }
      }
      return line;
    }
  }
}
