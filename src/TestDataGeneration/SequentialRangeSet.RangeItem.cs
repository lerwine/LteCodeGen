using System.Buffers;
using System.Collections;

namespace TestDataGeneration;
public partial class SequentialRangeSet<T>
{
    public class RangeItem : IReadOnlyCollection<T>, ICollection
    {
        private const string ErrorMessage_InvalidRangeItemInsert = $"A {nameof(RangeItem)} which is immediately adjacent to or overlaps an existing item cannot be inserted.";

        private object _changeToken = new();

        private IRangeSequenceAccessors<T> _accessors;

        int IReadOnlyCollection<T>.Count => _accessors.GetCountInRange(Start, End);

        int ICollection.Count => _accessors.GetCountInRange(Start, End);

        public T End { get; private set; }

        public bool IsSingleValue { get; private set; }

        bool ICollection.IsSynchronized => true;

        public RangeItem? Next { get; private set; }

        public SequentialRangeSet<T>? Owner { get; private set; }

        public RangeItem? Previous { get; private set; }

        public T Start { get; private set; }

        public object SyncRoot { get; } = new();

        public RangeItem(RangeItem copyFrom)
        {
            ArgumentNullException.ThrowIfNull(copyFrom);
            _accessors = copyFrom._accessors;
            Start = copyFrom.Start;
            End = copyFrom.End;
            IsSingleValue = copyFrom.IsSingleValue;
        }

        public RangeItem(T start, T end, IRangeSequenceAccessors<T> accessors)
        {
            ArgumentNullException.ThrowIfNull(accessors);
            int diff = (_accessors = accessors).Compare(start, end);
            if (diff > 0) throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            Start = start;
            End = end;
            IsSingleValue = diff == 0;
        }

        public RangeItem(T value, IRangeSequenceAccessors<T> accessors)
        {
            ArgumentNullException.ThrowIfNull(accessors);
            _accessors = accessors;
            Start = End = value;
            IsSingleValue = true;
        }

        private RangeItem(RangeItem copyFrom, SequentialRangeSet<T> owner)
        {
            _accessors = owner.Accessors;
            Start = copyFrom.Start;
            End = copyFrom.End;
            if (ReferenceEquals(_accessors, copyFrom._accessors))
                IsSingleValue = copyFrom.IsSingleValue;
            else
            {
                int diff = (_accessors = (Owner = owner).Accessors).Compare(Start, End);
                if (diff > 0) throw new ArgumentOutOfRangeException(nameof(copyFrom), $"The {nameof(copyFrom)} range {nameof(Start)} value cannot be greater than the {nameof(End)} value.");
                IsSingleValue = diff == 0;
            }
        }

        private RangeItem(T start, T end, SequentialRangeSet<T> owner)
        {
            int diff = (_accessors = (Owner = owner).Accessors).Compare(start, end);
            if (diff > 0) throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            Start = start;
            End = end;
            IsSingleValue = diff == 0;
        }

        // private RangeItem(T start, T end, SequentialRangeSet<T> owner, bool isSingleValue)
        // {
        //     _accessors = (Owner = owner).Accessors;
        //     Start = start;
        //     End = end;
        //     IsSingleValue = isSingleValue;
        // }

        private RangeItem(T value, SequentialRangeSet<T> owner)
        {
            _accessors = (Owner = owner).Accessors;
            Start = End = value;
            IsSingleValue = true;
        }

