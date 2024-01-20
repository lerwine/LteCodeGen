using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedFraction16 : ISimpleFraction<UnsignedFraction16, byte, UnsignedMixedFraction32>
{
    #region Static Properties

    public static UnsignedFraction16 One { get; } = new(1, 1);

    public static UnsignedFraction16 Zero { get; } = new(0, 1);

    public static UnsignedFraction16 MaxValue { get; } = new(byte.MaxValue, 1);

    public static UnsignedFraction16 MinValue { get; } = new(byte.MinValue, 1);

    public static UnsignedFraction16 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public byte Numerator { get; }

    public byte Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedFraction16(byte numerator, byte denominator, bool doNotReduce = false)
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

    public UnsignedMixedFraction32 Add(byte wholeNumber1, byte wholeNumber2, UnsignedFraction16 fraction2)
    {
        (byte wholeNumber, byte numerator, byte denominator) = AddFractions(wholeNumber1, this, wholeNumber2, fraction2);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction16 Add(UnsignedFraction16 fraction)
    {
        (byte numerator, byte denominator) = AddSimpleFractions<UnsignedFraction16, byte>(this, fraction);
        return new(numerator, denominator);
    }

    public int CompareTo(UnsignedFraction16 other) => CompareFractionComponents(Numerator, Denominator, other.Numerator, other.Denominator);

    public UnsignedMixedFraction32 Divide(byte wholeDividend, byte wholeDivisor, UnsignedFraction16 divisorFraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = DivideFractions(wholeDividend, this, wholeDivisor, divisorFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction16 Divide(UnsignedFraction16 fraction)
    {
        (byte numerator, byte denominator) = DivideSimpleFractions<UnsignedFraction16, byte>(this, fraction);
        return new(numerator, denominator);
    }

    public bool Equals(UnsignedFraction16 other) => AreSimpleFractionsEqual<UnsignedFraction16, byte>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedFraction16 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public UnsignedMixedFraction32 Join(byte wholeNumber) => new(wholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction32 Multiply(byte wholeMultiplier, byte wholeMultiplicand, UnsignedFraction16 multiplicandFraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = MultiplyFractions(wholeMultiplier, this, wholeMultiplicand, multiplicandFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction16 Multiply(UnsignedFraction16 fraction)
    {
        (byte numerator, byte denominator) = MultiplySimpleFractions<UnsignedFraction16, byte>(this, fraction);
        return new(numerator, denominator);
    }

    public UnsignedMixedFraction32 Subtract(byte wholeMinuend, byte wholeSubtrahend, UnsignedFraction16 subtrahendFraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = SubtractFractions(wholeMinuend, this, wholeSubtrahend, subtrahendFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public UnsignedFraction16 Subtract(UnsignedFraction16 fraction)
    {
        (byte numerator, byte denominator) = SubtractSimpleFractions<UnsignedFraction16, byte>(this, fraction);
        return new(numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0) return double.NaN;
        if (provider is null)
            return (Numerator == 0) ? Convert.ToDouble(Numerator) : Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
        return (Numerator == 0) ? Convert.ToDouble(Numerator, provider) : Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider);
    }

    public override string ToString() => ToFractionString(Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatSimpleFraction<UnsignedFraction16, byte>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static UnsignedFraction16 Abs(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Add(byte wholeNumber1, UnsignedFraction16 fraction1, byte wholeNumber2, UnsignedFraction16 fraction2, out byte sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Add(UnsignedMixedFraction32 fraction1, byte wholeNumber2, UnsignedFraction16 fraction2, out byte sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Add(byte wholeNumber1, UnsignedFraction16 fraction1, UnsignedMixedFraction32 fraction2, out byte sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Add(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Divide(byte wholeDividend, UnsignedFraction16 dividendFraction, byte wholeDivisor, UnsignedFraction16 divisorFraction, out byte quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Divide(UnsignedMixedFraction32 dividend, byte wholeDivisor, UnsignedFraction16 divisorFraction, out byte quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Divide(byte wholeDividend, UnsignedFraction16 dividendFraction, UnsignedMixedFraction32 divisor, out byte quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Divide(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Invert(UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Invert(UnsignedFraction16 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Log2(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 MaxMagnitude(UnsignedFraction16 x, UnsignedFraction16 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 MaxMagnitudeNumber(UnsignedFraction16 x, UnsignedFraction16 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 MinMagnitude(UnsignedFraction16 x, UnsignedFraction16 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 MinMagnitudeNumber(UnsignedFraction16 x, UnsignedFraction16 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Multiply(byte wholeMultiplier, UnsignedFraction16 multiplierFraction, byte wholeMultiplicand, UnsignedFraction16 multiplicandFraction, out byte product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Multiply(UnsignedMixedFraction32 multiplier, byte wholeMultiplicand, UnsignedFraction16 multiplicandFraction, out byte product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Multiply(byte wholeMultiplier, UnsignedFraction16 multiplierFraction, UnsignedMixedFraction32 multiplicand, out byte product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Multiply(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Subtract(byte wholeMinuend, UnsignedFraction16 minuendFraction, byte wholeSubtrahend, UnsignedFraction16 subtrahendFraction, out byte difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Subtract(UnsignedMixedFraction32 minuend, byte wholeSubtrahend, UnsignedFraction16 subtrahendFraction, out byte difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 Subtract(byte wholeMinuend, UnsignedFraction16 minuendFraction, UnsignedMixedFraction32 subtrahend, out byte difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Subtract(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 ToProperFraction(UnsignedFraction16 value, out byte wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToProperFraction(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 ToProperSimplestForm(UnsignedFraction16 value, out byte wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToProperSimplestForm(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 ToSimplestForm(UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction16 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedFraction16>.Radix => 10;

    static UnsignedFraction16 IAdditiveIdentity<UnsignedFraction16, UnsignedFraction16>.AdditiveIdentity => Zero;

    static UnsignedFraction16 IMultiplicativeIdentity<UnsignedFraction16, UnsignedFraction16>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedFraction16 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedFraction16, byte>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedFraction16>.TryConvertFromChecked<TOther>(TOther value, out UnsignedFraction16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction16>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedFraction16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction16>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedFraction16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction16>.TryConvertToChecked<TOther>(UnsignedFraction16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction16>.TryConvertToSaturating<TOther>(UnsignedFraction16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction16>.TryConvertToTruncating<TOther>(UnsignedFraction16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedFraction16 operator +(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator +(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator -(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator -(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator ~(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator ++(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator --(UnsignedFraction16 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator *(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator /(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator %(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator &(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator |(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction16 operator ^(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedFraction16 left, UnsignedFraction16 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
