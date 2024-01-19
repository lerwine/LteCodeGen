using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction64 : ISimpleSignedFraction<Fraction64, int, MixedFraction128>
{
    #region Static Properties

    public static Fraction64 NegativeOne { get; } = new(-1, 1);

    public static Fraction64 One { get; } = new(1, 1);

    public static Fraction64 Zero { get; } = new(0, 1);

    public static Fraction64 MaxValue { get; } = new(int.MaxValue, 1);

    public static Fraction64 MinValue { get; } = new(int.MinValue, 1);

    #endregion

    #region Instance Properties

    public int Numerator { get; }

    public int Denominator { get; } = 1;

    #endregion

    #region Constructors

    public Fraction64(int numerator, int denominator, bool doNotReduce = false)
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

    public MixedFraction128 Add(int wholeNumber1, int wholeNumber2, Fraction64 fraction2)
    {
        throw new NotImplementedException();
    }

    public Fraction64 Add(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Fraction64 other)
    {
        throw new NotImplementedException();
    }

    public MixedFraction128 Divide(int wholeDividend, int wholeDivisor, Fraction64 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction64 Divide(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Fraction64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Fraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public MixedFraction128 Join(int wholeNumber)
    {
        throw new NotImplementedException();
    }

    public MixedFraction128 Multiply(int wholeMultiplier, int wholeMultiplicand, Fraction64 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction64 Multiply(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public MixedFraction128 Subtract(int wholeMinuend, int wholeSubtrahend, Fraction64 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction64 Subtract(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Static Methods

    public static Fraction64 Abs(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Add(int wholeNumber1, Fraction64 fraction1, int wholeNumber2, Fraction64 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Add(MixedFraction128 fraction1, int wholeNumber2, Fraction64 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Add(int wholeNumber1, Fraction64 fraction1, MixedFraction128 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Add(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Divide(int wholeDividend, Fraction64 dividendFraction, int wholeDivisor, Fraction64 divisorFraction, out int quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Divide(MixedFraction128 dividend, int wholeDivisor, Fraction64 divisorFraction, out int quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Divide(int wholeDividend, Fraction64 dividendFraction, MixedFraction128 divisor, out int quotient)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Divide(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Invert(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Invert(Fraction64 fraction, bool doNotReduce)
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

    public static bool IsProperFraction(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(Fraction64 value)
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

    public static Fraction64 Multiply(int wholeMultiplier, Fraction64 multiplierFraction, int wholeMultiplicand, Fraction64 multiplicandFraction, out int product)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Multiply(MixedFraction128 multiplier, int wholeMultiplicand, Fraction64 multiplicandFraction, out int product)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Multiply(int wholeMultiplier, Fraction64 multiplierFraction, MixedFraction128 multiplicand, out int product)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Multiply(int wholeNumber, Fraction64 fraction)
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

    public static Fraction64 Subtract(int wholeMinuend, Fraction64 minuendFraction, int wholeSubtrahend, Fraction64 subtrahendFraction, out int difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Subtract(MixedFraction128 minuend, int wholeSubtrahend, Fraction64 subtrahendFraction, out int difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Subtract(int wholeMinuend, Fraction64 minuendFraction, MixedFraction128 subtrahend, out int difference)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Subtract(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 ToProperFraction(Fraction64 value, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToProperFraction(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 ToProperSimplestForm(Fraction64 value, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToProperSimplestForm(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 ToSimplestForm(Fraction64 fraction)
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

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<Fraction64>.Radix => 10;

    static Fraction64 IAdditiveIdentity<Fraction64, Fraction64>.AdditiveIdentity => Zero;

    static Fraction64 IMultiplicativeIdentity<Fraction64, Fraction64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is Fraction64 other) ? CompareTo(other) : -1;

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

    public override string ToString()
    {
        return base.ToString() ?? string.Empty;
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

    #endregion

    #endregion

    #region Static Operators

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

    #endregion
}
