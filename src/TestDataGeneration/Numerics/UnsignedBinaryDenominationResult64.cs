using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedBinaryDenominationResult64 : IBinaryDenominationResult<UnsignedBinaryDenominationResult64, double, ulong>
{
    #region Static Properties

    public static UnsignedBinaryDenominationResult64 One { get; } = new(1UL);

    static int INumberBase<UnsignedBinaryDenominationResult64>.Radix => 10;

    public static UnsignedBinaryDenominationResult64 Zero { get; } = new(0UL);

    static UnsignedBinaryDenominationResult64 IAdditiveIdentity<UnsignedBinaryDenominationResult64, UnsignedBinaryDenominationResult64>.AdditiveIdentity => Zero;

    static UnsignedBinaryDenominationResult64 IMultiplicativeIdentity<UnsignedBinaryDenominationResult64, UnsignedBinaryDenominationResult64>.MultiplicativeIdentity => One;

    public static UnsignedBinaryDenominationResult64 MaxValue { get; } = new(ulong.MaxValue);

    public static UnsignedBinaryDenominationResult64 MinValue { get; } = new(ulong.MinValue);

    #endregion
    
    #region Instance Properties

    public double Value { get; }

    double IFraction<UnsignedBinaryDenominationResult64, double>.Numerator => Value;

    public BinaryDenomination Denomination { get; }

    double IFraction<UnsignedBinaryDenominationResult64, double>.Denominator => (ulong)Denomination;

    #endregion
    
    #region Constructors

    public UnsignedBinaryDenominationResult64(ulong wholeValue)
    {
        if (wholeValue > (ulong)BinaryDenomination.Terabytes + (ulong)BinaryDenomination.Gigabytes)
            Denomination = BinaryDenomination.Petabytes;
        else if (wholeValue > (ulong)BinaryDenomination.Gigabytes + (ulong)BinaryDenomination.Megabytes)
            Denomination = BinaryDenomination.Gigabytes;
        else if (wholeValue > (ulong)BinaryDenomination.Megabytes + (ulong)BinaryDenomination.Kilobytes)
            Denomination = BinaryDenomination.Megabytes;
        else if (wholeValue > (ulong)BinaryDenomination.Kilobytes + (ulong)BinaryDenomination.Bytes)
            Denomination = BinaryDenomination.Kilobytes;
        else
        {
            Denomination = BinaryDenomination.Bytes;
            Value = wholeValue;
            return;
        }
        Value = double.CreateChecked(wholeValue) / double.CreateChecked((ulong)Denomination);
    }

    public UnsignedBinaryDenominationResult64(double value, BinaryDenomination denomination)
    {
        Denomination = denomination;
        Value = value;
    }

    public UnsignedBinaryDenominationResult64(UnsignedBinaryDenominatedInt64 denominatedValue)
    {
        Denomination = denominatedValue.Denomination;
        Value = denominatedValue.Value;
    }

    #endregion
    
    #region Instance Methods

    public UnsignedBinaryDenominatedInt64 Add(double wholeNumber1, double wholeNumber2, UnsignedBinaryDenominationResult64 fraction2)
    {
        throw new NotImplementedException();
    }

    public UnsignedBinaryDenominationResult64 Add(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedBinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedBinaryDenominationResult64 other) ? CompareTo(other) : -1;
    
    public UnsignedBinaryDenominatedInt64 Divide(double wholeDividend, double wholeDivisor, UnsignedBinaryDenominationResult64 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedBinaryDenominationResult64 Divide(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedBinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedBinaryDenominationResult64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Value, Denomination);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public UnsignedBinaryDenominatedInt64 Join(double wholeNumber)
    {
        throw new NotImplementedException();
    }

    public UnsignedBinaryDenominatedInt64 Multiply(double wholeMultiplier, double wholeMultiplicand, UnsignedBinaryDenominationResult64 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedBinaryDenominationResult64 Multiply(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedBinaryDenominatedInt64 Subtract(double wholeMinuend, double wholeSubtrahend, UnsignedBinaryDenominationResult64 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedBinaryDenominationResult64 Subtract(UnsignedBinaryDenominationResult64 fraction)
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
    
    public static UnsignedBinaryDenominationResult64 Abs(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Add(double wholeNumber1, UnsignedBinaryDenominationResult64 fraction1, double wholeNumber2, UnsignedBinaryDenominationResult64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Add(UnsignedBinaryDenominatedInt64 fraction1, double wholeNumber2, UnsignedBinaryDenominationResult64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Add(double wholeNumber1, UnsignedBinaryDenominationResult64 fraction1, UnsignedBinaryDenominatedInt64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 Add(double wholeNumber, UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Divide(double wholeDividend, UnsignedBinaryDenominationResult64 dividendFraction, double wholeDivisor, UnsignedBinaryDenominationResult64 divisorFraction, out double quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Divide(UnsignedBinaryDenominatedInt64 dividend, double wholeDivisor, UnsignedBinaryDenominationResult64 divisorFraction, out double quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Divide(double wholeDividend, UnsignedBinaryDenominationResult64 dividendFraction, UnsignedBinaryDenominatedInt64 divisor, out double quotient)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 Divide(double wholeNumber, UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Invert(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Invert(UnsignedBinaryDenominationResult64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Log2(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 MaxMagnitude(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 MaxMagnitudeNumber(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 MinMagnitude(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 MinMagnitudeNumber(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Multiply(double wholeMultiplier, UnsignedBinaryDenominationResult64 multiplierFraction, double wholeMultiplicand, UnsignedBinaryDenominationResult64 multiplicandFraction, out double product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Multiply(UnsignedBinaryDenominatedInt64 multiplier, double wholeMultiplicand, UnsignedBinaryDenominationResult64 multiplicandFraction, out double product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Multiply(double wholeMultiplier, UnsignedBinaryDenominationResult64 multiplierFraction, UnsignedBinaryDenominatedInt64 multiplicand, out double product)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 Multiply(double wholeNumber, UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Subtract(double wholeMinuend, UnsignedBinaryDenominationResult64 minuendFraction, double wholeSubtrahend, UnsignedBinaryDenominationResult64 subtrahendFraction, out double difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Subtract(UnsignedBinaryDenominatedInt64 minuend, double wholeSubtrahend, UnsignedBinaryDenominationResult64 subtrahendFraction, out double difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 Subtract(double wholeMinuend, UnsignedBinaryDenominationResult64 minuendFraction, UnsignedBinaryDenominatedInt64 subtrahend, out double difference)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 Subtract(double wholeNumber, UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 ToProperFraction(UnsignedBinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 ToProperFraction(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 ToProperSimplestForm(UnsignedBinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 ToProperSimplestForm(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 ToSimplestForm(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.TryConvertFromChecked<TOther>(TOther value, out UnsignedBinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedBinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedBinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.TryConvertToChecked<TOther>(UnsignedBinaryDenominationResult64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.TryConvertToSaturating<TOther>(UnsignedBinaryDenominationResult64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.TryConvertToTruncating<TOther>(UnsignedBinaryDenominationResult64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Operators

    public static UnsignedBinaryDenominationResult64 operator +(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator +(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator -(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator -(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator ~(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator ++(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator --(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator *(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator /(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator %(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator &(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator |(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominationResult64 operator ^(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedBinaryDenominationResult64 left, UnsignedBinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
