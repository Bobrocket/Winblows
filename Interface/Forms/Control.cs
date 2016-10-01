using Common;
using Hardware.Events.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Display;

namespace Interface.Forms
{
    public abstract class Control : Renderable, IUpdatable
    {
        private Hardware.Events.EventHandler<MouseButtonReleasedEvent> _handler = new Hardware.Events.EventHandler<MouseButtonReleasedEvent>();
        private Window _parent;

        public Hardware.Events.EventHandler<MouseButtonReleasedEvent> OnClick
        {
            get { return _handler; }
            set
            {
                _handler = value;
            }
        }

        public Control(int x, int y, int width, int height, Window parent) : base(x, y, width, height)
        {
            _parent = parent;
        }

        public override void Draw(DisplayDriver driver)
        {
            int realX = _parent.X + X;
            int realY = _parent.Y + Y;

            driver.FillRect(realX, realY, realX + Width, realY + Height, 2);

            //base.Draw(driver);
        }

        public abstract void Update();
    }
}
