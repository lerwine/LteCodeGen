using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

static class NumberStatic
{
    internal static bool TryReadBigEndian<TSelf>(ReadOnlySpan<byte> source, bool isUnsigned, out TSelf value) where TSelf : IBinaryInteger<TSelf> => TSelf.TryReadBigEndian(source, isUnsigned, out value);

    internal static bool TryReadLittleEndian<TSelf>(ReadOnlySpan<byte> source, bool isUnsigned, out TSelf value) where TSelf : IBinaryInteger<TSelf> => TSelf.TryReadLittleEndian(source, isUnsigned, out value);

    internal static bool TryWriteBigEndian<TSelf>(TSelf value, Span<byte> destination, out int bytesWritten) where TSelf : IBinaryInteger<TSelf> => value.TryWriteBigEndian(destination, out bytesWritten);

    internal static bool TryWriteLittleEndian<TSelf>(TSelf value, Span<byte> destination, out int bytesWritten) where TSelf : IBinaryInteger<TSelf> => value.TryWriteLittleEndian(destination, out bytesWritten);

    public static bool TryConvertFromCheckedToUInt32<TOther>(TOther value, out uint result) where TOther : INumberBase<TOther>
    {
        if (value is byte b)
            result = b;
        else if (value is char c)
            result = c;
        else if (value is ushort us)
            result = us;
        else if (value is ulong ul)
            result = checked((uint)ul);
        else if (value is nuint n)
            result = checked((uint)n);
        else if (value is decimal d)
            result = (d >= uint.MaxValue) ? uint.MaxValue : (d <= uint.MinValue) ? uint.MinValue : (uint)d;
        else if (value is UInt128 u)
            result = checked((uint)u);
        else
        {
            result = default;
            return false;
        }
        return true;
    }

    public static bool TryConvertFromSaturatingToUInt32<TOther>(TOther value, out uint result) where TOther : INumberBase<TOther>
    {
        if (value is byte b)
            result = b;
        else if (value is char c)
            result = c;
        else if (value is ushort us)
            result = us;
        else if (value is ulong ul)
            result = (ul >= uint.MaxValue) ? uint.MaxValue : (uint)ul;
        else if (value is nuint n)
            result = (n >= uint.MaxValue) ? uint.MaxValue : (uint)n;
        else if (value is decimal d)
            result = (d >= uint.MaxValue) ? uint.MaxValue : (d <= uint.MinValue) ? uint.MinValue : (uint)d;
        else if (value is UInt128 u)
            result = (u >= uint.MaxValue) ? uint.MaxValue : (uint)u;
        else
        {
            result = default;
            return false;
        }
        return true;
    }

    public static bool TryConvertFromTruncatingToUInt32<TOther>(TOther value, out uint result) where TOther : INumberBase<TOther>
    {
        if (value is byte b)
            result = b;
        else if (value is char c)
            result = c;
        else if (value is ushort us)
            result = us;
        else if (value is ulong ul)
            result = (uint)ul;
        else if (value is nuint n)
            result = (uint)n;
        else if (value is decimal d)
            result = (d >= uint.MaxValue) ? uint.MaxValue : (d <= uint.MinValue) ? uint.MinValue : (uint)d;
        else if (value is UInt128 u)
            result = (uint)u;
        else
        {
            result = default;
            return false;
        }
        return true;
    }

    public static bool TryConvertUInt32ToChecked<TOther>(uint value, [MaybeNullWhen(false)] out TOther result) where TOther : INumberBase<TOther>
    {
        if (typeof(TOther) == typeof(double))
            result = (TOther)(object)(double)value;
        else if (typeof(TOther) == typeof(Half))
            result = (TOther)(object)(Half)value;
        else if (typeof(TOther) == typeof(long))
            result = (TOther)(object)(long)value;
        else if (typeof(TOther) == typeof(Int128))
            result = (TOther)(object)(Int128)value;
        else if (typeof(TOther) == typeof(float))
            result = (TOther)(object)(float)value;
        else if (typeof(TOther) == typeof(short))
            result = (TOther)(object)checked((short)value);
        else if (typeof(TOther) == typeof(int))
            result = (TOther)(object)checked((int)value);
        else if (typeof(TOther) == typeof(nint))
            result = (TOther)(object)checked((nint)value);
        else if (typeof(TOther) == typeof(sbyte))
            result = (TOther)(object)checked((sbyte)value);
        else
        {
            result = default;
            return false;
        }
        return true;
    }

    public static bool TryConvertUInt32ToSaturating<TOther>(uint value, [MaybeNullWhen(false)] out TOther result) where TOther : INumberBase<TOther>
    {
        if (typeof(TOther) == typeof(double))
            result = (TOther)(object)(double)value;
        else if (typeof(TOther) == typeof(Half))
            result = (TOther)(object)(Half)value;
        else if (typeof(TOther) == typeof(long))
            result = (TOther)(object)(long)value;
        else if (typeof(TOther) == typeof(Int128))
            result = (TOther)(object)(Int128)value;
        else if (typeof(TOther) == typeof(nint))
            result = (TOther)(object)(nint)value;
        else if (typeof(TOther) == typeof(float))
            result = (TOther)(object)(float)value;
        else if (typeof(TOther) == typeof(short))
            result = (TOther)(object)((value >= (uint)short.MaxValue) ? short.MaxValue : (short)value);
        else if (typeof(TOther) == typeof(int))
            result = (TOther)(object)((value >= int.MaxValue) ? int.MaxValue : (int)value);
        else if (typeof(TOther) == typeof(sbyte))
            result = (TOther)(object)((value >= (uint)sbyte.MaxValue) ? sbyte.MaxValue : (sbyte)value);
        else
        {
            result = default;
            return false;
        }
        return true;
    }

    public static bool TryConvertUInt32ToTruncating<TOther>(uint value, [MaybeNullWhen(false)] out TOther result) where TOther : INumberBase<TOther>
    {
        if (typeof(TOther) == typeof(double))
            result = (TOther)(object)(double)value;
        else if (typeof(TOther) == typeof(Half))
            result = (TOther)(object)(Half)value;
        else if (typeof(TOther) == typeof(short))
            result = (TOther)(object)(short)value;
        else if (typeof(TOther) == typeof(int))
            result = (TOther)(object)(int)value;
        else if (typeof(TOther) == typeof(long))
            result = (TOther)(object)(long)value;
        else if (typeof(TOther) == typeof(Int128))
            result = (TOther)(object)(Int128)value;
        else if (typeof(TOther) == typeof(nint))
            result = (TOther)(object)(nint)value;
        else if (typeof(TOther) == typeof(sbyte))
            result = (TOther)(object)(sbyte)value;
        else if (typeof(TOther) == typeof(float))
            result = (TOther)(object)(float)value;
        else
        {
            result = default;
            return false;
        }
        return true;
    }

}
