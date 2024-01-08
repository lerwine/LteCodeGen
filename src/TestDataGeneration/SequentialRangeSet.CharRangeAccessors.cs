namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class CharRangeAccessors : IRangeSequenceAccessors<char>
    {
        public static readonly CharRangeAccessors Instance = new();

        private CharRangeAccessors() { }

        public char MaxValue => throw new NotImplementedException();

        public char MinValue => throw new NotImplementedException();

        public int Compare(char x, char y)
        {
            throw new NotImplementedException();
        }

        public int GetCountInRange(char firstInclusive, char lastInclusive)
        {
            throw new NotImplementedException();
        }

        public char GetDecrementedValue(char value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public char GetIncrementedValue(char value, int count = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> GetSequentialValuesInRange(char firstInclusive, char lastInclusive)
        {
            throw new NotImplementedException();
        }

        public bool IsSequentiallyAdjacent(char previousValue, char nextValue)
        {
            throw new NotImplementedException();
        }
    }
}
