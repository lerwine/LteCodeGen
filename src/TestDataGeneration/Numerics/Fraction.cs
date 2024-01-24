using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Media;
using System.Numerics;
using System.Text.RegularExpressions;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Helper class for fractional values.
/// </summary>
public static class Fraction
{
    /// <summary>
    /// The default separator for the <see cref="IFraction{TSelf, TValue}.Numerator" /> and <see cref="IFraction{TSelf, TValue}.Denominator" />.
    /// </summary>
    public const char Separator_Numerator_Denominator = '\u2215';

    /// <summary>
    /// The alternate separator for the <see cref="IFraction{TSelf, TValue}.Numerator" /> and <see cref="IFraction{TSelf, TValue}.Denominator" />.
    /// </summary>
    public const char AltSeparator_Numerator_Denominator = '/';

    private static readonly char[] _anySeparator = new char[] { Separator_Numerator_Denominator, AltSeparator_Numerator_Denominator };

    public const char Group_Open = '(';

    public const char Group_Close = ')';

    /// <summary>
    /// The default positive sign character.
    /// </summary>
    public const char Positive_Prefix_Char = '+';

    /// <summary>
    /// The default negative sign character.
    /// </summary>
    public const char Negative_Prefix_Char = '-';

    /// <summary>
    /// The alternate negative sign character.
    /// </summary>
    public const char AltNegative_Prefix_Char = '\u2212';

    /// <summary>
    /// String representation for a fraction that is not a number (<see cref="IFraction{TSelf, TValue}.Denominator" /> is zero).
    /// </summary>
    public const string Format_NaN = "NaN";

    /// <summary>
    /// The default number format for the <see cref="IMixedFraction{TSelf, TValue}.WholeNumber"/>, <see cref="IFraction{TSelf, TValue}.Numerator" />, and <see cref="IFraction{TSelf, TValue}.Denominator" />.
    /// </summary>
    private const string Default_Number_Format = "D";

