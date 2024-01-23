using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction64 : IMixedSignedFraction<MixedFraction64, short, Fraction32>
{
    #region Static Properties

    public static MixedFraction64 NegativeOne { get; } = new(-1);

    public static MixedFraction64 One { get; } = new(1);

    public static MixedFraction64 Zero { get; } = new(0);

    public static MixedFraction64 MaxValue { get; } = new(short.MaxValue, short.MaxValue, 1);

    public static MixedFraction64 MinValue { get; } = new(short.MinValue, short.MaxValue, 1);

    public static MixedFraction64 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public short WholeNumber { get; }

    public short Numerator { get; }

    public short Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction64(short wholeNumber, short numerator, short denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public MixedFraction64(short numerator, short denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction64(short wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction64 Add(MixedFraction64 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = AddFractions<MixedFraction64, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(MixedFraction64 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public MixedFraction64 Divide(MixedFraction64 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = DivideFractions<MixedFraction64, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(MixedFraction64 other) => AreMixedFractionsEqual<MixedFraction64, short>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction64 Multiply(MixedFraction64 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = MultiplyFractions<MixedFraction64, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public short Split(out Fraction32 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public MixedFraction64 Subtract(MixedFraction64 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = SubtractFractions<MixedFraction64, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0) return double.NaN;
        if (provider is null)
            return (Numerator == 0) ? Convert.ToDouble(WholeNumber) : Convert.ToDouble(WholeNumber) + (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator));
        return (Numerator == 0) ? Convert.ToDouble(WholeNumber, provider) : Convert.ToDouble(WholeNumber, provider) + (Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider));
    }

    public override string ToString() => ToFractionString(Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatMixedFraction<MixedFraction64, short>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static MixedFraction64 Abs(MixedFraction64 value) => (value.Denominator == 0) ? value : new(short.Abs(value.Numerator), short.Abs(value.Denominator));

    public static MixedFraction64 Add(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Divide(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Invert(MixedFraction64 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Invert(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Invert(MixedFraction64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Log2(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MaxMagnitude(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MaxMagnitudeNumber(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MinMagnitude(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MinMagnitudeNumber(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Multiply(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Subtract(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToProperFraction(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToProperSimplestForm(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToSimplestForm(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        if (TryParseMixedFraction(s, style, provider, out short wholeNumber, out short numerator, out short denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out short wholeNumber, out short numerator, out short denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out short wholeNumber, out short numerator, out short denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out short wholeNumber, out short numerator, out short denominator))
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

    static int INumberBase<MixedFraction64>.Radix => 10;

    static MixedFraction64 IAdditiveIdentity<MixedFraction64, MixedFraction64>.AdditiveIdentity => Zero;

    static MixedFraction64 IMultiplicativeIdentity<MixedFraction64, MixedFraction64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction64 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<MixedFraction64, short>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction64>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertToChecked<TOther>(MixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertToSaturating<TOther>(MixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertToTruncating<TOther>(MixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction64 operator +(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator +(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator -(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator -(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator ~(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator ++(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator --(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator *(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator /(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator %(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator &(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator |(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator ^(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
