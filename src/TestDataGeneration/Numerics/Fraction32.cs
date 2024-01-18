using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction32 : IFraction<Fraction32, short, int>
{
    public static Fraction32 E => throw new NotImplementedException();

    public static Fraction32 Pi => throw new NotImplementedException();

    public static Fraction32 Tau => throw new NotImplementedException();

    public static Fraction32 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static Fraction32 Zero => throw new NotImplementedException();

    public static Fraction32 AdditiveIdentity => throw new NotImplementedException();

    public static Fraction32 MultiplicativeIdentity => throw new NotImplementedException();

    public static Fraction32 MaxValue => throw new NotImplementedException();

    public static Fraction32 MinValue => throw new NotImplementedException();

    public short Numerator => throw new NotImplementedException();

    public short Denominator => throw new NotImplementedException();

    IConvertible IFraction.Numerator => throw new NotImplementedException();

    IConvertible IFraction.Denominator => throw new NotImplementedException();

    public static Fraction32 Abs(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Acosh(Fraction32 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Asinh(Fraction32 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Atanh(Fraction32 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Cosh(Fraction32 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Invert(int wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Invert(int wholeNumber, Fraction32 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Invert(int wholeNumber, Fraction32 fraction, out int fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Log2(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 MaxMagnitude(Fraction32 x, Fraction32 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 MaxMagnitudeNumber(Fraction32 x, Fraction32 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 MinMagnitude(Fraction32 x, Fraction32 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 MinMagnitudeNumber(Fraction32 x, Fraction32 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Normalize(Fraction32 fraction, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Sinh(Fraction32 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Tanh(Fraction32 x)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction32>.TryConvertFromChecked<TOther>(TOther value, out Fraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction32>.TryConvertFromSaturating<TOther>(TOther value, out Fraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction32>.TryConvertFromTruncating<TOther>(TOther value, out Fraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction32>.TryConvertToChecked<TOther>(Fraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction32>.TryConvertToSaturating<TOther>(Fraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction32>.TryConvertToTruncating<TOther>(Fraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Fraction32 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Fraction32 other)
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

    public static Fraction32 operator +(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator +(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator -(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator -(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator ~(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator ++(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator --(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator *(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator /(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator %(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator &(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator |(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 operator ^(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Fraction32 left, Fraction32 right)
    {
        throw new NotImplementedException();
    }
}
