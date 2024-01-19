using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests
{
    public class FractionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TryGetFractionTokensTest()
        {
            string fractionString = "3";
            var actual = Fraction.TryGetFractionTokens(fractionString, out string? wholeNumber, out string? numerator, out string? denominator, out bool isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("3"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.Empty);
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.Empty);
                Assert.That(isNegative, Is.False);
            });
            fractionString = "356";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("356"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.Empty);
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.Empty);
                Assert.That(isNegative, Is.False);
            });
            fractionString = "3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "+4/26";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("4"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("26"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "5/+345";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("5"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("345"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "-6/777";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("6"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("777"));
                Assert.That(isNegative, Is.True);
            });
            fractionString = "-3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });
            fractionString = "3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });
            fractionString = "+3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });
            fractionString = "-3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.Empty);
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "1 3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            
            fractionString = "+13 3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("13"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "+1 +367/856";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("367"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("856"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "+1 3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "+1 +3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });

            fractionString = "1 +3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "1 +3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });

            fractionString = "1+3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "1+3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "+1+3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });

            fractionString = "1 3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "+1 3/+4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });

            fractionString = "-1 3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });
            fractionString = "-1 3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });

            fractionString = "1 -3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });
            fractionString = "-1 -3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "1 -3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "-1 -3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });

            fractionString = "1-3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });
            fractionString = "-1-3/4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "1-3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.False);
            });
            fractionString = "-1-3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });

            fractionString = "1 3/-4";
            actual = Fraction.TryGetFractionTokens(fractionString, out wholeNumber, out numerator, out denominator, out isNegative);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.True);
                Assert.That(wholeNumber, Is.Not.Null);
                Assert.That(wholeNumber, Is.EqualTo("1"));
                Assert.That(numerator, Is.Not.Null);
                Assert.That(numerator, Is.EqualTo("3"));
                Assert.That(denominator, Is.Not.Null);
                Assert.That(denominator, Is.EqualTo("4"));
                Assert.That(isNegative, Is.True);
            });
        }

        [Test]
        public void ToCommonDenominatorTest()
        {
            var n1 = 2;
            var d1 = 3;
            var n2 = 3;
            var d2 = 4; // 12/4 = 3; 3 
            Fraction.ToCommonDenominator(ref n1, ref d1, ref n2, ref d2);
            Assert.That(n1, Is.EqualTo(8));
            Assert.That(d1, Is.EqualTo(12));
            Assert.That(n2, Is.EqualTo(9));
            Assert.That(d2, Is.EqualTo(12));
        }

        [Test]
        public void GetGCDTest()
        {
            var d1 = 8;
            var d2 = 12;
            var actual = Fraction.GetGCD(d1, d2);
            Assert.That(actual, Is.EqualTo(4));
        }

        [Test]
        public void GetLCMTest()
        {
            var d1 = 3;
            var d2 = 4;
            int actual = Fraction.GetLCM(d1, d2);
            Assert.That(actual, Is.EqualTo(12));
            d1 = 6;
            d2 = 4;
            actual = Fraction.GetLCM(d1, d2);
            Assert.That(actual, Is.EqualTo(12));
            d1 = 5;
            d2 = 7;
            actual = Fraction.GetLCM(d1, d2);
            Assert.That(actual, Is.EqualTo(35));
            d1 = 6;
            d2 = 9;
            actual = Fraction.GetLCM(d1, d2);
            Assert.That(actual, Is.EqualTo(18));
            d1 = 15;
            d2 = 10;
            actual = Fraction.GetLCM(d1, d2);
            Assert.That(actual, Is.EqualTo(30));
        }
    }
}