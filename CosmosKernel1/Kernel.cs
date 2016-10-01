using System;
using System.Collections.Generic;
using System.Text;
using Hardware.Display;
using Sys = Cosmos.System;
using Hardware.Input;
using Hardware.Events.Input;
using Interface.Forms;
using Interface.Forms.Controls;
using Common;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        private MemoryStream ms = new MemoryStream(12);

        protected override void BeforeRun()
        {
            //Make sure button pressing works
            /*Desktop.MouseHandler += (evt) =>
            {
                if (evt is MouseButtonPressedEvent) ((Mouse)evt.Sender).X = 50;
            };*/

            //Make sure button releasing works
            /*Desktop.MouseHandler += (evt) =>
            {
                if (evt is MouseButtonReleasedEvent) ((Mouse)evt.Sender).Y = 50;
            };*/
            ms.Write(new byte[] { 33, 89, 100 });
            ms.Position = 0;
            Sys.Global.Dbg.Send(ms.Read(1)[0] + " ");
            ms.Position = 2;
            Sys.Global.Dbg.Send(ms.Read(1)[0] + " ");
            Window w = new Window(10, 15, 28, 30);
            w.Controls.Add(new Button(2, 2, 26, 10, w));

            WindowManager.OpenWindows.Add(w);
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
