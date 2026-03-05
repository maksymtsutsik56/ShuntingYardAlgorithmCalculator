namespace ShuntingYard
{
    internal class BasicList<T>
    {

        const int DefaultUpsizeBy = 2;
        const int DefaultDownsizeBy = 2;

        private T[] _underlyingArray;   
        public int Count { get; private set; }

        public BasicList()
        {
            _underlyingArray = new T[4];
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                return _underlyingArray[index];
            }

            set
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                _underlyingArray[index] = value;
            }
        }

        public void Add(T value)
        {
            if (Count == _underlyingArray.Length) Upsize();

            _underlyingArray[Count] = value;

            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            for(int i = index; i < Count; i++)
            {
                _underlyingArray[i] = _underlyingArray[i + 1];
            }

            Count--;

            if (_underlyingArray.Length >= Count * 4) Downsize();
        }

        private void Upsize()
        {
            int newCapacity = _underlyingArray.Length * DefaultUpsizeBy;
            T[] newUnderlyingArray = new T[newCapacity];

            for (int i = 0; i < Count; i++)
            {
                newUnderlyingArray[i] = _underlyingArray[i];
            }

            _underlyingArray = newUnderlyingArray;
        }

        private void Downsize()
        {
            int newCapacity = _underlyingArray.Length / DefaultDownsizeBy;
            T[] newUnderlyingArray = new T[newCapacity];

            for (int i = 0; i < Count; i++)
            {
                newUnderlyingArray[i] = _underlyingArray[i];
            }

            _underlyingArray = newUnderlyingArray;
        }
    }
}

