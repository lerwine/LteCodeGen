using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction192 : IMixedSignedFraction<MixedFraction192, long, Fraction128>
{
    #region Static Properties

    public static MixedFraction192 NegativeOne { get; } = new(-1L);

    public static MixedFraction192 One { get; } = new(1L);

    public static MixedFraction192 Zero { get; } = new(0L);

    public static MixedFraction192 MaxValue { get; } = new(long.MaxValue, long.MaxValue, 1U);

    public static MixedFraction192 MinValue { get; } = new(long.MinValue, long.MaxValue, 1U);

    public static MixedFraction192 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public long WholeNumber { get; }

    public long Numerator { get; }

    public long Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction192(long wholeNumber, long numerator, long denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public MixedFraction192(long numerator, long denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0L, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction192(long wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction192 Add(MixedFraction192 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = AddFractions<MixedFraction192, long>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(MixedFraction192 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public MixedFraction192 Divide(MixedFraction192 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = DivideFractions<MixedFraction192, long>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(MixedFraction192 other) => AreMixedFractionsEqual<MixedFraction192, long>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction192 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction192 Multiply(MixedFraction192 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = MultiplyFractions<MixedFraction192, long>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public long Split(out Fraction128 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public MixedFraction192 Subtract(MixedFraction192 fraction)
    {
        (long wholeNumber, long numerator, long denominator) = SubtractFractions<MixedFraction192, long>(this, fraction);
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
        TryFormatMixedFraction<MixedFraction192, long>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static MixedFraction192 Abs(MixedFraction192 value) => (value.Denominator == 0L) ? value : new(long.Abs(value.Numerator), long.Abs(value.Denominator));

    public static MixedFraction192 Add(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Divide(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Invert(MixedFraction192 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Invert(MixedFraction192 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Invert(MixedFraction192 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction192 value) => value.Denominator != 0L && ((value.Numerator == 0L) ? value.WholeNumber % 2 == 0L :
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0L && (value.WholeNumber + value.Numerator / value.Denominator) % 2 == 0L));

    public static bool IsFinite(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction192 value) => value.Denominator != 0L && (value.Numerator == 0L ||
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0L));

    public static bool IsNaN(MixedFraction192 value) => value.Denominator == 0L;

    public static bool IsNegative(MixedFraction192 value) => value.Denominator != 0L &&
        ((value.Numerator != 0L) ? ((value.Denominator < 0L) ?
        ((value.Numerator > 0L) ? value.WholeNumber > 0L : value.WholeNumber < 0L) :
        (value.Numerator < 0L) ? value.WholeNumber > 0L : value.WholeNumber < 0L) : value.WholeNumber < 0L);

    public static bool IsNegativeInfinity(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction192 value) => value.Denominator != 0L && ((value.Numerator != 0L) ? Math.Abs(value.Numerator) > Math.Abs(value.Denominator) &&
        value.Numerator % value.Denominator == 0L && (value.WholeNumber + value.Numerator / value.Denominator) % 2 != 0L : value.WholeNumber % 2 != 0L);

    public static bool IsPositive(MixedFraction192 value) => value.Denominator != 0L &&
        ((value.Numerator == 0L) ? value.WholeNumber >= 0L : ((value.Denominator < 0L) ?
        ((value.Numerator < 0L) ? value.WholeNumber > 0L : value.WholeNumber < 0L) :
        (value.Numerator > 0L) ? value.WholeNumber > 0L : value.WholeNumber < 0L));

    public static bool IsPositiveInfinity(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction192 value) => double.IsPow2(value.ToDouble());

    public static bool IsProperFraction(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction192 value) => value.Denominator != 0L;

    public static bool IsSimplestForm(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction192 value) => value.Numerator == 0L && value.WholeNumber == 0L && value.Denominator != 0L;

    public static MixedFraction192 Log2(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 MaxMagnitude(MixedFraction192 x, MixedFraction192 y) => (x > y) ? x : y;

    public static MixedFraction192 MaxMagnitudeNumber(MixedFraction192 x, MixedFraction192 y)
    {
        MixedFraction192 ax = Abs(x);
        MixedFraction192 ay = Abs(y);
        if ((ax > ay) || ay.Denominator == 0L) return x;
        return (ax != ay) ? y : IsNegative(x) ? y : x;
    }

    public static MixedFraction192 MinMagnitude(MixedFraction192 x, MixedFraction192 y) => (x < y) ? x : y;

    public static MixedFraction192 MinMagnitudeNumber(MixedFraction192 x, MixedFraction192 y)
    {
        MixedFraction192 ax = Abs(x);
        MixedFraction192 ay = Abs(y);
        if ((ax < ay) || ay.Denominator == 0L) return x;
        return (ax != ay) ? y : IsNegative(x) ? x : y;
    }

    public static MixedFraction192 Multiply(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 Subtract(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 ToProperFraction(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 ToProperSimplestForm(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 ToSimplestForm(MixedFraction192 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction192 result)
    {
        if (TryParseMixedFraction(s, style, provider, out long wholeNumber, out long numerator, out long denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction192 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out long wholeNumber, out long numerator, out long denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction192 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out long wholeNumber, out long numerator, out long denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction192 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out long wholeNumber, out long numerator, out long denominator))
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

    static int INumberBase<MixedFraction192>.Radix => 2;

    static MixedFraction192 IAdditiveIdentity<MixedFraction192, MixedFraction192>.AdditiveIdentity => Zero;

    static MixedFraction192 IMultiplicativeIdentity<MixedFraction192, MixedFraction192>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction192 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<MixedFraction192, long>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction192>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction192>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction192>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction192>.TryConvertToChecked<TOther>(MixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction192>.TryConvertToSaturating<TOther>(MixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction192>.TryConvertToTruncating<TOther>(MixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction192 operator +(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator +(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator -(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator -(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator ~(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator ++(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator --(MixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator *(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator /(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator %(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator &(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator |(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction192 operator ^(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction192 left, MixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}