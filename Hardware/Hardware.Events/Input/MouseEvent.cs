using Hardware.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Events.Input
{
    public abstract class MouseEvent : Event
    {
        private int _x, _y;

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public MouseEvent(Mouse mouse, int x, int y) : base(mouse)
        {
            _x = x;
            _y = y;
        }

        public void Dispose()
        {

        }
    }
}
