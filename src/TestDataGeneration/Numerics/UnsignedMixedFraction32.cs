using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction32 : IMixedFraction<UnsignedMixedFraction32, byte, UnsignedFraction16>
{
    #region Static Properties

    public static UnsignedMixedFraction32 One { get; } = new(1);

    public static UnsignedMixedFraction32 Zero { get; } = new(0);

    public static UnsignedMixedFraction32 MaxValue { get; } = new(byte.MaxValue, byte.MaxValue, 1);

    public static UnsignedMixedFraction32 MinValue { get; } = new(byte.MinValue, byte.MaxValue, 1);

    public static UnsignedMixedFraction32 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public byte WholeNumber { get; }

    public byte Numerator { get; }

    public byte Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedMixedFraction32(byte wholeNumber, byte numerator, byte denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction32(byte numerator, byte denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction32(byte wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction32 Add(UnsignedMixedFraction32 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = AddFractions<UnsignedMixedFraction32, byte>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction32 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public UnsignedMixedFraction32 Divide(UnsignedMixedFraction32 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = DivideFractions<UnsignedMixedFraction32, byte>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction32 other) => AreMixedFractionsEqual<UnsignedMixedFraction32, byte>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction32 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction32 Multiply(UnsignedMixedFraction32 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = MultiplyFractions<UnsignedMixedFraction32, byte>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public byte Split(out UnsignedFraction16 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public UnsignedMixedFraction32 Subtract(UnsignedMixedFraction32 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = SubtractFractions<UnsignedMixedFraction32, byte>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0) return double.NaN;
        if (provider is null)
            return (Numerator == 0) ? Convert.ToDouble(WholeNumber) : Convert.ToDouble(WholeNumber) + (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator));
        return (Numerator == 0) ? Convert.ToDouble(WholeNumber, provider) : Convert.ToDouble(WholeNumber, provider) + (Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider));
    }

    public override string ToString() => ToFractionString(WholeNumber, Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatMixedFraction<UnsignedMixedFraction32, byte>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static UnsignedMixedFraction32 Abs(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Add(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Divide(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Invert(UnsignedMixedFraction32 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Invert(UnsignedMixedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Invert(UnsignedMixedFraction32 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Log2(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MaxMagnitude(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MaxMagnitudeNumber(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MinMagnitude(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MinMagnitudeNumber(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Multiply(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Subtract(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToProperFraction(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToProperSimplestForm(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToSimplestForm(UnsignedMixedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedMixedFraction32>.Radix => 10;

    static UnsignedMixedFraction32 IAdditiveIdentity<UnsignedMixedFraction32, UnsignedMixedFraction32>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction32 IMultiplicativeIdentity<UnsignedMixedFraction32, UnsignedMixedFraction32>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction32 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction32, byte>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertToChecked<TOther>(UnsignedMixedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertToSaturating<TOther>(UnsignedMixedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertToTruncating<TOther>(UnsignedMixedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction32 operator +(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator +(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator -(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator -(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator ~(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator ++(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator --(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator *(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator /(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator %(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator &(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator |(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator ^(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}