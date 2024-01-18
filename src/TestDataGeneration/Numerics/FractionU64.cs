using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct FractionU64 : IFraction<FractionU64, uint, ulong>
{
    public static FractionU64 E => throw new NotImplementedException();

    public static FractionU64 Pi => throw new NotImplementedException();

    public static FractionU64 Tau => throw new NotImplementedException();

    public static FractionU64 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static FractionU64 Zero => throw new NotImplementedException();

    public static FractionU64 AdditiveIdentity => throw new NotImplementedException();

    public static FractionU64 MultiplicativeIdentity => throw new NotImplementedException();

    public static FractionU64 MaxValue => throw new NotImplementedException();

    public static FractionU64 MinValue => throw new NotImplementedException();

    public uint Numerator => throw new NotImplementedException();

    public uint Denominator => throw new NotImplementedException();

    IConvertible IFraction.Numerator => throw new NotImplementedException();

    IConvertible IFraction.Denominator => throw new NotImplementedException();

    public static FractionU64 Abs(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Acosh(FractionU64 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Asinh(FractionU64 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Atanh(FractionU64 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Cosh(FractionU64 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Invert(ulong wholeNumber, FractionU64 fraction)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Invert(ulong wholeNumber, FractionU64 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Invert(ulong wholeNumber, FractionU64 fraction, out ulong fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Log2(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 MaxMagnitude(FractionU64 x, FractionU64 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 MaxMagnitudeNumber(FractionU64 x, FractionU64 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 MinMagnitude(FractionU64 x, FractionU64 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 MinMagnitudeNumber(FractionU64 x, FractionU64 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Normalize(FractionU64 fraction, out ulong wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Sinh(FractionU64 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 Tanh(FractionU64 x)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU64>.TryConvertFromChecked<TOther>(TOther value, out FractionU64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU64>.TryConvertFromSaturating<TOther>(TOther value, out FractionU64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU64>.TryConvertFromTruncating<TOther>(TOther value, out FractionU64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU64>.TryConvertToChecked<TOther>(FractionU64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU64>.TryConvertToSaturating<TOther>(FractionU64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU64>.TryConvertToTruncating<TOther>(FractionU64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(FractionU64 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(FractionU64 other)
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

    public static FractionU64 operator +(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator +(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator -(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator -(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator ~(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator ++(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator --(FractionU64 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator *(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator /(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator %(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator &(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator |(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU64 operator ^(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(FractionU64 left, FractionU64 right)
    {
        throw new NotImplementedException();
    }
}
