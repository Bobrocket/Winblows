using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public unsafe class MemoryStream : Stream
    {
        private byte* _ptr;
        private long _startLocation;

        public override long Position
        {
            get { return base.Position; }
            set
            {
                base.Position = value;
                _ptr = (byte*)(value + _startLocation);
            }
        }

        public MemoryStream(long startLocation)
        {
            _startLocation = startLocation;
            _ptr = (byte*)startLocation;
        }

        public override byte[] Read(int length)
        {
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++) bytes[i] = *(_ptr++);
            Position += length;
            return bytes;
        }

        public override bool Write(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++) *(_ptr++) = bytes[i];
            Position += bytes.Length;
            Length += bytes.Length;
            return true;
            //throw new NotImplementedException();
        }

        public override byte ReadAt(int location)
        {
            return *((byte*)location + _startLocation);
        }
    }
}
