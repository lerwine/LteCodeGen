using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction96 : IMixedSignedFraction<MixedFraction96, int, Fraction64>
{
    #region Static Properties

    public static MixedFraction96 NegativeOne { get; } = new(-1);

    public static MixedFraction96 One { get; } = new(1);

    public static MixedFraction96 Zero { get; } = new(0);

    public static MixedFraction96 MaxValue { get; } = new(int.MaxValue, int.MaxValue, 1);

    public static MixedFraction96 MinValue { get; } = new(int.MinValue, int.MaxValue, 1);

    public static MixedFraction96 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public int WholeNumber { get; }

    public int Numerator { get; }

    public int Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction96(int wholeNumber, int numerator, int denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public MixedFraction96(int numerator, int denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction96(int wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction96 Add(MixedFraction96 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = AddFractions<MixedFraction96, int>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(MixedFraction96 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public MixedFraction96 Divide(MixedFraction96 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = DivideFractions<MixedFraction96, int>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(MixedFraction96 other) => AreMixedFractionsEqual<MixedFraction96, int>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction96 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction96 Multiply(MixedFraction96 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = MultiplyFractions<MixedFraction96, int>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int Split(out Fraction64 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public MixedFraction96 Subtract(MixedFraction96 fraction)
    {
        (int wholeNumber, int numerator, int denominator) = SubtractFractions<MixedFraction96, int>(this, fraction);
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
        TryFormatMixedFraction<MixedFraction96, int>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static MixedFraction96 Abs(MixedFraction96 value) => (value.Denominator == 0) ? value : new(int.Abs(value.Numerator), int.Abs(value.Denominator));

    public static MixedFraction96 Add(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Divide(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Invert(MixedFraction96 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Invert(MixedFraction96 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Invert(MixedFraction96 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Log2(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 MaxMagnitude(MixedFraction96 x, MixedFraction96 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 MaxMagnitudeNumber(MixedFraction96 x, MixedFraction96 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 MinMagnitude(MixedFraction96 x, MixedFraction96 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 MinMagnitudeNumber(MixedFraction96 x, MixedFraction96 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Multiply(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Subtract(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 ToProperFraction(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 ToProperSimplestForm(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 ToSimplestForm(MixedFraction96 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction96 result)
    {
        if (TryParseMixedFraction(s, style, provider, out int wholeNumber, out int numerator, out int denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction96 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out int wholeNumber, out int numerator, out int denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction96 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out int wholeNumber, out int numerator, out int denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction96 result)
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

    static int INumberBase<MixedFraction96>.Radix => 10;

    static MixedFraction96 IAdditiveIdentity<MixedFraction96, MixedFraction96>.AdditiveIdentity => Zero;

    static MixedFraction96 IMultiplicativeIdentity<MixedFraction96, MixedFraction96>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction96 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<MixedFraction96, int>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction96>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction96 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction96>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction96 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction96>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction96 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction96>.TryConvertToChecked<TOther>(MixedFraction96 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction96>.TryConvertToSaturating<TOther>(MixedFraction96 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction96>.TryConvertToTruncating<TOther>(MixedFraction96 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction96 operator +(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator +(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator -(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator -(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator ~(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator ++(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator --(MixedFraction96 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator *(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator /(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator %(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator &(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator |(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 operator ^(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction96 left, MixedFraction96 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}