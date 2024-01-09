namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class UInt16RangeAccessors : IRangeSequenceAccessors<ushort>
    {
        public static readonly UInt16RangeAccessors Instance = new();

        private UInt16RangeAccessors() { }

        public ushort MaxValue => ushort.MaxValue;

        public ushort MinValue => ushort.MinValue;

        public int Compare(ushort x, ushort y) => x.CompareTo(y);

        public int GetCountInRange(ushort firstInclusive, ushort lastInclusive) => lastInclusive - firstInclusive + 1;

        public ushort GetDecrementedValue(ushort value, int count = 1) => (ushort)(value - count);

        public ushort GetIncrementedValue(ushort value, int count = 1) => (ushort)(value + count);

        public IEnumerable<ushort> GetSequentialValuesInRange(ushort firstInclusive, ushort lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(ushort value, ushort start, ushort end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(ushort previousValue, ushort nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
