namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public static readonly SByteRangeEvaluator SByte = SByteRangeEvaluator.Instance;
    
    public sealed class SByteRangeEvaluator : IRangeEvaluator<sbyte>
    {
        public static readonly SByteRangeEvaluator Instance = new();

        private SByteRangeEvaluator() { }

        public sbyte MaxValue => sbyte.MaxValue;

        public sbyte MinValue => sbyte.MinValue;

        public int Compare(sbyte x, sbyte y) => x.CompareTo(y);

        public sbyte GetDecrementedValue(sbyte value, int count = 1) => (sbyte)(value - count);

        public sbyte GetIncrementedValue(sbyte value, int count = 1) => (sbyte)(value + count);

        public ulong GetLongCountInRange(sbyte firstInclusive, sbyte lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == sbyte.MinValue && lastInclusive == sbyte.MaxValue)) ? 0UL : (ulong)(lastInclusive - firstInclusive) + 1UL;

        public IEnumerable<sbyte> GetSequentialValuesInRange(sbyte firstInclusive, sbyte lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(sbyte value, sbyte start, sbyte end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(sbyte previousValue, sbyte nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
