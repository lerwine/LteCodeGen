using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct FractionU32 : IFraction<FractionU32, ushort, uint>
{
    public static FractionU32 E => throw new NotImplementedException();

    public static FractionU32 Pi => throw new NotImplementedException();

    public static FractionU32 Tau => throw new NotImplementedException();

    public static FractionU32 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static FractionU32 Zero => throw new NotImplementedException();

    public static FractionU32 AdditiveIdentity => throw new NotImplementedException();

    public static FractionU32 MultiplicativeIdentity => throw new NotImplementedException();

    public static FractionU32 MaxValue => throw new NotImplementedException();

    public static FractionU32 MinValue => throw new NotImplementedException();

    public ushort Numerator => throw new NotImplementedException();

    public ushort Denominator => throw new NotImplementedException();

    IConvertible IFraction.Numerator => throw new NotImplementedException();

    IConvertible IFraction.Denominator => throw new NotImplementedException();

    public static FractionU32 Abs(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Acosh(FractionU32 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Asinh(FractionU32 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Atanh(FractionU32 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Cosh(FractionU32 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Invert(uint wholeNumber, FractionU32 fraction)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Invert(uint wholeNumber, FractionU32 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Invert(uint wholeNumber, FractionU32 fraction, out uint fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Log2(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 MaxMagnitude(FractionU32 x, FractionU32 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 MaxMagnitudeNumber(FractionU32 x, FractionU32 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 MinMagnitude(FractionU32 x, FractionU32 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 MinMagnitudeNumber(FractionU32 x, FractionU32 y)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Normalize(FractionU32 fraction, out uint wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Sinh(FractionU32 x)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 Tanh(FractionU32 x)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out FractionU32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU32>.TryConvertFromChecked<TOther>(TOther value, out FractionU32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU32>.TryConvertFromSaturating<TOther>(TOther value, out FractionU32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU32>.TryConvertFromTruncating<TOther>(TOther value, out FractionU32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU32>.TryConvertToChecked<TOther>(FractionU32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU32>.TryConvertToSaturating<TOther>(FractionU32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<FractionU32>.TryConvertToTruncating<TOther>(FractionU32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(FractionU32 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(FractionU32 other)
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

    public static FractionU32 operator +(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator +(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator -(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator -(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator ~(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator ++(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator --(FractionU32 value)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator *(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator /(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator %(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator &(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator |(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static FractionU32 operator ^(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(FractionU32 left, FractionU32 right)
    {
        throw new NotImplementedException();
    }
}
