using System.Globalization;

namespace TestDataGeneration.UnitTests;

public partial class FractionTests
{
    class TestData
    {
        public static System.Collections.IEnumerable GetTryParseSimpleFractionTestData()
        {
            yield return new TestCaseData("+5∕+17", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 5, 17);
            yield return new TestCaseData("(+009)/10", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 9, 10);
            yield return new TestCaseData("+13/-00010", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 13, -10);
            yield return new TestCaseData("+5/-26", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 5, -26);
            yield return new TestCaseData("-24/+10", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -24, 10);
            yield return new TestCaseData("-27∕-0025", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -27, -25);
            yield return new TestCaseData("-017/14", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -17, 14);
            yield return new TestCaseData("-14/-19", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -14, -19);
            yield return new TestCaseData("(−7∕-28)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -7, -28);
            yield return new TestCaseData("−15∕+17", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -15, 17);
            yield return new TestCaseData("−21/-00017", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -21, -17);
            yield return new TestCaseData("−15/-3", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -15, -3);
            yield return new TestCaseData("(21∕-006)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 21, -6);
            yield return new TestCaseData("(0013∕-17)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 13, -17);
            yield return new TestCaseData("6/-18", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 6, -18);
            yield return new TestCaseData("(22∕21)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 22, 21);
        }

        public static System.Collections.IEnumerable GetTryParseMixedFractionTestData()
        {
            yield return new TestCaseData("(−26)\t\t+9/−31", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -26, 9, -31);
            yield return new TestCaseData("19  +5∕(−023)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 19, 5, -23);
            yield return new TestCaseData("(12  +4/(+031))", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 12, 4, 31);
            yield return new TestCaseData("−15  +11∕−31", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -15, 11, -31);
            yield return new TestCaseData("+15 (+\t  26)∕31", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 15, 26, -31);
            yield return new TestCaseData("(−17 \t+  31∕−19)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -17, 31, -19);
            yield return new TestCaseData("+12   + 14∕-00026", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 12, 14, -26);
            yield return new TestCaseData("-24 + 0/07", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -24, 0, 7);
            yield return new TestCaseData("00029+21∕-016", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 29, 21, -16);
            yield return new TestCaseData("((-16)+00028∕-23)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -16, 28, -23);
            yield return new TestCaseData("+31+6∕22", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 31, 6, 22);
            yield return new TestCaseData("11+02/(+28)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 11, 2, 28);
            yield return new TestCaseData("-7+ 0020∕26", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -7, 20, 26);
            yield return new TestCaseData("1+  \t0031/15", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 1, 31, -15);
            yield return new TestCaseData("-28+ 023/-26", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -28, 23, -26);
            yield return new TestCaseData("-30+ 0/-26", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -30, 0, -26);
            yield return new TestCaseData("11  \t-1∕17", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 11, -1, 17);
            yield return new TestCaseData("(8)   -30∕(9)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 8, -30, -9);
            yield return new TestCaseData("(+28)   -7∕31", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 28, -7, -31);
            yield return new TestCaseData("7 \t(-18)∕6", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -7, -18, 6);
            yield return new TestCaseData("4  - 11∕+23", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 4, -11, 23);
            yield return new TestCaseData("(9)  (-  \t22)/+00010", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 9, -22, 10);
            yield return new TestCaseData("27 -\t22∕-21", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 27, -22, -21);
            yield return new TestCaseData("4  -  7∕7", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 4, -7, 7);
            yield return new TestCaseData("(−10)-11/−5", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -10, -11, -5);
            yield return new TestCaseData("25-6/−23", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 25, -6, -23);
            yield return new TestCaseData("+12-16/+19", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 12, -16, 19);
            yield return new TestCaseData("−0028-2/−29", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -28, -2, -29);
            yield return new TestCaseData("8-   14∕021", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -8, -14, -21);
            yield return new TestCaseData("((-23)- 11∕(18))", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -23, -11, 18);
            yield return new TestCaseData("(+12-  1/−8)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 12, -1, -8);
            yield return new TestCaseData("-23- 0000/+9", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -23, 0, 9);
            yield return new TestCaseData("-1\t  −7∕22", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -1, -7, 22);
            yield return new TestCaseData("(4\t−27∕3)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -4, -27, -3);
            yield return new TestCaseData("+26 −8/-001", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 26, -8, -1);
            yield return new TestCaseData("-21  −0∕-3", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -21, 0, -3);
            yield return new TestCaseData("008 − 30/(-4)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 8, -30, -4);
            yield return new TestCaseData("((0019)\t  −   17/24)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 19, -17, -24);
            yield return new TestCaseData("+11   (−  028)∕(−2)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 11, -28, -2);
            yield return new TestCaseData("17  −   0023∕+14", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -17, -23, 14);
            yield return new TestCaseData("−28(−24)∕8", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -28, -24, 8);
            yield return new TestCaseData("(−19−9∕−4)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -19, -9, -4);
            yield return new TestCaseData("25−25∕−12", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 25, -25, -12);
            yield return new TestCaseData("(−08−8∕−17)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -8, -8, -17);
            yield return new TestCaseData("+19− 12/(-12)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 19, -12, -12);
            yield return new TestCaseData("12(−  \t5)/+28", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -12, -5, 28);
            yield return new TestCaseData("28−   28/+00018", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -28, -28, 18);
            yield return new TestCaseData("+2− 21/-5", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 2, -21, -5);
            yield return new TestCaseData("(-20  \t22∕-29)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -20, 22, -29);
            yield return new TestCaseData("22 27/(26)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, 22, 27, 26);
            yield return new TestCaseData("-07 28/(-28)", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -7, 28, -28);
            yield return new TestCaseData("-6  31∕1", NumberStyles.AllowLeadingSign | NumberStyles.Integer, -6, 31, 1);
        }

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