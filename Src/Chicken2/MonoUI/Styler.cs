// MGUI.MonoUI.Styler

using ImGuiNET;
using System.Numerics;

#nullable disable
namespace MGUI.MonoUI
{
  public static class Styler
  {
    private static Vector4 mainAccent = new Vector4(0.75f, 0.466f, 0.142f, 1f);
    private static Vector4 background = new Vector4(0.28f, 0.281f, 0.283f, 1f);
    private static Vector4 hover = new Vector4(0.55f, 0.347f, 0.115f, 1f);
    private static Vector4 active = new Vector4(0.91f, 0.485f, 0.0f, 1f);

    public static void SetStyle()
    {
      ImGui.GetStyle().WindowRounding = 5f;
      ImGui.GetStyle().ChildRounding = 5f;
      ImGui.GetStyle().FrameRounding = 5f;
      ImGui.GetStyle().GrabRounding = 5f;
      ImGui.GetStyle().PopupRounding = 5f;
      ImGui.GetStyle().ScrollbarRounding = 5f;
      ImGui.GetStyle().Colors[11] = Styler.mainAccent;
      ImGui.GetStyle().Colors[40] = Styler.mainAccent;
      ImGui.GetStyle().Colors[41] = Styler.hover;
      ImGui.GetStyle().Colors[42] = Styler.mainAccent;
      ImGui.GetStyle().Colors[43] = Styler.hover;
      ImGui.GetStyle().Colors[7] = Styler.background;
      ImGui.GetStyle().Colors[24] = Styler.mainAccent;
      ImGui.GetStyle().Colors[25] = Styler.hover;
      ImGui.GetStyle().Colors[26] = Styler.active;
    }
  }
}
