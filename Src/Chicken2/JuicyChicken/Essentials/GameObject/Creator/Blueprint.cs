// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Blueprint
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;

#nullable disable
namespace JuicyChicken
{
  public abstract class Blueprint
  {
    public GameObject GameObject { get; private set; }

    public static T Spawn<T>(Vector2 position = default (Vector2), float rotation = 0.0f, Vector2 scale = default (Vector2), GameObject parent = null) where T : Blueprint, new()
    {
      T obj = new T();
      obj.GameObject = GameObject.Spawn(position, rotation, scale == new Vector2() ? Vector2.One : scale, parent);
      obj.Construct();
      return obj;
    }

    protected abstract void Construct();
  }
}
