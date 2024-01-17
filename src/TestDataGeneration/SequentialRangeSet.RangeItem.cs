using System.Buffers;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using static TestDataGeneration.SequentialRangeSet;

namespace TestDataGeneration;

public partial class SequentialRangeSet<T>
{
    /// <summary>
    /// A linked node for a value range.
    /// </summary>
    public class RangeItem : LinkedCollectionBase<RangeItem>.LinkedNode, IRangeExtents<T>, IReadOnlyCollection<T>, ICollection, IHasChangeToken
    {
        #region Fields

        private const string ErrorMessage_InvalidRangeItemInsert = $"A {nameof(RangeItem)} which is immediately adjacent to or overlaps an existing item cannot be inserted.";

        private object _beforeChangeToken = new();
        private object _changeToken = new();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the inclusive start value for the range.
        /// </summary>
        public T Start { get; private set; }

        /// <summary>
        /// Gets the inclusive end value for the range.
        /// </summary>
        public T End { get; private set; }

        bool IChangeTracking.IsChanged => !ReferenceEquals(_beforeChangeToken, _changeToken);

        public bool IsMaxRange { get; private set; }

        public bool IsMultiValue { get; private set; }

        #region Explicit Properties

        object IHasChangeToken.ChangeToken => _changeToken;

        int IReadOnlyCollection<T>.Count => (int)SequentialRangeSet.GetCount(this);

        int ICollection.Count => (int)SequentialRangeSet.GetCount(this);

        bool ICollection.IsSynchronized => true;

        object ICollection.SyncRoot => SyncRoot;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new <c>RangeItem</c> object from the properties of an existing object.
        /// </summary>
        /// <param name="copyFrom">The object to copy properties from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="copyFrom"/> is <see langword="null"/>.</exception>
        public RangeItem(RangeItem copyFrom)
        {
            ArgumentNullException.ThrowIfNull(copyFrom);
            Start = copyFrom.Start;
            End = copyFrom.End;
            IsMultiValue = copyFrom.IsMultiValue;
            IsMaxRange = copyFrom.IsMaxRange;
        }

        /// <summary>
        /// Initialize a new <c>RangeItem</c> object.
        /// </summary>
        /// <param name="start">The inclusive range start value.</param>
        /// <param name="end">The inclusive range end value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="evaluator"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="start"/> is greater than <paramref name="end"/>.</exception>
        public RangeItem(T start, T end)
        {
            if (!start.IsValidStartFrom(end, out bool isMultiValue, out bool isMaxRange))
                throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            Start = start;
            End = end;
            IsMultiValue = isMultiValue;
            IsMaxRange = isMaxRange;
        }

        /// <summary>
        /// Initialize a new single-value <c>RangeItem</c> object.
        /// </summary>
        /// <param name="value">The single value for the value range.</param>
        /// <param name="evaluator">The object used to test and manipulate <typeparamref name="T"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="evaluator"/> is <see langword="null"/>.</exception>
        public RangeItem(T value)
        {
            Start = End = value;
            IsMultiValue = false;
        }

        private RangeItem(T start, T end, bool isMultiValue, bool isMaxRange)
        {
            Start = start;
            End = end;
            IsMultiValue = isMultiValue;
            IsMaxRange = isMaxRange;
        }

        #endregion

        #region Static Methods

        void IChangeTracking.AcceptChanges()
        {
            Monitor.Enter(SyncRoot);
            try { _beforeChangeToken = _changeToken; }
            finally { Monitor.Exit(SyncRoot); }
        }

        internal static void Add(RangeItem item, SequentialRangeSet<T> owner)
        {
            var node = owner.First;
            if (node is null || item.End < node.Start)
                owner.AddFirst(item);
            else
            {
                var start = item.Start;
                do
                {
                    // c..g
                    // o..q
                    // m
                    if (start < node.Start)
                    {
                        owner.InsertBefore(item, node);
                        return;
                    }
                    node = node.Next;
                }
                while (node is not null);
                owner.AddLast(item);
            }
        }

