using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct BinaryDenominatedInt64 : ISignedBinaryDenominatedNumber<BinaryDenominatedInt64, double, long>, IConvertible
{
    #region Static Properties

    public static BinaryDenominatedInt64 E => throw new NotImplementedException();

    public static BinaryDenominatedInt64 Pi => throw new NotImplementedException();

    public static BinaryDenominatedInt64 Tau => throw new NotImplementedException();

    public static BinaryDenominatedInt64 One => new(1L);

    public static int Radix => throw new NotImplementedException();

    public static BinaryDenominatedInt64 Zero => new(0L);

    static BinaryDenominatedInt64 IAdditiveIdentity<BinaryDenominatedInt64, BinaryDenominatedInt64>.AdditiveIdentity => Zero;

    static BinaryDenominatedInt64 IMultiplicativeIdentity<BinaryDenominatedInt64, BinaryDenominatedInt64>.MultiplicativeIdentity => One;

    public static BinaryDenominatedInt64 MaxValue => throw new NotImplementedException();

    public static BinaryDenominatedInt64 MinValue => throw new NotImplementedException();

    public static BinaryDenominatedInt64 NegativeOne => throw new NotImplementedException();

    #endregion

    #region Instance Properties

    public double Value { get; }
    
    double IFraction<BinaryDenominatedInt64, double, long>.Numerator => Value;

    IConvertible IFraction.Numerator => Value;

    public BinaryDenomination Denomination { get; }

    double IFraction<BinaryDenominatedInt64, double, long>.Denominator => (double)Denomination;

    IConvertible IFraction.Denominator => Denomination;

    public long WholeValue { get; }

    #endregion

    #region Constructors
    
    public BinaryDenominatedInt64(double numerator, BinaryDenomination denomination)
    {
        if (denomination == BinaryDenomination.Bytes)
        {
            WholeValue = Convert.ToInt64(numerator);
            Value = WholeValue;
        }
        else
        {
            WholeValue = Convert.ToInt64(numerator * (double)denomination);
            Value = WholeValue / (double)Denomination;
        }
        Denomination = denomination;
    }

    public BinaryDenominatedInt64(long value)
    {
        WholeValue = value;
        if (value > (long)BinaryDenomination.Petabytes)
            Denomination = BinaryDenomination.Petabytes;
        else if (value > (long)BinaryDenomination.Terabytes)
            Denomination = BinaryDenomination.Terabytes;
        else if (value > (long)BinaryDenomination.Gigabytes)
            Denomination = BinaryDenomination.Terabytes;
        else if (value > (long)BinaryDenomination.Megabytes)
            Denomination = BinaryDenomination.Terabytes;
        else if (value > (long)BinaryDenomination.Kilobytes)
            Denomination = BinaryDenomination.Terabytes;
        else
        {
            Denomination = BinaryDenomination.Bytes;
            Value = value;
            return;
        }
        Value = value / (double)Denomination;
    }

    #endregion

    #region Static Methods
    
    public static BinaryDenominatedInt64 Abs(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Acosh(BinaryDenominatedInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Asinh(BinaryDenominatedInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Atanh(BinaryDenominatedInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Cosh(BinaryDenominatedInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Invert(long wholeNumber, BinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Invert(long wholeNumber, BinaryDenominatedInt64 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Invert(long wholeNumber, BinaryDenominatedInt64 fraction, out long fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Log2(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MaxMagnitude(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MaxMagnitudeNumber(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MinMagnitude(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MinMagnitudeNumber(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Normalize(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominatedInt64 IFraction<BinaryDenominatedInt64, double, long>.Normalize(BinaryDenominatedInt64 fraction, out long wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Sinh(BinaryDenominatedInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Tanh(BinaryDenominatedInt64 x)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertFromChecked<TOther>(TOther value, out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertFromSaturating<TOther>(TOther value, out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertFromTruncating<TOther>(TOther value, out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertToChecked<TOther>(BinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertToSaturating<TOther>(BinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertToTruncating<TOther>(BinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Instance Methods

    public int CompareTo(BinaryDenominatedInt64 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public bool Equals(BinaryDenominatedInt64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

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

    public decimal ToDecimal()
    {
        throw new NotImplementedException();
    }

    decimal IConvertible.ToDecimal(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public double ToDouble()
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

    public float ToSingle()
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

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }

    string IConvertible.ToString(IFormatProvider? provider)
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

    #region Static operators

    public static BinaryDenominatedInt64 operator +(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator +(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator -(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator -(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator ~(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator ++(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator --(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator *(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator /(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator %(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator &(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator |(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator ^(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}