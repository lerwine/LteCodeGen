using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedBinaryDenominationResult64 : IBinaryDenominationResult<UnsignedBinaryDenominationResult64, double, ulong>
{
    #region Static Properties

    public static UnsignedBinaryDenominationResult64 One { get; } = new(1UL);

    public static UnsignedBinaryDenominationResult64 Zero { get; } = new(0UL);

    public static UnsignedBinaryDenominationResult64 MaxValue { get; } = new(ulong.MaxValue);

    public static UnsignedBinaryDenominationResult64 MinValue { get; } = new(ulong.MinValue);

    #endregion

    #region Instance Properties

    public double Value { get; }

    public BinaryDenomination Denomination { get; }

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

    public UnsignedBinaryDenominationResult64 Add(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedBinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedBinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedBinaryDenominationResult64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Value, Denomination);

    public UnsignedBinaryDenominationResult64 Subtract(UnsignedBinaryDenominationResult64 fraction)
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

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedBinaryDenominationResult64>.Radix => 10;

    static UnsignedBinaryDenominationResult64 IAdditiveIdentity<UnsignedBinaryDenominationResult64, UnsignedBinaryDenominationResult64>.AdditiveIdentity => Zero;

    static UnsignedBinaryDenominationResult64 IMultiplicativeIdentity<UnsignedBinaryDenominationResult64, UnsignedBinaryDenominationResult64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Properties

    double IFraction<UnsignedBinaryDenominationResult64, double>.Numerator => Value;

    double IFraction<UnsignedBinaryDenominationResult64, double>.Denominator => (ulong)Denomination;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedBinaryDenominationResult64 other) ? CompareTo(other) : -1;

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    UnsignedBinaryDenominationResult64 IFraction<UnsignedBinaryDenominationResult64, double>.Divide(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    UnsignedBinaryDenominationResult64 IFraction<UnsignedBinaryDenominationResult64, double>.Multiply(UnsignedBinaryDenominationResult64 fraction)
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

    static UnsignedBinaryDenominationResult64 ISimpleFraction<UnsignedBinaryDenominationResult64, double>.Add(double wholeNumber1, UnsignedBinaryDenominationResult64 fraction1, double wholeNumber2, UnsignedBinaryDenominationResult64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 ISimpleFraction<UnsignedBinaryDenominationResult64, double>.Subtract(double wholeMinuend, UnsignedBinaryDenominationResult64 minuendFraction, double wholeSubtrahend, UnsignedBinaryDenominationResult64 subtrahendFraction, out double difference)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 ISimpleFraction<UnsignedBinaryDenominationResult64, double>.Multiply(double wholeMultiplier, UnsignedBinaryDenominationResult64 multiplierFraction, double wholeMultiplicand, UnsignedBinaryDenominationResult64 multiplicandFraction, out double product)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 ISimpleFraction<UnsignedBinaryDenominationResult64, double>.Divide(double wholeDividend, UnsignedBinaryDenominationResult64 dividendFraction, double wholeDivisor, UnsignedBinaryDenominationResult64 divisorFraction, out double quotient)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 ISimpleFraction<UnsignedBinaryDenominationResult64, double>.ToProperFraction(UnsignedBinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 ISimpleFraction<UnsignedBinaryDenominationResult64, double>.ToProperSimplestForm(UnsignedBinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 IFraction<UnsignedBinaryDenominationResult64, double>.Invert(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 IFraction<UnsignedBinaryDenominationResult64, double>.Invert(UnsignedBinaryDenominationResult64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<UnsignedBinaryDenominationResult64, double>.IsProperFraction(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<UnsignedBinaryDenominationResult64, double>.IsProperSimplestForm(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<UnsignedBinaryDenominationResult64, double>.IsSimplestForm(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 IFraction<UnsignedBinaryDenominationResult64, double>.ToSimplestForm(UnsignedBinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    static bool IBinaryNumber<UnsignedBinaryDenominationResult64>.IsPow2(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 IBinaryNumber<UnsignedBinaryDenominationResult64>.Log2(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 INumberBase<UnsignedBinaryDenominationResult64>.Abs(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsCanonical(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsComplexNumber(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsEvenInteger(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsFinite(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsImaginaryNumber(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsInfinity(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsInteger(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsNaN(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsNegative(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsNegativeInfinity(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsNormal(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsOddInteger(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsPositive(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsPositiveInfinity(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsRealNumber(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsSubnormal(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominationResult64>.IsZero(UnsignedBinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 INumberBase<UnsignedBinaryDenominationResult64>.MaxMagnitude(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 INumberBase<UnsignedBinaryDenominationResult64>.MaxMagnitudeNumber(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 INumberBase<UnsignedBinaryDenominationResult64>.MinMagnitude(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominationResult64 INumberBase<UnsignedBinaryDenominationResult64>.MinMagnitudeNumber(UnsignedBinaryDenominationResult64 x, UnsignedBinaryDenominationResult64 y)
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
