using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Display
{
    class BufferedDisplayDriver : DisplayDriver
    {
        protected byte[] _buffer;
        protected bool _modified;

        public BufferedDisplayDriver() : base()
        {
            base.Init();
            _buffer = new byte[_width * _height];
            //oldBuffer = new byte[_width * _height];
        }

        public override void SetPixel(int x, int y, int c)
        {
            if (x < 0 || y < 0 || x > _width || y > _height) return;

            if (Pixel(x, y) != (byte)c)
            {
                Global.Dbg.Send((x + (y * _width)) + " is " + c);
                //base.SetPixel(x, y, c);
                _buffer[x + (y * _width)] = (byte)c;
                _modified = true;
            }
            //base.SetPixel(x, y, c);
        }

        public override void FillRect(int x1, int y1, int x2, int y2, int c)
        {
            for (int x = x1; x < x2; ++x) for (int y = y1; y < y2; ++y) SetPixel(x, y, c);
        }

        public override void Clear(int c)
        {
            
            base.Clear(c);
        }

        protected byte Pixel(int x, int y)
        {
            return _buffer[x + (y * _width)];
        }

        public void Draw()
        {
            if (_modified)
            {
                //base.FillRect(0, 0, _width, _height, 6);

                for (int x = 0; x < _width; ++x)
                {
                    for (int y = 0; y < _height; ++y)
                    {
                        //base.SetPixel(x, y, 0);
                        /*if (_oldBuffer[x + (y * _width)] != _buffer[x + (y * _width)])*/ base.SetPixel(x, y, _buffer[x + (y * _width)]);
                    }
                }
                _modified = false;

                //_oldBuffer = _buffer;
                //FillRect(0, 0, _width, _height, 28);
                _buffer = new byte[_width * _height];
            }
        }

        public override void Step()
        {
            Draw();
            //Clear(0);
            //Clear(0);
            //base.Step();
        }
    }
}
