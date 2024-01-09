using System.Collections;
using static TestDataGeneration.SequentialRangeSet;

namespace TestDataGeneration;

/// <summary>
/// Represents an ordered collection of non-adjacent value ranges.
/// </summary>
/// <typeparam name="T">The value type.</typeparam>
/// <remarks>In this class, ranges cannot overlap, and one range will never immediately follow another. Adjacent ranges will be joined as a single range.</remarks>
public partial class SequentialRangeSet<T> : ICollection<SequentialRangeSet<T>.RangeItem>, IReadOnlyList<SequentialRangeSet<T>.RangeItem>, IList, IHasChangeToken
    where T : struct
{
    private object _changeToken = new();

    private const string ErrorMessage_SequentialRangeSetChanged = $"{nameof(SequentialRangeSet<T>)} has changed.";

    RangeItem IReadOnlyList<RangeItem>.this[int index] => GetItemAt(index, this);

    object? IList.this[int index] { get => GetItemAt(index, this); set => throw new NotSupportedException(); }

    /// <summary>
    /// Gets the object that is used to compare and manipulate values of type <typeparamref name="T"/>.
    /// </summary>
    public IRangeSequenceAccessors<T> Accessors { get; }

    object IHasChangeToken.ChangeToken => _changeToken;

    int IReadOnlyCollection<RangeItem>.Count => Count();

    int ICollection<RangeItem>.Count => Count();

    int ICollection.Count => Count();

    /// <summary>
    /// Gets the first range in the ordered collection.
    /// </summary>
    /// <value>The range with the lowest <see cref="RangeItem.Start"/> and <see cref="RangeItem.End"/> values or <see langword="null"/> if this collection is empty.</value>
    public RangeItem? First { get; private set; }

    /// <summary>
    /// Gets the last range in the ordered collection.
    /// </summary>
    /// <value>The range with the higest <see cref="RangeItem.Start"/> and <see cref="RangeItem.End"/> values or <see langword="null"/> if this collection is empty.</value>
    public RangeItem? Last { get; private set; }

    bool IList.IsReadOnly => true;

    bool IList.IsFixedSize => false;

    bool ICollection.IsSynchronized => true;

    public object SyncRoot { get; } = new();

    bool ICollection<RangeItem>.IsReadOnly => throw new NotImplementedException();

    /// <summary>
    /// Initializes a new <c>SequentialRangeSet</c> object.
    /// </summary>
    /// <param name="accessors">The object that is used to compare and manipulate values of type <typeparamref name="T"/>.</param>
    public SequentialRangeSet(IRangeSequenceAccessors<T> accessors)
    {
        ArgumentNullException.ThrowIfNull(accessors);
        Accessors = accessors;
    }

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
    /// <exception cref="ArgumentOutOfRangeException">The specified <paramref name="item"/> had a different <see cref="IRangeSequenceAccessors{T}"/> object
    /// which caused value comparisons to be interpreted differently, resulted in a start value that was considered to be larger than the end value, according to
    /// the current <see cref="Accessors"/> object.</exception>
    /// <exception cref="InvalidOperationException">The specified <paramref name="item"/> overlaps an existing range or is directly adjacent to an existing range,
    /// and could nto be added.</exception>
    public void Add(RangeItem item)
    {
        Monitor.Enter(SyncRoot);
        try { RangeItem.Add(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    int IList.Add(object? value) => throw new NotSupportedException();

    public void Clear() => RangeItem.Clear(this);

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

    /// <summary>
    /// Returns a value indicating whether the item exists in the current collection.
    /// </summary>
    /// <param name="item">The item to look for.</param>
    /// <returns><see langword="true"/> if <paramref name="item"/> has been added to the current collection; otherwise <see langword="false"/>.</returns>
    public bool Contains(RangeItem item) => RangeItem.Contains(item, this);

    bool IList.Contains(object? value) => (value is T item) ? RangeItem.Contains(item, this) : value is RangeItem range && RangeItem.Contains(range, this);

    void ICollection<RangeItem>.CopyTo(RangeItem[] array, int arrayIndex) => RangeItem.GetRanges(this).ToList().CopyTo(array, arrayIndex);

    void ICollection.CopyTo(Array array, int index) => RangeItem.GetRanges(this).ToArray().CopyTo(array, index);
    
    /// <summary>
    /// Gets the number of distinct value ranges.
    /// </summary>
    /// <returns>The number of distinct value ranges</returns>
    public int Count()
    {
        var count = 0;
        Monitor.Enter(SyncRoot);
        try
        {
            for (var item = First; item is not null; item = item.Next) count++;
        }
        finally { Monitor.Exit(SyncRoot); }
        return count;
    }

    /// <summary>
    /// Gets all values from all ranges.
    /// </summary>
    /// <returns>An enumeration of values from all ranges.</returns>
    public IEnumerable<T> GetAllValues()
    {
        foreach (RangeItem item in RangeItem.GetRanges(this))
        {
            foreach (var value in item.GetValues())
                yield return value;
        }
    }

    /// <summary>
    /// Gets an enumerator that iterates through all value ranges.
    /// </summary>
    /// <returns>An enumerator that iterates through all value ranges.</returns>
    public IEnumerator<RangeItem> GetEnumerator() => RangeItem.GetRanges(this).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => RangeItem.GetRanges(this).GetEnumerator();

    int IList.IndexOf(object? value) => (value is RangeItem item) ? RangeItem.IndexOf(item, this) : -1;

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

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
            if (item.Owner is null || !ReferenceEquals(item.Owner, this)) return false;
            item.Remove();
        }
        finally { Monitor.Exit(SyncRoot); }
        return true;
    }

    /// <summary>
    /// Removes the lowest-value range in the collection
    /// </summary>
    /// <returns><see langword="true"/> if the first range removed; otherwise <see langword="false"/> if this collection is empty.</returns>
    public bool RemoveFirst()
    {
        Monitor.Enter(SyncRoot);
        try
        {
            var item = First;
            if (item is null) return false;
            item.Remove();
        }
        finally { Monitor.Exit(SyncRoot); }
        return true;
    }

    /// <summary>
    /// Removes the highest-value range in the collection
    /// </summary>
    /// <returns><see langword="true"/> if the last range removed; otherwise <see langword="false"/> if this collection is empty.</returns>
    public bool RemoveLast()
    {
        Monitor.Enter(SyncRoot);
        try
        {
            var item = Last;
            if (item is null) return false;
            item.Remove();
        }
        finally { Monitor.Exit(SyncRoot); }
        return true;
    }

    void IList.Remove(object? value) => throw new NotSupportedException();

    void IList.RemoveAt(int index) => throw new NotSupportedException();
}