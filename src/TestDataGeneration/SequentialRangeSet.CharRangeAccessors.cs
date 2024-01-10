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

        public char GetDecrementedValue(char value, int count = 1) => (char)(value - count);

        public char GetIncrementedValue(char value, int count = 1) => (char)(value + count);

        public ulong GetLongCountInRange(char firstInclusive, char lastInclusive) => (firstInclusive > lastInclusive ||
            (firstInclusive == char.MinValue && lastInclusive == char.MaxValue)) ? 0UL : (ulong)(lastInclusive - firstInclusive) + 1UL;

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
