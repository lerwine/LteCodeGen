namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class UInt64RangeAccessors : IRangeSequenceAccessors<ulong>
    {
        public static readonly UInt64RangeAccessors Instance = new();

        private UInt64RangeAccessors() { }

        public ulong MaxValue => throw new NotImplementedException();

        public ulong MinValue => throw new NotImplementedException();

        public int Compare(ulong x, ulong y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(ulong firstInclusive, ulong lastInclusive)
        {
            throw new NotImplementedException();
        }

        public ulong GetDecrementedValue(ulong value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public ulong GetIncrementedValue(ulong value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ulong> GetSequentialValuesInRange(ulong firstInclusive, ulong lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(ulong previousValue, ulong nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
