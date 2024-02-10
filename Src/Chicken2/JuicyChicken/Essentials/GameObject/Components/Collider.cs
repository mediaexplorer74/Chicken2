// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Collider
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public class Collider : Component
  {
    private Vector2 size;
    private Vector2 center;
    private Dictionary<int, CollisionData> currentCollisions = new Dictionary<int, CollisionData>();
    private Texture2D debugTexture;
    private static List<Collider> colliders = new List<Collider>();
    private HashSet<Enum> blackList = new HashSet<Enum>();

    public Vector2 Size
    {
      get => this.size;
      set
      {
        if (this.size != value && this.DrawDebug)
          this.debugTexture = TextureGenerator.CreateBox((int) value.X, (int) value.Y, 1, Color.Transparent, Color.White);
        this.size = value;
      }
    }

    public Vector2 Offset
    {
      get => this.center;
      set => this.center = value;
    }

    public bool IsTrigger { get; set; }

    public float Width => this.Size.X;

    public float Height => this.Size.Y;

    public float Left => this.Position.X;

    public float Right => this.Position.X + this.Width;

    public float Top => this.Position.Y;

    public float Bottom => this.Position.Y + this.Height;

    public Vector2 Position
    {
      get
      {
        return this.Owner.Transform.Position - Vector2.UnitX * this.Width * 0.5f - Vector2.UnitY * this.Height * 0.5f + this.Offset;
      }
    }

    public bool IsColliding => this.currentCollisions.Count > 0;

    public bool DrawDebug { get; set; }

    public event Action<CollisionData> OnCollision;

    public event Action<CollisionData> OnCollisionEnter;

    public event Action<CollisionData> OnCollisionExit;

    private static event Action<int> OnRemoveCollider;

    public static List<Collider> GetColliders() => Collider.colliders;

    private static void Register(Collider collider) => Collider.colliders.Add(collider);

    private static void Deregister(Collider collider)
    {
      if (!Collider.colliders.Contains(collider))
        return;
      Collider.colliders.Remove(collider);
      Action<int> onRemoveCollider = Collider.OnRemoveCollider;
      if (onRemoveCollider == null)
        return;
      onRemoveCollider(collider.Index);
    }

    protected override void Start()
    {
      this.Size = Vector2.One * 100f;
      this.Offset = Vector2.Zero;
      Collider.Register(this);
      Collider.OnRemoveCollider += new Action<int>(this.TryRemoveCollision);
    }

    protected override void Update()
    {
      if (this.Owner == null || !this.Owner.IsActive || this.Owner.Static || !this.Enabled)
        return;
      this.DetectCollisions();
    }

    public void AddToBlackList(params Enum[] layers)
    {
      foreach (Enum layer in layers)
      {
        if (!this.blackList.Contains(layer))
          this.blackList.Add(layer);
      }
    }

    public void RemoveFromBlackList(params Enum[] layers)
    {
      foreach (Enum layer in layers)
      {
        if (this.blackList.Contains(layer))
          this.blackList.Remove(layer);
      }
    }

    private void DetectCollisions()
    {
      for (int index = 0; index < Collider.colliders.Count; ++index)
      {
        Collider collider = Collider.colliders[index];
        if (collider != this && collider.Owner != null && collider.Owner.IsActive && collider.Enabled && (collider.Owner.Layer == null || !this.blackList.Contains(collider.Owner.Layer)))
        {
          CollisionData data;
          if (this.Intersects(collider, out data))
          {
            Action<CollisionData> onCollision = this.OnCollision;
            if (onCollision != null)
              onCollision(data);
            this.TryAddCollision(data);
            if (!this.IsTrigger && !collider.IsTrigger)
              this.CounterTranslate(data);
          }
          else if (this.currentCollisions.ContainsKey(collider.Index))
            this.TryRemoveCollision(collider.Index);
        }
      }
    }

    private void TryAddCollision(CollisionData data)
    {
      if (this.currentCollisions.ContainsKey(data.Other.Index))
        return;
      this.currentCollisions.Add(data.Other.Index, data);
      Action<CollisionData> onCollisionEnter = this.OnCollisionEnter;
      if (onCollisionEnter == null)
        return;
      onCollisionEnter(data);
    }

    private void TryRemoveCollision(int index)
    {
      if (!this.currentCollisions.ContainsKey(index))
        return;
      this.currentCollisions.Remove(index);
      Action<CollisionData> onCollisionExit = this.OnCollisionExit;
      if (onCollisionExit == null)
        return;
      onCollisionExit(this.currentCollisions[index]);
    }

    public bool Intersects(Collider other, out CollisionData data)
    {
      if (this.Owner == null || other.Owner == null)
      {
        data = new CollisionData();
        return false;
      }
      if (((double) this.Position.X >= (double) other.Position.X + (double) other.Width || (double) this.Position.X + (double) this.Width <= (double) other.Position.X || (double) this.Position.Y >= (double) other.Position.Y + (double) other.Height ? 0 : ((double) this.Position.Y + (double) this.Height > (double) other.Position.Y ? 1 : 0)) != 0)
      {
        Side side = Side.Left;
        float num1 = this.Bottom - other.Position.Y;
        float num2 = other.Bottom - this.Position.Y;
        float num3 = this.Right - other.Position.X;
        float num4 = other.Right - this.Position.X;
        if ((double) num1 < (double) num2 && (double) num1 < (double) num3 && (double) num1 < (double) num4)
          side = Side.Top;
        if ((double) num2 < (double) num1 && (double) num2 < (double) num3 && (double) num2 < (double) num4)
          side = Side.Bottom;
        if ((double) num3 < (double) num4 && (double) num3 < (double) num1 && (double) num3 < (double) num2)
          side = Side.Left;
        if ((double) num4 < (double) num3 && (double) num4 < (double) num1 && (double) num4 < (double) num2)
          side = Side.Right;
        data = new CollisionData(this, other, side);
        return true;
      }
      data = new CollisionData();
      return false;
    }

    private void CounterTranslate(CollisionData data)
    {
      this.Owner.Transform.Position += data.Normal * data.Penetration;
    }

    protected override void Draw(Space space)
    {
      if (space != Space.World || !this.DrawDebug)
        return;
      JuicyChicken.Graphics.SpriteBatch.Draw(this.debugTexture, this.Position, new Rectangle?(), this.IsColliding ? Color.Red : Color.Lime, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
    }

    public override void Reset()
    {
      this.OnCollision = (Action<CollisionData>) null;
      this.OnCollisionEnter = (Action<CollisionData>) null;
      this.OnCollisionExit = (Action<CollisionData>) null;
      Collider.OnRemoveCollider -= new Action<int>(this.TryRemoveCollision);
      this.currentCollisions.Clear();
      Collider.Deregister(this);
    }
  }
}
