using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction64 : ISimpleSignedFraction<Fraction64, int, MixedFraction96>
{
    #region Static Properties

    public static Fraction64 NegativeOne { get; } = new(-1, 1);

    public static Fraction64 One { get; } = new(1, 1);

    public static Fraction64 Zero { get; } = new(0, 1);

    public static Fraction64 MaxValue { get; } = new(int.MaxValue, 1);

    public static Fraction64 MinValue { get; } = new(int.MinValue, 1);

    public static Fraction64 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public int Numerator { get; }

    public int Denominator { get; }

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

    public MixedFraction96 Add(int wholeNumber1, int wholeNumber2, Fraction64 fraction2)
    {
        (int wholeNumber, int numerator, int denominator) = AddFractions(wholeNumber1, this, wholeNumber2, fraction2);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction64 Add(Fraction64 fraction)
    {
        (int numerator, int denominator) = AddSimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    public int CompareTo(Fraction64 other) => CompareFractionComponents(Numerator, Denominator, other.Numerator, other.Denominator);

    public MixedFraction96 Divide(int wholeDividend, int wholeDivisor, Fraction64 divisorFraction)
    {
        (int wholeNumber, int numerator, int denominator) = DivideFractions(wholeDividend, this, wholeDivisor, divisorFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction64 Divide(Fraction64 fraction)
    {
        (int numerator, int denominator) = DivideSimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    public bool Equals(Fraction64 other) => AreSimpleFractionsEqual<Fraction64, int>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Fraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public MixedFraction96 Join(int wholeNumber) => new(wholeNumber, Numerator, Denominator);

    public MixedFraction96 Multiply(int wholeMultiplier, int wholeMultiplicand, Fraction64 multiplicandFraction)
    {
        (int wholeNumber, int numerator, int denominator) = MultiplyFractions(wholeMultiplier, this, wholeMultiplicand, multiplicandFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction64 Multiply(Fraction64 fraction)
    {
        (int numerator, int denominator) = MultiplySimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    public MixedFraction96 Subtract(int wholeMinuend, int wholeSubtrahend, Fraction64 subtrahendFraction)
    {
        (int wholeNumber, int numerator, int denominator) = SubtractFractions(wholeMinuend, this, wholeSubtrahend, subtrahendFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction64 Subtract(Fraction64 fraction)
    {
        (int numerator, int denominator) = SubtractSimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0) return double.NaN;
        if (provider is null)
            return (Numerator == 0) ? Convert.ToDouble(Numerator) : Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
        return (Numerator == 0) ? Convert.ToDouble(Numerator, provider) : Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider);
    }

    public override string ToString() => ToFractionString(Numerator, Denominator);

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatSimpleFraction<Fraction64, int>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static Fraction64 Abs(Fraction64 value) => (value.Denominator == 0) ? value : new(int.Abs(value.Numerator), int.Abs(value.Denominator));

    public static Fraction64 Add(int wholeNumber1, Fraction64 fraction1, int wholeNumber2, Fraction64 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Add(MixedFraction96 fraction1, int wholeNumber2, Fraction64 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Add(int wholeNumber1, Fraction64 fraction1, MixedFraction96 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Add(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Divide(int wholeDividend, Fraction64 dividendFraction, int wholeDivisor, Fraction64 divisorFraction, out int quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Divide(MixedFraction96 dividend, int wholeDivisor, Fraction64 divisorFraction, out int quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Divide(int wholeDividend, Fraction64 dividendFraction, MixedFraction96 divisor, out int quotient)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Divide(int wholeNumber, Fraction64 fraction)
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

    public static Fraction64 Multiply(MixedFraction96 multiplier, int wholeMultiplicand, Fraction64 multiplicandFraction, out int product)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Multiply(int wholeMultiplier, Fraction64 multiplierFraction, MixedFraction96 multiplicand, out int product)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Multiply(int wholeNumber, Fraction64 fraction)
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

    public static Fraction64 Subtract(MixedFraction96 minuend, int wholeSubtrahend, Fraction64 subtrahendFraction, out int difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 Subtract(int wholeMinuend, Fraction64 minuendFraction, MixedFraction96 subtrahend, out int difference)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 Subtract(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 ToProperFraction(Fraction64 value, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 ToProperFraction(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 ToProperSimplestForm(Fraction64 value, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction96 ToProperSimplestForm(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 ToSimplestForm(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        if (TryParseSimpleFraction(s, style, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), style, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        if (TryParseSimpleFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
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

    TypeCode IConvertible.GetTypeCode() => TypeCode.Double;

    bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(ToDouble(provider), provider);

    byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(ToDouble(provider), provider);

    char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(ToDouble(provider), provider);

    DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(ToDouble(provider), provider);

    decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(ToDouble(provider), provider);

    short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(ToDouble(provider), provider);

    int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(ToDouble(provider), provider);

    long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(ToDouble(provider), provider);

    sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(ToDouble(provider), provider);

    float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(ToDouble(provider), provider);

    string IConvertible.ToString(IFormatProvider? provider) => ToFractionString(Numerator, Denominator, provider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToFractionString(Numerator, Denominator, format, formatProvider);

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<Fraction64, int>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

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
