using Hardware.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public abstract class Renderable
    {
        private int _x, _y, _width, _height;
        private bool _visible = true;

        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
            }
        }

        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
            }
        }

        public Renderable(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public virtual void Draw(DisplayDriver driver)
        {
            driver.FillRect(X, Y, (X + Width), (Y + Height), 1);
        }
    }
}
