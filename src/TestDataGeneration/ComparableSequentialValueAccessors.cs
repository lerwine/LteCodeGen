using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public abstract class ComparableSequentialValueAccessors<T> : ISequentalValueAccessors<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    public abstract T MaxValue { get; }

    public abstract T MinValue { get; }

    public int Compare(T x, T y) => x.CompareTo(y);

    public abstract T Decrement(T value, int count = 1);
    
    public bool Equals(T x, T y) => x.Equals(y);
    
    public virtual int GetHashCode([DisallowNull] T obj) => obj.GetHashCode();

    public abstract int GetRangeCount(T rangeStart, T rangeEnd);

    public abstract IEnumerable<T> GetValuesInRange(T rangeStart, T rangeEnd);

    public abstract T Increment(T value, int count = 1);

    public abstract bool IsInRange(T targetValue, T rangeStart, T rangeEnd);

    public abstract bool IsSequentiallyNext(T precedingValue, T nextValue);
}