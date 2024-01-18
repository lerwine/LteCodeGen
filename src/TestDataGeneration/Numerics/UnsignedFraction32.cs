using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedFraction32 : ISimpleFraction<UnsignedFraction32, ushort, UnsignedMixedFraction64>
{
    #region Static Properties

    public static UnsignedFraction32 One { get; } = new(1, 1);

    static int INumberBase<UnsignedFraction32>.Radix => 10;

    public static UnsignedFraction32 Zero { get; } = new(0, 1);

    static UnsignedFraction32 IAdditiveIdentity<UnsignedFraction32, UnsignedFraction32>.AdditiveIdentity => Zero;

    static UnsignedFraction32 IMultiplicativeIdentity<UnsignedFraction32, UnsignedFraction32>.MultiplicativeIdentity => One;

    public static UnsignedFraction32 MaxValue { get; } = new(ushort.MaxValue, 1);

    public static UnsignedFraction32 MinValue { get; } = new(ushort.MinValue, 1);

    #endregion
    
    #region Instance Properties

    public ushort Numerator { get; }

    public ushort Denominator { get; } = (ushort)1;

    #endregion
    
    #region Constructors

    public UnsignedFraction32(ushort numerator, ushort denominator, bool doNotReduce = false)
    {
        if (doNotReduce)
        {
            if (denominator == 0) throw new DivideByZeroException();
        }
        else
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        Numerator = numerator;
        Denominator = denominator;
    }

    #endregion
    
    #region Instance Methods

    public UnsignedMixedFraction64 Add(ushort wholeNumber1, ushort wholeNumber2, UnsignedFraction32 fraction2)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction32 Add(UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedFraction32 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedFraction32 other) ? CompareTo(other) : -1;
    
    public UnsignedMixedFraction64 Divide(ushort wholeDividend, ushort wholeDivisor, UnsignedFraction32 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction32 Divide(UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedFraction32 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedFraction32 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction64 Join(ushort wholeNumber)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction64 Multiply(ushort wholeMultiplier, ushort wholeMultiplicand, UnsignedFraction32 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction32 Multiply(UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction64 Subtract(ushort wholeMinuend, ushort wholeSubtrahend, UnsignedFraction32 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction32 Subtract(UnsignedFraction32 fraction)
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
    
    public static UnsignedFraction32 Abs(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Add(ushort wholeNumber1, UnsignedFraction32 fraction1, ushort wholeNumber2, UnsignedFraction32 fraction2, out ushort sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Add(UnsignedMixedFraction64 fraction1, ushort wholeNumber2, UnsignedFraction32 fraction2, out ushort sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Add(ushort wholeNumber1, UnsignedFraction32 fraction1, UnsignedMixedFraction64 fraction2, out ushort sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Add(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Divide(ushort wholeDividend, UnsignedFraction32 dividendFraction, ushort wholeDivisor, UnsignedFraction32 divisorFraction, out ushort quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Divide(UnsignedMixedFraction64 dividend, ushort wholeDivisor, UnsignedFraction32 divisorFraction, out ushort quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Divide(ushort wholeDividend, UnsignedFraction32 dividendFraction, UnsignedMixedFraction64 divisor, out ushort quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Divide(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Invert(UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Invert(UnsignedFraction32 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Log2(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 MaxMagnitude(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 MaxMagnitudeNumber(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 MinMagnitude(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 MinMagnitudeNumber(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Multiply(ushort wholeMultiplier, UnsignedFraction32 multiplierFraction, ushort wholeMultiplicand, UnsignedFraction32 multiplicandFraction, out ushort product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Multiply(UnsignedMixedFraction64 multiplier, ushort wholeMultiplicand, UnsignedFraction32 multiplicandFraction, out ushort product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Multiply(ushort wholeMultiplier, UnsignedFraction32 multiplierFraction, UnsignedMixedFraction64 multiplicand, out ushort product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Multiply(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Subtract(ushort wholeMinuend, UnsignedFraction32 minuendFraction, ushort wholeSubtrahend, UnsignedFraction32 subtrahendFraction, out ushort difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Subtract(UnsignedMixedFraction64 minuend, ushort wholeSubtrahend, UnsignedFraction32 subtrahendFraction, out ushort difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 Subtract(ushort wholeMinuend, UnsignedFraction32 minuendFraction, UnsignedMixedFraction64 subtrahend, out ushort difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 Subtract(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 ToProperFraction(UnsignedFraction32 value, out ushort wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 ToProperFraction(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 ToProperSimplestForm(UnsignedFraction32 value, out ushort wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction64 ToProperSimplestForm(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 ToSimplestForm(UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertFromChecked<TOther>(TOther value, out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertToChecked<TOther>(UnsignedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertToSaturating<TOther>(UnsignedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertToTruncating<TOther>(UnsignedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Operators

    public static UnsignedFraction32 operator +(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator +(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator -(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator -(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator ~(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator ++(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator --(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator *(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator /(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator %(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator &(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator |(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator ^(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
