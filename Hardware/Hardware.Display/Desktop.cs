using Hardware.Events.Input;
using Hardware.Input;
using Interface.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hardware.Display
{
    public static class Desktop
    {
        private static BufferedDisplayDriver _driver = new BufferedDisplayDriver();
        private static Mouse _mouse;
        private static bool _running;

        private static Cosmos.HAL.Mouse.MouseState _oldState;

        private static Hardware.Events.EventHandler<MouseEvent> _mousePressHandler = new Events.EventHandler<MouseEvent>();

        /// <summary>
        /// The event handler for all mouse events
        /// </summary>
        public static Hardware.Events.EventHandler<MouseEvent> MouseHandler
        {
            get { return _mousePressHandler; }
            set
            {
                _mousePressHandler = value;
            }
        }

        /// <summary>
        /// Whether or not the desktop thread is polling.
        /// </summary>
        public static bool Polling
        {
            get { return _running; }
            set
            {
                _running = value;
            }
        }

        /// <summary>
        /// Initialises everything necessary.
        /// </summary>
        static Desktop()
        {
            _mouse = new Mouse(_driver.Width, _driver.Height);
            _running = true;
        }

        public static void Run()
        {
            if (_running)
            {
                Cosmos.HAL.Global.Dbg.Send("updating mouse");
                //Step one: update everything necessary
                _mouse.Update();

                Cosmos.HAL.Global.Dbg.Send("drawing");
                //Step two: draw everything necessary (ie render to buffer)
                WindowManager.Draw(_driver);
                _mouse.Draw(_driver);

                Cosmos.HAL.Global.Dbg.Send("rendering");
                //Step three: draw the buffer
                _driver.Step();
            }
            
        }
    }
}
