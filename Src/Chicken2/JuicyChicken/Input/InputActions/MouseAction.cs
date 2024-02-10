// Decompiled with JetBrains decompiler
// Type: JuicyChicken.MouseAction
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System;

#nullable disable
namespace JuicyChicken
{
  public class MouseAction : InputAction
  {
    private float leftHoldTime;
    private float rightHoldTime;

    public event Action OnLeftClickDown;

    public event Action OnRightClickDown;

    public event Action OnLeftClickUp;

    public event Action OnRightClickUp;

    public event Action OnLeftClickHold;

    public event Action OnRightClickHold;

    public event Action<float> OnScrollChange;

    public MouseAction(float leftHoldTime = 1f, float rightHoldTime = 1f)
    {
      this.leftHoldTime = leftHoldTime;
      this.rightHoldTime = rightHoldTime;
    }

    public override void CheckInput()
    {
      if (Input.GetMouseState().LeftClicked)
      {
        Action onLeftClickDown = this.OnLeftClickDown;
        if (onLeftClickDown != null)
          onLeftClickDown();
      }
      if (Input.GetMouseState().RightClicked)
      {
        Action onRightClickDown = this.OnRightClickDown;
        if (onRightClickDown != null)
          onRightClickDown();
      }
      if (Input.GetMouseState().LeftUp)
      {
        Action onLeftClickUp = this.OnLeftClickUp;
        if (onLeftClickUp != null)
          onLeftClickUp();
      }
      if (Input.GetMouseState().RightUp)
      {
        Action onRightClickUp = this.OnRightClickUp;
        if (onRightClickUp != null)
          onRightClickUp();
      }
      if (Input.GetMouseState().LeftHoldDuration(this.leftHoldTime))
      {
        Action onLeftClickHold = this.OnLeftClickHold;
        if (onLeftClickHold != null)
          onLeftClickHold();
      }
      if (Input.GetMouseState().RightHoldDuration(this.rightHoldTime))
      {
        Action onRightClickHold = this.OnRightClickHold;
        if (onRightClickHold != null)
          onRightClickHold();
      }
      float mouseWheel = Input.GetMouseState().MouseWheel;
      if ((double) mouseWheel == 0.0)
        return;
      Action<float> onScrollChange = this.OnScrollChange;
      if (onScrollChange == null)
        return;
      onScrollChange(mouseWheel / 120f);
    }

    public override void Clear()
    {
      this.OnLeftClickDown = (Action) null;
      this.OnLeftClickUp = (Action) null;
      this.OnRightClickDown = (Action) null;
      this.OnRightClickUp = (Action) null;
      this.OnLeftClickHold = (Action) null;
      this.OnRightClickHold = (Action) null;
      this.OnScrollChange = (Action<float>) null;
    }
  }
}
