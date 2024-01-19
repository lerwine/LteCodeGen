using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction128 : IMixedSignedFraction<MixedFraction128, int, Fraction64>
{
    #region Static Properties

    public static MixedFraction128 NegativeOne { get; } = new(-1);

    public static MixedFraction128 One { get; } = new(1);

    public static MixedFraction128 Zero { get; } = new(0);

    public static MixedFraction128 MaxValue { get; } = new(int.MaxValue, int.MaxValue, 1);

    public static MixedFraction128 MinValue { get; } = new(int.MinValue, int.MaxValue, 1);

    #endregion

    #region Instance Properties

    public int WholeNumber { get; }

    public int Numerator { get; }

    public int Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction128(int wholeNumber, int numerator, int denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public MixedFraction128(int numerator, int denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction128(int wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction128 Add(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(MixedFraction128 other)
    {
        throw new NotImplementedException();
    }

    public MixedFraction128 Divide(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(MixedFraction128 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction128 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction128 Multiply(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public int Split(out Fraction64 properFraction)
    {
        throw new NotImplementedException();
    }

    public MixedFraction128 Subtract(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() ?? string.Empty;
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Static Methods

    public static MixedFraction128 Abs(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Add(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Divide(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Invert(MixedFraction128 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Invert(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Invert(MixedFraction128 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Log2(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MaxMagnitude(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MaxMagnitudeNumber(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MinMagnitude(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 MinMagnitudeNumber(MixedFraction128 x, MixedFraction128 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Multiply(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 Subtract(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToProperFraction(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToProperSimplestForm(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 ToSimplestForm(MixedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<MixedFraction128>.Radix => 10;

    static MixedFraction128 IAdditiveIdentity<MixedFraction128, MixedFraction128>.AdditiveIdentity => Zero;

    static MixedFraction128 IMultiplicativeIdentity<MixedFraction128, MixedFraction128>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction128 other) ? CompareTo(other) : -1;

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

    #endregion

    #region Static Methods

    static bool INumberBase<MixedFraction128>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction128 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertToChecked<TOther>(MixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertToSaturating<TOther>(MixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction128>.TryConvertToTruncating<TOther>(MixedFraction128 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction128 operator +(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator +(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator -(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator -(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator ~(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator ++(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator --(MixedFraction128 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator *(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator /(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator %(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator &(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator |(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction128 operator ^(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction128 left, MixedFraction128 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}