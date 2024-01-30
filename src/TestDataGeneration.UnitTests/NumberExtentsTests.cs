using System.Numerics;
using NUnit.Framework;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public partial class NumberExtentsTests
    {
        [SetUp]
        public void Setup()
        {
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

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsFirstAdjacentToTestData))]
        public bool IsFirstAdjacentToTest(NumberExtents<char> extents, char value)
        {
            return extents.IsFirstAdjacentTo(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsLastAdjacentToTestData))]
        public bool IsLastAdjacentToTest(NumberExtents<char> extents, char value)
        {
            return extents.IsLastAdjacentTo(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsBeforeTestData))]
        public bool IsBeforeTest(NumberExtents<char> extents, char value)
        {
            return extents.IsBefore(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsFirstMoreThanOneAfterTestData))]
        public bool IsFirstMoreThanOneAfterTest(NumberExtents<char> extents, char value)
        {
            return extents.IsFirstMoreThanOneAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsAfterTestData))]
        public bool IsAfterTest(NumberExtents<char> extents, char value)
        {
            return extents.IsAfter(value);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetIsLastMoreThanOneBeforeTestData))]
        public bool IsLastMoreThanOneBeforeTest(NumberExtents<char> extents, char value)
        {
            return extents.IsLastMoreThanOneBefore(value);
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