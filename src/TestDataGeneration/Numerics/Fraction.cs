using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public static class Fraction
{
    public const char Separator_Numerator_Denominator = '∕';

    public const char AltSeparator_Numerator_Denominator = '/';

    public const char Positive_Prefix_Char = '+';

    public const char Negative_Prefix_Char = '-';

    public const char Negative_Prefix_Decimal = '.';

    public const char AltNegative_Prefix_Char = '−';

    private const char NumberChar_0 = '0';

    private const char NumberChar_1 = '1';

    private const char NumberChar_2 = '2';

    private const char NumberChar_3 = '3';

    private const char NumberChar_4 = '4';

    private const char NumberChar_5 = '5';

    private const char NumberChar_6 = '6';

    private const char NumberChar_7 = '7';

    private const char NumberChar_8 = '8';

    private const char NumberChar_9 = '9';

    private static ImmutableArray<char> _numberchars = new char[] { NumberChar_0, NumberChar_1, NumberChar_2, NumberChar_3, NumberChar_4, NumberChar_5, NumberChar_6, NumberChar_7, NumberChar_8, NumberChar_9 }.ToImmutableArray();

    internal static bool TryParseFractionComponents(string pattern, [NotNullWhen(true)] out string? wholeNumber, [NotNullWhen(true)] out string? numerator, [NotNullWhen(true)] out string? denominator,
        out bool isNegative)
    {
        if (string.IsNullOrEmpty(pattern))
        {
            isNegative = false;
            wholeNumber = numerator = denominator = null;
            return false;
        }

        bool incrementNext(ref int value)
        {
            return ++value < pattern.Length;
        }

        bool moveToEndOfNumber(int start, out int end)
        {
            end = start;
            if (!char.IsNumber(pattern[end])) return false;
            do
            {
                if (!incrementNext(ref end)) return true;
            }
            while (char.IsNumber(pattern[end]));
            if (pattern[end] != Negative_Prefix_Decimal) return true;
            if (!(incrementNext(ref end) && char.IsNumber(pattern[end]))) return false;
            do
            {
                if (!incrementNext(ref end)) break;
            }
            while (char.IsNumber(pattern[end]));
            return true;
        }

        bool moveToEndOfWhiteSpace(int start, out int end)
        {
            end = start;
            if (!char.IsWhiteSpace(pattern[start])) return false;
            do
            {
                if (!incrementNext(ref end)) return false;
            }
            while (char.IsWhiteSpace(pattern[start]));
            return true;
        }

        int wholeNumberStart, wholeNumberEnd;
        switch (pattern[0])
        {
            case Negative_Prefix_Char:
            case AltNegative_Prefix_Char:
                isNegative = true;
                wholeNumberStart = 1;
                if (pattern.Length == 1 || !moveToEndOfNumber(wholeNumberStart, out wholeNumberEnd))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                // ^-\d+(\.\d+)?\D
                break;
            case Positive_Prefix_Char:
                isNegative = false;
                wholeNumberStart = 1;
                if (pattern.Length == 1 || !moveToEndOfNumber(wholeNumberStart, out wholeNumberEnd))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                // ^\+\d+(\.\d+)?\D
                break;
            default:
                isNegative = false;
                wholeNumberStart = 0;
                if (!moveToEndOfNumber(wholeNumberStart, out wholeNumberEnd))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                // ^\d+(\.\d+)?\D
                break;
        }
        int numeratorStart, numeratorEnd, denominatorStart;
        // ^[+-]?\d+(\.\d+)?\D
        switch (pattern[wholeNumberEnd])
        {
            case Negative_Prefix_Char:
            case AltNegative_Prefix_Char:
                isNegative = !isNegative;
                numeratorStart = wholeNumberEnd;
                if (!(incrementNext(ref numeratorStart) && moveToEndOfNumber(numeratorStart, out numeratorEnd) && pattern[numeratorEnd] switch
                {
                    Separator_Numerator_Denominator or AltSeparator_Numerator_Denominator => true,
                    _ => false,
                }))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                denominatorStart = numeratorEnd;
                // ^[+-]?\d+(\.\d+)?-\d+(\.\d+)?/
                break;
            case Positive_Prefix_Char:
                // ^[+-?]\d+(\.\d+)?\+
                numeratorStart = wholeNumberEnd;
                if (!incrementNext(ref numeratorStart))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                if (char.IsWhiteSpace(pattern[numeratorStart]))
                {
                    if (!moveToEndOfWhiteSpace(numeratorStart, out numeratorStart))
                    {
                        wholeNumber = numerator = denominator = null;
                        return false;
                    }
                }
                switch (pattern[numeratorStart])
                {
                    case Negative_Prefix_Char:
                    case AltNegative_Prefix_Char:
                        isNegative = !isNegative;
                        if (!incrementNext(ref numeratorStart))
                        {
                            wholeNumber = numerator = denominator = null;
                            return false;
                        }
                        break;
                }
                if (!(moveToEndOfNumber(numeratorStart, out numeratorEnd) && pattern[numeratorEnd] switch
                {
                    Separator_Numerator_Denominator or AltSeparator_Numerator_Denominator => true,
                    _ => false,
                }))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                denominatorStart = numeratorEnd;
                // ^[+-?]\d+(\.\d+)?\+\s*-?\d+(\.\d+)?/
                break;
            case Separator_Numerator_Denominator:
            case AltSeparator_Numerator_Denominator:
                numeratorEnd = denominatorStart = wholeNumberEnd;
                wholeNumberEnd = numeratorStart = wholeNumberStart;
                if (!incrementNext(ref denominatorStart))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                // ^[+-?]\d+(\.\d+)?/
                break;
            default:
                if (!moveToEndOfWhiteSpace(wholeNumberEnd, out numeratorStart))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                switch (pattern[numeratorStart])
                {
                    case Negative_Prefix_Char:
                    case AltNegative_Prefix_Char:
                        isNegative = !isNegative;
                        if (!incrementNext(ref numeratorStart))
                        {
                            wholeNumber = numerator = denominator = null;
                            return false;
                        }
                        // ^[+-]?\d+(\.\d+)?\s+-(?=\d)
                        break;
                    case Positive_Prefix_Char:
                        if (!incrementNext(ref numeratorStart))
                        {
                            wholeNumber = numerator = denominator = null;
                            return false;
                        }
                        // ^[+-]?\d+(\.\d+)?\s+\+
                        switch (pattern[numeratorStart])
                        {
                            case Negative_Prefix_Char:
                            case AltNegative_Prefix_Char:
                                isNegative = !isNegative;
                                if (!incrementNext(ref numeratorStart))
                                {
                                    wholeNumber = numerator = denominator = null;
                                    return false;
                                }
                                // ^[+-]?\d+(\.\d+)?\s+\+-
                                break;
                            default:
                                if (char.IsWhiteSpace(pattern[numeratorStart]))
                                {
                                    if (!moveToEndOfWhiteSpace(numeratorStart, out numeratorStart))
                                    {
                                        wholeNumber = numerator = denominator = null;
                                        return false;
                                    }
                                    // ^[+-]?\d+(\.\d+)?\s+\+\s+
                                    switch (pattern[numeratorStart])
                                    {
                                        case Negative_Prefix_Char:
                                        case AltNegative_Prefix_Char:
                                            isNegative = !isNegative;
                                            if (!incrementNext(ref numeratorStart))
                                            {
                                                wholeNumber = numerator = denominator = null;
                                                return false;
                                            }
                                            break;
                                    }
                                    // ^[+-]?\d+(\.\d+)?\s+\+\s+-?
                                }
                                else
                                {
                                    switch (pattern[numeratorStart])
                                    {
                                        case Negative_Prefix_Char:
                                        case AltNegative_Prefix_Char:
                                            isNegative = !isNegative;
                                            if (!incrementNext(ref numeratorStart))
                                            {
                                                wholeNumber = numerator = denominator = null;
                                                return false;
                                            }
                                            break;
                                    }
                                    // ^[+-]?\d+(\.\d+)?\s+\+-?
                                }
                                // ^[+-]?\d+(\.\d+)?\s+\+\s*-?(?=\d)
                                break;

                        }
                        break;
                }
                if (!(moveToEndOfNumber(numeratorStart, out numeratorEnd) && pattern[numeratorEnd] switch
                {
                    Separator_Numerator_Denominator or AltSeparator_Numerator_Denominator => true,
                    _ => false,
                }))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                denominatorStart = numeratorEnd;
                // ^[+-]?\d+(\.\d+)?\s+(-|\+\s*-?)\d+(\.\d+)?/
                break;
        }
        if (!incrementNext(ref denominatorStart))
        {
            wholeNumber = numerator = denominator = null;
            return false;
        }
        switch (pattern[denominatorStart])
        {
            case Negative_Prefix_Char:
            case AltNegative_Prefix_Char:
                isNegative = !isNegative;
                if (!incrementNext(ref denominatorStart))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                break;
            case Positive_Prefix_Char:
                if (!incrementNext(ref denominatorStart))
                {
                    wholeNumber = numerator = denominator = null;
                    return false;
                }
                break;
        }
        if (moveToEndOfNumber(denominatorStart, out int denominatorEnd) && denominatorEnd == pattern.Length)
        {
            wholeNumber = (wholeNumberStart == wholeNumberEnd) ? string.Empty : (wholeNumberStart > 0) ? pattern[wholeNumberStart..wholeNumberEnd] : pattern[..wholeNumberEnd];
            numerator = pattern[numeratorStart..numeratorEnd];
            denominator = pattern[denominatorStart..];
            return true;
        }
        wholeNumber = numerator = denominator = null;
        return false;
    }

    internal static T GetGCD<T>(T d1, params T[] denominators)
        where T : struct, IBinaryNumber<T>
    {
        if (denominators == null || denominators.Length == 0)
            return d1;
        T gcd = T.Abs(d1);
        foreach (T d in denominators)
        {
            T b;
            if (d.CompareTo(gcd) > 0)
            {
                b = gcd;
                gcd = T.Abs(d);
            }
            else
                b = T.Abs(d);
            while (T.IsPositive(b))
            {
                T rem = gcd % b;
                gcd = b;
                b = rem;
            }
        }

        return gcd;
    }

    internal static T GetLCM<T>(T d1, T d2, out T secondMultiplier)
        where T : struct, IBinaryNumber<T>
    {
        T zero = default;
        if (d1.CompareTo(zero) < 0)
            return GetLCM(T.Abs(d1), d2, out secondMultiplier);

        if (d2.CompareTo(zero) < 0)
            return GetLCM(d1, T.Abs(d2), out secondMultiplier);

        if (d1.Equals(d2))
        {
            secondMultiplier = T.One;
            return secondMultiplier;
        }

        if (d1.CompareTo(d2) < 0)
        {
            secondMultiplier = GetLCM(d2, d1, out d1);
            return d1;
        }

        secondMultiplier = d1;

        while (!(secondMultiplier % d2).Equals(zero))
            secondMultiplier += d1;

        return GetSimplifiedRational(secondMultiplier / d1, secondMultiplier, out secondMultiplier);
    }

    internal static T GetSimplifiedRational<T>(T n, T d, out T denominator)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(d)) throw new DivideByZeroException();

        if (T.IsZero(n))
        {
            denominator = T.One;
            return T.Zero;
        }

        if (n.Equals(d))
        {
            denominator = T.One;
            return T.One;
        }

        if (T.IsNegative(d))
        {

            d = T.Zero - d;
            n = T.Zero - n;
        }
        T gcd = GetGCD(n, d);
        denominator = d / gcd;
        return n / gcd;
    }

    internal static T GetProperRational<T>(T wholeNumber, T numerator, T denominator,
            out T properNumerator)
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

    internal static T GetNormalizedRational<T>(T wholeNumber, T numerator, T denominator, out T properNumerator, out T properDenominator)
        where T : struct, IBinaryNumber<T>
    {
        numerator = GetSimplifiedRational(numerator, denominator, out properDenominator);

        if (T.IsZero(numerator))
        {
            properNumerator = numerator;
            return wholeNumber;
        }

        if (properDenominator.Equals(T.One))
        {
            properNumerator = T.Zero;
            return wholeNumber + numerator;
        }

        if (numerator > properDenominator)
        {
            properNumerator = numerator % properDenominator;
            wholeNumber = T.IsNegative(wholeNumber)
                ? wholeNumber - ((numerator - properNumerator) / properDenominator)
                : wholeNumber + ((numerator - properNumerator) / properDenominator);
            properNumerator = GetSimplifiedRational(properNumerator, properDenominator, out properDenominator);
        }
        else
            properNumerator = numerator;

        if (T.IsZero(wholeNumber))
            return wholeNumber;

        if (T.IsNegative(properNumerator))
        {
            wholeNumber = T.IsNegative(wholeNumber) ? wholeNumber + T.One : wholeNumber - T.One;
            properNumerator += properDenominator;
        }

        return wholeNumber;
    }

    internal static T GetInvertedRational<T>(T w, T n, T d, out T numerator, out T denominator)
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

    internal static void ToCommonDenominator<T>(ref T numerator1, ref T denominator1, ref T numerator2, ref T denominator2)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(denominator1) || T.IsZero(denominator2)) throw new DivideByZeroException();

        if (T.IsZero(numerator1))
            denominator1 = denominator2;
        else if (T.IsZero(numerator2))
            denominator2 = denominator1;
        else if (!denominator1.Equals(denominator2))
        {
            numerator1 = GetSimplifiedRational(numerator1, denominator1, out denominator1);
            numerator2 = GetSimplifiedRational(numerator2, denominator2, out denominator2);

            if (denominator1.Equals(T.One))
                numerator1 *= denominator2;
            else if (denominator2.Equals(T.One))
                numerator2 *= denominator1;
            else if (!denominator1.Equals(denominator2))
            {
                T m1 = GetLCM(denominator1, denominator2, out _);
                numerator1 *= m1;
                denominator1 *= m1;
                numerator2 *= m1;
                denominator2 *= m1;
            }
        }
    }

    internal static int Compare<T>(T numerator1, T denominator1, T numerator2, T denominator2)
        where T : struct, IBinaryNumber<T>
    {
        ;
        if (T.IsZero(numerator1) || T.IsZero(numerator2) || denominator1 == denominator2)
        {
            if (T.IsZero(denominator1) || T.IsZero(denominator2)) throw new DivideByZeroException();
        }
        else
            ToCommonDenominator(ref numerator1, ref denominator1, ref numerator2, ref denominator2);
        return numerator1.CompareTo(numerator2);
    }

    internal static int Compare<T>(T wholeNumber1, T numerator1, T denominator1, T wholeNumber2, T numerator2, T denominator2)
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
}
