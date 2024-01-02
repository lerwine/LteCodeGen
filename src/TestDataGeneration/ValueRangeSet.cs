using System.Collections;

namespace TestDataGeneration;

/// <summary>
/// Represents a set of ordered value ranges.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
public partial class ValueRangeSet<T> : ISet<T>, IReadOnlyList<ValueRangeSet<T>.ValueRange>, IReadOnlyCollection<ValueRangeSet<T>.ValueRange>, IList, ICollection
    where T : struct
{
    private readonly ISequentalValueAccessors<T> _valueAccessors;
    private object _changeToken = new();

    bool ICollection<T>.IsReadOnly => false;

    /// <summary>
    /// Gets the first sequential <see cref="ValueRange"/> or <see langword="null"/> if this set is empty.
    /// </summary>
    public ValueRange? First { get; private set; }

    /// <summary>
    /// Gets the last sequential <see cref="ValueRange"/> or <see langword="null"/> if this set is empty.
    /// </summary>
    public ValueRange? Last { get; private set; }

    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="ValueRangeSet{T}"/>.
    /// </summary>
    public object SyncRoot { get; } = new();

    /// <summary>
    /// Gets the total number of values in all range sets.
    /// </summary>
    /// <returns>The total numbger of values in all <see cref="ValueRange">value ranges</see>.</returns>
    int ICollection<T>.Count => Count();

    int IReadOnlyCollection<ValueRangeSet<T>.ValueRange>.Count => RangeCount();

    bool IList.IsFixedSize => false;

    bool IList.IsReadOnly => true;

    int ICollection.Count => Count();

    bool ICollection.IsSynchronized => true;

    /// <summary>
    /// Gets the range at the specified index.
    /// </summary>
    /// <param name="index">The index of the range to get.</param>
    /// <returns>The <see cref="ValueRange"/> at the specified order index.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than <c>0</c> or is not less than the total number of ranges in the current range set.</exception>
    public ValueRange GetRangeAt(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        Monitor.Enter(SyncRoot);
        try
        {
            int i = -1;
            for (var item = First; item is not null; item = item.Next)
            {
                i++;
                if (i == index) return item;
            }
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    ValueRangeSet<T>.ValueRange IReadOnlyList<ValueRangeSet<T>.ValueRange>.this[int index] => GetRangeAt(index);

    object? IList.this[int index] { get => GetRangeAt(index); set => throw new NotSupportedException(); }

    public ValueRangeSet(ISequentalValueAccessors<T> valueAccessors)
    {
        ArgumentNullException.ThrowIfNull(valueAccessors);
        _valueAccessors = valueAccessors;
    }
    
    bool ISet<T>.Add(T item) => Include(item);

    void ICollection<T>.Add(T item) => Include(item);

    int IList.Add(object? value) => throw new NotSupportedException();

    /// <summary>
    /// Removes all value ranges from the current range set.
    /// </summary>
    public void Clear()
    {
        Monitor.Enter(SyncRoot);
        try { ValueRange.Clear(this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Checks whether a value is included in any of the value ranges of the current range set.
    /// </summary>
    /// <param name="item">The value to look for.</param>
    /// <returns><see langword="true"/> if <paramref name="item"/> exists in any of the value ranges; otherwise, <see langword="false"/>.</returns>
    public bool Contains(T item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (Last is not null)
            {
                int d = _valueAccessors.Compare(item, Last.End);
                if (d < 0)
                {
                    if ((d = _valueAccessors.Compare(item, Last.Start)) < 0)
                    {
                        var range = First!;
                        do
                        {
                            if ((d = _valueAccessors.Compare(item, range.Start)) < 0) break;
                            if ((range.Count == 1) ? d == 0 : _valueAccessors.Compare(item, range.End) <= 0) return true;
                        }
                        while ((range = range.Next)?.Next is not null);
                    }
                    else
                        return (Last.Count == 1) ? d == 0 : _valueAccessors.Compare(item, Last.End) <= 0;
                }
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    bool IList.Contains(object? value)
    {
        if (value is not ValueRange item) return false;
        Monitor.Enter(SyncRoot);
        try
        {
            if (Last is not null)
            {
                int d = _valueAccessors.Compare(item.Start, Last.End);
                if (d < 0)
                {
                    if ((d = _valueAccessors.Compare(item.Start, Last.Start)) < 0)
                    {
                        var range = First!;
                        if (item.Count == 1)
                        {
                            do
                            {
                                if ((d = _valueAccessors.Compare(item.Start, range.Start)) < 0) break;
                                if (d == 0) return range.Count == 1;
                            }
                            while ((range = range.Next)?.Next is not null);
                        }
                        else
                            do
                            {
                                if ((d = _valueAccessors.Compare(item.Start, range.Start)) < 0) break;
                                if (d == 0) return range.Count > 1 && _valueAccessors.Compare(item.End, range.End) == 0;
                            }
                            while ((range = range.Next)?.Next is not null);
                    }
                    else
                        return d == 0 && _valueAccessors.Compare(item.End, Last.End) == 0;
                }
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        Monitor.Enter(SyncRoot);
        try { ValueRange.ToList(this).CopyTo(array, arrayIndex); }
        finally { Monitor.Exit(SyncRoot); }
    }

    void ICollection.CopyTo(Array array, int index)
    {
        Monitor.Enter(SyncRoot);
        try { ValueRange.ToList(this).ToArray().CopyTo(array, index); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Gets the total number of values included in all value ranges.
    /// </summary>
    /// <returns>The total number of values included in all value ranges.</returns>
    public int Count()
    {
        int result = 0;
        Monitor.Enter(SyncRoot);
        try
        {
            for (var node = First; node is not null; node = node.Next)
                result += node.Count;
        }
        finally { Monitor.Exit(SyncRoot); }
        return result;
    }
    
    void ISet<T>.ExceptWith(IEnumerable<T> other) => ExcludeAll(other);

    /// <summary>
    /// Excludes a value from the current set of ranges.
    /// </summary>
    /// <param name="item">The value to exclude.</param>
    /// <returns><see langword="true"/> if the <paramref name="item"/> was removed from the current set of ranges; otherwise, <see langword="false"/> if the value was already not included in any ranges.</returns>
    public bool Exclude(T item)
    {
        Monitor.Enter(SyncRoot);
        try { return ValueRange.Exclude(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Excludes values from the current set of ranges.
    /// </summary>
    /// <param name="collection">The values to exclude.</param>
    /// <returns>The values that were removed from the range sets.</returns>
    public IEnumerable<T> ExcludeAll(IEnumerable<T> collection)
    {
        if (collection is null) return Enumerable.Empty<T>();
        Monitor.Enter(SyncRoot);
        try { return collection.Where(item => ValueRange.Exclude(item, this)); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Excludes values from the current set of ranges.
    /// </summary>
    /// <param name="collection">The values to exclude.</param>
    /// <param name="notRemoved">The values that did not previously exist in any of the range sets.</param>
    public void ExcludeAll(IEnumerable<T> collection, out IEnumerable<T> notRemoved)
    {
        if (collection is null)
        {
            notRemoved = collection!;
            return;
        }
        Monitor.Enter(SyncRoot);
        try { notRemoved = collection.Where(item => !ValueRange.Exclude(item, this)); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Excludes all matching values from the current set of ranges.
    /// </summary>
    /// <param name="match">The delegate that indicates which values should be removed.</param>
    /// <returns>The values that were removed from the set of ranges.</returns>
    public IEnumerable<T> ExcludeAll(Func<T, bool> match)
    {
        Monitor.Enter(SyncRoot);
        try { return ValueRange.ExcludeAll(match, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Excludes a range of values from the current set of ranges.
    /// </summary>
    /// <param name="startInclusive">The inclusive start value.</param>
    /// <param name="endInclusive">The inclusive end value.</param>
    /// <returns>The inclusive range of values that were actually removed.</returns>
    public (T Start, T End) ExcludeRange(T startInclusive, T endInclusive)
    {
        Monitor.Enter(SyncRoot);
        try { return ValueRange.ExcludeRange(startInclusive, endInclusive, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Returns an enumerator that iterates through all of the values of all of the ranges.
    /// </summary>
    /// <returns>An enumerator that iterates through all of the values of all of the ranges.</returns>
    public IEnumerator<T> GetEnumerator() => new ValueEnumerator(this);

    IEnumerator<ValueRangeSet<T>.ValueRange> IEnumerable<ValueRangeSet<T>.ValueRange>.GetEnumerator() => GetRangeEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => new ValueEnumerator(this);

    /// <summary>
    /// Returns an enumerator that iterates through all of the value ranges.
    /// </summary>
    /// <returns>An enumerator that iterates through all of the value ranges.</returns>
    public IEnumerator<ValueRangeSet<T>.ValueRange> GetRangeEnumerator() => new RangeEnumerator(this);

    /// <summary>
    /// Gets all of the ranges in the current range set.
    /// </summary>
    /// <returns>All of the ranges in the current range set.</returns>
    public IEnumerable<ValueRange> GetRanges()
    {
        using RangeEnumerator rangeEnumerator = new(this);
        while (rangeEnumerator.MoveNext())
            yield return rangeEnumerator.Current;
    }

    /// <summary>
    /// Gets all of the existing values in the specified range.
    /// </summary>
    /// <param name="startInclusive">The inclusive start range value.</param>
    /// <param name="endInclusive">The inclusive end range value.</param>
    /// <returns>All values from <paramref name="startInclusive"/> to <paramref name="endInclusive"/>, inclusively, that existed in any of the range sets.</returns>
    public IEnumerable<T> GetValuesInRange(T startInclusive, T endInclusive)
    {
        Monitor.Enter(SyncRoot);
        try { throw new NotImplementedException(); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Includes a value in the current set of ranges and returns a value to indicate if the value was successfully included in one of the ranges.
    /// </summary>
    /// <param name="item">The value to include in the range set.</param>
    /// <returns><see langword="true"/> if the a new range was added or an existing was expanded; <see langword="false"/> if the value is already included in one of the ranges.</returns>
    public bool Include(T item)
    {
        Monitor.Enter(SyncRoot);
        try { return ValueRange.Include(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }
    
    /// <summary>
    /// Includes the specified values in the current set of ranges and returns the number of values added.
    /// </summary>
    /// <param name="collection">The values ot include in the current range set.</param>
    /// <returns>The number of values added.</returns>
    public int Include(IEnumerable<T> collection)
    {
        Monitor.Enter(SyncRoot);
        try { return collection.Where(item => ValueRange.Include(item, this)).Count(); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Includes the specified values in the current set of ranges and returns the values that were not added.
    /// </summary>
    /// <param name="collection">The values ot include in the current range set.</param>
    /// <param name="notAdded">The values that were not added.</param>
    public void IncludeRange(IEnumerable<T> collection, out IEnumerable<T> notAdded)
    {
        Monitor.Enter(SyncRoot);
        try { notAdded = collection.Where(item => !ValueRange.Include(item, this)); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Includes the specified values in the current set of ranges and returns the values that were added.
    /// </summary>
    /// <param name="collection">The values ot include in the current range set.</param>
    /// <returns>The values that were added.</returns>
    public IEnumerable<T> IncludeRange(IEnumerable<T> collection)
    {
        Monitor.Enter(SyncRoot);
        try { return collection.Where(item => ValueRange.Include(item, this)); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    // Includes a range of values in the current set of ranges.
    /// </summary>
    /// <param name="startInclusive">The inclusive start value.</param>
    /// <param name="endInclusive">The inclusive end value.</param>
    /// <returns><see langword="true"/> if the any values were added; otherwise, <see langword="false"/> if all values in the specified range were already included in an existing range.</returns>
    public bool IncludeRange(T startInclusive, T endInclusive)
    {
        Monitor.Enter(SyncRoot);
        try { return ValueRange.IncludeRange(startInclusive, endInclusive, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    int IList.IndexOf(object? value)
    {
        if (value is not ValueRange item) return -1;
        Monitor.Enter(SyncRoot);
        try
        {
            if (Last is not null)
            {
                int d = _valueAccessors.Compare(item.Start, Last.End);
                if (d < 0)
                {
                    if ((d = _valueAccessors.Compare(item.Start, Last.Start)) < 0)
                    {
                        var range = First!;
                        int index = -1;
                        if (item.Count == 1)
                        {
                            do
                            {
                                index++;
                                if ((d = _valueAccessors.Compare(item.Start, range.Start)) < 0) break;
                                if (d == 0) return (range.Count == 1) ? index : -1;
                            }
                            while ((range = range.Next)?.Next is not null);
                        }
                        else
                            do
                            {
                                index++;
                                if ((d = _valueAccessors.Compare(item.Start, range.Start)) < 0) break;
                                if (d == 0) return (range.Count > 1 && _valueAccessors.Compare(item.End, range.End) == 0) ? index : -1;
                            }
                            while ((range = range.Next)?.Next is not null);
                    }
                    else
                        return (d == 0 && _valueAccessors.Compare(item.End, Last.End) == 0) ? 0 : -1;
                    
                }
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return -1;
    }

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

    /// <summary>
    /// Modifies the current set so that it contains only values that are also in a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    public void IntersectWith(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        Monitor.Enter(SyncRoot);
        try { ValueRange.IntersectWith(other, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Determines whether the current set is a proper (strict) subset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a proper subset of other; otherwise, <see langword="false"/>.</returns>
    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        Monitor.Enter(SyncRoot);
        try
        {
            using IEnumerator<T> enumerator = other.GetEnumerator();
            if (First is null) return enumerator.MoveNext();
            if (!enumerator.MoveNext()) return false;
            int count = 0;
            do
            {
                count++;
                if (Contains(enumerator.Current))
                {
                    while (enumerator.MoveNext()) count++;
                    return count > Count();
                }
            }
            while (enumerator.MoveNext());
            return false;
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Determines whether the current set is a proper (strict) superset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a proper superset of other; otherwise, <see langword="false"/>.</returns>
    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        using IEnumerator<ValueRange> enumerator = GetRangeEnumerator();
        if (!other.Any()) return enumerator.MoveNext();
        if (!enumerator.MoveNext()) return false;
        int count = 0;
        do
        {
            foreach (var value in enumerator.Current)
            {
                count++;
                if (other.Contains(value))
                {
                    while (enumerator.MoveNext()) count++;
                    return count > other.Count();
                }
            }
        }
        while (enumerator.MoveNext());
        return false;
    }

    /// <summary>
    /// Determines whether a set is a subset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a subset of other; otherwise, <see langword="false"/>.</returns>
    public bool IsSubsetOf(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        using IEnumerator<ValueRange> enumerator = GetRangeEnumerator();
        if (!enumerator.MoveNext()) return !other.Any();
        if (!other.Any()) return false;
        do
        {
            if (!enumerator.Current.All(value => other.Contains(value, _valueAccessors))) return false;
        }
        while (enumerator.MoveNext());
        return true;
    }

    /// <summary>
    /// Determines whether the current set is a superset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a superset of other; otherwise, <see langword="false"/>.</returns>
    public bool IsSupersetOf(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        using IEnumerator<T> enumerator = other.GetEnumerator();
        if (!enumerator.MoveNext()) return First is null;
        if (First is null) return false;
        do
        {
            if (!Contains(enumerator.Current)) return false;
        }
        while (enumerator.MoveNext());
        return true;
    }

    /// <summary>
    /// Determines whether the current set of ranges overlaps with the specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set and other share at least one common value; otherwise, <see langword="false"/>.</returns>
    public bool Overlaps(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        using IEnumerator<T> enumerator = other.GetEnumerator();
        if (!enumerator.MoveNext()) return First is null;
        return First is not null && other.Any(Contains);
    }

    /// <summary>
    /// Determines whether an inclusive range of values overlaps with any ranges in the the current set.
    /// </summary>
    /// <param name="startInclusive">The inclusive start range value.</param>
    /// <param name="endInclusive">The inclusive end range value.</param>
    /// <returns><see langword="true"/> if the current set of ranges overlap with <paramref name="startInclusive"/> and <paramref name="endInclusive"/>; otherwise, <see langword="false"/>.</returns>
    public bool Overlaps(T startInclusive, T endInclusive)
    {
        int d = _valueAccessors.Compare(startInclusive, endInclusive);
        if (d > 0) throw new ArgumentOutOfRangeException(nameof(startInclusive));
        if (d == 0) return Contains(startInclusive);
        using IEnumerator<ValueRange> enumerator = GetRangeEnumerator();
        foreach (ValueRange item in GetRanges())
        {
            if ((d = _valueAccessors.Compare(endInclusive, item.Start)) < 0) return false;
            if (d == 0 || _valueAccessors.Compare(startInclusive, item.End) <= 0) return true;
        }
        return false;
    }

    /// <summary>
    /// Gets the number of value ranges in the current set.
    /// </summary>
    /// <returns>The number of value ranges in the current set.</returns>
    public int RangeCount()
    {
        int result = 0;
        Monitor.Enter(SyncRoot);
        try
        {
            for (var node = First; node is not null; node = node.Next)
                result++;
        }
        finally { Monitor.Exit(SyncRoot); }
        return result;
    }

    bool ICollection<T>.Remove(T item) => Exclude(item);

    void IList.Remove(object? value) => throw new NotSupportedException();

    void IList.RemoveAt(int index) => throw new NotSupportedException();

    /// <summary>
    /// Determines whether the current set and the specified collection contain the same elements.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is equal to other; otherwise, <see langword="false"/>.</returns>
    public bool SetEquals(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        using IEnumerator<ValueRange> enumerator = GetRangeEnumerator();
        int count = 0;
        while (enumerator.MoveNext())
        {
            if (!enumerator.Current.All(other.Contains)) return false;
            count += enumerator.Current.Count;
        }
        return count == other.Distinct(_valueAccessors).Count();
    }

    /// <summary>
    /// Modifies the current set so that it contains only elements that are present either in the current set or in the specified collection, but not both.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        Monitor.Enter(SyncRoot);
        try { ValueRange.SymmetricExceptWith(other, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Converts all values in all range sets to a flat list.
    /// </summary>
    /// <returns>A <see cref="List{T}"/> containing all of the values from all of the sets.</returns>
    public List<T> ToList()
    {
        Monitor.Enter(SyncRoot);
        try { return ValueRange.ToList(this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    void ISet<T>.UnionWith(IEnumerable<T> other) => Include(other);

    public class CharSequentialValueAccessors : ComparableSequentialValueAccessors<char>
    {
        public override char MaxValue => char.MaxValue;

        public override char MinValue => char.MinValue;

        public override char Decrement(char value, int count = 1) => (char)(value - count);

        public override int GetRangeCount(char rangeStart, char rangeEnd)
        {
            if (rangeStart > rangeEnd) throw new ArgumentOutOfRangeException(nameof(rangeStart));
            return rangeEnd - rangeStart + 1;
        }

        public override IEnumerable<char> GetValuesInRange(char rangeStart, char rangeEnd)
        {
            if (rangeStart > rangeEnd) yield break;
            var result = rangeStart;
            while (result < rangeEnd)
            {
                yield return result;
                result++;
            }
            yield return rangeEnd;
        }

        public override char Increment(char value, int count = 1) => (char)(value + count);

        public override bool IsInRange(char targetValue, char rangeStart, char rangeEnd) => targetValue >= rangeStart && targetValue <= rangeEnd;

        public override bool IsSequentiallyNext(char precedingValue, char nextValue) => precedingValue < char.MaxValue && (precedingValue + 1) == nextValue;
    }

    public class ByteSequentialValueAccessors : ComparableSequentialValueAccessors<byte>
    {
        public override byte MaxValue => byte.MaxValue;

        public override byte MinValue => byte.MinValue;

        public override byte Decrement(byte value, int count = 1) => (byte)(value - count);

        public override int GetRangeCount(byte rangeStart, byte rangeEnd)
        {
            if (rangeStart > rangeEnd) throw new ArgumentOutOfRangeException(nameof(rangeStart));
            return rangeEnd - rangeStart + 1;
        }

        public override IEnumerable<byte> GetValuesInRange(byte rangeStart, byte rangeEnd)
        {
            if (rangeStart > rangeEnd) yield break;
            var result = rangeStart;
            while (result < rangeEnd)
            {
                yield return result;
                result++;
            }
            yield return rangeEnd;
        }

        public override byte Increment(byte value, int count = 1) => (byte)(value + count);

        public override bool IsInRange(byte targetValue, byte rangeStart, byte rangeEnd) => targetValue >= rangeStart && targetValue <= rangeEnd;

        public override bool IsSequentiallyNext(byte precedingValue, byte nextValue) => precedingValue < byte.MaxValue && (precedingValue + 1) == nextValue;
    }

    public class SByteSequentialValueAccessors : ComparableSequentialValueAccessors<sbyte>
    {
        public override sbyte MaxValue => sbyte.MaxValue;

        public override sbyte MinValue => sbyte.MinValue;

        public override sbyte Decrement(sbyte value, int count = 1) => (sbyte)(value - count);

        public override int GetRangeCount(sbyte rangeStart, sbyte rangeEnd)
        {
            if (rangeStart > rangeEnd) throw new ArgumentOutOfRangeException(nameof(rangeStart));
            return rangeEnd - rangeStart + 1;
        }

        public override IEnumerable<sbyte> GetValuesInRange(sbyte rangeStart, sbyte rangeEnd)
        {
            if (rangeStart > rangeEnd) yield break;
            var result = rangeStart;
            while (result < rangeEnd)
            {
                yield return result;
                result++;
            }
            yield return rangeEnd;
        }

        public override sbyte Increment(sbyte value, int count = 1) => (sbyte)(value + count);

        public override bool IsInRange(sbyte targetValue, sbyte rangeStart, sbyte rangeEnd) => targetValue >= rangeStart && targetValue <= rangeEnd;

        public override bool IsSequentiallyNext(sbyte precedingValue, sbyte nextValue) => precedingValue < sbyte.MaxValue && (precedingValue + 1) == nextValue;
    }

    public class Int16SequentialValueAccessors : ComparableSequentialValueAccessors<short>
    {
        public override short MaxValue => short.MaxValue;

        public override short MinValue => short.MinValue;

        public override short Decrement(short value, int count = 1) => (short)(value - count);

        public override int GetRangeCount(short rangeStart, short rangeEnd)
        {
            if (rangeStart > rangeEnd) throw new ArgumentOutOfRangeException(nameof(rangeStart));
            return rangeEnd - rangeStart + 1;
        }

        public override IEnumerable<short> GetValuesInRange(short rangeStart, short rangeEnd)
        {
            if (rangeStart > rangeEnd) yield break;
            var result = rangeStart;
            while (result < rangeEnd)
            {
                yield return result;
                result++;
            }
            yield return rangeEnd;
        }

        public override short Increment(short value, int count = 1) => (short)(value + count);

        public override bool IsInRange(short targetValue, short rangeStart, short rangeEnd) => targetValue >= rangeStart && targetValue <= rangeEnd;

        public override bool IsSequentiallyNext(short precedingValue, short nextValue) => precedingValue < short.MaxValue && (precedingValue + 1) == nextValue;
    }

    public class UInt16SequentialValueAccessors : ComparableSequentialValueAccessors<ushort>
    {
        public override ushort MaxValue => ushort.MaxValue;

        public override ushort MinValue => ushort.MinValue;

        public override ushort Decrement(ushort value, int count = 1) => (ushort)(value - count);

        public override int GetRangeCount(ushort rangeStart, ushort rangeEnd)
        {
            if (rangeStart > rangeEnd) throw new ArgumentOutOfRangeException(nameof(rangeStart));
            return rangeEnd - rangeStart + 1;
        }

        public override IEnumerable<ushort> GetValuesInRange(ushort rangeStart, ushort rangeEnd)
        {
            if (rangeStart > rangeEnd) yield break;
            var result = rangeStart;
            while (result < rangeEnd)
            {
                yield return result;
                result++;
            }
            yield return rangeEnd;
        }

        public override ushort Increment(ushort value, int count = 1) => (ushort)(value + count);

        public override bool IsInRange(ushort targetValue, ushort rangeStart, ushort rangeEnd) => targetValue >= rangeStart && targetValue <= rangeEnd;

        public override bool IsSequentiallyNext(ushort precedingValue, ushort nextValue) => precedingValue < ushort.MaxValue && (precedingValue + 1) == nextValue;
    }

    public class Int32SequentialValueAccessors : ComparableSequentialValueAccessors<int>
    {
        public override int MaxValue => int.MaxValue;

        public override int MinValue => int.MinValue;

        public override int Decrement(int value, int count = 1) => value - count;

        public override int GetRangeCount(int rangeStart, int rangeEnd)
        {
            if (rangeStart > rangeEnd) throw new ArgumentOutOfRangeException(nameof(rangeStart));
            return rangeEnd - rangeStart + 1;
        }

        public override IEnumerable<int> GetValuesInRange(int rangeStart, int rangeEnd)
        {
            if (rangeStart > rangeEnd) yield break;
            var result = rangeStart;
            while (result < rangeEnd)
            {
                yield return result;
                result++;
            }
            yield return rangeEnd;
        }

        public override int Increment(int value, int count = 1) => value + count;

        public override bool IsInRange(int targetValue, int rangeStart, int rangeEnd) => targetValue >= rangeStart && targetValue <= rangeEnd;

        public override bool IsSequentiallyNext(int precedingValue, int nextValue) => precedingValue < int.MaxValue && (precedingValue + 1) == nextValue;
    }
}
