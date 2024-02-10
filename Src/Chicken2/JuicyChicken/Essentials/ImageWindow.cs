// JuicyChicken.ImageWindow

using System;
using System.Numerics;

#nullable disable
namespace JuicyChicken
{
  public class ImageWindow
  {
    public IntPtr pointer;
    public string key;
    public Vector2 size;

    public ImageWindow(IntPtr pointer, string key, Vector2 size)
    {
      this.pointer = pointer;
      this.key = key;
      this.size = size;
    }
  }
}
