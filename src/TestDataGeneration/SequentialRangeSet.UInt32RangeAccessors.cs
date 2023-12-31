namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class UInt32RangeAccessors : IRangeSequenceAccessors<uint>
    {
        public static readonly UInt32RangeAccessors Instance = new();

        private UInt32RangeAccessors() { }

        public uint MaxValue => uint.MaxValue;

        public uint MinValue => uint.MinValue;

        public int Compare(uint x, uint y) => x.CompareTo(y);

        public int GetCountInRange(uint firstInclusive, uint lastInclusive)
        {
            var result = lastInclusive - firstInclusive + 1u;
            if (result < 0) return 0;
            return (result > int.MaxValue) ? int.MaxValue : (int)result;
        }

        public uint GetDecrementedValue(uint value, int count = 1) => value - (uint)count;

        public uint GetIncrementedValue(uint value, int count = 1) => value + (uint)count;

        public IEnumerable<uint> GetSequentialValuesInRange(uint firstInclusive, uint lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(uint value, uint start, uint end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(uint previousValue, uint nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
