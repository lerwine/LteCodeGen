namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class Int16RangeAccessors : IRangeSequenceAccessors<short>
    {
        public static readonly Int16RangeAccessors Instance = new();

        private Int16RangeAccessors() { }

        public short MaxValue => short.MaxValue;

        public short MinValue => short.MinValue;

        public int Compare(short x, short y) => x.CompareTo(y);

        public short GetDecrementedValue(short value, int count = 1) => (short)(value - count);

        public short GetIncrementedValue(short value, int count = 1) => (short)(value + count);

        public ulong GetLongCountInRange(short firstInclusive, short lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == short.MinValue && lastInclusive == short.MaxValue)) ? 0UL : (ulong)(lastInclusive - firstInclusive) + 1UL;

        public IEnumerable<short> GetSequentialValuesInRange(short firstInclusive, short lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(short value, short start, short end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(short previousValue, short nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
