using System.Collections;
using System.Diagnostics.CodeAnalysis;
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
        if (!start.IsValidStartFrom(end, out bool isMultiValue, out bool isMaxRange))
            throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
        Start = start;
        End = end;
        IsMultiValue = isMultiValue;
        IsMaxRange = isMaxRange;
    }

    public RangeExtents(T value)
    {
        Start = End = value;
        IsMultiValue = IsMaxRange = false;
    }

    public bool Equals(IRangeExtents<T>? other) => other is not null && other.Start.Equals(Start) && other.End.Equals(End);

    public IEnumerable<T> GetValues()
    {
        var value = Start;
        yield return value;
        while (value.CompareTo(End) < 0)
        {
            value++;
            yield return value;
        }
    }

    public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is not null && ((obj is IRangeExtents<T> other) ? Equals(other) : obj is T value && Equals(value));

    public override int GetHashCode() => HashCode.Combine(Start, End);

    public override string ToString() => IsMultiValue ? $"{{{Start}..{End}}}" : $"{{{Start}}}";
}
