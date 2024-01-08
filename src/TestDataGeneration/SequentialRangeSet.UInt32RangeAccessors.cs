namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class UInt32RangeAccessors : IRangeSequenceAccessors<uint>
    {
        public static readonly UInt32RangeAccessors Instance = new();

        private UInt32RangeAccessors() { }

        public uint MaxValue => throw new NotImplementedException();

        public uint MinValue => throw new NotImplementedException();

        public int Compare(uint x, uint y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(uint firstInclusive, uint lastInclusive)
        {
            throw new NotImplementedException();
        }

        public uint GetDecrementedValue(uint value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public uint GetIncrementedValue(uint value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<uint> GetSequentialValuesInRange(uint firstInclusive, uint lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(uint previousValue, uint nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
