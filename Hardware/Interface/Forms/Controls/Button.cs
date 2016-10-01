using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Display;

namespace Interface.Forms.Controls
{
    public class Button : Control
    {
        private int _color;

        public Button(int x, int y, int width, int height, Window parent) : base(x, y, width, height, parent)
        {
            OnClick += (evt) => {
                if (_color == 4) _color = 3;
                else _color = 4;
            };
        }

        public override void Draw(DisplayDriver driver)
        {
            int realX = (X + _parent.X);
            int realY = (Y + _parent.Y);
            driver.FillRect(realX, realY, realX + Width, realY + Height, _color);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
