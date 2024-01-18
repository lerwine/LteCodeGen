using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedFraction64 : ISimpleFraction<UnsignedFraction64, uint, UnsignedMixedFraction128>
{
    #region Static Properties

    public static UnsignedFraction64 One { get; } = new(1U, 1U);

    static int INumberBase<UnsignedFraction64>.Radix => 10;

    public static UnsignedFraction64 Zero { get; } = new(0U, 1U);

    static UnsignedFraction64 IAdditiveIdentity<UnsignedFraction64, UnsignedFraction64>.AdditiveIdentity => Zero;

    static UnsignedFraction64 IMultiplicativeIdentity<UnsignedFraction64, UnsignedFraction64>.MultiplicativeIdentity => One;

    public static UnsignedFraction64 MaxValue { get; } = new(uint.MaxValue, 1U);

    public static UnsignedFraction64 MinValue { get; } = new(uint.MinValue, 1U);

    #endregion
    
    #region Instance Properties

    public uint Numerator { get; }

    public uint Denominator { get; } = 1U;

    #endregion
    
    #region Constructors

    public UnsignedFraction64(uint numerator, uint denominator, bool doNotReduce = false)
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

    public UnsignedMixedFraction128 Add(uint wholeNumber1, uint wholeNumber2, UnsignedFraction64 fraction2)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction64 Add(UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedFraction64 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedFraction64 other) ? CompareTo(other) : -1;
    
    public UnsignedMixedFraction128 Divide(uint wholeDividend, uint wholeDivisor, UnsignedFraction64 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction64 Divide(UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedFraction64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedFraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction128 Join(uint wholeNumber)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction128 Multiply(uint wholeMultiplier, uint wholeMultiplicand, UnsignedFraction64 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction64 Multiply(UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction128 Subtract(uint wholeMinuend, uint wholeSubtrahend, UnsignedFraction64 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedFraction64 Subtract(UnsignedFraction64 fraction)
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
    
    public static UnsignedFraction64 Abs(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Add(uint wholeNumber1, UnsignedFraction64 fraction1, uint wholeNumber2, UnsignedFraction64 fraction2, out uint sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Add(UnsignedMixedFraction128 fraction1, uint wholeNumber2, UnsignedFraction64 fraction2, out uint sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Add(uint wholeNumber1, UnsignedFraction64 fraction1, UnsignedMixedFraction128 fraction2, out uint sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Add(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Divide(uint wholeDividend, UnsignedFraction64 dividendFraction, uint wholeDivisor, UnsignedFraction64 divisorFraction, out uint quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Divide(UnsignedMixedFraction128 dividend, uint wholeDivisor, UnsignedFraction64 divisorFraction, out uint quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Divide(uint wholeDividend, UnsignedFraction64 dividendFraction, UnsignedMixedFraction128 divisor, out uint quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Divide(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Invert(UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Invert(UnsignedFraction64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Log2(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MaxMagnitude(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MaxMagnitudeNumber(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MinMagnitude(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 MinMagnitudeNumber(UnsignedFraction64 x, UnsignedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Multiply(uint wholeMultiplier, UnsignedFraction64 multiplierFraction, uint wholeMultiplicand, UnsignedFraction64 multiplicandFraction, out uint product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Multiply(UnsignedMixedFraction128 multiplier, uint wholeMultiplicand, UnsignedFraction64 multiplicandFraction, out uint product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Multiply(uint wholeMultiplier, UnsignedFraction64 multiplierFraction, UnsignedMixedFraction128 multiplicand, out uint product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Multiply(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Subtract(uint wholeMinuend, UnsignedFraction64 minuendFraction, uint wholeSubtrahend, UnsignedFraction64 subtrahendFraction, out uint difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Subtract(UnsignedMixedFraction128 minuend, uint wholeSubtrahend, UnsignedFraction64 subtrahendFraction, out uint difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 Subtract(uint wholeMinuend, UnsignedFraction64 minuendFraction, UnsignedMixedFraction128 subtrahend, out uint difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 Subtract(uint wholeNumber, UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 ToProperFraction(UnsignedFraction64 value, out uint wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperFraction(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 ToProperSimplestForm(UnsignedFraction64 value, out uint wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction128 ToProperSimplestForm(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 ToSimplestForm(UnsignedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertFromChecked<TOther>(TOther value, out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertToChecked<TOther>(UnsignedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertToSaturating<TOther>(UnsignedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction64>.TryConvertToTruncating<TOther>(UnsignedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Operators

    public static UnsignedFraction64 operator +(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator +(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator -(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator -(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator ~(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator ++(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator --(UnsignedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator *(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator /(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator %(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator &(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator |(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction64 operator ^(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedFraction64 left, UnsignedFraction64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
