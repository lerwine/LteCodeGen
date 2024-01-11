namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class Int32RangeAccessors : IRangeSequenceAccessors<int>
    {
        public static readonly Int32RangeAccessors Instance = new();

        private Int32RangeAccessors() { }

        public int MaxValue => int.MaxValue;

        public int MinValue => int.MinValue;

        public int Compare(int x, int y) => x.CompareTo(y);

        public int GetDecrementedValue(int value, int count = 1) => value - count;

        public int GetIncrementedValue(int value, int count = 1) => value + count;

        public ulong GetLongCountInRange(int firstInclusive, int lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == int.MinValue && lastInclusive == int.MaxValue)) ? 0UL : (ulong)(lastInclusive - firstInclusive) + 1UL;

        public IEnumerable<int> GetSequentialValuesInRange(int firstInclusive, int lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(int value, int start, int end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(int previousValue, int nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
