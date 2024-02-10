// ChickenRemake.IState

#nullable disable
namespace ChickenRemake
{
  public interface IState
  {
    void Start(IState previousState);

    void Exit(IState newState);
  }
}
