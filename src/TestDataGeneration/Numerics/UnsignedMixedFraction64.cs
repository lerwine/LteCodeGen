using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction64 : IMixedFraction<UnsignedMixedFraction64, ushort, UnsignedFraction32>
{
    #region Static Properties

    public static UnsignedMixedFraction64 One { get; } = new(1);

    public static UnsignedMixedFraction64 Zero { get; } = new(0);

    public static UnsignedMixedFraction64 MaxValue { get; } = new(ushort.MaxValue, ushort.MaxValue, 1);

    public static UnsignedMixedFraction64 MinValue { get; } = new(ushort.MinValue, ushort.MaxValue, 1);

    public static UnsignedMixedFraction64 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public ushort WholeNumber { get; }

    public ushort Numerator { get; }

    public ushort Denominator { get; }

    #endregion

    #region Constructors

    public UnsignedMixedFraction64(ushort wholeNumber, ushort numerator, ushort denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction64(ushort numerator, ushort denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction64(ushort wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction64 Add(UnsignedMixedFraction64 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = AddFractions<UnsignedMixedFraction64, ushort>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction64 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public UnsignedMixedFraction64 Divide(UnsignedMixedFraction64 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = DivideFractions<UnsignedMixedFraction64, ushort>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction64 other) => AreMixedFractionsEqual<UnsignedMixedFraction64, ushort>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction64 Multiply(UnsignedMixedFraction64 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = MultiplyFractions<UnsignedMixedFraction64, ushort>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public ushort Split(out UnsignedFraction32 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public UnsignedMixedFraction64 Subtract(UnsignedMixedFraction64 fraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = SubtractFractions<UnsignedMixedFraction64, ushort>(this, fraction);
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
        TryFormatMixedFraction<UnsignedMixedFraction64, ushort>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static UnsignedMixedFraction64 Abs(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Add(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Divide(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Invert(UnsignedMixedFraction64 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Invert(UnsignedMixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Invert(UnsignedMixedFraction64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Log2(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 MaxMagnitude(UnsignedMixedFraction64 x, UnsignedMixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 MaxMagnitudeNumber(UnsignedMixedFraction64 x, UnsignedMixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 MinMagnitude(UnsignedMixedFraction64 x, UnsignedMixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 MinMagnitudeNumber(UnsignedMixedFraction64 x, UnsignedMixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Multiply(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Subtract(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 ToProperFraction(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 ToProperSimplestForm(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 ToSimplestForm(UnsignedMixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction64 result)
    {
        if (TryParseMixedFraction(s, style, provider, out ushort wholeNumber, out ushort numerator, out ushort denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out ushort wholeNumber, out ushort numerator, out ushort denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction64 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer, provider, out ushort wholeNumber, out ushort numerator, out ushort denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction64 result)
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

    static int INumberBase<UnsignedMixedFraction64>.Radix => 10;

    static UnsignedMixedFraction64 IAdditiveIdentity<UnsignedMixedFraction64, UnsignedMixedFraction64>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction64 IMultiplicativeIdentity<UnsignedMixedFraction64, UnsignedMixedFraction64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction64 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction64, ushort>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<UnsignedMixedFraction64>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction64>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction64>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction64>.TryConvertToChecked<TOther>(UnsignedMixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction64>.TryConvertToSaturating<TOther>(UnsignedMixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction64>.TryConvertToTruncating<TOther>(UnsignedMixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction64 operator +(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator +(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator -(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator -(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator ~(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator ++(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator --(UnsignedMixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator *(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator /(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator %(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator &(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator |(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 operator ^(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction64 left, UnsignedMixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}