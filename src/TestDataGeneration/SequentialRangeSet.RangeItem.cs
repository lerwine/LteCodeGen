using System.Buffers;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public partial class SequentialRangeSet<T>
{
    /// <summary>
    /// A linked node for a value range.
    /// </summary>
    public class RangeItem : IValueRange<T>, IReadOnlyCollection<T>, ICollection, IHasChangeToken
    {
        #region Fields

        private const string ErrorMessage_InvalidRangeItemInsert = $"A {nameof(RangeItem)} which is immediately adjacent to or overlaps an existing item cannot be inserted.";

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

        public bool IsMaxRange { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the range has only one value.
        /// </summary>
        /// <value><see langword="true"/> if <see cref="Start"/> is equal to <see cref="End"/>; otherwise, <see langword="false"/>.</value>
        public bool IsSingleValue { get; private set; }

        /// <summary>
        /// Gets the preceding range in order.
        /// </summary>
        /// <value>The preceding range whose <see cref="End"/> value is at least 2 increments less than the current <see cref="Start"/> value or <see langword="null"/> if this is there is no lesser range set.</value>
        public RangeItem? Previous { get; private set; }

        /// <summary>
        /// Gets the following range in order.
        /// </summary>
        /// <value>The following range whose <see cref="Start"/> value is at least 2 increments greater than the current <see cref="End"/> value or <see langword="null"/> if this is there is no greater range set.</value>
        public RangeItem? Next { get; private set; }

        /// <summary>
        /// Gets the collection that this set belongs to.
        /// </summary>
        /// <value>The collection that this set belongs to or <see langword="null"/> if this has not been added to a <see cref="SequentialRangeSet{T}"/>.</value>
        public SequentialRangeSet<T>? Owner { get; private set; }

        /// <summary>
        /// Gets the object that can be used to synchronize access.
        /// </summary>
        public object SyncRoot { get; } = new();

        #region Explicit Properties

        object IHasChangeToken.ChangeToken => _changeToken;

        int IReadOnlyCollection<T>.Count => (int)_evaluator.GetLongCountInRange(Start, End);

        int ICollection.Count => (int)_evaluator.GetLongCountInRange(Start, End);

        bool ICollection.IsSynchronized => true;

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

        private RangeItem(RangeItem copyFrom, SequentialRangeSet<T> owner)
        {
            _evaluator = owner.RangeEvaluator;
            Start = copyFrom.Start;
            End = copyFrom.End;
            if (ReferenceEquals(_evaluator, copyFrom._evaluator))
                IsSingleValue = copyFrom.IsSingleValue;
            else
            {
                if (!(_evaluator = (Owner = owner).RangeEvaluator).IsValidRange(Start, End, out bool isSingleValue, out bool isMaxRange))
                    throw new ArgumentOutOfRangeException(nameof(copyFrom), $"The {nameof(copyFrom)} range {nameof(Start)} value cannot be greater than the {nameof(End)} value.");
                IsSingleValue = isSingleValue;
                IsMaxRange = isMaxRange;
            }
        }

        private RangeItem(T start, T end, SequentialRangeSet<T> owner)
        {
            if (!(_evaluator = (Owner = owner).RangeEvaluator).IsValidRange(start, end, out bool isSingleValue, out bool isMaxRange))
                throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            Start = start;
            End = end;
            IsSingleValue = isSingleValue;
            IsMaxRange = isMaxRange;
        }

        private RangeItem(T start, T end, bool isSingleValue, bool isMaxRange, SequentialRangeSet<T> owner)
        {
            _evaluator = (Owner = owner).RangeEvaluator;
            Start = start;
            End = end;
            IsSingleValue = isSingleValue;
            IsMaxRange = isMaxRange;
        }

        private RangeItem(T value, SequentialRangeSet<T> owner)
        {
            _evaluator = (Owner = owner).RangeEvaluator;
            Start = End = value;
            IsSingleValue = true;
        }

        #endregion

        #region Static Methods

        internal static void Add(RangeItem item, SequentialRangeSet<T> owner)
        {
            if (item.Owner is not null)
            {
                if (ReferenceEquals(item.Owner, owner)) return;
                new RangeItem(item, owner).Add();
            }
            else
            {
                var oldEvaluator = item._evaluator;
                var wasSingleValue = item.IsSingleValue;
                var wasMaxRange = item.IsMaxRange;
                var evaluator = owner.RangeEvaluator;
                try
                {
                    item.Owner = owner;
                    if (ReferenceEquals(evaluator, oldEvaluator))
                        item.Add();
                    else
                    {
                        item._evaluator = evaluator;
                        if (!evaluator.IsValidRange(item.Start, item.End, out bool isSingleValue, out bool isMaxRange))
                            throw new ArgumentOutOfRangeException(nameof(item), $"The {nameof(Start)} range value cannot be greater than the {nameof(End)} value.");
                        item.IsSingleValue = isSingleValue;
                        item.IsMaxRange = isMaxRange;
                        item.Add();
                        item._changeToken = new();
                    }
                }
                catch
                {
                    item.Owner = null;
                    item._evaluator = oldEvaluator;
                    item.IsSingleValue = wasSingleValue;
                    item.IsMaxRange = wasMaxRange;
                    throw;
                }
            }
        }

        internal static bool Add(T start, T end, SequentialRangeSet<T> owner)
        {
            var evaluator = owner.RangeEvaluator;
            if (!evaluator.IsValidRange(start, end, out bool isSingleValue, out bool isMaxRange)) return false;
            var previous = owner.First;
            if (previous is null)
            {
                new RangeItem(start, end, isSingleValue, isMaxRange, owner).LinkAfter(null);
                return true; 
            }
            if (isMaxRange) return false;
            int diff = evaluator.Compare(end, previous.Start);
            if (diff < 0)
            {
                if (evaluator.IsSequentiallyAdjacent(end, previous.Start))
                    previous.SetStart(start);
                else
                    new RangeItem(start, end, isSingleValue, isMaxRange, owner).LinkAfter(null);
                return true;
            }
            if (diff == 0)
            {
                previous.SetStart(start);
                return true;
            }
            if (evaluator.Compare(end, previous.End) <= 0)
            {
                if (evaluator.Compare(start, previous.Start) >= 0) return false;
                previous.SetStart(start);
                return true;
            }
            // end > previous.End
            var next = previous.Next;
            if (next is null)
            {
                if (evaluator.Compare(start, previous.Start) < 0)
                    previous.SetRange(start, end);
                else if (evaluator.Compare(previous.End, start) >= 0 || evaluator.IsSequentiallyAdjacent(previous.End, start))
                    previous.SetEnd(end);
                else
                    new RangeItem(start, end, isSingleValue, isMaxRange, owner).LinkAfter(previous);
                return true;
            }
            while (evaluator.IsValidPrecedingRangeEnd(previous.End, start))
            {
                next = (previous = next).Next;
                if (next is null)
                {
                    new RangeItem(start, end, isSingleValue, isMaxRange, owner).LinkAfter(previous);
                    return true;
                }
            }
            diff = evaluator.Compare(end, previous.End);
            var changed = diff > 0;
            if (changed)
                do
                {
                    previous.MergeWithNext();
                    diff = evaluator.Compare(end, previous.End);
                    previous = next;
                    if ((next = previous.Next) is null)
                    {
                        if (diff > 0)
                        {
                            if (evaluator.Compare(start, previous.Start) < 0)
                                previous.SetRange(start, end);
                            else if (evaluator.Compare(previous.End, start) <= 0 || evaluator.IsSequentiallyAdjacent(previous.End, start))
                                previous.SetEnd(end);
                            else
                                new RangeItem(start, end, isSingleValue, isMaxRange, owner).LinkAfter(previous);
                        }
                        else if (evaluator.Compare(start, previous.Start) < 0)
                            previous.SetStart(start);
                        return true;
                    }
                }
                while (diff > 0);
            if (evaluator.Compare(start, previous.Start) < 0)
            {
                previous.SetStart(start);
                return true;
            }
            return changed;
        }

        internal static bool Add(T value, SequentialRangeSet<T> owner)
        {
            var evaluator = owner.RangeEvaluator;
            var item = owner.First;
            if (item is null || evaluator.IsValidPrecedingRangeEnd(value, item.Start) || evaluator.IsValidPrecedingRangeEnd(value, item.Start))
                new RangeItem(value, owner).LinkAfter(null);
            else if (evaluator.IsSequentiallyAdjacent(value, item.Start))
                item.SetStart(value);
            else
            {
                int diff = evaluator.Compare(value, item.End);
                if (diff > 0)
                {
                    do
                    {
                        if (evaluator.IsSequentiallyAdjacent(item.End, value))
                        {
                            if (item.Next is not null && evaluator.IsSequentiallyAdjacent(value, item.Next.Start))
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
                        diff = evaluator.Compare(value, item.End);
                    }
                    while (diff > 0);
                    if (diff == 0) return false;
                    if (evaluator.IsValidPrecedingRangeEnd(value, item.Start))
                        new RangeItem(value, owner).LinkAfter(item.Previous);
                    else if (evaluator.IsSequentiallyAdjacent(value, item.Start))
                        item.SetStart(value);
                    else
                        return false;
                }
                else
                {
                    if (diff == 0) return false;
                    if (evaluator.IsSequentiallyAdjacent(value, item.Start))
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

        internal static bool Contains(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var evaluator = rangeSet.RangeEvaluator;
            var diff = evaluator.Compare(start, end);
            if (diff > 0) return false;
            if (rangeSet.ContainsAllPossibleValues) return true;
            if (diff == 0) return Contains(start, rangeSet);
            foreach (var item in GetRanges(rangeSet))
                if (evaluator.Compare(start, item.Start) >= 0) return evaluator.Compare(end, item.End) <= 0;
            return false;
        }

        internal static bool Contains(T value, SequentialRangeSet<T> rangeSet)
        {
            if (rangeSet.ContainsAllPossibleValues) return true;
            var evaluator = rangeSet.RangeEvaluator;
            foreach (var item in GetRanges(rangeSet))
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
                foreach (var range in GetRanges(rangeSet))
                {
                    int diff = evaluator.Compare(item.Start, range.Start);
                    if (diff < 0) return false;
                    if (diff == 0) return evaluator.AreEqual(item.End, range.End);
                }
            }
            finally { Monitor.Exit(item.SyncRoot); }
            return false;
        }

        internal static IEnumerable<RangeItem> GetRanges(SequentialRangeSet<T> rangeSet)
        {
            object changeToken = rangeSet._changeToken;
            for (var item = rangeSet.First; item is not null; item = item.Next)
            {
                if (!ReferenceEquals(changeToken, rangeSet._changeToken)) throw new InvalidOperationException(ErrorMessage_SequentialRangeSetChanged);
                yield return item;
            }
        }

        internal static int IndexOf(RangeItem value, SequentialRangeSet<T> rangeSet)
        {
            int index = 0;
            var evaluator = rangeSet.RangeEvaluator;
            foreach (var item in GetRanges(rangeSet))
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
                        item.Remove();
                    else
                        item.SetStart(evaluator.GetIncrementedValue(value));
                    return true;
                }
                if ((diff = evaluator.Compare(value, item.End)) < 0)
                {
                    value = evaluator.GetIncrementedValue(value);
                    var end = item.End;
                    item.SetEnd(evaluator.GetDecrementedValue(value));
                    new RangeItem(value, end, rangeSet).LinkAfter(item);
                    return true;
                }
                else if (diff == 0)
                {
                    item.SetEnd(evaluator.GetDecrementedValue(value));
                    return true;
                }
            }
            return false;
        }

        internal static bool Remove(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var evaluator = rangeSet.RangeEvaluator;
            int diff = evaluator.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return Remove(start, rangeSet);
            var item = rangeSet.First;
            if (item is null) return false;
            while (evaluator.Compare(start, item.End) > 0)
            {
                item = item.Next;
                if (item is null) return false;
            }
            if ((diff = evaluator.Compare(end, item.Start)) < 0) return false;
            if (diff == 0)
            {
                if (item.IsSingleValue)
                    item.Remove();
                else
                    item.SetStart(evaluator.GetIncrementedValue(end));
            }
            else
            {
                while (evaluator.Compare(end, item.End) > 0)
                {
                    item.MergeWithNext();
                    if (item.Next is null) break;
                }
                if (evaluator.Compare(start, item.Start) <= 0)
                {
                    if (evaluator.Compare(end, item.End) >= 0)
                        item.Remove();
                    else
                        item.SetStart(evaluator.GetIncrementedValue(end));
                }
                else if (evaluator.Compare(end, item.End) >= 0)
                    item.SetEnd(evaluator.GetDecrementedValue(start));
                else
                {
                    var nextEnd = item.End;
                    item.SetEnd(evaluator.GetDecrementedValue(start));
                    new RangeItem(evaluator.GetIncrementedValue(end), nextEnd, rangeSet).LinkAfter(item);
                }
            }
            return true;
        }

        #endregion

        #region Non-Public Instance Methods

        private void Add()
        {
            var previous = Owner!.First;
            if (previous is null)
            {
                LinkAfter(null);
                return;
            }
            int diff = _evaluator.Compare(End, previous.Start);
            if (diff == 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
            if (diff < 0)
            {
                if (_evaluator.IsSequentiallyAdjacent(End, previous.Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                previous = null;
            }
            else if (IsSingleValue)
            {
                var next = previous.Next;
                if (!previous.IsSingleValue && _evaluator.Compare(Start, previous.End) <= 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                if (_evaluator.IsSequentiallyAdjacent(previous.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                while (next is not null)
                {
                    if ((diff = _evaluator.Compare(Start, next.Start)) < 0)
                    {
                        if (_evaluator.IsSequentiallyAdjacent(Start, next.Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                        break;
                    }
                    if (diff == 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    next = (previous = next).Next;
                    if (!previous.IsSingleValue && _evaluator.Compare(Start, previous.End) <= 0) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    if (_evaluator.IsSequentiallyAdjacent(previous.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                }
            }
            else
            {
                if (_evaluator.Compare(Start, previous.End) <= 0 || _evaluator.IsSequentiallyAdjacent(previous.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                var next = previous.Next;
                while (next is not null)
                {
                    if ((diff = _evaluator.Compare(End, next.End)) < 0)
                    {
                        if (_evaluator.Compare(End, next.Start) >= 0 || _evaluator.IsSequentiallyAdjacent(End, next.Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                        break;
                    }
                    else if (diff == 0)
                        throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    if (_evaluator.Compare(Start, next.End) < 0 || _evaluator.IsSequentiallyAdjacent(next.End, Start)) throw new InvalidOperationException(ErrorMessage_InvalidRangeItemInsert);
                    next = (previous = next).Next;
                }
            }
            LinkAfter(previous);
        }

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
            while (evaluator.Compare(value, End) > 0)
            {
                if (!ReferenceEquals(changeToken, _changeToken)) throw new InvalidOperationException("Collection has changed.");
                value = evaluator.GetIncrementedValue(value);
                yield return value;
            }
        }

        private void LinkAfter(RangeItem? previous)
        {
            if (Owner is null) throw new InvalidOperationException();
            Owner._changeToken = new();
            if ((Previous = previous) is null)
            {
                if ((Next = Owner!.First) is null)
                {
                    Owner.Last = this;
                    Owner.ContainsAllPossibleValues = IsMaxRange;
                }
                else
                {
                    Next.Previous = this;
                    Owner.ContainsAllPossibleValues = false;
                }
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
            IsMaxRange = _evaluator.AreEqual(Start, _evaluator.MinValue) && _evaluator.AreEqual(end, _evaluator.MaxValue);
            Owner!.ContainsAllPossibleValues = IsMaxRange;
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
            if (Owner is not null)
            {
                Owner._changeToken = new();
                Owner.ContainsAllPossibleValues = IsMaxRange;
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
            if (Owner is not null)
            {
                Owner._changeToken = new();
                Owner.ContainsAllPossibleValues = IsMaxRange;
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
            if (Owner is not null)
            {
                Owner._changeToken = new();
                Owner.ContainsAllPossibleValues = IsMaxRange;
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

        internal void Remove()
        {
            if (Owner is null) throw new InvalidOperationException();
            if (Next is null)
            {
                if ((Owner.Last = Previous) is null)
                {
                    Owner.First = null;
                    Owner.ContainsAllPossibleValues = false;
                }
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
