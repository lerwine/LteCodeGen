using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public partial class SequentialRangeSet<T>
{
    readonly struct ValueRange : IValueRange<T>
    {
        private readonly IRangeEvaluator<T> _rangeEvaluator;

        public bool IsSingleValue { get; }

        public T Start { get; }

        public T End { get; }

        public bool IsMaxRange { get; }

        internal ValueRange(T start, T end, IRangeEvaluator<T> rangeEvaluator)
        {
            ArgumentNullException.ThrowIfNull(rangeEvaluator);
            int diff = (_rangeEvaluator = rangeEvaluator).Compare(start, end);
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
                IsMaxRange = rangeEvaluator.AreEqual(start, rangeEvaluator.MinValue) && rangeEvaluator.AreEqual(end, rangeEvaluator.MaxValue);
            }
        }

        public bool Contains(T value) => _rangeEvaluator.IsInRange(value, Start, End);

        public bool Contains(T start, T end)
        {
            var diff = _rangeEvaluator.Compare(start, end);
            if (diff > 0) return false;
            if (diff == 0) return IsSingleValue ? _rangeEvaluator.AreEqual(start, Start) : _rangeEvaluator.IsInRange(start, Start, End);
            return IsSingleValue ? _rangeEvaluator.IsInRange(Start, start, end) :
                (diff = _rangeEvaluator.Compare(start, Start)) == 0 || (diff > 0 && _rangeEvaluator.Compare(end, End) <= 0);
        }

        public bool Equals(T value) => IsSingleValue && _rangeEvaluator.AreEqual(value, Start);

        public bool Equals(IValueRange<T>? other) => other is not null && _rangeEvaluator.AreEqual(other.Start, Start) && _rangeEvaluator.AreEqual(other.End, End);

        public bool Equals(T start, T end) => _rangeEvaluator.AreEqual(start, Start) && _rangeEvaluator.AreEqual(end, End);

        public override bool Equals([NotNullWhen(true)] object? obj) => obj is not null && ((obj is IValueRange<T> other) ? Equals(other) : obj is T value && Equals(value));

        public bool Follows(T value) => _rangeEvaluator.Compare(value, Start) < 0;

        public bool Follows(IValueRange<T> item) => item is not null && _rangeEvaluator.Compare(item.End, Start) < 0;

        public bool FollowsWithGap(T value) => _rangeEvaluator.IsValidPrecedingRangeEnd(value, Start);

        public bool FollowsWithGap(IValueRange<T> item) => item is not null && _rangeEvaluator.IsValidPrecedingRangeEnd(item.End, Start);

        public ulong GetCount() => IsSingleValue ? 1UL : IsMaxRange ? 0UL : _rangeEvaluator.GetLongCountInRange(Start, End);

        public IEnumerator<T> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetValues().GetEnumerator();

        internal IEnumerable<T> GetValues()
        {
            var value = Start;
            yield return value;
            while (_rangeEvaluator.Compare(value, End) > 0)
            {
                value = _rangeEvaluator.GetIncrementedValue(value);
                yield return value;
            }
        }

        public override int GetHashCode() => HashCode.Combine(Start, End);

        public bool ImmediatelyFollows(T value) => _rangeEvaluator.IsSequentiallyAdjacent(value, Start);

        public bool ImmediatelyFollows(IValueRange<T> item) => item is not null && _rangeEvaluator.IsSequentiallyAdjacent(item.End, Start);

        public bool ImmediatelyPrecedes(T value) => _rangeEvaluator.IsSequentiallyAdjacent(End, value);

        public bool ImmediatelyPrecedes(IValueRange<T> item) => item is not null && _rangeEvaluator.IsSequentiallyAdjacent(End, item.Start);

        public bool Overlaps(T start, T end)
        {
            int diff = _rangeEvaluator.Compare(start, End);
            return diff == 0 || (diff < 0 && _rangeEvaluator.Compare(end, Start) >= 0);
        }

        public bool Overlaps(IValueRange<T> item)
        {
            if (item is null) return false;
            int diff = _rangeEvaluator.Compare(item.Start, End);
            return diff == 0 || (diff < 0 && _rangeEvaluator.Compare(item.End, Start) >= 0);
        }

        public bool Precedes(T value) => _rangeEvaluator.Compare(value, End) > 0;

        public bool Precedes(IValueRange<T> item) => item is not null && _rangeEvaluator.Compare(item.Start, End) > 0;

        public bool PrecedesWithGap(T value) => _rangeEvaluator.IsValidPrecedingRangeEnd(End, value);

        public bool PrecedesWithGap(IValueRange<T> item) => item is not null && _rangeEvaluator.IsValidPrecedingRangeEnd(End, item.Start);

        public override string ToString() => IsSingleValue ? $"[{Start}]" : $"[{Start}..{End}]";
    }
}
