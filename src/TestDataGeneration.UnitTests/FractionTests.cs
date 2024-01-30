using System.Globalization;
using TestDataGeneration.Numerics;
using static TestDataGeneration.UnitTests.HelperMethods;

namespace TestDataGeneration.UnitTests;

public partial class FractionTests
{
    private Random _random;

    [SetUp]
    public void Setup()
    {
        _random = new();
    }

    [Test]
    public void TryMatchWhiteSpaceTest()
    {
        ReadOnlySpan<char> s = " ".AsSpan();
        var returnValue = s.TryMatchWhiteSpace(out int result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = " \t ".AsSpan();
        returnValue = s.TryMatchWhiteSpace(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(3));

        s = " test  ".AsSpan();
        returnValue = s.TryMatchWhiteSpace(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = ReadOnlySpan<char>.Empty;
        returnValue = s.TryMatchWhiteSpace(out result);
        Assert.That(returnValue, Is.False);

        s = "test  ".AsSpan();
        returnValue = s.TryMatchWhiteSpace(out result);
        Assert.That(returnValue, Is.False);
    }

    [Test]
    public void TryMatchDigitsTest()
    {
        ReadOnlySpan<char> s = "0".AsSpan();
        var returnValue = s.TryMatchDigits(out int result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "123".AsSpan();
        returnValue = s.TryMatchDigits(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(3));

        s = "1A2B".AsSpan();
        returnValue = s.TryMatchDigits(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = ReadOnlySpan<char>.Empty;
        returnValue = s.TryMatchDigits(out result);
        Assert.That(returnValue, Is.False);

        s = "A123".AsSpan();
        returnValue = s.TryMatchDigits(out result);
        Assert.That(returnValue, Is.False);
    }

    [Test]
    public void TryMatchSeparatorTest()
    {
        ReadOnlySpan<char> s = "∕".AsSpan();
        var returnValue = s.TryMatchSeparator(out int result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "/".AsSpan();
        returnValue = s.TryMatchSeparator(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "∕3".AsSpan();
        returnValue = s.TryMatchSeparator(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "/3".AsSpan();
        returnValue = s.TryMatchSeparator(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "∕/3".AsSpan();
        returnValue = s.TryMatchSeparator(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "\\∕/".AsSpan();
        returnValue = s.TryMatchSeparator(out result);
        Assert.That(returnValue, Is.False);
    }

    [Test]
    public void TryMatchOtherTest()
    {
        ReadOnlySpan<char> s = "+".AsSpan();
        var returnValue = s.TryMatchOther(out int result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "−".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "-".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "−-+".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(3));

        s = "−3".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "-3".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "+".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(1));

        s = "−-+3".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(3));

        s = "∕−/-+".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.False);
    }

    [Test]
    public void TryMatchGroupTest()
    {
        ReadOnlySpan<char> s = "()".AsSpan();
        var returnValue = s.TryMatchGroup(out int result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(2));

        s = "(12)".AsSpan();
        returnValue = s.TryMatchGroup(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(4));

        s = "(5)/(4)".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(3));

        s = "((5)/(4))".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(9));

        s = " (12)".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.False);

        s = "((5)/(4)".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.False);

        s = "((5/(4))".AsSpan();
        returnValue = s.TryMatchOther(out result);
        Assert.That(returnValue, Is.False);
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
        var wholeNumberTestData1 = signChars.Select(numSign => (numSign.Sign, numSign.IsNegative, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(1, 6)));
        if (!wholeNumberTestData1.Any(t => t.Expected == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0) });
        if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.Expected < 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(1, 1, true)) });
        if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.IsNegative)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { ("-", true, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(1, 1, true)) });
        if (!wholeNumberTestData1.Any(t => t.Expected > 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(2, 6, true)) });
        if (!wholeNumberTestData1.Any(t => t.ZeroPad == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: 0, Expected: GetRandomIntByLength(1, 6)) });
        if (!wholeNumberTestData1.Any(t => t.ZeroPad > 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (string.Empty, false, ZeroPad: SharedRandom.Next(1, 4), Expected: GetRandomIntByLength(1, 6)) });
        var wholeNumberTestData2 = wholeNumberTestData1.Select(t => (OpenPad: SharedRandom.Next(0, 6), t.Sign, t.IsNegative, t.ZeroPad, t.Expected, ClosePad: SharedRandom.Next(0, 6)));
        if (!wholeNumberTestData2.Any(t => t.OpenPad == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: 0,
                string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!wholeNumberTestData2.Any(t => t.OpenPad > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!wholeNumberTestData2.Any(t => t.ClosePad == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: 0
            ) });
        if (!wholeNumberTestData2.Any(t => t.ClosePad > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        if (!wholeNumberTestData2.Any(t => t.OpenPad == 0 && t.ClosePad == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: 0,
                string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: 0
            ) });
        if (!wholeNumberTestData2.Any(t => t.OpenPad > 0 && t.ClosePad > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                string.Empty, false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        var numDenTestData1 = signChars.SelectMany(numSign =>
            signChars.SelectMany(denSign =>
                separatorChars.Select(s =>
                    (
                        NumSign: numSign.Sign, NumNegative: numSign.IsNegative, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                        PadSepLeft: SharedRandom.Next(-6, 6),
                        Separator: s,
                        PadSepRight: SharedRandom.Next(-6, 6),
                        DenSign: numSign.Sign, DenNegative: numSign.IsNegative, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                    )
                )
            )
        );
        if (!numDenTestData1.Any(t => t.ExpectedNum == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: 0,
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.ExpectedNum > 1 && t.ExpectedNum < 10)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 1, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.ExpectedDen == 1)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: 1
                )
            });
        if (!numDenTestData1.Any(t => t.ExpectedDen > 10)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(2, 6, true)
                )
            });

        if (!numDenTestData1.Any(t => t.PadSepLeft == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: 0,
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepLeft > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(1, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepRight == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: 0,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepRight > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(1, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepLeft == 0 && t.PadSepRight == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: 0,
                    Separator: separatorChars[0],
                    PadSepRight: 0,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepLeft > 0 && t.PadSepRight > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(2, 6, true),
                    PadSepLeft: SharedRandom.Next(1, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(1, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        var numDenTestData2 = numDenTestData1.Select(t =>
        (
            OpenPad: SharedRandom.Next(1, 6),
            t.NumSign, t.NumNegative, t.NumZeroPad, t.ExpectedNum,
            t.PadSepLeft, t.Separator, t.PadSepRight,
            t.DenSign, t.DenNegative, t.DenZeroPad, t.ExpectedDen,
            ClosePad: SharedRandom.Next(1, 6)
        ));
        if (!numDenTestData2.Any(t => t.OpenPad == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: 0,
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!numDenTestData2.Any(t => t.OpenPad > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!numDenTestData2.Any(t => t.ClosePad == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: 0
            ) });
        if (!numDenTestData2.Any(t => t.ClosePad > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        if (!numDenTestData2.Any(t => t.OpenPad == 0 && t.ClosePad == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: 0,
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: 0
            ) });
        if (!numDenTestData2.Any(t => t.OpenPad > 0 && t.ClosePad > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        var wsChars = "      \t";
        foreach (var (sign, isNegative, zeroPad, expected) in wholeNumberTestData1)
        {
            var fStr = $"{sign}{new string('0', zeroPad)}{expected}";
            var result = Fraction.TryParseSimpleFraction(fStr.AsSpan(), style, provider, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualNumerator, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
            Assert.That(actualDenominator, Is.EqualTo(1), fStr);
        }
        foreach (var (openPad, sign, isNegative, zeroPad, expected, closePad) in wholeNumberTestData2)
        {
            var fStr = $"({GetRandomString(openPad, wsChars)}{sign}{new string('0', zeroPad)}{expected}{GetRandomString(closePad, wsChars)})";
            var result = Fraction.TryParseSimpleFraction(fStr.AsSpan(), style, provider, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualNumerator, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
            Assert.That(actualDenominator, Is.EqualTo(1), fStr);
        }
        foreach (var (numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen) in numDenTestData1)
        {
            var fStr = $"{numSign}{new string('0', numZeroPad)}{expectedNum}{GetRandomString(padSepLeft, wsChars)}{separator}{GetRandomString(padSepRight, wsChars)}{denSign}{new string('0', denZeroPad)}{expectedDen}";
            var result = Fraction.TryParseSimpleFraction(fStr.AsSpan(), style, provider, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
            Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
        }
        foreach (var (openPad, numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen, closePad) in numDenTestData2)
        {
            var fStr = $"({GetRandomString(openPad, wsChars)}{numSign}{new string('0', numZeroPad)}{expectedNum}{GetRandomString(padSepLeft, wsChars)}{separator}{GetRandomString(padSepRight, wsChars)}{denSign}{new string('0', denZeroPad)}{expectedDen}{GetRandomString(closePad, wsChars)})";
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
        var wholeNumberTestData1 = signChars.Select(numSign => (numSign.Sign, numSign.IsNegative, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(1, 6)));
        if (!wholeNumberTestData1.Any(t => t.Expected == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0) });
        if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.Expected < 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(1, 1, true)) });
        if (!wholeNumberTestData1.Any(t => t.Expected > 1 && t.IsNegative)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (Sign: "-", IsNegative: true, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(1, 1, true)) });
        if (!wholeNumberTestData1.Any(t => t.Expected > 10)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: GetRandomIntByLength(2, 6, true)) });
        if (!wholeNumberTestData1.Any(t => t.ZeroPad == 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (Sign: string.Empty, IsNegative: false, ZeroPad: 0, Expected: GetRandomIntByLength(1, 6)) });
        if (!wholeNumberTestData1.Any(t => t.ZeroPad > 0)) wholeNumberTestData1 = wholeNumberTestData1.Concat(new[] { (Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(1, 4), Expected: GetRandomIntByLength(1, 6)) });
        var wholeNumberTestData2 = wholeNumberTestData1.Select(t => (OpenPad: SharedRandom.Next(0, 6), t.Sign, t.IsNegative, t.ZeroPad, t.Expected, ClosePad: SharedRandom.Next(0, 6)));
        if (!wholeNumberTestData2.Any(t => t.OpenPad == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: 0,
                Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!wholeNumberTestData2.Any(t => t.OpenPad > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!wholeNumberTestData2.Any(t => t.ClosePad == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: 0
            ) });
        if (!wholeNumberTestData2.Any(t => t.ClosePad > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        if (!wholeNumberTestData2.Any(t => t.OpenPad == 0 && t.ClosePad == 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: 0,
                Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: 0
            ) });
        if (!wholeNumberTestData2.Any(t => t.OpenPad > 0 && t.ClosePad > 0)) wholeNumberTestData2 = wholeNumberTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                Sign: string.Empty, IsNegative: false, ZeroPad: SharedRandom.Next(-9, 4), Expected: 0,
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        var numDenTestData1 = signChars.SelectMany(numSign =>
            signChars.SelectMany(denSign =>
                separatorChars.Select(s =>
                    (
                        NumSign: numSign.Sign, NumNegative: numSign.IsNegative, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                        PadSepLeft: SharedRandom.Next(-6, 6),
                        Separator: s,
                        PadSepRight: SharedRandom.Next(-6, 6),
                        DenSign: numSign.Sign, DenNegative: numSign.IsNegative, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                    )
                )
            )
        );
        if (!numDenTestData1.Any(t => t.ExpectedNum == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: 0,
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.ExpectedNum > 1 && t.ExpectedNum < 10)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 1, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.ExpectedDen == 1)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: 1
                )
            });
        if (!numDenTestData1.Any(t => t.ExpectedDen > 10)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(2, 6, true)
                )
            });

        if (!numDenTestData1.Any(t => t.PadSepLeft == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: 0,
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepLeft > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(1, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(-6, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepRight == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: 0,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepRight > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: SharedRandom.Next(-6, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(1, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepLeft == 0 && t.PadSepRight == 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6, true),
                    PadSepLeft: 0,
                    Separator: separatorChars[0],
                    PadSepRight: 0,
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        if (!numDenTestData1.Any(t => t.PadSepLeft > 0 && t.PadSepRight > 0)) numDenTestData1 = numDenTestData1.Concat(new[]
            {
                (
                    NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(2, 6, true),
                    PadSepLeft: SharedRandom.Next(1, 6),
                    Separator: separatorChars[0],
                    PadSepRight: SharedRandom.Next(1, 6),
                    DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                )
            });
        var numDenTestData2 = numDenTestData1.Select(t =>
        (
            OpenPad: SharedRandom.Next(1, 6),
            t.NumSign, t.NumNegative, t.NumZeroPad, t.ExpectedNum,
            t.PadSepLeft, t.Separator, t.PadSepRight,
            t.DenSign, t.DenNegative, t.DenZeroPad, t.ExpectedDen,
            ClosePad: SharedRandom.Next(1, 6)
        ));
        if (!numDenTestData2.Any(t => t.OpenPad == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: 0,
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!numDenTestData2.Any(t => t.OpenPad > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(-6, 6)
            ) });
        if (!numDenTestData2.Any(t => t.ClosePad == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: 0
            ) });
        if (!numDenTestData2.Any(t => t.ClosePad > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(-6, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        if (!numDenTestData2.Any(t => t.OpenPad == 0 && t.ClosePad == 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: 0,
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: 0
            ) });
        if (!numDenTestData2.Any(t => t.OpenPad > 0 && t.ClosePad > 0)) numDenTestData2 = numDenTestData2.Concat(new[] { (
                OpenPad: SharedRandom.Next(1, 6),
                NumSign: string.Empty, NumNegative: false, NumZeroPad: SharedRandom.Next(-9, 4), ExpectedNum: GetRandomIntByLength(1, 6),
                PadSepLeft: 0, Separator: separatorChars[0], PadSepRight: 0,
                DenSign: string.Empty, DenNegative: false, DenZeroPad: SharedRandom.Next(-9, 4), GetRandomIntByLength(1, 6, true),
                ClosePad: SharedRandom.Next(1, 6)
            ) });
        var mixedTestData1 = wholeNumberTestData1.SelectMany(w =>
            signChars.SelectMany(numSign =>
                signChars.SelectMany(denSign =>
                    separatorChars.Select(s =>
                        (
                            WnSign: w.Sign, WnIsNegative: w.IsNegative, WnZeroPad: w.ZeroPad, ExpectedWn: w.Expected,
                            NumPadL: SharedRandom.Next((numSign.Sign.Length > 0) ? -6 : 1, 6),
                            NumSign: numSign.Sign,
                            NumPadR: (numSign.Sign.Length > 0) ? SharedRandom.Next(-6, 6) : 0,
                            NumNegative: numSign.IsNegative, NumZeroPad: SharedRandom.Next(-9, 4),
                            ExpectedNum: GetRandomIntByLength(1, 6),
                            PadSepLeft: SharedRandom.Next(-6, 6),
                            Separator: s,
                            PadSepRight: SharedRandom.Next(-6, 6),
                            DenSign: numSign.Sign, DenNegative: numSign.IsNegative, DenZeroPad: SharedRandom.Next(-9, 4), ExpectedDen: GetRandomIntByLength(1, 6, true)
                        )
                    )
                )
            )
        );
        var mixedTestData2 = mixedTestData1.Select(t =>
        (
            OpenPad: SharedRandom.Next(1, 6),
            t.WnSign, t.WnIsNegative, t.WnZeroPad, t.ExpectedWn,
            t.NumPadL, t.NumSign, t.NumPadR, t.NumNegative, t.NumZeroPad, t.ExpectedNum,
            t.PadSepLeft, t.Separator, t.PadSepRight, t.DenSign, t.DenNegative, t.DenZeroPad, t.ExpectedDen,
            ClosePad: SharedRandom.Next(1, 6)
        ));
        var wsChars = "      \t";
        foreach (var (sign, isNegative, zeroPad, expected) in wholeNumberTestData1)
        {
            var fStr = $"{sign}{new string('0', zeroPad)}{expected}";
            var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualWholeNumber, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
            Assert.That(actualNumerator, Is.EqualTo(0), fStr);
            Assert.That(actualDenominator, Is.EqualTo(1), fStr);
        }
        foreach (var (openPad, sign, isNegative, zeroPad, expected, closePad) in wholeNumberTestData2)
        {
            var fStr = $"({GetRandomString(openPad, wsChars)}{sign}{new string('0', zeroPad)}{expected}{GetRandomString(closePad, wsChars)})";
            var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualWholeNumber, Is.EqualTo(isNegative ? expected * -1 : expected), fStr);
            Assert.That(actualNumerator, Is.EqualTo(0), fStr);
            Assert.That(actualDenominator, Is.EqualTo(1), fStr);
        }
        foreach (var (numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen) in numDenTestData1)
        {
            var fStr = $"{numSign}{new string('0', numZeroPad)}{expectedNum}{GetRandomString(padSepLeft, wsChars)}{separator}{GetRandomString(padSepRight, wsChars)}{denSign}{new string('0', denZeroPad)}{expectedDen}";
            var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualWholeNumber, Is.EqualTo(0), fStr);
            Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
            Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
        }
        foreach (var (openPad, numSign, numNegative, numZeroPad, expectedNum, padSepLeft, separator, padSepRight, denSign, denNegative, denZeroPad, expectedDen, closePad) in numDenTestData2)
        {
            var fStr = $"({GetRandomString(openPad, wsChars)}{numSign}{new string('0', numZeroPad)}{expectedNum}{GetRandomString(padSepLeft, wsChars)}{separator}{GetRandomString(padSepRight, wsChars)}{denSign}{new string('0', denZeroPad)}{expectedDen}{GetRandomString(closePad, wsChars)})";
            var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualWholeNumber, Is.EqualTo(0), fStr);
            Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
            Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
        }
        foreach (var (wnSign, wnIsNegative, wnZeroPad, wxpectedWn, numPadL, numSign, numPadR, numNegative, numZeroPad, expectedNum, padSepLeft, sep, padSepRight, denSign, denNegative, denZeroPad, expectedDen) in mixedTestData1)
        {
            var fStr = $"{wnSign}{wnZeroPad}{wxpectedWn}{numPadL}{numSign}{numPadR}{new string('0', numZeroPad)}{expectedNum}{GetRandomString(padSepLeft, wsChars)}{sep}{GetRandomString(padSepRight, wsChars)}{denSign}{new string('0', denZeroPad)}{expectedDen}";
            var result = Fraction.TryParseMixedFraction(fStr.AsSpan(), style, provider, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
            Assert.That(result, Is.True, fStr);
            Assert.That(actualWholeNumber, Is.EqualTo(0), fStr);
            Assert.That(actualNumerator, Is.EqualTo(numNegative ? expectedNum * -1 : expectedNum), fStr);
            Assert.That(actualDenominator, Is.EqualTo(denNegative ? expectedDen * -1 : expectedDen), fStr);
        }
        foreach (var (openPad, wnSign, wnIsNegative, wnZeroPad, wxpectedWn, numPadL, numSign, numPadR, numNegative, numZeroPad, expectedNum, padSepLeft, sep, padSepRight, denSign, denNegative, denZeroPad, expectedDen, closePad) in mixedTestData2)
        {
            var fStr = $"({GetRandomString(openPad, wsChars)}{wnSign}{wnZeroPad}{wxpectedWn}{numPadL}{numSign}{numPadR}{new string('0', numZeroPad)}{expectedNum}{GetRandomString(padSepLeft, wsChars)}{sep}{GetRandomString(padSepRight, wsChars)}{denSign}{new string('0', denZeroPad)}{expectedDen}{GetRandomString(closePad, wsChars)})";
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
        var wsChars = "      \t";
        IEnumerable<string> getPadStrings()
        {
            yield return string.Empty;
            yield return " ";
            yield return "\t";
            yield return GetRandomString(2, 4, wsChars);
        }
        foreach (var (sign, expectedNegative) in new[] { (string.Empty, false), ("+", false), ("-", true), ("−", true) })
        {
            var expectedNumerator = GetRandomIntByLength(1, 4).ToString();
            var fractionString = $"{sign}{expectedNumerator}";
            var returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out string? numerator, out string? denominator, out bool isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(returnValue, Is.True, fractionString);
                Assert.That(numerator, Is.Not.Null, fractionString);
                Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                Assert.That(denominator, Is.Not.Null, fractionString);
                Assert.That(denominator, Is.Empty);
            });
            expectedNumerator = GetRandomIntByLength(1, 1).ToString();
            fractionString = $"{sign}{expectedNumerator}";
            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(returnValue, Is.True, fractionString);
                Assert.That(numerator, Is.Not.Null, fractionString);
                Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                Assert.That(denominator, Is.Not.Null, fractionString);
                Assert.That(denominator, Is.Empty);
            });
            expectedNumerator = GetRandomIntByLength(2, 6).ToString();
            fractionString = $"{sign}{expectedNumerator}";
            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(returnValue, Is.True, fractionString);
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
                    expectedNumerator = GetRandomIntByLength(1, 4).ToString();
                    fractionString = $"({leftPad}{sign}{expectedNumerator}{rightPad})";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
                        Assert.That(numerator, Is.Not.Null, fractionString);
                        Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                        Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                        Assert.That(denominator, Is.Not.Null, fractionString);
                        Assert.That(denominator, Is.Empty);
                    });
                    expectedNumerator = GetRandomIntByLength(1, 1).ToString();
                    fractionString = $"({leftPad}{sign}{expectedNumerator}{rightPad})";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
                        Assert.That(numerator, Is.Not.Null, fractionString);
                        Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                        Assert.That(isNegative, Is.EqualTo(expectedNegative), fractionString);
                        Assert.That(denominator, Is.Not.Null, fractionString);
                        Assert.That(denominator, Is.Empty);
                    });
                    expectedNumerator = GetRandomIntByLength(2, 6).ToString();
                    fractionString = $"({leftPad}{sign}{expectedNumerator}{rightPad})";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
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
                    var expectedNumerator = GetRandomIntByLength(1, 4).ToString();
                    var expectedDenominiator = GetRandomIntByLength(1, 1).ToString();
                    var fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                    var returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out string? numerator, out string? denominator, out bool isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
                        Assert.That(numerator, Is.Not.Null, fractionString);
                        Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                        Assert.That(denominator, Is.Not.Null, fractionString);
                        Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                        Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                    });
                    
                    expectedDenominiator = GetRandomIntByLength(2, 6).ToString();
                    fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
                        Assert.That(numerator, Is.Not.Null, fractionString);
                        Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                        Assert.That(denominator, Is.Not.Null, fractionString);
                        Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                        Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                    });

                    expectedNumerator = GetRandomIntByLength(1, 1).ToString();
                    expectedDenominiator = GetRandomIntByLength(1, 1).ToString();
                    fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
                        Assert.That(numerator, Is.Not.Null, fractionString);
                        Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                        Assert.That(denominator, Is.Not.Null, fractionString);
                        Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                        Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                    });

                    expectedNumerator = GetRandomIntByLength(1, 1).ToString();
                    expectedDenominiator = GetRandomIntByLength(2, 6).ToString();
                    fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
                        Assert.That(numerator, Is.Not.Null, fractionString);
                        Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                        Assert.That(denominator, Is.Not.Null, fractionString);
                        Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                        Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                    });

                    expectedNumerator = GetRandomIntByLength(2, 6).ToString();
                    expectedDenominiator = GetRandomIntByLength(1, 1).ToString();
                    fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
                        Assert.That(numerator, Is.Not.Null, fractionString);
                        Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                        Assert.That(denominator, Is.Not.Null, fractionString);
                        Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                        Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                    });

                    expectedNumerator = GetRandomIntByLength(2, 6).ToString();
                    expectedDenominiator = GetRandomIntByLength(2, 6).ToString();
                    fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                    returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                    Assert.Multiple(() =>
                    {
                        Assert.That(returnValue, Is.True, fractionString);
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
                            expectedNumerator = GetRandomIntByLength(1, 4).ToString();
                            expectedDenominiator = GetRandomIntByLength(1, 1).ToString();
                            fractionString = $"({leftPad}{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}{rightPad})";
                            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                            Assert.Multiple(() =>
                            {
                                Assert.That(returnValue, Is.True, fractionString);
                                Assert.That(numerator, Is.Not.Null, fractionString);
                                Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                Assert.That(denominator, Is.Not.Null, fractionString);
                                Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                            });

                            expectedDenominiator = GetRandomIntByLength(2, 6).ToString();
                            fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                            Assert.Multiple(() =>
                            {
                                Assert.That(returnValue, Is.True, fractionString);
                                Assert.That(numerator, Is.Not.Null, fractionString);
                                Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                Assert.That(denominator, Is.Not.Null, fractionString);
                                Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                            });

                            expectedNumerator = GetRandomIntByLength(1, 1).ToString();
                            expectedDenominiator = GetRandomIntByLength(1, 1).ToString();
                            fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                            Assert.Multiple(() =>
                            {
                                Assert.That(returnValue, Is.True, fractionString);
                                Assert.That(numerator, Is.Not.Null, fractionString);
                                Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                Assert.That(denominator, Is.Not.Null, fractionString);
                                Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                            });

                            expectedNumerator = GetRandomIntByLength(1, 1).ToString();
                            expectedDenominiator = GetRandomIntByLength(2, 6).ToString();
                            fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                            Assert.Multiple(() =>
                            {
                                Assert.That(returnValue, Is.True, fractionString);
                                Assert.That(numerator, Is.Not.Null, fractionString);
                                Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                Assert.That(denominator, Is.Not.Null, fractionString);
                                Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                            });

                            expectedNumerator = GetRandomIntByLength(2, 6).ToString();
                            expectedDenominiator = GetRandomIntByLength(1, 1).ToString();
                            fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                            Assert.Multiple(() =>
                            {
                                Assert.That(returnValue, Is.True, fractionString);
                                Assert.That(numerator, Is.Not.Null, fractionString);
                                Assert.That(numerator, Is.EqualTo(expectedNumerator), fractionString);
                                Assert.That(denominator, Is.Not.Null, fractionString);
                                Assert.That(denominator, Is.EqualTo(expectedDenominiator), fractionString);
                                Assert.That(isNegative, Is.EqualTo(expectedNumNegative != expectedDenNegative), fractionString);
                            });

                            expectedNumerator = GetRandomIntByLength(2, 6).ToString();
                            expectedDenominiator = GetRandomIntByLength(2, 6).ToString();
                            fractionString = fractionString = $"{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
                            returnValue = Fraction.TryGetSimpleFractionTokens(fractionString, out numerator, out denominator, out isNegative);
                            Assert.Multiple(() =>
                            {
                                Assert.That(returnValue, Is.True, fractionString);
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
        var wsChars = "      \t";
        IEnumerable<string> getPadStrings()
        {
            yield return string.Empty;
            yield return " ";
            yield return "\t";
            yield return GetRandomString(2, 4, wsChars);
        }

        IEnumerable<(string Sign, string Expected, bool IsNegative)> getWholeNumberTests()
        {
            yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), false);
            yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), false);
            yield return ("+", GetRandomIntByLength(1, 1).ToString(), false);
            yield return ("+", GetRandomIntByLength(2, 6).ToString(), false);
            yield return ("-", GetRandomIntByLength(1, 1).ToString(), true);
            yield return ("-", GetRandomIntByLength(2, 6).ToString(), true);
            yield return ("−", GetRandomIntByLength(1, 1).ToString(), true);
            yield return ("−", GetRandomIntByLength(2, 6).ToString(), true);
        }
        
        IEnumerable<(string NumeratorSign, string ExpectedNumerator, string separator, string DenominatorSign, string ExpectedDenominator, bool IsNegative)> getSimpleFractionTests()
        {
            foreach (string separator in new char[] { '∕', '/' }.SelectMany(c => getPadStrings().SelectMany(l => getPadStrings().Select(r => $"{l}{c}{r}"))))
            {
                yield return (string.Empty, "0", separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), false);
                yield return (string.Empty, "0", separator, "+", GetRandomIntByLength(1, 1).ToString(), false);
                yield return (string.Empty, "0", separator, "-", GetRandomIntByLength(1, 1).ToString(), true);
                yield return (string.Empty, "0", separator, "−", GetRandomIntByLength(1, 1).ToString(), true);

                yield return (string.Empty, "0", separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), false);
                yield return (string.Empty, "0", separator, "+", GetRandomIntByLength(2, 6).ToString(), false);
                yield return (string.Empty, "0", separator, "-", GetRandomIntByLength(2, 6).ToString(), true);
                yield return (string.Empty, "0", separator, "−", GetRandomIntByLength(2, 6).ToString(), true);

                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), true);
                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), true);

                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), true);
                yield return (string.Empty, GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), true);

                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), true);
                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), true);

                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), false);
                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), true);
                yield return (string.Empty, GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), true);

                yield return ("+", "0", separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("+", "0", separator, "+", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("+", "0", separator, "-", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("+", "0", separator, "−", GetRandomIntByLength(1, 1).ToString(), true);

                yield return ("+", "0", separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("+", "0", separator, "+", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("+", "0", separator, "-", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("+", "0", separator, "−", GetRandomIntByLength(2, 6).ToString(), true);

                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), true);

                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("+", GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), true);

                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), true);

                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("+", GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), true);

                yield return ("-", "0", separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("-", "0", separator, "+", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("-", "0", separator, "-", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("-", "0", separator, "−", GetRandomIntByLength(1, 1).ToString(), false);

                yield return ("-", "0", separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("-", "0", separator, "+", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("-", "0", separator, "-", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("-", "0", separator, "−", GetRandomIntByLength(2, 6).ToString(), false);

                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), false);

                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("-", GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), false);

                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), false);

                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("-", GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), false);

                yield return ("−", "0", separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("−", "0", separator, "+", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("−", "0", separator, "-", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("−", "0", separator, "−", GetRandomIntByLength(1, 1).ToString(), false);

                yield return ("−", "0", separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("−", "0", separator, "+", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("−", "0", separator, "-", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("−", "0", separator, "−", GetRandomIntByLength(2, 6).ToString(), false);

                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), false);

                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("−", GetRandomIntByLength(1, 1).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), false);

                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(1, 1).ToString(), true);
                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(1, 1).ToString(), false);
                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(1, 1).ToString(), false);

                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, string.Empty, GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, "+", GetRandomIntByLength(2, 6).ToString(), true);
                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, "-", GetRandomIntByLength(2, 6).ToString(), false);
                yield return ("−", GetRandomIntByLength(2, 6).ToString(), separator, "−", GetRandomIntByLength(2, 6).ToString(), false);
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
                    fractionString = $"{wholeNumberSign}{expectedWholeNumber}{GetRandomString(1, 6, wsChars)}{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}";
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
                            fractionString = $"({leftPad}{wholeNumberSign}{expectedWholeNumber}{GetRandomString(1, 6, wsChars)}{numeratorSign}{expectedNumerator}{separator}{denominatorSign}{expectedDenominiator}{rightPad})";
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
}