using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Display;
using Hardware.Events.Input;

namespace Interface.Forms
{
    public class Window : Renderable, IUpdatable, IDisposable
    {
        private List<Control> _controls = new List<Control>();
        private Action<MouseEvent> _eventHandler;

        public Window(int x, int y, int width, int height) : base(x, y, width, height)
        {
            _eventHandler = (evt) => HandleEvent(evt);
            Desktop.MouseHandler += _eventHandler;
           
        }

        public void Dispose()
        {
            Desktop.MouseHandler.Handlers.Remove(_eventHandler);
        }

        public override void Draw(DisplayDriver driver)
        {
            base.Draw(driver);
            foreach (Control c in _controls) if (c.Visible) c.Draw(driver);
        }

        private void HandleEvent(MouseEvent evt)
        {
            if (evt.Consumed) return; //We've consumed it, probably not good anymore

            if (evt.X >= X && evt.X <= (X + Width) && evt.Y >= Y && evt.Y <= (Y + Height)) //Within the bounds of our form!
            {
                foreach (Control c in _controls) //Loop through all controls
                {
                    //Calculate the starting position for the control
                    int cX = (X + c.X);
                    int cY = (Y + c.Y);

                    if (evt.X >= cX && evt.X <= (cX + c.Width) && evt.Y >= cY && evt.Y <= (cY + c.Height)) //Within the bounds of the control
                    {
                        if (evt is MouseButtonReleasedEvent) //For now, only interested in Released events
                        {
                            c.OnClick.Call((MouseButtonReleasedEvent)evt); //Call the Control's OnClick
                            evt.Consumed = true; //"Consume" the event
                            break; //Break the loop, no one else needs to use it
                        }
                    }
                }
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
