namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class Int64RangeAccessors : IRangeSequenceAccessors<long>
    {
        public static readonly Int64RangeAccessors Instance = new();

        private Int64RangeAccessors() { }

        public long MaxValue => throw new NotImplementedException();

        public long MinValue => throw new NotImplementedException();

        public int Compare(long x, long y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(long firstInclusive, long lastInclusive)
        {
            throw new NotImplementedException();
        }

        public long GetDecrementedValue(long value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public long GetIncrementedValue(long value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> GetSequentialValuesInRange(long firstInclusive, long lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(long previousValue, long nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