        internal static bool Add(T start, T end, SequentialRangeSet<T> owner)
        {
            if (!start.IsValidStartFrom(end, out bool isMultiValue, out bool isMaxRange)) return false;
            var previous = owner.First;
            if (previous is null)
            {
                owner.AddLast(new RangeItem(start, end, isMultiValue, isMaxRange));
                return true; 
            }
            if (isMaxRange || previous.IsMaxRange) return false;
            var next = previous.Next;
            var startDisposition = previous.GetDispositionOf(start);
            while (startDisposition == SequentialComparisonResult.FollowsWithGap)
            {
                if (next is null)
                {
                    owner.AddLast(new RangeItem(start, end, isMultiValue, isMaxRange));
                    return true; 
                }
                next = (previous = next).Next;
                startDisposition = previous.GetDispositionOf(start);
            }
            if (!isMultiValue)
            {
                switch (startDisposition)
                {
                    case SequentialComparisonResult.PrecedesWithGap:
                        owner.InsertBefore(new RangeItem(start), previous);
                        break;
                    case SequentialComparisonResult.ImmediatelyPrecedes:
                        previous.SetStart(start);
                        break;
                    case SequentialComparisonResult.ImmediatelyFollows:
                        previous.SetEnd(start);
                        break;
                    default:
                        return false;
                }
                return true;
            }
            var endDisposition = previous.GetDispositionOf(end);
            switch (endDisposition)
            {
                case SequentialComparisonResult.PrecedesWithGap:
                    owner.InsertBefore(new RangeItem(start, end, isMultiValue, isMaxRange), previous);
                    return true;
                case SequentialComparisonResult.ImmediatelyPrecedes:
                    previous.SetStart(start);
                    return true;
                case SequentialComparisonResult.EqualTo:
                    switch (startDisposition)
                    {
                        case SequentialComparisonResult.PrecedesWithGap:
                        case SequentialComparisonResult.ImmediatelyPrecedes:
                            previous.SetStart(start);
                            return true;
                        default:
                            return false;
                    }
                case SequentialComparisonResult.ImmediatelyFollows:
                    switch (startDisposition)
                    {
                        case SequentialComparisonResult.PrecedesWithGap:
                        case SequentialComparisonResult.ImmediatelyPrecedes:
                            if (next is null || end.IsValidPrecedingRangeEnd(next.Start))
                                previous.SetRange(start, end);
                            else
                            {
                                previous.SetStart(start);
                                previous.MergeWithNext();
                            }
                            break;
                        default:
                            if (next is null || end.IsValidPrecedingRangeEnd(next.Start))
                                previous.SetEnd(end);
                            else
                                previous.MergeWithNext();
                            break;
                    }
                    return true;
                default:
                    switch (startDisposition)
                    {
                        case SequentialComparisonResult.PrecedesWithGap:
                        case SequentialComparisonResult.ImmediatelyPrecedes:
                            previous.SetStart(start);
                            break;
                    }
                    break;
            }
            
            previous.MergeWithNext();
            while ((next = previous.Next) is not null)
            {
                switch (next.GetDispositionOf(end))
                {
                    case SequentialComparisonResult.ImmediatelyFollows:
                        if (next.Next is null || end.IsValidPrecedingRangeEnd(next.Next.Start))
                            previous.SetEnd(end);
                        else
                            previous.MergeWithNext();
                        return true;
                    case SequentialComparisonResult.FollowsWithGap:
                        previous.MergeWithNext();
                        break;
                    default:
                        return true;
                }
            }
            previous.SetEnd(end);
            return true;
        }

