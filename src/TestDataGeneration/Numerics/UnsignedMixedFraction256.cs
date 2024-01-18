using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction256 : IMixedFraction<UnsignedMixedFraction256, ulong, UnsignedFraction128>
{
    #region Static Properties
    
    public static UnsignedMixedFraction256 One { get; } = new(1UL);

    static int INumberBase<UnsignedMixedFraction256>.Radix => 10;

    public static UnsignedMixedFraction256 Zero { get; } = new(0UL);

    static UnsignedMixedFraction256 IAdditiveIdentity<UnsignedMixedFraction256, UnsignedMixedFraction256>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction256 IMultiplicativeIdentity<UnsignedMixedFraction256, UnsignedMixedFraction256>.MultiplicativeIdentity => One;

    public static UnsignedMixedFraction256 MaxValue { get; } = new(ulong.MaxValue, ulong.MaxValue, 1UL);

    public static UnsignedMixedFraction256 MinValue { get; } = new(ulong.MinValue, ulong.MaxValue, 1UL);

    #endregion
    
    #region Instance Properties

    public ulong WholeNumber { get; }

    public ulong Numerator { get; }

    public ulong Denominator { get; } = 1UL;

    #endregion
    
    #region Constructors

    public UnsignedMixedFraction256(ulong wholeNumber, ulong numerator, ulong denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction256(ulong numerator, ulong denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0UL, numerator, denominator, doNotReduce, doNotMakeProper) { }

    public UnsignedMixedFraction256(ulong wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion
    
    #region Instance Methods

    public UnsignedMixedFraction256 Add(UnsignedMixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedMixedFraction256 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction256 other) ? CompareTo(other) : -1;
    
    public UnsignedMixedFraction256 Divide(UnsignedMixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedMixedFraction256 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction256 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction256 Multiply(UnsignedMixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public ulong Split(out UnsignedFraction128 properFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction256 Subtract(UnsignedMixedFraction256 fraction)
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
    
    public override string ToString()
    {
        return base.ToString() ?? string.Empty;
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

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Methods

    public static UnsignedMixedFraction256 Abs(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Add(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Divide(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Invert(UnsignedMixedFraction256 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Invert(UnsignedMixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Invert(UnsignedMixedFraction256 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Log2(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 MaxMagnitude(UnsignedMixedFraction256 x, UnsignedMixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 MaxMagnitudeNumber(UnsignedMixedFraction256 x, UnsignedMixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 MinMagnitude(UnsignedMixedFraction256 x, UnsignedMixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 MinMagnitudeNumber(UnsignedMixedFraction256 x, UnsignedMixedFraction256 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Multiply(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Subtract(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 ToProperFraction(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 ToProperSimplestForm(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 ToSimplestForm(UnsignedMixedFraction256 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction256>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction256>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction256>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction256 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction256>.TryConvertToChecked<TOther>(UnsignedMixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction256>.TryConvertToSaturating<TOther>(UnsignedMixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction256>.TryConvertToTruncating<TOther>(UnsignedMixedFraction256 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction256 operator +(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator +(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator -(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator -(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator ~(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator ++(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator --(UnsignedMixedFraction256 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator *(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator /(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator %(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator &(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator |(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 operator ^(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction256 left, UnsignedMixedFraction256 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}