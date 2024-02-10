// Type: JuicyChicken.WaitUntil

using System;

#nullable disable
namespace JuicyChicken
{
  public class WaitUntil : YieldInstruction
  {
    private Func<bool> condition;

    public WaitUntil(Func<bool> condition) => this.condition = condition;

    public override void Update() => this.IsDone = this.condition();
  }
}
