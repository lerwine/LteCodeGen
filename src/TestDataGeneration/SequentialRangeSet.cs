using System.Numerics;
using static TestDataGeneration.SequentialRangeSet;

namespace TestDataGeneration;

/// <summary>
/// Represents an ordered collection of non-adjacent value ranges.
/// </summary>
/// <typeparam name="T">The value type.</typeparam>
/// <remarks>In this class, ranges cannot overlap, and one range will never immediately follow another. Adjacent ranges will be joined as a single range.</remarks>
public partial class SequentialRangeSet<T> : LinkedCollectionBase<SequentialRangeSet<T>.RangeItem>, ICollection<SequentialRangeSet<T>.RangeItem>, IReadOnlyList<SequentialRangeSet<T>.RangeItem>
    where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
{
    private const string ErrorMessage_SequentialRangeSetChanged = $"{nameof(SequentialRangeSet<T>)} has changed.";

    RangeItem IReadOnlyList<RangeItem>.this[int index] => GetItemAt(index, this);

    /// <summary>
    /// Gets a value indicating whether this range contains all possible values.
    /// </summary>
    /// <value><see langword="true"/> if this contains all values from <see cref="IRangeEvaluator{T}.MinValue"/>, up to and including <see cref="IRangeEvaluator{T}.MaxValue"/>; otherwise, <see langword="false"/></value>
    public bool ContainsAllPossibleValues { get; private set; }

    bool ICollection<RangeItem>.IsReadOnly => throw new NotImplementedException();

    /// <summary>
    /// Adds a value to the range collection.
    /// </summary>
    /// <param name="value">The value to be added.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> was appended or prepended to an existing range, or if it was added as a single value of a new range;
    /// otherwise <see langword="false"/> if the value already existed in one of the ranges.</returns>
    public bool Add(T value)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Add(value, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Adds a range of values to the range collection.
    /// </summary>
    /// <param name="start">The inclusive starting range value.</param>
    /// <param name="end">The inclusive ending range value.</param>
    /// <returns><see langword="true"/> if values were appended or prepended to an existing range, or if it was added as a new range;
    /// otherwise <see langword="false"/> if the all values from <paramref name="start"/>, up to and including <paramref name="end"/> already existed in one of the ranges.</returns>
    public bool Add(T start, T end)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Add(start, end, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Adds a new range item object to the range collection.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <exception cref="ArgumentOutOfRangeException">The specified <paramref name="item"/> had a different <see cref="IRangeEvaluator{T}"/> object
    /// which caused value comparisons to be interpreted differently, resulted in a start value that was considered to be larger than the end value, according to
    /// the current <see cref="RangeEvaluator"/> object.</exception>
    /// <exception cref="InvalidOperationException">The specified <paramref name="item"/> overlaps an existing range or is directly adjacent to an existing range,
    /// and could nto be added.</exception>
    public void Add(RangeItem item)
    {
        Monitor.Enter(SyncRoot);
        try { RangeItem.Add(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Returns a value indicating whether the specified value exists in any value ranges.
    /// </summary>
    /// <param name="item">The value to look for.</param>
    /// <returns><see langword="true"/> if <paramref name="item"/> exists in one of the ranges; otherwise <see langword="false"/>.</returns>
    public bool Contains(T item) => RangeItem.Contains(item, this);

    /// <summary>
    /// Returns a value indicating whether all values in the specified value exist in a ranges.
    /// </summary>
    /// <param name="start">The inclusive starting range value.</param>
    /// <param name="end">The inclusive ending range value.</param>
    /// <returns><see langword="true"/> if all values from <paramref name="start"/>, up to and including <paramref name="end"/> exist in one of the ranges; otherwise <see langword="false"/>.</returns>
    public bool Contains(T start, T end) => RangeItem.Contains(start, end, this);

    void ICollection<RangeItem>.CopyTo(RangeItem[] array, int arrayIndex) => ToList().CopyTo(array, arrayIndex);

    /// <summary>
    /// Gets all values from all ranges.
    /// </summary>
    /// <returns>An enumeration of values from all ranges.</returns>
    public IEnumerable<T> GetAllValues()
    {
        foreach (RangeItem item in GetAllNodes())
        {
            foreach (var value in item.GetValues())
                yield return value;
        }
    }

    /// <summary>
    /// Removes a value from an existing range.
    /// </summary>
    /// <param name="item">The value to remove.</param>
    /// <returns><see langword="true"/> if <paramref name="item"/> existed in a value range and was removed; otherwise <see langword="false"/>.</returns>
    /// <remarks>If <paramref name="item"/> exists in the middle of an existing value range, that range will be split up into 2 separate ranges.</remarks>
    public bool Remove(T item)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Remove(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Removes a range of values from existing ranges.
    /// </summary>
    /// <param name="start">The inclusive starting value to remove.</param>
    /// <param name="end">The inclusive ending value to remove.</param>
    /// <returns><see langword="true"/> if at least one value existed in a value range and was removed; otherwise <see langword="false"/>.</returns>
    public bool Remove(T start, T end)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Remove(start, end, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Removes an entire range rom the collection.
    /// </summary>
    /// <param name="item">The value range to remove.</param>
    /// <returns><see langword="true"/> if the <paramref name="item"/> was removed; otherwise <see langword="false"/> if the <paramref name="item"/> did not belong to this collection.</returns>
    public bool Remove(RangeItem item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (item.Owner is not SequentialRangeSet<T> owner || !ReferenceEquals(owner, this)) return false;
            owner.Remove(item);
        }
        finally { Monitor.Exit(SyncRoot); }
        return true;
    }
}