namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class SByteRangeAccessors : IRangeSequenceAccessors<sbyte>
    {
        public static readonly SByteRangeAccessors Instance = new();

        private SByteRangeAccessors() { }

        public sbyte MaxValue => throw new NotImplementedException();

        public sbyte MinValue => throw new NotImplementedException();

        public int Compare(sbyte x, sbyte y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(sbyte firstInclusive, sbyte lastInclusive)
        {
            throw new NotImplementedException();
        }

        public sbyte GetDecrementedValue(sbyte value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public sbyte GetIncrementedValue(sbyte value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<sbyte> GetSequentialValuesInRange(sbyte firstInclusive, sbyte lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(sbyte previousValue, sbyte nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
