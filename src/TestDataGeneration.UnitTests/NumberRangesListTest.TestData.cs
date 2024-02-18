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

        public static System.Collections.IEnumerable GetAdd1Test1Data()
        {
            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a')
                .Returns(new NumberExtents<char>[] { new('a') })
                .SetDescription("Add value to empty list.");

            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue) })
                .SetArgDisplayNames("[]", "char.MinValue", "true")
                .SetDescription("Add MinValue to empty list.");

            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), char.MaxValue)
                .Returns(new NumberExtents<char>[] { new(char.MaxValue) })
                .SetArgDisplayNames("[]", "char.MaxValue", "true")
                .SetDescription("Add MaxValue to empty list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0002') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue), new('\u0002') })
                .SetArgDisplayNames("[new('\\u0002')]", "char.MinValue", "true")
                .SetDescription("Add MinValue to single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0002', '\u0003') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue), new('\u0002', '\u0003') })
                .SetArgDisplayNames("[new('\\u0002', '\\u0003')]", "char.MinValue", "true")
                .SetDescription("Add MinValue to single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0002', '\u0004') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue), new('\u0002', '\u0004') })
                .SetArgDisplayNames("[new('\\u0002', '\\u0004')]", "char.MinValue", "true")
                .SetDescription("Add MinValue to single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c') })
                .SetDescription("Add first to single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Add first to single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Add first to single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c'), new('e') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') })
                .SetDescription("Add first to two-element list before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd'), new('f') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Add first to two-element list before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e'), new('g') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Add first to two-element list before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c'), new('e'), new('g') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') })
                .SetDescription("Add first to three-element list before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd'), new('f'), new('h') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h') })
                .SetDescription("Add first to three-element list before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e'), new('g'), new('i') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i') })
                .SetDescription("Add first to three-element list before three-value element.");

        }

        public static System.Collections.IEnumerable GetAdd1Test2Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0001') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue, '\u0001') })
                .SetArgDisplayNames("[new('\\u0001')]", "char.MinValue", "true")
                .SetDescription("Expand MinValue on single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0001', '\u0002') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue, '\u0002') })
                .SetArgDisplayNames("[new('\\u0001', '\\u0002')]", "char.MinValue", "true")
                .SetDescription("Expand MinValue on single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0001', '\u0003') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue, '\u0003') })
                .SetArgDisplayNames("[new('\\u0001', '\\u0003')]", "char.MinValue", "true")
                .SetDescription("Expand MinValue on single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0002') }, '\u0001')
                .Returns(new NumberExtents<char>[] { new('\u0001', '\u0002') })
                .SetArgDisplayNames("[new('\\u0002')]", "'\\u0001'", "true")
                .SetDescription("Expand to '\\u0001' on single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0002', '\u0003') }, '\u0001')
                .Returns(new NumberExtents<char>[] { new('\u0001', '\u0003') })
                .SetArgDisplayNames("[new('\\u0002', '\\u0003')]", "'\\u0001'", "true")
                .SetDescription("Expand to '\\u0001' on single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\u0002', '\u0004') }, '\u0001')
                .Returns(new NumberExtents<char>[] { new('\u0001', '\u0004') })
                .SetArgDisplayNames("[new('\\u0002', '\\u0004')]", "'\\u0001'", "true")
                .SetDescription("Expand to '\\u0001' on single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Expand First value of single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Expand First value of single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Expand First value of single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b'), new('d') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Expand First value of single-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c'), new('e') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Expand First value of two-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd'), new('f') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Expand First value of three-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Expand First value of single-value element that is preceded by another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Expand First value of two-value element that is preceded by a single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Expand First value of three-value element that is preceded by a single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') })
                .SetDescription("Expand First value of single-value element that is preceded by a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') })
                .SetDescription("Expand First value of two-value element that is preceded by another two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'g') })
                .SetDescription("Expand First value of three-value element that is preceded by a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') })
                .SetDescription("Expand First value of single-value element that is preceded by a three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'g') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') })
                .SetDescription("Expand First value of two-value element that is preceded by a three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'h') })
                .SetDescription("Expand First value of three-value element that is preceded by another three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f') })
                .SetDescription("Expand First value of single-value element that is preceded by 2 other other single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'g') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g') })
                .SetDescription("Expand First value of two-value element that is preceded by 2 single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'h') })
                .SetDescription("Expand First value of three-value element that is preceded by 2 single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('h') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') })
                .SetDescription("Expand First value of single-value element that is preceded by 2 two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('h', 'i') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'i') })
                .SetDescription("Expand First value of two-value element that is preceded by 2 other two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('h', 'j') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'j') })
                .SetDescription("Expand First value of three-value element that is preceded by 2 two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('j') }, 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'j') })
                .SetDescription("Expand First value of single-value element that is preceded by 2 three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('j', 'k') }, 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') })
                .SetDescription("Expand First value of two-value element that is preceded by 2 three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('j', 'l') }, 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'l') })
                .SetDescription("Expand First value of three-value element that is preceded by 2 other three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d'), new('f') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Expand First value of single-value element that is preceded by another single-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e'), new('g') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Expand First value of two-value element that is preceded by a single-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f'), new('h') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Expand First value of three-value element that is preceded by a single-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e'), new('g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g') })
                .SetDescription("Expand First value of single-value element that is preceded by a two-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f'), new('h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h') })
                .SetDescription("Expand First value of two-value element that is preceded by another two-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'g'), new('i') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'g'), new('i') })
                .SetDescription("Expand First value of three-value element that is preceded by a two-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f'), new('h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h') })
                .SetDescription("Expand First value of single-value element that is preceded by a three-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'g'), new('i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') })
                .SetDescription("Expand First value of two-value element that is preceded by a three-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'h'), new('j') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'h'), new('j') })
                .SetDescription("Expand First value of three-value element that is preceded by another three-value element and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f'), new('h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('h') })
                .SetDescription("Expand First value of single-value element that is preceded by 2 other other single-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'g'), new('i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('i') })
                .SetDescription("Expand First value of two-value element that is preceded by 2 single-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'h'), new('j') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'h'), new('j') })
                .SetDescription("Expand First value of three-value element that is preceded by 2 single-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('h'), new('j') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j') })
                .SetDescription("Expand First value of single-value element that is preceded by 2 two-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('h', 'i'), new('k') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'i'), new('k') })
                .SetDescription("Expand First value of two-value element that is preceded by 2 other two-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('h', 'j'), new('l') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'j'), new('l') })
                .SetDescription("Expand First value of three-value element that is preceded by 2 two-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('j'), new('l') }, 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'j'), new('l') })
                .SetDescription("Expand First value of single-value element that is preceded by 2 three-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('j', 'k'), new('m') }, 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k'), new('m') })
                .SetDescription("Expand First value of two-value element that is preceded by 2 three-value elements and followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('j', 'l'), new('n') }, 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'l'), new('n') })
                .SetDescription("Expand First value of three-value element that is preceded by 2 other three-value elements and followed by another element.");

        }

        public static System.Collections.IEnumerable GetAdd1Test3Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new(char.MinValue) }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue) })
                .SetArgDisplayNames("[new(char.MinValue)]", "char.MinValue", "true")
                .SetDescription("Add existing MinValue to single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new(char.MinValue, '\u0002') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue, '\u0002') })
                .SetArgDisplayNames("[new(char.MinValue, '\\u0002')]", "char.MinValue", "true")
                .SetDescription("Add existing MinValue to single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new(char.MinValue, '\u0003') }, char.MinValue)
                .Returns(new NumberExtents<char>[] { new(char.MinValue, '\u0003') })
                .SetArgDisplayNames("[new(char.MinValue, '\\u0003')]", "char.MinValue", "true")
                .SetDescription("Add existing MinValue to single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new(char.MaxValue) }, char.MaxValue)
                .Returns(new NumberExtents<char>[] { new(char.MaxValue) })
                .SetArgDisplayNames("[new(char.MaxValue)]", "char.MaxValue", "true")
                .SetDescription("Add existing MaxValue to single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\ufffe', char.MaxValue) }, char.MaxValue)
                .Returns(new NumberExtents<char>[] { new('\ufffe', char.MaxValue) })
                .SetArgDisplayNames("[new('\ufffe', char.MaxValue)]", "char.MaxValue", "true")
                .SetDescription("Add existing MaxValue to single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\ufffd', char.MaxValue) }, char.MaxValue)
                .Returns(new NumberExtents<char>[] { new('\ufffd', char.MaxValue) })
                .SetArgDisplayNames("[new('\ufffd', char.MaxValue)]", "char.MaxValue", "true")
                .SetDescription("Add existing MaxValue to single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Add existing First value of single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Add existing First value of single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Add existing First value of two-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Add existing First value of three-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Add existing First value of two-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Add existing First value of three-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Add existing First value of two-value element that is preceded and followed by other elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Add existing First value of three-value element that is preceded and followed by other elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c') })
                .SetDescription("Add existing value of single-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Add existing value of three-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c') })
                .SetDescription("Add existing value of single-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Add existing value of three-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') })
                .SetDescription("Add existing value of single-value element that is preceded and followed by other elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('f') })
                .SetDescription("Add existing value of three-value element that is preceded and followed by other elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Add existing Last value of two-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Add existing Last value of three-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Add existing Last value of two-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Add existing Last value of three-value element that is followed by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Add existing Last value of two-value element that is preceded and followed by other elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Add existing Last value of three-value element that is preceded and followed by other elements.");

        }

        public static System.Collections.IEnumerable GetAdd1Test4Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('\ufffe') }, char.MaxValue)
                .Returns(new NumberExtents<char>[] { new('\ufffe', char.MaxValue) })
                .SetArgDisplayNames("[new('\\ufffe')]", "char.MaxValue", "true")
                .SetDescription("Expand MaxValue on single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\ufffd', '\ufffe') }, char.MaxValue)
                .Returns(new NumberExtents<char>[] { new('\ufffd', char.MaxValue) })
                .SetArgDisplayNames("[new('\\ufffd', '\\ufffe')]", "char.MaxValue", "true")
                .SetDescription("Expand MaxValue on single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\ufffc', '\ufffe') }, char.MaxValue)
                .Returns(new NumberExtents<char>[] { new('\ufffc', char.MaxValue) })
                .SetArgDisplayNames("[new('\\ufffc', '\\ufffe')]", "char.MaxValue", "true")
                .SetDescription("Expand MaxValue on single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('\ufffd') }, '\ufffe')
                .Returns(new NumberExtents<char>[] { new('\ufffd', '\ufffe') })
                .SetArgDisplayNames("[new('\\ufffd')]", "'\\ufffe'", "true")
                .SetDescription("Expand to '\\ufffe' on single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Expand Last value of single-element/single-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Expand Last value of single-element/two-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Expand Last value of single-element/three-value list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Expand Last value of single-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Expand Last value of two-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Expand Last value of three-value element that is preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Expand Last value of single-value element that is followed by another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Expand Last value of two-value element that is followed by a single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Expand Last value of three-value element that is followed by a single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') })
                .SetDescription("Expand Last value of single-value element that is followed by a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') })
                .SetDescription("Expand Last value of two-value element that is followed by another two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', 'g') })
                .SetDescription("Expand Last value of three-value element that is followed by a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') })
                .SetDescription("Expand Last value of single-value element that is followed by a three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'g') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') })
                .SetDescription("Expand Last value of two-value element that is followed by a three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', 'h') })
                .SetDescription("Expand Last value of three-value element that is followed by another three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d'), new('f') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f') })
                .SetDescription("Expand Last value of single-value element that is followed by 2 other single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e'), new('g') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g') })
                .SetDescription("Expand Last value of two-value element that is followed by 2 single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f'), new('h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f'), new('h') })
                .SetDescription("Expand Last value of three-value element that is followed by 2 single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e'), new('g', 'h') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') })
                .SetDescription("Expand Last value of single-value element that is followed by 2 two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f'), new('h', 'i') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h', 'i') })
                .SetDescription("Expand Last value of two-value element that is followed by 2 other two-two elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'g'), new('i', 'j') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', 'g'), new('i', 'j') })
                .SetDescription("Expand Last value of three-value element that is followed by 2 single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f'), new('h', 'j') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h', 'j') })
                .SetDescription("Expand Last value of single-value element that is followed by 2 three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'g'), new('i', 'k') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') })
                .SetDescription("Expand Last value of two-value element that is followed by 2 three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'h'), new('j', 'l') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', 'h'), new('j', 'l') })
                .SetDescription("Expand Last value of three-value element that is followed by 2 other three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Expand Last value of single-value element that is followed by another single-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Expand Last value of two-value element that is followed by a single-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Expand Last value of three-value element that is followed by a single-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g') })
                .SetDescription("Expand Last value of single-value element that is followed by a two-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h') })
                .SetDescription("Expand Last value of two-value element that is followed by another two-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h', 'i') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h', 'i') })
                .SetDescription("Expand Last value of three-value element that is followed by a two-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h') })
                .SetDescription("Expand Last value of single-value element that is followed by a three-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i') })
                .SetDescription("Expand Last value of two-value element that is followed by a three-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h', 'j') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h', 'j') })
                .SetDescription("Expand Last value of three-value element that is followed by another three-value element and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f'), new('h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h') })
                .SetDescription("Expand Last value of single-value element that is followed by 2 other single-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g'), new('i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i') })
                .SetDescription("Expand Last value of two-value element that is followed by 2 single-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h'), new('j') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h'), new('j') })
                .SetDescription("Expand Last value of three-value element that is followed by 2 single-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'g'), new('i', 'j') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i', 'j') })
                .SetDescription("Expand Last value of single-value element that is followed by 2 two-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'h'), new('j', 'k') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j', 'k') })
                .SetDescription("Expand Last value of two-value element that is followed by 2 other two-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h', 'i'), new('k', 'l') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h', 'i'), new('k', 'l') })
                .SetDescription("Expand Last value of three-value element that is followed by 2 two-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f', 'h'), new('j', 'l') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j', 'l') })
                .SetDescription("Expand Last value of single-value element that is followed by 2 three-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'i'), new('k', 'm') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k', 'm') })
                .SetDescription("Expand Last value of two-value element that is followed by 2 three-value elements and preceded by another element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h', 'j'), new('l', 'n') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h', 'j'), new('l', 'n') })
                .SetDescription("Expand Last value of three-value element that is followed by 2 other three-value elements and preceded by another element.");

        }

        public static System.Collections.IEnumerable GetAdd1Test5Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Combine 2 single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Combine single-value element with following two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Combine single-value element with following three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Combine two-value element with following single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Combine 2 two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Combine two-value element with following three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Combine three-value element with following single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Combine three-value element with following two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Combine 2 three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Combine 2 single-value elements that have a preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Combine single-value element that has a preceding element with following two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Combine single-value element that has a preceding element with following three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Combine two-value element that has a preceding element with following single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Combine 2 two-value elements that have a preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h') })
                .SetDescription("Combine two-value element that has a preceding element with following three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Combine three-value element that has a preceding element with following single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h') })
                .SetDescription("Combine three-value element that has a preceding element with following two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'i') })
                .SetDescription("Combine 2 three-value elements that have a preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Combine 2 single-value elements that have a following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Combine single-value element with following two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') }, 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Combine single-value element with following three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Combine two-value element with following single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Combine 2 two-value elements that have a following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f'), new('h') })
                .SetDescription("Combine two-value element with following three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Combine three-value element with following single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f'), new('h') })
                .SetDescription("Combine three-value element with following two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'g'), new('i') })
                .SetDescription("Combine 2 three-value elements that have a following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Combine 2 single-value elements that have preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Combine single-value element that has a preceding element with following two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('i') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Combine single-value element that has a preceding element with following three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Combine two-value element that has a preceding element with following single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Combine 2 two-value elements that have preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('j') })
                .SetDescription("Combine two-value element that has a preceding element with following three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Combine three-value element that has a preceding element with following single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('j') })
                .SetDescription("Combine three-value element that has a preceding element with following two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'i'), new('k') })
                .SetDescription("Combine 2 three-value elements that have preceding and following elements.");

        }

        public static System.Collections.IEnumerable GetAdd1Test6Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') })
                .SetDescription("Insert single-value element between existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') })
                .SetDescription("Insert single-value element after an existing single-value element with a preceding element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') })
                .SetDescription("Insert single-value element after an existing single-value element and before another single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g'), new('i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g'), new('i') })
                .SetDescription("Insert single-value element after an existing single-value element with a preceding element and before another single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f') })
                .SetDescription("Insert single-value element after existing single-value element and before a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'h') })
                .SetDescription("Insert single-value element after existing single-value element with a preceding element and before a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f'), new('h') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('h') })
                .SetDescription("Insert single-value element after existing single-value element and before a two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'h'), new('j') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'h'), new('j') })
                .SetDescription("Insert single-value element after existing single-value element with a preceding element and before a two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g') })
                .SetDescription("Insert single-value element after existing single-value element and before a three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'i') })
                .SetDescription("Insert single-value element after existing single-value element with a preceding element and before a three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('i') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('i') })
                .SetDescription("Insert single-value element after existing single-value element and before a three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'i'), new('k') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'i'), new('k') })
                .SetDescription("Insert single-value element after existing single-value element with a preceding element and before a three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f') })
                .SetDescription("Insert single-value element after existing two-value element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Insert single-value element after existing two-value element with a preceding element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f'), new('h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f'), new('h') })
                .SetDescription("Insert single-value element after existing two-value element and before another single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h'), new('j') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h'), new('j') })
                .SetDescription("Insert single-value element after existing two-value element with a preceding element and before another single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'g') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'g') })
                .SetDescription("Insert single-value element between existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'i') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'i') })
                .SetDescription("Insert single-value element after an existing two-value element with a preceding element and before another two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'g'), new('i') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'g'), new('i') })
                .SetDescription("Insert single-value element after an existing two-value element and before another two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'i'), new('k') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'i'), new('k') })
                .SetDescription("Insert single-value element after an existing two-value element with a preceding element and before another two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'h') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'h') })
                .SetDescription("Insert single-value element after existing two-value element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'j') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'j') })
                .SetDescription("Insert single-value element after existing two-value element with a preceding element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'h'), new('i') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'h'), new('i') })
                .SetDescription("Insert single-value element after existing two-value element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'j'), new('l') }, 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'j'), new('l') })
                .SetDescription("Insert single-value element after existing two-value element with a preceding element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g') })
                .SetDescription("Insert single-value element after existing three-value element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i') })
                .SetDescription("Insert single-value element after existing three-value element with a preceding element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g'), new('i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g'), new('i') })
                .SetDescription("Insert single-value element after existing three-value element and before another single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i'), new('k') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i'), new('k') })
                .SetDescription("Insert single-value element after existing three-value element with a preceding element and before another single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'h') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'h') })
                .SetDescription("Insert single-value element after existing three-value element and before a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'j') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'j') })
                .SetDescription("Insert single-value element after existing three-value element with a preceding element and before a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'h'), new('j') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'h'), new('j') })
                .SetDescription("Insert single-value element after existing three-value element and before a two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'j'), new('l') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'j'), new('l') })
                .SetDescription("Insert single-value element after existing three-value element with a preceding element and before a two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'i') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'i') })
                .SetDescription("Insert single-value element between existing three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'k') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'k') })
                .SetDescription("Insert single-value element after an existing three-value element with a preceding element and before another three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'i'), new('k') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'i'), new('k') })
                .SetDescription("Insert single-value element after an existing three-value element and before a three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'k'), new('m') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'k'), new('m') })
                .SetDescription("Insert single-value element after an existing three-value element with a preceding element and before another three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c') })
                .SetDescription("Add last single-value element following a single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Add last single-value element following a two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Add last single-value element following a three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') })
                .SetDescription("Add last single-value element following 2 single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') }, 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g') })
                .SetDescription("Add last single-value element following 2 two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') })
                .SetDescription("Add last single-value element following 2 three-value elements.");
        }

        public static System.Collections.IEnumerable GetAdd2Test1Data()
        {
            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a') })
                .SetDescription("Add single-value element to empty list.");

            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Add two-value element to empty list.");

            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Add three-value element to empty list.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c') })
                .SetDescription("Add first single-value element before existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Add first two-value element before existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Add first three-value element before existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Add first single-value element before existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d', 'e') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') })
                .SetDescription("Add first two-value element before existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('e', 'f') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') })
                .SetDescription("Add first three-value element before existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Add first single-value element before existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d', 'f') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') })
                .SetDescription("Add first two-value element before existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('e', 'g') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') })
                .SetDescription("Add first three-value element before existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c'), new('e') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') })
                .SetDescription("Add first single-value element before existing single-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d'), new('f') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f') })
                .SetDescription("Add first two-value element before existing single-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('e'), new('g') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g') })
                .SetDescription("Add first three-value element before existing single-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd'), new('f') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Add first single-value element before existing two-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d', 'e'), new('g') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g') })
                .SetDescription("Add first two-value element before existing two-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('e', 'f'), new('h') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h') })
                .SetDescription("Add first three-value element before existing two-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e'), new('g') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Add first single-value element before existing three-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d', 'f'), new('h') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h') })
                .SetDescription("Add first two-value element before existing three-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('e', 'g'), new('i') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') })
                .SetDescription("Add first three-value element before existing three-value element with additional following element.");
        }

        public static System.Collections.IEnumerable GetAdd2Test2Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('b') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("One-value extend, adjacent to single-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("One-value extend, adjacent to single-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value extend, adjacent to single-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Two-value extend, adjacent to single-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value extend, adjacent to single-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Three-value extend, adjacent to single-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("One-value extend, adjacent to two-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("One-value extend, adjacent to two-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value extend, adjacent to two-value first element.");
            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Two-value extend, adjacent to two-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d', 'e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value extend, adjacent to two-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f', 'g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Three-value extend, adjacent to two-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("One-value extend, adjacent to three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("One-value extend, adjacent to three-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value extend, adjacent to three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Two-value extend, adjacent to three-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('d', 'f') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value extend, adjacent to three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f', 'h') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h') })
                .SetDescription("Three-value extend, adjacent to three-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value extend, last same as existing two-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Two-value extend, last same as existing two-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value extend, last same as existing three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Three-value extend, last same as existing three-value element that has an additional preceding element..");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value extend, last between First and Last of three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Three-value extend, last between First and Last of three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Four-value add, last between First and Last of three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Four-value add, last between First and Last of three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Three-value extend, last same as Last of two-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Three-value extend, last same as Last of two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c'), new('e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Three-value extend, last same as Last of two-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e'), new('g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Three-value extend, last same as Last of two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Four-value extend, last same as Last of two-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Four-value extend, last same as Last of two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd'), new('f') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Four-value extend, last same as Last of two-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f'), new('h') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Four-value extend, last same as Last of two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Four-value extend, last same as Last of three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Four-value extend, last same as Last of three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd'), new('f') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Four-value extend, last same as Last of three-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f'), new('h') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Four-value extend, last same as Last of three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Five-value extend, last same as Last of three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Five-value extend, last same as Last of three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e'), new('g') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Five-value extend, last same as Last of three-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('i') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Five-value extend, last same as Last of three-value element that has additional preceding and following elements.");
        }

        public static System.Collections.IEnumerable GetAdd2Test3Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('b') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Three-value extend, expanding single-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Three-value extend, expanding single-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b'), new('e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Three-value extend, expanding single-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d'), new('g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Three-value extend, expanding single-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Four-value extend, expanding two-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Four-value extend, expanding two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c'), new('f') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Four-value extend, expanding two-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e'), new('h') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Four-value extend, expanding two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Five-value extend, expanding three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Five-value extend, expanding three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd'), new('g') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Five-value extend, expanding three-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f'), new('i') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Five-value extend, expanding three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Four-value extend, expanding First extent of single-value first element by 2.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Four-value extend, expanding First extent of single-value element by 2, which also has an additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c'), new('f') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Four-value extend, expanding First extent of single-value first element by 2, which also has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('h') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Four-value extend, expanding First extent of single-value element by 2, which also has an additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Five-value extend, expanding First extent of two-value first element by 2.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Five-value extend, expanding First extent of two-value element by 2, which also has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd'), new('g') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Five-value extend, expanding First extent of two-value first element by 2, which also has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f'), new('i') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Five-value extend, expanding First extent of two-value element by 2, which also has an additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Six-value extend, expanding First extent of three-value first element by 2.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h') })
                .SetDescription("Six-value extend, expanding First extent of three-value element by 2, which also has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e'), new('h') }, 'a', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f'), new('h') })
                .SetDescription("Six-value extend, expanding First extent of three-value first element by 2, which also has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('j') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('j') })
                .SetDescription("Six-value extend, expanding First extent of three-value element by 2, which also has an additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Four-value extend, expanding Last extent of single-value first element by 2.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Four-value extend, expanding Last extent of single-value element by 2, which also has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b'), new('f') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Four-value extend, expanding Last extent of single-value first element by 2, which also has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d'), new('h') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Four-value extend, expanding Last extent of single-value element by 2, which also has an additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Five-value extend, expanding Last extent of two-value first element by 2.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Five-value extend, expanding Last extent of two-value element by 2, which also has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c'), new('g') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Five-value extend, expanding Last extent of two-value first element by 2, which also has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e'), new('i') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Five-value extend, expanding Last extent of two-value element by 2, which also has an additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd') }, 'a', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Six-value extend, expanding Last extent of three-value first element by 2.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h') })
                .SetDescription("Six-value extend, expanding Last extent of three-value element by 2, which also has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'd'), new('h') }, 'a', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f'), new('h') })
                .SetDescription("Six-value extend, expanding Last extent of three-value first element by 2, which also has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f'), new('j') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('j') })
                .SetDescription("Six-value extend, expanding Last extent of three-value element by 2, which also has an additional preceding and following elements.");
        }

        public static System.Collections.IEnumerable GetAdd2Test4Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('c') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Five-value extend, expanding single-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Five-value extend, expanding single-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c'), new('g') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Five-value extend, expanding single-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('i') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Five-value extend, expanding single-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd') }, 'a', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Six-value extend, expanding two-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h') })
                .SetDescription("Six-value extend, expanding two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'd'), new('h') }, 'a', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f'), new('h') })
                .SetDescription("Six-value extend, expanding two-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f'), new('j') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('j') })
                .SetDescription("Six-value extend, expanding two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Seven-value extend, expanding three-value first element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'c', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'i') })
                .SetDescription("Seven-value extend, expanding three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e'), new('i') }, 'a', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'g'), new('i') })
                .SetDescription("Seven-value extend, expanding three-value first element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('k') }, 'c', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'i'), new('k') })
                .SetDescription("Seven-value extend, expanding three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Two-value extend, first same as existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Two-value extend, first same as existing single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Two-value extend, first same as existing single-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Two-value extend, first same as existing single-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Three-value extend, first same as existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Three-value extend, first same as existing single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Three-value extend, first same as existing single-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Three-value extend, first same as existing single-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Three-value extend, first same as First of existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Three-value extend, first same as First of existing two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Three-value extend, first same as First of existing two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Three-value extend, first same as First of existing two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Four-value extend, first same as First of existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Four-value extend, first same as First of existing two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Four-value extend, first same as First of existing two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Four-value extend, first same as First of existing two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Four-value extend, first same as First of existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'a', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Four-value extend, first same as First of existing three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Four-value extend, first same as First of existing three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Four-value extend, first same as First of existing three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Five-value extend, first same as First of existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g') }, 'a', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Five-value extend, first same as First of existing three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Five-value extend, first same as First of existing three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Five-value extend, first same as First of existing three-value element that has additional preceding and following elements.");
        }

        public static System.Collections.IEnumerable GetAdd2Test5Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value extend, first same as middle of three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Three-value extend, first same as middle of three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Three-value extend, first same as middle of three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Three-value extend, first same as middle of three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'b', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Four-value extend, first same as middle of three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g') }, 'b', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Four-value extend, first same as middle of three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'd', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Four-value extend, first same as middle of three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i') }, 'd', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Four-value extend, first same as middle of three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value extend, first same as Last of existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Two-value extend, first same as Last of existing two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Two-value extend, first same as Last of existing two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Two-value extend, first same as Last of existing two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value extend, first same as Last of existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Three-value extend, first same as Last of existing two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Three-value extend, first same as Last of existing two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Three-value extend, first same as Last of existing two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value extend, first same as Last of existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Two-value extend, first same as Last of existing three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Two-value extend, first same as Last of existing three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Two-value extend, first same as Last of existing three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value extend, first same as Last of existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Three-value extend, first same as Last of existing three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Three-value extend, first same as Last of existing three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Three-value extend, first same as Last of existing three-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("One-value extend, adjacent to Last of existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("One-value extend, adjacent to Last of existing single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("One-value extend, adjacent to Last of existing single-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('f') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("One-value extend, adjacent to Last of existing single-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value extend, adjacent to Last of existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Two-value extend, adjacent to Last of existing single-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Two-value extend, adjacent to Last of existing single-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Two-value extend, adjacent to Last of existing single-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("One-value extend, adjacent to Last of existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("One-value extend, adjacent to Last of existing two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("One-value extend, adjacent to Last of existing two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("One-value extend, adjacent to Last of existing two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value extend, adjacent to Last of existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("Two-value extend, adjacent to Last of existing two-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("Two-value extend, adjacent to Last of existing two-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("Two-value extend, adjacent to Last of existing two-value element that has additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("One-value extend, adjacent to Last of existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') })
                .SetDescription("One-value extend, adjacent to Last of existing three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') })
                .SetDescription("One-value extend, adjacent to Last of existing three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('h') })
                .SetDescription("One-value extend, adjacent to Last of existing three-value element that additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value extend, adjacent to Last of existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g') })
                .SetDescription("Two-value extend, adjacent to Last of existing three-value element that has an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') })
                .SetDescription("Two-value extend, adjacent to Last of existing three-value element that has an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') })
                .SetDescription("Two-value extend, adjacent to Last of existing three-value element that has additional preceding and following elements.");
        }

        public static System.Collections.IEnumerable GetAdd2Test6Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c') })
                .SetDescription("Single-value insert after existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') })
                .SetDescription("Single-value insert after existing single-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') })
                .SetDescription("Two-value insert after existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f') })
                .SetDescription("Two-value insert after existing single-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') })
                .SetDescription("Three-value insert after existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g') })
                .SetDescription("Three-value insert after existing single-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') })
                .SetDescription("Single-value insert between existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') })
                .SetDescription("Single-value insert after existing single-value element and before another single-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') })
                .SetDescription("Single-value insert after existing single-value element with an additional preceding element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g'), new('i') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g'), new('i') })
                .SetDescription("Single-value insert betwee existing single-value elements with additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Two-value insert between existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h') })
                .SetDescription("Two-value insert after existing single-value element and before another single-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('h') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('h') })
                .SetDescription("Two-value insert after existing single-value element with an additional preceding element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('h'), new('j') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('h'), new('j') })
                .SetDescription("Two-value insert betwee existing single-value elements with additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Three-value insert between existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('g'), new('i') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i') })
                .SetDescription("Three-value insert after existing single-value element and before another single-value element with additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('i') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('i') })
                .SetDescription("Three-value insert after existing single-value element with an additional preceding element and before another single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('i'), new('k') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('i'), new('k') })
                .SetDescription("Three-value insert betwee existing single-value elements with additional preceding and following elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f') })
                .SetDescription("Single-value insert after existing single-value element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f'), new('h') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('h') })
                .SetDescription("Single-value insert after existing single-value element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'h') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'h') })
                .SetDescription("Single-value insert after existing single-value element with an additional preceding element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'h'), new('j') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'h'), new('j') })
                .SetDescription("Single-value insert after existing single-value element with an additional preceding element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('g', 'h') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'h') })
                .SetDescription("Two-value insert after existing single-value element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('g', 'h'), new('j') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'h'), new('j') })
                .SetDescription("Two-value insert after existing single-value element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('i', 'j') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('i', 'j') })
                .SetDescription("Two-value insert after existing single-value element with an additional preceding element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('i', 'j'), new('l') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('i', 'j'), new('l') })
                .SetDescription("Two-value insert after existing single-value element with an additional preceding element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('i', 'j') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'j') })
                .SetDescription("Three-value insert after existing single-value element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('i', 'j'), new('l') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'j'), new('l') })
                .SetDescription("Three-value insert after existing single-value element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('k', 'l') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('k', 'l') })
                .SetDescription("Three-value insert after existing single-value element with an additional preceding element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('k', 'l'), new('n') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('k', 'l'), new('n') })
                .SetDescription("Three-value insert after existing single-value element with an additional preceding element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g') })
                .SetDescription("Single-value insert after existing single-value element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('i') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('i') })
                .SetDescription("Single-value insert after existing single-value element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'i') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'i') })
                .SetDescription("Single-value insert after existing single-value element with an additional preceding element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('g', 'i'), new('k') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g', 'i'), new('k') })
                .SetDescription("Single-value insert after existing single-value element with an additional preceding element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('g', 'i') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'i') })
                .SetDescription("Two-value insert after existing single-value element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('g', 'i'), new('k') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('g', 'i'), new('k') })
                .SetDescription("Two-value insert after existing single-value element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('i', 'k') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('i', 'k') })
                .SetDescription("Two-value insert after existing single-value element with an additional preceding element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('i', 'k'), new('m') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'f'), new('i', 'k'), new('m') })
                .SetDescription("Two-value insert after existing single-value element with an additional preceding element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('h', 'j') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h', 'j') })
                .SetDescription("Three-value insert after existing single-value element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('h', 'j'), new('l') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('h', 'j'), new('l') })
                .SetDescription("Three-value insert after existing single-value element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('j', 'l') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('j', 'l') })
                .SetDescription("Three-value insert after existing single-value element with an additional preceding element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c'), new('j', 'l'), new('n') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', 'g'), new('j', 'l'), new('n') })
                .SetDescription("Three-value insert after existing single-value element with an additional preceding element and before three-value element with an additional following element.");
        }

        public static System.Collections.IEnumerable GetAdd2Test7Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') })
                .SetDescription("Single-value insert after existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') })
                .SetDescription("Single-value insert after existing two-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') })
                .SetDescription("Two-value insert after existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g') })
                .SetDescription("Two-value insert after existing two-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') })
                .SetDescription("Three-value insert after existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f') })
                .SetDescription("Single-value insert after existing two-value element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f'), new('h') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f'), new('h') })
                .SetDescription("Single-value insert after existing two-value element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h') })
                .SetDescription("Single-value insert after existing two-value element with an additional preceding element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h'), new('j') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h'), new('j') })
                .SetDescription("Single-value insert after existing two-value element with an additional preceding element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('g') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g') })
                .SetDescription("Two-value insert after existing two-value element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('g'), new('i') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g'), new('i') })
                .SetDescription("Two-value insert after existing two-value element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('i') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i') })
                .SetDescription("Two-value insert after existing two-value element with an additional preceding element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('i'), new('k') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i'), new('k') })
                .SetDescription("Two-value insert after existing two-value element with an additional preceding element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('h') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h') })
                .SetDescription("Three-value insert after existing two-value element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('h'), new('j') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h'), new('j') })
                .SetDescription("Three-value insert after existing two-value element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('j') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('j'), new('l') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j'), new('l') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'g') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'g') })
                .SetDescription("Single-value insert between existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'g'), new('i') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'g'), new('i') })
                .SetDescription("Single-value insert before existing two-value element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'i') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'i') })
                .SetDescription("Single-value insert after existing two-value element with an additional preceding element and before another two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'i'), new('k') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'i'), new('k') })
                .SetDescription("Single-value insert after existing two-value element with an additional preceding element and before another two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('g', 'h') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') })
                .SetDescription("Two-value insert between existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('g', 'h'), new('j') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j') })
                .SetDescription("Two-value insert before existing two-value element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('i', 'j') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i', 'j') })
                .SetDescription("Two-value insert after existing two-value element with an additional preceding element and before another two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('i', 'j'), new('l') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i', 'j'), new('l') })
                .SetDescription("Two-value insert after existing two-value element with an additional preceding element and before another two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('h', 'i') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h', 'i') })
                .SetDescription("Three-value insert between existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('h', 'i'), new('k') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h', 'i'), new('k') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element and before another two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('j', 'k') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j', 'k') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element and before another two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('j', 'k'), new('m') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j', 'k'), new('m') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element and before another two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'h') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'h') })
                .SetDescription("Single-value insert after existing two-value element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'h'), new('j') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', 'h'), new('j') })
                .SetDescription("Single-value insert after existing two-value element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'j') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'j') })
                .SetDescription("Single-value insert after existing two-value element with an additional preceding element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('h', 'j'), new('l') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f'), new('h', 'j'), new('l') })
                .SetDescription("Single-value insert after existing two-value element with an additional preceding element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('g', 'i') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'i') })
                .SetDescription("Two-value insert after existing two-value element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('g', 'i'), new('k') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'i'), new('k') })
                .SetDescription("Two-value insert after existing two-value element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('i', 'k') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i', 'k') })
                .SetDescription("Two-value insert after existing two-value element with an additional preceding element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('i', 'k'), new('m') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g'), new('i', 'k'), new('m') })
                .SetDescription("Two-value insert after existing two-value element with an additional preceding element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('h', 'j') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h', 'j') })
                .SetDescription("Three-value insert after existing two-value element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('h', 'j'), new('l') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('h', 'j'), new('l') })
                .SetDescription("Three-value insert after existing two-value element and before three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('j', 'l') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j', 'l') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element and before three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('j', 'l'), new('n') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h'), new('j', 'l'), new('n') })
                .SetDescription("Three-value insert after existing two-value element with an additional preceding element and before three-value element with an additional following element.");
        }

        public static System.Collections.IEnumerable GetAdd2Test8Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') })
                .SetDescription("Single-value insert after existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'g', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') })
                .SetDescription("Single-value insert after existing three-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') })
                .SetDescription("Two-value insert after existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'g', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h') })
                .SetDescription("Two-value insert after existing three-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') })
                .SetDescription("Three-value insert after existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'g', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i') })
                .SetDescription("Three-value insert after existing three-value element with an additional preceding element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g') })
                .SetDescription("Single-value insert after existing three-value element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g'), new('i') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g'), new('i') })
                .SetDescription("Single-value insert after existing three-value element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i') }, 'g', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i') })
                .SetDescription("Single-value insert after existing three-value element with an additional preceding element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i'), new('k') }, 'g', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i'), new('k') })
                .SetDescription("Single-value insert after existing three-value element with an additional preceding element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('h') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h') })
                .SetDescription("Two-value insert after existing three-value element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('h'), new('j') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h'), new('j') })
                .SetDescription("Two-value insert after existing three-value element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('j') }, 'g', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j') })
                .SetDescription("Two-value insert after existing three-value element with an additional preceding element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('j'), new('l') }, 'g', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j'), new('l') })
                .SetDescription("Two-value insert after existing three-value element with an additional preceding element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('i') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') })
                .SetDescription("Three-value insert after existing three-value element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('i'), new('k') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i'), new('k') })
                .SetDescription("Three-value insert after existing three-value element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('k') }, 'g', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k') })
                .SetDescription("Three-value insert after existing three-value element with an additional preceding element and before single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('k'), new('m') }, 'g', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k'), new('m') })
                .SetDescription("Three-value insert after existing three-value element with an additional preceding element and before single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'h') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'h') })
                .SetDescription("Single-value insert after existing three-value element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'h'), new('j') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'h'), new('j') })
                .SetDescription("Single-value insert after existing three-value element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'j') }, 'g', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'j') })
                .SetDescription("Single-value insert after existing three-value element with an additional preceding element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'j'), new('l') }, 'g', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'j'), new('l') })
                .SetDescription("Single-value insert after existing three-value element with an additional preceding element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('h', 'i') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h', 'i') })
                .SetDescription("Two-value insert after existing three-value element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('h', 'i'), new('k') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h', 'i'), new('k') })
                .SetDescription("Two-value insert after existing three-value element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('j', 'k') }, 'g', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j', 'k') })
                .SetDescription("Two-value insert after existing three-value element with an additional preceding element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('j', 'k'), new('m') }, 'g', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j', 'k'), new('m') })
                .SetDescription("Two-value insert after existing three-value element with an additional preceding element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('i', 'j') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'j') })
                .SetDescription("Three-value insert after existing three-value element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('i', 'j'), new('l') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'j'), new('l') })
                .SetDescription("Three-value insert after existing three-value element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('k', 'l') }, 'g', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k', 'l') })
                .SetDescription("Three-value insert after existing three-value element with an additional preceding element and before two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('k', 'l'), new('n') }, 'g', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k', 'l'), new('n') })
                .SetDescription("Three-value insert after existing three-value element with an additional preceding element and before two-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'i') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'i') })
                .SetDescription("Single-value insert between existing three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'i'), new('k') }, 'e', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', 'i'), new('k') })
                .SetDescription("Single-value insert after existing three-value element and before another single-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'k') }, 'g', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'k') })
                .SetDescription("Single-value insert after existing three-value element with an additional preceding element and before another three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('i', 'k'), new('m') }, 'g', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g'), new('i', 'k'), new('m') })
                .SetDescription("Single-value insert after existing three-value element with an additional preceding element and before another three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('h', 'j') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h', 'j') })
                .SetDescription("Two-value insert between existing three-value elements.");
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('h', 'j'), new('l') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('h', 'j'), new('l') })
                .SetDescription("Two-value insert after existing three-value element and before another three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('j', 'l') }, 'g', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j', 'l') })
                .SetDescription("Two-value insert after existing three-value element with an additional preceding element and before another three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('j', 'l'), new('n') }, 'g', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h'), new('j', 'l'), new('n') })
                .SetDescription("Two-value insert after existing three-value element with an additional preceding element and before another three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('i', 'k') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') })
                .SetDescription("Three-value insert between existing three-value elements.");
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('i', 'k'), new('m') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k'), new('m') })
                .SetDescription("Three-value insert after existing three-value element and before another three-value element with an additional following element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('k', 'm') }, 'g', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k', 'm') })
                .SetDescription("Three-value insert after existing three-value element with an additional preceding element and before another three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('k', 'm'), new('o') }, 'g', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i'), new('k', 'm'), new('o') })
                .SetDescription("Three-value insert after existing three-value element with an additional preceding element and before another three-value element with an additional following element.");

        }

        public static System.Collections.IEnumerable GetAdd2Test9Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a') })
                .SetDescription("Single-value add existing single-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Two-value add existing two-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Three-value add existing three-value element.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Single-value add existing Two-value element First.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'a', 'a')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Single-value add existing Three-value element First.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Single-value add existing Three-value element middle.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'b') })
                .SetDescription("Single-value add existing Two-value element Last.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Single-value add existing Three-value element Last.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value add existing Three-value element First.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value add existing Three-value element Last.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'd') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value add existing Four-value element middle.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b', 'c') }, 'd', 'a')
                .Returns(new NumberExtents<char>[] { new('b', 'c') })
                .SetDescription("Four-value add reverse order values to two-value element.");

            yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'c', 'a')
                .Returns(Array.Empty<NumberExtents<char>>())
                .SetDescription("Three-value add reverse order values to empty list.");
        }

        public static System.Collections.IEnumerable GetAdd2Test10Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Single-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value merge 2 existing single-value elements.");
            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'c') })
                .SetDescription("Two-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b'), new('d') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge 2 existing single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Single-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b'), new('d', 'e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Single-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b'), new('d', 'e') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'e') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'd') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge existing single- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'b', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Single-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'a', 'b')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e', 'g') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('b'), new('d', 'f') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('d', 'f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('c', 'e') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing single- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Single-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Two-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'a', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'd') })
                .SetDescription("Three-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing two- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing two- and single-value elements.");
        }

        public static System.Collections.IEnumerable GetAdd2Test11Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Single-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'f') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge 2 existing two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') }, 'c', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Single-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'g') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Two-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') }, 'b', 'c')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'h') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'h') })
                .SetDescription("Three-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'g') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') }, 'b', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('f', 'h') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'h') })
                .SetDescription("Three-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b'), new('e', 'g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge existing two- and three-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Single-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Two-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'e') })
                .SetDescription("Three-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing three- and single-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Single-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'g') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Two-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Two-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'h') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'h') })
                .SetDescription("Three-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'f') })
                .SetDescription("Three-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'g') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge existing three- and two-value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'd', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Single-value merge existing 2 three--value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'h') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'h') })
                .SetDescription("Two-value merge existing 2 three--value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'c', 'd')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Two-value merge existing 2 three--value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'd', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Two-value merge existing 2 three--value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'h') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'h') })
                .SetDescription("Three-value merge existing 2 three--value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('g', 'i') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'i') })
                .SetDescription("Three-value merge existing 2 three--value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'c', 'e')
                .Returns(new NumberExtents<char>[] { new('a', 'g') })
                .SetDescription("Three-value merge existing 2 three--value elements.");

            yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('f', 'h') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'h') })
                .SetDescription("Three-value merge existing 2 three--value elements.");
        }

        public static System.Collections.IEnumerable GetAdd2Test12Data()
        {
            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'b', 'l')
                .Returns(new NumberExtents<char>[] { new('a', 'm') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'b', 'k')
                .Returns(new NumberExtents<char>[] { new('a', 'k'), new('m') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'b', 'j')
                .Returns(new NumberExtents<char>[] { new('a', 'j'), new('m') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'b', 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'i'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'b', 'h')
                .Returns(new NumberExtents<char>[] { new('a', 'h'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'b', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'h'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'b', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'f'), new('h'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'c', 'l')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'm') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'c', 'k')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'k'), new('m') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'c', 'j')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'j'), new('m') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'c', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'i'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'd', 'l')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'm') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'd', 'k')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'k'), new('m') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('m') }, 'd', 'j')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'j'), new('m') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'd', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'i'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'd', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'h'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('f'), new('h'), new('k') }, 'd', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'h'), new('k') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'b', 'k')
                .Returns(new NumberExtents<char>[] { new('a', 'l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'b', 'j')
                .Returns(new NumberExtents<char>[] { new('a', 'j'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'b', 'i')
                .Returns(new NumberExtents<char>[] { new('a', 'i'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'b', 'h')
                .Returns(new NumberExtents<char>[] { new('a', 'h'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'b', 'g')
                .Returns(new NumberExtents<char>[] { new('a', 'g'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'b', 'f')
                .Returns(new NumberExtents<char>[] { new('a', 'g'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'c', 'k')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'c', 'j')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'j'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'c', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'i'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'c', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'h'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'c', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'c', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'd', 'k')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'd', 'j')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'j'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'd', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'h'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'd', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'g'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'd', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('d', 'g'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'e', 'k')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'e', 'j')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'j'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'e', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'i'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'e', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'h'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'e', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'e', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'f', 'k')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'f', 'j')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'j'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('l') }, 'f', 'i')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'i'), new('l') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'f', 'h')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'h'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'f', 'g')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('j') });

            yield return new TestCaseData(new NumberExtents<char>[] { new('a'), new('e'), new('g'), new('j') }, 'f', 'f')
                .Returns(new NumberExtents<char>[] { new('a'), new('e', 'g'), new('j') });
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