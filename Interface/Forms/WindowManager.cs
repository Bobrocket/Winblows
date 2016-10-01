using Hardware.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Forms
{
    public static class WindowManager
    {
        private static List<Window> _openWindows = new List<Window>();

        public static List<Window> OpenWindows
        {
            get { return _openWindows; }
            set
            {
                _openWindows = value;
            }
        }

        static WindowManager()
        {

        }

        public static void Draw(DisplayDriver driver)
        {
            foreach (Window w in _openWindows) w.Draw(driver);
        }
    }
}
