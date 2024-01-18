using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct BinaryDenominationResult64 : ISignedBinaryDenominationResult<BinaryDenominationResult64, double, long>
{
    #region Static Properties

    public static BinaryDenominationResult64 One { get; } = new(1L);

    static int INumberBase<BinaryDenominationResult64>.Radix => 10;

    public static BinaryDenominationResult64 Zero { get; } = new(0L);
    static BinaryDenominationResult64 IAdditiveIdentity<BinaryDenominationResult64, BinaryDenominationResult64>.AdditiveIdentity => Zero;

    static BinaryDenominationResult64 IMultiplicativeIdentity<BinaryDenominationResult64, BinaryDenominationResult64>.MultiplicativeIdentity => One;

    public static BinaryDenominationResult64 MaxValue { get; } = new(long.MaxValue);

    public static BinaryDenominationResult64 MinValue { get; } = new(long.MinValue);

    #endregion
    
    #region Instance Properties

    public double Value { get; }

    double IFraction<BinaryDenominationResult64, double>.Numerator => Value;

    public BinaryDenomination Denomination { get; }

    double IFraction<BinaryDenominationResult64, double>.Denominator => (ulong)Denomination;

    #endregion
    
    #region Constructors

    public BinaryDenominationResult64(long wholeValue)
    {
        ulong abs = (ulong)Math.Abs(wholeValue);
        if (abs > (ulong)BinaryDenomination.Terabytes + (ulong)BinaryDenomination.Gigabytes)
            Denomination = BinaryDenomination.Petabytes;
        else if (abs > (ulong)BinaryDenomination.Gigabytes + (ulong)BinaryDenomination.Megabytes)
            Denomination = BinaryDenomination.Gigabytes;
        else if (abs > (ulong)BinaryDenomination.Megabytes + (ulong)BinaryDenomination.Kilobytes)
            Denomination = BinaryDenomination.Megabytes;
        else if (abs > (ulong)BinaryDenomination.Kilobytes + (ulong)BinaryDenomination.Bytes)
            Denomination = BinaryDenomination.Kilobytes;
        else
        {
            Denomination = BinaryDenomination.Bytes;
            Value = wholeValue;
            return;
        }
        Value = double.CreateChecked(wholeValue) / double.CreateChecked((ulong)Denomination);
    }

    public BinaryDenominationResult64(double value, BinaryDenomination denomination)
    {
        Denomination = denomination;
        Value = value;
    }

    public BinaryDenominationResult64(BinaryDenominatedInt64 denominatedValue)
    {
        Denomination = denominatedValue.Denomination;
        Value = denominatedValue.Value;
    }

    #endregion
    
    #region Instance Methods

    public BinaryDenominatedInt64 Add(double wholeNumber1, double wholeNumber2, BinaryDenominationResult64 fraction2)
    {
        throw new NotImplementedException();
    }

    public BinaryDenominationResult64 Add(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(BinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is BinaryDenominationResult64 other) ? CompareTo(other) : -1;

    public BinaryDenominatedInt64 Divide(double wholeDividend, double wholeDivisor, BinaryDenominationResult64 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public BinaryDenominationResult64 Divide(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(BinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is BinaryDenominationResult64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Value, Denomination);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public BinaryDenominatedInt64 Join(double wholeNumber)
    {
        throw new NotImplementedException();
    }

    public BinaryDenominatedInt64 Multiply(double wholeMultiplier, double wholeMultiplicand, BinaryDenominationResult64 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public BinaryDenominationResult64 Multiply(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public BinaryDenominatedInt64 Subtract(double wholeMinuend, double wholeSubtrahend, BinaryDenominationResult64 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public BinaryDenominationResult64 Subtract(BinaryDenominationResult64 fraction)
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
    
    public static BinaryDenominationResult64 Abs(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Add(double wholeNumber1, BinaryDenominationResult64 fraction1, double wholeNumber2, BinaryDenominationResult64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Add(BinaryDenominatedInt64 fraction1, double wholeNumber2, BinaryDenominationResult64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Add(double wholeNumber1, BinaryDenominationResult64 fraction1, BinaryDenominatedInt64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Add(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Divide(double wholeDividend, BinaryDenominationResult64 dividendFraction, double wholeDivisor, BinaryDenominationResult64 divisorFraction, out double quotient)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Divide(BinaryDenominatedInt64 dividend, double wholeDivisor, BinaryDenominationResult64 divisorFraction, out double quotient)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Divide(double wholeDividend, BinaryDenominationResult64 dividendFraction, BinaryDenominatedInt64 divisor, out double quotient)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Divide(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Invert(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Invert(BinaryDenominationResult64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Log2(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 MaxMagnitude(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 MaxMagnitudeNumber(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 MinMagnitude(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 MinMagnitudeNumber(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Multiply(double wholeMultiplier, BinaryDenominationResult64 multiplierFraction, double wholeMultiplicand, BinaryDenominationResult64 multiplicandFraction, out double product)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Multiply(BinaryDenominatedInt64 multiplier, double wholeMultiplicand, BinaryDenominationResult64 multiplicandFraction, out double product)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Multiply(double wholeMultiplier, BinaryDenominationResult64 multiplierFraction, BinaryDenominatedInt64 multiplicand, out double product)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Multiply(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Subtract(double wholeMinuend, BinaryDenominationResult64 minuendFraction, double wholeSubtrahend, BinaryDenominationResult64 subtrahendFraction, out double difference)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Subtract(BinaryDenominatedInt64 minuend, double wholeSubtrahend, BinaryDenominationResult64 subtrahendFraction, out double difference)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 Subtract(double wholeMinuend, BinaryDenominationResult64 minuendFraction, BinaryDenominatedInt64 subtrahend, out double difference)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Subtract(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 ToProperFraction(BinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 ToProperFraction(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 ToProperSimplestForm(BinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 ToProperSimplestForm(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 ToSimplestForm(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.TryConvertFromChecked<TOther>(TOther value, out BinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.TryConvertFromSaturating<TOther>(TOther value, out BinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.TryConvertFromTruncating<TOther>(TOther value, out BinaryDenominationResult64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.TryConvertToChecked<TOther>(BinaryDenominationResult64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.TryConvertToSaturating<TOther>(BinaryDenominationResult64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.TryConvertToTruncating<TOther>(BinaryDenominationResult64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Operators

    public static BinaryDenominationResult64 operator +(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator +(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator -(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator -(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator ~(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator ++(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator --(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator *(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator /(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator %(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator &(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator |(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominationResult64 operator ^(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(BinaryDenominationResult64 left, BinaryDenominationResult64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}