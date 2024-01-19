using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.RegularExpressions;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Helper class for fractional values.
/// </summary>
public static class Fraction
{
    public const char Separator_Numerator_Denominator = '∕';

    public const char Negative_Prefix_Char = '-';

    public static string ToFractionString<T>(T wholeNumber, T numerator, T denominator)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(numerator)) return $"{wholeNumber}";
        if (T.IsZero(wholeNumber)) return $"{numerator}{Separator_Numerator_Denominator}{denominator}";
        return $"{wholeNumber} {numerator}{Separator_Numerator_Denominator}{denominator}";
    }
    
    public static string ToFractionString<T>(T numerator, T denominator)
        where T : struct, IBinaryNumber<T>
    {
        if (T.IsZero(numerator)) return $"{numerator}";
        return $"{numerator}{Separator_Numerator_Denominator}{denominator}";
    }
    
    public static readonly Regex FractionStringRegex = new(@"^(?:(?<wn>[−-])|\+)?(?<wh>\d+)([∕/](?:(?<dn0>[−-])|\+)?0*(?<d0>[1-9]\d*)|(\s+(?:(?<nn0>[−-])|\+)?|(?<nn1>[−-])|\+)(?<n>\d+)[∕/](?:(?<dn1>[−-])|\+)?0*(?<d1>[1-9]\d*))?$", RegexOptions.Compiled);
    
    /// <summary>
    /// Parses the fraction component tokens from a string representation of a fraction.
    /// </summary>
    /// <param name="fractionString">A string representation of a fraction.</param>
    /// <returns><see langword="true"/> if the components could be parsed; ottherwise, <see langword="false"/> if <paramref name="fractionString"/> was not properly formatted.</returns>
    public static bool TryGetFractionTokens(string fractionString, [NotNullWhen(true)] out string? wholeNumber, [NotNullWhen(true)] out string? numerator, [NotNullWhen(true)] out string? denominator,
        out bool isNegative)
    {
        if (!string.IsNullOrEmpty(fractionString))
        {
            Match match = FractionStringRegex.Match(fractionString);
            if (match.Success)
            {
                var g = match.Groups["d0"];
                if (g.Success)
                {
                    isNegative = match.Groups["wn"].Success != match.Groups["dn0"].Success;
                    wholeNumber = string.Empty;
                    numerator = match.Groups["wh"].Value;
                    denominator = g.Value;
                    return true;
                }
                wholeNumber = match.Groups["wh"].Value;
                if ((g = match.Groups["n"]).Success)
                {
                    numerator = g.Value;
                    denominator = match.Groups["d1"].Value;
                    isNegative = (match.Groups["nn0"].Success || match.Groups["nn1"].Success) ? match.Groups["wn"].Success == match.Groups["dn1"].Success : match.Groups["wn"].Success != match.Groups["dn1"].Success;
                }
                else
                {
                    numerator = denominator = string.Empty;
                    isNegative = match.Groups["wn"].Success;
                }
                return true;
            }
        }
        isNegative = false;
        wholeNumber = numerator = denominator = null;
        return false;
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

    public static T GetProperRational<T>(T wholeNumber, T numerator, T denominator,
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

    public static T GetNormalizedRational<T>(T wholeNumber, T numerator, T denominator, out T properNumerator, out T properDenominator)
        where T : struct, IBinaryNumber<T>
    {
        properNumerator = GetSimplifiedRational(numerator, denominator, out properDenominator);

        if (T.IsZero(properNumerator))  return wholeNumber;

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
            properNumerator = properNumerator % properDenominator;
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

    public static void ToCommonDenominator<T>(ref T numerator1, ref T denominator1, ref T numerator2, ref T denominator2)
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
                T lcm = GetLCM(denominator1, denominator2);
                numerator1 *= lcm / denominator1;
                numerator2 *= lcm / denominator2;
                denominator1 = denominator2 = lcm;
            }
        }
    }

    public static int Compare<T>(T numerator1, T denominator1, T numerator2, T denominator2)
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

    public static int Compare<T>(T wholeNumber1, T numerator1, T denominator1, T wholeNumber2, T numerator2, T denominator2)
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
