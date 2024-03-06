using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Represents an IP address range.
/// </summary>
public class IPV4Range : IEquatable<IPV4Range>, IComparable<IPV4Range>, IReadOnlySet<IPV4Address>, IFormattable, IParsable<IPV4Range>, ISpanFormattable,
    ISpanParsable<IPV4Range>, IEqualityOperators<IPV4Range, IPV4Range, bool>, IComparisonOperators<IPV4Range, IPV4Range, bool>, ICloneable
{
    /// <summary>
    /// The maximum address block bit size.
    /// </summary>
    public const byte MAX_BLOCK_BIT_COUNT = 32;

    /// <summary>
    /// Gets the original <see cref="IPV4Address"/> that was used to create the current <see cref="IPV4Range"/>.
    /// </summary>
    /// <returns>The original <see cref="IPV4Address"/> that was used to create the current <see cref="IPV4Range"/>.</returns>
    public IPV4Address OriginalAddress { get; }

    /// <summary>
    /// Gets the first <see cref="IPV4Address"/> in the current <see cref="IPV4Range"/>.
    /// </summary>
    /// <returns>The first <see cref="IPV4Address"/> in the current <see cref="IPV4Range"/>.</returns>
    public IPV4Address First { get; }

    /// <summary>
    /// Gets the last <see cref="IPV4Address"/> in the current <see cref="IPV4Range"/>.
    /// </summary>
    /// <returns>The last <see cref="IPV4Address"/> in the current <see cref="IPV4Range"/>.</returns>
    public IPV4Address Last { get; }

    /// <summary>
    /// Gets the number of bits for the block represented by the current <see cref="IPV4Range"/>.
    /// </summary>
    /// <returns>The number of bits for the block represented by the current <see cref="IPV4Range"/>.</returns>
    public byte BlockBitCount { get; }

    /// <summary>
    /// Gets the netmask value for the block represented by the current <see cref="IPV4Range"/>.
    /// </summary>
    /// <returns>The netmask value for the block represented by the current <see cref="IPV4Range"/>.</returns>
    public IPV4Address Mask { get; }

    /// <summary>
    /// Gets the number of IP addresses in the block represented by the current <see cref="IPV4Range"/>.
    /// </summary>
    public int Count => throw new NotImplementedException();

    /// <summary>
    /// Initializes a new <c>IPV4Range</c> that represents all possible IPv4 address values.
    /// </summary>
    public IPV4Range()
    {
        Mask = First = OriginalAddress = IPV4Address.MinValue;
        Last = IPV4Address.MaxValue;
        BlockBitCount = 0;
    }

    private IPV4Range(IPV4Range other)
    {
        Mask = other.Mask;
        First = other.First;
        Last = other.Last;
        OriginalAddress = other.OriginalAddress;
        BlockBitCount = other.BlockBitCount;
    }

    /// <summary>
    /// Initializes a new <c>IPV4Range</c> that represents a block of IP addresses.
    /// </summary>
    /// <param name="address">An IPv4 address that is contained in the IP address block.</param>
    /// <param name="blockBitCount">The number of bits in the IP address block.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="blockBitCount"/> is greater than 32.</exception>
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

    /// <summary>
    /// Initializes a new <c>IPV4Range</c> that represents a block of IP addresses.
    /// </summary>
    /// <param name="octet0">The first octet of anIPv4  address that is contained in the IP address block.</param>
    /// <param name="octet1">The second octet of anIPv4  address that is contained in the IP address block.</param>
    /// <param name="octet2">The third octet of anIPv4  address that is contained in the IP address block.</param>
    /// <param name="octet3">The fourth octet of anIPv4  address that is contained in the IP address block.</param>
    /// <param name="blockBitCount">The number of bits in the IP address block.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="blockBitCount"/> is greater than 32.</exception>
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

    /// <summary>
    /// Creates a new IPv4 addresss from a 32-bit IPv4 address value.
    /// </summary>
    /// <param name="address">The 32-bit IPv4 address value.</param>
    /// <param name="blockBitCount">The number of bits in the IP address block.</param>
    /// <returns>An <see cref="IPV4Range"/> that contains the specified IPv4 address.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="blockBitCount"/> is greater than 32.</exception>
    public static IPV4Range FromAddress(uint address, byte blockBitCount) => new(IPV4Address.FromAddress(address), blockBitCount);

    public IPV4Range Clone() => new(this);

    object ICloneable.Clone() => new IPV4Range(this);

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

    /// <summary>
    /// Gets an <see cref="IEnumerator{T}"/> that iterates through all the IP addresses included in the IP address range.
    /// </summary>
    /// <returns></returns>
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

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a span of characters into a <see cref="IPV4Range"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPV4Range"/>.</exception>
    public static IPV4Range Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a string into a <see cref="IPV4Range"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPV4Range"/>.</exception>
    public static IPV4Range Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries to parse a span of characters into a <see cref="IPV4Range"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Range result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries to parse a string into a <see cref="IPV4Range"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPV4Range result)
    {
        throw new NotImplementedException();
    }

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
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