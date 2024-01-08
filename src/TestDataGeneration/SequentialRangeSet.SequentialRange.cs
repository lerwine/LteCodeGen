using System.Collections;

namespace TestDataGeneration;
public partial class SequentialRangeSet<T>
{
    public class SequentialRange : IReadOnlyCollection<T>, ICollection
    {
        public object SyncRoot { get; } = new();
        private object _changeToken = new();
        private IRangeSequenceAccessors<T> _accessors;

        public bool IsSingleValue { get; private set; }

        public T Start { get; private set; }

        public T End { get; private set; }

        public SequentialRange? Previous { get; private set; }

        public SequentialRange? Next { get; private set; }

        public SequentialRangeSet<T>? Owner { get; private set; }

        int IReadOnlyCollection<T>.Count => _accessors.GetCountInRange(Start, End);

        int ICollection.Count => _accessors.GetCountInRange(Start, End);

        bool ICollection.IsSynchronized => true;

        public SequentialRange(T start, T end, IRangeSequenceAccessors<T> accessors)
        {
            ArgumentNullException.ThrowIfNull(accessors);
            int diff = accessors.Compare(start, end);
            if (diff > 0) throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            _accessors = accessors;
            Start = start;
            End = end;
            IsSingleValue = diff == 0;
        }

        private SequentialRange(T start, T end, bool isSingleValue, SequentialRangeSet<T> owner) => (Start, End, IsSingleValue, Owner, _accessors) = (start, end, isSingleValue, owner, owner.Accessors);

        internal static bool Add(T value, SequentialRangeSet<T> owner)
        {
            Monitor.Enter(owner.SyncRoot);
            try
            {
                if (owner.TryFindFirstIncludingOrAfter(value, out SequentialRange? previous, out SequentialRange? first, out bool includesValue))
                {
                    if (includesValue) return false;
                    IRangeSequenceAccessors<T> accessors = owner.Accessors;
                    Monitor.Enter(first.SyncRoot);
                    try
                    {
                        first._changeToken = new();
                        if (previous is not null && accessors.IsSequentiallyAdjacent(previous.End, value))
                        {
                            first.Start = previous.Start;
                            previous.Unlink();
                        }
                        else
                            first.Start = value;
                        first.IsSingleValue = false;
                    }
                    finally { Monitor.Exit(first.SyncRoot); }
                }
                else if (previous is null)
                    owner.First = owner.Last = new(value, value, true, owner);
                else
                {
                    IRangeSequenceAccessors<T> accessors = owner.Accessors;
                    if (accessors.IsSequentiallyAdjacent(previous.End, value))
                    {
                        Monitor.Enter(previous.SyncRoot);
                        try
                        {
                            previous._changeToken = new();
                            previous.End = value;
                            previous.IsSingleValue = false;
                        }
                        finally { Monitor.Exit(previous.SyncRoot); }
                    }
                    else
                    {
                        first = previous.Next = new(value, value, true, owner) { Next = previous.Next };
                        if (first.Next is null)
                            owner.Last = first;
                        else
                            first.Next.Previous = first;
                    }
                }
            }
            finally { Monitor.Exit(owner.SyncRoot); }
            return true;
        }

