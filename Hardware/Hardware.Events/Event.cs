using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Events
{
    public abstract class Event
    {
        private object _sender;

        public object Sender
        {
            get { return _sender; }
        }

        public Event(object sender)
        {
            _sender = sender;
        }
    }
}
