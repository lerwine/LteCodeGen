using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct BinaryDenominationResult64 : ISignedBinaryDenominationResult<BinaryDenominationResult64, double, long>
{
    #region Static Properties

    public static BinaryDenominationResult64 One { get; } = new(1L);

    public static BinaryDenominationResult64 Zero { get; } = new(0L);

    public static BinaryDenominationResult64 MaxValue { get; } = new(long.MaxValue);

    public static BinaryDenominationResult64 MinValue { get; } = new(long.MinValue);

    #endregion

    #region Instance Properties

    public double Value { get; }

    public BinaryDenomination Denomination { get; }

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

    public BinaryDenominationResult64 Add(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(BinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(BinaryDenominationResult64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is BinaryDenominationResult64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Value, Denomination);

    public BinaryDenominationResult64 Subtract(BinaryDenominationResult64 fraction)
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

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<BinaryDenominationResult64>.Radix => 10;

    static BinaryDenominationResult64 IAdditiveIdentity<BinaryDenominationResult64, BinaryDenominationResult64>.AdditiveIdentity => Zero;

    static BinaryDenominationResult64 IMultiplicativeIdentity<BinaryDenominationResult64, BinaryDenominationResult64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Properties

    double IFraction<BinaryDenominationResult64, double>.Numerator => Value;

    double IFraction<BinaryDenominationResult64, double>.Denominator => (ulong)Denomination;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is BinaryDenominationResult64 other) ? CompareTo(other) : -1;

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    BinaryDenominationResult64 IFraction<BinaryDenominationResult64, double>.Divide(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    BinaryDenominationResult64 IFraction<BinaryDenominationResult64, double>.Multiply(BinaryDenominationResult64 fraction)
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

    static BinaryDenominationResult64 ISimpleFraction<BinaryDenominationResult64, double>.Add(double wholeNumber1, BinaryDenominationResult64 fraction1, double wholeNumber2, BinaryDenominationResult64 fraction2, out double sum)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 ISimpleFraction<BinaryDenominationResult64, double>.Subtract(double wholeMinuend, BinaryDenominationResult64 minuendFraction, double wholeSubtrahend, BinaryDenominationResult64 subtrahendFraction, out double difference)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 ISimpleFraction<BinaryDenominationResult64, double>.Multiply(double wholeMultiplier, BinaryDenominationResult64 multiplierFraction, double wholeMultiplicand, BinaryDenominationResult64 multiplicandFraction, out double product)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 ISimpleFraction<BinaryDenominationResult64, double>.Divide(double wholeDividend, BinaryDenominationResult64 dividendFraction, double wholeDivisor, BinaryDenominationResult64 divisorFraction, out double quotient)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 ISimpleFraction<BinaryDenominationResult64, double>.ToProperFraction(BinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 ISimpleFraction<BinaryDenominationResult64, double>.ToProperSimplestForm(BinaryDenominationResult64 value, out double wholeNumber)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 IFraction<BinaryDenominationResult64, double>.Invert(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 IFraction<BinaryDenominationResult64, double>.Invert(BinaryDenominationResult64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<BinaryDenominationResult64, double>.IsProperFraction(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<BinaryDenominationResult64, double>.IsProperSimplestForm(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<BinaryDenominationResult64, double>.IsSimplestForm(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 IFraction<BinaryDenominationResult64, double>.ToSimplestForm(BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    static bool IBinaryNumber<BinaryDenominationResult64>.IsPow2(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 IBinaryNumber<BinaryDenominationResult64>.Log2(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 INumberBase<BinaryDenominationResult64>.Abs(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsCanonical(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsComplexNumber(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsEvenInteger(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsFinite(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsImaginaryNumber(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsInfinity(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsInteger(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsNaN(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsNegative(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsNegativeInfinity(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsNormal(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsOddInteger(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsPositive(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsPositiveInfinity(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsRealNumber(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsSubnormal(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominationResult64>.IsZero(BinaryDenominationResult64 value)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 INumberBase<BinaryDenominationResult64>.MaxMagnitude(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 INumberBase<BinaryDenominationResult64>.MaxMagnitudeNumber(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 INumberBase<BinaryDenominationResult64>.MinMagnitude(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominationResult64 INumberBase<BinaryDenominationResult64>.MinMagnitudeNumber(BinaryDenominationResult64 x, BinaryDenominationResult64 y)
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