using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedFraction128 : ISimpleFraction<UnsignedFraction128, ulong, UnsignedMixedFraction192>
{
    #region Static Properties

    public static UnsignedFraction128 One { get; } = new(1UL, 1UL);

    public static UnsignedFraction128 Zero { get; } = new(0UL, 1UL);

    public static UnsignedFraction128 MaxValue { get; } = new(ulong.MaxValue, 1UL);

    public static UnsignedFraction128 MinValue { get; } = new(ulong.MinValue, 1UL);

    public static UnsignedFraction128 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public ulong Numerator { get; }

    public ulong Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedFraction128(ulong numerator, ulong denominator, bool doNotReduce = false)
    {
        if (doNotReduce)
        {
            if (denominator == 0) throw new DivideByZeroException();
        }
        else
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        Numerator = numerator;
        Denominator = denominator;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction192 Add(ulong wholeNumber1, ulong wholeNumber2, UnsignedFraction128 fraction2)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = AddFractions(wholeNumber1, this, wholeNumber2, fraction2);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction128 Add(UnsignedFraction128 fraction)
    {
        (ulong numerator, ulong denominator) = AddSimpleFractions<UnsignedFraction128, ulong>(this, fraction);
        return new(numerator, denominator);
    }

    public int CompareTo(UnsignedFraction128 other) => CompareFractionComponents(Numerator, Denominator, other.Numerator, other.Denominator);

    public UnsignedMixedFraction192 Divide(ulong wholeDividend, ulong wholeDivisor, UnsignedFraction128 divisorFraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = DivideFractions(wholeDividend, this, wholeDivisor, divisorFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction128 Divide(UnsignedFraction128 fraction)
    {
        (ulong numerator, ulong denominator) = DivideSimpleFractions<UnsignedFraction128, ulong>(this, fraction);
        return new(numerator, denominator);
    }

    public bool Equals(UnsignedFraction128 other) => AreSimpleFractionsEqual<UnsignedFraction128, ulong>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedFraction128 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public UnsignedMixedFraction192 Join(ulong wholeNumber) => new(wholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction192 Multiply(ulong wholeMultiplier, ulong wholeMultiplicand, UnsignedFraction128 multiplicandFraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = MultiplyFractions(wholeMultiplier, this, wholeMultiplicand, multiplicandFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction128 Multiply(UnsignedFraction128 fraction)
    {
        (ulong numerator, ulong denominator) = MultiplySimpleFractions<UnsignedFraction128, ulong>(this, fraction);
        return new(numerator, denominator);
    }

    public UnsignedMixedFraction192 Subtract(ulong wholeMinuend, ulong wholeSubtrahend, UnsignedFraction128 subtrahendFraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = SubtractFractions(wholeMinuend, this, wholeSubtrahend, subtrahendFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction128 Subtract(UnsignedFraction128 fraction)
    {
        (ulong numerator, ulong denominator) = SubtractSimpleFractions<UnsignedFraction128, ulong>(this, fraction);
        return new(numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0UL) return double.NaN;
        if (provider is null)
            return (Numerator == 0UL) ? Convert.ToDouble(Numerator) : Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
        return (Numerator == 0UL) ? Convert.ToDouble(Numerator, provider) : Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider);
    }

    public override string ToString() => ToFractionString(Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatSimpleFraction<UnsignedFraction128, ulong>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    static UnsignedFraction128 INumberBase<UnsignedFraction128>.Abs(UnsignedFraction128 value) => value;


    public static UnsignedFraction128 Add(ulong wholeNumber1, UnsignedFraction128 fraction1, ulong wholeNumber2, UnsignedFraction128 fraction2, out ulong sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Add(UnsignedMixedFraction192 fraction1, ulong wholeNumber2, UnsignedFraction128 fraction2, out ulong sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Add(ulong wholeNumber1, UnsignedFraction128 fraction1, UnsignedMixedFraction192 fraction2, out ulong sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Add(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Divide(ulong wholeDividend, UnsignedFraction128 dividendFraction, ulong wholeDivisor, UnsignedFraction128 divisorFraction, out ulong quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Divide(UnsignedMixedFraction192 dividend, ulong wholeDivisor, UnsignedFraction128 divisorFraction, out ulong quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Divide(ulong wholeDividend, UnsignedFraction128 dividendFraction, UnsignedMixedFraction192 divisor, out ulong quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Divide(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Invert(UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Invert(UnsignedFraction128 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedFraction128 value) => value.Denominator == 0;

    public static bool IsNegative(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Log2(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MaxMagnitude(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MaxMagnitudeNumber(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MinMagnitude(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MinMagnitudeNumber(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Multiply(ulong wholeMultiplier, UnsignedFraction128 multiplierFraction, ulong wholeMultiplicand, UnsignedFraction128 multiplicandFraction, out ulong product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Multiply(UnsignedMixedFraction192 multiplier, ulong wholeMultiplicand, UnsignedFraction128 multiplicandFraction, out ulong product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Multiply(ulong wholeMultiplier, UnsignedFraction128 multiplierFraction, UnsignedMixedFraction192 multiplicand, out ulong product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Multiply(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Subtract(ulong wholeMinuend, UnsignedFraction128 minuendFraction, ulong wholeSubtrahend, UnsignedFraction128 subtrahendFraction, out ulong difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Subtract(UnsignedMixedFraction192 minuend, ulong wholeSubtrahend, UnsignedFraction128 subtrahendFraction, out ulong difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Subtract(ulong wholeMinuend, UnsignedFraction128 minuendFraction, UnsignedMixedFraction192 subtrahend, out ulong difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Subtract(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 ToProperFraction(UnsignedFraction128 value, out ulong wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 ToProperFraction(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 ToProperSimplestForm(UnsignedFraction128 value, out ulong wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 ToProperSimplestForm(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 ToSimplestForm(UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        if (TryParseSimpleFraction(s, style, provider, out ulong numerator, out ulong denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), style, provider, out ulong numerator, out ulong denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        if (TryParseSimpleFraction(s, NumberStyles.Integer, provider, out ulong numerator, out ulong denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), NumberStyles.Integer, provider, out ulong numerator, out ulong denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }


    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedFraction128>.Radix => 2;

    static UnsignedFraction128 IAdditiveIdentity<UnsignedFraction128, UnsignedFraction128>.AdditiveIdentity => Zero;

    static UnsignedFraction128 IMultiplicativeIdentity<UnsignedFraction128, UnsignedFraction128>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedFraction128 other) ? CompareTo(other) : -1;

    TypeCode IConvertible.GetTypeCode() => TypeCode.Double;

    bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(ToDouble(provider), provider);

    byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(ToDouble(provider), provider);

    char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(ToDouble(provider), provider);

    DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(ToDouble(provider), provider);

    decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(ToDouble(provider), provider);

    short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(ToDouble(provider), provider);

    int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(ToDouble(provider), provider);

    long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(ToDouble(provider), provider);

    sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(ToDouble(provider), provider);

    float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(ToDouble(provider), provider);

    string IConvertible.ToString(IFormatProvider? provider) => ToFractionString(Numerator, Denominator, provider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToFractionString(Numerator, Denominator, format, formatProvider);

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedFraction128, ulong>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedFraction128>.TryConvertFromChecked<TOther>(TOther value, out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertToChecked<TOther>(UnsignedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertToSaturating<TOther>(UnsignedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertToTruncating<TOther>(UnsignedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }
    #endregion

    #endregion

    #region Static Operators

    public static UnsignedFraction128 operator +(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator +(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator -(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator -(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator ~(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator ++(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator --(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator *(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator /(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator %(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator &(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator |(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator ^(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
