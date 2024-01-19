using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct UnsignedBinaryDenominatedInt64 : IBinaryDenominatedNumber<UnsignedBinaryDenominatedInt64, double, ulong>
{
    #region Static Properties

    public static UnsignedBinaryDenominatedInt64 One { get; } = new(1UL);

    public static UnsignedBinaryDenominatedInt64 Zero { get; } = new(0UL);

    public static UnsignedBinaryDenominatedInt64 MaxValue { get; } = new(ulong.MaxValue);

    public static UnsignedBinaryDenominatedInt64 MinValue { get; } = new(ulong.MinValue);

    #endregion

    #region Instance Properties

    public ulong WholeValue { get; }

    public double Value { get; }

    public BinaryDenomination Denomination { get; }

    #endregion

    #region Constructors

    public UnsignedBinaryDenominatedInt64(ulong wholeValue)
    {
        WholeValue = wholeValue;
        if (wholeValue > (ulong)BinaryDenomination.Terabytes + (ulong)BinaryDenomination.Gigabytes)
            Denomination = BinaryDenomination.Petabytes;
        else if (wholeValue > (ulong)BinaryDenomination.Gigabytes + (ulong)BinaryDenomination.Megabytes)
            Denomination = BinaryDenomination.Gigabytes;
        else if (wholeValue > (ulong)BinaryDenomination.Megabytes + (ulong)BinaryDenomination.Kilobytes)
            Denomination = BinaryDenomination.Megabytes;
        else if (wholeValue > (ulong)BinaryDenomination.Kilobytes + (ulong)BinaryDenomination.Bytes)
            Denomination = BinaryDenomination.Kilobytes;
        else
        {
            Denomination = BinaryDenomination.Bytes;
            Value = wholeValue;
            return;
        }
        Value = double.CreateChecked(wholeValue) / double.CreateChecked((ulong)Denomination);
    }

    public UnsignedBinaryDenominatedInt64(ulong wholeValue, BinaryDenomination denomination)
    {
        WholeValue = wholeValue;
        Denomination = denomination;
        if (denomination == BinaryDenomination.Bytes)
            Value = wholeValue;
        else
            Value = double.CreateChecked(wholeValue) / double.CreateChecked((ulong)denomination);
    }

    public UnsignedBinaryDenominatedInt64(UnsignedBinaryDenominationResult64 denominationResult)
    {
        Denomination = denominationResult.Denomination;
        WholeValue = ulong.CreateChecked(denominationResult.Value * double.CreateChecked((ulong)Denomination));
        Value = denominationResult.Value;
    }

    #endregion

    #region Instance Methods

    public UnsignedBinaryDenominatedInt64 Add(UnsignedBinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UnsignedBinaryDenominatedInt64 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UnsignedBinaryDenominatedInt64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedBinaryDenominatedInt64 other && Equals(other);

    public override int GetHashCode() => WholeValue.GetHashCode();

    public UnsignedBinaryDenominatedInt64 Subtract(UnsignedBinaryDenominatedInt64 fraction)
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

    public static UnsignedBinaryDenominatedInt64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UnsignedBinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedBinaryDenominatedInt64>.Radix => 10;

    static UnsignedBinaryDenominatedInt64 IAdditiveIdentity<UnsignedBinaryDenominatedInt64, UnsignedBinaryDenominatedInt64>.AdditiveIdentity => Zero;

    static UnsignedBinaryDenominatedInt64 IMultiplicativeIdentity<UnsignedBinaryDenominatedInt64, UnsignedBinaryDenominatedInt64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Properties

    double IMixedFraction<UnsignedBinaryDenominatedInt64, double>.WholeNumber => WholeValue;

    double IFraction<UnsignedBinaryDenominatedInt64, double>.Numerator => Value;

    double IFraction<UnsignedBinaryDenominatedInt64, double>.Denominator => (ulong)Denomination;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedBinaryDenominatedInt64 other) ? CompareTo(other) : -1;

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    UnsignedBinaryDenominatedInt64 IFraction<UnsignedBinaryDenominatedInt64, double>.Divide(UnsignedBinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    UnsignedBinaryDenominatedInt64 IFraction<UnsignedBinaryDenominatedInt64, double>.Multiply(UnsignedBinaryDenominatedInt64 fraction)
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

    static UnsignedBinaryDenominatedInt64 IMixedFraction<UnsignedBinaryDenominatedInt64, double>.Invert(UnsignedBinaryDenominatedInt64 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 IMixedFraction<UnsignedBinaryDenominatedInt64, double>.ToProperFraction(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 IMixedFraction<UnsignedBinaryDenominatedInt64, double>.ToProperSimplestForm(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 IFraction<UnsignedBinaryDenominatedInt64, double>.Invert(UnsignedBinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 IFraction<UnsignedBinaryDenominatedInt64, double>.Invert(UnsignedBinaryDenominatedInt64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<UnsignedBinaryDenominatedInt64, double>.IsProperFraction(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<UnsignedBinaryDenominatedInt64, double>.IsProperSimplestForm(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool IFraction<UnsignedBinaryDenominatedInt64, double>.IsSimplestForm(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 IFraction<UnsignedBinaryDenominatedInt64, double>.ToSimplestForm(UnsignedBinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    static bool IBinaryNumber<UnsignedBinaryDenominatedInt64>.IsPow2(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 IBinaryNumber<UnsignedBinaryDenominatedInt64>.Log2(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 INumberBase<UnsignedBinaryDenominatedInt64>.Abs(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsCanonical(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsComplexNumber(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsEvenInteger(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsFinite(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsImaginaryNumber(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsInfinity(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsInteger(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsNaN(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsNegative(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsNegativeInfinity(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsNormal(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsOddInteger(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsPositive(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsPositiveInfinity(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsRealNumber(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsSubnormal(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.IsZero(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 INumberBase<UnsignedBinaryDenominatedInt64>.MaxMagnitude(UnsignedBinaryDenominatedInt64 x, UnsignedBinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 INumberBase<UnsignedBinaryDenominatedInt64>.MaxMagnitudeNumber(UnsignedBinaryDenominatedInt64 x, UnsignedBinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 INumberBase<UnsignedBinaryDenominatedInt64>.MinMagnitude(UnsignedBinaryDenominatedInt64 x, UnsignedBinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    static UnsignedBinaryDenominatedInt64 INumberBase<UnsignedBinaryDenominatedInt64>.MinMagnitudeNumber(UnsignedBinaryDenominatedInt64 x, UnsignedBinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.TryConvertFromChecked<TOther>(TOther value, out UnsignedBinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedBinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedBinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.TryConvertToChecked<TOther>(UnsignedBinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.TryConvertToSaturating<TOther>(UnsignedBinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedBinaryDenominatedInt64>.TryConvertToTruncating<TOther>(UnsignedBinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedBinaryDenominatedInt64 operator +(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator +(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator -(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator -(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator ~(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator ++(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator --(UnsignedBinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator *(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator /(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator %(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator &(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator |(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedBinaryDenominatedInt64 operator ^(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedBinaryDenominatedInt64 left, UnsignedBinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
