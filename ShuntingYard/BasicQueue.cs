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
            _entry = -1;
            Count = 0;
        }

        public void Enqueue(T value)
        {
            if (Count == _underlyingArray.Length) Upsize();

            _entry = (_entry + 1) % _underlyingArray.Length;
            _underlyingArray[_entry] = value;

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

            int j;
            int i;

            for (j = 0, i = _exit; (i % _underlyingArray.Length) != _entry; i++, j++)
            {
                newUnderlyingArray[j] = _underlyingArray[i % _underlyingArray.Length];
            }

            newUnderlyingArray[j] = _underlyingArray[i % _underlyingArray.Length];

            _underlyingArray = newUnderlyingArray;
            _exit = 0;
            _entry = j; 
        }
    }
}
