
namespace ShuntingYard;

internal class BasicStack<T>
{
    const int DefaultUpsizeBy = 2;
    const int DefaultDownsizeBy = 2;
    const int MinCapacity = 4;

    private T[] _underlyingArray;
    private int _pointer;

    public int Count => _pointer + 1;

    public BasicStack()
    {
        _underlyingArray = new T[4];
        _pointer = -1;
    }

    public void Push(T value)
    {
        if (Count == _underlyingArray.Length) Upsize();

        _pointer++;
        _underlyingArray[_pointer] = value;

    }

    public T Pop()
    {
        if (_pointer < 0) throw new InvalidOperationException();

        T result = _underlyingArray[_pointer];

        _underlyingArray[_pointer] = default!;
        _pointer--;

        if (_underlyingArray.Length > MinCapacity && _underlyingArray.Length >= Count * 4) Downsize();

        return result;
    }

    public T Peek()
    {
        if (_pointer < 0) throw new InvalidOperationException();

        T result = _underlyingArray[_pointer];

        return result;
    }

    private void Upsize()
    {
        int newCapacity = _underlyingArray.Length * DefaultUpsizeBy;
        T[] newUnderlyingArray = new T[newCapacity];

        for (int i = 0; i <= _pointer; i++)
        {
            newUnderlyingArray[i] = _underlyingArray[i];
        }

        _underlyingArray = newUnderlyingArray;
    }

    private void Downsize()
    {
        int newCapacity = _underlyingArray.Length / DefaultDownsizeBy;
        T[] newUnderlyingArray = new T[newCapacity];

        for (int i = 0; i <= _pointer; i++)
        {
            newUnderlyingArray[i] = _underlyingArray[i];
        }

        _underlyingArray = newUnderlyingArray;
    }
}

