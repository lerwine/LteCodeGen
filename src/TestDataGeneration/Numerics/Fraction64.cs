using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction64 : IFraction<Fraction64, int, long>
{
    public static Fraction64 E => throw new NotImplementedException();

    public static Fraction64 Pi => throw new NotImplementedException();

    public static Fraction64 Tau => throw new NotImplementedException();

    public static Fraction64 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static Fraction64 Zero => throw new NotImplementedException();

    public static Fraction64 AdditiveIdentity => throw new NotImplementedException();

    public static Fraction64 MultiplicativeIdentity => throw new NotImplementedException();

    public static Fraction64 MaxValue => throw new NotImplementedException();

    public static Fraction64 MinValue => throw new NotImplementedException();

    public int Numerator => throw new NotImplementedException();

    public int Denominator => throw new NotImplementedException();

    IConvertible IFraction.Numerator => throw new NotImplementedException();

    IConvertible IFraction.Denominator => throw new NotImplementedException();

    public static Fraction64 Abs(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Acosh(Fraction64 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Asinh(Fraction64 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Atanh(Fraction64 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Cosh(Fraction64 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Invert(long wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Invert(long wholeNumber, Fraction64 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Invert(long wholeNumber, Fraction64 fraction, out long fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Log2(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 MaxMagnitude(Fraction64 x, Fraction64 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 MaxMagnitudeNumber(Fraction64 x, Fraction64 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 MinMagnitude(Fraction64 x, Fraction64 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 MinMagnitudeNumber(Fraction64 x, Fraction64 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Normalize(Fraction64 fraction, out long wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Sinh(Fraction64 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Tanh(Fraction64 x)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertFromChecked<TOther>(TOther value, out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertFromSaturating<TOther>(TOther value, out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertFromTruncating<TOther>(TOther value, out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertToChecked<TOther>(Fraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertToSaturating<TOther>(Fraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertToTruncating<TOther>(Fraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Fraction64 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Fraction64 other)
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

    public static Fraction64 operator +(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator +(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator -(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator -(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator ~(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator ++(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator --(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator *(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator /(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator %(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator &(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator |(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator ^(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }
}
