// ChickenRemake.CreatePlayer

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public class CreatePlayer : Blueprint
  {
    protected override void Construct()
    {
      this.GameObject.Tag = "Player";
      this.GameObject.Layer = (Enum) ObjectLayer.Player;

      this.GameObject.AddComponent<InputHandler>();
      
      Player player = this.GameObject.AddComponent<Player>();
      PlayerVisual playerVisual = this.GameObject.AddComponent<PlayerVisual>();
      Collider collider = this.GameObject.AddComponent<Collider>();
      playerVisual.Setup();

      collider.Size = new Vector2(6f, 12f);
      collider.Offset = -new Vector2(0.0f, 5f);

      collider.OnCollisionEnter += new Action<CollisionData>(player.EnterCollision);
    }
  }
}
