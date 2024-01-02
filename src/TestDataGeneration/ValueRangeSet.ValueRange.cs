using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration
{
    public partial class ValueRangeSet<T> where T : struct
    {
        public class ValueRange : IEnumerable<T>, IEquatable<ValueRange>
        {
            private readonly ValueRangeSet<T> _set;
            private IEnumerable<T>? _values;


            public T Start { get; private set; }

            public T End { get; private set; }

            public ValueRange? Previous { get; private set; }

            public ValueRange? Next { get; private set; }

            public int Count { get; private set; }

            private ValueRange(ValueRangeSet<T> set, T value)
            {
                _set = set;
                _values = Enumerable.Repeat(value, 1);
                Start = End = value;
                Count = 1;
            }

            public ValueRange(ValueRangeSet<T> set, T startInclusive, T endInclusive)
            {
                _set = set;
                if ((Count = set._getCountInRange(startInclusive, endInclusive)) < 2) throw new InvalidOperationException();
                if (Count == 2) _values = new T[] { startInclusive, endInclusive };
                Start = startInclusive;
                End = endInclusive;
            }

            public bool Equals(ValueRangeSet<T>.ValueRange? other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;
                return _set._equalityComparer.Equals(Start, other.Start) && _set._equalityComparer.Equals(End, other.End);
            }

            public override bool Equals(object? obj)
            {
                if (obj is not ValueRangeSet<T>.ValueRange other) return false;
                if (ReferenceEquals(this, other)) return true;
                return _set._equalityComparer.Equals(Start, other.Start) && _set._equalityComparer.Equals(End, other.End);
            }

            public IEnumerator<T> GetEnumerator() => (_values ?? _set._getValuesInRange(Start, End)).GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public override int GetHashCode()
            {
                HashCode hashCode = new();
                hashCode.Add(Start, _set._equalityComparer);
                hashCode.Add(End, _set._equalityComparer);
                return hashCode.ToHashCode();
            }

            public override string ToString() => (Count == 1) ? $"[{Start}]" : $"[{Start}..{End}]";

            // value == range.Start
            // value == range.End
            internal static bool TryFind(T value, ValueRangeSet<T> set, [NotNullWhen(true)] out ValueRange? range, out bool? isEnd)
            {
                var comparer = set._sortComparer;
                for (range = set.First; range is not null; range = range.Next)
                {
                    int d = comparer.Compare(value, range.Start);
                    if (d < 0) break;
                    if (d == 0)
                    {
                        isEnd = false;
                        return true;
                    }
                    if ((d = comparer.Compare(value, range.End)) == 0)
                    {
                        isEnd = true;
                        return true;
                    }
                    if (d < 0)
                    {
                        isEnd = null;
                        return true;
                    }
                }
                isEnd = null;
                return false;
            }

            private static bool Find(T value, ValueRangeSet<T> set, [NotNullWhen(true)] out ValueRange? range, out int comparison)
            {
                var comparer = set._sortComparer;
                var isImmediatelyPreceding = set._isImmediatelyPreceding;
                var isImmediatelyFollowing = set._isImmediatelyFollowing;
                range = set.First;
                if (range is null)
                {
                    comparison = -1;
                    return false;
                }
                if ((comparison = comparer.Compare(value, range.End)) == 0)
                    return true;
                if (comparison < 0)
                {
                    if ((comparison = comparer.Compare(value, range.Start)) >= 0)
                        return true;
                    comparison = isImmediatelyPreceding(value, range.Start) ? -1 : -2;
                    return false;
                }
                if (isImmediatelyFollowing(value, range.End))
                {
                    comparison = 1;
                    return false;
                }
                var preceding = range;
                while ((range = range!.Next) is not null)
                {
                    if ((comparison = comparer.Compare(value, range.End)) == 0) return true;
                    if (comparison < 0)
                    {
                        if ((comparison = comparer.Compare(value, range.Start)) >= 0) return true;
                        // value is before start
                        comparison = isImmediatelyPreceding(value, range.Start) ? -1 : -2;
                        return false;
                    }
                    if (isImmediatelyFollowing(value, range.End))
                    {
                        comparison = 1;
                        return false;
                    }
                    preceding = range;
                }
                comparison = 1;
                return false;
            }

            private void ExpandEnd(T end)
            {
                var comparer = _set._sortComparer;
                var isImmediatelyPreceding = _set._isImmediatelyPreceding;
                var isImmediatelyFollowing = _set._isImmediatelyFollowing;
                while (Next is not null)
                {
                    var d = comparer.Compare(end, Next.Start);
                    if (d < 0)
                    {
                        if (isImmediatelyPreceding(end, Next.Start))
                            MergeWithNext();
                        else
                        {
                            End = end;
                            UpdateCount();
                        }
                        return;
                    }
                    MergeWithNext();
                    if (d == 0 || (d = comparer.Compare(end, End)) <= 0) return;
                    if (isImmediatelyFollowing(end, End))
                    {
                        End = end;
                        OnIncrementEnd();
                        return;
                    }
                }
                End = end;
                UpdateCount();
            }

            private void ExpandStart(T start)
            {
                var comparer = _set._sortComparer;
                var isImmediatelyPreceding = _set._isImmediatelyPreceding;
                var isImmediatelyFollowing = _set._isImmediatelyFollowing;
                while (Previous is not null)
                {
                    var d = comparer.Compare(start, Previous.End);
                    if (d > 0)
                    {
                        if (isImmediatelyFollowing(start, Previous.End))
                            MergeWithPrevious();
                        else
                        {
                            Start = start;
                            UpdateCount();
                        }
                        return;
                    }
                    MergeWithPrevious();
                    if (d == 0 || (d = comparer.Compare(start, Start)) >= 0) return;
                    if (isImmediatelyPreceding(start, Start))
                    {
                        Start = start;
                        OnDecrementStart();
                        return;
                    }
                }
                Start = start;
                UpdateCount();
            }

            private void OnDecrementStart()
            {
                if (Previous is not null && _set._isImmediatelyFollowing(Previous.End, Start))
                    MergeWithPrevious();
                else
                {
                    Count++;
                    OnCountChanged();
                }
            }

            private void OnIncrementEnd()
            {
                if (Next is not null && _set._isImmediatelyPreceding(Next.Start, End))
                    MergeWithNext();
                else
                {
                    Count++;
                    OnCountChanged();
                }
            }
            
            private void UpdateCount()
            {
                if (_set._sortComparer.Compare(Start, End) == 0)
                    _values = Enumerable.Repeat(Start, 1);
                else if (_set._isImmediatelyPreceding(Start, End))
                    _values = new T[] { Start, End };
                else
                {
                    Count = _set._getCountInRange(Start, End);
                    _values = null;
                }
            }

            private void OnCountChanged() => _values = Count switch
            {
                1 => Enumerable.Repeat(Start, 1),
                2 => new T[] { Start, End },
                _ => null,
            };

            private void MergeWithPrevious()
            {
                var removed = Previous;
                if (removed is null) throw new InvalidOperationException();
                removed.Next = null;
                Start = removed.Start;
                UpdateCount();
                if ((Previous = removed.Previous) is null)
                    _set.First = this;
                else
                {
                    Previous.Next = this;
                    removed.Previous = null;
                }
            }

            private void MergeWithNext()
            {
                var removed = Next;
                if (removed is null) throw new InvalidOperationException();
                removed.Previous = null;
                End = removed.End;
                UpdateCount();
                if ((Next = removed.Next) is null)
                    _set.Last = this;
                else
                {
                    Next.Previous = this;
                    removed.Next = null;
                }
            }

            internal static bool Include(T value, ValueRangeSet<T> set)
            {
                if (Find(value, set, out ValueRange? range, out int comparison)) return false;
                if (range is null)
                {
                    var item = set.Last = new ValueRange(set, value) { Previous = set.Last };
                    if (item.Previous is null)
                        set.First = item;
                    else
                        item.Previous.Next = item;
                }
                else
                    switch (comparison)
                    {
                        case -2:
                            var item = new ValueRange(set, value) { Next = range, Previous = range.Previous };
                            range.Previous = item;
                            if (item.Previous is null)
                                set.First = item;
                            else
                                item.Previous.Next = item;
                            break;
                        case -1:
                            range.Start = value;
                            range.OnDecrementStart();
                            break;
                        case 1:
                            range.End = value;
                            range.OnIncrementEnd();
                            break;
                    }
                set._changeToken = new();
                return true;
            }

            internal static bool IncludeRange(T startInclusive, T endInclusive, ValueRangeSet<T> set)
            {
                var comparer = set._sortComparer;
                if (Find(startInclusive, set, out ValueRange? range, out int comparison))
                {
                    int d = comparer.Compare(endInclusive, range.End);
                    if (d <= 0) return false;
                    range.ExpandEnd(endInclusive);
                }
                else if (range is null)
                {
                    var item = set.Last = new ValueRange(set, startInclusive, endInclusive) { Previous = set.Last };
                    if (item.Previous is null)
                        set.First = item;
                    else
                        item.Previous.Next = item;
                }
                else
                {
                    var isImmediatelyPreceding = set._isImmediatelyPreceding;
                    var isImmediatelyFollowing = set._isImmediatelyFollowing;
                    int d;
                    switch (comparison)
                    {
                        case -2:
                            if ((d = comparer.Compare(endInclusive, range.Start)) < 0)
                            {
                                if (isImmediatelyPreceding(endInclusive, range.Start))
                                    range.ExpandStart(startInclusive);
                                else
                                {
                                    var item = new ValueRange(set, startInclusive, endInclusive) { Next = range, Previous = range.Previous };
                                    range.Previous = item;
                                    if (item.Previous is null)
                                        set.First = item;
                                    else
                                        item.Previous.Next = item;
                                }
                            }
                            else
                            {
                                range.ExpandStart(startInclusive);
                                if (comparer.Compare(endInclusive, range.End) >= 0)
                                    range.ExpandEnd(endInclusive);
                            }
                            break;
                        case -1: // Start is startInclusive before range.Start
                            if ((d = comparer.Compare(endInclusive, range.End)) <= 0)
                            {
                                range.Start = startInclusive;
                                range.OnDecrementStart();
                            }
                            else
                            {
                                range.ExpandStart(startInclusive);
                                range.ExpandEnd(endInclusive);
                            }
                            break;
                        case 1:
                            range.ExpandEnd(endInclusive);
                            break;
                    }
                }
                set._changeToken = new();
                return true;
            }

            internal static void Clear(ValueRangeSet<T> set)
            {
                var next = set.First;
                if (next is null) return;
                var previous = next;
                set.First = set.Last = null;
                while ((next = next!.Next) is not null)
                {
                    previous.Next = null;
                    next.Previous = null;
                    previous = next;
                }
                previous.Next = null;
                set._changeToken = new();
            }

            internal static bool Exclude(T value, ValueRangeSet<T> set)
            {
                if (TryFind(value, set, out ValueRange? range, out bool? isEnd))
                {
                    switch (range.Count)
                    {
                        case 1:
                            range.Remove();
                            set._changeToken = new();
                            return true;
                        case 2:
                            if (isEnd.HasValue && isEnd.Value)
                                range.End = range.Start;
                            else
                                range.Start = range.End;
                            range.Count = 1;
                            range.OnCountChanged();
                            set._changeToken = new();
                            return true;
                        default:
                            if (isEnd.HasValue)
                            {
                                if (isEnd.Value)
                                {
                                    if (set._tryGetDecrementedValue(range.End, out value))
                                    {
                                        range.End = value;
                                        range.Count--;
                                        range.OnCountChanged();
                                        set._changeToken = new();
                                        return true;
                                    }
                                }
                                else if (set._tryGetIncrementedValue(range.Start, out value))
                                {
                                    range.Start = value;
                                    range.Count--;
                                    range.OnCountChanged();
                                    set._changeToken = new();
                                    return true;
                                }
                            }
                            else
                            {
                                if (set._isImmediatelyFollowing(value, range.Start))
                                {
                                    if (range.Count == 3)
                                    {
                                        var item = new ValueRange(set, range.Start) { Next = range, Previous = range.Previous };
                                        if (item.Previous is null)
                                            set.First = item;
                                        else
                                            item.Previous.Next = item;
                                        range.Previous = item;
                                        range.End = range.Start;
                                        range.Count = 1;
                                        range.OnCountChanged();
                                        set._changeToken = new();
                                        return true;
                                    }
                                    if (set._tryGetIncrementedValue(value, out value))
                                    {
                                        var item = new ValueRange(set, range.Start) { Next = range, Previous = range.Previous };
                                        if (item.Previous is null)
                                            set.First = item;
                                        else
                                            item.Previous.Next = item;
                                        range.Previous = item;
                                        range.Start = value;
                                        range.Count--;
                                        range.OnCountChanged();
                                        set._changeToken = new();
                                        return true;
                                    }
                                }
                                else if (set._isImmediatelyPreceding(value, range.End))
                                {
                                    if (set._tryGetDecrementedValue(value, out value))
                                    {
                                        var item = new ValueRange(set, range.End) { Previous = range, Next = range.Next };
                                        if (item.Next is null)
                                            set.Last = item;
                                        else
                                            item.Next.Previous = item;
                                        range.Next = item;
                                        range.End = value;
                                        range.Count--;
                                        range.OnCountChanged();
                                        set._changeToken = new();
                                        return true;
                                    }
                                }
                            }
                            break;
                    }
                }
                return false;
            }

            private void Remove()
            {
                if (Previous is null)
                {
                    if ((_set.First = Next) is null)
                        _set.Last = null;
                    else
                    {
                        Next = null;
                        _set.First.Previous = null;
                    }
                }
                else
                {
                    if ((Previous.Next = Next) is null)
                        _set.Last = Previous;
                    else
                    {
                        Next!.Previous = Previous;
                        Next = null;
                    }
                    Previous = null;
                }
            }

            internal static IEnumerable<T> ExcludeAll(Func<T, bool> match, ValueRangeSet<T> set)
            {
                throw new NotImplementedException();
            }

            internal static (T Start, T End) ExcludeRange(T start, T end, ValueRangeSet<T> set)
            {
                throw new NotImplementedException();
            }

            internal static List<T> ToList(ValueRangeSet<T> set)
            {
                List<T> list = new();
                for (var item = set.First; item is not null; item = item.Next)
                {
                    switch (item.Count)
                    {
                        case 1:
                            list.Add(item.Start);
                            break;
                        case 2:
                            list.Add(item.Start);
                            list.Add(item.End);
                            break;
                        default:
                            list.AddRange(item);
                            break;
                    }
                }
                return list;
            }

            internal static void IntersectWith(IEnumerable<T> other, ValueRangeSet<T> set)
            {
                throw new NotImplementedException();
            }

            internal static void SymmetricExceptWith(IEnumerable<T> other, ValueRangeSet<T> set)
            {
                throw new NotImplementedException();
            }
        }
    }
}