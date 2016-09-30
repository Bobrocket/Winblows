using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Events
{
    public class EventHandler<T> where T : Event
    {
        private List<Action<T>> _handlers = new List<Action<T>>();

        public EventHandler()
        {

        }

        public static EventHandler<T> operator +(EventHandler<T> item, Action<T> e)
        {
            item._handlers.Add(e);
            return item;
        }

        public void Call(T evt)
        {
            foreach (Action<T> handler in _handlers) handler(evt);
        }

        public List<Action<T>> Handlers
        {
            get { return _handlers; }
        }
    }
}
