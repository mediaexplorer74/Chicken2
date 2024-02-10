// Decompiled with JetBrains decompiler
// Type: JuicyChicken.DebugConsole
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#nullable disable
namespace JuicyChicken
{
  public static class DebugConsole
  {
    private static SpriteFont font;
    private static List<Line> lines = new List<Line>();
    private static readonly int savedLineCount = 150;
    private static List<string> commandHistory = new List<string>();
    private static byte[] InputBuffer = new byte[1024];
    private static List<float> frameTimes = new List<float>();
    private static bool showGraphicsInfo = false;
    private static bool newConsoleEnable = false;
    private static bool gameObjectDebug = false;
    private static bool imguiDemo = false;

    public static bool ShowGraphicsInfo => DebugConsole.showGraphicsInfo;

    public static int FramecounterDelay { get; set; } = 15;

    public static void Initialize()
    {
      CommandManager.GetCommands();
      GameLoop.OnGUI += new Action(GameObject.DrawUI);
      GameLoop.OnGUI += new Action(DebugConsole.Draw);
      JuicyChicken.Input.OnTyping += new Action<Keys, char>(DebugConsole.CheckKey);
      GameLoop.OnLateUpdate += new Action(DebugConsole.LateUpdate);
    }

    private static void LateUpdate()
    {
      DebugConsole.frameTimes.Add(Time.UnscaledDeltaTime * 1000f);
      if (DebugConsole.frameTimes.Count <= 50)
        return;
      DebugConsole.frameTimes.RemoveAt(0);
    }

    private static void CheckKey(Keys key, char character)
    {
      if (character != '`' && character != '\u00BD')
        return;
      DebugConsole.ToggleConsole();
    }

    private static void SendCommand(string input)
    {
      if (input.Contains(" "))
      {
        int startIndex = input.IndexOf(" ");
        string str = input.Remove(startIndex);
        List<string> list = ((IEnumerable<string>) input.Substring(startIndex + 1).Trim().Split(',')).ToList<string>();
        Debug.Log<string>(str.ToLower());
        CommandManager.ExecuteCommand(str.ToLower(), (object[]) list.ToArray());
      }
      else
      {
        object[] objArray = new object[0];
        Debug.Log<string>(input.ToLower());
        CommandManager.ExecuteCommand(input.ToLower(), objArray);
      }
    }

    public static void Write<T>(T value, Color color = default (Color))
    {
      Line line = !(color == new Color()) ? new Line(value.ToString(), color) : new Line(value.ToString(), Color.White);
      DebugConsole.lines.Insert(0, line);
      if (DebugConsole.lines.Count > DebugConsole.savedLineCount)
        DebugConsole.lines.RemoveAt(DebugConsole.lines.Count - 1);
      if (DebugConsole.commandHistory.Count <= DebugConsole.savedLineCount)
        return;
      DebugConsole.commandHistory.RemoveAt(DebugConsole.lines.Count - 1);
    }

    [ConsoleCommand("Clear", "No Description", 0)]
    private static void Clear() => DebugConsole.lines.Clear();

    [ConsoleCommand("GraphicsInfo", "Show or hide graphics information", 0)]
    private static void InfoToggle()
    {
      DebugConsole.showGraphicsInfo = !DebugConsole.showGraphicsInfo;
    }

    public static void ToggleConsole()
    {
      DebugConsole.newConsoleEnable = !DebugConsole.newConsoleEnable;
    }

    public static void Draw()
    {
      if (DebugConsole.newConsoleEnable)
        DebugConsole.DrawConsole();
      if (!DebugConsole.ShowGraphicsInfo)
        return;
      DebugConsole.DrawGraphicsInfo();
    }

    private static void DrawConsole()
    {
      if (DebugConsole.imguiDemo)
        ImGui.ShowDemoWindow();
      ImGui.Begin("Juicy Console", ref DebugConsole.newConsoleEnable, ImGuiWindowFlags.MenuBar);
      DebugConsole.DrawMenu();
      ImGui.BeginChild("Scroller", new System.Numerics.Vector2(0.0f, (float) (-(double) ImGui.GetFrameHeightWithSpacing() - 5.0)));
      string input1 = "";
      for (int index = DebugConsole.lines.Count - 1; index >= 0; --index)
        input1 = input1 + DebugConsole.lines[index].Text + "\n";
      ImGui.InputTextMultiline("", ref input1, 1024U, new System.Numerics.Vector2(ImGui.GetWindowWidth(), ImGui.GetWindowHeight()), ImGuiInputTextFlags.ReadOnly);
      ImGui.EndChild();
      ImGui.Separator();
      ImGui.PushItemWidth(ImGui.GetWindowWidth() - 80f);
      bool flag = ImGui.InputText("", DebugConsole.InputBuffer, 1024U, ImGuiInputTextFlags.EnterReturnsTrue);
      ImGui.SameLine();
      if (ImGui.Button("Send") | flag)
      {
        string input2 = Encoding.UTF8.GetString(DebugConsole.InputBuffer).Replace("\0", string.Empty);
        if (input2.Trim() != "")
        {
          DebugConsole.SendCommand(input2);
          DebugConsole.InputBuffer = new byte[1024];
        }
      }
      ImGui.End();
    }

    private static void DrawMenu()
    {
      if (!ImGui.BeginMenuBar())
        return;
      if (ImGui.BeginMenu("Utilities"))
      {
        GameObject.MenuItem();
        Content.MenuItem();
        ImGui.EndMenu();
      }
      if (ImGui.BeginMenu("Info"))
      {
        ImGui.MenuItem("Performance info", "", ref DebugConsole.showGraphicsInfo);
        Audio.MenuItem();
        ImGui.EndMenu();
      }
      if (ImGui.BeginMenu("View"))
      {
        ImGui.MenuItem("Reference window", "", ref DebugConsole.imguiDemo);
        JuicyChicken.Graphics.MenuItem();
        ImGui.EndMenu();
      }
      ImGui.EndMenuBar();
    }

    public static void DrawGraphicsInfo()
    {
      ImGui.SetNextWindowBgAlpha(0.4f);
      ImGui.Begin("Graphics information", ref DebugConsole.showGraphicsInfo, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoDocking);
      ImGui.Value("FPS", ImGui.GetIO().Framerate);
      float[] array = DebugConsole.frameTimes.ToArray();
      ImGui.PlotLines("", ref array[0], array.Length, 0, "", 0.0f, 40f, new System.Numerics.Vector2(0.0f, 50f));
      ImGui.End();
    }
  }
}
