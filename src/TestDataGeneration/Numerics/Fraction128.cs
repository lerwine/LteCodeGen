using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction128 : ISimpleSignedFraction<Fraction128, long, MixedFraction256>
{
    #region Static Properties

    public static Fraction128 NegativeOne { get; } = new(-1L, 1L);

    public static Fraction128 One { get; } = new(1L, 1L);

    public static Fraction128 Zero { get; } = new(0L, 1L);

    public static Fraction128 MaxValue { get; } = new(long.MaxValue, 1L);

    public static Fraction128 MinValue { get; } = new(long.MinValue, 1L);

    #endregion

    #region Instance Properties

    public long Numerator { get; }

    public long Denominator { get; } = 1L;

    #endregion

    #region Constructors

    public Fraction128(long numerator, long denominator, bool doNotReduce = false)
    {
        if (doNotReduce)
        {
            if (denominator == 0) throw new DivideByZeroException();
        }
        else
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        Numerator = numerator;
        Denominator = denominator;
    }

    #endregion

    #region Instance Methods

    public MixedFraction256 Add(long wholeNumber1, long wholeNumber2, Fraction128 fraction2)
    {
        throw new NotImplementedException();
    }

    public Fraction128 Add(Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Fraction128 other)
    {
        throw new NotImplementedException();
    }

    public MixedFraction256 Divide(long wholeDividend, long wholeDivisor, Fraction128 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction128 Divide(Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Fraction128 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Fraction128 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public MixedFraction256 Join(long wholeNumber)
    {
        throw new NotImplementedException();
    }

    public MixedFraction256 Multiply(long wholeMultiplier, long wholeMultiplicand, Fraction128 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction128 Multiply(Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public MixedFraction256 Subtract(long wholeMinuend, long wholeSubtrahend, Fraction128 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction128 Subtract(Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() ?? string.Empty;
    }


    #endregion

    #region Static Methods

    public static Fraction128 Abs(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Add(long wholeNumber1, Fraction128 fraction1, long wholeNumber2, Fraction128 fraction2, out long sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Add(MixedFraction256 fraction1, long wholeNumber2, Fraction128 fraction2, out long sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Add(long wholeNumber1, Fraction128 fraction1, MixedFraction256 fraction2, out long sum)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Add(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Divide(long wholeDividend, Fraction128 dividendFraction, long wholeDivisor, Fraction128 divisorFraction, out long quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Divide(MixedFraction256 dividend, long wholeDivisor, Fraction128 divisorFraction, out long quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Divide(long wholeDividend, Fraction128 dividendFraction, MixedFraction256 divisor, out long quotient)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Divide(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Invert(Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Invert(Fraction128 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Log2(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 MaxMagnitude(Fraction128 x, Fraction128 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 MaxMagnitudeNumber(Fraction128 x, Fraction128 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 MinMagnitude(Fraction128 x, Fraction128 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 MinMagnitudeNumber(Fraction128 x, Fraction128 y)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Multiply(long wholeMultiplier, Fraction128 multiplierFraction, long wholeMultiplicand, Fraction128 multiplicandFraction, out long product)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Multiply(MixedFraction256 multiplier, long wholeMultiplicand, Fraction128 multiplicandFraction, out long product)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Multiply(long wholeMultiplier, Fraction128 multiplierFraction, MixedFraction256 multiplicand, out long product)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Multiply(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Subtract(long wholeMinuend, Fraction128 minuendFraction, long wholeSubtrahend, Fraction128 subtrahendFraction, out long difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Subtract(MixedFraction256 minuend, long wholeSubtrahend, Fraction128 subtrahendFraction, out long difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 Subtract(long wholeMinuend, Fraction128 minuendFraction, MixedFraction256 subtrahend, out long difference)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 Subtract(long wholeNumber, Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 ToProperFraction(Fraction128 value, out long wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToProperFraction(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 ToProperSimplestForm(Fraction128 value, out long wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction256 ToProperSimplestForm(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 ToSimplestForm(Fraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction128 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<Fraction128>.Radix => 10;

    static Fraction128 IAdditiveIdentity<Fraction128, Fraction128>.AdditiveIdentity => Zero;

    static Fraction128 IMultiplicativeIdentity<Fraction128, Fraction128>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is Fraction128 other) ? CompareTo(other) : -1;

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

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Static Methods

    static bool INumberBase<Fraction128>.TryConvertFromChecked<TOther>(TOther value, out Fraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction128>.TryConvertFromSaturating<TOther>(TOther value, out Fraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction128>.TryConvertFromTruncating<TOther>(TOther value, out Fraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction128>.TryConvertToChecked<TOther>(Fraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction128>.TryConvertToSaturating<TOther>(Fraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction128>.TryConvertToTruncating<TOther>(Fraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static Fraction128 operator +(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator +(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator -(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator -(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator ~(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator ++(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator --(Fraction128 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator *(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator /(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator %(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator &(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator |(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction128 operator ^(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Fraction128 left, Fraction128 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
