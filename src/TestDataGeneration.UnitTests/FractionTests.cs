using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public class FractionTests
    {
        private Random _random;
        [SetUp]
        public void Setup()
        {
            _random = new();
        }

        private string GetRandomPaddingText(int minLength, int maxLength)
        {
            int length = (minLength == maxLength) ? minLength : _random.Next(minLength, maxLength + 1);
            if (length == 0) return string.Empty;
            if (length == 1) return (_random.Next(0, 4) == 4) ? "\t" : " ";
            StringBuilder sb = new();
            for (var i = 0; i < length; i++) sb.Append((_random.Next(0, 4) == 4) ? '\t' : ' ');
            return sb.ToString();
        }

        private string GetRandomZeroPad(int minLength, int maxLength)
        {
            int length = (minLength == maxLength) ? minLength : _random.Next(minLength, maxLength + 1);
            if (length < 1) return string.Empty;
            return new string('0', length);
        }

        private string GetRandomNumber(int minLength, int maxLength)
        {
            int length = (minLength == maxLength) ? minLength : _random.Next(minLength, maxLength + 1);
            if (length < 2) return _random.Next(1, 10).ToString();
            StringBuilder sb = new();
            for (var i = 0; i < length; i++) sb.Append(_random.Next(0, 10));
            var result = sb.ToString();
            return result.All(c => c == '0') ? result[1..] + _random.Next(1, 10).ToString() : result;
        }

        private int GetRandomInteger(int minLength, int maxLength, bool allowZero = false)
        {
            int length = (minLength == maxLength) ? minLength : _random.Next(minLength, maxLength + 1);
            if (length < 2) return _random.Next(allowZero ? 0 : 1, 10);
            int minValue = 1, maxValue = 10;
            do
            {
                minValue *= 10;
                maxValue *= 10;
                length--;
            }
            while (length > 1);
            return _random.Next(minValue, maxValue);
        }

        [Test]
        public void TryParseSimpleFractionTest()
        {
            var separatorChars = new string[] { "∕", "/" };
            var signChars = new[]
            {
                (Sign: "", IsNegative: false),
                (Sign: "+", IsNegative: false),
                (Sign: "-", IsNegative: true),
                (Sign: "−", IsNegative: true)
            };
            var style = NumberStyles.AllowLeadingSign | NumberStyles.Integer;
            var provider = CultureInfo.CurrentCulture.NumberFormat;
            var wholeNumberTestData1 = signChars.Select(numSign => (numSign.Sign, numSign.IsNegative, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(1, 6, true)));
            if (!wholeNumberTestData1.Any(t => t.Expected == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0) });
            if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.Expected < 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(1, 1)) });
            if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.IsNegative)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { ("-", true, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(1, 1)) });
            if (!wholeNumberTestData1.Any(t => t.Expected > 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(2, 6)) });
            if (!wholeNumberTestData1.Any(t => t.ZeroPad.Length == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: string.Empty, Expected: GetRandomInteger(1, 6, true)) });
            if (!wholeNumberTestData1.Any(t => t.ZeroPad.Length > 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(1, 4), Expected: GetRandomInteger(1, 6, true)) });
            var wholeNumberTestData2 = wholeNumberTestData1.Select(t => (OpenPad: GetRandomPaddingText(0, 6), t.Sign, t.IsNegative, t.ZeroPad, t.Expected, ClosePad: GetRandomPaddingText(0, 6)));
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!wholeNumberTestData2.Any(t => t.ClosePad.Length == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: string.Empty
                ) });
            if (!wholeNumberTestData2.Any(t => t.ClosePad.Length > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length == 0 && t.ClosePad.Length == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: string.Empty
                ) });
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length > 0 && t.ClosePad.Length > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            var numDenTestData1 = signChars.SelectMany(numSign =>
                signChars.SelectMany(denSign =>
                    separatorChars.Select(s =>
                        (
                            NumSign: numSign.Sign, NumNegative: numSign.IsNegative, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                            PadSepLeft: GetRandomPaddingText(-6, 6),
                            Separator: s,
                            PadSepRight: GetRandomPaddingText(-6, 6),
                            DenSign: numSign.Sign, DenNegative: numSign.IsNegative, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                        )
                    )
                )
            );
            if (!numDenTestData1.Any(t => t.ExpectedNum == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: 0,
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.ExpectedNum > 1 && t.ExpectedNum < 10)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 1),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.ExpectedDen == 1)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: 1
                    )
                });
            if (!numDenTestData1.Any(t => t.ExpectedDen > 10)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(2, 6)
                    )
                });

            if (!numDenTestData1.Any(t => t.PadSepLeft.Length == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: string.Empty,
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepLeft.Length > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(1, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepRight.Length == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: string.Empty,
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepRight.Length > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(1, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepLeft.Length == 0 && t.PadSepRight.Length == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: string.Empty,
                        Separator: separatorChars[0],
                        PadSepRight: string.Empty,
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepLeft.Length > 0 && t.PadSepRight.Length > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(2, 6),
                        PadSepLeft: GetRandomPaddingText(1, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(1, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            var numDenTestData2 = numDenTestData1.Select(t =>
            (
                OpenPad: GetRandomPaddingText(1, 6),
                t.NumSign, t.NumNegative, t.NumZeroPad, t.ExpectedNum,
                t.PadSepLeft, t.Separator, t.PadSepRight,
                t.DenSign, t.DenNegative, t.DenZeroPad, t.ExpectedDen,
                ClosePad: GetRandomPaddingText(1, 6)
            ));
            if (!numDenTestData2.Any(t => t.OpenPad.Length == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!numDenTestData2.Any(t => t.OpenPad.Length > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!numDenTestData2.Any(t => t.ClosePad.Length == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: string.Empty
                ) });
            if (!numDenTestData2.Any(t => t.ClosePad.Length > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            if (!numDenTestData2.Any(t => t.OpenPad.Length == 0 && t.ClosePad.Length == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: string.Empty
                ) });
            if (!numDenTestData2.Any(t => t.OpenPad.Length > 0 && t.ClosePad.Length > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            foreach (var (sign, isNegative, zeroPad, expected) in wholeNumberTestData1)
            {
                var fStr = $"{sign}{zeroPad}{expected}";
                var result = Fraction.TryParseSimpleFraction(fStr.AsSpan(), style, provider, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualNumerator, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
                Assert.That(actualDenominator, Is.EqualTo(1), fStr);
            }
            foreach (var (openPad, sign, isNegative, zeroPad, expected, closePad) in wholeNumberTestData2)
            {
                var fStr = $"({openPad}{sign}{zeroPad}{expected}{closePad})";
                var result = Fraction.TryParseSimpleFraction(fStr.AsSpan(), style, provider, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualNumerator, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
                Assert.That(actualDenominator, Is.EqualTo(1), fStr);
            }
            foreach (var (numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen) in numDenTestData1)
            {
                var fStr = $"{numSign}{numZeroPad}{expectedNum}{padSepLeft}{separator}{padSepRight}{denSign}{denZeroPad}{expectedDen}";
                var result = Fraction.TryParseSimpleFraction(fStr.AsSpan(), style, provider, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
                Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
            }
            foreach (var (openPad, numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen, closePad) in numDenTestData2)
            {
                var fStr = $"({openPad}{numSign}{numZeroPad}{expectedNum}{padSepLeft}{separator}{padSepRight}{denSign}{denZeroPad}{expectedDen}{closePad})";
                var result = Fraction.TryParseSimpleFraction(fStr.AsSpan(), style, provider, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
                Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
            }
        }

        [Test]
        public void TryParseMixedFractionTest()
        {
            var separatorChars = new string[] { "∕", "/" };
            var signChars = new[]
            {
                (Sign: "", IsNegative: false),
                (Sign: "+", IsNegative: false),
                (Sign: "-", IsNegative: true),
                (Sign: "−", IsNegative: true)
            };
            var style = NumberStyles.AllowLeadingSign | NumberStyles.Integer;
            var provider = CultureInfo.CurrentCulture.NumberFormat;
            var wholeNumberTestData1 = signChars.Select(numSign => (numSign.Sign, numSign.IsNegative, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(1, 6, true)));
            if (!wholeNumberTestData1.Any(t => t.Expected == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0) });
            if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.Expected < 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(1, 1)) });
            if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.IsNegative)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { ("-", true, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(1, 1)) });
            if (!wholeNumberTestData1.Any(t => t.Expected > 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: GetRandomInteger(2, 6)) });
            if (!wholeNumberTestData1.Any(t => t.ZeroPad.Length == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: string.Empty, Expected: GetRandomInteger(1, 6, true)) });
            if (!wholeNumberTestData1.Any(t => t.ZeroPad.Length > 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: GetRandomZeroPad(1, 4), Expected: GetRandomInteger(1, 6, true)) });
            var wholeNumberTestData2 = wholeNumberTestData1.Select(t => (OpenPad: GetRandomPaddingText(0, 6), t.Sign, t.IsNegative, t.ZeroPad, t.Expected, ClosePad: GetRandomPaddingText(0, 6)));
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!wholeNumberTestData2.Any(t => t.ClosePad.Length == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: string.Empty
                ) });
            if (!wholeNumberTestData2.Any(t => t.ClosePad.Length > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length == 0 && t.ClosePad.Length == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: string.Empty
                ) });
            if (!wholeNumberTestData2.Any(t => t.OpenPad.Length > 0 && t.ClosePad.Length > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    string.Empty, false, ZeroPad: GetRandomZeroPad(-9, 4), Expected: 0,
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            var numDenTestData1 = signChars.SelectMany(numSign =>
                signChars.SelectMany(denSign =>
                    separatorChars.Select(s =>
                        (
                            NumSign: numSign.Sign, NumNegative: numSign.IsNegative, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                            PadSepLeft: GetRandomPaddingText(-6, 6),
                            Separator: s,
                            PadSepRight: GetRandomPaddingText(-6, 6),
                            DenSign: numSign.Sign, DenNegative: numSign.IsNegative, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                        )
                    )
                )
            );
            if (!numDenTestData1.Any(t => t.ExpectedNum == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: 0,
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.ExpectedNum > 1 && t.ExpectedNum < 10)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 1),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.ExpectedDen == 1)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: 1
                    )
                });
            if (!numDenTestData1.Any(t => t.ExpectedDen > 10)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(2, 6)
                    )
                });

            if (!numDenTestData1.Any(t => t.PadSepLeft.Length == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: string.Empty,
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepLeft.Length > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(1, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(-6, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepRight.Length == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: string.Empty,
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepRight.Length > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: GetRandomPaddingText(-6, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(1, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepLeft.Length == 0 && t.PadSepRight.Length == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6),
                        PadSepLeft: string.Empty,
                        Separator: separatorChars[0],
                        PadSepRight: string.Empty,
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            if (!numDenTestData1.Any(t => t.PadSepLeft.Length > 0 && t.PadSepRight.Length > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
                {
                    (
                        NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(2, 6),
                        PadSepLeft: GetRandomPaddingText(1, 6),
                        Separator: separatorChars[0],
                        PadSepRight: GetRandomPaddingText(1, 6),
                        DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                    )
                });
            var numDenTestData2 = numDenTestData1.Select(t =>
            (
                OpenPad: GetRandomPaddingText(1, 6),
                t.NumSign, t.NumNegative, t.NumZeroPad, t.ExpectedNum,
                t.PadSepLeft, t.Separator, t.PadSepRight,
                t.DenSign, t.DenNegative, t.DenZeroPad, t.ExpectedDen,
                ClosePad: GetRandomPaddingText(1, 6)
            ));
            if (!numDenTestData2.Any(t => t.OpenPad.Length == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!numDenTestData2.Any(t => t.OpenPad.Length > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(-6, 6)
                ) });
            if (!numDenTestData2.Any(t => t.ClosePad.Length == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: string.Empty
                ) });
            if (!numDenTestData2.Any(t => t.ClosePad.Length > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(-6, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            if (!numDenTestData2.Any(t => t.OpenPad.Length == 0 && t.ClosePad.Length == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: string.Empty,
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: string.Empty
                ) });
            if (!numDenTestData2.Any(t => t.OpenPad.Length > 0 && t.ClosePad.Length > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                    OpenPad: GetRandomPaddingText(1, 6),
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: GetRandomZeroPad(-9, 4), ExpectedNum: GetRandomInteger(1, 6, true),
                    PadSepLeft: string.Empty, Separator: separatorChars[0], string.Empty,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: GetRandomZeroPad(-9, 4), GetRandomInteger(1, 6),
                    ClosePad: GetRandomPaddingText(1, 6)
                ) });
            var mixedTestData1 = wholeNumberTestData1.SelectMany(w =>
                signChars.SelectMany(numSign =>
                    signChars.SelectMany(denSign =>
                        separatorChars.Select(s =>
                            (
                                WnSign: w.Sign, WnIsNegative: w.IsNegative, WnZeroPad: w.ZeroPad, ExpectedWn: w.Expected,
                                NumPadL: GetRandomPaddingText((numSign.Sign.Length > 0) ? -6 : 1, 6),
                                NumSign: numSign.Sign,
                                NumPadR: (numSign.Sign.Length > 0) ? GetRandomPaddingText(-6, 6) : string.Empty,
                                NumNegative: numSign.IsNegative, NumZeroPad: GetRandomZeroPad(-9, 4),
                                ExpectedNum: GetRandomInteger(1, 6, true),
                                PadSepLeft: GetRandomPaddingText(-6, 6),
                                Separator: s,
                                PadSepRight: GetRandomPaddingText(-6, 6),
                                DenSign: numSign.Sign, DenNegative: numSign.IsNegative, DenZeroPad: GetRandomZeroPad(-9, 4), ExpectedDen: GetRandomInteger(1, 6)
                            )
                        )
                    )
                )
            );
            var mixedTestData2 = mixedTestData1.Select(t =>
            (
                OpenPad: GetRandomPaddingText(1, 6),
                t.WnSign, t.WnIsNegative, t.WnZeroPad, t.ExpectedWn,
                t.NumPadL, t.NumSign, t.NumPadR, t.NumNegative, t.NumZeroPad, t.ExpectedNum,
                t.PadSepLeft, t.Separator, t.PadSepRight, t.DenSign, t.DenNegative, t.DenZeroPad, t.ExpectedDen,
                ClosePad: GetRandomPaddingText(1, 6)
            ));
            foreach (var (sign, isNegative, zeroPad, expected) in wholeNumberTestData1)
            {
                var fStr = $"{sign}{zeroPad}{expected}";
                var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualWholeNumber, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
                Assert.That(actualNumerator, Is.EqualTo(0), fStr);
                Assert.That(actualDenominator, Is.EqualTo(1), fStr);
            }
            foreach (var (openPad, sign, isNegative, zeroPad, expected, closePad) in wholeNumberTestData2)
            {
                var fStr = $"({openPad}{sign}{zeroPad}{expected}{closePad})";
                var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualWholeNumber, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
                Assert.That(actualNumerator, Is.EqualTo(0), fStr);
                Assert.That(actualDenominator, Is.EqualTo(1), fStr);
            }
            foreach (var (numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen) in numDenTestData1)
            {
                var fStr = $"{numSign}{numZeroPad}{expectedNum}{padSepLeft}{separator}{padSepRight}{denSign}{denZeroPad}{expectedDen}";
                var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualWholeNumber, Is.EqualTo(0), fStr);
                Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
                Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
            }
            foreach (var (openPad, numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen, closePad) in numDenTestData2)
            {
                var fStr = $"({openPad}{numSign}{numZeroPad}{expectedNum}{padSepLeft}{separator}{padSepRight}{denSign}{denZeroPad}{expectedDen}{closePad})";
                var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualWholeNumber, Is.EqualTo(0), fStr);
                Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
                Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
            }
            foreach (var (wnSign, wnIsNegative, wnZeroPad, wxpectedWn, numPadL, numSign, numPadR, numNegative, numZeroPad, expectedNum, padSepLeft, sep, padSepRight, denSign, denNegative, denZeroPad, expectedDen) in mixedTestData1)
            {
                var fStr = $"{wnSign}{wnZeroPad}{wxpectedWn}{numPadL}{numSign}{numPadR}{numZeroPad}{expectedNum}{padSepLeft}{sep}{padSepRight}{denSign}{denZeroPad}{expectedDen}";
                var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualWholeNumber, Is.EqualTo(0), fStr);
                Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
                Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
            }
            foreach (var (openPad, wnSign, wnIsNegative, wnZeroPad, wxpectedWn, numPadL, numSign, numPadR, numNegative, numZeroPad, expectedNum, padSepLeft, sep, padSepRight, denSign, denNegative, denZeroPad, expectedDen, closePad) in mixedTestData2)
            {
                var fStr = $"({openPad}{wnSign}{wnZeroPad}{wxpectedWn}{numPadL}{numSign}{numPadR}{numZeroPad}{expectedNum}{padSepLeft}{sep}{padSepRight}{denSign}{denZeroPad}{expectedDen}{closePad})";
                var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
                Assert.That(result, Is.True, fStr);
                Assert.That(actualWholeNumber, Is.EqualTo(0), fStr);
                Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
                Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
            }
        }

        [Test, Explicit]
        public void TryGetSimpleFractionTokensTest()
        {
            IEnumerable<string> getPadStrings()
            {
                yield return string.Empty;
                yield return " ";
                yield return "\t";
                yield return GetRandomPaddingText(2, 4);
            }
            foreach (var (sign, expectedNegative) in new[] { (string.Empty, false), ("+", false), ("-", true), ("−", true) })
            {
                var expectedNumerator = GetRandomZeroPad(1, 4);
                var fractionString = $"{sign}{expectedNumerator}";
                var returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out string? numerator, out string? denominator, out bool isNegative);
                Assert.Multiple(() =>
                {
                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                    Assert.That(numerator, Is.Not.Null, fractionString);
                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                    Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                    Assert.That(denominator, Is.Not.Null, fractionString);
                    Assert.That(denominator, Is.Empty);
                });
                expectedNumerator = GetRandomNumber(1, 1);
                fractionString = $"{sign}{expectedNumerator}";
                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                Assert.Multiple(() =>
                {
                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                    Assert.That(numerator, Is.Not.Null, fractionString);
                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                    Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                    Assert.That(denominator, Is.Not.Null, fractionString);
                    Assert.That(denominator, Is.Empty);
                });
                expectedNumerator = GetRandomNumber(2, 6);
                fractionString = $"{sign}{expectedNumerator}";
                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                Assert.Multiple(() =>
                {
                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                    Assert.That(numerator, Is.Not.Null, fractionString);
                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                    Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                    Assert.That(denominator, Is.Not.Null, fractionString);
                    Assert.That(denominator, Is.Empty);
                });
                foreach (var leftPad in getPadStrings())
                {
                    foreach (var rightPad in getPadStrings())
                    {
                        expectedNumerator = GetRandomZeroPad(1, 4);
                        fractionString = $"({leftPad}{sign}{expectedNumerator}{rightPad})";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.Empty);
                        });
                        expectedNumerator = GetRandomNumber(1, 1);
                        fractionString = $"({leftPad}{sign}{expectedNumerator}{rightPad})";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.Empty);
                        });
                        expectedNumerator = GetRandomNumber(2, 6);
                        fractionString = $"({leftPad}{sign}{expectedNumerator}{rightPad})";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.Empty);
                        });
                    }
                }
            }
            
            foreach (var (numeratorSign, expectedNumNegative) in new[] { (string.Empty, false), ("+", false), ("-", true), ("−", true) })
            {
                foreach (var (denominatorSign, expectedDenNegative) in new[] { (string.Empty, false), ("+", false), ("-", true), ("−", true) })
                {
                    foreach (string separator in new char[] { '∕', '/' }.SelectMany(c => getPadStrings().SelectMany(l => getPadStrings().Select(r => $"{l}{c}{r}"))))
                    {
                        var expectedNumerator = GetRandomZeroPad(1, 4);
                        var expectedDenominiator = GetRandomNumber(1, 1);
                        var fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                        var returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out string? numerator, out string? denominator, out bool isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                        });
                        
                        expectedDenominiator = GetRandomNumber(2, 6);
                        fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                        });

                        expectedNumerator = GetRandomNumber(1, 1);
                        expectedDenominiator = GetRandomNumber(1, 1);
                        fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                        });

                        expectedNumerator = GetRandomNumber(1, 1);
                        expectedDenominiator = GetRandomNumber(2, 6);
                        fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                        });

                        expectedNumerator = GetRandomNumber(2, 6);
                        expectedDenominiator = GetRandomNumber(1, 1);
                        fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                        });

                        expectedNumerator = GetRandomNumber(2, 6);
                        expectedDenominiator = GetRandomNumber(2, 6);
                        fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                        returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                        });

                        foreach (var leftPad in getPadStrings())
                        {
                            foreach (var rightPad in getPadStrings())
                            {
                                expectedNumerator = GetRandomZeroPad(1, 4);
                                expectedDenominiator = GetRandomNumber(1, 1);
                                fractionString = $"({leftPad}{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}{rightPad})";
                                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                                });

                                expectedDenominiator = GetRandomNumber(2, 6);
                                fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                                });

                                expectedNumerator = GetRandomNumber(1, 1);
                                expectedDenominiator = GetRandomNumber(1, 1);
                                fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                                });

                                expectedNumerator = GetRandomNumber(1, 1);
                                expectedDenominiator = GetRandomNumber(2, 6);
                                fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                                });

                                expectedNumerator = GetRandomNumber(2, 6);
                                expectedDenominiator = GetRandomNumber(1, 1);
                                fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                                });

                                expectedNumerator = GetRandomNumber(2, 6);
                                expectedDenominiator = GetRandomNumber(2, 6);
                                fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                                returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, expectedNumerator, fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                                });
                            }
                        }
                    }
                }
            }
        }

        [Test, Explicit]
        public void TryGetMixedFractionTokensTest()
        {
            IEnumerable<string> getPadStrings()
            {
                yield return string.Empty;
                yield return " ";
                yield return "\t";
                yield return GetRandomPaddingText(2, 4);
            }

            IEnumerable<(string Sign, string Expected, bool IsNegative)> getWholeNumberTests()
            {
                yield return (string.Empty, GetRandomNumber(1, 1), false);
                yield return (string.Empty, GetRandomNumber(2, 6), false);
                yield return ("+", GetRandomNumber(1, 1), false);
                yield return ("+", GetRandomNumber(2, 6), false);
                yield return ("-", GetRandomNumber(1, 1), true);
                yield return ("-", GetRandomNumber(2, 6), true);
                yield return ("−", GetRandomNumber(1, 1), true);
                yield return ("−", GetRandomNumber(2, 6), true);
            }
            
            IEnumerable<(string NumeratorSign, string ExpectedNumerator, string separator, string DenominatorSign, string ExpectedDenominator, bool IsNegative)> getSimpleFractionTests()
            {
                foreach (string separator in new char[] { '∕', '/' }.SelectMany(c => getPadStrings().SelectMany(l => getPadStrings().Select(r => $"{l}{c}{r}"))))
                {
                    yield return (string.Empty, "0", separator, string.Empty, GetRandomNumber(1, 1), false);
                    yield return (string.Empty, "0", separator, "+", GetRandomNumber(1, 1), false);
                    yield return (string.Empty, "0", separator, "-", GetRandomNumber(1, 1), true);
                    yield return (string.Empty, "0", separator, "−", GetRandomNumber(1, 1), true);

                    yield return (string.Empty, "0", separator, string.Empty, GetRandomNumber(2, 6), false);
                    yield return (string.Empty, "0", separator, "+", GetRandomNumber(2, 6), false);
                    yield return (string.Empty, "0", separator, "-", GetRandomNumber(2, 6), true);
                    yield return (string.Empty, "0", separator, "−", GetRandomNumber(2, 6), true);

                    yield return (string.Empty, GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(1, 1), false);
                    yield return (string.Empty, GetRandomNumber(1, 1), separator, "+", GetRandomNumber(1, 1), false);
                    yield return (string.Empty, GetRandomNumber(1, 1), separator, "-", GetRandomNumber(1, 1), true);
                    yield return (string.Empty, GetRandomNumber(1, 1), separator, "−", GetRandomNumber(1, 1), true);

                    yield return (string.Empty, GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(2, 6), false);
                    yield return (string.Empty, GetRandomNumber(1, 1), separator, "+", GetRandomNumber(2, 6), false);
                    yield return (string.Empty, GetRandomNumber(1, 1), separator, "-", GetRandomNumber(2, 6), true);
                    yield return (string.Empty, GetRandomNumber(1, 1), separator, "−", GetRandomNumber(2, 6), true);

                    yield return (string.Empty, GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(1, 1), false);
                    yield return (string.Empty, GetRandomNumber(2, 6), separator, "+", GetRandomNumber(1, 1), false);
                    yield return (string.Empty, GetRandomNumber(2, 6), separator, "-", GetRandomNumber(1, 1), true);
                    yield return (string.Empty, GetRandomNumber(2, 6), separator, "−", GetRandomNumber(1, 1), true);

                    yield return (string.Empty, GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(2, 6), false);
                    yield return (string.Empty, GetRandomNumber(2, 6), separator, "+", GetRandomNumber(2, 6), false);
                    yield return (string.Empty, GetRandomNumber(2, 6), separator, "-", GetRandomNumber(2, 6), true);
                    yield return (string.Empty, GetRandomNumber(2, 6), separator, "−", GetRandomNumber(2, 6), true);

                    yield return ("+", "0", separator, string.Empty, GetRandomNumber(1, 1), false);
                    yield return ("+", "0", separator, "+", GetRandomNumber(1, 1), false);
                    yield return ("+", "0", separator, "-", GetRandomNumber(1, 1), true);
                    yield return ("+", "0", separator, "−", GetRandomNumber(1, 1), true);

                    yield return ("+", "0", separator, string.Empty, GetRandomNumber(2, 6), false);
                    yield return ("+", "0", separator, "+", GetRandomNumber(2, 6), false);
                    yield return ("+", "0", separator, "-", GetRandomNumber(2, 6), true);
                    yield return ("+", "0", separator, "−", GetRandomNumber(2, 6), true);

                    yield return ("+", GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(1, 1), false);
                    yield return ("+", GetRandomNumber(1, 1), separator, "+", GetRandomNumber(1, 1), false);
                    yield return ("+", GetRandomNumber(1, 1), separator, "-", GetRandomNumber(1, 1), true);
                    yield return ("+", GetRandomNumber(1, 1), separator, "−", GetRandomNumber(1, 1), true);

                    yield return ("+", GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(2, 6), false);
                    yield return ("+", GetRandomNumber(1, 1), separator, "+", GetRandomNumber(2, 6), false);
                    yield return ("+", GetRandomNumber(1, 1), separator, "-", GetRandomNumber(2, 6), true);
                    yield return ("+", GetRandomNumber(1, 1), separator, "−", GetRandomNumber(2, 6), true);

                    yield return ("+", GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(1, 1), false);
                    yield return ("+", GetRandomNumber(2, 6), separator, "+", GetRandomNumber(1, 1), false);
                    yield return ("+", GetRandomNumber(2, 6), separator, "-", GetRandomNumber(1, 1), true);
                    yield return ("+", GetRandomNumber(2, 6), separator, "−", GetRandomNumber(1, 1), true);

                    yield return ("+", GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(2, 6), false);
                    yield return ("+", GetRandomNumber(2, 6), separator, "+", GetRandomNumber(2, 6), false);
                    yield return ("+", GetRandomNumber(2, 6), separator, "-", GetRandomNumber(2, 6), true);
                    yield return ("+", GetRandomNumber(2, 6), separator, "−", GetRandomNumber(2, 6), true);

                    yield return ("-", "0", separator, string.Empty, GetRandomNumber(1, 1), true);
                    yield return ("-", "0", separator, "+", GetRandomNumber(1, 1), true);
                    yield return ("-", "0", separator, "-", GetRandomNumber(1, 1), false);
                    yield return ("-", "0", separator, "−", GetRandomNumber(1, 1), false);

                    yield return ("-", "0", separator, string.Empty, GetRandomNumber(2, 6), true);
                    yield return ("-", "0", separator, "+", GetRandomNumber(2, 6), true);
                    yield return ("-", "0", separator, "-", GetRandomNumber(2, 6), false);
                    yield return ("-", "0", separator, "−", GetRandomNumber(2, 6), false);

                    yield return ("-", GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(1, 1), true);
                    yield return ("-", GetRandomNumber(1, 1), separator, "+", GetRandomNumber(1, 1), true);
                    yield return ("-", GetRandomNumber(1, 1), separator, "-", GetRandomNumber(1, 1), false);
                    yield return ("-", GetRandomNumber(1, 1), separator, "−", GetRandomNumber(1, 1), false);

                    yield return ("-", GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(2, 6), true);
                    yield return ("-", GetRandomNumber(1, 1), separator, "+", GetRandomNumber(2, 6), true);
                    yield return ("-", GetRandomNumber(1, 1), separator, "-", GetRandomNumber(2, 6), false);
                    yield return ("-", GetRandomNumber(1, 1), separator, "−", GetRandomNumber(2, 6), false);

                    yield return ("-", GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(1, 1), true);
                    yield return ("-", GetRandomNumber(2, 6), separator, "+", GetRandomNumber(1, 1), true);
                    yield return ("-", GetRandomNumber(2, 6), separator, "-", GetRandomNumber(1, 1), false);
                    yield return ("-", GetRandomNumber(2, 6), separator, "−", GetRandomNumber(1, 1), false);

                    yield return ("-", GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(2, 6), true);
                    yield return ("-", GetRandomNumber(2, 6), separator, "+", GetRandomNumber(2, 6), true);
                    yield return ("-", GetRandomNumber(2, 6), separator, "-", GetRandomNumber(2, 6), false);
                    yield return ("-", GetRandomNumber(2, 6), separator, "−", GetRandomNumber(2, 6), false);

                    yield return ("−", "0", separator, string.Empty, GetRandomNumber(1, 1), true);
                    yield return ("−", "0", separator, "+", GetRandomNumber(1, 1), true);
                    yield return ("−", "0", separator, "-", GetRandomNumber(1, 1), false);
                    yield return ("−", "0", separator, "−", GetRandomNumber(1, 1), false);

                    yield return ("−", "0", separator, string.Empty, GetRandomNumber(2, 6), true);
                    yield return ("−", "0", separator, "+", GetRandomNumber(2, 6), true);
                    yield return ("−", "0", separator, "-", GetRandomNumber(2, 6), false);
                    yield return ("−", "0", separator, "−", GetRandomNumber(2, 6), false);

                    yield return ("−", GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(1, 1), true);
                    yield return ("−", GetRandomNumber(1, 1), separator, "+", GetRandomNumber(1, 1), true);
                    yield return ("−", GetRandomNumber(1, 1), separator, "-", GetRandomNumber(1, 1), false);
                    yield return ("−", GetRandomNumber(1, 1), separator, "−", GetRandomNumber(1, 1), false);

                    yield return ("−", GetRandomNumber(1, 1), separator, string.Empty, GetRandomNumber(2, 6), true);
                    yield return ("−", GetRandomNumber(1, 1), separator, "+", GetRandomNumber(2, 6), true);
                    yield return ("−", GetRandomNumber(1, 1), separator, "-", GetRandomNumber(2, 6), false);
                    yield return ("−", GetRandomNumber(1, 1), separator, "−", GetRandomNumber(2, 6), false);

                    yield return ("−", GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(1, 1), true);
                    yield return ("−", GetRandomNumber(2, 6), separator, "+", GetRandomNumber(1, 1), true);
                    yield return ("−", GetRandomNumber(2, 6), separator, "-", GetRandomNumber(1, 1), false);
                    yield return ("−", GetRandomNumber(2, 6), separator, "−", GetRandomNumber(1, 1), false);

                    yield return ("−", GetRandomNumber(2, 6), separator, string.Empty, GetRandomNumber(2, 6), true);
                    yield return ("−", GetRandomNumber(2, 6), separator, "+", GetRandomNumber(2, 6), true);
                    yield return ("−", GetRandomNumber(2, 6), separator, "-", GetRandomNumber(2, 6), false);
                    yield return ("−", GetRandomNumber(2, 6), separator, "−", GetRandomNumber(2, 6), false);
                }
            }
            
            foreach (var (wholeNumberSign, expectedWholeNumber, expectedNegative1) in getWholeNumberTests())
            {
                var fractionString = $"{wholeNumberSign}{expectedWholeNumber}";
                var returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out string? wholeNumber, out string? numerator, out string? denominator, out bool isNegative);
                Assert.Multiple(() =>
                {
                    Assert.That(returnValue, Is.True, fractionString);
                    Assert.That(wholeNumber, Is.Not.Null, fractionString);
                    Assert.That(wholeNumber, Is.EqualTo(expectedWholeNumber), fractionString);
                    Assert.That(isNegative, Is.EqualTo(expectedNegative1), fractionString);
                    Assert.That(numerator, Is.Not.Null, fractionString);
                    Assert.That(numerator, Is.Empty, fractionString);
                    Assert.That(denominator, Is.Not.Null, fractionString);
                    Assert.That(denominator, Is.Empty, fractionString);
                });
                foreach (var leftPad in getPadStrings())
                {
                    foreach (var rightPad in getPadStrings())
                    {
                        fractionString = $"({leftPad}{wholeNumberSign}{expectedWholeNumber}{rightPad})";
                        returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, fractionString);
                            Assert.That(wholeNumber, Is.Not.Null, fractionString);
                            Assert.That(wholeNumber, Is.EqualTo(expectedWholeNumber), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNegative1), fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.Empty, fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.Empty, fractionString);
                        });
                    }
                }
                foreach (var (numeratorSign, expectedNumerator, separator, denominatorSign, expectedDenominiator, expectedNegative2) in getSimpleFractionTests())
                {
                    if (numeratorSign.Length > 0)
                    {
                        foreach (var beforeNumSign in getPadStrings())
                        {
                            foreach (var afterNumSign in getPadStrings())
                            {
                                fractionString = $"{wholeNumberSign}{expectedWholeNumber}{beforeNumSign}{numeratorSign}{afterNumSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                                returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, fractionString);
                                    Assert.That(wholeNumber, Is.Not.Null, fractionString);
                                    Assert.That(wholeNumber, Is.EqualTo(expectedWholeNumber), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNegative1 != expectedNegative2), fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                });
                                foreach (var leftPad in getPadStrings())
                                {
                                    foreach (var rightPad in getPadStrings())
                                    {
                                        fractionString = $"({leftPad}{wholeNumberSign}{expectedWholeNumber}{beforeNumSign}{numeratorSign}{afterNumSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}{rightPad})";
                                        returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
                                        Assert.Multiple(() =>
                                        {
                                            Assert.That(returnValue, Is.True, fractionString);
                                            Assert.That(wholeNumber, Is.Not.Null, fractionString);
                                            Assert.That(wholeNumber, Is.EqualTo(expectedWholeNumber), fractionString);
                                            Assert.That(isNegative, Is.EqualTo(expectedNegative1 != expectedNegative2), fractionString);
                                            Assert.That(numerator, Is.Not.Null, fractionString);
                                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                            Assert.That(denominator, Is.Not.Null, fractionString);
                                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                        });
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        fractionString = $"{wholeNumberSign}{expectedWholeNumber}{GetRandomPaddingText(1, 6)}{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                        returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, fractionString);
                            Assert.That(wholeNumber, Is.Not.Null, fractionString);
                            Assert.That(wholeNumber, Is.EqualTo(expectedWholeNumber), fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNegative1 != expectedNegative2), fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                        });
                        foreach (var leftPad in getPadStrings())
                        {
                            foreach (var rightPad in getPadStrings())
                            {
                                fractionString = $"({leftPad}{wholeNumberSign}{expectedWholeNumber}{GetRandomPaddingText(1, 6)}{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}{rightPad})";
                                returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
                                Assert.Multiple(() =>
                                {
                                    Assert.That(returnValue, Is.True, fractionString);
                                    Assert.That(wholeNumber, Is.Not.Null, fractionString);
                                    Assert.That(wholeNumber, Is.EqualTo(expectedWholeNumber), fractionString);
                                    Assert.That(isNegative, Is.EqualTo(expectedNegative1 != expectedNegative2), fractionString);
                                    Assert.That(numerator, Is.Not.Null, fractionString);
                                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                    Assert.That(denominator, Is.Not.Null, fractionString);
                                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                });
                            }
                        }
                    }
                }
            }
            foreach (var (numeratorSign, expectedNumerator, separator, denominatorSign, expectedDenominiator, expectedNegative) in getSimpleFractionTests())
            {
                var fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                var returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out string? wholeNumber, out string? numerator, out string? denominator, out bool isNegative);
                Assert.Multiple(() =>
                {
                    Assert.That(returnValue, Is.True, fractionString);
                    Assert.That(wholeNumber, Is.Not.Null, fractionString);
                    Assert.That(wholeNumber, Is.Empty, fractionString);
                    Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                    Assert.That(numerator, Is.Not.Null, fractionString);
                    Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                    Assert.That(denominator, Is.Not.Null, fractionString);
                    Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                });
                foreach (var leftPad in getPadStrings())
                {
                    foreach (var rightPad in getPadStrings())
                    {
                        fractionString = $"({leftPad}{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}{rightPad})";
                        returnValue = Fraction.TryGetMixedFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
                        Assert.Multiple(() =>
                        {
                            Assert.That(returnValue, Is.True, fractionString);
                            Assert.That(wholeNumber, Is.Not.Null, fractionString);
                            Assert.That(wholeNumber, Is.Empty, fractionString);
                            Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                            Assert.That(numerator, Is.Not.Null, fractionString);
                            Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                            Assert.That(denominator, Is.Not.Null, fractionString);
                            Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                        });
                    }
                }
            }
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetSimplifiedRationalTestData))]
        public (int Numerator, int Denominator) GetSimplifiedRationalTest(int numerator, int denominator)
        {
            numerator = Fraction.GetSimplifiedRational(numerator, denominator, out denominator);
            return (numerator, denominator);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetToCommonDenominatorTestData))]
        public (int N1, int D1, int N2, int D2) ToCommonDenominatorTest(int n1, int d1, int n2, int d2)
        {
            Fraction.ToCommonDenominator(ref n1, ref d1, ref n2, ref d2);
            return (n1, d1, n2, d2);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetGCDTestTestData))]
        public int GetGCDTest(int d1, int d2)
        {
            return Fraction.GetGCD(d1, d2);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetLCMTestData))]
        public int GetLCMTest(int d1, int d2)
        {
            return Fraction.GetLCM(d1, d2);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetGetProperRationalTestData))]
        public (int WholeNumber, int Numerator) GetProperRationalTest(int wholeNumber, int numerator, int denominator)
        {
            wholeNumber = Fraction.GetProperRational(wholeNumber, numerator, denominator, out numerator);
            return (wholeNumber, numerator);
        }

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
}