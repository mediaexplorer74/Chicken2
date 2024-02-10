// ChickenRemake.PlayerDefaultBehaviour

using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace ChickenRemake
{
  public class PlayerDefaultBehaviour : IBehaviour<Player>
  {
    private ModValue jumpHeight = new ModValue(190f);
    private Vector2 gravity = new Vector2(0.0f, 420f);
    private bool jumpHeld;
    private const float FallMultiplier = 2.5f;
    private const float LowJumpMultiplier = 2f;

    public Player Target { get; set; }

    public int CurrentJumpAmount { get; set; }

    public int MaxJumpAmount { get; set; } = 1;

    public bool JumpDown { get; set; }

    public bool UseGravity { get; set; } = true;

    public void Start()
    {
      this.CurrentJumpAmount = this.MaxJumpAmount;
      InputHandler component = this.Target.Owner.GetComponent<InputHandler>();
      KeyAction keyAction = component.AddKeyAction(Keys.Space, 1f);
      PadAction padAction = component.AddPadAction(Buttons.A, 1f);
      padAction.OnDownEvent += new Action(this.Jump);
      keyAction.OnDownEvent += new Action(this.Jump);
      padAction.OnUpEvent += (Action) (() => this.jumpHeld = false);
      keyAction.OnUpEvent += (Action) (() => this.jumpHeld = false);
     
      this.Target.OnGroundEnter += (Action) (() =>
      {
        this.Target.Velocity = new Vector2(this.Target.Velocity.X, 0.0f);
        this.CurrentJumpAmount = this.MaxJumpAmount;
        this.Target.Transform.Scale = new Vector2(this.Target.Transform.Scale.X, 0.15f);
        Audio.Play("Hit", 0.07f, new Vector2(0.1f, 0.2f));
      });

      this.Target.Velocity = new Vector2(this.Target.Velocity.X, 0.0f);
    }

    public void Update()
    {
      if (!this.Target.IsGrounded)
        this.ApplyGravity();
      this.Target.Velocity = 
                Vector2.Lerp(this.Target.Velocity, 
                new Vector2(0.0f, this.Target.Velocity.Y), 
                10f * Time.DeltaTime);
    }

    public void Jump()
    {
      this.jumpHeld = true;
      if (this.CurrentJumpAmount <= 0)
        return;
      Audio.Play("jump", 0.4f, new Vector2(0.2f, 0.5f));
      Animation animation;

        if (GameObject.Find((Predicate<GameObject>)(x => x.Tag == "animContainer"))
                    .GetComponent<AnimationContainer>().GetAnimation("jump", out animation))
        {
            Blueprint.Spawn<CreateBasicParticle>(
                this.Target.Transform.Position, scale: Vector2.One * 1f).StartAnimation(animation);
        }

      this.Target.Transform.Scale = new Vector2(0.2f, 2f);
      this.Target.Velocity = new Vector2(this.Target.Velocity.X, -this.jumpHeight.Value);
      --this.CurrentJumpAmount;
      ++Stats.TotalJumps;
    }

    public void ApplyGravity()
    {
      if (!this.UseGravity)
        return;
      if ((double) this.Target.Velocity.Y > 0.0)
        this.Target.Velocity += this.gravity * 2.5f * Time.DeltaTime;
      else if ((double) this.Target.Velocity.Y < 0.0 && !this.jumpHeld)
        this.Target.Velocity += this.gravity * 2f * Time.DeltaTime;
      else
        this.Target.Velocity += this.gravity * Time.DeltaTime;
    }

    public void Exit()
    {
        //
    }
  }
}
