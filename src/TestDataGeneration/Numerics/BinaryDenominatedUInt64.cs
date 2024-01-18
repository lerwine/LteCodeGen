using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct BinaryDenominatedUInt64 : IBinaryDenominatedNumber<BinaryDenominatedUInt64, double, ulong>
{
    #region Static Properties

    public static BinaryDenominatedUInt64 E => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 Pi => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 Tau => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 Zero => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 AdditiveIdentity => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 MultiplicativeIdentity => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 MaxValue => throw new NotImplementedException();

    public static BinaryDenominatedUInt64 MinValue => throw new NotImplementedException();

    #endregion

    #region Instance Properties

    public double Value { get; }

    double IFraction<BinaryDenominatedUInt64, double, ulong>.Numerator => throw new NotImplementedException();

    IConvertible IFraction.Numerator => throw new NotImplementedException();

    public ulong WholeValue { get; }

    public BinaryDenomination Denomination { get; }

    double IFraction<BinaryDenominatedUInt64, double, ulong>.Denominator => throw new NotImplementedException();

    IConvertible IFraction.Denominator => throw new NotImplementedException();

    #endregion

    #region Constructors
    
    public BinaryDenominatedUInt64(double numerator, BinaryDenomination denomination)
    {
        if (denomination == BinaryDenomination.Bytes)
        {
            WholeValue = Convert.ToUInt64(numerator);
            Value = WholeValue;
        }
        else
        {
            WholeValue = Convert.ToUInt64(numerator * (double)denomination);
            Value = WholeValue / (double)Denomination;
        }
        Denomination = denomination;
    }

    public BinaryDenominatedUInt64(ulong value)
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

    public static BinaryDenominatedUInt64 Abs(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Acosh(BinaryDenominatedUInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Asinh(BinaryDenominatedUInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Atanh(BinaryDenominatedUInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Cosh(BinaryDenominatedUInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Invert(ulong wholeNumber, BinaryDenominatedUInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Invert(ulong wholeNumber, BinaryDenominatedUInt64 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Invert(ulong wholeNumber, BinaryDenominatedUInt64 fraction, out ulong fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Log2(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 MaxMagnitude(BinaryDenominatedUInt64 x, BinaryDenominatedUInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 MaxMagnitudeNumber(BinaryDenominatedUInt64 x, BinaryDenominatedUInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 MinMagnitude(BinaryDenominatedUInt64 x, BinaryDenominatedUInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 MinMagnitudeNumber(BinaryDenominatedUInt64 x, BinaryDenominatedUInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Normalize(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Normalize(BinaryDenominatedUInt64 fraction, out ulong wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Sinh(BinaryDenominatedUInt64 x)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 Tanh(BinaryDenominatedUInt64 x)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedUInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedUInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedUInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedUInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedUInt64>.TryConvertFromChecked<TOther>(TOther value, out BinaryDenominatedUInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedUInt64>.TryConvertFromSaturating<TOther>(TOther value, out BinaryDenominatedUInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedUInt64>.TryConvertFromTruncating<TOther>(TOther value, out BinaryDenominatedUInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedUInt64>.TryConvertToChecked<TOther>(BinaryDenominatedUInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedUInt64>.TryConvertToSaturating<TOther>(BinaryDenominatedUInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedUInt64>.TryConvertToTruncating<TOther>(BinaryDenominatedUInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Instance Methods
    
    int IComparable.CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(BinaryDenominatedUInt64 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(BinaryDenominatedUInt64 other)
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

    public string ToString(string? format, IFormatProvider? formatProvider)
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

    public static BinaryDenominatedUInt64 operator +(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator +(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator -(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator -(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator ~(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator ++(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator --(BinaryDenominatedUInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator *(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator /(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator %(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator &(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator |(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedUInt64 operator ^(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(BinaryDenominatedUInt64 left, BinaryDenominatedUInt64 right)
    {
        throw new NotImplementedException();
    }
    
    #endregion
}
