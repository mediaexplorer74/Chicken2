// MGUI.MonoUI.DrawVertDeclaration


using ImGuiNET;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace MGUI.MonoUI
{
  public static class DrawVertDeclaration
  {
    public static readonly VertexDeclaration Declaration;

    //RnD
    public static readonly int Size = 200;//sizeof (ImDrawVert);

    static DrawVertDeclaration()
    {
      DrawVertDeclaration.Declaration = 
                new VertexDeclaration(DrawVertDeclaration.Size, new VertexElement[3]
      {
        new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),
        new VertexElement(8, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
        new VertexElement(16, VertexElementFormat.Color, VertexElementUsage.Color, 0)
      });
    }
  }
}
