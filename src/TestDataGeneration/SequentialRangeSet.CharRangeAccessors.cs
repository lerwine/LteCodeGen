namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public sealed class CharRangeAccessors : IRangeSequenceAccessors<char>
    {
        public static readonly CharRangeAccessors Instance = new();

        private CharRangeAccessors() { }

        public char MaxValue => char.MaxValue;

        public char MinValue => char.MinValue;

        public int Compare(char x, char y) => x.CompareTo(y);

        public int GetCountInRange(char firstInclusive, char lastInclusive) => lastInclusive - firstInclusive + 1;

        public char GetDecrementedValue(char value, int count = 1) => (char)(value - count);

        public char GetIncrementedValue(char value, int count = 1) => (char)(value + count);

        public IEnumerable<char> GetSequentialValuesInRange(char firstInclusive, char lastInclusive)
        {
            for (var n = firstInclusive; n < lastInclusive; n++)
                yield return n;
            yield return lastInclusive;
        }

        public bool IsInRange(char value, char start, char end) => value >= start && value <= end;

        public bool IsSequentiallyAdjacent(char previousValue, char nextValue) => previousValue < nextValue && previousValue + 1 == nextValue;
    }
}
