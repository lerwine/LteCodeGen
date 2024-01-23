using System;
using System.Collections.Generic;
using System.Linq;
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
            if (length == 0) return string.Empty;
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