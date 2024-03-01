using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace TestDataGeneration.Numerics;

public class IPV4Range : IEquatable<IPV4Range>, IComparable<IPV4Range>, IReadOnlySet<IPV4Address>, IFormattable, IParsable<IPV4Range>, ISpanFormattable,
    ISpanParsable<IPV4Range>, IEqualityOperators<IPV4Range, IPV4Range, bool>, IComparisonOperators<IPV4Range, IPV4Range, bool>
{
    public const byte MAX_BLOCK_BIT_COUNT = 32;

    public IPV4Address OriginalAddress { get; }

    public IPV4Address First { get; }

    public IPV4Address Last { get; }

    public byte BlockBitCount { get; }

    public IPV4Address Mask { get; }

    public int Count => throw new NotImplementedException();

    public IPV4Range()
    {
        Mask = First = OriginalAddress = IPV4Address.MinValue;
        Last = IPV4Address.MaxValue;
        BlockBitCount = 0;
    }

    public IPV4Range(IPV4Range other)
    {
        Mask = other.Mask;
        First = other.First;
        Last = other.Last;
        OriginalAddress = other.OriginalAddress;
        BlockBitCount = other.BlockBitCount;
    }

    public IPV4Range(IPV4Address address, byte blockBitCount)
    {
        BlockBitCount = blockBitCount;
        OriginalAddress = address;
        switch (blockBitCount)
        {
            case 0:
                Mask = First = OriginalAddress = IPV4Address.MinValue;
                Last = IPV4Address.MaxValue;
                break;
            case MAX_BLOCK_BIT_COUNT:
                Mask = IPV4Address.MaxValue;
                First = Last = address;
                break;
            default:
                if (blockBitCount > MAX_BLOCK_BIT_COUNT) throw new ArgumentOutOfRangeException(nameof(blockBitCount));
                Mask = IPV4Address.AsNetMask(blockBitCount);
                First = address.AsMasked(Mask);
                Last = First.AsEndOfSegment(blockBitCount);
                break;
        }
    }

    public IPV4Range(byte octet0, byte octet1, byte octet2, byte octet3, byte blockBitCount)
    {
        BlockBitCount = blockBitCount;
        OriginalAddress = new IPV4Address(octet0, octet1, octet2, octet3);
        switch (blockBitCount)
        {
            case 0:
                Mask = First = OriginalAddress = IPV4Address.MinValue;
                Last = IPV4Address.MaxValue;
                break;
            case MAX_BLOCK_BIT_COUNT:
                Mask = IPV4Address.MaxValue;
                First = Last = OriginalAddress;
                break;
            default:
                if (blockBitCount > MAX_BLOCK_BIT_COUNT) throw new ArgumentOutOfRangeException(nameof(blockBitCount));
                Mask = IPV4Address.AsNetMask(blockBitCount);
                First = OriginalAddress.AsMasked(Mask);
                Last = First.AsEndOfSegment(blockBitCount);
                break;
        }
    }

    public static IPV4Range FromAddress(uint address, byte blockBitCount) => new(IPV4Address.FromAddress(address), blockBitCount);

    public int CompareTo(IPV4Range? other)
    {
        throw new NotImplementedException();
    }

    public bool Contains(IPV4Address item)
    {
        throw new NotImplementedException();
    }

    public bool Equals(IPV4Range? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public IEnumerator<IPV4Address> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString()!;
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }

    public static IPV4Range Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Range result)
    {
        throw new NotImplementedException();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static IPV4Range Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Range result)
    {
        throw new NotImplementedException();
    }

    public bool IsProperSubsetOf(IEnumerable<IPV4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool IsProperSupersetOf(IEnumerable<IPV4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool IsSubsetOf(IEnumerable<IPV4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool IsSupersetOf(IEnumerable<IPV4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool Overlaps(IEnumerable<IPV4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool SetEquals(IEnumerable<IPV4Address> other)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(IPV4Range left, IPV4Range right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(IPV4Range left, IPV4Range right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(IPV4Range left, IPV4Range right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(IPV4Range left, IPV4Range right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator ==(IPV4Range? left, IPV4Range? right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(IPV4Range? left, IPV4Range? right)
    {
        throw new NotImplementedException();
    }
}