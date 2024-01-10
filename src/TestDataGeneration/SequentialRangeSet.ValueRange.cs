using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public partial class SequentialRangeSet<T>
{
    readonly struct ValueRange : IValueRange<T>
    {
        private readonly IRangeSequenceAccessors<T> _accessors;

        public bool IsSingleValue { get; }

        public T Start { get; }

        public T End { get; }

        public bool IsMaxRange { get; }

        internal ValueRange(T start, T end, IRangeSequenceAccessors<T> accessors)
        {
            ArgumentNullException.ThrowIfNull(accessors);
            int diff = (_accessors = accessors).Compare(start, end);
            if (diff > 0) throw new ArgumentOutOfRangeException(nameof(start));
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

        public bool Contains(T value) => _accessors.IsInRange(value, Start, End);

        public bool Contains(T start, T end)
        {
            var diff = _accessors.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return IsSingleValue ? _accessors.AreEqual(start, Start) : _accessors.IsInRange(start, Start, End);
            return IsSingleValue ? _accessors.IsInRange(Start, start, end) :
                (diff = _accessors.Compare(start, Start)) == 0 || (diff > 0 && _accessors.Compare(end, End) <= 0);
        }

        public bool Equals(T value) => IsSingleValue && _accessors.AreEqual(value, Start);

        public bool Equals(IValueRange<T>? other) => other is not null && _accessors.AreEqual(other.Start, Start) && _accessors.AreEqual(other.End, End);

        public bool Equals(T start, T end) => _accessors.AreEqual(start, Start) && _accessors.AreEqual(end, End);

        public override bool Equals([NotNullWhen(true)] object? obj) => obj is not null && ((obj is IValueRange<T> other) ? Equals(other) : obj is T value && Equals(value));

        public bool Follows(T value) => _accessors.Compare(value, Start) < 0;

        public bool Follows(IValueRange<T> item) => item is not null && _accessors.Compare(item.End, Start) < 0;

        public bool FollowsWithGap(T value) => _accessors.CanInsert(value, Start);

        public bool FollowsWithGap(IValueRange<T> item) => item is not null && _accessors.CanInsert(item.End, Start);

        public ulong GetCount() => IsSingleValue ? 1UL : IsMaxRange ? 0UL : _accessors.GetLongCountInRange(Start, End);

        public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

        internal IEnumerable<T> GetValues()
        {
            var value = Start;
            yield return value;
            while (_accessors.Compare(value, End) > 0)
            {
                value = _accessors.GetIncrementedValue(value);
                yield return value;
            }
        }

        public override int GetHashCode() => HashCode.Combine(Start, End);

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
    }
}
