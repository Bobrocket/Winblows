using Hardware.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Events.Input
{
    public class MouseButtonReleasedEvent : MouseEvent
    {
        private Mouse.MouseButton _state;

        public Mouse.MouseButton Button
        {
            get { return _state; }
        }

        public MouseButtonReleasedEvent(Mouse mouse, int x, int y, Mouse.MouseButton state) : base(mouse, x, y)
        {
            _state = state;
        }
    }
}
