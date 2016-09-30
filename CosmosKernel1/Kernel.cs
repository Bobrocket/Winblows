using System;
using System.Collections.Generic;
using System.Text;
using Hardware.Display;
using Sys = Cosmos.System;
using Hardware.Input;
using Hardware.Events.Input;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            //Make sure button pressing works
            Desktop.MouseHandler += (evt) =>
            {
                if (evt is MouseButtonPressedEvent) ((Mouse)evt.Sender).X = 50;
            };

            //Make sure button releasing works
            Desktop.MouseHandler += (evt) =>
            {
                if (evt is MouseButtonReleasedEvent) ((Mouse)evt.Sender).Y = 50;
            };
            
        }

        protected override void Run()
        {
            while (true)
            {
                Desktop.Run();
            }
        }
    }
}
