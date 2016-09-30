using Hardware.Display;
using Hardware.Events.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Input
{
    public class Mouse
    {
        public enum MouseButton
        {
            Left = 0,
            Right = 1,
            Middle = 2
        }

        private Cosmos.HAL.Mouse _mouse;
        //0 -> Left
        //1 -> Right
        //2 -> Middle
        private byte[] states = new byte[3]; //Since a byte has the same memory storage as a boolean, I might as well use byte and assign more values (thus saving more bytes of mem.)
        //Values:
        //0 -> not pressed or held
        //1 -> pressed
        //2 -> held

        private Cosmos.HAL.Mouse.MouseState _oldState;

        public Mouse(int width, int height)
        {
            _mouse = new Cosmos.HAL.Mouse();
            _mouse.Initialize((uint)width, (uint)height);
        }

        public int X
        {
            get { return _mouse.X; }
            set
            {
                _mouse.X = value;
            }
        }

        public int Y
        {
            get { return _mouse.Y; }
            set
            {
                _mouse.Y = value;
            }
        }

        public void Update()
        {
            //In this method, we want to effectively check if we are clicking any mouse buttons.
            //If we aren't (state = none) then:
            //Find out which buttons we had previously clicked and fire a MouseButtonReleasedEvent
            //If we are (state != none) then:
            //Find out which buttons we are clicking - if we just started clicking (oldState != state) then set the status to ONE. Otherwise (oldState = state), set the status to TWO.

            if (State == Cosmos.HAL.Mouse.MouseState.None) //Not holding any buttons, time to fire some released events!
            {
                if (states[(int)MouseButton.Left] != 0) //Left mouse button has been released!
                {
                    MouseEvent me = new MouseButtonReleasedEvent(this, X, Y, MouseButton.Left);
                    Desktop.MouseHandler.Call(me);

                    states[(int)MouseButton.Left] = 0; //Set the status to 0
                }
                //Repeat
                if (states[(int)MouseButton.Right] != 0)
                {
                    MouseEvent me = new MouseButtonReleasedEvent(this, X, Y, MouseButton.Right);
                    Desktop.MouseHandler.Call(me);

                    states[(int)MouseButton.Right] = 0;
                }

                if (states[(int)MouseButton.Middle] != 0)
                {
                    MouseEvent me = new MouseButtonReleasedEvent(this, X, Y, MouseButton.Middle);
                    Desktop.MouseHandler.Call(me);

                    states[(int)MouseButton.Middle] = 0;
                }
            }
            else //We are holding some button
            {
                if (State == Cosmos.HAL.Mouse.MouseState.Left)
                {
                    if (_oldState == Cosmos.HAL.Mouse.MouseState.Left) states[(int)MouseButton.Left] = 2; //If we're holding on to the button, set its status to TWO
                    else //Otherwise, set its status to ONE
                    {
                        states[(int)MouseButton.Left] = 1;

                        MouseEvent me = new MouseButtonPressedEvent(this, X, Y, MouseButton.Left); //Fire a MouseButtonPressedEvent
                        Desktop.MouseHandler.Call(me);
                    }
                }
                if (State == Cosmos.HAL.Mouse.MouseState.Right)
                {
                    if (_oldState == Cosmos.HAL.Mouse.MouseState.Right) states[(int)MouseButton.Right] = 2;
                    else
                    {
                        states[(int)MouseButton.Right] = 1;

                        MouseEvent me = new MouseButtonPressedEvent(this, X, Y, MouseButton.Right);
                        Desktop.MouseHandler.Call(me);
                    }
                }
                if (State == Cosmos.HAL.Mouse.MouseState.Middle)
                {
                    if (_oldState == Cosmos.HAL.Mouse.MouseState.Middle) states[(int)MouseButton.Middle] = 2;
                    else
                    {
                        states[(int)MouseButton.Middle] = 1;

                        MouseEvent me = new MouseButtonPressedEvent(this, X, Y, MouseButton.Middle);
                        Desktop.MouseHandler.Call(me);
                    }
                }
            }
            

            _oldState = State;
        }

        public void Draw(DisplayDriver driver)
        {
            int color = (ButtonPressed(MouseButton.Left)) ? 6 : 28;

            driver.FillRect(X - 1, Y - 1, X + 1, Y + 1, color);
        }

        public Cosmos.HAL.Mouse.MouseState State
        {
            get { return _mouse.Buttons; }
        }

        public bool ButtonPressed(MouseButton button)
        {
            return states[(int)button] != 0;
        }
    }
}
