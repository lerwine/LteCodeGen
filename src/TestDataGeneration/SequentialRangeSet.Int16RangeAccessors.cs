namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class Int16RangeAccessors : IRangeSequenceAccessors<short>
    {
        public static readonly Int16RangeAccessors Instance = new();

        private Int16RangeAccessors() { }

        public short MaxValue => throw new NotImplementedException();

        public short MinValue => throw new NotImplementedException();

        public int Compare(short x, short y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(short firstInclusive, short lastInclusive)
        {
            throw new NotImplementedException();
        }

        public short GetDecrementedValue(short value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public short GetIncrementedValue(short value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<short> GetSequentialValuesInRange(short firstInclusive, short lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(short previousValue, short nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
