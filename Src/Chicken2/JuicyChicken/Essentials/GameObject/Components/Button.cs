// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Button
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace JuicyChicken
{
  public class Button : Component
  {
    private bool hovered;
    private Vector2 bounds;
    private MouseAction mouse = new MouseAction();

    public event Action OnLeftClick;

    public event Action OnRightClick;

    public event Action OnHoverEnter;

    public event Action OnHoverExit;

    public Vector2 Origin { get; set; }

    public Vector2 Bounds
    {
      get => this.bounds;
      set => this.bounds = value;
    }

    public Space Space { get; set; } = Space.Screen;

    protected override void Start()
    {
      this.mouse.OnLeftClickDown += new Action(this.LeftClick);
      this.mouse.OnRightClickDown += new Action(this.RightClick);
      this.mouse.OnLeftClickUp += new Action(this.ClickRelease);
      this.mouse.OnRightClickUp += new Action(this.ClickRelease);
    }

    private void ClickRelease()
    {
      if (!this.hovered)
        return;
      this.OnHoverExit();
      this.hovered = false;
    }

    private void LeftClick()
    {
      if (!this.hovered)
        return;
      Action onLeftClick = this.OnLeftClick;
      if (onLeftClick == null)
        return;
      onLeftClick();
    }

    private void RightClick()
    {
      if (!this.hovered)
        return;
      Action onRightClick = this.OnRightClick;
      if (onRightClick == null)
        return;
      onRightClick();
    }

    private void EnterButton()
    {
      if (this.Owner == null)
        return;
      if (this.Owner.Transform.Position.PointInside(this.Bounds * this.Owner.Transform.Scale, (this.Space != Space.Screen ? Camera.ScreenToWorld(Input.CurrentMousePosition) : Input.CurrentMousePosition) + this.Origin * this.Owner.Transform.Scale))
      {
        if (this.hovered)
          return;
        Action onHoverEnter = this.OnHoverEnter;
        if (onHoverEnter != null)
          onHoverEnter();
        this.hovered = true;
      }
      else
      {
        if (!this.hovered)
          return;
        Action onHoverExit = this.OnHoverExit;
        if (onHoverExit != null)
          onHoverExit();
        this.hovered = false;
      }
    }

    protected override void Update()
    {
      this.mouse.CheckInput();
      this.EnterButton();
    }

    public override void Reset()
    {
      this.mouse.OnLeftClickDown -= new Action(this.LeftClick);
      this.mouse.OnRightClickDown -= new Action(this.RightClick);
      this.OnRightClick = (Action) null;
      this.OnLeftClick = (Action) null;
      this.OnHoverEnter = (Action) null;
      this.OnHoverExit = (Action) null;
      this.hovered = false;
      this.Bounds = new Vector2();
    }
  }
}