        internal static bool Add(T value, SequentialRangeSet<T> owner)
        {
            var item = owner.First;
            if (item is null)
            {
                owner.AddFirst(new RangeItem(value));
                return true;
            }
            
            var startDisposition = item.GetDispositionOf(value);
            while (startDisposition == SequentialComparisonResult.FollowsWithGap)
            {
                if (item.Next is null)
                {
                    owner.InsertAfter(new RangeItem(value), item);
                    return true;
                }
                item = item.Next;
                startDisposition = item.GetDispositionOf(value);
            }
            switch (startDisposition)
            {
                case SequentialComparisonResult.PrecedesWithGap:
                    owner.InsertBefore(new RangeItem(value), item);
                    break;
                case SequentialComparisonResult.ImmediatelyPrecedes:
                    item.SetStart(value);
                    break;
                case SequentialComparisonResult.ImmediatelyFollows:
                    if (item.Next is null || value.IsValidPrecedingRangeEnd(item.Next.Start))
                        item.SetEnd(value);
                    else
                        item.MergeWithNext();
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void AssertCanInsert(SequentialRangeSet<T>.RangeItem? after, SequentialRangeSet<T>.RangeItem? before, LinkedCollectionBase<SequentialRangeSet<T>.RangeItem> linkedCollection)
        {
            base.AssertCanInsert(after, before, linkedCollection);
            if (linkedCollection is not SequentialRangeSet<T> owner) return;
            if (after is not null)
                Start.AssertCanInsertAfter(after.End);
            if (before is not null)
                End.AssertCanInsertBefore(before.Start);
            if (linkedCollection is SequentialRangeSet<T> rangeSet)
                rangeSet.ContainsAllPossibleValues = before is null && after is null && IsMaxRange;
        }

        internal static bool Contains(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var diff = start.CompareTo(end);
            if (diff > 0) return false;
            if (rangeSet.ContainsAllPossibleValues) return true;
            if (diff == 0) return Contains(start, rangeSet);
            foreach (var item in rangeSet.GetAllNodes())
                if (start.CompareTo(item.Start) >= 0) return end.CompareTo(item.End) <= 0;
            return false;
        }

        internal static bool Contains(T value, SequentialRangeSet<T> rangeSet)
        {
            if (rangeSet.ContainsAllPossibleValues) return true;
            foreach (var item in rangeSet.GetAllNodes())
            {
                int diff = value.CompareTo(item.Start);
                if (diff == 0) return true;
                if (diff < 0) return false;
                if (value.CompareTo(item.End) <= 0) return true;
            }
            return false;
        }

        internal static bool Contains(RangeItem item, SequentialRangeSet<T> rangeSet)
        {
            Monitor.Enter(item.SyncRoot);
            try
            {
                if (item.Owner is null || !ReferenceEquals(item.Owner, rangeSet)) return false;
                if (rangeSet.ContainsAllPossibleValues) return true;
                foreach (var range in rangeSet.GetAllNodes())
                {
                    int diff = item.Start.CompareTo(range.Start);
                    if (diff < 0) return false;
                    if (diff == 0) return item.End.Equals(range.End);
                }
            }
            finally { Monitor.Exit(item.SyncRoot); }
            return false;
        }

        internal static int IndexOf(RangeItem value, SequentialRangeSet<T> rangeSet)
        {
            int index = 0;
            foreach (var item in rangeSet.GetAllNodes())
            {
                int diff = value.Start.CompareTo(item.Start);
                if (diff < 0) return -1;
                if (diff == 0) return value.End.Equals(item.End) ? index : -1;
                index++;
            }
            return -1;
        }

        internal static bool Remove(T value, SequentialRangeSet<T> rangeSet)
        {
            var item = rangeSet.First;
            while (item is not null)
            {
                int diff = value.CompareTo(item.Start);
                if (diff < 0) return false;
                if (diff == 0)
                {
                    if (item.IsMultiValue)
                        item.SetStart(++value);
                    else
                        Unlink(item, rangeSet);
                    return true;
                }
                if ((diff = value.CompareTo(item.End)) < 0)
                {
                    var end = item.End;
                    var vMinus1 = value;
                    item.SetEnd(--vMinus1);
                    rangeSet.InsertAfter(new RangeItem(++value, end), item);
                    return true;
                }
                else if (diff == 0)
                {
                    item.SetEnd(--value);
                    return true;
                }
                item = item.Next;
            }
            return false;
        }

        internal static bool Remove(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var item = rangeSet.First;
            if (item is null || !start.IsValidStartFrom(end, out bool isMultiValue, out bool isMaxRange)) return false;
            if (isMaxRange)
            {
                Clear(rangeSet);
                return true;
            }
            if (!isMultiValue) return Remove(start, rangeSet);
            
            int diff;
            while ((diff = start.CompareTo(item.End)) > 0)
            {
                item = item.Next;
                if (item is null) return false;
            }
            if (diff == 0)
            {
                // start == item.End
                if (item.IsMultiValue)
                {
                    item.SetEnd(--start);
                    item = item.Next;
                }
                else
                {
                    var next = item.Next;
                    item.Unlink();
                    item = next;
                }
            }
            else if (start.CompareTo(item.Start) > 0)
            {
                var oldEnd = item.End;
                item.SetEnd(--start);
                if (end.CompareTo(oldEnd) < 0)
                {
                    InsertAfter(new RangeItem(++end, oldEnd), item, rangeSet);
                    return true;
                }
                item = item.Next;
            }
            else
            {
                if ((diff = end.CompareTo(item.End)) == 0)
                {
                    item.Unlink();
                    return true;
                }
                if (diff < 0)
                {
                    item.SetStart(++end);
                    return true;
                }
                var next = item.Next;
                item.Unlink();
                item = next;
            }
            if (item is null) return true;
            while ((diff = end.CompareTo(item.End)) > 0)
            {
                var next = item.Next;
                item.Unlink();
                item = next;
                if (item is null) return true;
            }
            if (diff == 0)
                item.Unlink();
            else if (end.CompareTo(item.Start) >= 0)
                item.SetStart(++end);
            return true;
        }

        #endregion

        #region Non-Public Instance Methods

        internal IEnumerable<T> GetValues()
        {
            object changeToken;
            Monitor.Enter(SyncRoot);
            try { changeToken = _changeToken; }
            finally { Monitor.Exit(SyncRoot); }
            if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
            var value = Start;
            yield return value;
            while (value.CompareTo(End) < 0)
            {
                if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
                value++;
                yield return value;
            }
        }

        private void MergeWithNext()
        {
            if (Next is null) throw new InvalidOperationException();
            var end = Next.End;
            Unlink(Next, Owner!);
            _changeToken = new();
            End = end;
            IsMultiValue = true;
            IsMaxRange = Start.Equals(T.MinValue) && end.Equals(T.MaxValue);
            if (Owner is SequentialRangeSet<T> owner) owner.ContainsAllPossibleValues = IsMaxRange;
        }

        private void SetEnd(T end)
        {
            if (end.Equals(End)) return;
            bool isMultiValue = Start.AssertLessThanOrEquals(end);
            if (Next is not null) end.AssertCanInsertBefore(Next.Start);
            _changeToken = new();
            End = end;
            IsMultiValue = isMultiValue;
            IsMaxRange = isMultiValue && Start.Equals(T.MinValue) && end.Equals(T.MaxValue);
            if (Owner is SequentialRangeSet<T> owner)
            {
                owner.SetChanged();
                owner.ContainsAllPossibleValues = IsMaxRange;
            }
        }

        private void SetRange(T start, T end)
        {
            if (start.Equals(Start) && end.Equals(End)) return;
            bool isMultiValue = start.AssertLessThanOrEquals(end);
            if (Next is not null) end.AssertCanInsertBefore(Next.Start);
            if (Previous is not null) start.AssertCanInsertAfter(Previous.End);
            _changeToken = new();
            Start = start;
            End = end;
            IsMultiValue = isMultiValue;
            IsMaxRange = isMultiValue && start.Equals(T.MinValue) && end.Equals(T.MaxValue);
            if (Owner is SequentialRangeSet<T> owner)
            {
                owner.SetChanged();
                owner.ContainsAllPossibleValues = IsMaxRange;
            }
        }

        private void SetStart(T start)
        {
            if (start.Equals(Start)) return;
            bool isMultiValue = start.AssertLessThanOrEquals(End);
            if (Previous is not null) start.AssertCanInsertAfter(Previous.End);
            _changeToken = new();
            Start = start;
            IsMultiValue = isMultiValue;
            IsMaxRange = isMultiValue && start.Equals(T.MinValue) && End.Equals(T.MaxValue);
            if (Owner is SequentialRangeSet<T> owner)
            {
                owner.SetChanged();
                owner.ContainsAllPossibleValues = IsMaxRange;
            }
        }

        internal bool TryGetNextAvailableRange(out T start, out T end, out RangeItem? next)
        {
            next = Next;
            if (next is not null)
            {
                start = End;
                start++;
                if (start.IsValidPrecedingRangeEnd(next.Start))
                {
                    end = next.Start;
                    end--;
                    end--;
                    return true;
                }
                return next.TryGetNextAvailableRange(out start, out end, out next);
            }
            if (End.IsValidPrecedingRangeEnd(T.MaxValue))
            {
                start = End;
                start++;
                start++;
                end = T.MaxValue;
                return true;
            }
            start = Start;
            end = End;
            return false;
        }

        #endregion

        #region Public Instance Methods

        public bool Contains(T value) => value.IsIncludedInExtents(Start, End);

        public bool Contains(T start, T end)
        {
            var diff = start.CompareTo(end);
            if (diff > 0) return false;
            if (!IsMultiValue) return diff == 0 && start.Equals(Start);
            if (diff == 0) return (diff = start.CompareTo(Start)) == 0 || (diff > 0 && start <= End);
            return start >= Start && end <= End;
        }

        void ICollection.CopyTo(Array array, int index) => GetValues().ToArray().CopyTo(array, index);

        public bool Equals(IRangeExtents<T>? other) => other is not null && other.Start.Equals(Start) && other.End.Equals(End);

        public override bool Equals([NotNullWhen(true)] object? obj) => obj is not null && ((obj is IRangeExtents<T> other) ? Equals(other) : obj is T value && Equals(value));

        public override int GetHashCode() => HashCode.Combine(Start, End);

        public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

        public override string ToString() => IsMultiValue ? $"{{{Start}..{End}}}" : $"{{{Start}}}";

        #endregion
    }
}
