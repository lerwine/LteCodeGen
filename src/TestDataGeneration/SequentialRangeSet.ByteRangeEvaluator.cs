namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public static readonly ByteRangeEvaluator Byte = ByteRangeEvaluator.Instance;
    
    public sealed class ByteRangeEvaluator : IRangeEvaluator<byte>
    {
        public static readonly ByteRangeEvaluator Instance = new();

        private ByteRangeEvaluator() { }

        public byte MaxValue => byte.MaxValue;

        public byte MinValue => byte.MinValue;

        public int Compare(byte x, byte y) => x.CompareTo(y);

        public byte GetDecrementedValue(byte value, int count = 1) => (byte)(value - count);

        public byte GetIncrementedValue(byte value, int count = 1) => (byte)(value + count);

        public ulong GetLongCountInRange(byte firstInclusive, byte lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == byte.MinValue && lastInclusive == byte.MaxValue)) ? 0UL : (ulong)(lastInclusive - firstInclusive) + 1UL;

        public IEnumerable<byte> GetSequentialValuesInRange(byte firstInclusive, byte lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(byte value, byte start, byte end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(byte previousValue, byte nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
