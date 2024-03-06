using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction48 : IMixedFraction<UnsignedMixedFraction48, ushort, UnsignedFraction32>
{
    #region Static Properties

    public static UnsignedMixedFraction48 One { get; } = new(1);

    public static UnsignedMixedFraction48 Zero { get; } = new(0);

    public static UnsignedMixedFraction48 MaxValue { get; } = new(ushort.MaxValue, ushort.MaxValue, 1);

    public static UnsignedMixedFraction48 MinValue { get; } = new(ushort.MinValue, ushort.MaxValue, 1);

    public static UnsignedMixedFraction48 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public ushort WholeNumber { get; }

    public ushort Numerator { get; }

    public ushort Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedMixedFraction48(ushort wholeNumber, ushort numerator, ushort denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction48(ushort numerator, ushort denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction48(ushort wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction48 Add(UnsignedMixedFraction48 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = AddFractions<UnsignedMixedFraction48, ushort>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction48 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public UnsignedMixedFraction48 Divide(UnsignedMixedFraction48 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = DivideFractions<UnsignedMixedFraction48, ushort>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction48 other) => AreMixedFractionsEqual<UnsignedMixedFraction48, ushort>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction48 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction48 Multiply(UnsignedMixedFraction48 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = MultiplyFractions<UnsignedMixedFraction48, ushort>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public ushort Split(out UnsignedFraction32 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public UnsignedMixedFraction48 Subtract(UnsignedMixedFraction48 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = SubtractFractions<UnsignedMixedFraction48, ushort>(this, fraction);
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
        TryFormatMixedFraction<UnsignedMixedFraction48, ushort>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    static UnsignedMixedFraction48 INumberBase<UnsignedMixedFraction48>.Abs(UnsignedMixedFraction48 value) => value;

    public static UnsignedMixedFraction48 Add(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Divide(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Invert(UnsignedMixedFraction48 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Invert(UnsignedMixedFraction48 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Invert(UnsignedMixedFraction48 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction48 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (value.Numerator > value.Denominator && value.Numerator % value.Denominator == 0));

    public static bool IsFinite(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction48 value) => value.Denominator == 0;

    public static bool IsNegative(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction48 value) => value.Denominator != 0 && ((value.Numerator != 0) ? value.Numerator > value.Denominator &&
        value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 != 0 : value.WholeNumber % 2 != 0);

    public static bool IsPositive(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction48 value) => double.IsPow2(value.ToDouble());

    public static bool IsProperFraction(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction48 value) => value.Numerator == 0 && value.WholeNumber == 0 && value.Denominator != 0;

    public static UnsignedMixedFraction48 Log2(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 MaxMagnitude(UnsignedMixedFraction48 x, UnsignedMixedFraction48 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction48 MaxMagnitudeNumber(UnsignedMixedFraction48 x, UnsignedMixedFraction48 y) => (x > y) ? x : y;

    public static UnsignedMixedFraction48 MinMagnitude(UnsignedMixedFraction48 x, UnsignedMixedFraction48 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction48 MinMagnitudeNumber(UnsignedMixedFraction48 x, UnsignedMixedFraction48 y) => (x < y) ? x : y;

    public static UnsignedMixedFraction48 Multiply(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 Subtract(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 ToProperFraction(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 ToProperSimplestForm(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 ToSimplestForm(UnsignedMixedFraction48 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction48 result)
    {
        if (TryParseMixedFraction(s, style, provider, out ushort wholeNumber, out ushort numerator, out ushort denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction48 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out ushort wholeNumber, out ushort numerator, out ushort denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction48 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer, provider, out ushort wholeNumber, out ushort numerator, out ushort denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction48 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer, provider, out ushort wholeNumber, out ushort numerator, out ushort denominator))
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

    static int INumberBase<UnsignedMixedFraction48>.Radix => 2;

    static UnsignedMixedFraction48 IAdditiveIdentity<UnsignedMixedFraction48, UnsignedMixedFraction48>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction48 IMultiplicativeIdentity<UnsignedMixedFraction48, UnsignedMixedFraction48>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction48 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction48, ushort>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedMixedFraction48>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction48 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction48>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction48 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction48>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction48 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction48>.TryConvertToChecked<TOther>(UnsignedMixedFraction48 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction48>.TryConvertToSaturating<TOther>(UnsignedMixedFraction48 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction48>.TryConvertToTruncating<TOther>(UnsignedMixedFraction48 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction48 operator +(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator +(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator -(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator -(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator ~(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator ++(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator --(UnsignedMixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator *(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator /(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator %(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator &(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator |(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction48 operator ^(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction48 left, UnsignedMixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}