        private void Add()
        {
            var previous = Owner!.First;
            if (previous is null)
            {
                LinkAfter(null);
                return;
            }
            int diff = _accessors.Compare(End, previous.Start);
            if (diff == 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
            if (diff < 0)
            {
                if (_accessors.IsSequentiallyAdjacent(End, previous.Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                previous = null;
            }
            else if (IsSingleValue)
            {
                var next = previous.Next;
                if (!previous.IsSingleValue && _accessors.Compare(Start, previous.End) <= 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                if (_accessors.IsSequentiallyAdjacent(previous.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                while (next is not null)
                {
                    if ((diff = _accessors.Compare(Start, next.Start)) < 0)
                    {
                        if (_accessors.IsSequentiallyAdjacent(Start, next.Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                        break;
                    }
                    if (diff == 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    next = (previous = next).Next;
                    if (!previous.IsSingleValue && _accessors.Compare(Start, previous.End) <= 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    if (_accessors.IsSequentiallyAdjacent(previous.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                }
            }
            else
            {
                if (_accessors.Compare(Start, previous.End) <= 0 || _accessors.IsSequentiallyAdjacent(previous.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                var next = previous.Next;
                while (next is not null)
                {
                    if ((diff = _accessors.Compare(End, next.End)) < 0)
                    {
                        if (_accessors.Compare(End, next.Start) >= 0 || _accessors.IsSequentiallyAdjacent(End, next.Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                        break;
                    }
                    else if (diff == 0)
                        throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    if (_accessors.Compare(Start, next.End) < 0 || _accessors.IsSequentiallyAdjacent(next.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    next = (previous = next).Next;
                }
            }
            LinkAfter(previous);
        }

        internal static void Add(RangeItem item, SequentialRangeSet<T> owner)
        {
            if (item.Owner is not null)
            {
                if (ReferenceEquals(item.Owner, owner)) return;
                new RangeItem(item, owner).Add();
            }
            else
            {
                var oldAccessors = item._accessors;
                var wasSingleValue = item.IsSingleValue;
                var accessors = owner.Accessors;
                try
                {
                    item.Owner = owner;
                    if (ReferenceEquals(accessors, oldAccessors))
                        item.Add();
                    else
                    {
                        item._accessors = accessors;
                        int diff = accessors.Compare(item.Start, item.End);
                        if (diff > 0) throw new ArgumentOutOfRangeException(nameof(item), $"The {nameof(Start)} range value cannot be greater than the {nameof(End)} value.");
                        item.IsSingleValue = diff == 0;
                        item.Add();
                        item._changeToken = new();
                    }
                }
                catch
                {
                    item.Owner = null;
                    item._accessors = oldAccessors;
                    item.IsSingleValue = wasSingleValue;
                    throw;
                }
            }
        }

        internal static bool Add(T start, T end, SequentialRangeSet<T> owner)
        {
            var accessors = owner.Accessors;
            int diff = accessors.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return Add(start, owner);
            var item = owner.First;
            if (item is null)
            {
                new RangeItem(start, end, owner).LinkAfter(null);
                return true;
            }
            if ((diff = accessors.Compare(end, item.Start)) < 0)
            {
                if (accessors.IsSequentiallyAdjacent(end, item.Start))
                    item.SetStart(start);
                else
                    new RangeItem(start, end, owner).LinkAfter(null);
                return true;
            }
            if (diff == 0)
            {
                item.SetStart(start);
                return true;
            }
            if (accessors.Compare(end, item.End) <= 0)
            {
                if (accessors.Compare(start, item.Start) >= 0) return false;
                item.SetStart(start);
                return true;
            }
            // end > item.End
            var next = item.Next;
            if (next is null)
            {
                if (accessors.Compare(start, item.Start) < 0)
                    item.SetRange(start, end);
                else
                    item.SetEnd(end);
                return true;
            }
            while (accessors.CanInsert(item.End, start))
            {
                next = (item = next).Next;
                if (next is null)
                {
                    new RangeItem(start, end, owner).LinkAfter(item);
                    return true;
                }
            }
            diff = accessors.Compare(end, item.End);
            var changed = diff > 0;
            if (changed)
                do
                {
                    item.MergeWithNext();
                    diff = accessors.Compare(end, item.End);
                    if ((next = item.Next) is null)
                    {
                        if (diff > 0)
                        {
                            if (accessors.Compare(start, item.Start) < 0)
                                item.SetRange(start, end);
                            else
                                item.SetEnd(end);
                        }
                        else if (accessors.Compare(start, item.Start) < 0)
                            item.SetStart(start);
                        return true;
                    }
                }
                while (diff > 0);
            if (accessors.Compare(start, item.Start) < 0)
            {
                item.SetStart(start);
                return true;
            }
            return changed;
        }

        internal static bool Add(T value, SequentialRangeSet<T> owner)
        {
            var accessors = owner.Accessors;
            var item = owner.First;
            if (item is null || accessors.CanInsert(value, item.Start) || accessors.CanInsert(value, item.Start))
                new RangeItem(value, owner).LinkAfter(null);
            else if (accessors.IsSequentiallyAdjacent(value, item.Start))
                item.SetStart(value);
            else
            {
                int diff = accessors.Compare(value, item.End);
                if (diff > 0)
                {
                    do
                    {
                        if (accessors.IsSequentiallyAdjacent(item.End, value))
                        {
                            if (item.Next is not null && accessors.IsSequentiallyAdjacent(value, item.Next.Start))
                                item.MergeWithNext();
                            else
                                item.SetEnd(value);
                            return true;
                        }
                        if (item.Next is null)
                        {
                            new RangeItem(value, owner).LinkAfter(item);
                            return true;
                        }
                        item = item.Next;
                        diff = accessors.Compare(value, item.End);
                    }
                    while (diff > 0);
                    if (diff == 0) return false;
                    if (accessors.CanInsert(value, item.Start))
                        new RangeItem(value, owner).LinkAfter(item.Previous);
                    else if (accessors.IsSequentiallyAdjacent(value, item.Start))
                        item.SetStart(value);
                    else
                        return false;
                }
                else
                {
                    if (diff == 0) return false;
                    if (accessors.IsSequentiallyAdjacent(value, item.Start))
                        item.SetStart(value);
                    else
                        return false;
                }
            }
            return true;
        }

        internal static void Clear(SequentialRangeSet<T> rangeSet)
        {
            var previous = rangeSet.First;
            if (previous is null) return;
            rangeSet.First = rangeSet.Last = null;
            rangeSet._changeToken = new();
            var next = previous.Next;
            previous.Owner = null;
            while (next is not null)
            {
                next.Owner = null;
                next.Previous = null;
                previous.Next = null;
                previous = next;
                next = previous.Next;
            }
            previous.Previous = null;
        }

        internal static bool Contains(T value, SequentialRangeSet<T> rangeSet)
        {
            var accessors = rangeSet.Accessors;
            foreach (var item in GetRanges(rangeSet))
            {
                int diff = accessors.Compare(value, item.Start);
                if (diff == 0) return true;
                if (diff < 0) return false;
                if (accessors.Compare(value, item.End) <= 0) return true;
            }
            return false;
        }

        internal static bool Contains(RangeItem item, SequentialRangeSet<T> rangeSet)
        {
            var accessors = rangeSet.Accessors;
            foreach (var range in GetRanges(rangeSet))
            {
                int diff = accessors.Compare(item.Start, range.Start);
                if (diff < 0) return false;
                if (diff == 0) return accessors.AreEqual(item.End, range.End);
            }
            return false;
        }

        void ICollection.CopyTo(Array array, int index) => GetValues().ToArray().CopyTo(array, index);

        public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

        internal static IEnumerable<RangeItem> GetRanges(SequentialRangeSet<T> rangeSet)
        {
            object changeToken = rangeSet._changeToken;
            for (var item = rangeSet.First; item is not null; item = item.Next)
            {
                if (!ReferenceEquals(changeToken, rangeSet._changeToken)) throw new InvalidOperationException(ErrorMessage_SequentialRangeSetChanged);
                yield return item;
            }
        }

        internal IEnumerable<T> GetValues()
        {
            IRangeSequenceAccessors<T> accessors;
            object changeToken;
            Monitor.Enter(SyncRoot);
            try
            {
                accessors = _accessors;
                changeToken = _changeToken;
            }
            finally { Monitor.Exit(SyncRoot); }
            if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
            var value = Start;
            yield return value;
            while (accessors.Compare(value, End) > 0)
            {
                if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
                value = accessors.GetIncrementedValue(value);
                yield return value;
            }
        }

        internal static int IndexOf(RangeItem value, SequentialRangeSet<T> rangeSet)
        {
            int index = 0;
            var accessors = rangeSet.Accessors;
            foreach (var item in GetRanges(rangeSet))
            {
                int diff = accessors.Compare(value.Start, item.Start);
                if (diff < 0) return -1;
                if (diff == 0) return accessors.AreEqual(value.End, item.End) ? index : -1;
                index++;
            }
            return -1;
        }

        internal static int IndexOf(T value, SequentialRangeSet<T> rangeSet)
        {
            int index = 0;
            var accessors = rangeSet.Accessors;
            foreach (var item in GetRanges(rangeSet))
            {
                int diff = accessors.Compare(value, item.Start);
                if (diff == 0) return index;
                if (diff < 0) return -1;
                if (accessors.Compare(value, item.End) <= 0) return index + accessors.GetCountInRange(accessors.GetIncrementedValue(item.Start), value);
                index += accessors.GetCountInRange(item.Start, item.End);
            }
            return -1;
        }

        private void LinkAfter(RangeItem? previous)
        {
            if (Owner is null) throw new InvalidOperationException();
            Owner._changeToken = new();
            if ((Previous = previous) is null)
            {
                if ((Next = Owner!.First) is null)
                    Owner.Last = this;
                Owner.First = this;
            }
            else
            {
                if ((Next = previous!.Next) is null)
                    Owner.Last = this;
                else
                    Next.Previous = this;
                Previous.Next = this;
            }
            Owner._changeToken = new();
        }

        private void MergeWithNext()
        {
            if (Next is null) throw new InvalidOperationException();
            var end = Next.End;
            Next.Remove();
            _changeToken = new();
            End = end;
            IsSingleValue = false;
            Next.Remove();
        }

        // private void MergeWithNext(T newStart)
        // {
        //     if (Next is null) throw new InvalidOperationException();
        //     var end = Next.End;
        //     int diff = _accessors.Compare(newStart, end);
        //     if (diff < 0 || (Previous is not null && !_accessors.CanInsert(Previous.End, newStart))) throw new InvalidOperationException();
        //     Next.Unlink();
        //     _changeToken = new();
        //     Start = newStart;
        //     End = end;
        //     IsSingleValue = diff == 0;
        // }

        internal static bool Remove(T value, SequentialRangeSet<T> rangeSet)
        {
            var item = rangeSet.First;
            var accessors = rangeSet.Accessors;
            while (item is not null)
            {
                int diff = accessors.Compare(value, item.Start);
                if (diff < 0) return false;
                if (diff == 0)
                {
                    if (item.IsSingleValue)
                        item.Remove();
                    else
                        item.SetStart(accessors.GetIncrementedValue(value));
                    return true;
                }
                if ((diff = accessors.Compare(value, item.End)) < 0)
                {
                    value = accessors.GetIncrementedValue(value);
                    var end = item.End;
                    item.SetEnd(accessors.GetDecrementedValue(value));
                    new RangeItem(value, end, rangeSet).LinkAfter(item);
                    return true;
                }
                else if (diff == 0)
                {
                    item.SetEnd(accessors.GetDecrementedValue(value));
                    return true;
                }
            }
            return false;
        }

        internal static bool Remove(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var accessors = rangeSet.Accessors;
            int diff = accessors.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return Remove(start, rangeSet);
            var item = rangeSet.First;
            if (item is null) return false;
            while (accessors.Compare(start, item.End) > 0)
            {
                item = item.Next;
                if (item is null) return false;
            }
            if ((diff = accessors.Compare(end, item.Start)) < 0) return false;
            if (diff == 0)
            {
                if (item.IsSingleValue)
                    item.Remove();
                else
                    item.SetStart(accessors.GetIncrementedValue(end));
            }
            else
            {
                while (accessors.Compare(end, item.End) > 0)
                {
                    item.MergeWithNext();
                    if (item.Next is null) break;
                }
                if (accessors.Compare(start, item.Start) <= 0)
                {
                    if (accessors.Compare(end, item.End) >= 0)
                        item.Remove();
                    else
                        item.SetStart(accessors.GetIncrementedValue(end));
                }
                else if (accessors.Compare(end, item.End) >= 0)
                    item.SetEnd(accessors.GetDecrementedValue(start));
                else
                {
                    var nextEnd = item.End;
                    item.SetEnd(accessors.GetDecrementedValue(start));
                    new RangeItem(accessors.GetIncrementedValue(end), nextEnd, rangeSet).LinkAfter(item);
                }
            }
            return true;
        }

        private void SetEnd(T end)
        {
            if (_accessors.AreEqual(end, End)) return;
            int diff = _accessors.Compare(Start, end);
            if (diff < 0 || (Next is not null && !_accessors.CanInsert(end, Next.Start))) throw new InvalidOperationException();
            _changeToken = new();
            End = end;
            IsSingleValue = diff == 0;
            if (Owner is not null) Owner._changeToken = new();
        }

        private void SetRange(T start, T end)
        {
            if (_accessors.AreEqual(start, Start) && _accessors.AreEqual(end, End)) return;
            int diff = _accessors.Compare(start, end);
            if (diff < 0 || (Previous is not null && !_accessors.CanInsert(Previous.End, start)) || (Next is not null && !_accessors.CanInsert(end, Next.Start))) throw new InvalidOperationException();
            _changeToken = new();
            Start = start;
            End = end;
            IsSingleValue = diff == 0;
            if (Owner is not null) Owner._changeToken = new();
        }

        private void SetStart(T start)
        {
            if (_accessors.AreEqual(start, Start)) return;
            int diff = _accessors.Compare(start, End);
            if (diff < 0 || (Previous is not null && !_accessors.CanInsert(Previous.End, start))) throw new InvalidOperationException();
            _changeToken = new();
            Start = start;
            IsSingleValue = diff == 0;
            if (Owner is not null) Owner._changeToken = new();
        }

        internal bool TryGetNextAvailableRange(out T start, out T end, out RangeItem? next)
        {
            next = Next;
            if (next is not null)
            {
                start = _accessors.GetIncrementedValue(End);
                if (_accessors.CanInsert(start, next.Start))
                {
                    end = _accessors.GetDecrementedValue(next.Start, 2);
                    return true;
                }
                return next.TryGetNextAvailableRange(out start, out end, out next);
            }
            if (_accessors.CanInsert(End, _accessors.MaxValue))
            {
                start = _accessors.GetIncrementedValue(End, 2);
                end = _accessors.MaxValue;
                return true;
            }
            start = Start;
            end = End;
            return false;
        }

        internal void Remove()
        {
            if (Owner is null) throw new InvalidOperationException();
            if (Next is null)
            {
                if ((Owner.Last = Previous) is null)
                    Owner.First = null;
                else
                    Previous = Previous!.Next = null;
            }
            else
            {
                if ((Next.Previous = Previous) is null)
                    Owner.First = Next;
                else
                {
                    Previous!.Next = Next;
                    Previous = null;
                }
                Next = null;
            }
            Owner._changeToken = new();
            Owner = null;
        }
    }
}
