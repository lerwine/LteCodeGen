using System.Numerics;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public partial class NumberExtentsTests
    {
        class TestData
        {
            public static System.Collections.IEnumerable GetImmediatelyFollowsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'A').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('B', 'd'), 'A').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'C'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetImmediatelyPrecedesTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'B').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'D').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'D').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsBeforeTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'B').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('C'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'c'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'D').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('C', 'E'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneAfterTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('d'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('C'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'D').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'A').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('C', 'E'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'f').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'f').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'F').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsAfterTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'C').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('B', 'D'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'E').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'f').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), 'z').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), 'z').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, 'z'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, char.MinValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('z', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffd'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', '\ufffe'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe', char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue, char.MaxValue), char.MinValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetGetRelationOfTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), 'd').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'D').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'd').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'b').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'B').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'A').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('B'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'A').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('D'), 'a').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d'), 'A').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0003').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0002').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0001').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MinValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), char.MinValue).Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), char.MaxValue).Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MaxValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffe').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffd').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffc').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MaxValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'f').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), 'a').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0005').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0004').Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0003').Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), char.MinValue).Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), char.MaxValue).Returns(ExtentValueRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(ExtentValueRelativity.Includes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffc').Returns(ExtentValueRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffb').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffa').Returns(ExtentValueRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(ExtentValueRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(ExtentValueRelativity.FollowsWithGap);
            }

            public static System.Collections.IEnumerable GetGetRelationToTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('d')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0003')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('f')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0005')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'e')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('f'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0003', '\u0005')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', '\u0004')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue, '\ufffd')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('f', 'h')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'g')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d', 'f')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c', 'e')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('b', 'd')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'd')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'd')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'e')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('f', 'h'), new NumberExtents<char>('a', 'c')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0005', '\u0007')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004', '\u0006')).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003', '\u0005')).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002', '\u0004')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0004'), new NumberExtents<char>('\u0001', '\u0003')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0004')).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\u0004', '\u0006'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\u0005', '\u0007'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufff8', '\ufffa'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufff9', '\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.ImmediatelyPrecedes);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.EqualTo);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.Contains);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffb', char.MaxValue)).Returns(ExtentRelativity.ContainedBy);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(ExtentRelativity.Overlaps);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(ExtentRelativity.ImmediatelyFollows);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff9', '\ufffb')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff8', '\ufffa')).Returns(ExtentRelativity.FollowsWithGap);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(ExtentRelativity.PrecedesWithGap);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(ExtentRelativity.FollowsWithGap);
            }

            public static System.Collections.IEnumerable GetReverseTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('a')).Returns(new char[] { 'a' });
                yield return new TestCaseData(new NumberExtents<char>('a', 'b')).Returns(new char[] { 'b', 'a' });
                yield return new TestCaseData(new NumberExtents<char>('A', 'F')).Returns(new char[] { 'F', 'E', 'D', 'C', 'B', 'A' });
            }

            public static System.Collections.IEnumerable GetContainsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0001').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), '\u0002').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), '\ufffe').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'a').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'a').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'A').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'b').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'b').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'B').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'c').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('A', 'C'), 'c').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'C').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'd').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), 'e').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), char.MinValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MinValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0001').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0002').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0003').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), '\u0004').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffb').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffc').Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffd').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), '\ufffe').Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MaxValue).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), char.MaxValue).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), char.MinValue).Returns(false);
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
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue)).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'd')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', '\u0004')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001', '\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue, '\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'g')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d', 'f')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c', 'e')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b', 'd')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'c')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'd')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('b', 'c')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('b', 'c'), new NumberExtents<char>('a', 'e')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('a', 'c')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004', '\u0006')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003', '\u0005')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002', '\u0004')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001', '\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0003')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0004'), new NumberExtents<char>('\u0001', '\u0002')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0002'), new NumberExtents<char>(char.MinValue, '\u0004')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\u0004', '\u0006'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufff9', '\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(0);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', '\ufffe')).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', '\ufffe'), new NumberExtents<char>('\ufffc', char.MaxValue)).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff9', '\ufffb')).Returns(1);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(-1);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(1);
            }

            public static System.Collections.IEnumerable GetEqualsTestData()
            {
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue)).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('e'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a'), new NumberExtents<char>('c', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\u0002', '\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('e', 'g'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('d', 'f'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('c', 'e'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('a', 'c')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('a', 'c')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'd'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'e'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('b', 'd'), new NumberExtents<char>('a', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('b', 'd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('c', 'e')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('d', 'f')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('a', 'c'), new NumberExtents<char>('e', 'g')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0004', '\u0006'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0003', '\u0005'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0002', '\u0004'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0003'), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0004'), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\u0001', '\u0003'), new NumberExtents<char>(char.MinValue, '\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0001', '\u0003')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0002', '\u0004')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0003', '\u0005')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\u0004', '\u0006')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufff9', '\ufffb')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffa', '\ufffc')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffb', '\ufffd')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(true);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', char.MaxValue), new NumberExtents<char>('\ufffc', '\ufffe')).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffb', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffc', '\ufffe'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffb', '\ufffd'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffa', '\ufffc'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufff9', '\ufffb'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>(char.MinValue, '\u0002'), new NumberExtents<char>('\ufffd', char.MaxValue)).Returns(false);
                yield return new TestCaseData(new NumberExtents<char>('\ufffd', char.MaxValue), new NumberExtents<char>(char.MinValue, '\u0002')).Returns(false);
            }

            public static System.Collections.IEnumerable GetConstructorTestData()
            {
                yield return new TestCaseData('a', 'a').Returns((First: 'a', Last: 'a', GetCount: new BigInteger(1)));
                yield return new TestCaseData('a', 'b').Returns((First: 'a', Last: 'b', GetCount: new BigInteger(2)));
                yield return new TestCaseData('a', 'z').Returns((First: 'a', Last: 'z', GetCount: new BigInteger(26)));
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
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'c', extents: new('a')).Returns(true);
                yield return create(value: 'c', extents: new('A')).Returns(true);
                yield return create(value: 'C', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('A')).Returns(true);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'a', extents: new('C')).Returns(true);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'E', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(true);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: 'e', extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneAfterTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('c'), value: 'A').Returns(true);
                yield return create(extents: new('c'), value: 'a').Returns(true);
                yield return create(extents: new('C'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'A').Returns(true);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('a'), value: 'C').Returns(true);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(true);
                yield return create(extents: new('C', 'E'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'A').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(true);
                yield return create(extents: new('a'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(false);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneAfterTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('A')).Returns(false);
                yield return create(value: 'C', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('A')).Returns(false);
                yield return create(value: 'a', extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(true);
                yield return create(value: 'a', extents: new('c')).Returns(true);
                yield return create(value: 'a', extents: new('C')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'E', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(true);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneAfterTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('c'), value: 'A').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('C'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'A').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(true);
                yield return create(extents: new('a'), value: 'c').Returns(true);
                yield return create(extents: new('a'), value: 'C').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('C', 'E'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'A').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(true);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('c')).Returns(true);
                yield return create(value: 'a', extents: new('C')).Returns(false);
                yield return create(value: 'a', extents: new('C')).Returns(false);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'A', extents: new('b')).Returns(true);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(true);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'A', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsMoreThanOneBeforeTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'c').Returns(true);
                yield return create(extents: new('a'), value: 'C').Returns(false);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('A'), value: 'b').Returns(true);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('A', 'C'), value: 'd').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(true);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneBeforeTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'a', extents: new('C')).Returns(true);
                yield return create(value: 'a', extents: new('C')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(true);
                yield return create(value: 'A', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('a')).Returns(true);
                yield return create(value: 'c', extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(true);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'A', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(true);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
            }

            public static System.Collections.IEnumerable GetIsNotMoreThanOneBeforeTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('a'), value: 'C').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(true);
                yield return create(extents: new('A'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'a').Returns(true);
                yield return create(extents: new('c'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(true);
                yield return create(extents: new('A', 'C'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(true);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(false);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(true);

            }

            public static System.Collections.IEnumerable GetIsLessThanTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('c')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(true);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(true);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(true);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsLessThanTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'c').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(true);
                yield return create(extents: new('a'), value: 'B').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('C'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'D').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('C', 'E'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(true);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsGreaterThanTest1Data()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'c', extents: new('a')).Returns(true);
                yield return create(value: 'b', extents: new('a')).Returns(true);
                yield return create(value: 'B', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: 'a', extents: new('C', 'E')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(true);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: 'a', extents: new('e', char.MaxValue)).Returns(false);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsGreaterThanTest2Data()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('c'), value: 'a').Returns(true);
                yield return create(extents: new('b'), value: 'a').Returns(true);
                yield return create(extents: new('B'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('a'), value: 'C').Returns(true);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(true);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(true);
                yield return create(extents: new('B', 'D'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'E').Returns(true);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: 'e').Returns(false);
                yield return create(extents: new('e', char.MaxValue), value: 'a').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(false);
            }

            public static System.Collections.IEnumerable GetIsIncludedInTestData()
            {
                static TestCaseData create(char value, NumberExtents<char> extents)
                {
                    return new TestCaseData(value, extents).SetArgDisplayNames((value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'", extents.ToString());
                }
                yield return create(value: 'a', extents: new('a')).Returns(true);
                yield return create(value: 'a', extents: new('b')).Returns(false);
                yield return create(value: 'a', extents: new('c')).Returns(false);
                yield return create(value: 'b', extents: new('a')).Returns(false);
                yield return create(value: 'c', extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'b')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'b')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'b')).Returns(false);
                yield return create(value: 'd', extents: new('a', 'b')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'b', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'c', extents: new('a', 'c')).Returns(true);
                yield return create(value: 'd', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'e', extents: new('a', 'c')).Returns(false);
                yield return create(value: 'a', extents: new('b', 'd')).Returns(false);
                yield return create(value: 'a', extents: new('c', 'e')).Returns(false);
                yield return create(value: char.MinValue, extents: new('a')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a')).Returns(false);
                yield return create(value: 'a', extents: new(char.MinValue)).Returns(false);
                yield return create(value: 'a', extents: new(char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', 'c')).Returns(false);
                yield return create(value: 'c', extents: new(char.MinValue, 'e')).Returns(true);
                yield return create(value: 'e', extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: 'e', extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MinValue, extents: new(char.MinValue, 'c')).Returns(true);
                yield return create(value: char.MinValue, extents: new('a', char.MaxValue)).Returns(false);
                yield return create(value: char.MinValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, 'c')).Returns(false);
                yield return create(value: char.MaxValue, extents: new('a', char.MaxValue)).Returns(true);
                yield return create(value: char.MaxValue, extents: new(char.MinValue, char.MaxValue)).Returns(true);
            }

            public static System.Collections.IEnumerable GetIncludesTestData()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'a').Returns(true);
                yield return create(extents: new('a'), value: 'b').Returns(false);
                yield return create(extents: new('a'), value: 'c').Returns(false);
                yield return create(extents: new('b'), value: 'a').Returns(false);
                yield return create(extents: new('c'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'b'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'b'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'b'), value: 'c').Returns(false);
                yield return create(extents: new('a', 'b'), value: 'd').Returns(false);
                yield return create(extents: new('b', 'c'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'a').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'b').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'c').Returns(true);
                yield return create(extents: new('a', 'c'), value: 'd').Returns(false);
                yield return create(extents: new('a', 'c'), value: 'e').Returns(false);
                yield return create(extents: new('b', 'd'), value: 'a').Returns(false);
                yield return create(extents: new('c', 'e'), value: 'a').Returns(false);
                yield return create(extents: new('a'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a'), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue), value: 'a').Returns(false);
                yield return create(extents: new(char.MaxValue), value: 'a').Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MinValue).Returns(false);
                yield return create(extents: new('a', 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new(char.MinValue, 'e'), value: 'c').Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'e').Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MinValue).Returns(true);
                yield return create(extents: new('a', char.MaxValue), value: char.MinValue).Returns(false);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(true);
                yield return create(extents: new(char.MinValue, 'c'), value: char.MaxValue).Returns(false);
                yield return create(extents: new('a', char.MaxValue), value: char.MaxValue).Returns(true);
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(true);
            }

            public static System.Collections.IEnumerable GetWithFirstTestData()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('b'), value: 'a').Returns(new NumberExtents<char>('a', 'b'));
                yield return create(extents: new('a', 'b'), value: 'a').Returns(new NumberExtents<char>('a', 'b'));
                yield return create(extents: new('a', 'b'), value: 'b').Returns(new NumberExtents<char>('b'));
                
                yield return create(extents: new(char.MaxValue), value: char.MinValue).Returns(new NumberExtents<char>(char.MinValue, char.MaxValue));
                yield return create(extents: new(char.MinValue, char.MaxValue), value: 'a').Returns(new NumberExtents<char>('a', char.MaxValue));
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(new NumberExtents<char>(char.MinValue, char.MaxValue));
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MaxValue).Returns(new NumberExtents<char>(char.MaxValue));
            }

            public static System.Collections.IEnumerable GetWithLastTestData()
            {
                static TestCaseData create(NumberExtents<char> extents, char value)
                {
                    return new TestCaseData(extents, value).SetArgDisplayNames(extents.ToString(), (value == char.MinValue) ? "char.MinValue" : (value == char.MaxValue) ? "char.MaxValue" : (char.IsAscii(value) && !char.IsControl(value)) ? $"'{value}'" : $"'\\u{(int)value:x4}'");
                }
                yield return create(extents: new('a'), value: 'b').Returns(new NumberExtents<char>('a', 'b'));
                yield return create(extents: new('a', 'b'), value: 'a').Returns(new NumberExtents<char>('a'));
                yield return create(extents: new('a', 'b'), value: 'b').Returns(new NumberExtents<char>('a', 'b'));
                yield return create(extents: new(char.MinValue), value: char.MaxValue).Returns(new NumberExtents<char>(char.MinValue, char.MaxValue));
                yield return create(extents: new(char.MinValue), value: 'a').Returns(new NumberExtents<char>(char.MinValue, 'a'));
                yield return create(extents: new(char.MinValue, char.MaxValue), value: char.MinValue).Returns(new NumberExtents<char>(char.MinValue));
                yield return create(extents: new(char.MinValue), value: char.MaxValue).Returns(new NumberExtents<char>(char.MinValue, char.MaxValue));
            }

            public static System.Collections.IEnumerable GetAddFirstTest1Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'a').Returns(new NumberExtents<char>[] { new('a') });
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'b').Returns(new NumberExtents<char>[] { new('a', 'b') });
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'c').Returns(new NumberExtents<char>[] { new('a', 'c') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('d', 'e') }, 'a', 'b').Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('e', 'g') }, 'a', 'c').Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('e', 'g'), new('i', 'k') }, 'a', 'c').Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') });
            }

            public static System.Collections.IEnumerable GetAddFirstTest2Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a').Returns(new NumberExtents<char>[] { new('a') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e') }, 'a').Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('c', 'e'), new('g', 'i') }, 'a').Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i') });
            }

            public static System.Collections.IEnumerable GetAddLastTest1Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'a').Returns(new NumberExtents<char>[] { new('a', 'a') });
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'b').Returns(new NumberExtents<char>[] { new('a', 'b') });
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a', 'c').Returns(new NumberExtents<char>[] { new('a', 'c') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'b') }, 'd', 'e').Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'e', 'g').Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'i', 'k').Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') });
            }

            public static System.Collections.IEnumerable GetAddLastTest2Data()
            {
                yield return new TestCaseData(Array.Empty<NumberExtents<char>>(), 'a').Returns(new NumberExtents<char>[] { new('a') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c') }, 'e').Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') });
                yield return new TestCaseData(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, 'i').Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') });

            }

            public static System.Collections.IEnumerable GetAddPreviousTest1Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
                {
                    return new TestCaseData(before, target, after, first, last);
                }
                yield return create(before: null, target: new('d', 'e'), after: new('g', 'h'), first: 'a', last: 'b')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') });
                yield return create(before: new('a', 'b'), target: new('g', 'h'), after: new('j', 'k'), first: 'd', last: 'e')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j', 'k') });
                yield return create(before: new('a', 'b'), target: new('g', 'h'), after: null, first: 'd', last: 'e')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') });
            }

            public static System.Collections.IEnumerable GetAddPreviousTest2Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
                {
                    return new TestCaseData(before, target, after, value);
                }
                yield return create(before: null, target: new('c'), after: new('e'), value: 'a').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') });
                yield return create(before: new('a'), target: new('e'), after: new('g'), value: 'c').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') });
                yield return create(before: new('a'), target: new('e'), after: null, value: 'c').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') });
            }

            public static System.Collections.IEnumerable GetAddNextTest1Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char first, char last)
                {
                    return new TestCaseData(before, target, after, first, last);
                }
                yield return create(before: null, target: new('a', 'b'), after: new('g', 'h'), first: 'd', last: 'e')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') });
                yield return create(before: new('a', 'b'), target: new('d', 'e'), after: new('j', 'k'), first: 'g', last: 'h')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h'), new('j', 'k') });
                yield return create(before: new('a', 'b'), target: new('d', 'e'), after: null, first: 'g', last: 'h')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') });
            }

            public static System.Collections.IEnumerable GetAddNextTest2Data()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, NumberExtents<char>? after, char value)
                {
                    return new TestCaseData(before, target, after, value);
                }
                yield return create(before: null, target: new('a'), after: new('e'), value: 'c').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') });
                yield return create(before: new('a'), target: new('c'), after: new('g'), value: 'e').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e'), new('g') });
                yield return create(before: new('a'), target: new('c'), after: null, value: 'e').Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e') });
            }

            public static System.Collections.IEnumerable GetRemoveAndGetNextTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>? expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c'), expected: new('g'), new('g'), new('i') )
                    .Returns(new NumberExtents<char>[] { new('a'), new('g'), new('i') });
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c'), expected: new('g'), new NumberExtents<char>('g'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('g') });
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c'), expected: null)
                    .Returns(new NumberExtents<char>[] { new('a') });
            }

            public static System.Collections.IEnumerable GetRemoveAndGetPreviousTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, NumberExtents<char>? expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, after, expected);
                }
                yield return create(before: new NumberExtents<char>[] { new('a'), new('c') }, target: new('e'), expected: new('c'), new('g'), new('i'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('g'), new('i') });
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c'), expected: new('a'), new('e'), new('g'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('e'), new('g') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a'), expected: null, new('c'), new('e'))
                    .Returns(new NumberExtents<char>[] { new('c'), new('e') });
            }

            public static System.Collections.IEnumerable GetTryExpandTest1Data()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, first, last, after);
                }
                foreach (var c in new char[] { 'a', 'b' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', c), 'a', 'a')
                        .Returns(new NumberExtents<char>[] { new('a', c) });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', c), 'a', 'b')
                        .Returns(new NumberExtents<char>[] { new('a', 'b') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'b')
                        .Returns(new NumberExtents<char>[] { new('a', 'c') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'b'), 'a', c, new NumberExtents<char>('d'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'b'), c, 'b', new NumberExtents<char>('d', 'e'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'b'), 'a', c, new NumberExtents<char>('d', 'f'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'b', new NumberExtents<char>('e'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'b', new NumberExtents<char>('e', 'g'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'b', new NumberExtents<char>('e', 'f'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') });
                }
                foreach (var c in new char[] { 'a', 'b', 'c' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'c', new NumberExtents<char>('e'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'c', new NumberExtents<char>('e', 'g'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'c', new NumberExtents<char>('e', 'f'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') });
                }
                foreach (var c in new char[] { 'b', 'c' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), c, 'c')
                        .Returns(new NumberExtents<char>[] { new('a', 'c') });
                }
                foreach (var c in new char[] { 'a', 'c' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), 'a', c)
                        .Returns(new NumberExtents<char>[] { new('a'), new('c') });
                }
                foreach (var c in new char[] { 'c', 'd' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a'), 'a', 'a', new NumberExtents<char>('c', c))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'd'), 'c', c)
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', c), c, c)
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), 'c', c)
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'd'), c, 'd', new NumberExtents<char>('f'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'd'), c, 'd', new NumberExtents<char>('f', 'g'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'g') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'd'), c, 'd', new NumberExtents<char>('f', 'h'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), c, 'd', new NumberExtents<char>('g'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), c, 'd', new NumberExtents<char>('g', 'h'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), c, 'd', new NumberExtents<char>('g', 'i'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i') });
                }
                foreach (var c in new char[] { 'c', 'd', 'e' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), c, 'e')
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), c, 'e', new NumberExtents<char>('g'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), c, 'e', new NumberExtents<char>('g', 'h'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), c, 'e', new NumberExtents<char>('g', 'i'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i') });
                }
                foreach (var c in new char[] { 'd', 'e' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'b'), 'b', 'b', new NumberExtents<char>('d', c))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'e'), c, 'e')
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), 'd', c)
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'e'), c, 'e', new NumberExtents<char>('g'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'e'), c, 'e', new NumberExtents<char>('g', 'h'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'h') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'e'), c, 'e', new NumberExtents<char>('g', 'i'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'i') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), c, 'e', new NumberExtents<char>('j'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), c, 'e', new NumberExtents<char>('j', 'k'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', 'k') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), c, 'e', new NumberExtents<char>('j', 'l'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', 'l') });
                }
                foreach (var c in new char[] { 'd', 'e', 'f' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), c, 'f')
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), c, 'f', new NumberExtents<char>('j'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), c, 'f', new NumberExtents<char>('j', 'k'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', 'k') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), c, 'f', new NumberExtents<char>('j', 'l'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', 'l') });
                }
                foreach (var c in new char[] { 'e', 'f' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', c), 'd', 'd')
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', c), 'e', 'e')
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'f'), c, 'f')
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'f')
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'f'), c, 'f', new NumberExtents<char>('j'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('j') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'f'), c, 'f', new NumberExtents<char>('j', 'k'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('j', 'k') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'f'), c, 'f', new NumberExtents<char>('j', 'l'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('j', 'l') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'f', new NumberExtents<char>('i'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'f', new NumberExtents<char>('i', 'j'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'j') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'f', new NumberExtents<char>('i', 'k'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') });
                }
                foreach (var c in new char[] { 'e', 'f', 'g' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'g')
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c'), 'c', 'c', new NumberExtents<char>('e', c))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c'), new('e', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'g', new NumberExtents<char>('i'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'g', new NumberExtents<char>('i', 'j'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'j') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), c, 'g', new NumberExtents<char>('i', 'k'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') });
                }
                foreach (var c in new char[] { 'f', 'g', 'h' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d'), 'd', 'd', new NumberExtents<char>('f', c))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d'), new('f', c) });
                }
                foreach (var c in new char[] { 'g', 'h' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), 'c', 'c', new NumberExtents<char>('g', c))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', c) });
                }
                foreach (var c in new char[] { 'g', 'h', 'i' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'e'), 'd', 'd', new NumberExtents<char>('g', c))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e'), 'e', 'e', new NumberExtents<char>('g', c))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e'), new('g', c) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'f'), 'e', 'e', new NumberExtents<char>('g', c))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('g') });
                }
                foreach (var c in new char[] { 'i', 'j' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), 'e', 'e', new NumberExtents<char>('i', c))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', c) });
                }
                foreach (var c in new char[] { 'j', 'k', 'l' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), 'd', 'd', new NumberExtents<char>('j', c))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', c) });
                }

                yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d'), 'd', 'd')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'b'), 'b', 'b', new NumberExtents<char>('d', 'f'))
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') });

                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a'), 'a', 'a', new NumberExtents<char>('c', 'e'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), 'a', 'a', new NumberExtents<char>('e'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') });

                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), 'd', 'd')
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') });

                yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), 'e', 'e')
                    .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });

                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'd'), 'c', 'c', new NumberExtents<char>('f', 'h'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h') });

                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'e'), 'c', 'c', new NumberExtents<char>('g', 'i'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'i') });

                yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('d', 'f'), 'd', 'd', new NumberExtents<char>('j', 'l'))
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', 'l') });

                yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), 'e', 'e', new NumberExtents<char>('i', 'k'))
                    .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', 'k') });
            }

            public static System.Collections.IEnumerable GetTryExpandTest2Data()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, first, last, after);
                }

                foreach (char c1 in new char[] { 'a', 'b' })
                {
                    foreach (char c2 in new char[] { 'e', 'f' })
                    {
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new(c1), 'a', 'b', new NumberExtents<char>('d', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', c2) });
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new(c1, 'b'), 'a', 'c', new NumberExtents<char>('e', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', c2) });
                    }
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new(c1), 'a', 'b')
                        .Returns(new NumberExtents<char>[] { new('a', 'b') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new(c1, 'b'), 'a', 'c')
                        .Returns(new NumberExtents<char>[] { new('a', 'c') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new(c1), 'a', 'b', new NumberExtents<char>('d'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new(c1, 'b'), 'a', 'c', new NumberExtents<char>('e', 'g'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                }

                foreach (char c1 in new char[] { 'c', 'd' })
                {
                    foreach (char c2 in new char[] { 'f', 'g' })
                    {
                        yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1), 'c', 'd', new NumberExtents<char>('f', c2))
                            .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', c2) });
                    }
                    foreach (char c2 in new char[] { 'g', 'i' })
                    {
                        yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1, 'd'), 'c', 'e', new NumberExtents<char>('g', c2))
                            .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', c2) });
                    }
                    foreach (char c2 in new char[] { 'f', 'h' })
                    {
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', c1), 'a', 'd', new NumberExtents<char>('f', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', c2) });
                    }
                    foreach (char c2 in new char[] { 'k', 'l' })
                    {
                        yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1, 'e'), 'c', 'f', new NumberExtents<char>('j', c2))
                            .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('j', c2) });
                    }
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1), 'c', 'd')
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', c1), 'a', 'd')
                        .Returns(new NumberExtents<char>[] { new('a', 'd') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1, 'd'), 'c', 'e')
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1, 'e'), 'c', 'f')
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1), 'c', 'd', new NumberExtents<char>('f', 'h'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'd'), new('f', 'h') });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', c1), 'a', 'd', new NumberExtents<char>('f', 'g'))
                        .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', 'g') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new(c1, 'e'), 'c', 'f', new NumberExtents<char>('j'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('j') });
                }

                foreach (char c1 in new char[] { 'd', 'e' })
                {
                    foreach (char c2 in new char[] { 'g', 'h' })
                    {
                        yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1), 'd', 'e', new NumberExtents<char>('g', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', c2) });
                    }
                    foreach (char c2 in new char[] { 'j', 'k' })
                    {
                        yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1, 'e'), 'd', 'f', new NumberExtents<char>('j', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', c2) });
                        yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1, 'f'), 'd', 'g', new NumberExtents<char>('i', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'g'), new('i', c2) });
                    }
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1), 'd', 'e')
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1, 'e'), 'd', 'f')
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1, 'f'), 'd', 'g')
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'g') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', c1), 'c', 'e', new NumberExtents<char>('g', 'h'))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1), 'd', 'e', new NumberExtents<char>('g', 'i'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'e'), new('g', 'i') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1, 'e'), 'd', 'f', new NumberExtents<char>('j', 'l'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', 'l') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new(c1, 'f'), 'd', 'g', new NumberExtents<char>('i'))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'g'), new('i') });
                }

                foreach (char c1 in new char[] { 'e', 'f' })
                {
                    foreach (char c2 in new char[] { 'j', 'k'})
                    {
                        yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1), 'e', 'f', new NumberExtents<char>('j', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('j', c2) });
                        yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1, 'f'), 'e', 'g', new NumberExtents<char>('i', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', c2) });
                        yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1, 'g'), 'e', 'j', new NumberExtents<char>('j', c2))
                            .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'j'), new('j', c2) });
                    }
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1), 'e', 'f')
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1), 'e', 'f', new NumberExtents<char>('j', 'l'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'f'), new('j', 'l') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1, 'f'), 'e', 'g')
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1, 'f'), 'e', 'g', new NumberExtents<char>('i'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1, 'g'), 'e', 'j')
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'j') });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new(c1, 'g'), 'e', 'j', new NumberExtents<char>('j', 'l'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'j'), new('j', 'l') });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', 'e'), 'c', c1)
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', c1) });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'c'), 'a', 'c', new NumberExtents<char>('e', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', c1) });
                }

                foreach (char c1 in new char[] { 'g', 'h' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'd'), 'a', 'e', new NumberExtents<char>('g', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g', c1) });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), 'a', 'd', new NumberExtents<char>('f', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', c1) });
                }

                foreach (char c1 in new char[] { 'g', 'i' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', 'e'), 'c', 'e', new NumberExtents<char>('g', c1))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', c1) });
                }

                foreach (char c2 in new char[] { 'g', 'j' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'g'), 'd', c2)
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', c2) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'g'), 'e', c2)
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', c2) });
                }

                foreach (char c1 in new char[] { 'h', 'i' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'd'), 'a', 'e', new NumberExtents<char>('g', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g', c1) });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), 'a', 'd', new NumberExtents<char>('f', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', c1) });
                }

                foreach (char c1 in new char[] { 'j', 'k' })
                {
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'd'), 'a', 'e', new NumberExtents<char>('g', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g', c1) });
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), 'a', 'd', new NumberExtents<char>('f', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f', c1) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'f'), 'd', 'f', new NumberExtents<char>('j', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', c1) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'g'), 'e', 'g', new NumberExtents<char>('i', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i', c1) });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', 'f'), 'c', 'f', new NumberExtents<char>('j', c1))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('j', c1) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'g'), 'd', 'g', new NumberExtents<char>('i', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'g'), new('i', c1) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'j'), 'e', 'j', new NumberExtents<char>('j', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'j'), new('j', c1) });
                    yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', 'f'), 'c', 'g', new NumberExtents<char>('i', c1))
                        .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i', c1) });
                    yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'g'), 'd', 'j', new NumberExtents<char>('j', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'j'), new('j', c1) });
                }

                foreach (char c1 in new char[] { 'k', 'l' })
                {
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'j'), 'e', 'i', new NumberExtents<char>('k', c1))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'i'), new('k', c1) });
                }

                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'c'), 'a', 'c')
                    .Returns(new NumberExtents<char>[] { new('a', 'c') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), 'a', 'd')
                    .Returns(new NumberExtents<char>[] { new('a', 'd') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'd'), 'a', 'e')
                    .Returns(new NumberExtents<char>[] { new('a', 'e') });
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', 'f'), 'c', 'g')
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'j'), 'e', 'i')
                    .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'i') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'c'), 'a', 'c', new NumberExtents<char>('e', 'g'))
                    .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), 'a', 'd', new NumberExtents<char>('f'))
                    .Returns(new NumberExtents<char>[] { new('a', 'd'), new('f') });
                yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('b', 'd'), 'a', 'e', new NumberExtents<char>('g', 'i'))
                    .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g', 'i') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'f'), 'd', 'f')
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f') });
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('c', 'd'), 'c', 'e', new NumberExtents<char>('g', 'h'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'e'), new('g', 'h') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'f'), 'd', 'f', new NumberExtents<char>('j', 'l'))
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'f'), new('j', 'l') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'g'), 'e', 'g', new NumberExtents<char>('i'))
                    .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g'), new('i') });
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', 'f'), 'c', 'f', new NumberExtents<char>('j', 'l'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'f'), new('j', 'l') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'g'), 'd', 'g', new NumberExtents<char>('i'))
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'g'), new('i') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'j'), 'e', 'j', new NumberExtents<char>('j', 'l'))
                    .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'j'), new('j', 'l') });
                yield return create(before: new NumberExtents<char>[] { new('a') }, target: new('d', 'f'), 'c', 'g', new NumberExtents<char>('i'))
                    .Returns(new NumberExtents<char>[] { new('a'), new('c', 'g'), new('i') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'b') }, target: new('e', 'g'), 'd', 'j', new NumberExtents<char>('j', 'l'))
                    .Returns(new NumberExtents<char>[] { new('a', 'b'), new('d', 'j'), new('j', 'l') });
                yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('f', 'j'), 'e', 'i', new NumberExtents<char>('k', 'm'))
                    .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'i'), new('k', 'm') });
            }

            public static System.Collections.IEnumerable GetTryExpandTest3Data()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, first, last, after);
                }

                foreach (var first in new char[] { 'a', 'b', 'c', 'd', 'e', 'f' })
                {
                    foreach (var last in new char[] { 'o', 'n', 'm', 'l', 'k', 'j' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'i'), first, last, new NumberExtents<char>('k', 'm'))
                            .Returns(new NumberExtents<char>[] { new('a', 'o') });
                    foreach (var last in new char[] { 'n', 'm', 'l', 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'j'), first, last, new NumberExtents<char>('j', 'l'))
                            .Returns(new NumberExtents<char>[] { new('a', 'n') });
                    foreach (var last in new char[] { 'm', 'l', 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g'), first, last, new NumberExtents<char>('i', 'k'))
                            .Returns(new NumberExtents<char>[] { new('a', 'm') });
                    foreach (var last in new char[] { 'n', 'm', 'l', 'k', 'j' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'i'), first, last, new NumberExtents<char>('k', 'l'))
                            .Returns(new NumberExtents<char>[] { new('a', 'n') });
                    foreach (var last in new char[] { 'm', 'l', 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'j'), first, last, new NumberExtents<char>('j', 'k'))
                            .Returns(new NumberExtents<char>[] { new('a', 'm') });
                    foreach (var last in new char[] { 'l', 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g'), first, last, new NumberExtents<char>('i', 'j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'l') });
                    foreach (var last in new char[] { 'm', 'l', 'k', 'j' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'i'), first, last, new NumberExtents<char>('k'))
                            .Returns(new NumberExtents<char>[] { new('a', 'm') });
                    foreach (var last in new char[] { 'l', 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'j'), first, last, new NumberExtents<char>('j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'l') });
                    foreach (var last in new char[] { 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g'), first, last, new NumberExtents<char>('i'))
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'i'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'i', 'h', 'g' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'i') });
                    yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'j'), first, last: 'j')
                        .Returns(new NumberExtents<char>[] { new('a', 'j') });
                }
                foreach (var first in new char[] { 'a', 'b', 'c', 'd', 'e' })
                {
                    foreach (var last in new char[] { 'n', 'm', 'l', 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'j'), first, last, new NumberExtents<char>('j', 'l'))
                            .Returns(new NumberExtents<char>[] { new('a', 'n') });
                    foreach (var last in new char[] { 'k', 'j', 'i', 'h', 'g', 'f' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'e'), first, last, new NumberExtents<char>('g', 'i'))
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'm', 'l', 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'g'), first, last, new NumberExtents<char>('i', 'k'))
                            .Returns(new NumberExtents<char>[] { new('a', 'm') });
                    foreach (var last in new char[] { 'm', 'l', 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'j'), first, last, new NumberExtents<char>('j', 'k'))
                            .Returns(new NumberExtents<char>[] { new('a', 'm') });
                    foreach (var last in new char[] { 'j', 'i', 'h', 'g', 'f' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'e'), first, last, new NumberExtents<char>('g', 'j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                    foreach (var last in new char[] { 'l', 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'g'), first, last, new NumberExtents<char>('i', 'j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'l') });
                    foreach (var last in new char[] { 'l', 'k', 'j', 'i' })
                    {
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'j'), first, last, new NumberExtents<char>('j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'l') });
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f'), first, last, new NumberExtents<char>('j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'l') });
                    }
                    foreach (var last in new char[] { 'i', 'h', 'g', 'f' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'e'), first, last, new NumberExtents<char>('g'))
                            .Returns(new NumberExtents<char>[] { new('a', 'i') });
                    foreach (var last in new char[] { 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'g'), first, last, new NumberExtents<char>('i'))
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'g', 'f', 'e' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'e'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'g') });
                    foreach (var last in new char[] { 'i', 'h', 'g' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'g'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'i') });
                    foreach (var last in new char[] { 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f'), first, last, new NumberExtents<char>('j', 'i'))
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f'), first, last, new NumberExtents<char>('j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                    yield return create(before: new NumberExtents<char>[] { new('c', 'd') }, target: new('f', 'j'), first, last: 'j')
                        .Returns(new NumberExtents<char>[] { new('a', 'j') });
                }
                foreach (var first in new char[] { 'a', 'b', 'c', 'd' })
                {
                    foreach (var last in new char[] { 'j', 'i', 'h', 'g', 'f', 'e' })
                    {
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'd'), first, last, new NumberExtents<char>('f', 'j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'd'), first, last, new NumberExtents<char>('f'))
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                    }
                    foreach (var last in new char[] { 'm', 'l', 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'g'), first, last, new NumberExtents<char>('i', 'k'))
                            .Returns(new NumberExtents<char>[] { new('a', 'm') });
                    foreach (var last in new char[] { 'k', 'j', 'i', 'h', 'g', 'f' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e'), first, last, new NumberExtents<char>('g', 'i'))
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'j', 'i', 'h', 'g', 'f' })
                    {
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'f'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e'), first, last, new NumberExtents<char>('g', 'j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                    }
                    foreach (var last in new char[] { 'l', 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'g'), first, last, new NumberExtents<char>('i', 'j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'l') });
                    foreach (var last in new char[] { 'i', 'h', 'g', 'f', 'e' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'd'), first, last, new NumberExtents<char>('f', 'g'))
                            .Returns(new NumberExtents<char>[] { new('a', 'i') });
                    foreach (var last in new char[] { 'k', 'j', 'i', 'h' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'g'), first, last, new NumberExtents<char>('i'))
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'l', 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'f'), first, last, new NumberExtents<char>('j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'l') });
                    foreach (var last in new char[] { 'i', 'h', 'g', 'f' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e'), first, last, new NumberExtents<char>('g'))
                            .Returns(new NumberExtents<char>[] { new('a', 'i') });
                    foreach (var last in new char[] { 'i', 'h', 'g' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'g'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'i') });
                    foreach (var last in new char[] { 'k', 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'f'), first, last, new NumberExtents<char>('j', 'i'))
                            .Returns(new NumberExtents<char>[] { new('a', 'k') });
                    foreach (var last in new char[] { 'f', 'e', 'd' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'd'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'f') });
                    foreach (var last in new char[] { 'g', 'f', 'e' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'g') });
                    foreach (var last in new char[] { 'j', 'i' })
                        yield return create(before: new NumberExtents<char>[] { new('c') }, target: new('e', 'f'), first, last, new NumberExtents<char>('j'))
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                }
                foreach (var first in new char[] { 'a', 'b', 'c' })
                {
                    foreach (var last in new char[] { 'j', 'i', 'h', 'g', 'f', 'e', 'd' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c'), first, last, new NumberExtents<char>('e', 'f'))
                            .Returns(new NumberExtents<char>[] { new('a', 'j') });
                    foreach (var last in new char[] { 'i', 'h', 'g', 'f', 'e', 'd' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c'), first, last, new NumberExtents<char>('e', 'g'))
                            .Returns(new NumberExtents<char>[] { new('a', 'i') });
                    foreach (var last in new char[] { 'g', 'f', 'e', 'd' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c'), first, last, new NumberExtents<char>('e'))
                            .Returns(new NumberExtents<char>[] { new('a', 'g') });
                    foreach (var last in new char[] { 'e', 'd', 'c' })
                        yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c'), first, last)
                            .Returns(new NumberExtents<char>[] { new('a', 'e') });
                }
            }

            // public static System.Collections.IEnumerable GetTryExpandTest4Data()
            // {
            //     static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, params NumberExtents<char>[] after)
            //     {
            //         return new TestCaseData(before, target, first, last, after);
            //     }
            // }

            // public static System.Collections.IEnumerable GetTryExpandTest5Data()
            // {
            //     static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char first, char last, params NumberExtents<char>[] after)
            //     {
            //         return new TestCaseData(before, target, first, last, after);
            //     }
            // }

            public static System.Collections.IEnumerable GetTryExpandFirstTestData()
            {
                static TestCaseData create(NumberExtents<char>[] before, NumberExtents<char> target, char value, bool expected, NumberExtents<char>? after)
                {
                    return new TestCaseData(before, target, value, after, expected);
                }
                foreach (var value in new char[] { 'h', 'i', 'j', 'k' })
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, target: new('i', 'k'), value, expected: true, after: new('m', 'o'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'k'), new('m', 'o') });
                foreach (var value in new char[] { 'a', 'b', 'c', 'd' })
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') }, target: new('i', 'k'), value, expected: true, after: new('m', 'o'))
                        .Returns(new NumberExtents<char>[] { new('a', 'k'), new('m', 'o') });
                foreach (var value in new char[] { 'a', 'b', 'c', 'd' })
                    yield return create(before: new NumberExtents<char>[] { new('a', 'c') }, target: new('e', 'g'), value, expected: true, after: new('i', 'k'))
                        .Returns(new NumberExtents<char>[] { new('a', 'g'), new('i', 'k') });
                foreach (var value in new char[] { 'a', 'b' })
                    yield return create(before: new NumberExtents<char>[] { new('c', 'e') }, target: new('g', 'i'), value, expected: true, after: new('k', 'm'))
                        .Returns(new NumberExtents<char>[] { new('a', 'i'), new('k', 'm') });
                foreach (var value in new char[] { 'a', 'b' })
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('c', 'e'), value, expected: true, after: new('g', 'i'))
                        .Returns(new NumberExtents<char>[] { new('a', 'e'), new('g', 'i') });
                foreach (var value in new char[] { 'a', 'b', 'c' })
                    yield return create(before: Array.Empty<NumberExtents<char>>(), target: new('a', 'c'), value, expected: false, after: new('e', 'g'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'g') });
            }

            public static System.Collections.IEnumerable GetTryExpandLastTestData()
            {
                static TestCaseData create(NumberExtents<char>? before, NumberExtents<char> target, char value, bool expected, params NumberExtents<char>[] after)
                {
                    return new TestCaseData(before, target, value, after, expected);
                }
                foreach (var value in new char[] { 'h', 'i', 'j', 'k' })
                    yield return create(before: new('a', 'c'), target: new('e', 'g'), value, expected: true, new('i', 'k'), new('n', 'o'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'k'), new('n', 'o') });
                foreach (var value in new char[] { 'l', 'm', 'n', 'o' })
                    yield return create(before: new('a', 'c'), target: new('e', 'g'), value, expected: true, new('i', 'k'), new('n', 'o'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', 'o') });
                foreach (var value in new char[] { 'p', 'q' })
                    yield return create(before: new('a', 'c'), target: new('e', 'g'), value, expected: true, new('i', 'k'), new('n', 'o'))
                        .Returns(new NumberExtents<char>[] { new('a', 'c'), new('e', value) });
            }
        }
    }
}