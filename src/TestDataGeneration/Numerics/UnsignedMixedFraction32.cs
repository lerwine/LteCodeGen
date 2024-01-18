using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedMixedFraction32 : IMixedFraction<UnsignedMixedFraction32, byte, UnsignedFraction16>
{
    #region Static Properties

    public static UnsignedMixedFraction32 One { get; } = new(1);

    static int INumberBase<UnsignedMixedFraction32>.Radix => 10;

    public static UnsignedMixedFraction32 Zero { get; } = new(0);

    static UnsignedMixedFraction32 IAdditiveIdentity<UnsignedMixedFraction32, UnsignedMixedFraction32>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction32 IMultiplicativeIdentity<UnsignedMixedFraction32, UnsignedMixedFraction32>.MultiplicativeIdentity => One;

    public static UnsignedMixedFraction32 MaxValue { get; } = new(byte.MaxValue, byte.MaxValue, 1);

    public static UnsignedMixedFraction32 MinValue { get; } = new(byte.MinValue, byte.MaxValue, 1);

    #endregion
    
    #region Instance Properties

    public byte WholeNumber { get; }

    public byte Numerator { get; }

    public byte Denominator { get; } = (byte)1;

    #endregion
    
    #region Constructors

    public UnsignedMixedFraction32(byte wholeNumber, byte numerator, byte denominator, bool doNotReduce = false, bool doNotMakeProper = false)
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

    public UnsignedMixedFraction32(byte numerator, byte denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0, numerator, denominator, doNotReduce, doNotMakeProper) { }

    public UnsignedMixedFraction32(byte wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion
    
    #region Instance Methods

    public UnsignedMixedFraction32 Add(UnsignedMixedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedMixedFraction32 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction32 other) ? CompareTo(other) : -1;
    
    public UnsignedMixedFraction32 Divide(UnsignedMixedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedMixedFraction32 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction32 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction32 Multiply(UnsignedMixedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public byte Split(out UnsignedFraction16 properFraction)
    {
        throw new NotImplementedException();
    }

    public UnsignedMixedFraction32 Subtract(UnsignedMixedFraction32 fraction)
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
    
    public static UnsignedMixedFraction32 Abs(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Add(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Divide(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Invert(UnsignedMixedFraction32 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Invert(UnsignedMixedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Invert(UnsignedMixedFraction32 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Log2(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MaxMagnitude(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MaxMagnitudeNumber(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MinMagnitude(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 MinMagnitudeNumber(UnsignedMixedFraction32 x, UnsignedMixedFraction32 y)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Multiply(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 Subtract(byte wholeNumber, UnsignedFraction16 fraction)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToProperFraction(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToProperSimplestForm(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 ToSimplestForm(UnsignedMixedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertToChecked<TOther>(UnsignedMixedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertToSaturating<TOther>(UnsignedMixedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction32>.TryConvertToTruncating<TOther>(UnsignedMixedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Operators

    public static UnsignedMixedFraction32 operator +(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator +(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator -(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator -(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator ~(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator ++(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator --(UnsignedMixedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator *(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator /(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator %(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator &(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator |(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction32 operator ^(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction32 left, UnsignedMixedFraction32 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}