using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public readonly struct BinaryDenominatedInt64 : ISignedBinaryDenominatedNumber<BinaryDenominatedInt64, double, long>
{
    #region Static Properties

    public static BinaryDenominatedInt64 One { get; } = new(1L);

    static int INumberBase<BinaryDenominatedInt64>.Radix => 10;

    public static BinaryDenominatedInt64 Zero { get; } = new(0L);

    static BinaryDenominatedInt64 IAdditiveIdentity<BinaryDenominatedInt64, BinaryDenominatedInt64>.AdditiveIdentity => Zero;

    static BinaryDenominatedInt64 IMultiplicativeIdentity<BinaryDenominatedInt64, BinaryDenominatedInt64>.MultiplicativeIdentity => One;

    public static BinaryDenominatedInt64 MaxValue { get; } = new(long.MaxValue);

    public static BinaryDenominatedInt64 MinValue { get; } = new(long.MinValue);

    #endregion
    
    #region Instance Properties

    public long WholeValue { get; }

    double IMixedFraction<BinaryDenominatedInt64, double>.WholeNumber => WholeValue;

    public double Value { get; }

    public BinaryDenomination Denomination { get; }

    double IFraction<BinaryDenominatedInt64, double>.Numerator => Value;

    double IFraction<BinaryDenominatedInt64, double>.Denominator => (ulong)Denomination;

    #endregion
    
    #region Constructors

    public BinaryDenominatedInt64(long wholeValue)
    {
        WholeValue = wholeValue;
        ulong abs = (ulong)Math.Abs(wholeValue);
        if (abs > (ulong)BinaryDenomination.Terabytes + (ulong)BinaryDenomination.Gigabytes)
            Denomination = BinaryDenomination.Petabytes;
        else if (abs > (ulong)BinaryDenomination.Gigabytes + (ulong)BinaryDenomination.Megabytes)
            Denomination = BinaryDenomination.Gigabytes;
        else if (abs > (ulong)BinaryDenomination.Megabytes + (ulong)BinaryDenomination.Kilobytes)
            Denomination = BinaryDenomination.Megabytes;
        else if (abs > (ulong)BinaryDenomination.Kilobytes + (ulong)BinaryDenomination.Bytes)
            Denomination = BinaryDenomination.Kilobytes;
        else
        {
            Denomination = BinaryDenomination.Bytes;
            Value = wholeValue;
            return;
        }
        Value = double.CreateChecked(wholeValue) / double.CreateChecked((ulong)Denomination);
    }

    public BinaryDenominatedInt64(long wholeValue, BinaryDenomination denomination)
    {
        WholeValue = wholeValue;
        Denomination = denomination;
        if (denomination == BinaryDenomination.Bytes)
            Value = wholeValue;
        else
            Value = double.CreateChecked(wholeValue) / double.CreateChecked((ulong)denomination);
    }

    public BinaryDenominatedInt64(BinaryDenominationResult64 denominationResult)
    {
        Denomination = denominationResult.Denomination;
        WholeValue = long.CreateChecked(denominationResult.Value * double.CreateChecked((ulong)Denomination));
        Value = denominationResult.Value;
    }

    #endregion
    
    #region Instance Methods

    public BinaryDenominatedInt64 Add(BinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(BinaryDenominatedInt64 other)
    {
        throw new NotImplementedException();
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is BinaryDenominatedInt64 other) ? CompareTo(other) : -1;

    public BinaryDenominatedInt64 Divide(BinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public bool Equals(BinaryDenominatedInt64 other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is BinaryDenominatedInt64 other && Equals(other);

    public override int GetHashCode() => WholeValue.GetHashCode();

    TypeCode IConvertible.GetTypeCode()
    {
        throw new NotImplementedException();
    }

    public BinaryDenominatedInt64 Multiply(BinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public BinaryDenominatedInt64 Subtract(BinaryDenominatedInt64 fraction)
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
    
    public static BinaryDenominatedInt64 Abs(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Add(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Divide(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominatedInt64 IMixedFraction<BinaryDenominatedInt64, double>.Invert(BinaryDenominatedInt64 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Invert(BinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Invert(BinaryDenominatedInt64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPow2(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperFraction(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperSimplestForm(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSimplestForm(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Log2(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MaxMagnitude(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MaxMagnitudeNumber(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MinMagnitude(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 MinMagnitudeNumber(BinaryDenominatedInt64 x, BinaryDenominatedInt64 y)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Multiply(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 Subtract(double wholeNumber, BinaryDenominationResult64 fraction)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominatedInt64 IMixedFraction<BinaryDenominatedInt64, double>.ToProperFraction(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    static BinaryDenominatedInt64 IMixedFraction<BinaryDenominatedInt64, double>.ToProperSimplestForm(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 ToSimplestForm(BinaryDenominatedInt64 fraction)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertFromChecked<TOther>(TOther value, out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertFromSaturating<TOther>(TOther value, out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertFromTruncating<TOther>(TOther value, out BinaryDenominatedInt64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertToChecked<TOther>(BinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertToSaturating<TOther>(BinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<BinaryDenominatedInt64>.TryConvertToTruncating<TOther>(BinaryDenominatedInt64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    #region Static Operators

    public static BinaryDenominatedInt64 operator +(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator +(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator -(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator -(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator ~(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator ++(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator --(BinaryDenominatedInt64 value)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator *(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator /(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator %(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator &(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator |(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static BinaryDenominatedInt64 operator ^(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(BinaryDenominatedInt64 left, BinaryDenominatedInt64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
