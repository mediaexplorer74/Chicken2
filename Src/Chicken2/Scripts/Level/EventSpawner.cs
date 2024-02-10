// Decompiled with JetBrains decompiler
// Type: ChickenRemake.EventSpawner
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;

#nullable disable
namespace ChickenRemake
{
  public class EventSpawner : Component
  {
    private IBehaviour<EventSpawner> currentBehaviour;

    public void SetBehaviour<T>() where T : IBehaviour<EventSpawner>, new()
    {
      if (this.currentBehaviour != null)
        this.currentBehaviour.Exit();
      T obj = new T();
      obj.Target = this;
      obj.Start();
      this.currentBehaviour = (IBehaviour<EventSpawner>) obj;
    }

    protected override void Update()
    {
      if (this.currentBehaviour == null)
        return;
      this.currentBehaviour.Update();
    }

    public override void Reset() => this.currentBehaviour = (IBehaviour<EventSpawner>) null;
  }
}
