using System.Buffers;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public partial class SequentialRangeSet<T>
{
    /// <summary>
    /// A linked node for a value range.
    /// </summary>
    public class RangeItem : LinkedCollectionBase<RangeItem>.LinkedNode, IValueRange<T>, IReadOnlyCollection<T>, ICollection, IHasChangeToken
    {
        #region Fields

        private const string ErrorMessage_InvalidRangeItemInsert = $"A {nameof(RangeItem)} which is immediately adjacent to or overlaps an existing item cannot be inserted.";

        private object _beforeChangeToken = new();
        private object _changeToken = new();

        private IRangeEvaluator<T> _evaluator;

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

        /// <summary>
        /// Returns a value indicating whether the range has only one value.
        /// </summary>
        /// <value><see langword="true"/> if <see cref="Start"/> is equal to <see cref="End"/>; otherwise, <see langword="false"/>.</value>
        public bool IsSingleValue { get; private set; }

        #region Explicit Properties

        object IHasChangeToken.ChangeToken => _changeToken;

        int IReadOnlyCollection<T>.Count => (int)_evaluator.GetLongCountInRange(Start, End);

        int ICollection.Count => (int)_evaluator.GetLongCountInRange(Start, End);

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
            _evaluator = copyFrom._evaluator;
            Start = copyFrom.Start;
            End = copyFrom.End;
            IsSingleValue = copyFrom.IsSingleValue;
            IsMaxRange = copyFrom.IsMaxRange;
        }

        /// <summary>
        /// Initialize a new <c>RangeItem</c> object.
        /// </summary>
        /// <param name="start">The inclusive range start value.</param>
        /// <param name="end">The inclusive range end value.</param>
        /// <param name="evaluator">The object used to test and manipulate <typeparamref name="T"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="evaluator"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="start"/> is greater than <paramref name="end"/>.</exception>
        public RangeItem(T start, T end, IRangeEvaluator<T> evaluator)
        {
            ArgumentNullException.ThrowIfNull(evaluator);
            if (!(_evaluator = evaluator).IsValidRange(start, end, out bool isSingleValue, out bool isMaxRange))
                throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            Start = start;
            End = end;
            IsSingleValue = isSingleValue;
            IsMaxRange = isMaxRange;
        }

        /// <summary>
        /// Initialize a new single-value <c>RangeItem</c> object.
        /// </summary>
        /// <param name="value">The single value for the value range.</param>
        /// <param name="evaluator">The object used to test and manipulate <typeparamref name="T"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="evaluator"/> is <see langword="null"/>.</exception>
        public RangeItem(T value, IRangeEvaluator<T> evaluator)
        {
            ArgumentNullException.ThrowIfNull(evaluator);
            _evaluator = evaluator;
            Start = End = value;
            IsSingleValue = true;
        }

        private RangeItem(T start, T end, bool isSingleValue, bool isMaxRange, IRangeEvaluator<T> evaluator)
        {
            _evaluator = evaluator;
            Start = start;
            End = end;
            IsSingleValue = isSingleValue;
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
            if (node is null || owner.RangeEvaluator.Compare(item.End, node.Start) < 0)
                owner.AddFirst(item);
            else
            {
                var start = item.Start;
                var evaluator = owner.RangeEvaluator;
                do
                {
                    // c..g
                    // o..q
                    // m
                    if (evaluator.Compare(start, node.Start) < 0)
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
            var evaluator = owner.RangeEvaluator;
            if (!evaluator.IsValidRange(start, end, out bool isSingleValue, out bool isMaxRange)) return false;
            var previous = owner.First;
            if (previous is null)
            {
                owner.AddLast(new RangeItem(start, end, isSingleValue, isMaxRange, evaluator));
                return true; 
            }
            if (isMaxRange || previous.IsMaxRange) return false;
            var next = previous.Next;
            var startDisposition = evaluator.GetRangeDisposition(start, previous);
            while (startDisposition == SequentialComparisonResult.FollowsWithGap)
            {
                if (next is null)
                {
                    owner.AddLast(new RangeItem(start, end, isSingleValue, isMaxRange, evaluator));
                    return true; 
                }
                next = (previous = next).Next;
                startDisposition = evaluator.GetRangeDisposition(start, previous);
            }
            if (isSingleValue)
            {
                switch (startDisposition)
                {
                    case SequentialComparisonResult.PrecedesWithGap:
                        owner.InsertBefore(new RangeItem(start, evaluator), previous);
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
            var endDisposition = evaluator.GetRangeDisposition(end, previous);
            switch (endDisposition)
            {
                case SequentialComparisonResult.PrecedesWithGap:
                    owner.InsertBefore(new RangeItem(start, end, isSingleValue, isMaxRange, evaluator), previous);
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
                            if (next is null || evaluator.IsValidPrecedingRangeEnd(end, next.Start))
                                previous.SetRange(start, end);
                            else
                            {
                                previous.SetStart(start);
                                previous.MergeWithNext();
                            }
                            break;
                        default:
                            if (next is null || evaluator.IsValidPrecedingRangeEnd(end, next.Start))
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
                switch (evaluator.GetRangeDisposition(end, next))
                {
                    case SequentialComparisonResult.ImmediatelyFollows:
                        if (next.Next is null || evaluator.IsValidPrecedingRangeEnd(end, next.Next.Start))
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
            var evaluator = owner.RangeEvaluator;
            var item = owner.First;
            if (item is null)
            {
                owner.AddFirst(new RangeItem(value, evaluator));
                return true;
            }
            
            var startDisposition = evaluator.GetRangeDisposition(value, item);
            while (startDisposition == SequentialComparisonResult.FollowsWithGap)
            {
                if (item.Next is null)
                {
                    owner.InsertAfter(new RangeItem(value, evaluator), item);
                    return true;
                }
                item = item.Next;
                startDisposition = evaluator.GetRangeDisposition(value, item);
            }
            switch (startDisposition)
            {
                case SequentialComparisonResult.PrecedesWithGap:
                    owner.InsertBefore(new RangeItem(value, evaluator), item);
                    break;
                case SequentialComparisonResult.ImmediatelyPrecedes:
                    item.SetStart(value);
                    break;
                case SequentialComparisonResult.ImmediatelyFollows:
                    if (item.Next is null || evaluator.IsValidPrecedingRangeEnd(value, item.Next.Start))
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
            var evaluator = owner.RangeEvaluator;
            if (after is not null)
                evaluator.AssertCanInsert(after.End, Start);
            if (before is not null)
                evaluator.AssertCanInsert(End, before.Start);
            if (!ReferenceEquals(_evaluator, evaluator))
            {
                if (!evaluator.IsValidRange(Start, End, out bool isSingleValue, out bool isMaxRange))
                    throw new InvalidOperationException($"The range {nameof(Start)} value cannot be greater than the {nameof(End)} value.");
                if (IsSingleValue != isSingleValue || IsMaxRange != isMaxRange)
                {
                    IsSingleValue = isSingleValue;
                    IsMaxRange = isMaxRange;
                    _changeToken = new();
                }
                _evaluator = evaluator;
            }
            if (linkedCollection is SequentialRangeSet<T> rangeSet)
                rangeSet.ContainsAllPossibleValues = before is null && after is null && IsMaxRange;
        }

        internal static bool Contains(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var evaluator = rangeSet.RangeEvaluator;
            var diff = evaluator.Compare(start, end);
            if (diff > 0) return false;
            if (rangeSet.ContainsAllPossibleValues) return true;
            if (diff == 0) return Contains(start, rangeSet);
            foreach (var item in rangeSet.GetAllNodes())
                if (evaluator.Compare(start, item.Start) >= 0) return evaluator.Compare(end, item.End) <= 0;
            return false;
        }

        internal static bool Contains(T value, SequentialRangeSet<T> rangeSet)
        {
            if (rangeSet.ContainsAllPossibleValues) return true;
            var evaluator = rangeSet.RangeEvaluator;
            foreach (var item in rangeSet.GetAllNodes())
            {
                int diff = evaluator.Compare(value, item.Start);
                if (diff == 0) return true;
                if (diff < 0) return false;
                if (evaluator.Compare(value, item.End) <= 0) return true;
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
                var evaluator = rangeSet.RangeEvaluator;
                foreach (var range in rangeSet.GetAllNodes())
                {
                    int diff = evaluator.Compare(item.Start, range.Start);
                    if (diff < 0) return false;
                    if (diff == 0) return evaluator.AreEqual(item.End, range.End);
                }
            }
            finally { Monitor.Exit(item.SyncRoot); }
            return false;
        }

        [Obsolete("Use GetAllNodes")]
        internal static IEnumerable<RangeItem> GetRanges(SequentialRangeSet<T> rangeSet)
        {
            IHasChangeToken ct = rangeSet;
            object changeToken =  ct.ChangeToken;
            for (var item = rangeSet.First; item is not null; item = item.Next)
            {
                if (!ReferenceEquals(changeToken, ct.ChangeToken)) throw new InvalidOperationException(ErrorMessage_SequentialRangeSetChanged);
                yield return item;
            }
        }

        internal static int IndexOf(RangeItem value, SequentialRangeSet<T> rangeSet)
        {
            int index = 0;
            var evaluator = rangeSet.RangeEvaluator;
            foreach (var item in rangeSet.GetAllNodes())
            {
                int diff = evaluator.Compare(value.Start, item.Start);
                if (diff < 0) return -1;
                if (diff == 0) return evaluator.AreEqual(value.End, item.End) ? index : -1;
                index++;
            }
            return -1;
        }

        internal static bool Remove(T value, SequentialRangeSet<T> rangeSet)
        {
            var item = rangeSet.First;
            var evaluator = rangeSet.RangeEvaluator;
            while (item is not null)
            {
                int diff = evaluator.Compare(value, item.Start);
                if (diff < 0) return false;
                if (diff == 0)
                {
                    if (item.IsSingleValue)
                        Unlink(item, rangeSet);
                    else
                        item.SetStart(evaluator.GetIncrementedValue(value));
                    return true;
                }
                if ((diff = evaluator.Compare(value, item.End)) < 0)
                {
                    var end = item.End;
                    item.SetEnd(evaluator.GetDecrementedValue(value));
                    rangeSet.InsertAfter(new RangeItem(evaluator.GetIncrementedValue(value), end, evaluator), item);
                    return true;
                }
                else if (diff == 0)
                {
                    item.SetEnd(evaluator.GetDecrementedValue(value));
                    return true;
                }
                item = item.Next;
            }
            return false;
        }

        internal static bool Remove(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var evaluator = rangeSet.RangeEvaluator;
            var item = rangeSet.First;
            if (item is null || !evaluator.IsValidRange(start, end, out bool isSingleValue, out bool isMaxRange)) return false;
            if (isMaxRange)
            {
                Clear(rangeSet);
                return true;
            }
            if (isSingleValue) return Remove(start, rangeSet);
            
            int diff;
            while ((diff = evaluator.Compare(start, item.End)) > 0)
            {
                item = item.Next;
                if (item is null) return false;
            }
            if (diff == 0)
            {
                // start == item.End
                if (item.IsSingleValue)
                {
                    var next = item.Next;
                    item.Unlink();
                    item = next;
                }
                else
                {
                    item.SetEnd(evaluator.GetDecrementedValue(start));
                    item = item.Next;
                }
            }
            else if (evaluator.Compare(start, item.Start) > 0)
            {
                var oldEnd = item.End;
                item.SetEnd(evaluator.GetDecrementedValue(start));
                if (evaluator.Compare(end, oldEnd) < 0)
                {
                    InsertAfter(new RangeItem(evaluator.GetIncrementedValue(end), oldEnd, evaluator), item, rangeSet);
                    return true;
                }
                item = item.Next;
            }
            else
            {
                if ((diff = evaluator.Compare(end, item.End)) == 0)
                {
                    item.Unlink();
                    return true;
                }
                if (diff < 0)
                {
                    item.SetStart(evaluator.GetIncrementedValue(end));
                    return true;
                }
                var next = item.Next;
                item.Unlink();
                item = next;
            }
            if (item is null) return true;
            while ((diff = evaluator.Compare(end, item.End)) > 0)
            {
                var next = item.Next;
                item.Unlink();
                item = next;
                if (item is null) return true;
            }
            if (diff == 0)
                item.Unlink();
            else if (evaluator.Compare(end, item.Start) >= 0)
                item.SetStart(evaluator.GetIncrementedValue(end));
            return true;
        }

        #endregion

        #region Non-Public Instance Methods

        internal IEnumerable<T> GetValues()
        {
            IRangeEvaluator<T> evaluator;
            object changeToken;
            Monitor.Enter(SyncRoot);
            try
            {
                evaluator = _evaluator;
                changeToken = _changeToken;
            }
            finally { Monitor.Exit(SyncRoot); }
            if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
            var value = Start;
            yield return value;
            while (evaluator.Compare(value, End) < 0)
            {
                if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
                value = evaluator.GetIncrementedValue(value);
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
            IsSingleValue = false;
            IsMaxRange = _evaluator.AreEqual(Start, _evaluator.MinValue) && _evaluator.AreEqual(end, _evaluator.MaxValue);
            if (Owner is SequentialRangeSet<T> owner) owner.ContainsAllPossibleValues = IsMaxRange;
        }

        private void SetEnd(T end)
        {
            if (_evaluator.AreEqual(end, End)) return;
            bool isSingleValue = _evaluator.AssertValidRange(Start, end);
            if (Next is not null) _evaluator.AssertCanInsert(end, Next.Start);
            _changeToken = new();
            End = end;
            IsSingleValue = isSingleValue;
            IsMaxRange = !isSingleValue && _evaluator.AreEqual(Start, _evaluator.MinValue) && _evaluator.AreEqual(end, _evaluator.MaxValue);
            if (Owner is SequentialRangeSet<T> owner)
            {
                owner.SetChanged();
                owner.ContainsAllPossibleValues = IsMaxRange;
            }
        }

        private void SetRange(T start, T end)
        {
            if (_evaluator.AreEqual(start, Start) && _evaluator.AreEqual(end, End)) return;
            bool isSingleValue = _evaluator.AssertValidRange(start, end);
            if (Next is not null) _evaluator.AssertCanInsert(end, Next.Start);
            if (Previous is not null) _evaluator.AssertCanInsert(Previous.End, start);
            _changeToken = new();
            Start = start;
            End = end;
            IsSingleValue = isSingleValue;
            IsMaxRange = !isSingleValue && _evaluator.AreEqual(start, _evaluator.MinValue) && _evaluator.AreEqual(end, _evaluator.MaxValue);
            if (Owner is SequentialRangeSet<T> owner)
            {
                owner.SetChanged();
                owner.ContainsAllPossibleValues = IsMaxRange;
            }
        }

        private void SetStart(T start)
        {
            if (_evaluator.AreEqual(start, Start)) return;
            bool isSingleValue = _evaluator.AssertValidRange(start, End);
            if (Previous is not null) _evaluator.AssertCanInsert(Previous.End, start);
            _changeToken = new();
            Start = start;
            IsSingleValue = isSingleValue;
            IsMaxRange = !isSingleValue && _evaluator.AreEqual(start, _evaluator.MinValue) && _evaluator.AreEqual(End, _evaluator.MaxValue);
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
                start = _evaluator.GetIncrementedValue(End);
                if (_evaluator.IsValidPrecedingRangeEnd(start, next.Start))
                {
                    end = _evaluator.GetDecrementedValue(next.Start, 2);
                    return true;
                }
                return next.TryGetNextAvailableRange(out start, out end, out next);
            }
            if (_evaluator.IsValidPrecedingRangeEnd(End, _evaluator.MaxValue))
            {
                start = _evaluator.GetIncrementedValue(End, 2);
                end = _evaluator.MaxValue;
                return true;
            }
            start = Start;
            end = End;
            return false;
        }

        [Obsolete("Use methods on base class")]
        internal void Remove()
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Public Instance Methods

        public bool Contains(T value) => _evaluator.IsInRange(value, Start, End);

        public bool Contains(T start, T end)
        {
            var diff = _evaluator.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return IsSingleValue ? _evaluator.AreEqual(start, Start) : _evaluator.IsInRange(start, Start, End);
            return IsSingleValue ? _evaluator.IsInRange(Start, start, end) :
                (diff = _evaluator.Compare(start, Start)) == 0 || (diff > 0 && _evaluator.Compare(end, End) <= 0);
        }

        void ICollection.CopyTo(Array array, int index) => GetValues().ToArray().CopyTo(array, index);

        public bool Equals(T value) => IsSingleValue && _evaluator.AreEqual(value, Start);

        public bool Equals(IValueRange<T>? other) => other is not null && _evaluator.AreEqual(other.Start, Start) && _evaluator.AreEqual(other.End, End);

        public bool Equals(T start, T end) => _evaluator.AreEqual(start, Start) && _evaluator.AreEqual(end, End);

        public override bool Equals([NotNullWhen(true)] object? obj) => obj is not null && ((obj is IValueRange<T> other) ? Equals(other) : obj is T value && Equals(value));

        public bool Follows(T value) => _evaluator.Compare(value, Start) < 0;

        public bool Follows(IValueRange<T> item) => item is not null && _evaluator.Compare(item.End, Start) < 0;

        public bool FollowsWithGap(T value) => _evaluator.IsValidPrecedingRangeEnd(value, Start);

        public bool FollowsWithGap(IValueRange<T> item) => item is not null && _evaluator.IsValidPrecedingRangeEnd(item.End, Start);

        public ulong GetCount() => IsSingleValue ? 1UL : IsMaxRange ? 0UL : _evaluator.GetLongCountInRange(Start, End);

        public override int GetHashCode() => HashCode.Combine(Start, End);

        public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

        public bool ImmediatelyFollows(T value) => _evaluator.IsSequentiallyAdjacent(value, Start);

        public bool ImmediatelyFollows(IValueRange<T> item) => item is not null && _evaluator.IsSequentiallyAdjacent(item.End, Start);

        public bool ImmediatelyPrecedes(T value) => _evaluator.IsSequentiallyAdjacent(End, value);

        public bool ImmediatelyPrecedes(IValueRange<T> item) => item is not null && _evaluator.IsSequentiallyAdjacent(End, item.Start);

        public bool Overlaps(T start, T end)
        {
            int diff = _evaluator.Compare(start, End);
            return diff == 0 || (diff < 0 && _evaluator.Compare(end, Start) >= 0);
        }

        public bool Overlaps(IValueRange<T> item)
        {
            if (item is null) return false;
            int diff = _evaluator.Compare(item.Start, End);
            return diff == 0 || (diff < 0 && _evaluator.Compare(item.End, Start) >= 0);
        }

        public bool Precedes(T value) => _evaluator.Compare(value, End) > 0;

        public bool Precedes(IValueRange<T> item) => item is not null && _evaluator.Compare(item.Start, End) > 0;

        public bool PrecedesWithGap(T value) => _evaluator.IsValidPrecedingRangeEnd(End, value);

        public bool PrecedesWithGap(IValueRange<T> item) => item is not null && _evaluator.IsValidPrecedingRangeEnd(End, item.Start);

        public override string ToString() => IsSingleValue ? $"[{Start}]" : $"[{Start}..{End}]";

        #endregion
    }
}
