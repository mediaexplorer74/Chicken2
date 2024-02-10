// Decompiled with JetBrains decompiler
// Type: JuicyChicken.WaitForSeconds
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

#nullable disable
namespace JuicyChicken
{
  public class WaitForSeconds : YieldInstruction
  {
    private float seconds;
    private float elapsedTime;

    public WaitForSeconds(float seconds) => this.seconds = seconds;

    public override void Start()
    {
      base.Start();
      this.elapsedTime = 0.0f;
    }

    public override void Update()
    {
      if ((double) this.elapsedTime < (double) this.seconds)
        this.elapsedTime += Time.UnscaledDeltaTime;
      else
        this.IsDone = true;
    }
  }
}
