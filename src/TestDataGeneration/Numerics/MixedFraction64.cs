using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct MixedFraction64 : IMixedSignedFraction<MixedFraction64, short, Fraction32>
{
    #region Static Properties

    public static MixedFraction64 NegativeOne { get; } = new(-1);

    public static MixedFraction64 One { get; } = new(1);

    public static MixedFraction64 Zero { get; } = new(0);

    public static MixedFraction64 MaxValue { get; } = new(short.MaxValue, short.MaxValue, 1);

    public static MixedFraction64 MinValue { get; } = new(short.MinValue, short.MaxValue, 1);

    #endregion

    #region Instance Properties

    public short WholeNumber { get; }

    public short Numerator { get; }

    public short Denominator { get; }

    #endregion

    #region Constructors

    public MixedFraction64(short wholeNumber, short numerator, short denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public MixedFraction64(short numerator, short denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    public MixedFraction64(short wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    public MixedFraction64 Add(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(MixedFraction64 other)
    {
        throw new NotImplementedException();
    }

    public MixedFraction64 Divide(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(MixedFraction64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is MixedFraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    public MixedFraction64 Multiply(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public short Split(out Fraction32 properFraction)
    {
        throw new NotImplementedException();
    }

    public MixedFraction64 Subtract(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() ?? string.Empty;
    }

    #endregion

    #region Static Methods

    public static MixedFraction64 Abs(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Add(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Divide(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Invert(MixedFraction64 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Invert(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Invert(MixedFraction64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Log2(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MaxMagnitude(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MaxMagnitudeNumber(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MinMagnitude(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 MinMagnitudeNumber(MixedFraction64 x, MixedFraction64 y)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Multiply(int wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Subtract(int wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToProperFraction(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToProperSimplestForm(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 ToSimplestForm(MixedFraction64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertFromChecked<TOther>(TOther value, out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertFromSaturating<TOther>(TOther value, out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertFromTruncating<TOther>(TOther value, out MixedFraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertToChecked<TOther>(MixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertToSaturating<TOther>(MixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<MixedFraction64>.TryConvertToTruncating<TOther>(MixedFraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Subtract(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 Multiply(short wholeNumber, Fraction32 fraction)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<MixedFraction64>.Radix => 10;

    static MixedFraction64 IAdditiveIdentity<MixedFraction64, MixedFraction64>.AdditiveIdentity => Zero;

    static MixedFraction64 IMultiplicativeIdentity<MixedFraction64, MixedFraction64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is MixedFraction64 other) ? CompareTo(other) : -1;

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

    #endregion

    #endregion

    #region Static Operators

    public static MixedFraction64 operator +(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator +(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator -(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator -(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator ~(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator ++(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator --(MixedFraction64 value)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator *(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator /(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator %(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator &(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator |(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static MixedFraction64 operator ^(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MixedFraction64 left, MixedFraction64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
