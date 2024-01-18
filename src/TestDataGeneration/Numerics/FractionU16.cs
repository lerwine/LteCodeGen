using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct FractionU16 : IFraction<FractionU16, byte, uint>
{
    public static FractionU16 E => throw new NotImplementedException();

    public static FractionU16 Pi => throw new NotImplementedException();

    public static FractionU16 Tau => throw new NotImplementedException();

    public static FractionU16 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static FractionU16 Zero => throw new NotImplementedException();

    public static FractionU16 AdditiveIdentity => throw new NotImplementedException();

    public static FractionU16 MultiplicativeIdentity => throw new NotImplementedException();

    public static FractionU16 MaxValue => throw new NotImplementedException();

    public static FractionU16 MinValue => throw new NotImplementedException();

    public byte Numerator => throw new NotImplementedException();

    public byte Denominator => throw new NotImplementedException();

    IConvertible IFraction.Numerator => throw new NotImplementedException();

    IConvertible IFraction.Denominator => throw new NotImplementedException();

    public static FractionU16 Abs(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Acosh(FractionU16 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Asinh(FractionU16 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Atanh(FractionU16 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Cosh(FractionU16 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Invert(uint wholeNumber, FractionU16 fraction)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Invert(uint wholeNumber, FractionU16 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Invert(uint wholeNumber, FractionU16 fraction, out uint fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Log2(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 MaxMagnitude(FractionU16 x, FractionU16 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 MaxMagnitudeNumber(FractionU16 x, FractionU16 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 MinMagnitude(FractionU16 x, FractionU16 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 MinMagnitudeNumber(FractionU16 x, FractionU16 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Normalize(FractionU16 fraction, out uint wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Sinh(FractionU16 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 Tanh(FractionU16 x)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU16>.TryConvertFromChecked<TOther>(TOther value, out FractionU16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU16>.TryConvertFromSaturating<TOther>(TOther value, out FractionU16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU16>.TryConvertFromTruncating<TOther>(TOther value, out FractionU16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU16>.TryConvertToChecked<TOther>(FractionU16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU16>.TryConvertToSaturating<TOther>(FractionU16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU16>.TryConvertToTruncating<TOther>(FractionU16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(FractionU16 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(FractionU16 other)
    {
        throw new NotImplementedException();
    }

    public TypeCode GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public bool ToBoolean(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public byte ToByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public char ToChar(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public DateTime ToDateTime(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public decimal ToDecimal()
    {
        throw new NotImplementedException();
    }

    public decimal ToDecimal(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public double ToDouble()
    {
        throw new NotImplementedException();
    }

    public double ToDouble(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public short ToInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public int ToInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public long ToInt64(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public sbyte ToSByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public float ToSingle()
    {
        throw new NotImplementedException();
    }

    public float ToSingle(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public string ToString(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }

    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public ushort ToUInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public uint ToUInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public ulong ToUInt64(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator +(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator +(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator -(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator -(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator ~(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator ++(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator --(FractionU16 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator *(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator /(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator %(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator &(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator |(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU16 operator ^(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(FractionU16 left, FractionU16 right)
    {
        throw new NotImplementedException();
    }
}