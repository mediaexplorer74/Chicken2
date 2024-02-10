// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Transform
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace JuicyChicken
{
  public class Transform
  {
    private GameObject gameObject;
    private Texture2D debugTexture;
    private Matrix worldMatrix;
    private Matrix inverseWorldMatrix;
    private Matrix localMatrix;
    private Vector2 position;
    private float rotation;
    private Vector2 scale;
    private Vector2 localPosition;
    private float localRotation;
    private Vector2 localScale;
    private bool pendingLocalUpdate;
    private bool pendingWorldUpdate;

    public Matrix LocalMatrix
    {
        get
        {
            return this.UpdateLocalMatrixAndReturn<Matrix>(ref this.worldMatrix);
        }
    }

    public Matrix WorldMatrix
    {
        get
        {
            return this.UpdateWorldMatrixAndReturn<Matrix>(ref this.worldMatrix);
        }
    }

    public Matrix InverseWorldMatrix
    {
      get => this.UpdateWorldMatrixAndReturn<Matrix>(ref this.inverseWorldMatrix);
    }

    public bool UseRelativePosition { get; set; } = true;

    public bool UseRelativeRotation { get; set; } = true;

    public bool UseRelativeScale { get; set; } = true;

    public Vector2 InitialPosition { get; private set; }

    public float InitialRotation { get; private set; }

    public Vector2 InitialScale { get; private set; }

    public Vector2 Position
    {
      get
      {
        return !this.UseRelativePosition
                    ? this.localPosition
                    : this.UpdateWorldMatrixAndReturn<Vector2>(ref this.position);
      }
      set => this.LocalPosition = value;
    }

    public float Rotation
    {
      get
      {
        return !this.UseRelativeRotation 
                    ? this.localRotation
                    : this.UpdateWorldMatrixAndReturn<float>(ref this.rotation);
      }
      set => this.LocalRotation = value;
    }

    public Vector2 Scale
    {
      get
      {
        return !this.UseRelativeScale
                    ? this.localScale
                    : this.UpdateWorldMatrixAndReturn<Vector2>(ref this.scale);
      }
      set => this.LocalScale = value;
    }

    public Vector2 LocalPosition
    {
      get => this.localPosition;
      set
      {
        if (!(this.localPosition != value))
          return;

        this.localPosition = value;

        this.RequestLocalUpdate();
      }
    }


    public float LocalRotation
    {
      get => this.localRotation;
      set
      {
        if ((double) this.localRotation == (double) value)
          return;
        this.localRotation = value;
        this.RequestLocalUpdate();
      }
    }

    public Vector2 LocalScale
    {
      get => this.localScale;
      set
      {
        if (!(this.localScale != value))
          return;
        this.localScale = value;
        this.RequestLocalUpdate();
      }
    }

    public Vector2 Right
    {
      get
      {
        Vector2 right = new Vector2
        (
            (float)Math.Cos(MathHelper.ToRadians(this.Rotation)), 
            (float)Math.Sin(MathHelper.ToRadians(this.Rotation))
        );

        if ((double) right.Length() != 0.0)
          right.Normalize();

        return right;
      }
    }

    public Vector2 Up
    {
      get
      {
        Vector2 up = new Vector2
        (
            (float)Math.Sin(MathHelper.ToRadians(this.Rotation)), 
            (float) -Math.Cos(MathHelper.ToRadians(this.Rotation))
        );
        
        if ((double) up.Length() != 0.0)
          up.Normalize();

        return up;
      }
    }

    public Transform(GameObject gameObject, Vector2 position, float rotation, Vector2 scale)
    {
      this.gameObject = gameObject;
      this.Position = position;
      this.Rotation = rotation;
      this.Scale = scale;
      this.InitialPosition = position;
      this.InitialRotation = rotation;
      this.InitialScale = scale;
    }

    public void ToLocalPosition(ref Vector2 world, out Vector2 local)
    {
      Vector2.Transform(ref world, ref this.inverseWorldMatrix, out local);
    }

    public void ToWorldPosition(ref Vector2 local, out Vector2 world)
    {
      Vector2.Transform(ref local, ref this.worldMatrix, out world);
    }

    public Vector2 ToWorldPosition(Vector2 local) => Vector2.Transform(local, this.worldMatrix);

    private void RequestLocalUpdate()
    {
      this.pendingLocalUpdate = true;
      this.RequestWorldUpdate();
    }

    private void RequestWorldUpdate()
    {
      this.pendingWorldUpdate = true;
      for (int index = 0; index < this.gameObject.ChildCount; ++index)
        this.gameObject.GetChild(index).Transform.RequestWorldUpdate();
    }

    private void UpdateLocalMatrix()
    {
      this.localMatrix = Matrix.CreateScale(this.localScale.X, this.localScale.Y, 1f) 
                * Matrix.CreateRotationZ(MathHelper.ToRadians(this.localRotation))
                * Matrix.CreateTranslation(this.localPosition.X, this.localPosition.Y, 0.0f);
      this.pendingLocalUpdate = false;
    }

    private void UpdateWorldMatrix()
    {
      if (!this.gameObject.IsChild)
      {
        this.worldMatrix = this.localMatrix;
        this.scale = this.localScale;
        this.rotation = this.localRotation;
        this.position = this.localPosition;
      }
      else
      {
        Matrix worldMatrix = this.gameObject.Parent.Transform.WorldMatrix;
        Matrix.Multiply(ref this.localMatrix, ref worldMatrix, out this.worldMatrix);
        this.scale = this.gameObject.Parent.Transform.Scale * this.localScale;
        this.rotation = this.gameObject.Parent.Transform.Rotation + this.localRotation;
        this.position = Vector2.Zero;
        this.ToWorldPosition(ref this.position, out this.position);
      }
      Matrix.Invert(ref this.worldMatrix, out this.inverseWorldMatrix);
      this.pendingWorldUpdate = false;
    }

    private T UpdateLocalMatrixAndReturn<T>(ref T field)
    {
      if (this.pendingLocalUpdate)
        this.UpdateLocalMatrix();

      return field;
    }

    private T UpdateWorldMatrixAndReturn<T>(ref T field)
    {
      if (this.pendingLocalUpdate)
        this.UpdateLocalMatrix();

      if (this.pendingWorldUpdate)
        this.UpdateWorldMatrix();
      return field;
    }

    public void Translate(Vector2 direction) => this.Position += direction;

    public void Rotate(float angle) => this.Rotation += angle;

    public void ClampPosition(Vector2 minValue, Vector2 maxValue)
    {
      this.ClampX(minValue.X, maxValue.X);
      this.ClampY(minValue.Y, maxValue.Y);
    }

    public void ClampX(float minValue, float maxValue)
    {
      this.Position = new Vector2(MathHelper.Clamp(this.Position.X, minValue, maxValue),
          this.Position.Y);
    }

    public void ClampY(float minValue, float maxValue)
    {
      this.Position = new Vector2(this.Position.X, 
          MathHelper.Clamp(this.Position.Y, minValue, maxValue));
    }

    public void LookAt(Vector2 target)
    {
      Vector2 vector2 = target - this.Position;
      this.Rotation = MathHelper.ToDegrees(
          (float) Math.Atan2((double) vector2.Y, 
          (double) vector2.X));
    }

    public float GetLookRotation(Vector2 target)
    {
      Vector2 vector2 = target - this.Position;
      return MathHelper.ToDegrees((float) Math.Atan2((double) vector2.Y, (double) vector2.X));
    }

    public Vector2 GetLookDirection(Vector2 target)
    {
      float radians = MathHelper.ToRadians(this.GetLookRotation(target));
      return new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians));
    }

    public void DrawDebug(Space space)
    {
      if (space != Space.World)
        return;
      if (this.debugTexture == null)
      {
        int width = 1;
        int height = 1;
        this.debugTexture = new Texture2D(JuicyChicken.Graphics.Device, width, height);
        Color[] data = new Color[width * height];
        for (int index = 0; index < data.Length; ++index)
          data[index] = Color.White;
        this.debugTexture.SetData<Color>(data);
      }
      JuicyChicken.Graphics.SpriteBatch.Draw(this.debugTexture, 
          this.Position, new Rectangle?(), Color.Red,
          MathHelper.ToRadians(this.GetLookRotation(this.Position + this.Right)),
          Vector2.Zero, Vector2.One + Vector2.UnitX * 8f, SpriteEffects.None, 1f);

      JuicyChicken.Graphics.SpriteBatch.Draw(this.debugTexture,
          this.Position, new Rectangle?(), Color.LightGreen, 
          MathHelper.ToRadians(this.GetLookRotation(this.Position + this.Up)),
          Vector2.Zero, Vector2.One + Vector2.UnitX * 8f, SpriteEffects.None, 1f);

      DefaultInterpolatedStringHandler interpolatedStringHandler =
                new DefaultInterpolatedStringHandler(8, 2);

      interpolatedStringHandler.AppendLiteral("X:");
      interpolatedStringHandler.AppendFormatted<double>(Math.Round((double) this.position.X, 1));
      interpolatedStringHandler.AppendLiteral(" - Y: ");
      interpolatedStringHandler.AppendFormatted<double>(Math.Round((double) this.position.Y, 1));
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();

      JuicyChicken.Graphics.SpriteBatch.DrawString(Content.GetFont("consolefont"), 
          stringAndClear, this.position, Color.Red, 0.0f, Vector2.Zero, 0.4f,
          SpriteEffects.None, 1f);
    }
  }
}
