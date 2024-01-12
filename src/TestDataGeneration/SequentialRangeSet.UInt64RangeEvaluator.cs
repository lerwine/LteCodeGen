namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public static readonly UInt64RangeEvaluator UInt64 = UInt64RangeEvaluator.Instance;
    
    public sealed class UInt64RangeEvaluator : IRangeEvaluator<ulong>
    {
        public static readonly UInt64RangeEvaluator Instance = new();

        private UInt64RangeEvaluator() { }

        public ulong MaxValue => ulong.MaxValue;

        public ulong MinValue => ulong.MinValue;

        public int Compare(ulong x, ulong y) => x.CompareTo(y);

        public ulong GetDecrementedValue(ulong value, int count = 1) => value - (ulong)count;

        public ulong GetIncrementedValue(ulong value, int count = 1) => value + (ulong)count;

        public ulong GetLongCountInRange(ulong firstInclusive, ulong lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == ulong.MaxValue && lastInclusive == ulong.MaxValue)) ? 0UL : lastInclusive - firstInclusive + 1UL;

        public IEnumerable<ulong> GetSequentialValuesInRange(ulong firstInclusive, ulong lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(ulong value, ulong start, ulong end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(ulong previousValue, ulong nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
