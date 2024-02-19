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
        returnValue = s.TryMatchGroup(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(3));

        s = "((5)/(4))".AsSpan();
        returnValue = s.TryMatchGroup(out result);
        Assert.That(returnValue, Is.True);
        Assert.That(result, Is.EqualTo(9));

        s = " (12)".AsSpan();
        returnValue = s.TryMatchGroup(out _);
        Assert.That(returnValue, Is.False);

        s = "((5)/(4)".AsSpan();
        returnValue = s.TryMatchGroup(out _);
        Assert.That(returnValue, Is.False);

        s = "((5/(4))".AsSpan();
        returnValue = s.TryMatchGroup(out _);
        Assert.That(returnValue, Is.False);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetTryParseSimpleFractionTestData))]
    public void TryParseSimpleFractionTest(string fractionString, NumberStyles style, int expectedNumerator, int expectedDenominator)
    {
        var result = Fraction.TryParseSimpleFraction(fractionString.AsSpan(), style, CultureInfo.CurrentCulture.NumberFormat, out int actualNumerator, out int actualDenominator);
        Assert.That(result, Is.True);
        Assert.That(actualNumerator, Is.EqualTo(expectedNumerator));
        Assert.That(actualDenominator, Is.EqualTo(expectedDenominator));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetTryParseMixedFractionTestData))]
    public void TryParseMixedFractionTest(string fractionString, NumberStyles style, int expectedWholeNumber, int expectedNumerator, int expectedDenominator)
    {
        var result = Fraction.TryParseMixedFraction(fractionString.AsSpan(), style, CultureInfo.CurrentCulture.NumberFormat, out int actualWholeNumber, out int actualNumerator, out int actualDenominator);
        Assert.That(result, Is.True);
        Assert.That(actualWholeNumber, Is.EqualTo(expectedWholeNumber));
        Assert.That(actualNumerator, Is.EqualTo(expectedNumerator));
        Assert.That(actualDenominator, Is.EqualTo(expectedDenominator));
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