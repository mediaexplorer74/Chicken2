// JuicyChicken.CoroutineHandler

using System;
using System.Collections;

#nullable disable
namespace JuicyChicken
{
  public class CoroutineHandler
  {
    private IEnumerator method;

    public bool IsDone { get; private set; }

    public CoroutineHandler(IEnumerator method) => this.method = method;

    // Update
    public void Update()
    {
        //RnD
        if (this.method != null)
        {
            if (this.method.Current is YieldInstruction current)
            {
                if (current.IsDone)
                    this.Step();
                else
                    current.Update();
            }
            else
                this.Step();
        }
        else
        {
            this.Step();
        }
    }//Update


    // Step
    public void Step()
    {
            
        //RnD
        if (this.method != null)
        {
            if (this.method.MoveNext())
            {
                if (!(this.method.Current is YieldInstruction current))
                    return;
                current.Start();
            }
            else
                this.IsDone = true;
        }
        else
        { 
            this.IsDone = true; 
        }
           
    }//Step
  }
}
