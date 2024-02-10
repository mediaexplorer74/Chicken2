// Decompiled with JetBrains decompiler
// Type: ChickenRemake.OptionsState
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;

#nullable disable
namespace ChickenRemake
{
  internal class OptionsState : IState
  {
    private GameObject optionsUI;

    public void Start(IState previousState)
    {
      Graphics.ClearColor = PaletteLoader.GetColor(25);
      this.optionsUI = Blueprint.Spawn<CreateOptionsMenu>().GameObject;
    }

    public void Exit(IState newState) => GameObject.Despawn(this.optionsUI);
  }
}
