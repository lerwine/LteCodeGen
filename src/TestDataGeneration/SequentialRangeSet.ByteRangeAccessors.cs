namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class ByteRangeAccessors : IRangeSequenceAccessors<byte>
    {
        public static readonly ByteRangeAccessors Instance = new();

        private ByteRangeAccessors() { }

        public byte MaxValue => throw new NotImplementedException();

        public byte MinValue => throw new NotImplementedException();

        public int Compare(byte x, byte y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(byte firstInclusive, byte lastInclusive)
        {
            throw new NotImplementedException();
        }

        public byte GetDecrementedValue(byte value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public byte GetIncrementedValue(byte value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<byte> GetSequentialValuesInRange(byte firstInclusive, byte lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(byte previousValue, byte nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