    private static readonly NumberFormatInfo _defaultFormatInfo = CultureInfo.InvariantCulture.NumberFormat;

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) AddFractions<TFraction, TValue>(TValue wholeNumber1, TFraction fraction1, TValue wholeNumber2, TFraction fraction2)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) AddFractions<TFraction, TValue>(TFraction fraction1, TFraction fraction2)
        where TFraction : struct, IMixedFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue Numerator, TValue Denominator) AddSimpleFractions<TFraction, TValue>(TFraction fraction1, TFraction fraction2)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static int CompareFractionComponents<T>(T numerator1, T denominator1, T numerator2, T denominator2)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(numerator1) || T.IsZero(numerator2) || denominator1 == denominator2)
        {
            if (T.IsZero(denominator1) || T.IsZero(denominator2)) throw new DivideByZeroException();
        }
        else
            ToCommonDenominator(ref numerator1, ref denominator1, ref numerator2, ref denominator2);
        return numerator1.CompareTo(numerator2);
    }

    public static int CompareFractionComponents<T>(T wholeNumber1, T numerator1, T denominator1, T wholeNumber2, T numerator2, T denominator2)
        where T : struct, IBinaryNumber<T>
    {
        wholeNumber1 = GetNormalizedRational(wholeNumber1, numerator1, denominator1, out numerator1, out denominator1);
        wholeNumber2 = GetNormalizedRational(wholeNumber2, numerator2, denominator2, out numerator2, out denominator2);
        int diff = wholeNumber1.CompareTo(wholeNumber2);
        if (diff != 0) return diff;

        if (T.IsZero(wholeNumber1))
        {
            if (T.IsZero(numerator1) || T.IsZero(numerator2) || denominator1 == denominator2)
            {
                if (T.IsZero(denominator1) || T.IsZero(denominator2)) throw new DivideByZeroException();
            }
            else
                ToCommonDenominator(ref numerator1, ref denominator1, ref numerator2, ref denominator2);
        }
        else
        {
            if (T.IsZero(numerator1)) return T.Sign(numerator2);
            if (T.IsZero(numerator2)) return T.Sign(numerator1);
            ToCommonDenominator(ref numerator1, ref denominator1, ref numerator2, ref denominator2);
        }

        return numerator1.CompareTo(numerator2);
    }

    public static bool AreSimpleFractionsEqual<TFraction, TValue>(TFraction fraction1, TFraction fraction2)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static bool AreMixedFractionsEqual<TFraction, TValue>(TFraction fraction1, TFraction fraction2)
        where TFraction : struct, IMixedFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) DivideFractions<TFraction, TValue>(TValue wholeDividend, TFraction dividendFraction, TValue wholeDivisor, TFraction divisorFraction)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) DivideFractions<TFraction, TValue>(TFraction dividend, TFraction divisor)
        where TFraction : struct, IMixedFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue Numerator, TValue Denominator) DivideSimpleFractions<TFraction, TValue>(TFraction dividend, TFraction divisor)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) MultiplyFractions<TFraction, TValue>(TValue wholeMultiplier, TFraction multiplierFraction, TValue wholeMultiplicand, TFraction multiplicandFraction)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) MultiplyFractions<TFraction, TValue>(TFraction multiplier, TFraction multiplicand)
        where TFraction : struct, IMixedFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue Numerator, TValue Denominator) MultiplySimpleFractions<TFraction, TValue>(TFraction multiplier, TFraction multiplicand)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) SubtractFractions<TFraction, TValue>(TValue wholeMinuend, TFraction minuendFraction, TValue wholeSubtrahend, TFraction subtrahendFraction)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue WholeNumber, TValue Numerator, TValue Denominator) SubtractFractions<TFraction, TValue>(TFraction minuend, TFraction subtrahend)
        where TFraction : struct, IMixedFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    public static (TValue Numerator, TValue Denominator) SubtractSimpleFractions<TFraction, TValue>(TFraction minuend, TFraction subtrahend)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the greatest common denominator.
    /// </summary>
    /// <param name="d1">The first denominator value.</param>
    /// <param name="d2">The second denominator value.</param>
    /// <param name="denominators">Optional additional denominator values.</param>
    /// <returns>The greatest common denominator among the given denominators.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="d1"/>, <paramref name="d2"/>, or one of the values of <paramref name="denominators"/> is <c>0</c>.</exception>
    public static T GetGCD<T>(T d1, T d2, params T[] denominators)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(d1)) throw new ArgumentOutOfRangeException(nameof(d1));
        if (T.IsZero(d2)) throw new ArgumentOutOfRangeException(nameof(d2));
        if ((d1 = T.Abs(d1)) == T.One || (d2 = T.Abs(d2)) == T.One) return T.One;
        static T getNext(T g, T d)
        {
            T b;
            if (d.CompareTo(g) > 0)
            {
                b = g;
                g = d;
            }
            else
                b = d;
            while (!T.IsZero(b))
            {
                T rem = g % b;
                g = b;
                b = rem;
            }
            return g;
        }
        T gcd = getNext(d1, d2);
        if (denominators is not null)
            foreach (T d in denominators)
            {
                if (T.IsZero(d)) throw new ArgumentOutOfRangeException(nameof(denominators));
                gcd = getNext(gcd, T.Abs(d));
            }
        return gcd;
    }

    /// <summary>
    /// Gets the lowest common multiple.
    /// </summary>
    /// <param name="d1">The first denominator.</param>
    /// <param name="d2">The second denominator.</param>
    /// <returns>The lowest common mutiple for the two denominators.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="d1"/> or <paramref name="d2"/> is <c>0</c>.</exception>
    public static T GetLCM<T>(T d1, T d2)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(d1)) throw new ArgumentOutOfRangeException(nameof(d1));
        if (T.IsZero(d2)) throw new ArgumentOutOfRangeException(nameof(d2));
        if ((d1 = T.Abs(d1)) == T.One) return T.Abs(d2);
        if ((d2 = T.Abs(d2)) == T.One) return d1;
        if (d1 < d2) return GetLCM(d2, d1);
        var lcm = d1;
        while (!T.IsZero(lcm % d2)) lcm += d1;
        return lcm;
    }

    public static T GetInvertedRational<T>(T w, T n, T d, out T numerator, out T denominator)
        where T : struct, IBinaryNumber<T>
    {
        w = GetNormalizedRational(w, n, d, out numerator, out denominator);

        if (T.IsZero(numerator))
        {
            if (T.IsZero(w)) return w;
            numerator = T.One;
            denominator = w;
            return T.Zero;
        }

        if (T.IsZero(w))
            return GetNormalizedRational(T.Zero, d, n, out numerator, out denominator);

        return GetNormalizedRational(T.Zero, d, n + d * w, out numerator, out denominator);
    }

    public static T GetNormalizedRational<T>(T wholeNumber, T numerator, T denominator, out T properNumerator, out T properDenominator)
        where T : struct, IBinaryNumber<T>
    {
        properNumerator = GetSimplifiedRational(numerator, denominator, out properDenominator);

        if (T.IsZero(properNumerator)) return wholeNumber;

        if (T.IsNegative(wholeNumber))
        {
            if (T.IsNegative(properNumerator))
            {
                if (T.IsNegative(properDenominator))
                    properDenominator = T.Abs(properDenominator);
                else
                    wholeNumber = T.Abs(wholeNumber);
                properNumerator = T.Abs(properNumerator);
            }
            else if (T.IsNegative(properNumerator))
            {
                wholeNumber = T.Abs(wholeNumber);
                properNumerator = T.Abs(properNumerator);
            }
        }
        else if (T.IsNegative(properDenominator))
        {
            if (T.IsZero(wholeNumber))
            {
                if (T.IsNegative(properNumerator))
                    properNumerator = T.Abs(properNumerator);
                else
                    properNumerator = T.Zero - properNumerator;
            }
            else if (T.IsNegative(properNumerator))
                properNumerator = T.Abs(properNumerator);
            else
                wholeNumber = T.Zero - wholeNumber;
            properDenominator = T.Abs(properDenominator);
        }
        else if (T.IsNegative(properNumerator) && !T.IsZero(wholeNumber))
        {
            wholeNumber = T.Zero - wholeNumber;
            properDenominator = T.Abs(properDenominator);
        }

        if (properDenominator.Equals(T.One))
        {
            properNumerator = T.Zero;
            return wholeNumber + properNumerator;
        }

        if (properNumerator > properDenominator)
        {
            properNumerator %= properDenominator;
            wholeNumber = T.IsNegative(wholeNumber)
                ? wholeNumber - ((properNumerator - properNumerator) / properDenominator)
                : wholeNumber + ((properNumerator - properNumerator) / properDenominator);
            properNumerator = GetSimplifiedRational(properNumerator, properDenominator, out properDenominator);
        }

        if (T.IsZero(wholeNumber))
            return wholeNumber;

        if (T.IsNegative(properNumerator))
        {
            wholeNumber = T.IsNegative(wholeNumber) ? wholeNumber + T.One : wholeNumber - T.One;
            properNumerator += properDenominator;
        }

        return wholeNumber;
    }

    public static T GetProperRational<T>(T wholeNumber, T numerator, T denominator, out T properNumerator)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator)) throw new DivideByZeroException();

        if (T.IsZero(numerator))
        {
            properNumerator = numerator;
            return wholeNumber;
        }

        if (denominator.Equals(T.One))
        {
            properNumerator = T.Zero;
            return wholeNumber + numerator;
        }

        if (numerator > denominator)
        {
            properNumerator = numerator % denominator;
            wholeNumber = T.IsNegative(wholeNumber)
                ? wholeNumber - ((numerator - properNumerator) / denominator)
                : wholeNumber + ((numerator - properNumerator) / denominator);
        }
        else
            properNumerator = numerator;

        if (T.IsZero(wholeNumber))
            return wholeNumber;

        if (T.IsNegative(properNumerator))
        {
            wholeNumber = T.IsNegative(wholeNumber) ? wholeNumber + T.One : wholeNumber - T.One;
            properNumerator += denominator;
        }

        return wholeNumber;
    }

    /// <summary>
    /// Gets the simplified rational for given fraction values.
    /// </summary>
    /// <param name="numerator">The numerator of a fraction.</param>
    /// <param name="denominator">The denominator of a fraction.</param>
    /// <param name="simplifiedDenominator">The simplified denominator.</param>
    /// <returns>The simplified numerator.</returns>
    public static T GetSimplifiedRational<T>(T numerator, T denominator, out T simplifiedDenominator)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator)) throw new DivideByZeroException();

        if (T.IsZero(numerator))
        {
            simplifiedDenominator = T.One;
            return T.Zero;
        }

        if (numerator.Equals(denominator))
        {
            simplifiedDenominator = T.One;
            return T.One;
        }

        if (T.IsNegative(denominator))
        {

            denominator = T.Zero - denominator;
            numerator = T.Zero - numerator;
        }
        T gcd = GetGCD(numerator, denominator);
        simplifiedDenominator = denominator / gcd;
        return numerator / gcd;
    }

    public static void ToCommonDenominator<T>(ref T numerator1, ref T denominator1, ref T numerator2, ref T denominator2)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator1) || T.IsZero(denominator2)) throw new DivideByZeroException();

        if (T.IsZero(numerator1))
        {
            if (T.IsZero(numerator2))
                denominator1 = denominator2 = T.One;
            else
            {
                numerator2 = GetSimplifiedRational(numerator2, denominator2, out denominator2);
                denominator1 = denominator2;
            }
        }
        else if (T.IsZero(numerator2))
        {
            numerator1 = GetSimplifiedRational(numerator1, denominator1, out denominator1);
            denominator2 = denominator1;
        }
        else if (!denominator1.Equals(denominator2))
        {
            numerator1 = GetSimplifiedRational(numerator1, denominator1, out denominator1);
            numerator2 = GetSimplifiedRational(numerator2, denominator2, out denominator2);

            if (denominator1.Equals(T.One))
            {
                denominator1 = denominator2;
                numerator1 *= denominator2;
            }
            else if (denominator2.Equals(T.One))
            {
                denominator2 = denominator1;
                numerator2 *= denominator1;
            }
            else if (!denominator1.Equals(denominator2))
            {
                T lcm = GetLCM(denominator1, denominator2);
                numerator1 *= lcm / denominator1;
                numerator2 *= lcm / denominator2;
                denominator1 = denominator2 = lcm;
            }
        }
    }

    public static string ToFractionString<T>(T wholeNumber, T numerator, T denominator, IFormatProvider? provider = null)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator) || T.IsNaN(denominator)) return Format_NaN;
        if (T.IsZero(numerator)) return wholeNumber.ToString(Default_Number_Format, provider ?? _defaultFormatInfo);
        var p = provider ?? _defaultFormatInfo;
        var str = numerator.ToString(Default_Number_Format, p) + Separator_Numerator_Denominator + denominator.ToString(Default_Number_Format, p);
        if (!T.IsZero(wholeNumber))
        {
            var nfi = provider as NumberFormatInfo ?? _defaultFormatInfo;
            if (char.IsNumber(str[0]))
                str = wholeNumber.ToString(Default_Number_Format, p) + (T.IsNegative(numerator) ? nfi.NegativeSign : nfi.PositiveSign) + str;
            else if (str.StartsWith(nfi.NegativeSign) || str.StartsWith(nfi.PositiveSign))
                str = wholeNumber.ToString(Default_Number_Format, p) + str;
            else
                str = wholeNumber.ToString(Default_Number_Format, p) + " " + (T.IsNegative(numerator) ? nfi.NegativeSign : nfi.PositiveSign) + " " + str;
        }
        return $"({str})";
    }

    public static string ToFractionString<T>(T wholeNumber, T numerator, T denominator, string? format, IFormatProvider? provider = null)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator) || T.IsNaN(denominator)) return Format_NaN;
        if (string.IsNullOrEmpty(format)) format  = Default_Number_Format;
        if (T.IsZero(numerator)) return wholeNumber.ToString(format, provider ?? _defaultFormatInfo);
        var p = provider ?? _defaultFormatInfo;
        var str = numerator.ToString(format, p) + Separator_Numerator_Denominator + denominator.ToString(format, p);
        if (!T.IsZero(wholeNumber))
        {
            var nfi = provider as NumberFormatInfo ?? _defaultFormatInfo;
            if (char.IsNumber(str[0]))
                str = wholeNumber.ToString(format, p) + (T.IsNegative(numerator) ? nfi.NegativeSign : nfi.PositiveSign) + str;
            else if (str.StartsWith(nfi.NegativeSign) || str.StartsWith(nfi.PositiveSign))
                str = wholeNumber.ToString(format, p) + str;
            else
                str = wholeNumber.ToString(format, p) + " " + (T.IsNegative(numerator) ? nfi.NegativeSign : nfi.PositiveSign) + " " + str;
        }
        return $"({str})";
    }

    public static string ToFractionString<T>(T numerator, T denominator, IFormatProvider? provider = null)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator) || T.IsNaN(denominator)) return Format_NaN;
        if (T.IsZero(numerator)) return numerator.ToString(Default_Number_Format, provider ?? _defaultFormatInfo);
        provider ??= _defaultFormatInfo;
        return "(" + numerator.ToString(Default_Number_Format, provider) + Separator_Numerator_Denominator + denominator.ToString(Default_Number_Format, provider) + ")";
    }

    public static string ToFractionString<T>(T numerator, T denominator, string? format, IFormatProvider? provider = null)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator) || T.IsNaN(denominator)) return Format_NaN;
        if (string.IsNullOrEmpty(format)) format = Default_Number_Format;
        if (T.IsZero(numerator)) return numerator.ToString(format, provider ?? _defaultFormatInfo);
        provider ??= _defaultFormatInfo;
        return "(" + numerator.ToString(format, provider) + Separator_Numerator_Denominator + denominator.ToString(format, provider) + ")";
    }

    public enum FractionTokenType
    {
        Group,
        Numbers,
        Separator,
        WhiteSpace,
        Other
    }
    public record FractionToken(int Start, int End, FractionTokenType Type)
    {
        public ReadOnlySpan<char> ToSpan(ReadOnlySpan<char> s) => s[Start..End];
        public ReadOnlySpan<char> ToInnerSpan(ReadOnlySpan<char> s)
        {
            var i = Start + 1;
            var e = End - 1;
            return (i < e) ? ReadOnlySpan<char>.Empty : s[i..e];
        }
    }

    public static IEnumerable<FractionToken> TokenizeFractionString(ReadOnlySpan<char> s)
    {
        int e;
        for (int index = 0; index < s.Length; index++)
        {
            char c = s[index];
            switch (c)
            {
                case '(':
                    int level = 1;
                    e = index + 1;
                    while (level > 0)
                    {
                        switch (s[e])
                        {
                            case '(':
                                level++;
                                break;
                            case ')':
                                level--;
                                break;
                        }
                        e++;
                        if (e == s.Length) break;
                    }
                    if (level == 0)
                    {
                        yield return new FractionToken(index, e, FractionTokenType.Group);
                        index = e - 1;
                    }
                    else
                    {
                        e = index + 1;
                        while (e < s.Length)
                        {
                            c = s[e];
                            if (c switch
                            {
                                '(' or Separator_Numerator_Denominator or AltSeparator_Numerator_Denominator => true,
                                _ => char.IsNumber(c) || char.IsWhiteSpace(c),
                            }) break;
                            e++;
                        }
                        yield return new FractionToken(index, e, FractionTokenType.Other);
                        index = e - 1;
                    }
                    break;
                case Separator_Numerator_Denominator:
                case AltSeparator_Numerator_Denominator:
                    yield return new FractionToken(index, index + 1, FractionTokenType.Separator);
                    break;
                default:
                    e = index + 1;
                    if (char.IsNumber(c))
                    {
                        while (e < s.Length)
                        {
                            if (!char.IsNumber(c)) break;
                            e++;
                        }
                        yield return new FractionToken(index, e, FractionTokenType.Numbers);
                    }
                    else if (char.IsWhiteSpace(c))
                    {
                        while (e < s.Length)
                        {
                            if (!char.IsWhiteSpace(c)) break;
                            e++;
                        }
                        yield return new FractionToken(index, e, FractionTokenType.WhiteSpace);
                    }
                    else
                    {
                        while (e < s.Length)
                        {
                            c = s[e];
                            if (c switch
                            {
                                '(' or Separator_Numerator_Denominator or AltSeparator_Numerator_Denominator => true,
                                _ => char.IsNumber(c) || char.IsWhiteSpace(c),
                            }) break;
                            e++;
                        }
                        yield return new FractionToken(index, e, FractionTokenType.Other);
                    }
                    index = e - 1;
                    break;
            }
        }
    }

    public static ReadOnlySpan<char> SplitFractionComponents(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out ReadOnlySpan<char> numerator, out ReadOnlySpan<char> denominator)
    {
        // Check starting with \s*\( and ending witih \)\s* with balancing pair checking
        // whole: \D*\d+[^\d/]*
        // whole: \D*\d+[^\d/]*
        // whole: \D*\d+[^\d\s/]*  \s+  numerator: [^\d/\s]*\d+[^/\d]*  \s*/\s*  denominator: \D*\d+\D*
        // whole: \D*\d+[^\d\s/]*  numerator: [^\d/\s]+\d+[^/\d]*  \s*/\s*  denominator: \D*\d+\D*
        // numerator: \D*\d+[^\d\s/]*   \s*/\s*  denominator: \D*\d+\D*
        var tokens = TokenizeFractionString(s).ToList();
        if (tokens.Count == 0)
        {
            numerator = denominator = ReadOnlySpan<char>.Empty;
            return s;
        }
        var t = tokens[0];
        if (tokens.Count == 1)
        {
            if (t.Type == FractionTokenType.Group)
            {
                if ((s = t.ToInnerSpan(s)).IsEmpty)
                {
                    numerator = denominator = ReadOnlySpan<char>.Empty;
                    return s;
                }
                return SplitFractionComponents(s, style, provider, out numerator, out denominator);
            }
            if (t.Type == FractionTokenType.Numbers)
            {
                numerator = ReadOnlySpan<char>.Empty;
                denominator = ReadOnlySpan<char>.Empty;
                return t.ToSpan(s);
            }
            numerator = denominator = ReadOnlySpan<char>.Empty;
            return s;
        }
        int wholeNumberStart = t.Start;
        throw new NotImplementedException();
    }

    public static bool TryParseSimpleFraction<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out T numerator, out T denominator)
        where T : struct, IBinaryNumber<T>
    {
        int index = s.IndexOf(Group_Open);
        if ((index == 0) ? (s.Length < 3 || s[^1] != Group_Close || (s = s[1..^1].Trim()).Length == 0) : index > 0)
        {
            numerator = denominator = default;
            return false;
        }
        
        if ((index = s.IndexOfAny(Separator_Numerator_Denominator, AltSeparator_Numerator_Denominator)) < 0)
        {
            if (T.TryParse(s, style, provider, out numerator))
            {
                denominator = T.One;
                return true;
            }
            denominator = default;
        }
        else if (index == 0 || index == s.Length - 1)
            numerator = denominator = default;
        else if (T.TryParse(s[..index].TrimEnd(), style, provider, out numerator))
        {
            if (T.TryParse(s[(index + 1)..].TrimStart(), style, provider, out denominator)) return true;
        }
        else
            denominator = default;
        return false;
    }

    public static bool TryParseMixedFraction<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out T wholeNumber, out T numerator, out T denominator)
        where T : struct, IBinaryNumber<T>
    {
        int index = s.IndexOf(Group_Open);
        if ((index == 0) ? (s.Length < 3 || s[^1] != Group_Close || (s = s[1..^1].Trim()).Length == 0) : index > 0)
        {
            wholeNumber = numerator = denominator = default;
            return false;
        }

        if ((index = s.IndexOfAny(Separator_Numerator_Denominator, AltSeparator_Numerator_Denominator)) < 0)
        {
            if (T.TryParse(s, style, provider, out wholeNumber))
            {
                numerator = T.Zero;
                denominator = T.One;
                return true;
            }
            numerator = denominator = default;
            return false;
        }
        if (index == 0 || index == s.Length - 1)
        {
            wholeNumber = numerator = denominator = default;
            return false;
        }
        // s = [^/]{index}/[^/].*
        ReadOnlySpan<char> n = s[..index].TrimStart();
        if (n.Length == 0 || (s = s[(index + 1)..].TrimStart()).Length == 0 || !T.TryParse(s, style, provider, out denominator) || T.IsZero(denominator))
        {
            denominator = wholeNumber = numerator = default;
            return false;
        }
        // n = [^/\s][^/]*
        int startIndex;
        if (char.IsNumber(n[0]))
            startIndex = 0; // n = \d[^/]*
        else
        {
            if (n.Length == 1)
            {
                wholeNumber = numerator = default;
                return false;
            }
            // n = [^\d\s][^/]+
            startIndex = 1;
        }
        if (!char.IsNumber(n[startIndex]))
        {
            wholeNumber = numerator = default;
            return false;
        }
        // n = [^\d\s]?\d[^/]*
        for (int i = startIndex + 1; i < n.Length; i++)
        {
            if (!char.IsNumber(n[i]))
            {
                // n = [+-]?\d+[^\d]
                s = n[..i];
                if ((n = n[index..].TrimStart()).Length == 0 || !T.TryParse(s, style, provider, out wholeNumber))
                {
                    denominator = wholeNumber = numerator = default;
                    return false;
                }
                if (!char.IsNumber(n[0]))
                {
                    if (n.Length == 1)
                    {
                        denominator = numerator = default;
                        return false;
                    }
                    if (char.IsWhiteSpace(s[1])) n = new(new char[] { n[0] }.Concat(n[1..].TrimStart().ToArray()).ToArray());
                }
                return T.TryParse(n, style, provider, out numerator);
            }
        }
        wholeNumber = default;
        return T.TryParse(n, style, provider, out numerator);
    }

    public static object ConvertFraction<TFraction, TValue>(TFraction fraction, Type conversionType, IFormatProvider? provider)
        where TFraction : struct, IFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        if (conversionType is null || conversionType.IsAssignableFrom(fraction.GetType())) return fraction;
        provider ??= _defaultFormatInfo;
        var d = fraction.ToDouble(provider);
        return conversionType.IsAssignableFrom(typeof(double)) ? d : Convert.ChangeType(d, conversionType, provider);
    }

