using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction128 : IMixedFraction<UnsignedMixedFraction128, uint, UnsignedFraction64>
{
    #region Static Properties

    public static UnsignedMixedFraction128 One { get; } = new(1U);

    public static UnsignedMixedFraction128 Zero { get; } = new(0U);

    public static UnsignedMixedFraction128 MaxValue { get; } = new(uint.MaxValue, uint.MaxValue, 1U);

    public static UnsignedMixedFraction128 MinValue { get; } = new(uint.MinValue, uint.MaxValue, 1U);

    public static UnsignedMixedFraction128 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public uint WholeNumber { get; }

    public uint Numerator { get; }

    public uint Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedMixedFraction128(uint wholeNumber, uint numerator, uint denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction128(uint numerator, uint denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0U, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction128(uint wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction128 Add(UnsignedMixedFraction128 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = AddFractions<UnsignedMixedFraction128, uint>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction128 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public UnsignedMixedFraction128 Divide(UnsignedMixedFraction128 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = DivideFractions<UnsignedMixedFraction128, uint>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction128 other) => AreMixedFractionsEqual<UnsignedMixedFraction128, uint>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction128 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction128 Multiply(UnsignedMixedFraction128 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = MultiplyFractions<UnsignedMixedFraction128, uint>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public uint Split(out UnsignedFraction64 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public UnsignedMixedFraction128 Subtract(UnsignedMixedFraction128 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = SubtractFractions<UnsignedMixedFraction128, uint>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0U) return double.NaN;
        if (provider is null)
            return (Numerator == 0U) ? Convert.ToDouble(WholeNumber) : Convert.ToDouble(WholeNumber) + (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator));
        return (Numerator == 0U) ? Convert.ToDouble(WholeNumber, provider) : Convert.ToDouble(WholeNumber, provider) + (Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider));
    }

    public override string ToString() => ToFractionString(WholeNumber, Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatMixedFraction<UnsignedMixedFraction128, uint>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static UnsignedMixedFraction128 Abs(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Add(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Divide(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Invert(UnsignedMixedFraction128 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Invert(UnsignedMixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Invert(UnsignedMixedFraction128 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Log2(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MaxMagnitude(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MaxMagnitudeNumber(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MinMagnitude(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MinMagnitudeNumber(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Multiply(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Subtract(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperFraction(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperSimplestForm(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToSimplestForm(UnsignedMixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedMixedFraction128>.Radix => 10;

    static UnsignedMixedFraction128 IAdditiveIdentity<UnsignedMixedFraction128, UnsignedMixedFraction128>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction128 IMultiplicativeIdentity<UnsignedMixedFraction128, UnsignedMixedFraction128>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction128 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction128, uint>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertToChecked<TOther>(UnsignedMixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertToSaturating<TOther>(UnsignedMixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertToTruncating<TOther>(UnsignedMixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction128 operator +(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator +(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator -(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator -(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator ~(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator ++(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator --(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator *(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator /(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator %(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator &(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator |(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator ^(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}