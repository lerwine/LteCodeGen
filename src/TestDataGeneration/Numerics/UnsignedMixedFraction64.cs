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

    #endregion

    #region Instance Properties

    public ushort WholeNumber { get; }

    public ushort Numerator { get; }

    public ushort Denominator { get; } = (ushort)1;

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
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedMixedFraction64 other)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction64 Divide(UnsignedMixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedMixedFraction64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public UnsignedMixedFraction64 Multiply(UnsignedMixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public ushort Split(out UnsignedFraction32 properFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction64 Subtract(UnsignedMixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    float IConvertible.ToSingle(IFormatProvider? provider)
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
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction64 result)
    {
        throw new NotImplementedException();
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