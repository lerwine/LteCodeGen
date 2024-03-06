using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction192 : IMixedFraction<UnsignedMixedFraction192, ulong, UnsignedFraction128>
{
    #region Static Properties

    public static UnsignedMixedFraction192 One { get; } = new(1UL);

    public static UnsignedMixedFraction192 Zero { get; } = new(0UL);

    public static UnsignedMixedFraction192 MaxValue { get; } = new(ulong.MaxValue, ulong.MaxValue, 1UL);

    public static UnsignedMixedFraction192 MinValue { get; } = new(ulong.MinValue, ulong.MaxValue, 1UL);

    public static UnsignedMixedFraction192 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public ulong WholeNumber { get; }

    public ulong Numerator { get; }

    public ulong Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedMixedFraction192(ulong wholeNumber, ulong numerator, ulong denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction192(ulong numerator, ulong denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0UL, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction192(ulong wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction192 Add(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = AddFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction192 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public UnsignedMixedFraction192 Divide(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = DivideFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction192 other) => AreMixedFractionsEqual<UnsignedMixedFraction192, ulong>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction192 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction192 Multiply(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = MultiplyFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public ulong Split(out UnsignedFraction128 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public UnsignedMixedFraction192 Subtract(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = SubtractFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0UL) return double.NaN;
        if (provider is null)
            return (Numerator == 0UL) ? Convert.ToDouble(WholeNumber) : Convert.ToDouble(WholeNumber) + (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator));
        return (Numerator == 0UL) ? Convert.ToDouble(WholeNumber, provider) : Convert.ToDouble(WholeNumber, provider) + (Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider));
    }

    public override string ToString() => ToFractionString(WholeNumber, Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatMixedFraction<UnsignedMixedFraction192, ulong>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    static UnsignedMixedFraction192 INumberBase<UnsignedMixedFraction192>.Abs(UnsignedMixedFraction192 value) => value;

    public static UnsignedMixedFraction192 Add(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Divide(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Invert(UnsignedMixedFraction192 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Invert(UnsignedMixedFraction192 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Invert(UnsignedMixedFraction192 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction192 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (value.Numerator > value.Denominator && value.Numerator % value.Denominator == 0));

    public static bool IsFinite(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction192 value) => value.Denominator == 0;

    public static bool IsNegative(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction192 value) => value.Denominator != 0 && ((value.Numerator != 0) ? value.Numerator > value.Denominator &&
        value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 != 0 : value.WholeNumber % 2 != 0);

    public static bool IsPositive(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction192 value) => double.IsPow2(value.ToDouble());

    public static bool IsProperFraction(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction192 value) => value.Numerator == 0 && value.WholeNumber == 0 && value.Denominator != 0;

    public static UnsignedMixedFraction192 Log2(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 MaxMagnitude(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction192 MaxMagnitudeNumber(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction192 MinMagnitude(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction192 MinMagnitudeNumber(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction192 Multiply(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 Subtract(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 ToProperFraction(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 ToProperSimplestForm(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 ToSimplestForm(UnsignedMixedFraction192 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction192 result)
    {
        if (TryParseMixedFraction(s, style, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction192 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction192 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction192 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
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

    static int INumberBase<UnsignedMixedFraction192>.Radix => 2;

    static UnsignedMixedFraction192 IAdditiveIdentity<UnsignedMixedFraction192, UnsignedMixedFraction192>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction192 IMultiplicativeIdentity<UnsignedMixedFraction192, UnsignedMixedFraction192>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction192 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction192, ulong>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertToChecked<TOther>(UnsignedMixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertToSaturating<TOther>(UnsignedMixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertToTruncating<TOther>(UnsignedMixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction192 operator +(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator +(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator -(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator -(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator ~(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator ++(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator --(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator *(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator /(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator %(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator &(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator |(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator ^(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
