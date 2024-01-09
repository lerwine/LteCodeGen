using System.Collections;
using static TestDataGeneration.SequentialRangeSet;

namespace TestDataGeneration;
public partial class SequentialRangeSet<T> : ICollection<SequentialRangeSet<T>.RangeItem>, IReadOnlyList<SequentialRangeSet<T>.RangeItem>, IList
    where T : struct
{
    private object _changeToken = new();

    private const string ErrorMessage_SequentialRangeSetChanged = $"{nameof(SequentialRangeSet<T>)} has changed.";

    RangeItem IReadOnlyList<RangeItem>.this[int index] => GetItemAt(index, this);

    object? IList.this[int index] { get => GetItemAt(index, this); set => throw new NotSupportedException(); }

    public IRangeSequenceAccessors<T> Accessors { get; }

    int IReadOnlyCollection<RangeItem>.Count => Count();

    int ICollection<RangeItem>.Count => Count();

    int ICollection.Count => Count();

    public RangeItem? First { get; private set; }

    bool IList.IsReadOnly => true;

    bool IList.IsFixedSize => false;

    bool ICollection.IsSynchronized => true;

    public RangeItem? Last { get; private set; }

    public object SyncRoot { get; } = new();

    bool ICollection<RangeItem>.IsReadOnly => throw new NotImplementedException();

    public SequentialRangeSet(IRangeSequenceAccessors<T> accessors)
    {
        ArgumentNullException.ThrowIfNull(accessors);
        Accessors = accessors;
    }

    public bool Add(T value)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Add(value, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Add(T start, T end)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Add(start, end, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    public void Add(RangeItem item)
    {
        Monitor.Enter(SyncRoot);
        try { RangeItem.Add(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    int IList.Add(object? value) => throw new NotSupportedException();

    public void Clear() => RangeItem.Clear(this);

    public bool Contains(T item) => RangeItem.Contains(item, this);

    public bool Contains(RangeItem item) => RangeItem.Contains(item, this);

    bool IList.Contains(object? value) => (value is T item) ? RangeItem.Contains(item, this) : value is RangeItem range && RangeItem.Contains(range, this);

    void ICollection<RangeItem>.CopyTo(RangeItem[] array, int arrayIndex) => RangeItem.GetRanges(this).ToList().CopyTo(array, arrayIndex);

    void ICollection.CopyTo(Array array, int index) => RangeItem.GetRanges(this).ToArray().CopyTo(array, index);

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

    public IEnumerable<T> GetAllValues()
    {
        foreach (RangeItem item in RangeItem.GetRanges(this))
        {
            foreach (var value in item.GetValues())
                yield return value;
        }
    }

    public IEnumerable<(T Start, T End)> GetAvailableRanges()
    {
        object changeToken;
        Monitor.Enter(SyncRoot);
        try { changeToken = _changeToken; }
        finally { Monitor.Exit(SyncRoot); }
        if (TryGetFirstAvailableRange(out T start, out T end, out RangeItem? next))
        {
            yield return (start, end);
            while (next is not null)
            {
                if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException(ErrorMessage_SequentialRangeSetChanged);
                if (!next.TryGetNextAvailableRange(out start, out end, out next)) break;
                yield return (start, end);
            }
        }
    }

    public IEnumerator<RangeItem> GetEnumerator() => RangeItem.GetRanges(this).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => RangeItem.GetRanges(this).GetEnumerator();

    int IList.IndexOf(object? value) => (value is RangeItem item) ? RangeItem.IndexOf(item, this) : -1;

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

    public bool Remove(T item)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Remove(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Remove(T start, T end)
    {
        Monitor.Enter(SyncRoot);
        try { return RangeItem.Remove(start, end, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Remove(RangeItem item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (item.Owner is null || !ReferenceEquals(item.Owner, this)) return false;
            item.Remove();
            return true;
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    void IList.Remove(object? value) => throw new NotSupportedException();

    void IList.RemoveAt(int index) => throw new NotSupportedException();

    // /// <summary>
    // /// Tries to find the first item that includes or is greater than a specified value.
    // /// </summary>
    // /// <param name="value">The value to search for.</param>
    // /// <param name="previous">Returns the last <see cref="RangeItem"/> where <see cref="RangeItem.End"/> is less than <paramref name="value"/> or <see langword="null"/> if <see cref="Last"/> is null.</param>
    // /// <param name="result">Returns the first <see cref="RangeItem"/> where <see cref="RangeItem.End"/> is not less than <paramref name="value"/> or <see langword="null"/>
    // /// if <paramref name="value"/> is greater than all existing <see cref="RangeItem.End"/> values.</param>
    // /// <param name="includesValue"><see langword="true"/> if <paramref name="result"/> includes the <paramref name="value"/>; otherwise, <see langword="false"/>.</param>
    // /// <returns><see langword="true"/> if <paramref name="result"/> includes or is less than the <paramref name="value"/>; otherwise, <see langword="false"/>.</returns>
    // private bool TryFindFirstIncludingOrAfter(T value, out RangeItem? previous, [NotNullWhen(true)] out RangeItem? result, out bool includesValue)
    // {
    //     previous = null;
    //     for (result = First; result is not null; result = result.Next)
    //     {
    //         int diff = Accessors.Compare(value, result.Start);
    //         if (diff < 0)
    //         {
    //             // (previous is null || value > previous.End) && value < result.Start
    //             includesValue = false;
    //             return true;
    //         }
    //         if (diff == 0 || Accessors.Compare(value, result.End) <= 0)
    //         {
    //             // result.Contains(value)
    //             includesValue = true;
    //             return true;
    //         }
    //         previous = result;
    //     }
    //     // (previous is null || value > previous.End) && result is null
    //     includesValue = false;
    //     return false;
    // }

    // private bool TryFindFirstIncludingOrAfter(T value, [NotNullWhen(true)] out RangeItem? result, out bool equalsExtent, out bool extentIsEnd)
    // {
    //     for (result = First; result is not null; result = result.Next)
    //     {
    //         int diff = Accessors.Compare(value, result.Start);
    //         if (diff < 0)
    //         {
    //             equalsExtent = extentIsEnd = false;
    //             return true;
    //         }
    //         if (diff == 0)
    //         {
    //             extentIsEnd = false;
    //             equalsExtent = true;
    //         }
    //         if ((diff = Accessors.Compare(value, result.End)) < 0)
    //         {
    //             equalsExtent = false;
    //             extentIsEnd = true;
    //             return true;
    //         }
    //         if (diff == 0)
    //         {
    //             equalsExtent = extentIsEnd = true;
    //             return true;
    //         }
    //     }
    //     // (previous is null || value > previous.End) && result is null
    //     equalsExtent = extentIsEnd = false;
    //     return false;
    // }

    // /// <summary>
    // /// Tries to get the next item including the specified value.
    // /// </summary>
    // /// <param name="value">The value to look for.</param>
    // /// <param name="start">The starting range.</param>
    // /// <param name="result">The <see cref="RangeItem"/> containing <paramref name="value"/> or the last <see cref="RangeItem"/> where <see cref="RangeItem.End"/> is less than <paramref name="value"/>.</param>
    // /// <returns><see langword="true"/> if <paramref name="result"/> includes contains <paramref name="value"/>; otherwise, <see langword="false"/> if <see cref="RangeItem.End"/> is less than <paramref name="value"/>.</returns>
    // private bool TryFindNextIncludingOrBefore(T value, RangeItem start, out RangeItem result)
    // {

    //     result = start;
    //     int diff = Accessors.Compare(value, result.End);
    //     if (diff == 0) return true; // result.Contains(value)
    //     if (diff < 0)
    //     {
    //         if (Accessors.Compare(value, result.Start) < 0) throw new InvalidOperationException();
    //         // result.Contains(value)
    //         return true;
    //     }


    //     for (var next = result.Next; next is not null; next = next.Next)
    //     {
    //         if ((diff = Accessors.Compare(value, next.End)) == 0)
    //         {
    //             // result.Contains(value)
    //             result = next;
    //             return true;
    //         }
    //         if (diff < 0)
    //         {
    //             if (Accessors.Compare(value, next.Start) < 0) return false; // value > result.End
    //             result = next;
    //             // result.Contains(value)
    //             return true;
    //         }
    //         result = next;
    //     }
    //     // value > result.End
    //     return false;
    // }

    public bool TryGetFirstAvailableRange(out T start, out T end, out RangeItem? next)
    {
        next = First;
        if (next is not null)
        {
            if (Accessors.CanInsert(Accessors.MinValue, next.Start))
            {
                start = Accessors.MinValue;
                end = Accessors.GetDecrementedValue(next.Start, 2);
                return true;
            }
            return next.TryGetNextAvailableRange(out start, out end, out next);
        }
        start = Accessors.MinValue;
        end = Accessors.MaxValue;
        return true;
    }

    // internal bool TryGetRangeDisposition(T rangeStart, T rangeEnd, [NotNullWhen(true)] out RangeItem? startItem, out RangeValueDisposition startDisposition,
    //     [NotNullWhen(true)] out RangeItem? endItem, out RangeValueDisposition endDisposition)
    // {
    //     int diff = Accessors.Compare(rangeStart, rangeEnd);
    //     if (diff > 0) throw new ArgumentOutOfRangeException(nameof(rangeStart), $"{nameof(rangeStart)} cannot be greater than {nameof(rangeEnd)}.");
    //     if (diff == 0)
    //     {
    //         var result = TryGetValueDisposition(rangeStart, out startItem, out startDisposition);
    //         endItem = startItem;
    //         endDisposition = startDisposition;
    //         return result;
    //     }
    //     startDisposition = RangeValueDisposition.AfterEnd;
    //     if ((startItem = First) is null)
    //     {
    //         endDisposition = RangeValueDisposition.AfterEnd;
    //         endItem = null;
    //         return false;
    //     }
    //     object changeToken = _changeToken;
    //     do
    //     {
    //         if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
    //         if ((diff = Accessors.Compare(rangeStart, startItem.Start)) < 0)
    //         {
    //             startDisposition = Accessors.IsSequentiallyAdjacent(rangeStart, startItem.Start) ? RangeValueDisposition.AdjacentToStart : RangeValueDisposition.BeforeStart;
    //             break;
    //         }
    //         if (diff == 0)
    //         {
    //             startDisposition = RangeValueDisposition.SameAsStart;
    //             break;
    //         }
    //         if (!startItem.IsSingleValue)
    //         {
    //             if ((diff = Accessors.Compare(rangeStart, startItem.End)) < 0)
    //             {
    //                 startDisposition = RangeValueDisposition.BetweenStartAndEnd;
    //                 break;
    //             }
    //             if (diff == 0)
    //             {
    //                 startDisposition = RangeValueDisposition.SameAsEnd;
    //                 break;
    //             }
    //         }
    //         if (Accessors.IsSequentiallyAdjacent(rangeStart, startItem.End))
    //         {
    //             startDisposition = RangeValueDisposition.AdjacentToEnd;
    //             break;
    //         }
    //     }
    //     while ((startItem = startItem!.Next) is not null);
    //     if (startItem is not null)
    //     {
    //         endDisposition = RangeValueDisposition.AfterEnd;
    //         endItem = startItem;
    //         switch (startDisposition)
    //         {
    //             case RangeValueDisposition.BeforeStart:
    //                 if ((diff = Accessors.Compare(rangeEnd, endItem.Start)) < 0)
    //                     endDisposition = Accessors.IsSequentiallyAdjacent(rangeEnd, endItem.Start) ? RangeValueDisposition.AdjacentToStart : RangeValueDisposition.BeforeStart;
    //                 else if (diff == 0)
    //                     endDisposition = RangeValueDisposition.SameAsStart;
    //                 else if (endItem.IsSingleValue)
    //                 {
    //                     if (Accessors.IsSequentiallyAdjacent(rangeEnd, endItem.End)) startDisposition = RangeValueDisposition.AdjacentToEnd;
    //                 }
    //                 else if ((diff = Accessors.Compare(rangeEnd, endItem.End)) < 0)
    //                     endDisposition = RangeValueDisposition.BetweenStartAndEnd;
    //                 else if (diff == 0)
    //                     endDisposition = RangeValueDisposition.SameAsEnd;
    //                 break;
    //             case RangeValueDisposition.AdjacentToStart:
    //                 if (Accessors.Compare(rangeEnd, endItem.Start) == 0)
    //                     endDisposition = RangeValueDisposition.SameAsStart;
    //                 else if (endItem.IsSingleValue)
    //                 {
    //                     if (Accessors.IsSequentiallyAdjacent(rangeEnd, endItem.End)) startDisposition = RangeValueDisposition.AdjacentToEnd;
    //                 }
    //                 else if ((diff = Accessors.Compare(rangeEnd, endItem.End)) < 0)
    //                     endDisposition = RangeValueDisposition.BetweenStartAndEnd;
    //                 else if (diff == 0)
    //                     endDisposition = RangeValueDisposition.SameAsEnd;
    //                 break;
    //             case RangeValueDisposition.BetweenStartAndEnd:
    //                 if ((diff = Accessors.Compare(rangeEnd, endItem.End)) < 0)
    //                     endDisposition = RangeValueDisposition.BetweenStartAndEnd;
    //                 else if (diff == 0)
    //                     endDisposition = RangeValueDisposition.SameAsEnd;
    //                 break;
    //         }
    //         if (endDisposition == RangeValueDisposition.AfterEnd)
    //         {
    //             while (endItem.Next is not null)
    //             {
    //                 endItem = endItem.Next;
    //                 if ((diff = Accessors.Compare(rangeEnd, endItem.Start)) < 0)
    //                 {
    //                     endDisposition = Accessors.IsSequentiallyAdjacent(rangeEnd, endItem.Start) ? RangeValueDisposition.AdjacentToStart : RangeValueDisposition.BeforeStart;
    //                     break;
    //                 }
    //                 if (diff == 0)
    //                 {
    //                     endDisposition = RangeValueDisposition.SameAsStart;
    //                     break;
    //                 }
    //                 if (endItem.IsSingleValue)
    //                 {
    //                     if (Accessors.IsSequentiallyAdjacent(rangeEnd, endItem.End))
    //                     {
    //                         startDisposition = RangeValueDisposition.AdjacentToEnd;
    //                         break;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     if ((diff = Accessors.Compare(rangeEnd, endItem.End)) < 0)
    //                     {
    //                         endDisposition = RangeValueDisposition.BetweenStartAndEnd;
    //                         break;
    //                     }
    //                     if (diff == 0)
    //                     {
    //                         endDisposition = RangeValueDisposition.SameAsEnd;
    //                         break;
    //                     }
    //                 }
    //             }
    //         }
    //         return true;
    //     }
    //     if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
    //     startItem = endItem = Last;
    //     endDisposition = startDisposition;
    //     return startItem is not null;
    // }

    // internal bool TryGetValueDisposition(T value, [NotNullWhen(true)] out RangeItem? item, out RangeValueDisposition disposition)
    // {
    //     if ((item = First) is null)
    //     {
    //         disposition = RangeValueDisposition.AfterEnd;
    //         return false;
    //     }
    //     object changeToken = _changeToken;
    //     do
    //     {
    //         if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
    //         int diff = Accessors.Compare(value, item.Start);
    //         if (diff < 0)
    //         {
    //             disposition = Accessors.IsSequentiallyAdjacent(value, item.Start) ? RangeValueDisposition.AdjacentToStart : RangeValueDisposition.BeforeStart;
    //             return true;
    //         }
    //         if (diff == 0)
    //         {
    //             disposition = RangeValueDisposition.SameAsStart;
    //             return true;
    //         }
    //         if (!item.IsSingleValue)
    //         {
    //             if ((diff = Accessors.Compare(value, item.End)) < 0)
    //             {
    //                 disposition = RangeValueDisposition.BetweenStartAndEnd;
    //                 return true;
    //             }
    //             if (diff == 0)
    //             {
    //                 disposition = RangeValueDisposition.SameAsEnd;
    //                 return true;
    //             }
    //         }
    //         if (Accessors.IsSequentiallyAdjacent(value, item.End))
    //         {
    //             disposition = RangeValueDisposition.AdjacentToEnd;
    //             return true;
    //         }
    //     }
    //     while ((item = item!.Next) is not null);
    //     if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
    //     item = Last;
    //     disposition = RangeValueDisposition.AfterEnd;
    //     return item is not null;
    // }
}

// /// <summary>
// /// Indicates the disposition of a value in relation to a reference range item.
// /// </summary>
// internal enum RangeValueDisposition
// {
//     /// <summary>
//     /// Target value is more than one increment less than <see cref="SequentialRangeSet{T}.RangeItem.Start"/>.
//     /// </summary>
//     BeforeStart,

//     /// <summary>
//     /// Target value is one increment less than <see cref="SequentialRangeSet{T}.RangeItem.Start"/>.
//     /// </summary>
//     /// <remarks>This also indicates that either <see cref="SequentialRangeSet{T}.RangeItem.Previous"/> is null or the target value is more than one increment
//     /// greater than the <see cref="SequentialRangeSet{T}.RangeItem.End"/> of the <see cref="SequentialRangeSet{T}.RangeItem.Previous"/> item.</remarks>
//     AdjacentToStart,

//     /// <summary>
//     /// Target value is the same as <see cref="SequentialRangeSet{T}.RangeItem.Start"/>.
//     /// </summary>
//     SameAsStart,

//     /// <summary>
//     /// Target value at least one increment more than <see cref="SequentialRangeSet{T}.RangeItem.Start"/> and one increment less than <see cref="SequentialRangeSet{T}.RangeItem.End"/>.
//     /// </summary>
//     /// <remarks>This also indicates that either <see cref="SequentialRangeSet{T}.RangeItem.IsSingleValue"/> is <see langword="false"/>.</remarks>
//     BetweenStartAndEnd,

//     /// <summary>
//     /// Target value is the same as <see cref="SequentialRangeSet{T}.RangeItem.End"/>.
//     /// </summary>
//     /// <remarks>This also indicates that either <see cref="SequentialRangeSet{T}.RangeItem.IsSingleValue"/> is <see langword="false"/>.</remarks>
//     SameAsEnd,

//     /// <summary>
//     /// Target value is one increment more than <see cref="SequentialRangeSet{T}.RangeItem.End"/>.
//     /// </summary>
//     /// <remarks>This also indicates that <see cref="SequentialRangeSet{T}.RangeItem.IsSingleValue"/> is <see langword="false"/>,
//     /// and either <see cref="SequentialRangeSet{T}.RangeItem.Next"/> is null or the target value is more than one increment
//     /// less than the <see cref="SequentialRangeSet{T}.RangeItem.Start"/> of the <see cref="SequentialRangeSet{T}.RangeItem.Next"/> item.</remarks>
//     AdjacentToEnd,

//     /// <summary>
//     /// Target value is more than one increment greater than <see cref="SequentialRangeSet{T}.RangeItem.End"/>.
//     /// </summary>
//     AfterEnd
// }
