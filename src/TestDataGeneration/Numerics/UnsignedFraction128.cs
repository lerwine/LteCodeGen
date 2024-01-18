using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedFraction128 : ISimpleFraction<UnsignedFraction128, ulong, UnsignedMixedFraction256>
{
    #region Static Properties

    public static UnsignedFraction128 One { get; } = new(1UL, 1UL);

    static int INumberBase<UnsignedFraction128>.Radix => 10;

    public static UnsignedFraction128 Zero { get; } = new(0UL, 1UL);

    static UnsignedFraction128 IAdditiveIdentity<UnsignedFraction128, UnsignedFraction128>.AdditiveIdentity => Zero;

    static UnsignedFraction128 IMultiplicativeIdentity<UnsignedFraction128, UnsignedFraction128>.MultiplicativeIdentity => One;

    public static UnsignedFraction128 MaxValue { get; } = new(ulong.MaxValue, 1UL);

    public static UnsignedFraction128 MinValue { get; } = new(ulong.MinValue, 1UL);

    #endregion
    
    #region Instance Properties

    public ulong Numerator { get; }

    public ulong Denominator { get; } = 1UL;

    #endregion
    
    #region Constructors

    public UnsignedFraction128(ulong numerator, ulong denominator, bool doNotReduce = false)
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

    public UnsignedMixedFraction256 Add(ulong wholeNumber1, ulong wholeNumber2, UnsignedFraction128 fraction2)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction128 Add(UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedFraction128 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedFraction128 other) ? CompareTo(other) : -1;
    
    public UnsignedMixedFraction256 Divide(ulong wholeDividend, ulong wholeDivisor, UnsignedFraction128 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction128 Divide(UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedFraction128 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedFraction128 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction256 Join(ulong wholeNumber)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction256 Multiply(ulong wholeMultiplier, ulong wholeMultiplicand, UnsignedFraction128 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction128 Multiply(UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction256 Subtract(ulong wholeMinuend, ulong wholeSubtrahend, UnsignedFraction128 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction128 Subtract(UnsignedFraction128 fraction)
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
    
    public static UnsignedFraction128 Abs(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Add(ulong wholeNumber1, UnsignedFraction128 fraction1, ulong wholeNumber2, UnsignedFraction128 fraction2, out ulong sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Add(UnsignedMixedFraction256 fraction1, ulong wholeNumber2, UnsignedFraction128 fraction2, out ulong sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Add(ulong wholeNumber1, UnsignedFraction128 fraction1, UnsignedMixedFraction256 fraction2, out ulong sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Add(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Divide(ulong wholeDividend, UnsignedFraction128 dividendFraction, ulong wholeDivisor, UnsignedFraction128 divisorFraction, out ulong quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Divide(UnsignedMixedFraction256 dividend, ulong wholeDivisor, UnsignedFraction128 divisorFraction, out ulong quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Divide(ulong wholeDividend, UnsignedFraction128 dividendFraction, UnsignedMixedFraction256 divisor, out ulong quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Divide(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Invert(UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Invert(UnsignedFraction128 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Log2(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MaxMagnitude(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MaxMagnitudeNumber(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MinMagnitude(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 MinMagnitudeNumber(UnsignedFraction128 x, UnsignedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Multiply(ulong wholeMultiplier, UnsignedFraction128 multiplierFraction, ulong wholeMultiplicand, UnsignedFraction128 multiplicandFraction, out ulong product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Multiply(UnsignedMixedFraction256 multiplier, ulong wholeMultiplicand, UnsignedFraction128 multiplicandFraction, out ulong product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Multiply(ulong wholeMultiplier, UnsignedFraction128 multiplierFraction, UnsignedMixedFraction256 multiplicand, out ulong product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Multiply(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Subtract(ulong wholeMinuend, UnsignedFraction128 minuendFraction, ulong wholeSubtrahend, UnsignedFraction128 subtrahendFraction, out ulong difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Subtract(UnsignedMixedFraction256 minuend, ulong wholeSubtrahend, UnsignedFraction128 subtrahendFraction, out ulong difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 Subtract(ulong wholeMinuend, UnsignedFraction128 minuendFraction, UnsignedMixedFraction256 subtrahend, out ulong difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 Subtract(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 ToProperFraction(UnsignedFraction128 value, out ulong wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 ToProperFraction(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 ToProperSimplestForm(UnsignedFraction128 value, out ulong wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction256 ToProperSimplestForm(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 ToSimplestForm(UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertFromChecked<TOther>(TOther value, out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertToChecked<TOther>(UnsignedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertToSaturating<TOther>(UnsignedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction128>.TryConvertToTruncating<TOther>(UnsignedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Operators

    public static UnsignedFraction128 operator +(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator +(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator -(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator -(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator ~(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator ++(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator --(UnsignedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator *(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator /(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator %(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator &(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator |(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction128 operator ^(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedFraction128 left, UnsignedFraction128 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
