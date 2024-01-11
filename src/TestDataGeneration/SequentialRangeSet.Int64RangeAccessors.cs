namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class Int64RangeAccessors : IRangeSequenceAccessors<long>
    {
        public static readonly Int64RangeAccessors Instance = new();

        private Int64RangeAccessors() { }

        public long MaxValue => long.MaxValue;

        public long MinValue => long.MinValue;

        public int Compare(long x, long y) => x.CompareTo(y);

        public long GetDecrementedValue(long value, int count = 1) => value - count;

        public long GetIncrementedValue(long value, int count = 1) => value + count;

        public ulong GetLongCountInRange(long firstInclusive, long lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == long.MinValue && lastInclusive == long.MaxValue)) ? 0UL : (ulong)(lastInclusive - firstInclusive) + 1UL;

        public IEnumerable<long> GetSequentialValuesInRange(long firstInclusive, long lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(long value, long start, long end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(long previousValue, long nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