        internal static bool AddRange(T start, T end, SequentialRangeSet<T> owner)
        {
            IRangeSequenceAccessors<T> accessors = owner.Accessors;
            int diff = accessors.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return Add(start, owner);

            Monitor.Enter(owner.SyncRoot);
            try
            {
                if (owner.TryFindFirstIncludingOrAfter(start, out SequentialRange? previous, out SequentialRange? first, out bool includesValue))
                {
                    var next = first.Next;
                    if (includesValue)
                    {
                        if (accessors.Compare(end, first.End) <= 0) return false;
                        if (next is null)
                        {
                            Monitor.Enter(first.SyncRoot);
                            try
                            {
                                first.End = end;
                                first._changeToken = new();
                                first.IsSingleValue = false;
                            }
                            finally { Monitor.Exit(first.SyncRoot); }
                        }
                        else
                        {
                            while ((diff = accessors.Compare(end, next.End)) >= 0)
                            {
                                next = next.Unlink();
                                if (next is null)
                                {
                                    Monitor.Enter(first.SyncRoot);
                                    try
                                    {
                                        first.End = end;
                                        first._changeToken = new();
                                        first.IsSingleValue = false;
                                    }
                                    finally { Monitor.Exit(first.SyncRoot); }
                                    return true;
                                }
                            }
                            Monitor.Enter(first.SyncRoot);
                            try
                            {
                                first.End = (accessors.Compare(end, next.Start) >= 0 || accessors.IsSequentiallyAdjacent(end, next.Start)) ? next.End : end;
                                first._changeToken = new();
                                first.IsSingleValue = false;
                            }
                            finally { Monitor.Exit(first.SyncRoot); }
                        }
                    }
                    else
                    {
                        // (previous is null || start > previous.End) && start < first.Start
                        Monitor.Enter(first.SyncRoot);
                        try
                        {
                            first._changeToken = new();
                            if (previous is not null && accessors.IsSequentiallyAdjacent(previous.End, start))
                            {
                                first.Start = previous.Start;
                                previous.Unlink();
                            }
                            else
                                first.Start = start;
                            if (accessors.Compare(end, first.End) <= 0) return true;
                            while (next is not null)
                            {
                                if ((diff = accessors.Compare(end, next.Start)) < 0) break;
                                if (diff == 0 || accessors.Compare(end, next.End) <= 0)
                                {
                                    end = next.End;
                                    next.Unlink();
                                    break;
                                }
                                next = next.Unlink();
                            }
                            first.End = end;
                            first.IsSingleValue = false;
                        }
                        finally { Monitor.Exit(first.SyncRoot); }
                    }
                }
                else if (previous is null)
                    owner.First = owner.Last = new(start, end, false, owner);
                else
                {
                    // start > previous.End
                    var next = previous.Next;
                    if (accessors.IsSequentiallyAdjacent(previous.End, start))
                    {
                        Monitor.Enter(previous.SyncRoot);
                        try
                        {
                            previous._changeToken = new();
                            if (next is not null && accessors.IsSequentiallyAdjacent(end, next.Start))
                            {
                                previous.End = next.End;
                                next.Unlink();
                            }
                            else
                                previous.End = end;
                            previous.IsSingleValue = false;
                        }
                        finally { Monitor.Exit(previous.SyncRoot); }
                    }
                    else
                        owner.Last = previous.Next = new(start, end, false, owner) { Previous = previous };
                }
            }
            finally { Monitor.Exit(owner.SyncRoot); }
            return true;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

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

        private static void LinkFirst(SequentialRange item, SequentialRangeSet<T> owner)
        {
            object syncRoot = item.SyncRoot;
            IRangeSequenceAccessors<T> accessors;
            bool sameAccessors;
            Monitor.Enter(syncRoot);
            try
            {
                if (item.Owner is not null)
                {
                    if (ReferenceEquals(owner, item.Owner))
                    {
                        if (ReferenceEquals(owner.First, item)) return;
                        throw new ArgumentException($"{nameof(item)} already exists in the target range set.", nameof(item));
                    }
                    item = new SequentialRange(item.Start, item.End, item.IsSingleValue, owner);
                    var s = syncRoot;
                    syncRoot = item.SyncRoot;
                    try { Monitor.Enter(item.SyncRoot); }
                    finally { Monitor.Exit(s); }
                    sameAccessors = true;
                    accessors = owner.Accessors;
                }
                else
                {
                    accessors = owner.Accessors;
                    sameAccessors = ReferenceEquals(item._accessors, accessors);
                }
                var next = owner.First;
                if (next is null)
                    owner.First = owner.Last = item;
                else
                {
                    if (accessors.Compare(item.End, next.Start) >= 0 || accessors.IsSequentiallyAdjacent(item.End, next.Start))
                        throw new ArgumentException($"{nameof(item)} overlaps or is adjacent to an existing item.", nameof(item));
                    owner.First = (item.Next = next).Previous = item;
                }
                item.Owner = owner;
                if (sameAccessors) return;
                item._changeToken = new();
                item._accessors = accessors;
            }
            finally { Monitor.Exit(syncRoot); }
        }

        private void LinkNext(SequentialRange item)
        {
            if (Owner is null) throw new InvalidOperationException();
            object syncRoot = item.SyncRoot;
            Monitor.Enter(syncRoot);
            bool sameAccessors;
            try
            {
                if (item.Owner is not null)
                {
                    if (ReferenceEquals(Owner, item.Owner))
                    {
                        if (item.Previous is not null && ReferenceEquals(this, item.Previous)) return;
                        throw new ArgumentException($"{nameof(item)} already exists in the target range set.", nameof(item));
                    }
                    item = new SequentialRange(item.Start, item.End, item.IsSingleValue, Owner);
                    var s = syncRoot;
                    syncRoot = item.SyncRoot;
                    try { Monitor.Enter(item.SyncRoot); }
                    finally { Monitor.Exit(s); }
                    sameAccessors = true;
                }
                else
                {
                    sameAccessors = ReferenceEquals(item._accessors, _accessors);
                }
                var next = Next;
                if (next is null)
                    Owner.Last = (item.Previous = this).Next = item;
                else
                {
                    if (_accessors.Compare(End, item.Start) >= 0 || _accessors.IsSequentiallyAdjacent(End, item.Start))
                        throw new ArgumentException($"{nameof(item)} overlaps or is adjacent to an existing item.", nameof(item));
                    else
                    {
                        if (_accessors.Compare(item.End, next.Start) >= 0 || _accessors.IsSequentiallyAdjacent(item.End, next.Start))
                            throw new ArgumentException($"{nameof(item)} overlaps or is adjacent to an existing item.", nameof(item));
                        (item.Next = next).Previous = (item.Previous = this).Next = item;
                    }
                }
                item.Owner = Owner;
                if (sameAccessors) return;
                item._changeToken = new();
                item._accessors = _accessors;
            }
            finally { Monitor.Exit(syncRoot); }
        }

        internal static bool Remove(T value, SequentialRangeSet<T> owner)
        {
            
            Monitor.Enter(owner.SyncRoot);
            try
            {
                var accessors = owner.Accessors;
                for (var item = owner.First; item is not null; item = item.Next)
                {
                    int diff = accessors.Compare(value, item.Start);
                    if (diff < 0) return false;
                    if (diff == 0)
                    {
                        if (item.IsSingleValue)
                            item.Unlink();
                        else
                        {
                            Monitor.Enter(item.SyncRoot);
                            try
                            {
                                item._changeToken = new();
                                item.Start = accessors.GetIncrementedValue(value);
                                item.IsSingleValue = accessors.Compare(item.Start, item.End) == 0;
                            }
                            finally { Monitor.Exit(item.SyncRoot); }
                        }
                        return true;
                    }
                    if ((diff = accessors.Compare(value, item.End)) == 0)
                    {
                        Monitor.Enter(item.SyncRoot);
                        try
                        {
                            item._changeToken = new();
                            item.End = accessors.GetDecrementedValue(value);
                            item.IsSingleValue = accessors.Compare(item.Start, item.End) == 0;
                        }
                        finally { Monitor.Exit(item.SyncRoot); }
                        return true;
                    }
                    if (diff < 0)
                    {
                        var end = item.End;
                        Monitor.Enter(item.SyncRoot);
                        try
                        {
                            item._changeToken = new();
                            item.End = accessors.GetDecrementedValue(value);
                            item.IsSingleValue = accessors.Compare(item.Start, item.End) == 0;
                        }
                        finally { Monitor.Exit(item.SyncRoot); }
                        item.LinkNext(new SequentialRange(value, end, accessors));
                        return true;
                    }
                }
            }
            finally { Monitor.Exit(owner.SyncRoot); }
            return false;
        }

        internal static bool RemoveRange(T start, T end, SequentialRangeSet<T> owner)
        {
            IRangeSequenceAccessors<T> accessors = owner.Accessors;
            int diff = accessors.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return Remove(start, owner);
            
            Monitor.Enter(owner.SyncRoot);
            try
            {
                if (owner.TryFindFirstIncludingOrAfter(start, out var result, out bool equalsExtent, out bool diffIsEnd))
                {
                    if (equalsExtent)
                    {
                        if (diffIsEnd)
                        {
                            // start == result.End
                            // TODO: Decrement result.End
                            result = result.Next;
                        }
                        else
                        {
                            // start == result.Start
                            if (result.IsSingleValue)
                                result = result.Unlink();
                            else
                            {
                                // TODO: Set end to decremented start
                                if ((diff = accessors.Compare(end, result.End)) < 0)
                                {
                                    // TODO: Append Increment(end)..result.End
                                    return true;
                                }
                                if (diff == 0) return true;
                                result = result.Next;
                            }
                        }
                        if (result is null) return true;
                        // TODO: Return true if result.Start < end
                    }
                    else
                    {
                        if (diffIsEnd)
                        {
                            // start < result.End
                        }
                        else
                        {
                            // start < result.Start
                        }
                    }
                }
            }
            finally { Monitor.Exit(owner.SyncRoot); }
            return false;
        }

        private SequentialRange? Unlink()
        {
            if (Owner is null) return null;
            var next = Next;
            if (next is null)
            {
                if ((Owner.Last = Previous) is null)
                    Owner.First = null;
                else
                    Previous = Previous!.Next = null;
            }
            else
            {
                if ((next.Previous = Previous) is null)
                    Owner.First = next;
                else
                {
                    Previous!.Next = next;
                    Previous = null;
                }
                Next = null;
            }
            Owner = null;
            return next;
        }
        
        private void Unlink(out SequentialRange? previous)
        {
            previous = Previous;
            if (Owner is null) return;
            if (Next is null)
            {
                if ((Owner.Last = previous) is null)
                    Owner.First = null;
                else
                    Previous = previous!.Next = null;
            }
            else
            {
                if ((Next.Previous = previous) is null)
                    Owner.First = Next;
                else
                {
                    previous!.Next = Next;
                    Previous = null;
                }
                Next = null;
            }
            Owner = null;
        }
            }
}
