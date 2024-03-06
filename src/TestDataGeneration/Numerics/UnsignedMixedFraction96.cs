using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction96 : IMixedFraction<UnsignedMixedFraction96, uint, UnsignedFraction64>
{
    #region Static Properties

    public static UnsignedMixedFraction96 One { get; } = new(1U);

    public static UnsignedMixedFraction96 Zero { get; } = new(0U);

    public static UnsignedMixedFraction96 MaxValue { get; } = new(uint.MaxValue, uint.MaxValue, 1U);

    public static UnsignedMixedFraction96 MinValue { get; } = new(uint.MinValue, uint.MaxValue, 1U);

    public static UnsignedMixedFraction96 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public uint WholeNumber { get; }

    public uint Numerator { get; }

    public uint Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedMixedFraction96(uint wholeNumber, uint numerator, uint denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction96(uint numerator, uint denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0U, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction96(uint wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction96 Add(UnsignedMixedFraction96 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = AddFractions<UnsignedMixedFraction96, uint>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction96 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public UnsignedMixedFraction96 Divide(UnsignedMixedFraction96 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = DivideFractions<UnsignedMixedFraction96, uint>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction96 other) => AreMixedFractionsEqual<UnsignedMixedFraction96, uint>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction96 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction96 Multiply(UnsignedMixedFraction96 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = MultiplyFractions<UnsignedMixedFraction96, uint>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public uint Split(out UnsignedFraction64 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public UnsignedMixedFraction96 Subtract(UnsignedMixedFraction96 fraction)
    {
        (uint wholeNumber, uint numerator, uint denominator) = SubtractFractions<UnsignedMixedFraction96, uint>(this, fraction);
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
        TryFormatMixedFraction<UnsignedMixedFraction96, uint>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    static UnsignedMixedFraction96 INumberBase<UnsignedMixedFraction96>.Abs(UnsignedMixedFraction96 value) => value;

    public static UnsignedMixedFraction96 Add(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Divide(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Invert(UnsignedMixedFraction96 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Invert(UnsignedMixedFraction96 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Invert(UnsignedMixedFraction96 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction96 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (value.Numerator > value.Denominator && value.Numerator % value.Denominator == 0));

    public static bool IsFinite(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction96 value) => value.Denominator == 0;

    public static bool IsNegative(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction96 value) => value.Denominator != 0 && ((value.Numerator != 0) ? value.Numerator > value.Denominator &&
        value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 != 0 : value.WholeNumber % 2 != 0);

    public static bool IsPositive(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction96 value) => double.IsPow2(value.ToDouble());

    public static bool IsProperFraction(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction96 value) => value.Numerator == 0 && value.WholeNumber == 0 && value.Denominator != 0;

    public static UnsignedMixedFraction96 Log2(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 MaxMagnitude(UnsignedMixedFraction96 x, UnsignedMixedFraction96 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction96 MaxMagnitudeNumber(UnsignedMixedFraction96 x, UnsignedMixedFraction96 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction96 MinMagnitude(UnsignedMixedFraction96 x, UnsignedMixedFraction96 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction96 MinMagnitudeNumber(UnsignedMixedFraction96 x, UnsignedMixedFraction96 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction96 Multiply(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 Subtract(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 ToProperFraction(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 ToProperSimplestForm(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 ToSimplestForm(UnsignedMixedFraction96 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction96 result)
    {
        if (TryParseMixedFraction(s, style, provider, out uint wholeNumber, out uint numerator, out uint denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction96 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out uint wholeNumber, out uint numerator, out uint denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction96 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer, provider, out uint wholeNumber, out uint numerator, out uint denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction96 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer, provider, out uint wholeNumber, out uint numerator, out uint denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedMixedFraction96>.Radix => 2;

    static UnsignedMixedFraction96 IAdditiveIdentity<UnsignedMixedFraction96, UnsignedMixedFraction96>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction96 IMultiplicativeIdentity<UnsignedMixedFraction96, UnsignedMixedFraction96>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction96 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction96, uint>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedMixedFraction96>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction96 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction96>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction96 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction96>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction96 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction96>.TryConvertToChecked<TOther>(UnsignedMixedFraction96 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction96>.TryConvertToSaturating<TOther>(UnsignedMixedFraction96 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction96>.TryConvertToTruncating<TOther>(UnsignedMixedFraction96 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction96 operator +(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator +(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator -(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator -(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator ~(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator ++(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator --(UnsignedMixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator *(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator /(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator %(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator &(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator |(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction96 operator ^(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction96 left, UnsignedMixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}