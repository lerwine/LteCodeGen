namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class UInt16RangeAccessors : IRangeSequenceAccessors<ushort>
    {
        public static readonly UInt16RangeAccessors Instance = new();

        private UInt16RangeAccessors() { }

        public ushort MaxValue => throw new NotImplementedException();

        public ushort MinValue => throw new NotImplementedException();

        public int Compare(ushort x, ushort y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(ushort firstInclusive, ushort lastInclusive)
        {
            throw new NotImplementedException();
        }

        public ushort GetDecrementedValue(ushort value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public ushort GetIncrementedValue(ushort value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ushort> GetSequentialValuesInRange(ushort firstInclusive, ushort lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(ushort previousValue, ushort nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
