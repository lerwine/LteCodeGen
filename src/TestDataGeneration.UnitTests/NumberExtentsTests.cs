using System.Numerics;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public partial class NumberExtentsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTest1Data))]
        public bool IsMoreThanOneAfterTest1(char value, NumberExtents<char> extents)
        {
            return value.FollowsNonAdjacent(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTest2Data))]
        public bool IsMoreThanOneAfterTest2(NumberExtents<char> extents, char value)
        {
            return NumberExtents.FollowsNonAdjacent(extents, value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneAfterTest1Data))]
        public bool IsNotMoreThanOneAfterTest1(char value, NumberExtents<char> extents)
        {
            return value.AdjacentOrDoesNotFollow(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneAfterTest2Data))]
        public bool IsNotMoreThanOneAfterTest2(NumberExtents<char> extents, char value)
        {
            return extents.AdjacentOrDoesNotFollow(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTest1Data))]
        public bool IsMoreThanOneBeforeTest1(char value, NumberExtents<char> extents)
        {
            return value.PrecedesNonAdjacent(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTest2Data))]
        public bool IsMoreThanOneBeforeTest2(NumberExtents<char> extents, char value)
        {
            return NumberExtents.PrecedesNonAdjacent(extents, value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneBeforeTest1Data))]
        public bool IsNotMoreThanOneBeforeTest1(char value, NumberExtents<char> extents)
        {
            return value.AdjacentOrDoesNotPrecede(extents);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsNotMoreThanOneBeforeTest2Data))]
        public bool IsNotMoreThanOneBeforeTest2(NumberExtents<char> extents, char value)
        {
            return extents.AdjacentOrDoesNotPrecede(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetWithFirstTestData))]
        public NumberExtents<char> WithFirstTest(NumberExtents<char> extents, char value)
        {
            return extents.WithFirst(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetWithLastTestData))]
        public NumberExtents<char> WithLastTest(NumberExtents<char> extents, char value)
        {
            return extents.WithLast(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetRemoveAndGetNextTestData))]
        public NumberExtents<char>[] RemoveAndGetNextTest(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>[] after, NumberExtents<char>? expected)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.RemoveAndGetNext();
            Assert.That(actual?.Value, Is.EqualTo(expected));
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetRemoveAndGetPreviousTestData))]
        public NumberExtents<char>[] RemoveAndGetPreviousTest(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>[] after, NumberExtents<char>? expected)
        {
            LinkedList<NumberExtents<char>> list = new(before);
            var node = list.AddLast(target);
            foreach (var item in after) list.AddLast(item);
            var actual = node.RemoveAndGetPrevious();
            Assert.That(actual?.Value, Is.EqualTo(expected));
            return list.ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetInvalidExtentsTestData))]
        public void InvalidExtentsTest(char first, char last)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new NumberExtents<char>(first, last));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorTestData))]
        public (char First, char Last, BigInteger GetCount) ConstructorTest(char first, char last)
        {
            var target = new NumberExtents<char>(first, last);
            return (target.First, target.Last, target.GetCount());
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetCompareToTestData))]
        public int CompareToTest(NumberExtents<char> lValue, NumberExtents<char> rValue)
        {
            var result = lValue.CompareTo(rValue);
            return (result < 0) ? -1 : (result > 0) ? 1 : 0;
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetEqualsTestData))]
        public bool EqualsTest(NumberExtents<char> lValue, NumberExtents<char> rValue)
        {
            return lValue.Equals(rValue);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetToStringTestData))]
        public string ToStringTest(NumberExtents<char> value)
        {
            return value.ToString();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetAsEnumerableTestData))]
        public char[] AsEnumerableTest(NumberExtents<char> value)
        {
            return value.AsEnumerable().ToArray();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetContainsTestData))]
        public bool ContainsTest(NumberExtents<char> extents, char value)
        {
            return extents.Contains(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetImmediatelyFollowsTestData))]
        public bool IsFirstAdjacentToTest(NumberExtents<char> extents, char value)
        {
            return extents.ImmediatelyFollows(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetImmediatelyPrecedesTestData))]
        public bool IsLastAdjacentToTest(NumberExtents<char> extents, char value)
        {
            return extents.ImmediatelyPrecedes(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsBeforeTestData))]
        public bool IsBeforeTest(NumberExtents<char> extents, char value)
        {
            return extents.IsBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneAfterTestData))]
        public bool IsFirstMoreThanOneAfterTest(NumberExtents<char> extents, char value)
        {
            return extents.IsMoreThanOneAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsAfterTestData))]
        public bool IsAfterTest(NumberExtents<char> extents, char value)
        {
            return extents.IsAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsMoreThanOneBeforeTestData))]
        public bool IsLastMoreThanOneBeforeTest(NumberExtents<char> extents, char value)
        {
            return extents.IsMoreThanOneBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetRelationOfTestData))]
        public ExtentValueRelativity GetRelationOfTest(NumberExtents<char> extents, char value)
        {
            return extents.GetRelationOf(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetRelationToTestData))]
        public ExtentRelativity GetRelationToTest(NumberExtents<char> extents, NumberExtents<char> other)
        {
            return extents.GetRelationTo(other);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetReverseTestData))]
        public char[] ReverseTest(NumberExtents<char> value)
        {
            return value.Reverse().ToArray();
        }
    }
}