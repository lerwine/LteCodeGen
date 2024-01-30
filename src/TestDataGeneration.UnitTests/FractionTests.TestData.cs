namespace TestDataGeneration.UnitTests;

public partial class FractionTests
{
    class TestData
    {
        public static System.Collections.IEnumerable GetGetProperRationalTestData()
        {
            yield return new TestCaseData(6, 1, 2)
                                .Returns((6, 1));
            yield return new TestCaseData(6, 3, 2)
                                .Returns((7, 1));
            yield return new TestCaseData(6, 4, 2)
                                .Returns((8, 0));
        }

        public static System.Collections.IEnumerable GetGetSimplifiedRationalTestData()
        {
            yield return new TestCaseData(2, 4)
                                .Returns((1, 2));
            yield return new TestCaseData(4, 2)
                                .Returns((2, 1));
            yield return new TestCaseData(9, 6)
                                .Returns((3, 2));
            yield return new TestCaseData(6, 9)
                                .Returns((2, 3));
            yield return new TestCaseData(13, 9)
                                .Returns((13, 9));
            yield return new TestCaseData(2, 6)
                                .Returns((1, 3));
        }

        public static System.Collections.IEnumerable GetToCommonDenominatorTestData()
        {
            yield return new TestCaseData(2, 3, 3, 4)
                                .Returns((8, 12, 9, 12));

            yield return new TestCaseData(1, 8, 7, 6)
                                .Returns((3, 24, 28, 24));

            yield return new TestCaseData(13, 9, 2, 6)
                                .Returns((13, 9, 3, 9));

            yield return new TestCaseData(11, 1, 5, 1)
                                .Returns((11, 1, 5, 1));

            yield return new TestCaseData(6, 4, 8, 1)
                                .Returns((3, 2, 16, 2));

            yield return new TestCaseData(99, 9, 1, 9)
                                .Returns((99, 9, 1, 9));

            yield return new TestCaseData(0, 3, 6, 8)
                                .Returns((0, 4, 3, 4));

            yield return new TestCaseData(0, 1, 0, 7)
                                .Returns((0, 1, 0, 1));
        }

        public static System.Collections.IEnumerable GetGetGCDTestTestData()
        {
            yield return new TestCaseData(8, 12).Returns(4);
            yield return new TestCaseData(12, 8).Returns(4);
            yield return new TestCaseData(1, 12).Returns(1);
            yield return new TestCaseData(12, 1).Returns(1);
            yield return new TestCaseData(1, 1).Returns(1);
            yield return new TestCaseData(2, 3).Returns(1);
            yield return new TestCaseData(2, 4).Returns(2);
        }

        public static System.Collections.IEnumerable GetGetLCMTestData()
        {
            yield return new TestCaseData(3, 4).Returns(12);
            yield return new TestCaseData(4, 3).Returns(12);
            yield return new TestCaseData(6, 4).Returns(12);
            yield return new TestCaseData(4, 6).Returns(12);
            yield return new TestCaseData(5, 7).Returns(35);
            yield return new TestCaseData(7, 5).Returns(35);
            yield return new TestCaseData(6, 9).Returns(18);
            yield return new TestCaseData(9, 6).Returns(18);
            yield return new TestCaseData(9, 9).Returns(9);
            yield return new TestCaseData(15, 10).Returns(30);
            yield return new TestCaseData(10, 15).Returns(30);
            yield return new TestCaseData(1, 11).Returns(11);
            yield return new TestCaseData(11, 1).Returns(11);
            yield return new TestCaseData(11, 11).Returns(11);
            yield return new TestCaseData(1, 1).Returns(1);
            yield return new TestCaseData(12, 9).Returns(36);
            yield return new TestCaseData(12, 16).Returns(48);
        }
    }
}