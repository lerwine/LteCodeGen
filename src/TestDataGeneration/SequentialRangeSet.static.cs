using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    /// <summary>
    /// Asserts that one value can be the <see cref="SequentialRangeSet{T}.RangeItem.End"/> range value preceding the <see cref="SequentialRangeSet{T}.RangeItem.Start"/> of another range.
    /// </summary>
    /// <param name="accessors">The object for comparing range values.</param>
    /// <param name="previous">The potential preceding range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <param name="next">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <exception cref="InvalidOperationException"><paramref name="previous"/> is not at least 2 incremental values less than <paramref name="next"/>.</exception>
    public static void AssertCanInsert<T>(this IRangeSequenceAccessors<T> accessors, T previous, T next) where T : struct
    {
        if (accessors.Compare(previous, next) >= 0 || accessors.IsSequentiallyAdjacent(previous, next))
            throw new InvalidOperationException($"The range end value of a preceding range element must be at least incremental values less than the range start value of the following range element.");
    }

    /// <summary>
    /// Asserts that a range start value is not greater than an end range value
    /// </summary>
    /// <param name="accessors">The object for comparing range values.</param>
    /// <param name="start">The potential range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <param name="end">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <returns><see langword="true"/> if <paramref name="start"/> is equal to <paramref name="end"/>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="InvalidOperationException"><paramref name="start"/> greater than <paramref name="end"/>.</exception>
    public static bool AssertValidRange<T>(this IRangeSequenceAccessors<T> accessors, T start, T end) where T : struct
    {
        var diff = accessors.Compare(start, end);
        if (diff > 0) throw new InvalidOperationException("Start range value cannot be greater than the end range value.");
        return diff == 0;
    }

    public static bool AreEqual<T>(this IRangeSequenceAccessors<T> accessors, T x, T y) where T : struct => accessors.Compare(x, y) == 0;

    public static bool CanInsert<T>(this IRangeSequenceAccessors<T> accessors, T previous, T next) where T : struct => accessors.Compare(previous, next) < 0 && !accessors.IsSequentiallyAdjacent(previous, next);

    public static SequentialRangeSet<T>.RangeItem GetItemAt<T>(int index, SequentialRangeSet<T> rangeSet) where T : struct
    {
        ArgumentNullException.ThrowIfNull(rangeSet);
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        int pos = -1;
        foreach (var item in SequentialRangeSet<T>.RangeItem.GetRanges(rangeSet))
        {
            pos++;
            if (pos == index) return item;
        }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public class CharRangeSet : SequentialRangeSet<char>
    {
        public CharRangeSet() : base(CharRangeAccessors.Instance) { }
    }

    public class SByteRangeSet : SequentialRangeSet<sbyte>
    {
        public SByteRangeSet() : base(SByteRangeAccessors.Instance) { }
    }

    public class ByteRangeSet : SequentialRangeSet<byte>
    {
        public ByteRangeSet() : base(ByteRangeAccessors.Instance) { }
    }

    public class Int16RangeSet : SequentialRangeSet<short>
    {
        public Int16RangeSet() : base(Int16RangeAccessors.Instance) { }
    }

    public class UInt16RangeSet : SequentialRangeSet<ushort>
    {
        public UInt16RangeSet() : base(UInt16RangeAccessors.Instance) { }
    }

    public class Int32RangeSet : SequentialRangeSet<int>
    {
        public Int32RangeSet() : base(Int32RangeAccessors.Instance) { }
    }

    public class UInt32RangeSet : SequentialRangeSet<uint>
    {
        public UInt32RangeSet() : base(UInt32RangeAccessors.Instance) { }
    }

    public class In64RangeSet : SequentialRangeSet<long>
    {
        public In64RangeSet() : base(Int64RangeAccessors.Instance) { }
    }

    public class UIn64RangeSet : SequentialRangeSet<ulong>
    {
        public UIn64RangeSet() : base(UInt64RangeAccessors.Instance) { }
    }
}
