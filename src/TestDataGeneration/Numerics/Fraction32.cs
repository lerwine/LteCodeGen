using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction32 : ISimpleSignedFraction<Fraction32, short, MixedFraction64>
{
    #region Static Properties

    public static Fraction32 NegativeOne { get; } = new(-1, 1);

    public static Fraction32 One { get; } = new(1, 1);

    static int INumberBase<Fraction32>.Radix => 10;

    public static Fraction32 Zero { get; } = new(0, 1);

    static Fraction32 IAdditiveIdentity<Fraction32, Fraction32>.AdditiveIdentity => Zero;

    static Fraction32 IMultiplicativeIdentity<Fraction32, Fraction32>.MultiplicativeIdentity => One;

    public static Fraction32 MaxValue { get; } = new(short.MaxValue, 1);

    public static Fraction32 MinValue { get; } = new(short.MinValue, 1);

    #endregion
    
    #region Instance Properties

    public short Numerator { get; }

    public short Denominator { get; } = 1;

    #endregion
    
    #region Constructors

    public Fraction32(short numerator, short denominator, bool doNotReduce = false)
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

    public MixedFraction64 Add(short wholeNumber1, short wholeNumber2, Fraction32 fraction2)
    {
        throw new NotImplementedException();
    }

    public Fraction32 Add(Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Fraction32 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is Fraction32 other) ? CompareTo(other) : -1;
    
    public MixedFraction64 Divide(short wholeDividend, short wholeDivisor, Fraction32 divisorFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction32 Divide(Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Fraction32 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Fraction32 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public MixedFraction64 Join(short wholeNumber)
    {
        throw new NotImplementedException();
    }

    public MixedFraction64 Multiply(short wholeMultiplier, short wholeMultiplicand, Fraction32 multiplicandFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction32 Multiply(Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public MixedFraction64 Subtract(short wholeMinuend, short wholeSubtrahend, Fraction32 subtrahendFraction)
    {
        throw new NotImplementedException();
    }

    public Fraction32 Subtract(Fraction32 fraction)
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

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Methods
    
    public static Fraction32 Abs(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Add(short wholeNumber1, Fraction32 fraction1, short wholeNumber2, Fraction32 fraction2, out short sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Add(MixedFraction64 fraction1, short wholeNumber2, Fraction32 fraction2, out short sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Add(short wholeNumber1, Fraction32 fraction1, MixedFraction64 fraction2, out short sum)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Add(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Divide(short wholeDividend, Fraction32 dividendFraction, short wholeDivisor, Fraction32 divisorFraction, out short quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Divide(MixedFraction64 dividend, short wholeDivisor, Fraction32 divisorFraction, out short quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Divide(short wholeDividend, Fraction32 dividendFraction, MixedFraction64 divisor, out short quotient)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Divide(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Invert(Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Invert(Fraction32 fraction, bool doNotReduce)
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

    public static bool IsProperFraction(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(Fraction32 value)
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

    public static Fraction32 Multiply(short wholeMultiplier, Fraction32 multiplierFraction, short wholeMultiplicand, Fraction32 multiplicandFraction, out short product)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Multiply(MixedFraction64 multiplier, short wholeMultiplicand, Fraction32 multiplicandFraction, out short product)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Multiply(short wholeMultiplier, Fraction32 multiplierFraction, MixedFraction64 multiplicand, out short product)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Multiply(short wholeNumber, Fraction32 fraction)
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

    public static Fraction32 Subtract(short wholeMinuend, Fraction32 minuendFraction, short wholeSubtrahend, Fraction32 subtrahendFraction, out short difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Subtract(MixedFraction64 minuend, short wholeSubtrahend, Fraction32 subtrahendFraction, out short difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Subtract(short wholeMinuend, Fraction32 minuendFraction, MixedFraction64 subtrahend, out short difference)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Subtract(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 ToProperFraction(Fraction32 value, out short wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToProperFraction(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 ToProperSimplestForm(Fraction32 value, out short wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToProperSimplestForm(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 ToSimplestForm(Fraction32 fraction)
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

    #endregion
    
    #region Static Operators

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

    #endregion
}
