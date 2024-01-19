using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction256 : IMixedSignedFraction<MixedFraction256, long, Fraction128>
{
    #region Static Properties

    public static MixedFraction256 NegativeOne { get; } = new(-1L);

    public static MixedFraction256 One { get; } = new(1L);

    public static MixedFraction256 Zero { get; } = new(0L);

    public static MixedFraction256 MaxValue { get; } = new(long.MaxValue, long.MaxValue, 1U);

    public static MixedFraction256 MinValue { get; } = new(long.MinValue, long.MaxValue, 1U);

    #endregion

    #region Instance Properties

    public long WholeNumber { get; }

    public long Numerator { get; }

    public long Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction256(long wholeNumber, long numerator, long denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public MixedFraction256(long numerator, long denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0L, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction256(long wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction256 Add(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(MixedFraction256 other)
    {
        throw new NotImplementedException();
    }

    public MixedFraction256 Divide(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(MixedFraction256 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction256 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction256 Multiply(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public long Split(out Fraction128 properFraction)
    {
        throw new NotImplementedException();
    }

    public MixedFraction256 Subtract(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() ?? string.Empty;
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Static Methods

    public static MixedFraction256 Abs(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Add(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Divide(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Invert(MixedFraction256 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Invert(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Invert(MixedFraction256 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Log2(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MaxMagnitude(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MaxMagnitudeNumber(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MinMagnitude(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 MinMagnitudeNumber(MixedFraction256 x, MixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Multiply(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Subtract(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToProperFraction(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToProperSimplestForm(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToSimplestForm(MixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<MixedFraction256>.Radix => 10;

    static MixedFraction256 IAdditiveIdentity<MixedFraction256, MixedFraction256>.AdditiveIdentity => Zero;

    static MixedFraction256 IMultiplicativeIdentity<MixedFraction256, MixedFraction256>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction256 other) ? CompareTo(other) : -1;

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    bool IConvertible.ToBoolean(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    byte IConvertible.ToByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    char IConvertible.ToChar(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    DateTime IConvertible.ToDateTime(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    decimal IConvertible.ToDecimal(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    double IConvertible.ToDouble(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    short IConvertible.ToInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    int IConvertible.ToInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    long IConvertible.ToInt64(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    sbyte IConvertible.ToSByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    float IConvertible.ToSingle(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    string IConvertible.ToString(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    ushort IConvertible.ToUInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    uint IConvertible.ToUInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    ulong IConvertible.ToUInt64(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction256>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertToChecked<TOther>(MixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertToSaturating<TOther>(MixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction256>.TryConvertToTruncating<TOther>(MixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction256 operator +(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator +(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator -(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator -(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator ~(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator ++(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator --(MixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator *(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator /(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator %(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator &(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator |(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 operator ^(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction256 left, MixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}