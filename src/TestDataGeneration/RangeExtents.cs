using System.Collections;
using System.Numerics;

namespace TestDataGeneration;

public readonly struct RangeExtents<T> : IRangeExtents<T>
    where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
{
    public T Start { get; }

    public T End { get; }

    public bool IsMultiValue { get; }

    public bool IsMaxRange { get; }

    public RangeExtents(T start, T end)
    {
        if (start > end) throw new ArgumentOutOfRangeException(nameof(start));
        int diff = start.CompareTo(end);
        if (diff > 0)
        Start = start;
        End = end;
        if (diff == 0)
            IsMultiValue = IsMaxRange = false;
        else
        {
            IsMultiValue = true;
            IsMaxRange = start.Equals(T.MinValue) && end.Equals(T.MaxValue);
        }
    }

    public RangeExtents(T value)
    {
        Start = End = value;
        IsMultiValue = IsMaxRange = false;
    }

    public bool Equals(IRangeExtents<T>? other)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
