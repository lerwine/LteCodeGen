using System.Numerics;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests;

public partial class NumberRangesListTest
{
    static class TestData
    {
        internal static System.Collections.IEnumerable GetConstructorWithNumberExtentsArgsTestData()
        {
            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(),
                /*expectedCount*/ 0).Returns(Array.Empty<NumberExtents<char>>());
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'z'), new('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('Z', 'z'), new('A', 'a') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('A', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('A', 'a'), new('Z', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('A', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'z'), new('A', 'Z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('0', '9'), new('a', 'z'), new('A', 'Z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'z'), new('0', '9'), new('A', 'Z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'z'), new('A', 'Z'), new('0', '9') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z'), new('0', '9') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'n'), new('n', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('n', 'z'), new('a', 'n') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'm'), new('n', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('n', 'z'), new('a', 'm') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'm'), new('o', 'z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('a', 'm'), new('o', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('o', 'z'), new('a', 'm') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('a', 'm'), new('o', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'z'), new('b', 'y') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'y'), new('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'z'), new(char.MinValue, char.MinValue) },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new(char.MinValue, char.MinValue) });
            yield return new TestCaseData(new NumberExtents<char>[] { new(char.MinValue, char.MinValue), new('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new(char.MinValue, char.MinValue) });
        }

        internal static System.Collections.IEnumerable GetConstructorWithTupleArgsTestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*expectedCount*/ 0).Returns(Array.Empty<NumberExtents<char>>());
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z'), ('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('Z', 'z'), ('A', 'a') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('A', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('A', 'a'), ('Z', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('A', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('A', 'Z'), ('a', 'z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z'), ('A', 'Z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('0', '9'), ('A', 'Z'), ('a', 'z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('0', '9'), ('a', 'z'), ('A', 'Z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z'), ('0', '9'), ('A', 'Z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z'), ('A', 'Z'), ('0', '9') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('A', 'Z'), ('a', 'z'), ('0', '9') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('0', '9'), new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'n'), ('n', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z'), ('a', 'n') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'm'), ('n', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z'), ('a', 'm') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'm'), ('o', 'z') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('a', 'm'), new('o', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('o', 'z'), ('a', 'm') },
                /*expectedCount*/ 2).Returns(new NumberExtents<char>[] { new('a', 'm'), new('o', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z'), ('b', 'y') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('b', 'y'), ('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z'), (char.MinValue, char.MinValue) },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new(char.MinValue, char.MinValue) });
            yield return new TestCaseData(new (char First, char Last)[] { (char.MinValue, char.MinValue), ('a', 'z') },
                /*expectedCount*/ 1).Returns(new NumberExtents<char>[] { new(char.MinValue, char.MinValue) });
        }

        internal static System.Collections.IEnumerable GetAdd1Test1Data()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*value*/ 'a', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*value*/ 'a', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*value*/ 'A', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('A'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*value*/ 'l', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new ('l'), new('n', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'm') },
                /*value*/ 'm', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('m', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'm') },
                /*value*/ 'n', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('n', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'm') },
                /*value*/ 'l', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'm') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'm') },
                /*value*/ 'm', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'm') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'm') },
                /*value*/ 'n', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'n') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'm') },
                /*value*/ 'o', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'm'), new('o') });
        }

        internal static System.Collections.IEnumerable GetAdd1Test2Data()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*item*/ new NumberExtents<char>('a', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*item*/ new NumberExtents<char>('a', 'z'), /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'm') },
                /*item*/ new NumberExtents<char>('n', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*item*/ new NumberExtents<char>('a', 'm'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'n') },
                /*item*/ new NumberExtents<char>('n', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*item*/ new NumberExtents<char>('a', 'n'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'o') },
                /*item*/ new NumberExtents<char>('n', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*item*/ new NumberExtents<char>('a', 'o'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'l') },
                /*item*/ new NumberExtents<char>('n', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'l'), new('n', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*item*/ new NumberExtents<char>('a', 'l'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'l'), new('n', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*item*/ new NumberExtents<char>('A', 'Z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('A', 'Z') },
                /*item*/ new NumberExtents<char>('a', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*item*/ new NumberExtents<char>('b', 'z'), /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('b', 'z') },
                /*item*/ new NumberExtents<char>('a', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*item*/ new NumberExtents<char>('a', 'y'), /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'y') },
                /*item*/ new NumberExtents<char>('a', 'z'), /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
        }

        internal static System.Collections.IEnumerable GetAdd2TestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*first*/ 'a', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ 'a', /*last*/ 'z', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'm') },
                /*first*/ 'n', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*first*/ 'a', /*last*/ 'm', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'n') },
                /*first*/ 'n', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*first*/ 'a', /*last*/ 'n', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'o') },
                /*first*/ 'n', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*first*/ 'a', /*last*/ 'o', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'l') },
                /*first*/ 'n', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'l'), new('n', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('n', 'z') },
                /*first*/ 'a', /*last*/ 'l', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'l'), new('n', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ 'A', /*last*/ 'Z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('A', 'Z') },
                /*first*/ 'a', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('A', 'Z'), new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ 'b', /*last*/ 'z', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('b', 'z') },
                /*first*/ 'a', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ 'a', /*last*/ 'y', /*expectedResult*/ false).Returns(new NumberExtents<char>[] { new('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'y') },
                /*first*/ 'a', /*last*/ 'z', /*expectedResult*/ true).Returns(new NumberExtents<char>[] { new('a', 'z') });
        }

        internal static System.Collections.IEnumerable GetClearTestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>());
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') });
            yield return new TestCaseData(new (char First, char Last)[] { ('A', 'Z'), ('a', 'z'), ('0', '9') });
            yield return new TestCaseData(new (char First, char Last)[] { (char.MinValue, char.MaxValue) });
        }

        internal static System.Collections.IEnumerable GetContains1Test1Data()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*value*/ 'a').Returns(false);
            yield return new TestCaseData(new (char First, char Last)[] { ('f', 'r') },
                /*value*/ 'e').Returns(false);
            yield return new TestCaseData(new (char First, char Last)[] { ('f', 'r') },
                /*value*/ 'f').Returns(true);
            yield return new TestCaseData(new (char First, char Last)[] { ('f', 'r') },
                /*value*/ 'g').Returns(true);
            yield return new TestCaseData(new (char First, char Last)[] { ('f', 'r') },
                /*value*/ 'q').Returns(true);
            yield return new TestCaseData(new (char First, char Last)[] { ('f', 'r') },
                /*value*/ 'r').Returns(true);
            yield return new TestCaseData(new (char First, char Last)[] { ('f', 'r') },
                /*value*/ 's').Returns(false);
            yield return new TestCaseData(new (char First, char Last)[] { ('f', 'r') },
                /*value*/ 'G').Returns(false);
        }

        internal static System.Collections.IEnumerable GetContains1Test2Data()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*item*/ new NumberExtents<char>('a')).Returns(false);
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*item*/ new NumberExtents<char>('a')).Returns(false);
        }

        internal static System.Collections.IEnumerable GetContains2TestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*first*/ 'a', /*last*/ 'z').Returns(false);
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ 'a', /*last*/ 'z').Returns(true);
        }

        internal static System.Collections.IEnumerable GetContainsAllTestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*first*/ char.MinValue, /*last*/ char.MaxValue).Returns(false);
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ char.MinValue, /*last*/ char.MaxValue).Returns(true);
        }
        
        internal static System.Collections.IEnumerable GetGetItemAtTestData()
        {
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*index*/ 0).Returns(new NumberExtents<char>('a', 'z'));
        }

        internal static System.Collections.IEnumerable GetGetValueAtTestData()
        {
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*index*/ new BigInteger(1)).Returns('b');
        }

        internal static System.Collections.IEnumerable GetGetValueCountTestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>())
                .Returns(BigInteger.Zero);
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') })
                .Returns(new BigInteger(26));
        }

        internal static System.Collections.IEnumerable GetIndexOfTestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*item*/ new NumberExtents<char>(char.MinValue)).Returns(-1);
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*item*/ new NumberExtents<char>(char.MinValue)).Returns(-1);
        }

        internal static System.Collections.IEnumerable GetIsProperSubsetOfTestData()
        {
            yield return new TestCaseData(
                Array.Empty<(char First, char Last)>(),
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);

            yield return new TestCaseData(
                new (char First, char Last)[] { ('a', 'z') },
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);
        }

        internal static System.Collections.IEnumerable GetIsProperSupersetOfTestData()
        {
            yield return new TestCaseData(
                Array.Empty<(char First, char Last)>(),
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);

            yield return new TestCaseData(
                new (char First, char Last)[] { ('a', 'z') },
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);
        }

        internal static System.Collections.IEnumerable GetIsSubsetOfTestData()
        {
            yield return new TestCaseData(
                Array.Empty<(char First, char Last)>(),
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);

            yield return new TestCaseData(
                new (char First, char Last)[] { ('a', 'z') },
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);
        }

        internal static System.Collections.IEnumerable GetIsSupersetOfTestData()
        {
            yield return new TestCaseData(
                Array.Empty<(char First, char Last)>(),
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);

            yield return new TestCaseData(
                new (char First, char Last)[] { ('a', 'z') },
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);
        }

        internal static System.Collections.IEnumerable GetOverlapsTestData()
        {
            yield return new TestCaseData(
                Array.Empty<(char First, char Last)>(),
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);

            yield return new TestCaseData(
                new (char First, char Last)[] { ('a', 'z') },
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);
        }

        internal static System.Collections.IEnumerable GetAnyOverlapsTestData()
        {
            yield return new TestCaseData(Array.Empty<(char First, char Last)>(),
                /*first*/ 'a', /*last*/ 'z').Returns(false);
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ 'a', /*last*/ 'z').Returns(true);
        }

        internal static System.Collections.IEnumerable GetRemove1Test1Data()
        {
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'a') },
                /*value*/ 'a', true).Returns(Array.Empty<NumberExtents<char>>());
        }

        internal static System.Collections.IEnumerable GetRemove1Test2Data()
        {
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*item*/ new NumberExtents<char>('a', 'z'), true).Returns(Array.Empty<NumberExtents<char>>());
        }

        internal static System.Collections.IEnumerable GetRemove2TestData()
        {
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*first*/ 'a', /*last*/ 'z', true).Returns(Array.Empty<NumberExtents<char>>());
        }

        internal static System.Collections.IEnumerable GetRemoveAtTestData()
        {
            yield return new TestCaseData(new (char First, char Last)[] { ('a', 'z') },
                /*index*/ 0).Returns(Array.Empty<NumberExtents<char>>());
        }

        internal static System.Collections.IEnumerable GetSetEqualsTestData()
        {
            yield return new TestCaseData(
                Array.Empty<(char First, char Last)>(),
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(true);

            yield return new TestCaseData(
                new (char First, char Last)[] { ('a', 'z') },
                /*other*/ Enumerable.Empty<NumberExtents<char>>()
            ).Returns(false);
        }
    }
}