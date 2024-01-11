using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    /// <summary>
    /// Asserts that one value can be the <see cref="SequentialRangeSet{T}.RangeItem.End"/> range value preceding the <see cref="SequentialRangeSet{T}.RangeItem.Start"/> of another range.
    /// </summary>
    /// <param name="evaluator">The object for comparing range values.</param>
    /// <param name="previous">The potential preceding range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <param name="next">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <exception cref="InvalidOperationException"><paramref name="previous"/> is not at least 2 incremental values less than <paramref name="next"/>.</exception>
    public static void AssertCanInsert<T>(this IRangeEvaluator<T> evaluator, T previous, T next) where T : struct
    {
        if (evaluator.Compare(previous, next) >= 0 || evaluator.IsSequentiallyAdjacent(previous, next))
            throw new InvalidOperationException($"The range end value of a preceding range element must be at least incremental values less than the range start value of the following range element.");
    }

    /// <summary>
    /// Asserts that a range start value is not greater than an end range value
    /// </summary>
    /// <param name="evaluator">The object for comparing range values.</param>
    /// <param name="start">The potential range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <param name="end">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <returns><see langword="true"/> if <paramref name="start"/> is equal to <paramref name="end"/>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="InvalidOperationException"><paramref name="start"/> greater than <paramref name="end"/>.</exception>
    public static bool AssertValidRange<T>(this IRangeEvaluator<T> evaluator, T start, T end) where T : struct
    {
        var diff = evaluator.Compare(start, end);
        if (diff > 0) throw new InvalidOperationException("Start range value cannot be greater than the end range value.");
        return diff == 0;
    }

    public static bool IsValidRange<T>(this IRangeEvaluator<T> evaluator, T start, T end, out bool isSingleValue, out bool isMaxRange) where T : struct
    {
        var diff = evaluator.Compare(start, end);
        if (diff > 0)
        {
            isSingleValue = isMaxRange = false;
            return false;
        }
        if (diff == 0)
        {
            isSingleValue = true;
            isMaxRange = false;
        }
        else
        {
            isSingleValue = false;
            isMaxRange = evaluator.AreEqual(start, evaluator.MinValue) && evaluator.AreEqual(end, evaluator.MaxValue);
        }
        return true;
    }

    // public static bool IsValidRange<T>(this IRangeEvaluator<T> evaluator, T start, T end, out bool isSingleValue) where T : struct
    // {
    //     var diff = evaluator.Compare(start, end);
    //     if (diff > 0)
    //     {
    //         isSingleValue = false;
    //         return false;
    //     }
    //     isSingleValue = diff == 0;
    //     return true;
    // }

    public static bool AreEqual<T>(this IRangeEvaluator<T> evaluator, T x, T y) where T : struct => evaluator.Compare(x, y) == 0;

    public static bool IsValidPrecedingRangeEnd<T>(this IRangeEvaluator<T> evaluator, T previous, T next) where T : struct => evaluator.Compare(previous, next) < 0 && !evaluator.IsSequentiallyAdjacent(previous, next);

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
        public CharRangeSet() : base(CharRangeEvaluator.Instance) { }
    }

    public class SByteRangeSet : SequentialRangeSet<sbyte>
    {
        public SByteRangeSet() : base(SByteRangeEvaluator.Instance) { }
    }

    public class ByteRangeSet : SequentialRangeSet<byte>
    {
        public ByteRangeSet() : base(ByteRangeEvaluator.Instance) { }
    }

    public class Int16RangeSet : SequentialRangeSet<short>
    {
        public Int16RangeSet() : base(Int16RangeEvaluator.Instance) { }
    }

    public class UInt16RangeSet : SequentialRangeSet<ushort>
    {
        public UInt16RangeSet() : base(UInt16RangeEvaluator.Instance) { }
    }

    public class Int32RangeSet : SequentialRangeSet<int>
    {
        public Int32RangeSet() : base(Int32RangeEvaluator.Instance) { }
    }

    public class UInt32RangeSet : SequentialRangeSet<uint>
    {
        public UInt32RangeSet() : base(UInt32RangeEvaluator.Instance) { }
    }

    public class In64RangeSet : SequentialRangeSet<long>
    {
        public In64RangeSet() : base(Int64RangeEvaluator.Instance) { }
    }

    public class UIn64RangeSet : SequentialRangeSet<ulong>
    {
        public UIn64RangeSet() : base(UInt64RangeEvaluator.Instance) { }
    }
}
