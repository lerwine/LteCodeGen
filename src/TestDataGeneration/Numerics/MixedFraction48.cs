using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction48 : IMixedSignedFraction<MixedFraction48, short, Fraction32>
{
    #region Static Properties

    public static MixedFraction48 NegativeOne { get; } = new(-1);

    public static MixedFraction48 One { get; } = new(1);

    public static MixedFraction48 Zero { get; } = new(0);

    public static MixedFraction48 MaxValue { get; } = new(short.MaxValue, short.MaxValue, 1);

    public static MixedFraction48 MinValue { get; } = new(short.MinValue, short.MaxValue, 1);

    public static MixedFraction48 NaN { get; } = new();

    #endregion

    #region Instance Properties

    public short WholeNumber { get; }

    public short Numerator { get; }

    public short Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction48(short wholeNumber, short numerator, short denominator, bool doNotReduce = false, bool doNotMakeProper = false)
    {
        if (doNotReduce)
        {
            if (doNotMakeProper)
            {
                if (denominator == 0) throw new DivideByZeroException();
            }
            else
                wholeNumber = GetProperRational(wholeNumber, numerator, denominator, out numerator);
        }
        else if (doNotMakeProper)
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        else
            wholeNumber = GetNormalizedRational(wholeNumber, numerator, denominator, out numerator, out denominator);
        WholeNumber = wholeNumber;
        Numerator = numerator;
        Denominator = denominator;
    }

    public MixedFraction48(short numerator, short denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction48(short wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction48 Add(MixedFraction48 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = AddFractions<MixedFraction48, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(MixedFraction48 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    public MixedFraction48 Divide(MixedFraction48 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = DivideFractions<MixedFraction48, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(MixedFraction48 other) => AreMixedFractionsEqual<MixedFraction48, short>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction48 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction48 Multiply(MixedFraction48 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = MultiplyFractions<MixedFraction48, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public short Split(out Fraction32 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    public MixedFraction48 Subtract(MixedFraction48 fraction)
    {
        (short wholeNumber, short numerator, short denominator) = SubtractFractions<MixedFraction48, short>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0) return double.NaN;
        if (provider is null)
            return (Numerator == 0) ? Convert.ToDouble(WholeNumber) : Convert.ToDouble(WholeNumber) + (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator));
        return (Numerator == 0) ? Convert.ToDouble(WholeNumber, provider) : Convert.ToDouble(WholeNumber, provider) + (Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider));
    }

    public override string ToString() => ToFractionString(Numerator, Denominator);

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatMixedFraction<MixedFraction48, short>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    public static MixedFraction48 Abs(MixedFraction48 value) => (value.Denominator == 0) ? value : new(short.Abs(value.Numerator), short.Abs(value.Denominator));

    public static MixedFraction48 Add(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Divide(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Invert(MixedFraction48 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Invert(MixedFraction48 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Invert(MixedFraction48 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction48 value) => value.Denominator != 0 && ((value.Numerator == 0) ? value.WholeNumber % 2 == 0 :
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 == 0));

    public static bool IsFinite(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction48 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0));

    public static bool IsNaN(MixedFraction48 value) => value.Denominator == 0;

    public static bool IsNegative(MixedFraction48 value) => value.Denominator != 0 &&
        ((value.Numerator != 0) ? ((value.Denominator < 0) ?
        ((value.Numerator > 0) ? value.WholeNumber > 0 : value.WholeNumber < 0) :
        (value.Numerator < 0) ? value.WholeNumber > 0 : value.WholeNumber < 0) : value.WholeNumber < 0);

    public static bool IsNegativeInfinity(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction48 value) => value.Denominator != 0 && ((value.Numerator != 0) ? Math.Abs(value.Numerator) > Math.Abs(value.Denominator) &&
        value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 != 0 : value.WholeNumber % 2 != 0);

    public static bool IsPositive(MixedFraction48 value) => value.Denominator != 0 &&
        ((value.Numerator == 0) ? value.WholeNumber >= 0 : ((value.Denominator < 0) ?
        ((value.Numerator < 0) ? value.WholeNumber > 0 : value.WholeNumber < 0) :
        (value.Numerator > 0) ? value.WholeNumber > 0 : value.WholeNumber < 0));

    public static bool IsPositiveInfinity(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction48 value) => double.IsPow2(value.ToDouble());

    public static bool IsProperFraction(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction48 value) => value.Denominator != 0;

    public static bool IsSimplestForm(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction48 value) => value.Numerator == 0 && value.WholeNumber == 0 && value.Denominator != 0;

    public static MixedFraction48 Log2(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 MaxMagnitude(MixedFraction48 x, MixedFraction48 y) => (x > y) ? x : y;

    public static MixedFraction48 MaxMagnitudeNumber(MixedFraction48 x, MixedFraction48 y)
    {
        MixedFraction48 ax = Abs(x);
        MixedFraction48 ay = Abs(y);
        if ((ax > ay) || ay.Denominator == 0) return x;
        return (ax != ay) ? y : IsNegative(x) ? y : x;
    }

    public static MixedFraction48 MinMagnitude(MixedFraction48 x, MixedFraction48 y) => (x < y) ? x : y;

    public static MixedFraction48 MinMagnitudeNumber(MixedFraction48 x, MixedFraction48 y)
    {
        MixedFraction48 ax = Abs(x);
        MixedFraction48 ay = Abs(y);
        if ((ax < ay) || ay.Denominator == 0) return x;
        return (ax != ay) ? y : IsNegative(x) ? x : y;
    }

    public static MixedFraction48 Multiply(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 Subtract(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 ToProperFraction(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 ToProperSimplestForm(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 ToSimplestForm(MixedFraction48 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction48 result)
    {
        if (TryParseMixedFraction(s, style, provider, out short wholeNumber, out short numerator, out short denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction48 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out short wholeNumber, out short numerator, out short denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction48 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out short wholeNumber, out short numerator, out short denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction48 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out short wholeNumber, out short numerator, out short denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<MixedFraction48>.Radix => 2;

    static MixedFraction48 IAdditiveIdentity<MixedFraction48, MixedFraction48>.AdditiveIdentity => Zero;

    static MixedFraction48 IMultiplicativeIdentity<MixedFraction48, MixedFraction48>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction48 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<MixedFraction48, short>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction48>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction48 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction48>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction48 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction48>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction48 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction48>.TryConvertToChecked<TOther>(MixedFraction48 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction48>.TryConvertToSaturating<TOther>(MixedFraction48 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction48>.TryConvertToTruncating<TOther>(MixedFraction48 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction48 operator +(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator +(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator -(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator -(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator ~(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator ++(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator --(MixedFraction48 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator *(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator /(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator %(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator &(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator |(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction48 operator ^(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction48 left, MixedFraction48 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
