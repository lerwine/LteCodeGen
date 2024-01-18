using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction16 : IFraction<Fraction16, sbyte, int>
{
    public static Fraction16 E => throw new NotImplementedException();

    public static Fraction16 Pi => throw new NotImplementedException();

    public static Fraction16 Tau => throw new NotImplementedException();

    public static Fraction16 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static Fraction16 Zero => throw new NotImplementedException();

    public static Fraction16 AdditiveIdentity => throw new NotImplementedException();

    public static Fraction16 MultiplicativeIdentity => throw new NotImplementedException();

    public static Fraction16 MaxValue => throw new NotImplementedException();

    public static Fraction16 MinValue => throw new NotImplementedException();

    public sbyte Numerator => throw new NotImplementedException();

    public sbyte Denominator => throw new NotImplementedException();

    IConvertible IFraction.Numerator => throw new NotImplementedException();

    IConvertible IFraction.Denominator => throw new NotImplementedException();

    public static Fraction16 Abs(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Acosh(Fraction16 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Asinh(Fraction16 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Atanh(Fraction16 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Cosh(Fraction16 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Invert(int wholeNumber, Fraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Invert(int wholeNumber, Fraction16 fraction, bool doNotNormalize)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Invert(int wholeNumber, Fraction16 fraction, out int fromInverted)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormalized(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Log2(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 MaxMagnitude(Fraction16 x, Fraction16 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 MaxMagnitudeNumber(Fraction16 x, Fraction16 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 MinMagnitude(Fraction16 x, Fraction16 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 MinMagnitudeNumber(Fraction16 x, Fraction16 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Normalize(Fraction16 fraction, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Sinh(Fraction16 x)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 Tanh(Fraction16 x)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction16 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction16>.TryConvertFromChecked<TOther>(TOther value, out Fraction16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction16>.TryConvertFromSaturating<TOther>(TOther value, out Fraction16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction16>.TryConvertFromTruncating<TOther>(TOther value, out Fraction16 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction16>.TryConvertToChecked<TOther>(Fraction16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction16>.TryConvertToSaturating<TOther>(Fraction16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction16>.TryConvertToTruncating<TOther>(Fraction16 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Fraction16 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Fraction16 other)
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

    public static Fraction16 operator +(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator +(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator -(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator -(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator ~(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator ++(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator --(Fraction16 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator *(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator /(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator %(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator &(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator |(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction16 operator ^(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Fraction16 left, Fraction16 right)
    {
        throw new NotImplementedException();
    }
}
