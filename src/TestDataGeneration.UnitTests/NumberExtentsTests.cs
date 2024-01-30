using System.Numerics;
using NUnit.Framework;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public class NumberExtentsTests
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

        class TestData
        {
            public static System.Collections.IEnumerable GetIsFirstAdjacentToTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'd'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'd').Returns(false);
            }

            public static System.Collections.IEnumerable GetIsLastAdjacentToTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
            }

            public static System.Collections.IEnumerable GetIsBeforeTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
            }

            public static System.Collections.IEnumerable GetIsFirstMoreThanOneAfterTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'd'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'f').Returns(false);
            }

            public static System.Collections.IEnumerable GetIsAfterTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'd'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'f').Returns(false);
            }

            public static System.Collections.IEnumerable GetIsLastMoreThanOneBeforeTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
            }

            public static System.Collections.IEnumerable GetGetRelationOfTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), 'd').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'c').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), 'c').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'b').Returns(ExtentValueRelativity.IsIncluded);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'b').Returns(ExtentValueRelativity.IsIncluded);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(ExtentValueRelativity.IsIncluded);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), 'b').Returns(ExtentValueRelativity.IsIncluded);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'a').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('c', 'd'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
            }

            public static System.Collections.IEnumerable GetGetRelationToTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'd')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'e')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'g')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'f')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'c')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('c', 'e')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('b', 'c')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c', 'e')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), new NumberExtents<char>('a', 'b')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a', 'b')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('b', 'c')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('b')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), new NumberExtents<char>('a', 'd')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'd')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'd')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'b')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'b')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), new NumberExtents<char>('a')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'b')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('d', 'e'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('c', 'd'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'b')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('b', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('c')).Returns(ExtentRelativity.FollowsWithGap);
            }

            public static System.Collections.IEnumerable GetReverseTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a')).Returns(new char[] { 'a' });
                yield return new TestCaseData(new NumberExtents<char>('a', 'b')).Returns(new char[] { 'b', 'a' });
                yield return new TestCaseData(new NumberExtents<char>('A', 'F')).Returns(new char[] { 'F', 'E', 'D', 'C', 'B', 'A' });
            }

            public static System.Collections.IEnumerable GetContainsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'c').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'C').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('B', 'F'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('B', 'F'), 'B').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'F'), 'D').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'F'), 'F').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'F'), 'G').Returns(false);
            }

            public static System.Collections.IEnumerable GetAsEnumerableTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a')).Returns(new char[] { 'a' });
                yield return new TestCaseData(new NumberExtents<char>('a', 'b')).Returns(new char[] { 'a', 'b' });
                yield return new TestCaseData(new NumberExtents<char>('A', 'F')).Returns(new char[] { 'A', 'B', 'C', 'D', 'E', 'F' });
            }

            public static System.Collections.IEnumerable GetToStringTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a')).Returns($"{{U+{(int)'a':x4}}}");
                yield return new TestCaseData(new NumberExtents<char>('a', 'b')).Returns($"{{U+{(int)'a':x4}..U+{(int)'b':x4}}}");
            }

            public static System.Collections.IEnumerable GetCompareToTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'b')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('d')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a', 'b')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('a', 'b')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a', 'e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('a', 'f')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('a', 'e')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c', 'd'), new NumberExtents<char>('a', 'f')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('c', 'd')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('c', 'f'), new NumberExtents<char>('a', 'f')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('c', 'f')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('c', 'g'), new NumberExtents<char>('a', 'f')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('c', 'g')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('f', 'h'), new NumberExtents<char>('a', 'f')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('f', 'h')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('g', 'i'), new NumberExtents<char>('a', 'f')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('g', 'i')).Returns(-1);
            }

            public static System.Collections.IEnumerable GetEqualsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'b')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('d')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a', 'b')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('a', 'b')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'b'), new NumberExtents<char>('a', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('a', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('a', 'f')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('a', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'd'), new NumberExtents<char>('a', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('c', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'f'), new NumberExtents<char>('a', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('c', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'g'), new NumberExtents<char>('a', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('c', 'g')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('f', 'h'), new NumberExtents<char>('a', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('f', 'h')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('g', 'i'), new NumberExtents<char>('a', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'f'), new NumberExtents<char>('g', 'i')).Returns(false);
            }

            public static System.Collections.IEnumerable GetConstructorTestData()
            {
                yield return new TestCaseData('a', 'a').Returns((First: 'a', Last: 'a', GetCount: new BigInteger(1)));
                yield return new TestCaseData('a', 'b').Returns((First: 'a', Last: 'b', GetCount: new BigInteger(2)));
                yield return new TestCaseData('A', 'Z').Returns((First: 'A', Last: 'Z', GetCount: new BigInteger(26)));
                yield return new TestCaseData(char.MinValue, '\u0001').Returns((First: char.MinValue, Last: '\u0001', GetCount: new BigInteger(2)))
                    .SetArgDisplayNames("char.MinValue", "'\\u0001'");
                yield return new TestCaseData('\ufffe', char.MaxValue).Returns((First: '\ufffe', Last: char.MaxValue, GetCount: new BigInteger(2)))
                    .SetArgDisplayNames("'\\ufffe'", "char.MaxValue");
                yield return new TestCaseData(char.MinValue, char.MaxValue).Returns((First: char.MinValue, Last: char.MaxValue, GetCount: new BigInteger(char.MaxValue - char.MinValue + 1)))
                    .SetArgDisplayNames("char.MinValue", "char.MaxValue");
            }

            public static System.Collections.IEnumerable GetInvalidExtentsTestData()
            {
                yield return new TestCaseData('b', 'a');
                yield return new TestCaseData(char.MaxValue, '\ufffe').SetArgDisplayNames("char.MaxValue", "'\\ufffe'");
                yield return new TestCaseData('\u0001', char.MinValue).SetArgDisplayNames("'\\u0001'", "char.MinValue");
            }
        }
    }
}