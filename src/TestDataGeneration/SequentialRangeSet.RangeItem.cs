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

        private IRangeSequenceAccessors<T> _accessors;

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

        int IReadOnlyCollection<T>.Count => (int)_accessors.GetLongCountInRange(Start, End);

        int ICollection.Count => (int)_accessors.GetLongCountInRange(Start, End);

        bool ICollection.IsSynchronized => true;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new <c>RangeItem</c> object from the properties of an existing object.
        /// </summary>
        /// <param name="copyFrom">The object to copy properties from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="accessors"/> is <see langword="null"/>.</exception>
        public RangeItem(RangeItem copyFrom)
        {
            ArgumentNullException.ThrowIfNull(copyFrom);
            _accessors = copyFrom._accessors;
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
        /// <param name="accessors">The object used to test and manipulate <typeparamref name="T"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="accessors"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="start"/> is greater than <paramref name="end"/>.</exception>
        public RangeItem(T start, T end, IRangeSequenceAccessors<T> accessors)
        {
            ArgumentNullException.ThrowIfNull(accessors);
            int diff = (_accessors = accessors).Compare(start, end);
            if (diff > 0) throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            Start = start;
            End = end;
            if (diff == 0)
            {
                IsSingleValue = true;
                IsMaxRange = false;
            }
            else
            {
                IsSingleValue = false;
                IsMaxRange = accessors.AreEqual(start, accessors.MinValue) && accessors.AreEqual(end, accessors.MaxValue);
            }
        }

        /// <summary>
        /// Initialize a new single-value <c>RangeItem</c> object.
        /// </summary>
        /// <param name="value">The single value for the value range.</param>
        /// <param name="accessors">The object used to test and manipulate <typeparamref name="T"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="accessors"/> is <see langword="null"/>.</exception>
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
                if (diff == 0)
                {
                    IsSingleValue = true;
                    IsMaxRange = false;
                }
                else
                {
                    IsSingleValue = false;
                    IsMaxRange = _accessors.AreEqual(Start, _accessors.MinValue) && _accessors.AreEqual(End, _accessors.MaxValue);
                }
            }
        }

        private RangeItem(T start, T end, SequentialRangeSet<T> owner)
        {
            int diff = (_accessors = (Owner = owner).Accessors).Compare(start, end);
            if (diff > 0) throw new ArgumentOutOfRangeException(nameof(start), $"The {nameof(start)} range value cannot be greater than the {nameof(end)} value.");
            Start = start;
            End = end;
            if (diff == 0)
            {
                IsSingleValue = true;
                IsMaxRange = false;
            }
            else
            {
                IsSingleValue = false;
                IsMaxRange = _accessors.AreEqual(start, _accessors.MinValue) && _accessors.AreEqual(end, _accessors.MaxValue);
            }
        }

        private RangeItem(T value, SequentialRangeSet<T> owner)
        {
            _accessors = (Owner = owner).Accessors;
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

        internal static bool Contains(T start, T end, SequentialRangeSet<T> rangeSet)
        {
            var accessors = rangeSet.Accessors;
            var diff = accessors.Compare(start, end);
            if (diff > 0) return false;
            if (rangeSet.ContainsAllPossibleValues) return true;
            if (diff == 0) return Contains(start, rangeSet);
            foreach (var item in GetRanges(rangeSet))
                if (accessors.Compare(start, item.Start) >= 0) return accessors.Compare(end, item.End) <= 0;
            return false;
        }

        internal static bool Contains(T value, SequentialRangeSet<T> rangeSet)
        {
            if (rangeSet.ContainsAllPossibleValues) return true;
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
            Monitor.Enter(item.SyncRoot);
            try
            {
                if (item.Owner is null || !ReferenceEquals(item.Owner, rangeSet)) return false;
                if (rangeSet.ContainsAllPossibleValues) return true;
                var accessors = rangeSet.Accessors;
                foreach (var range in GetRanges(rangeSet))
                {
                    int diff = accessors.Compare(item.Start, range.Start);
                    if (diff < 0) return false;
                    if (diff == 0) return accessors.AreEqual(item.End, range.End);
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
                    Owner.ContainsAllPossibleValues = false;
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
            IsMaxRange = _accessors.AreEqual(Start, _accessors.MinValue) && _accessors.AreEqual(end, _accessors.MaxValue);
            Owner!.ContainsAllPossibleValues = IsMaxRange;
        }

        private void SetEnd(T end)
        {
            if (_accessors.AreEqual(end, End)) return;
            int diff = _accessors.Compare(Start, end);
            if (diff < 0 || (Next is not null && !_accessors.CanInsert(end, Next.Start))) throw new InvalidOperationException();
            _changeToken = new();
            End = end;
            if (diff == 0)
            {
                IsSingleValue = true;
                IsMaxRange = false;
            }
            else
            {
                IsSingleValue = false;
                IsMaxRange = _accessors.AreEqual(Start, _accessors.MinValue) && _accessors.AreEqual(end, _accessors.MaxValue);
            }
            if (Owner is not null)
            {
                Owner._changeToken = new();
                Owner.ContainsAllPossibleValues = IsMaxRange;
            }
        }

        private void SetRange(T start, T end)
        {
            if (_accessors.AreEqual(start, Start) && _accessors.AreEqual(end, End)) return;
            int diff = _accessors.Compare(start, end);
            if (diff < 0 || (Previous is not null && !_accessors.CanInsert(Previous.End, start)) || (Next is not null && !_accessors.CanInsert(end, Next.Start))) throw new InvalidOperationException();
            _changeToken = new();
            Start = start;
            End = end;
            if (diff == 0)
            {
                IsSingleValue = true;
                IsMaxRange = false;
            }
            else
            {
                IsSingleValue = false;
                IsMaxRange = _accessors.AreEqual(start, _accessors.MinValue) && _accessors.AreEqual(end, _accessors.MaxValue);
            }
            if (Owner is not null)
            {
                Owner._changeToken = new();
                Owner.ContainsAllPossibleValues = IsMaxRange;
            }
        }

        private void SetStart(T start)
        {
            if (_accessors.AreEqual(start, Start)) return;
            int diff = _accessors.Compare(start, End);
            if (diff < 0 || (Previous is not null && !_accessors.CanInsert(Previous.End, start))) throw new InvalidOperationException();
            _changeToken = new();
            Start = start;
            if (diff == 0)
            {
                IsSingleValue = true;
                IsMaxRange = false;
            }
            else
            {
                IsSingleValue = false;
                IsMaxRange = _accessors.AreEqual(start, _accessors.MinValue) && _accessors.AreEqual(End, _accessors.MaxValue);
            }
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

        public bool Contains(T value) => _accessors.IsInRange(value, Start, End);

        public bool Contains(T start, T end)
        {
            var diff = _accessors.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return IsSingleValue ? _accessors.AreEqual(start, Start) : _accessors.IsInRange(start, Start, End);
            return IsSingleValue ? _accessors.IsInRange(Start, start, end) :
                (diff = _accessors.Compare(start, Start)) == 0 || (diff > 0 && _accessors.Compare(end, End) <= 0);
        }

        void ICollection.CopyTo(Array array, int index) => GetValues().ToArray().CopyTo(array, index);

        public bool Equals(T value) => IsSingleValue && _accessors.AreEqual(value, Start);

        public bool Equals(IValueRange<T>? other) => other is not null && _accessors.AreEqual(other.Start, Start) && _accessors.AreEqual(other.End, End);

        public bool Equals(T start, T end) => _accessors.AreEqual(start, Start) && _accessors.AreEqual(end, End);

        public override bool Equals([NotNullWhen(true)] object? obj) => obj is not null && ((obj is IValueRange<T> other) ? Equals(other) : obj is T value && Equals(value));

        public bool Follows(T value) => _accessors.Compare(value, Start) < 0;

        public bool Follows(IValueRange<T> item) => item is not null && _accessors.Compare(item.End, Start) < 0;

        public bool FollowsWithGap(T value) => _accessors.CanInsert(value, Start);

        public bool FollowsWithGap(IValueRange<T> item) => item is not null && _accessors.CanInsert(item.End, Start);

        public ulong GetCount() => IsSingleValue ? 1UL : IsMaxRange ? 0UL : _accessors.GetLongCountInRange(Start, End);

        public override int GetHashCode() => HashCode.Combine(Start, End);

        public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

        public bool ImmediatelyFollows(T value) => _accessors.IsSequentiallyAdjacent(value, Start);

        public bool ImmediatelyFollows(IValueRange<T> item) => item is not null && _accessors.IsSequentiallyAdjacent(item.End, Start);

        public bool ImmediatelyPrecedes(T value) => _accessors.IsSequentiallyAdjacent(End, value);

        public bool ImmediatelyPrecedes(IValueRange<T> item) => item is not null && _accessors.IsSequentiallyAdjacent(End, item.Start);

        public bool Overlaps(T start, T end)
        {
            int diff = _accessors.Compare(start, End);
            return diff == 0 || (diff < 0 && _accessors.Compare(end, Start) >= 0);
        }

        public bool Overlaps(IValueRange<T> item)
        {
            if (item is null) return false;
            int diff = _accessors.Compare(item.Start, End);
            return diff == 0 || (diff < 0 && _accessors.Compare(item.End, Start) >= 0);
        }

        public bool Precedes(T value) => _accessors.Compare(value, End) > 0;

        public bool Precedes(IValueRange<T> item) => item is not null && _accessors.Compare(item.Start, End) > 0;

        public bool PrecedesWithGap(T value) => _accessors.CanInsert(End, value);

        public bool PrecedesWithGap(IValueRange<T> item) => item is not null && _accessors.CanInsert(End, item.Start);

        public override string ToString() => IsSingleValue ? $"[{Start}]" : $"[{Start}..{End}]";

        #endregion
    }
}
