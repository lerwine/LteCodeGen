using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct NumberExtents<T> : INumberExtents<NumberExtents<T>, T>
    where T : IBinaryNumber<T>, IMinMaxValue<T>
{
    public static NumberExtents<T> MaxExtents { get; } = new(T.MinValue, T.MaxValue);

    public T First { get; }

    public T Last { get; }

    int IReadOnlyCollection<T>.Count => (int)GetCount();

    public NumberExtents(T first, T last)
    {
        if (first > last) throw new ArgumentOutOfRangeException(nameof(first));
        First = first;
        Last = last;
    }

    public NumberExtents(T value)
    {
        First = Last = value;
    }

    public int CompareTo(NumberExtents<T> other)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public bool Equals(NumberExtents<T> other)
    {
        throw new NotImplementedException();
    }

    public BigInteger GetCount()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool IsSingleValue()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() ?? "";
    }

    public static bool operator ==(NumberExtents<T> left, NumberExtents<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NumberExtents<T> left, NumberExtents<T> right)
    {
        return !(left == right);
    }

    public static bool operator <(NumberExtents<T> left, NumberExtents<T> right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(NumberExtents<T> left, NumberExtents<T> right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(NumberExtents<T> left, NumberExtents<T> right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(NumberExtents<T> left, NumberExtents<T> right)
    {
        return left.CompareTo(right) >= 0;
    }
}
