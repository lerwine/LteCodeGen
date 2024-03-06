using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction24 : IMixedFraction<UnsignedMixedFraction24, byte, UnsignedFraction16>
{
    #region Static Properties

    public static UnsignedMixedFraction24 One { get; } = new(1);

    public static UnsignedMixedFraction24 Zero { get; } = new(0);

    public static UnsignedMixedFraction24 MaxValue { get; } = new(byte.MaxValue, byte.MaxValue, 1);

    public static UnsignedMixedFraction24 MinValue { get; } = new(byte.MinValue, byte.MaxValue, 1);

    public static UnsignedMixedFraction24 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public byte WholeNumber { get; }

    public byte Numerator { get; }

    public byte Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedMixedFraction24(byte wholeNumber, byte numerator, byte denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction24(byte numerator, byte denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction24(byte wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction24 Add(UnsignedMixedFraction24 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = AddFractions<UnsignedMixedFraction24, byte>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction24 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public UnsignedMixedFraction24 Divide(UnsignedMixedFraction24 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = DivideFractions<UnsignedMixedFraction24, byte>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction24 other) => AreMixedFractionsEqual<UnsignedMixedFraction24, byte>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction24 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction24 Multiply(UnsignedMixedFraction24 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = MultiplyFractions<UnsignedMixedFraction24, byte>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public byte Split(out UnsignedFraction16 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public UnsignedMixedFraction24 Subtract(UnsignedMixedFraction24 fraction)
    {
        (byte wholeNumber, byte numerator, byte denominator) = SubtractFractions<UnsignedMixedFraction24, byte>(this, fraction);
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
        TryFormatMixedFraction<UnsignedMixedFraction24, byte>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    static UnsignedMixedFraction24 INumberBase<UnsignedMixedFraction24>.Abs(UnsignedMixedFraction24 value) => value;

    public static UnsignedMixedFraction24 Add(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Divide(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Invert(UnsignedMixedFraction24 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Invert(UnsignedMixedFraction24 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Invert(UnsignedMixedFraction24 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction24 value) => value.Denominator != 0 && ((value.Numerator == 0) ? value.WholeNumber % 2 == 0 :
        (value.Numerator > value.Denominator && value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 == 0));

    public static bool IsFinite(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction24 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (value.Numerator > value.Denominator && value.Numerator % value.Denominator == 0));

    public static bool IsNaN(UnsignedMixedFraction24 value) => value.Denominator == 0;

    public static bool IsNegative(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction24 value) => value.Denominator != 0 && ((value.Numerator != 0) ? value.Numerator > value.Denominator &&
        value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 != 0 : value.WholeNumber % 2 != 0);

    public static bool IsPositive(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction24 value) => double.IsPow2(value.ToDouble());

    public static bool IsProperFraction(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction24 value) => value.Numerator == 0 && value.WholeNumber == 0 && value.Denominator != 0;

    public static UnsignedMixedFraction24 Log2(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 MaxMagnitude(UnsignedMixedFraction24 x, UnsignedMixedFraction24 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction24 MaxMagnitudeNumber(UnsignedMixedFraction24 x, UnsignedMixedFraction24 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction24 MinMagnitude(UnsignedMixedFraction24 x, UnsignedMixedFraction24 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction24 MinMagnitudeNumber(UnsignedMixedFraction24 x, UnsignedMixedFraction24 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction24 Multiply(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 Subtract(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 ToProperFraction(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 ToProperSimplestForm(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 ToSimplestForm(UnsignedMixedFraction24 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction24 result)
    {
        if (TryParseMixedFraction(s, style, provider, out byte wholeNumber, out byte numerator, out byte denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction24 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out byte wholeNumber, out byte numerator, out byte denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction24 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer, provider, out byte wholeNumber, out byte numerator, out byte denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction24 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer, provider, out byte wholeNumber, out byte numerator, out byte denominator))
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

    static int INumberBase<UnsignedMixedFraction24>.Radix => 2;

    static UnsignedMixedFraction24 IAdditiveIdentity<UnsignedMixedFraction24, UnsignedMixedFraction24>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction24 IMultiplicativeIdentity<UnsignedMixedFraction24, UnsignedMixedFraction24>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction24 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction24, byte>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedMixedFraction24>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction24 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction24>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction24 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction24>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction24 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction24>.TryConvertToChecked<TOther>(UnsignedMixedFraction24 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction24>.TryConvertToSaturating<TOther>(UnsignedMixedFraction24 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction24>.TryConvertToTruncating<TOther>(UnsignedMixedFraction24 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction24 operator +(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator +(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator -(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator -(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator ~(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator ++(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator --(UnsignedMixedFraction24 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator *(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator /(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator %(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator &(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator |(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction24 operator ^(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction24 left, UnsignedMixedFraction24 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}