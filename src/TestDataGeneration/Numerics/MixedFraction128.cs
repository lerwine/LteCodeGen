using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction128 : IMixedSignedFraction<MixedFraction128, int, Fraction64>
{
    #region Static Properties

    public static MixedFraction128 NegativeOne { get; } = new(-1);

    public static MixedFraction128 One { get; } = new(1);

    public static MixedFraction128 Zero { get; } = new(0);

    public static MixedFraction128 MaxValue { get; } = new(int.MaxValue, int.MaxValue, 1);

    public static MixedFraction128 MinValue { get; } = new(int.MinValue, int.MaxValue, 1);

    public static MixedFraction128 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public int WholeNumber { get; }

    public int Numerator { get; }

    public int Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction128(int wholeNumber, int numerator, int denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public MixedFraction128(int numerator, int denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction128(int wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction128 Add(MixedFraction128 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = AddFractions<MixedFraction128, int>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(MixedFraction128 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public MixedFraction128 Divide(MixedFraction128 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = DivideFractions<MixedFraction128, int>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(MixedFraction128 other) => AreMixedFractionsEqual<MixedFraction128, int>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction128 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction128 Multiply(MixedFraction128 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = MultiplyFractions<MixedFraction128, int>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int Split(out Fraction64 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public MixedFraction128 Subtract(MixedFraction128 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = SubtractFractions<MixedFraction128, int>(this, fraction);
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
        TryFormatMixedFraction<MixedFraction128, int>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static MixedFraction128 Abs(MixedFraction128 value) => (value.Denominator == 0) ? value : new(int.Abs(value.Numerator), int.Abs(value.Denominator));

    public static MixedFraction128 Add(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Divide(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Invert(MixedFraction128 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Invert(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Invert(MixedFraction128 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Log2(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MaxMagnitude(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MaxMagnitudeNumber(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MinMagnitude(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MinMagnitudeNumber(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Multiply(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Subtract(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToProperFraction(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToProperSimplestForm(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToSimplestForm(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        if (TryParseMixedFraction(s, style, provider, out int wholeNumber, out int numerator, out int denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out int wholeNumber, out int numerator, out int denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out int wholeNumber, out int numerator, out int denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out int wholeNumber, out int numerator, out int denominator))
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

    static int INumberBase<MixedFraction128>.Radix => 10;

    static MixedFraction128 IAdditiveIdentity<MixedFraction128, MixedFraction128>.AdditiveIdentity => Zero;

    static MixedFraction128 IMultiplicativeIdentity<MixedFraction128, MixedFraction128>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction128 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<MixedFraction128, int>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction128>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertToChecked<TOther>(MixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertToSaturating<TOther>(MixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertToTruncating<TOther>(MixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction128 operator +(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator +(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator -(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator -(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator ~(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator ++(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator --(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator *(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator /(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator %(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator &(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator |(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator ^(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}