//     public static readonly Regex SimpleFractionPattern = new(@"^
// (
//     \(\s*
//         (?:(?<nn>[\u2212-])|\+)?(?<num>\d+)
//         (
//             [ \t]*
//             [\u2215/]
//             [ \t]*
//             (?:(?<nd>[\u2212-])|\+)?(?<den>\d+)
//         )?
//     \s*\)
// |
//     (?:(?<nn>[\u2212-])|\+)?(?<num>\d+)
//     (
//         [ \t]*
//         [\u2215/]
//         [ \t]*
//         (?:(?<nd>[\u2212-])|\+)?(?<den>\d+)
//     )?
// )
// $", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

//     public static readonly Regex MixedFractionPattern = new(@"^
// (
//     \(\s*
//         (?:(?<wn>[\u2212-])|\+)?(?<whl>\d+)
//         (
//             (
//                 (?:[\t ]+(?:(?<nn>[\u2212-])|\+)?|(?:(?<nn>[\u2212-])|\+))
//                 (?<num>\d+)
//             )?
//             [\u2215/]
//             [ \t]*
//             (?:(?<nd>[\u2212-])|\+)?(?<den>\d+)
//         )?
//     \s*\)
// |
//     (?:(?<wn>[\u2212-])|\+)?(?<whl>\d+)
//     (
//         (
//             (?:[\t ]+(?:(?<nn>[\u2212-])|\+)?|(?:(?<nn>[\u2212-])|\+))
//             (?<num>\d+)
//         )?
//         [\u2215/]
//         [ \t]*
//         (?:(?<nd>[\u2212-])|\+)?(?<den>\d+)
//     )?
// )
// $", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

    // public static readonly Regex FractionStringRegex = new(@"^(?:(?<wn>[−-])|\+)?(?<wh>\d+)([\u2215/](?:(?<dn0>[−-])|\+)?0*(?<d0>[1-9]\d*)|(\s+(?:(?<nn0>[−-])|\+)?|(?<nn1>[−-])|\+)(?<n>\d+)[\u2215/](?:(?<dn1>[−-])|\+)?0*(?<d1>[1-9]\d*))?$", RegexOptions.Compiled);

    public static int IndexOfNextNonWhiteSpace(string source, int startIndex)
    {
        while (startIndex < source.Length)
        {
            if (!char.IsWhiteSpace(source[startIndex])) return startIndex;
            startIndex++;
        }
        return -1;
    }

    public static bool TryGetFractionNumber(string source, int startIndex, bool allowWhitespaceAfterSign, out bool isNegative, out int numberStartIndex, out int nextIndex)
    {
        numberStartIndex = startIndex;
        switch (source[startIndex])
        {
            case Positive_Prefix_Char:
                isNegative = false;
                if (++numberStartIndex == source.Length)
                {
                    nextIndex = numberStartIndex;
                    return false;
                }
                if (char.IsWhiteSpace(source[numberStartIndex]))
                {
                    if (!allowWhitespaceAfterSign || (nextIndex = IndexOfNextNonWhiteSpace(source, numberStartIndex)) < 0)
                    {
                        nextIndex = numberStartIndex;
                        return false;
                    }
                    numberStartIndex = nextIndex;
                }
                break;
            case Negative_Prefix_Char:
            case AltNegative_Prefix_Char:
                isNegative = true;
                if (++numberStartIndex == source.Length)
                {
                    nextIndex = numberStartIndex;
                    return false;
                }
                if (char.IsWhiteSpace(source[numberStartIndex]))
                {
                    if (!allowWhitespaceAfterSign || (nextIndex = IndexOfNextNonWhiteSpace(source, numberStartIndex)) < 0)
                    {
                        nextIndex = numberStartIndex;
                        return false;
                    }
                    numberStartIndex = nextIndex;
                }
                break;
            default:
                isNegative = false;
                break;
        }
        if (char.IsAsciiDigit(source[numberStartIndex]))
        {
            nextIndex = numberStartIndex + 1;
            while (nextIndex < source.Length)
            {
                if (!char.IsAsciiDigit(source[nextIndex])) break;
                nextIndex++;
            }
            return true;
        }
        nextIndex = numberStartIndex;
        return false;
    }
    
    /// <summary>
    /// Parses the fraction component tokens from a string representation of a fraction.
    /// </summary>
    /// <param name="fractionString">A string representation of a fraction.</param>
    /// <returns><see langword="true"/> if the components could be parsed; ottherwise, <see langword="false"/> if <paramref name="fractionString"/> was not properly formatted.</returns>
    public static bool TryGetMixedFractionTokens(string fractionString, [NotNullWhen(true)] out string? wholeNumber, [NotNullWhen(true)] out string? numerator, [NotNullWhen(true)] out string? denominator,
        out bool isNegative)
    {
        if (string.IsNullOrEmpty(fractionString))
        {
            isNegative = false;
            wholeNumber = numerator = denominator = null;
            return false;
        }
        bool enclosedInParentheses = fractionString[0] == Group_Open;
        int wholeNumberStartIndex = enclosedInParentheses ? 1 : 0;
        if ((enclosedInParentheses && (fractionString.Length < 3 || fractionString[^1] != Group_Close || (wholeNumberStartIndex = IndexOfNextNonWhiteSpace(fractionString, wholeNumberStartIndex)) < 0)) ||
            !TryGetFractionNumber(fractionString, wholeNumberStartIndex, false, out isNegative, out wholeNumberStartIndex, out int wholeNumberEndIndex))
        {
            isNegative = false;
            wholeNumber = numerator = denominator = null;
            return false;
        }
        if (wholeNumberEndIndex == fractionString.Length)
        {
            wholeNumber = (wholeNumberStartIndex > 0) ? fractionString[wholeNumberStartIndex..] : fractionString;
            numerator = denominator = string.Empty;
            return true;
        }
        int numeratorStartIndex = IndexOfNextNonWhiteSpace(fractionString, wholeNumberEndIndex);
        if (numeratorStartIndex < 0)
        {
            if (enclosedInParentheses)
            {
                wholeNumber = fractionString[wholeNumberStartIndex..wholeNumberEndIndex];
                numerator = denominator = string.Empty;
                return true;
            }
            wholeNumber = numerator = denominator = null;
            return false;
        }
        int numeratorEndIndex, denominatorStartIndex;
        switch (fractionString[numeratorStartIndex])
        {
            case Separator_Numerator_Denominator:
            case AltSeparator_Numerator_Denominator:
                if ((denominatorStartIndex = numeratorStartIndex + 1) == fractionString.Length || (denominatorStartIndex = IndexOfNextNonWhiteSpace(fractionString, denominatorStartIndex)) < 0)
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                numeratorStartIndex = wholeNumberStartIndex;
                numeratorEndIndex = wholeNumberEndIndex;
                wholeNumberEndIndex = wholeNumberStartIndex;
                break;
            case Group_Close:
                if (enclosedInParentheses && numeratorStartIndex + 1 == fractionString.Length)
                {
                    wholeNumber = fractionString[wholeNumberStartIndex..wholeNumberEndIndex];
                    numerator = denominator = string.Empty;
                    return true;
                }
                wholeNumber = numerator = denominator = null;
                return false;
            default:
                if (!TryGetFractionNumber(fractionString, numeratorStartIndex, true, out bool numeratorIsNegative, out numeratorStartIndex, out numeratorEndIndex) ||
                    (denominatorStartIndex = IndexOfNextNonWhiteSpace(fractionString, numeratorEndIndex)) < 0)
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                switch (fractionString[denominatorStartIndex])
                {
                    case Separator_Numerator_Denominator:
                    case AltSeparator_Numerator_Denominator:
                        if (++denominatorStartIndex == fractionString.Length || (denominatorStartIndex = IndexOfNextNonWhiteSpace(fractionString, denominatorStartIndex)) < 0)
                        {
                            wholeNumber = numerator = denominator = null;
                            return false;
                        }
                        break;
                    default:
                        wholeNumber = numerator = denominator = null;
                        return false;
                }
                if (numeratorIsNegative) isNegative = !isNegative;
                break;
        }
        if (!TryGetFractionNumber(fractionString, denominatorStartIndex, true, out bool denominatorIsNegative, out denominatorStartIndex, out int denominatorEndIndex))
        {
            wholeNumber = numerator = denominator = null;
            return false;
        }
        if (denominatorIsNegative) isNegative = !isNegative;
        if (denominatorEndIndex < fractionString.Length)
        {
            if (enclosedInParentheses)
            {
                int index = IndexOfNextNonWhiteSpace(fractionString, denominatorEndIndex);
                if (index < fractionString.Length - 1)
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
            }
            else
            {
                wholeNumber = numerator = denominator = null;
                return false;
            }
        }
        wholeNumber = (wholeNumberStartIndex < wholeNumberEndIndex) ? fractionString[wholeNumberStartIndex..wholeNumberEndIndex] : string.Empty;
        numerator = fractionString[numeratorStartIndex..numeratorEndIndex];
        denominator = fractionString[denominatorStartIndex..denominatorEndIndex];
        return true;
    }

    /// <summary>
    /// Parses the fraction component tokens from a string representation of a fraction.
    /// </summary>
    /// <param name="fractionString">A string representation of a fraction.</param>
    /// <returns><see langword="true"/> if the components could be parsed; ottherwise, <see langword="false"/> if <paramref name="fractionString"/> was not properly formatted.</returns>
    public static bool TryGetSimpleFractionTokens(string fractionString, [NotNullWhen(true)] out string? numerator, [NotNullWhen(true)] out string? denominator, out bool isNegative)
    {
        if (string.IsNullOrEmpty(fractionString))
        {
            isNegative = false;
            numerator = denominator = null;
            return false;
        }
        bool enclosedInParentheses = fractionString[0] == Group_Open;
        int numeratorStartIndex = enclosedInParentheses ? 1 : 0;
        if ((enclosedInParentheses && (fractionString.Length < 3 || fractionString[^1] != Group_Close || (numeratorStartIndex = IndexOfNextNonWhiteSpace(fractionString, numeratorStartIndex)) < 0)) ||
            !TryGetFractionNumber(fractionString, numeratorStartIndex, false, out isNegative, out numeratorStartIndex, out int numeratorEndIndex))
        {
            isNegative = false;
            numerator = denominator = null;
            return false;
        }
        if (numeratorEndIndex == fractionString.Length)
        {
            numerator = (numeratorStartIndex > 0) ? fractionString[numeratorStartIndex..] : fractionString;
            denominator = string.Empty;
            return true;
        }
        
        int denominatorStartIndex = IndexOfNextNonWhiteSpace(fractionString, numeratorEndIndex);
        if (denominatorStartIndex < 0)
        {
            numerator = denominator = null;
            return false;
        }
        switch (fractionString[denominatorStartIndex])
        {
            case Separator_Numerator_Denominator:
            case AltSeparator_Numerator_Denominator:
                if (++denominatorStartIndex == fractionString.Length || (denominatorStartIndex = IndexOfNextNonWhiteSpace(fractionString, denominatorStartIndex)) < 0)
                {
                    numerator = denominator = null;
                    return false;
                }
                break;
            case Group_Close:
                if (enclosedInParentheses && denominatorStartIndex + 1 == fractionString.Length)
                {
                    numerator = fractionString[numeratorStartIndex..numeratorEndIndex];
                    denominator = string.Empty;
                    return true;
                }
                numerator = denominator = null;
                return false;
            default:
                numerator = denominator = null;
                return false;
        }
        if (!TryGetFractionNumber(fractionString, denominatorStartIndex, true, out bool denominatorIsNegative, out denominatorStartIndex, out int denominatorEndIndex))
        {
            numerator = denominator = null;
            return false;
        }
        if (denominatorIsNegative) isNegative = !isNegative;
        if (denominatorEndIndex < fractionString.Length)
        {
            if (enclosedInParentheses)
            {
                int index = IndexOfNextNonWhiteSpace(fractionString, denominatorEndIndex);
                if (index < fractionString.Length - 1 || fractionString[index] != Group_Close)
                {
                    numerator = denominator = null;
                    return false;
                }
            }
            else
            {
                numerator = denominator = null;
                return false;
            }
        }
        numerator = fractionString[numeratorStartIndex..numeratorEndIndex];
        denominator = fractionString[denominatorStartIndex..denominatorEndIndex];
        return true;
    }

    public static bool TryFormatSimpleFraction<TFraction, TValue>(TFraction fraction, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        where TFraction : struct, ISimpleFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        ReadOnlySpan<char> result;
        if (TValue.IsZero(fraction.Denominator) || TValue.IsNaN(fraction.Denominator))
            result = Format_NaN.AsSpan();
        else
        {
            if (TValue.IsZero(fraction.Numerator))
                return fraction.Numerator.TryFormat(destination, out charsWritten, format, provider ?? _defaultFormatInfo);

            var formatStr = format.IsEmpty ? Default_Number_Format : new string(format);
            provider ??= _defaultFormatInfo;
            result = ("(" + fraction.Numerator.ToString(formatStr, provider) + Separator_Numerator_Denominator + fraction.Denominator.ToString(formatStr, provider) + ")").AsSpan();
        }
        if (result.TryCopyTo(destination))
        {
            charsWritten = result.Length;
            return true;
        }
        charsWritten = 0;
        return false;
    }

    public static bool TryFormatMixedFraction<TFraction, TValue>(TFraction fraction, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        where TFraction : struct, IMixedFraction<TFraction, TValue>?
        where TValue : struct, IBinaryNumber<TValue>
    {
        string str;
        if (TValue.IsZero(fraction.Denominator) || TValue.IsNaN(fraction.Denominator))
            str = Format_NaN;
        else
        {
            if (TValue.IsZero(fraction.Numerator))
                return fraction.Numerator.TryFormat(destination, out charsWritten, format, provider ?? _defaultFormatInfo);
            var formatStr = format.IsEmpty ? Default_Number_Format : new string(format);
            var p = provider ?? _defaultFormatInfo;
            str = fraction.Numerator.ToString(formatStr, p) + Separator_Numerator_Denominator + fraction.Denominator.ToString(formatStr, p);
            if (TValue.IsZero(fraction.WholeNumber))
                str = $"({str})";
            else
            {
                var nfi = provider as NumberFormatInfo ?? _defaultFormatInfo;
                if (char.IsNumber(str[0]))
                    str = "(" + fraction.WholeNumber.ToString(formatStr, p) + (TValue.IsNegative(fraction.Numerator) ? nfi.NegativeSign : nfi.PositiveSign) + str + ")";
                else if (str.StartsWith(nfi.NegativeSign) || str.StartsWith(nfi.PositiveSign))
                    str = "(" + fraction.WholeNumber.ToString(formatStr, p) + str + ")";
                else
                    str = "(" + fraction.WholeNumber.ToString(formatStr, p) + " " + (TValue.IsNegative(fraction.Numerator) ? nfi.NegativeSign : nfi.PositiveSign) + " " + str + ")";
            }
        }
        var result = str.AsSpan();
        if (result.TryCopyTo(destination))
        {
            charsWritten = result.Length;
            return true;
        }
        charsWritten = 0;
        return false;
    }
}
