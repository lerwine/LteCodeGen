namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class ByteRangeAccessors : IRangeSequenceAccessors<byte>
    {
        public static readonly ByteRangeAccessors Instance = new();

        private ByteRangeAccessors() { }

        public byte MaxValue => byte.MaxValue;

        public byte MinValue => byte.MinValue;

        public int Compare(byte x, byte y) => x.CompareTo(y);

        public int GetCountInRange(byte firstInclusive, byte lastInclusive) => lastInclusive - firstInclusive + 1;

        public byte GetDecrementedValue(byte value, int count = 1) => (byte)(value - count);

        public byte GetIncrementedValue(byte value, int count = 1) => (byte)(value + count);

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
