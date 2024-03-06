using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct Fraction32 : ISimpleSignedFraction<Fraction32, short, MixedFraction48>
{
    #region Static Properties

    public static Fraction32 NegativeOne { get; } = new(-1, 1);

    public static Fraction32 One { get; } = new(1, 1);

    public static Fraction32 Zero { get; } = new(0, 1);

    public static Fraction32 MaxValue { get; } = new(short.MaxValue, 1);

    public static Fraction32 MinValue { get; } = new(short.MinValue, 1);

    public static Fraction32 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public short Numerator { get; }

    public short Denominator { get; }

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

    public MixedFraction48 Add(short wholeNumber1, short wholeNumber2, Fraction32 fraction2)
    {
        (short wholeNumber, short numerator, short denominator) = AddFractions(wholeNumber1, this, wholeNumber2, fraction2);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction32 Add(Fraction32 fraction)
    {
        (short numerator, short denominator) = AddSimpleFractions<Fraction32, short>(this, fraction);
        return new(numerator, denominator);
    }

    public int CompareTo(Fraction32 other) => CompareFractionComponents(Numerator, Denominator, other.Numerator, other.Denominator);

    public MixedFraction48 Divide(short wholeDividend, short wholeDivisor, Fraction32 divisorFraction)
    {
        (short wholeNumber, short numerator, short denominator) = DivideFractions(wholeDividend, this, wholeDivisor, divisorFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction32 Divide(Fraction32 fraction)
    {
        (short numerator, short denominator) = DivideSimpleFractions<Fraction32, short>(this, fraction);
        return new(numerator, denominator);
    }

    public bool Equals(Fraction32 other) => AreSimpleFractionsEqual<Fraction32, short>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Fraction32 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public MixedFraction48 Join(short wholeNumber) => new(wholeNumber, Numerator, Denominator);

    public MixedFraction48 Multiply(short wholeMultiplier, short wholeMultiplicand, Fraction32 multiplicandFraction)
    {
        (short wholeNumber, short numerator, short denominator) = MultiplyFractions(wholeMultiplier, this, wholeMultiplicand, multiplicandFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction32 Multiply(Fraction32 fraction)
    {
        (short numerator, short denominator) = MultiplySimpleFractions<Fraction32, short>(this, fraction);
        return new(numerator, denominator);
    }

    public MixedFraction48 Subtract(short wholeMinuend, short wholeSubtrahend, Fraction32 subtrahendFraction)
    {
        (short wholeNumber, short numerator, short denominator) = SubtractFractions(wholeMinuend, this, wholeSubtrahend, subtrahendFraction);
        return new(wholeNumber, numerator, denominator);
    }

    public Fraction32 Subtract(Fraction32 fraction)
    {
        (short numerator, short denominator) = SubtractSimpleFractions<Fraction32, short>(this, fraction);
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

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatSimpleFraction<Fraction32, short>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static Fraction32 Abs(Fraction32 value) => (value.Denominator == 0) ? value : new(short.Abs(value.Numerator), short.Abs(value.Denominator));

    public static Fraction32 Add(short wholeNumber1, Fraction32 fraction1, short wholeNumber2, Fraction32 fraction2, out short sum)
    {
        (short wholeNumber, short numerator, short denominator) = AddFractions(wholeNumber1, fraction1, wholeNumber2, fraction2);
        throw new NotImplementedException();
    }

    public static Fraction32 Add(MixedFraction48 fraction1, short wholeNumber2, Fraction32 fraction2, out short sum)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Add(short wholeNumber1, Fraction32 fraction1, MixedFraction48 fraction2, out short sum)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Add(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Divide(short wholeDividend, Fraction32 dividendFraction, short wholeDivisor, Fraction32 divisorFraction, out short quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Divide(MixedFraction48 dividend, short wholeDivisor, Fraction32 divisorFraction, out short quotient)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Divide(short wholeDividend, Fraction32 dividendFraction, MixedFraction48 divisor, out short quotient)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Divide(short wholeNumber, Fraction32 fraction)
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

    public static bool IsEvenInteger(Fraction32 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0 && value.Numerator / value.Denominator % 2 == 0));

    public static bool IsInteger(Fraction32 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0));

    public static bool IsNaN(Fraction32 value) => value.Denominator == 0;

    public static bool IsNegative(Fraction32 value) => value.Denominator != 0 && value.Numerator != 0 && ((value.Denominator < 0) ? value.Numerator > 0 : value.Numerator < 0);

    public static bool IsOddInteger(Fraction32 value) => value.Denominator != 0 && value.Numerator != 0 && Math.Abs(value.Numerator) > Math.Abs(value.Denominator) &&
        value.Numerator % value.Denominator == 0 && value.Numerator / value.Denominator % 2 != 0;

    public static bool IsPositive(Fraction32 value) => value.Denominator != 0 && (value.Numerator == 0 || ((value.Denominator < 0) ? value.Numerator < 0 : value.Numerator > 0));

    public static bool IsPow2(Fraction32 value) => double.IsPow2(value.ToDouble());

    public static bool IsProperFraction(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Fraction32 value) => value.Denominator != 0;

    public static bool IsSimplestForm(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Fraction32 value) => value.Numerator == 0 && value.Denominator != 0;

    public static Fraction32 Log2(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 MaxMagnitude(Fraction32 x, Fraction32 y) => (x > y) ? x : y;

    public static Fraction32 MaxMagnitudeNumber(Fraction32 x, Fraction32 y)
    {
        Fraction32 ax = Abs(x);
        Fraction32 ay = Abs(y);
        if ((ax > ay) || ay.Denominator == 0) return x;
        return (ax != ay) ? y : IsNegative(x) ? y : x;
    }

    public static Fraction32 MinMagnitude(Fraction32 x, Fraction32 y) => (x < y) ? x : y;

    public static Fraction32 MinMagnitudeNumber(Fraction32 x, Fraction32 y)
    {
        Fraction32 ax = Abs(x);
        Fraction32 ay = Abs(y);
        if ((ax < ay) || ay.Denominator == 0) return x;
        return (ax != ay) ? y : IsNegative(x) ? x : y;
    }

    public static Fraction32 Multiply(short wholeMultiplier, Fraction32 multiplierFraction, short wholeMultiplicand, Fraction32 multiplicandFraction, out short product)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Multiply(MixedFraction48 multiplier, short wholeMultiplicand, Fraction32 multiplicandFraction, out short product)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Multiply(short wholeMultiplier, Fraction32 multiplierFraction, MixedFraction48 multiplicand, out short product)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Multiply(short wholeNumber, Fraction32 fraction)
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

    public static Fraction32 Subtract(MixedFraction48 minuend, short wholeSubtrahend, Fraction32 subtrahendFraction, out short difference)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 Subtract(short wholeMinuend, Fraction32 minuendFraction, MixedFraction48 subtrahend, out short difference)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Subtract(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 ToProperFraction(Fraction32 value, out short wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 ToProperFraction(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 ToProperSimplestForm(Fraction32 value, out short wholeNumber)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 ToProperSimplestForm(Fraction32 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction32 ToSimplestForm(Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        if (TryParseSimpleFraction(s, style, provider, out short numerator, out short denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), style, provider, out short numerator, out short denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        if (TryParseSimpleFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out short numerator, out short denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction32 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out short numerator, out short denominator))
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

    static int INumberBase<Fraction32>.Radix => 2;

    static Fraction32 IAdditiveIdentity<Fraction32, Fraction32>.AdditiveIdentity => Zero;

    static Fraction32 IMultiplicativeIdentity<Fraction32, Fraction32>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is Fraction32 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<Fraction32, short>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<Fraction32>.IsCanonical(Fraction32 value) => true;

    static bool INumberBase<Fraction32>.IsComplexNumber(Fraction32 value) => false;

    static bool INumberBase<Fraction32>.IsFinite(Fraction32 value) => true;

    static bool INumberBase<Fraction32>.IsImaginaryNumber(Fraction32 value) => false;

    static bool INumberBase<Fraction32>.IsInfinity(Fraction32 value) => false;

    static bool INumberBase<Fraction32>.IsNegativeInfinity(Fraction32 value) => false;

    static bool INumberBase<Fraction32>.IsNormal(Fraction32 value) => true;

    static bool INumberBase<Fraction32>.IsPositiveInfinity(Fraction32 value) => false;

    static bool INumberBase<Fraction32>.IsSubnormal(Fraction32 value) => false;

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
