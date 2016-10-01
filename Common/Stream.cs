using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class Stream
    {
        private long _position, _length;

        public virtual long Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (_position > _length) _position = _length; //Prevent overflowing
            }
        }

        public long Length
        {
            get { return _length; }
            protected set
            {
                _length = value;
            }
        }

        public abstract byte[] Read(int length);
        public abstract byte ReadAt(int location);
        public abstract bool Write(byte[] bytes);
    }
}
