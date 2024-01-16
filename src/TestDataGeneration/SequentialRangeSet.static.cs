using System.Numerics;

namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public static bool IsSequentiallyAdjacent<T>(this T lValue, T rValue) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => !(lValue.Equals(rValue) || lValue.Equals(T.MaxValue)) && ++lValue == rValue;

    public static SequentialComparisonResult CompareForRangeValues<T>(this T lValue, T rValue) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        int diff = lValue.CompareTo(rValue);
        return (diff == 0) ? SequentialComparisonResult.EqualTo :
            (diff < 0) ? (IsSequentiallyAdjacent(lValue, rValue) ? SequentialComparisonResult.ImmediatelyPrecedes : SequentialComparisonResult.PrecedesWithGap) :
            IsSequentiallyAdjacent(rValue, lValue) ? SequentialComparisonResult.ImmediatelyFollows : SequentialComparisonResult.FollowsWithGap;
    }

    public static SequentialComparisonResult GetDispositionInRangeExtents<T>(this T value, T start, T end) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        int diff = start.CompareTo(end);
        if (diff > 0) throw new InvalidOperationException($"{nameof(start)} cannot be greater than {nameof(end)}.");
        if (diff == 0)
            return ((diff = value.CompareTo(start)) == 0) ? SequentialComparisonResult.EqualTo :
                (diff < 0) ? (IsSequentiallyAdjacent(value, start) ? SequentialComparisonResult.ImmediatelyPrecedes : SequentialComparisonResult.PrecedesWithGap) :
                IsSequentiallyAdjacent(start, value) ? SequentialComparisonResult.ImmediatelyFollows : SequentialComparisonResult.FollowsWithGap;
        
        if ((diff = value.CompareTo(start)) == 0) return SequentialComparisonResult.EqualTo;
        if (diff < 0)
            return IsSequentiallyAdjacent(value, start) ? SequentialComparisonResult.ImmediatelyPrecedes : SequentialComparisonResult.PrecedesWithGap;
        if (value.CompareTo(end) <= 0) return SequentialComparisonResult.EqualTo;
        return IsSequentiallyAdjacent(end, value) ? SequentialComparisonResult.ImmediatelyFollows : SequentialComparisonResult.FollowsWithGap;
    }

    public static bool IsMaxRange<T>(this IRangeExtents<T> extents) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && extents.Start.Equals(T.MaxValue);
    
    public static bool IsSingleValue<T>(this IRangeExtents<T> extents) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && extents.Start.Equals(extents.End);
    
    public static SequentialComparisonResult GetDispositionOf<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        ArgumentNullException.ThrowIfNull(extents);
        throw new NotImplementedException();
    }
    public static bool IsIncludedInExtents<T>(this T value, T start, T end)where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => value >= start && value <= end;

    /// <summary>
    /// Indicates whether a specified value falls within the current range extents.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is not less than <see cref="Start"/> and is not greater than <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    public static bool Contains<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value >= extents.Start && value <= extents.End;

    /// <summary>
    /// Indicates whether the specified range extents do not fall outside of the current range extents.
    /// </summary>
    /// <param name="start">The inclusive minimum value.</param>
    /// <param name="end">The inclusive maximum value.</param>
    /// <returns><see langword="true"/> if <paramref name="end"/> is not less than <see cref="Start"/> and <paramref name="start"/> is not greater than <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    /// <remarks>If an invalid range is passed (<paramref name="start"/> is greather than <paramref name="end"/>) this will not throw an exception, but will instead simply return <see langword="false"/>.</remarks>
    public static bool Contains<T>(this IRangeExtents<T> extents, T start, T end) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && start >= extents.Start && end <= extents.End && start <= end;

    /// <summary>
    /// Indicates whether the current range extents matches a given single-value range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is equal to both <see cref="Start"/> and <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    public static bool Equals<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value == extents.Start && value == extents.End;

    /// <summary>
    /// Indicates whether the current range extents match given range extents.
    /// </summary>
    /// <param name="start">The inclusive starting range extent.</param>
    /// <param name="end">The inclusive ending range extent.</param>
    /// <returns><see langword="true"/> if <paramref name="start"/> is equal to <see cref="Start"/> and <paramref name="end"/> is equal to <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    /// <remarks>If an invalid range is passed (<paramref name="start"/> is greather than <paramref name="end"/>) this will not throw an exception, but will instead simply return <see langword="false"/>.</remarks>
    public static bool Equals<T>(this IRangeExtents<T> extents, T start, T end) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && start == extents.Start && end == extents.End;

    /// <summary>
    /// Indicates whether a specified value is greater than the ending extent.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is greater than <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    public static bool Follows<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value > extents.End;

    /// <summary>
    /// Indicates whether the specified range extents begin after the end of the current range extents.
    /// </summary>
    /// <param name="item">The range extents to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Start"/> extent of the given <paramref name="item"/> is greater than <see cref="End"/> etent; otherwise, <see langword="false"/>.</returns>
    public static bool Follows<T>(this IRangeExtents<T> extents, IRangeExtents<T> item) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => item is not null && Follows(extents, item.End);

    /// <summary>
    /// Indicates whether a specified value is at least two increments greater than the current ending extent.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is at least two increments greater than <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    public static bool FollowsWithGap<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value > extents.End && --value > extents.End;

    /// <summary>
    /// Indicates whether the specified range extents start at least 1 additional increment after the end of the current range extents.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Start"/> value of the given <paramref name="item"/> is at least 2 increments greater than the <see cref="End"/> of the current extents;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool FollowsWithGap<T>(this IRangeExtents<T> extents, IRangeExtents<T> item) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => item is not null && FollowsWithGap(extents, item.End);

    /// <summary>
    /// Gets the number of sequential values included within the current extents.
    /// </summary>
    /// <returns>The number of sequential values starting from the <see cref="Start"/> value, up to and including the <see cref="End"/> value.</returns>
    /// <remarks>This will return <c>0UL</c> if <see cref="IsMaxRange"/> is <see langword="true"/> to accomodate 64-bit values.</remarks>
    public static BigInteger GetCount<T>(this IRangeExtents<T> extents) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>, IBinaryNumber<T>, INumber<T>, INumberBase<T>, IFormattable, IParsable<T>, ISpanFormattable, ISpanParsable<T>
    {
        ArgumentNullException.ThrowIfNull(extents);
        return BigInteger.CreateChecked(extents.End) - BigInteger.CreateChecked(extents.Start) + BigInteger.One;
    }

    /// <summary>
    /// Indicates whether the specified value is exactly one increment greater than the end of the current range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is exactly on increment greater than <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    public static bool ImmediatelyFollows<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value < extents.Start && ++value == extents.Start;

    /// <summary>
    /// Indicates whether the range starts immediately after the end of the current range.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Start"/> value of the given <paramref name="item"/> is exactly on increment greater than <see cref="End"/>; otherwise, <see langword="false"/>.</returns>
    public static bool ImmediatelyFollows<T>(this IRangeExtents<T> extents, IRangeExtents<T> item) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => item is not null && ImmediatelyFollows(extents, item.End);

    /// <summary>
    /// Indicates whether the specified value is exactly one increment lesser than the start of the current range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is exactly on increment lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</returns>
    public static bool ImmediatelyPrecedes<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value > extents.End && --value == extents.End;

    /// <summary>
    /// Indicates whether the range ends immediately before the start of the current range.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <returns><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> is exactly on increment lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</returns>
    public static bool ImmediatelyPrecedes<T>(this IRangeExtents<T> extents, IRangeExtents<T> item) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => item is not null && ImmediatelyPrecedes(extents, item.Start);

    /// <summary>
    /// Indicates whether a given range overlaps the current range.
    /// </summary>
    /// <param name="item">The range to compare.</param>
    /// <returns><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> not lesser than the current <see cref="Start"/> value,
    /// and the <see cref="Start"/> value of the given <paramref name="item"/> is not greater than the current <see cref="End"/> value; otherwise, <see langword="false"/>.</returns>
    public static bool Overlaps<T>(this IRangeExtents<T> extents, IRangeExtents<T> item) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        if (extents is null) return item is null;
        if (item is null) return false;
        int diff = item.Start.CompareTo(extents.End);
        if (diff == 0) return true;
        return diff < 0 && item.End >= extents.Start;
    }

    /// <summary>
    /// Indicates whether a given range of values overlaps the current range.
    /// </summary>
    /// <param name="start">The inclusive starting range value.</param>
    /// <param name="end">The inclusive ending range value.</param>
    /// <returns><see langword="true"/> if the given <paramref name="end"/> value not lesser than the current <see cref="Start"/> value,
    /// and the given <paramref name="start"/> is not greater than the current <see cref="End"/> value; otherwise, <see langword="false"/>.</returns>
    public static bool Overlaps<T>(this IRangeExtents<T> extents, T start, T end) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        if (extents is null) return false;
        int diff = start.CompareTo(extents.End);
        if (diff == 0) return true;
        return diff < 0 && end >= extents.Start;
    }

    /// <summary>
    /// Indicates whether a specified value is less than the starting extent.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</returns>
    public static bool Precedes<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value > extents.End;

    /// <summary>
    /// Indicates whether the specified range extents end before the start of the current range extents.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <returns><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> is lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</returns>
    public static bool Precedes<T>(this IRangeExtents<T> extents, IRangeExtents<T> item) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => item is not null && Precedes(extents, item.Start);

    /// <summary>
    /// Indicates whether a specified value is at least two increments less than the current starting extent.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is at least two increments less than <see cref="Start"/>; otherwise, <see langword="false"/>.</returns>
    public static bool PrecedesWithGap<T>(this IRangeExtents<T> extents, T value) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => extents is not null && value > extents.End && --value > extents.End;

    /// <summary>
    /// Indicates whether the specified range extents end at least 1 additional increment before the start of the current range extents.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <returns><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> is at least 2 increments lesser than <see cref="Start"/> of the current extents;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool PrecedesWithGap<T>(this IRangeExtents<T> extents, IRangeExtents<T> item) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> => item is not null && PrecedesWithGap(extents, item.Start);

    /// <summary>
    /// Asserts that one value can be the <see cref="SequentialRangeSet{T}.RangeItem.End"/> range extent preceding the <see cref="SequentialRangeSet{T}.RangeItem.Start"/> of another range.
    /// </summary>
    /// <param name="previous">The potential preceding range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <param name="next">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <exception cref="InvalidOperationException"><paramref name="previous"/> is not at least 2 incremental values less than <paramref name="next"/>.</exception>
    public static void AssertCanInsertBefore<T>(this T previous, T next) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        if (previous.CompareTo(next) >= 0 || IsSequentiallyAdjacent(previous, next))
            throw new InvalidOperationException($"The range end extent of a preceding range element must be at least incremental values less than the range start extent of the following range element.");
    }

    /// <summary>
    /// Asserts that one value can be the <see cref="SequentialRangeSet{T}.RangeItem.Start"/> range extent following the <see cref="SequentialRangeSet{T}.RangeItem.End"/> of another range.
    /// </summary>
    /// <param name="next">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <param name="previous">The potential preceding range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <exception cref="InvalidOperationException"><paramref name="previous"/> is not at least 2 incremental values less than <paramref name="next"/>.</exception>
    public static void AssertCanInsertAfter<T>(this T next, T previous) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        if (previous.CompareTo(next) >= 0 || IsSequentiallyAdjacent(previous, next))
            throw new InvalidOperationException($"The range start extent of a following range element must be at least incremental values greater than the range end extent of the following range element.");
    }

    /// <summary>
    /// Asserts that a range start value is not greater than an end range value
    /// </summary>
    /// <param name="start">The potential range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <param name="end">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <returns><see langword="true"/> if <paramref name="start"/> is less than <paramref name="end"/>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="InvalidOperationException"><paramref name="start"/> is greater than <paramref name="end"/>.</exception>
    public static bool AssertLessThanOrEquals<T>(this T start, T end) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        var diff = start.CompareTo(end);
        if (diff > 0) throw new InvalidOperationException("Start range value cannot be greater than the end range value.");
        return diff < 0;
    }

    /// <summary>
    /// Asserts that a range start value is not greater than an end range value
    /// </summary>
    /// <param name="end">The potential following range <see cref="SequentialRangeSet{T}.RangeItem.End"/> value.</param>
    /// <param name="start">The potential range <see cref="SequentialRangeSet{T}.RangeItem.Start"/> value.</param>
    /// <returns><see langword="true"/> if <paramref name="end"/> is greater than <paramref name="start"/>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="InvalidOperationException"><paramref name="end"/> is less than <paramref name="start"/>.</exception>
    public static bool AssertGreaterThanOrEquals<T>(this T end, T start) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        var diff = start.CompareTo(end);
        if (diff > 0) throw new InvalidOperationException("End range value cannot be less than the start range value.");
        return diff < 0;
    }

    public static bool IsValidStartFrom<T>(this T start, T end, out bool isMultiValue, out bool isMaxRange) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        var diff = start.CompareTo(end);
        if (diff > 0)
        {
            isMultiValue = isMaxRange = false;
            return false;
        }
        if (diff == 0)
            isMultiValue = isMaxRange = false;
        else
        {
            isMultiValue = true;
            isMaxRange = start.Equals(T.MinValue) && end.Equals(T.MaxValue);
        }
        return true;
    }

    public static bool IsValidEndFrom<T>(this T end, T start, out bool isMultiValue, out bool isMaxRange) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        var diff = start.CompareTo(end);
        if (diff > 0)
        {
            isMultiValue = isMaxRange = false;
            return false;
        }
        if (diff == 0)
            isMultiValue = isMaxRange = false;
        else
        {
            isMultiValue = true;
            isMaxRange = start.Equals(T.MinValue) && end.Equals(T.MaxValue);
        }
        return true;
    }

    public static bool IsValidPrecedingRangeEnd<T>(this T previous, T next) where T : struct, IBinaryInteger<T>, IMinMaxValue<T> =>
        previous.CompareTo(next) < 0 && !IsSequentiallyAdjacent(previous, next);

    public static SequentialRangeSet<T>.RangeItem GetItemAt<T>(int index, SequentialRangeSet<T> rangeSet) where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
    {
        ArgumentNullException.ThrowIfNull(rangeSet);
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        int pos = -1;
        foreach (var item in rangeSet)
        {
            pos++;
            if (pos == index) return item;
        }
        throw new ArgumentOutOfRangeException(nameof(index));
    }
}
