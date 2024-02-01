using System.Numerics;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public partial class NumberExtentsTests
    {
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

            public static System.Collections.IEnumerable GetIsMoreThanOneAfterTest1Data()
            {
                yield return new TestCaseData('c', new NumberExtents<char>('a')).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneAfterTest2Data()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneAfterTest1Data()
            {
                yield return new TestCaseData('b', new NumberExtents<char>('a')).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneAfterTest2Data()
            {
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(true);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTest1Data()
            {
                yield return new TestCaseData('a', new NumberExtents<char>('c')).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTest2Data()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneBeforeTest1Data()
            {
                yield return new TestCaseData('a', new NumberExtents<char>('b')).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneBeforeTest2Data()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(true);
            }

            public static System.Collections.IEnumerable GetIsLessThanTest1Data()
            {
                yield return new TestCaseData('a', new NumberExtents<char>('b')).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsLessThanTest2Data()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(true);
            }

            public static System.Collections.IEnumerable GetIsGreaterThanTest1Data()
            {
                yield return new TestCaseData('b', new NumberExtents<char>('a')).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsGreaterThanTest2Data()
            {
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(true);
            }

            public static System.Collections.IEnumerable GetIsIncludedInTestData()
            {
                yield return new TestCaseData('b', new NumberExtents<char>('b')).Returns(true);
            }

            public static System.Collections.IEnumerable GetIncludesTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('b'), 'b').Returns(true);
            }

            public static System.Collections.IEnumerable GetWithFirstTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(new NumberExtents<char>('a', 'b'));
            }

            public static System.Collections.IEnumerable GetWithLastTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(new NumberExtents<char>('a', 'b'));
            }

            public static System.Collections.IEnumerable GetAddFirstTest1Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'z').Returns(new NumberExtents<char>[] { new('a', 'z') });
            }

            public static System.Collections.IEnumerable GetAddFirstTest2Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a').Returns(new NumberExtents<char>[] { new('a') });
            }

            public static System.Collections.IEnumerable GetAddLastTest1Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'z').Returns(new NumberExtents<char>[] { new('a', 'z') });
            }

            public static System.Collections.IEnumerable GetAddLastTest2Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a').Returns(new NumberExtents<char>[] { new('a') });
            }

            public static System.Collections.IEnumerable GetAddPreviousTest1Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
                {
                    return new TestCaseData(before, target, after, first, last);
                }
                yield return create(before: new NumberExtents<char>('a', 'b'), target: new NumberExtents<char>('g', 'h'), after: new NumberExtents<char>('j', 'k'), first: 'd', last: 'e').Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j', 'k') });
            }

            public static System.Collections.IEnumerable GetAddPreviousTest2Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
                {
                    return new TestCaseData(before, target, after, value);
                }
                yield return create(before: new NumberExtents<char>('a'), target: new NumberExtents<char>('e'), after: new NumberExtents<char>('g'), value: 'c').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') });
            }

            public static System.Collections.IEnumerable GetAddNextTest1Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
                {
                    return new TestCaseData(before, target, after, first, last);
                }
                yield return create(before: new NumberExtents<char>('a', 'b'), target: new NumberExtents<char>('d', 'e'), after: new NumberExtents<char>('j', 'k'), first: 'g', last: 'h').Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j', 'k') });
            }

            public static System.Collections.IEnumerable GetAddNextTest2Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
                {
                    return new TestCaseData(before, target, after, value);
                }
                yield return create(before: new NumberExtents<char>('a'), target: new NumberExtents<char>('c'), after: new NumberExtents<char>('g'), value: 'e').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') });
            }

            public static System.Collections.IEnumerable GetRemoveAndGetNextTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>? expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new NumberExtents<char>('c'), expected: new NumberExtents<char>('g'), new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('e'), new('g') });
            }

            public static System.Collections.IEnumerable GetRemoveAndGetPreviousTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>? expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new NumberExtents<char>('c'), expected: new NumberExtents<char>('a'), new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('e'), new('g') });
            }

            public static System.Collections.IEnumerable GetTryExpandTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, bool expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, first, last, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new NumberExtents<char>('d'), first: 'c', last: 'e', expected: true, new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') });
            }

            public static System.Collections.IEnumerable GetTryExpandFirstTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char value, bool expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, value, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new NumberExtents<char>('d'), value: 'c', expected: true, new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g') });
            }

            public static System.Collections.IEnumerable GetTryExpandLastTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char value, bool expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, value, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new NumberExtents<char>('d'), value: 'e', expected: true, new NumberExtents<char>('g')).Returns(new NumberExtents<char>[] { new('a'), new('d', 'e'), new('g') });
            }
        }
    }
}