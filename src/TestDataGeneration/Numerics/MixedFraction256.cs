using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction256 : IMixedSignedFraction<MixedFraction256, long, Fraction128>
{
    #region Static Properties

    public static MixedFraction256 NegativeOne { get; } = new(-1L);

    public static MixedFraction256 One { get; } = new(1L);

    public static MixedFraction256 Zero { get; } = new(0L);

    public static MixedFraction256 MaxValue { get; } = new(long.MaxValue, long.MaxValue, 1U);

    public static MixedFraction256 MinValue { get; } = new(long.MinValue, long.MaxValue, 1U);

    public static MixedFraction256 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public long WholeNumber { get; }

    public long Numerator { get; }

    public long Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction256(long wholeNumber, long numerator, long denominator, bool doNotReduce = false, bool doNotMakeProper = false)
    {
        if (doNotReduce)
        {
            if (doNotMakeProper)
            {
                if (denominator == 0) throw new DivideByZeroException();
            }
            else
                wholeNumber = GetProperRational(wholeNumber, numerator, denominator, out numerator);
        }
        else if (doNotMakeProper)
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        else
            wholeNumber = GetNormalizedRational(wholeNumber, numerator, denominator, out numerator, out denominator);
        WholeNumber = wholeNumber;
        Numerator = numerator;
        Denominator = denominator;
    }

    public MixedFraction256(long numerator, long denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0L, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction256(long wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction256 Add(MixedFraction256 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = AddFractions<MixedFraction256, long>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(MixedFraction256 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public MixedFraction256 Divide(MixedFraction256 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = DivideFractions<MixedFraction256, long>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(MixedFraction256 other) => AreMixedFractionsEqual<MixedFraction256, long>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction256 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction256 Multiply(MixedFraction256 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = MultiplyFractions<MixedFraction256, long>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public long Split(out Fraction128 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public MixedFraction256 Subtract(MixedFraction256 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = SubtractFractions<MixedFraction256, long>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0L) return double.NaN;
        if (provider is null)
            return (Numerator == 0L) ? Convert.ToDouble(WholeNumber) : Convert.ToDouble(WholeNumber) + (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator));
        return (Numerator == 0L) ? Convert.ToDouble(WholeNumber, provider) : Convert.ToDouble(WholeNumber, provider) + (Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider));
    }

    public override string ToString() => ToFractionString(WholeNumber, Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatMixedFraction<MixedFraction256, long>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static MixedFraction256 Abs(MixedFraction256 value) => (value.Denominator == 0L) ? value : new(long.Abs(value.Numerator), long.Abs(value.Denominator));

    public static MixedFraction256 Add(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Divide(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Invert(MixedFraction256 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Invert(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Invert(MixedFraction256 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Log2(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MaxMagnitude(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MaxMagnitudeNumber(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MinMagnitude(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MinMagnitudeNumber(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Multiply(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Subtract(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToProperFraction(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToProperSimplestForm(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToSimplestForm(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<MixedFraction256>.Radix => 10;

    static MixedFraction256 IAdditiveIdentity<MixedFraction256, MixedFraction256>.AdditiveIdentity => Zero;

    static MixedFraction256 IMultiplicativeIdentity<MixedFraction256, MixedFraction256>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction256 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<MixedFraction256, long>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction256>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertToChecked<TOther>(MixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertToSaturating<TOther>(MixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertToTruncating<TOther>(MixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction256 operator +(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator +(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator -(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator -(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator ~(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator ++(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator --(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator *(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator /(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator %(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator &(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator |(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator ^(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}