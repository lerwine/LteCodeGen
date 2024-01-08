namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class Int32RangeAccessors : IRangeSequenceAccessors<int>
    {
        public static readonly Int32RangeAccessors Instance = new();

        private Int32RangeAccessors() { }

        public int MaxValue => throw new NotImplementedException();

        public int MinValue => throw new NotImplementedException();

        public int Compare(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(int firstInclusive, int lastInclusive)
        {
            throw new NotImplementedException();
        }

        public int GetDecrementedValue(int value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public int GetIncrementedValue(int value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetSequentialValuesInRange(int firstInclusive, int lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(int previousValue, int nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
