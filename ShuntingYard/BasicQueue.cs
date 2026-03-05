using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYard
{
    internal class BasicQueue<T>
    {
        const int DefaultUpsizeBy = 2;

        private T[] _underlyingArray;
        private int _exit;
        private int _entry;
        
        public int Count { get; private set; }

        public BasicQueue()
        {
            _underlyingArray = new T[4];
            _exit = 0;
            _entry = 0;
            Count = 0;
        }

        public void Enqueue(T value)
        {
            if (Count == _underlyingArray.Length) Upsize();

            _underlyingArray[_entry] = value;

            _entry = (_entry + 1) % _underlyingArray.Length;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException();

            T result = _underlyingArray[_exit];
            _underlyingArray[_exit] = default!;

            _exit = (_exit + 1) % _underlyingArray.Length;
            Count--;

            return result;
        }

        private void Upsize()
        {
            int newCapacity = _underlyingArray.Length * DefaultUpsizeBy;
            T[] newUnderlyingArray = new T[newCapacity];

            for (int j = 0, i = _exit; i % _underlyingArray.Length < _entry; i++, j++)
            {
                newUnderlyingArray[j] = _underlyingArray[i];
            }

            _underlyingArray = newUnderlyingArray;
            _exit = 0;
            _entry = Count; 
        }
    }
}
