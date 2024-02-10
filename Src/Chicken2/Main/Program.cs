// ChickenRemake.Program

using System;
using System.Threading;

#nullable disable
namespace ChickenRemake
{
  public static class Program
  {
    private static Mutex mutex;

    [STAThread]
    private static void Main()
    {
      bool createdNew;
      Program.mutex = new Mutex(true, "Chicken 2", out createdNew);

      if (!createdNew)
        return;

      using (MainGame mainGame = new MainGame())
        mainGame.Run();
    }
  }
}
