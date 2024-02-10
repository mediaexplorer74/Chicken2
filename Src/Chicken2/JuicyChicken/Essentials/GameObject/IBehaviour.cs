// JuicyChicken.IBehaviour`1


#nullable disable
namespace JuicyChicken
{
  public interface IBehaviour<T>
  {
    T Target { get; set; }

    void Start();

    void Update();

    void Exit();
  }
}
