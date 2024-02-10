// Decompiled with JetBrains decompiler
// Type: JuicyChicken.WaitWhile
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System;

#nullable disable
namespace JuicyChicken
{
  public class WaitWhile : YieldInstruction
  {
    private Func<bool> condition;

    public WaitWhile(Func<bool> condition) => this.condition = condition;

    public override void Update() => this.IsDone = !this.condition();
  }
}
