// JuicyChicken.Component

using System;

#nullable disable
namespace JuicyChicken
{
  public abstract class Component
  {
    private bool enabled = true;

    public GameObject Owner { get; private set; }

    public Transform Transform => this.Owner.Transform;

    public int Index { get; private set; }

    public string Tag { get; set; } = "";

    public bool Enabled
    {
      get => this.enabled;
      set
      {
        if (!this.enabled && value)
          this.OnEnable();
        else if (this.enabled && !value)
          this.OnDisable();
        this.enabled = value;
      }
    }

    public void Initialize(GameObject owner, int index)
    {
      this.Owner = owner;
      this.Enabled = true;
      this.Index = index;
      this.Owner.OnRemoveComponent += new Action<Component>(this.TryClear);
      GameLoop.OnUpdate += new Action(this.TryUpdate);
      GameLoop.OnLateUpdate += new Action(this.TryLateUpdate);
      GameLoop.OnDraw += new Action<Space>(this.TryDraw);
      this.Start();
    }

    private void TryClear(Component component)
    {
      if (component.Index != this.Index)
        return;
      this.Owner.OnRemoveComponent -= new Action<Component>(this.TryClear);
      GameLoop.OnUpdate -= new Action(this.TryUpdate);
      GameLoop.OnLateUpdate -= new Action(this.TryLateUpdate);
      GameLoop.OnDraw -= new Action<Space>(this.TryDraw);
      this.Reset();
      this.Owner = (GameObject) null;
    }

    private void TryUpdate()
    {
      if (this.Owner == null || !this.Owner.IsActive || !this.Enabled)
        return;
      this.Update();
    }

    private void TryLateUpdate()
    {
      if (this.Owner == null || !this.Owner.IsActive || !this.Enabled)
        return;
      this.LateUpdate();
    }

    private void TryDraw(Space space)
    {
      if (this.Owner == null || !this.Owner.IsActive || !this.Enabled)
        return;
      this.Draw(space);
    }

    public bool CompareTag(string tag) => this.Tag.ToLower() == tag.ToLower();

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void LateUpdate()
    {
    }

    protected virtual void Draw(Space space)
    {
    }

    public abstract void Reset();
  }
}
