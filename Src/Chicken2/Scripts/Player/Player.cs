// ChickenRemake.Player

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace ChickenRemake
{
  public class Player : Component
  {
    private IBehaviour<Player> currentBehaviour;
    private bool isGrounded;
    private Vector2 velocity;
    private Collider collider;

    public Vector2 Velocity
    {
      get => this.velocity;
      set => this.velocity = value;
    }

    public bool IsGrounded
    {
        get
        {
            return this.isGrounded;
        }
    }

    public IBehaviour<Player> CurrentBehaviour
    {
        get
        {
            return this.currentBehaviour;
        }
    }

    public event Action OnGroundEnter;

    public event Action OnGroundExit;

    protected override void Start()
    {
      this.SetBehaviour<PlayerDefaultBehaviour>();
      Camera.Target = new Vector2(5f, 0.0f);
    }

    protected override void Update()
    {
        
        Camera.Target = Vector2.Clamp(Vector2.Lerp(Camera.Target, new Vector2(5f,
           (double) this.Transform.Position.Y < -50.0 ? this.Transform.Position.Y + 5f : 10f), 
           2f * Time.DeltaTime), new Vector2(0.0f, -75f), new Vector2(10f, -15f));
       // Camera.Target = new Vector2(5f, 0.0f);
            

      this.currentBehaviour?.Update();

      this.GroundDetection();

      //RnD
      this.Transform.Translate(this.velocity * Time.DeltaTime);

      if ((double)this.Transform.Position.X < 0.0)
      {
        System.Diagnostics.Debug.WriteLine((double)this.Transform.Position.X);
        this.Transform.Translate(Vector2.UnitX * 6f * Time.DeltaTime);
      }

            if ((double)this.Transform.Position.Y <= 300.0
                      && (double)this.Transform.Position.X >
                        -(double)Graphics.CurrentResolution.X / 2.0 / (double)Camera.Zoom)
            {
                return;                
            }

            // Game over :)
            this.Kill();

            //RnD
            //if ((double)this.Transform.Position.X <= 0.0)
            //    this.Transform.Translate(Vector2.UnitX * 6f * Time.DeltaTime);

            //RnD
             Camera.Target = Vector2.Clamp(Vector2.Lerp(Camera.Target, new Vector2(5f,
            (double)this.Transform.Position.Y < -50.0 + 50 ? this.Transform.Position.Y + 5f : 10f + 50),
            2f * Time.DeltaTime), new Vector2(10f, -15f), new Vector2(0.0f, -75f) );

            //Camera.Target = new Vector2(5f, 0.0f);
            
            this.currentBehaviour?.Update();

            this.GroundDetection();
            this.Transform.Translate(this.velocity * Time.DeltaTime);

            if ((double)this.Transform.Position.X < 0.0)
                this.Transform.Translate(Vector2.UnitX * 6f * Time.DeltaTime);
            this.SetBehaviour<PlayerDefaultBehaviour>();
            Camera.Target = new Vector2(5f, 0.0f);
            
        }

    public void Kill()
    {
        StateManager.SetState<GameoverState>();
    }

    public void SetBehaviour<T>() where T : IBehaviour<Player>, new()
    {
      if (this.currentBehaviour != null)
        this.currentBehaviour.Exit();
      T obj = new T();
      obj.Target = this;
      obj.Start();
      this.currentBehaviour = (IBehaviour<Player>) obj;
    }

    public void EnterCollision(CollisionData collision)
    {
      ICollectable component;
      if (collision.Other.Owner.TryGetComponent<ICollectable>(out component))
      {
        component.Collect(this);
      }
      else
      {
        if (collision.Side != Side.Bottom || !collision.Other.Owner.CompareTag("Ground"))
          return;

        this.velocity = new Vector2(this.velocity.X, -10f);
    
      }
    }

    private void GroundDetection()
    {
      if (this.collider == null)
      {
        this.collider = this.Owner.GetComponent<Collider>();
      }
      else
      {
        bool isGrounded = this.isGrounded;
        this.isGrounded = Raycast.Cast(this.Transform.Position
            - Vector2.UnitX * this.collider.Size.X * 0.5f, Vector2.UnitY, 
            3f, out Vector2 _, (Enum) ObjectLayer.Ground)
                    & Raycast.Cast(this.Transform.Position + Vector2.UnitX 
                    * this.collider.Size.X * 0.5f, Vector2.UnitY, 
                    3f, out Vector2 _, (Enum) ObjectLayer.Ground);

        if (isGrounded && !this.isGrounded)
        {
          Action onGroundExit = this.OnGroundExit;
          if (onGroundExit == null)
            return;

          onGroundExit();
        }
        else
        {
          if (isGrounded || !this.isGrounded)
            return;
          Action onGroundEnter = this.OnGroundEnter;
          if (onGroundEnter == null)
            return;

          onGroundEnter();
        }
      }
    }

    public override void Reset()
    {
      this.OnGroundEnter = (Action) null;
      this.OnGroundExit = (Action) null;
      this.currentBehaviour = (IBehaviour<Player>) null;
      this.collider = (Collider) null;
    }
  }
}
