using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class List<T>
    {
        private T[] _items;
        private uint _count;

        public int Count
        {
            get { return (int)_count; }
        }

        public T[] Items
        {
            get { return _items; }
        }

        public List(int capacity = 8)
        {
            _items = new T[capacity];
        }

        public void Add(T item)
        {
            Global.Dbg.Send("adding at " + (_count + 1));
            if ((_count + 1) >= _items.Length) Resize();
            _count++;
            _items[_count] = item;
        }

        public void RemoveAt(int index)
        {
            _count--;
            T[] newItems = new T[_items.Length];
            for (int i = 0; i < index; i++) newItems[i] = _items[i];
            for (int i = (index + 1); i < _items.Length; i++) newItems[i - 1] = _items[i];
            _items = newItems;
        }

        public void Remove(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    RemoveAt(i);
                    break;
                }
            }
        }

        public T Get(int index)
        {
            return _items[index];
        }

        private void Resize()
        {
            Global.Dbg.Send("resizing from " + (_count + 1));
            T[] newItems = new T[(_count + 1) * 2];
            for (int i = 0; i <= _count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }
    }
}
