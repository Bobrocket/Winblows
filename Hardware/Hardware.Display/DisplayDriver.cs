using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;

namespace Hardware.Display
{
    public abstract class DisplayDriver
    {
        protected VGAScreen _screen;
        protected int _width, _height;

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public DisplayDriver()
        {
            _screen = new VGAScreen();
        }

        public void Init()
        {
            _screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            _screen.Clear(0);

            _width = _screen.PixelWidth;
            _height = _screen.PixelHeight;
        }

        public virtual void SetPixel(int x, int y, int c)
        {
            if (x < 0 || y < 0 || x > _width || y > _height) return;

            if (_screen.GetPixel320x200x8((uint)x, (uint)y) != (uint)c) setPixelRaw(x, y, c);
        }

        public virtual void FillRect(int x1, int y1, int x2, int y2, int c)
        {
            for (int x = x1; x < x2; x++) for (int y = y1; y < y2; y++) SetPixel(x, y, c);
        }

        public virtual void Clear()
        {
            Clear(0);
        }

        public virtual void Clear(int c)
        {
            _screen.Clear(c);
        }

        public virtual void Step() { }

        protected void setPixelRaw(int x, int y, int c)
        {
            _screen.SetPixel320x200x8((uint)x, (uint)y, (uint)c);
        }
    }
}
