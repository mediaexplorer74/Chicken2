// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Animation
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public struct Animation
  {
    private Texture2D[] frames;
    private int framesPerSecond;
    private bool loop;

    public Texture2D[] Frames => this.frames;

    public int FramesPerSecond => this.framesPerSecond;

    public bool Loop => this.loop;

    public Animation(
      Texture2D spriteSheet,
      int frameCountX,
      int frameCountY,
      int cellWidth,
      int cellHeight,
      int framesPerSecond,
      bool loop)
    {
      this.frames = new Texture2D[0];
      this.framesPerSecond = framesPerSecond;
      this.loop = loop;
      List<Texture2D> texture2DList = new List<Texture2D>();
      for (int yIndex = 0; yIndex < spriteSheet.Height / cellHeight; ++yIndex)
      {
        for (int xIndex = 0; xIndex < spriteSheet.Width / cellWidth; ++xIndex)
        {
          Texture2D frame = spriteSheet.Slice(xIndex, yIndex, cellWidth, cellHeight);
          if (!this.EmptyFrame(frame))
            texture2DList.Add(frame);
        }
      }
      this.frames = new Texture2D[texture2DList.Count];
      for (int index = 0; index < texture2DList.Count; ++index)
        this.frames[index] = texture2DList[index];
    }

    public Animation(int framesPerSecond, bool loop, params Texture2D[] textures)
    {
      this.frames = textures;
      this.framesPerSecond = framesPerSecond;
      this.loop = loop;
    }

    private bool EmptyFrame(Texture2D frame)
    {
      Color[] data = new Color[frame.Width * frame.Height];
      frame.GetData<Color>(data);
      for (int index = 0; index < data.Length; ++index)
      {
        if (data[index].A != (byte) 0)
          return false;
      }
      return true;
    }
  }
}
