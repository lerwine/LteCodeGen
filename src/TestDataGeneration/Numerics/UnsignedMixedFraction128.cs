using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction128 : IMixedFraction<UnsignedMixedFraction128, uint, UnsignedFraction64>
{
    #region Static Properties

    public static UnsignedMixedFraction128 One { get; } = new(1U);

    public static UnsignedMixedFraction128 Zero { get; } = new(0U);

    public static UnsignedMixedFraction128 MaxValue { get; } = new(uint.MaxValue, uint.MaxValue, 1U);

    public static UnsignedMixedFraction128 MinValue { get; } = new(uint.MinValue, uint.MaxValue, 1U);

    #endregion

    #region Instance Properties

    public uint WholeNumber { get; }

    public uint Numerator { get; }

    public uint Denominator { get; } = 1U;

    #endregion

    #region Constructors

    public UnsignedMixedFraction128(uint wholeNumber, uint numerator, uint denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction128(uint numerator, uint denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0U, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public UnsignedMixedFraction128(uint wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public UnsignedMixedFraction128 Add(UnsignedMixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedMixedFraction128 other)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction128 Divide(UnsignedMixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedMixedFraction128 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction128 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction128 Multiply(UnsignedMixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public uint Split(out UnsignedFraction64 properFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction128 Subtract(UnsignedMixedFraction128 fraction)
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

    public static UnsignedMixedFraction128 Abs(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Add(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Divide(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Invert(UnsignedMixedFraction128 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Invert(UnsignedMixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Invert(UnsignedMixedFraction128 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Log2(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MaxMagnitude(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MaxMagnitudeNumber(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MinMagnitude(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 MinMagnitudeNumber(UnsignedMixedFraction128 x, UnsignedMixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Multiply(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Subtract(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperFraction(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperSimplestForm(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToSimplestForm(UnsignedMixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedMixedFraction128>.Radix => 10;

    static UnsignedMixedFraction128 IAdditiveIdentity<UnsignedMixedFraction128, UnsignedMixedFraction128>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction128 IMultiplicativeIdentity<UnsignedMixedFraction128, UnsignedMixedFraction128>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction128 other) ? CompareTo(other) : -1;

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

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertToChecked<TOther>(UnsignedMixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertToSaturating<TOther>(UnsignedMixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction128>.TryConvertToTruncating<TOther>(UnsignedMixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction128 operator +(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator +(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator -(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator -(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator ~(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator ++(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator --(UnsignedMixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator *(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator /(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator %(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator &(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator |(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 operator ^(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction128 left, UnsignedMixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}