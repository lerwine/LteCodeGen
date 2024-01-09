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

        public int GetCountInRange(long firstInclusive, long lastInclusive)
        {
            var result = lastInclusive - firstInclusive + 1L;
            if (result < 0) return 0;
            return (result > int.MaxValue) ? int.MaxValue : (int)result;
        }

        public long GetDecrementedValue(long value, int count = 1) => value - count;

        public long GetIncrementedValue(long value, int count = 1) => value + count;

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
