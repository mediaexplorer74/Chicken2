// Type: JuicyChicken.Input

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public static class Input
  {
    internal static List<InputAction> inputActions;
    internal static KeyboardState frameState;
    internal static KeyboardState formerState;
    internal static MouseState frameMouseState;
    internal static MouseState formerMouseState;
    internal static GamePadState frameGamePadState;
    internal static GamePadState formerGamePadState;
    private static Dictionary<Keys, ButtonState> keyStates = new Dictionary<Keys, ButtonState>();
    private static Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();
    private static MouseKeyState mouseKeyState = new MouseKeyState();

    public static Vector2 CurrentMousePosition => JuicyChicken.Input.mouseKeyState.MousePosition;

    public static Vector2 LeftStick => JuicyChicken.Input.frameGamePadState.ThumbSticks.Left;

    public static Vector2 RightStick => JuicyChicken.Input.frameGamePadState.ThumbSticks.Right;

    public static event Action<Keys, char> OnTyping;

    public static bool CheckInput { get; set; } = true;

    public static ModValue JoyMouseSpeed { get; set; } = new ModValue(5f);

    public static bool JoyMouse { get; set; } = true;

    public static void Initialize(GameWindow window)
    {
      JuicyChicken.Input.inputActions = new List<InputAction>();
      foreach (Keys key in Enum.GetValues(typeof (Keys)))
        JuicyChicken.Input.keyStates.Add(key, new ButtonState());
      foreach (Buttons key in Enum.GetValues(typeof (Buttons)))
        JuicyChicken.Input.buttonStates.Add(key, new ButtonState());
      window.TextInput += (EventHandler<TextInputEventArgs>) ((sender, e) =>
      {
        Action<Keys, char> onTyping = JuicyChicken.Input.OnTyping;
        if (onTyping == null)
          return;
        onTyping(e.Key, e.Character);
      });
      GameLoop.OnUpdate += new Action(JuicyChicken.Input.InputUpdater);
    }

    public static KeyAction AddKeyAction(Keys k, float holdTime = 1f)
    {
      KeyAction keyAction = new KeyAction(k, holdTime);
      JuicyChicken.Input.inputActions.Add((InputAction) keyAction);
      return keyAction;
    }

    public static PadAction AddPadAction(Buttons b, float holdTime = 1f)
    {
      PadAction padAction = new PadAction(b, holdTime);
      JuicyChicken.Input.inputActions.Add((InputAction) padAction);
      return padAction;
    }

    public static DirectionAction AddDirectionAction(Keys up = Keys.W, Keys down = Keys.S, Keys left = Keys.A, Keys right = Keys.D)
    {
      DirectionAction directionAction = new DirectionAction(up, down, left, right);
      JuicyChicken.Input.inputActions.Add((InputAction) directionAction);
      return directionAction;
    }

    public static MouseAction AddMouseAction(float holdTime = 1f)
    {
      MouseAction mouseAction = new MouseAction(holdTime);
      JuicyChicken.Input.inputActions.Add((InputAction) mouseAction);
      return mouseAction;
    }

    public static void RemoveAction(InputAction action) => JuicyChicken.Input.inputActions.Remove(action);

    private static void InputUpdater()
    {
      if (!JuicyChicken.Input.CheckInput)
        return;
      for (int index = 0; index < JuicyChicken.Input.inputActions.Count; ++index)
        JuicyChicken.Input.inputActions[index].CheckInput();
      JuicyChicken.Input.frameState = Keyboard.GetState();
      JuicyChicken.Input.frameMouseState = Mouse.GetState();
      JuicyChicken.Input.frameGamePadState = GamePad.GetState(0);
      foreach (Keys key in Enum.GetValues(typeof (Keys)))
      {
        ButtonState buttonState = new ButtonState(JuicyChicken.Input.keyStates[key].HeldTime);
        if (JuicyChicken.Input.KeyDown(key))
          buttonState.Down = true;
        if (JuicyChicken.Input.KeyUp(key))
          buttonState.Up = true;
        if (JuicyChicken.Input.KeyCurrentlyDown(key))
        {
          buttonState.HeldDown = true;
          buttonState.HeldTime += Time.DeltaTime;
        }
        else
          buttonState.HeldTime = 0.0f;
        JuicyChicken.Input.keyStates[key] = buttonState;
      }
      foreach (Buttons buttons in Enum.GetValues(typeof (Buttons)))
      {
        ButtonState buttonState = new ButtonState(JuicyChicken.Input.buttonStates[buttons].HeldTime);
        if (JuicyChicken.Input.frameGamePadState.IsButtonDown(buttons) && !JuicyChicken.Input.formerGamePadState.IsButtonDown(buttons))
          buttonState.Down = true;
        if (!JuicyChicken.Input.frameGamePadState.IsButtonDown(buttons) && JuicyChicken.Input.formerGamePadState.IsButtonDown(buttons))
          buttonState.Up = true;
        if (JuicyChicken.Input.frameGamePadState.IsButtonDown(buttons))
        {
          buttonState.HeldDown = true;
          buttonState.HeldTime += Time.DeltaTime;
        }
        else
          buttonState.HeldTime = 0.0f;
        JuicyChicken.Input.buttonStates[buttons] = buttonState;
      }
      JuicyChicken.Input.mouseKeyState = JuicyChicken.Input.UpdateMouse();
      if (JuicyChicken.Input.JoyMouse)
      {
        if (JuicyChicken.Input.GetPadState(Buttons.RightStick).Down)
          JuicyChicken.Input.mouseKeyState.LeftClicked = true;
        Vector2 vector2 = JuicyChicken.Input.CurrentMousePosition + new Vector2(JuicyChicken.Input.RightStick.X, -JuicyChicken.Input.RightStick.Y) * JuicyChicken.Input.JoyMouseSpeed.Value;
        Mouse.SetPosition((int) vector2.X, (int) vector2.Y);
      }
      JuicyChicken.Input.formerState = JuicyChicken.Input.frameState;
      JuicyChicken.Input.formerMouseState = JuicyChicken.Input.frameMouseState;
      JuicyChicken.Input.formerGamePadState = JuicyChicken.Input.frameGamePadState;
    }

    public static void Rumble(Vector2 intensity, float duration = 0.2f)
    {
      GamePad.SetVibration(0, intensity.X, intensity.Y);
      Coroutine.Start(JuicyChicken.Input.RumbleDelay(duration));
    }

    private static IEnumerator RumbleDelay(float duration)
    {
      yield return (object) new WaitForSeconds(duration);
      GamePad.SetVibration(0, 0.0f, 0.0f);
    }

    private static MouseKeyState UpdateMouse()
    {
      MouseKeyState mouseKeyState = new MouseKeyState();
      mouseKeyState.LeftHeldTime = JuicyChicken.Input.mouseKeyState.LeftHeldTime;
      mouseKeyState.RightHeldTime = JuicyChicken.Input.mouseKeyState.RightHeldTime;
      mouseKeyState.LeftClicked = JuicyChicken.Input.frameMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && JuicyChicken.Input.formerMouseState.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      mouseKeyState.RightClicked = JuicyChicken.Input.frameMouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && JuicyChicken.Input.formerMouseState.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      mouseKeyState.RightUp = JuicyChicken.Input.frameMouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released && JuicyChicken.Input.formerMouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      mouseKeyState.LeftUp = JuicyChicken.Input.frameMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && JuicyChicken.Input.formerMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      mouseKeyState.LeftHeld = JuicyChicken.Input.frameMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      mouseKeyState.RightHeld = JuicyChicken.Input.frameMouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      mouseKeyState.MouseWheel = (float) (JuicyChicken.Input.frameMouseState.ScrollWheelValue - JuicyChicken.Input.formerMouseState.ScrollWheelValue);
      if (mouseKeyState.LeftHeld)
        mouseKeyState.LeftHeldTime += Time.DeltaTime;
      else
        mouseKeyState.LeftHeldTime = 0.0f;
      if (mouseKeyState.RightHeld)
        mouseKeyState.RightHeldTime += Time.DeltaTime;
      else
        mouseKeyState.RightHeldTime = 0.0f;
      mouseKeyState.MousePosition = JuicyChicken.Input.frameMouseState.Position.ToVector2();
      return mouseKeyState;
    }

    public static ButtonState GetKeyState(Keys k) => JuicyChicken.Input.keyStates[k];

    public static ButtonState GetPadState(Buttons b) => JuicyChicken.Input.buttonStates[b];

    public static MouseKeyState GetMouseState() => JuicyChicken.Input.mouseKeyState;

    private static bool KeyDown(Keys key)
    {
      return JuicyChicken.Input.frameState.IsKeyDown(key) && !JuicyChicken.Input.formerState.IsKeyDown(key);
    }

    private static bool KeyUp(Keys key)
    {
      return JuicyChicken.Input.formerState.IsKeyDown(key) && !JuicyChicken.Input.frameState.IsKeyDown(key);
    }

    private static bool KeyCurrentlyDown(Keys key) => JuicyChicken.Input.frameState.IsKeyDown(key);
  }
}
