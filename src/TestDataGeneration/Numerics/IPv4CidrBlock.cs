using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Represents an IPv4 CIDR address block.
/// </summary>
public partial class IPv4CidrBlock : IEquatable<IPv4CidrBlock>, IComparable<IPv4CidrBlock>, IComparable, IReadOnlySet<IPv4Address>, IFormattable, IParsable<IPv4CidrBlock>, ISpanFormattable,
    ISpanParsable<IPv4CidrBlock>, IEqualityOperators<IPv4CidrBlock, IPv4CidrBlock, bool>, IComparisonOperators<IPv4CidrBlock, IPv4CidrBlock, bool>, ICloneable
{
    /// <summary>
    /// The block size separator character.
    /// </summary>
    public const char SeparatorChar = '/';

    /// <summary>
    /// The maximum address block bit size.
    /// </summary>
    public const byte MaxBlockBitCount = 32;

    /// <summary>
    /// Gets the original <see cref="IPv4Address"/> that was used to create the current <see cref="IPv4CidrBlock"/>.
    /// </summary>
    /// <returns>The original <see cref="IPv4Address"/> that was used to create the current <see cref="IPv4CidrBlock"/>.</returns>
    public IPv4Address OriginalAddress { get; }

    /// <summary>
    /// Gets the first <see cref="IPv4Address"/> in the current <see cref="IPv4CidrBlock"/>.
    /// </summary>
    /// <returns>The first <see cref="IPv4Address"/> in the current <see cref="IPv4CidrBlock"/>.</returns>
    public IPv4Address First { get; }

    /// <summary>
    /// Gets the last <see cref="IPv4Address"/> in the current <see cref="IPv4CidrBlock"/>.
    /// </summary>
    /// <returns>The last <see cref="IPv4Address"/> in the current <see cref="IPv4CidrBlock"/>.</returns>
    public IPv4Address Last { get; }

    /// <summary>
    /// Gets the number of shared initial bits for addresses in the current <see cref="IPv4CidrBlock"/>.
    /// </summary>
    /// <returns>The number of shared initial bits, counting from the most-significant bit of the address, for the current <see cref="IPv4CidrBlock"/>.</returns>
    public byte PrefixBitLength { get; }

    /// <summary>
    /// Gets the netmask value for the block represented by the current <see cref="IPv4CidrBlock"/>.
    /// </summary>
    /// <returns>The netmask value for the block represented by the current <see cref="IPv4CidrBlock"/>.</returns>
    public IPv4Address Mask { get; }

    /// <summary>
    /// Gets the number of IP addresses in the block represented by the current <see cref="IPv4CidrBlock"/>.
    /// </summary>
    int IReadOnlyCollection<IPv4Address>.Count => (PrefixBitLength < 2) ? int.MaxValue : 1 << (32 - PrefixBitLength);

    /// <summary>
    /// Initializes a new <c>IPV4Range</c> that represents all possible IPv4 address values.
    /// </summary>
    public IPv4CidrBlock()
    {
        Mask = First = OriginalAddress = IPv4Address.MinValue;
        Last = IPv4Address.MaxValue;
        PrefixBitLength = 0;
    }

    private IPv4CidrBlock(IPv4CidrBlock other)
    {
        Mask = other.Mask;
        First = other.First;
        Last = other.Last;
        OriginalAddress = other.OriginalAddress;
        PrefixBitLength = other.PrefixBitLength;
    }

    /// <summary>
    /// Initializes a new <c>IPV4Range</c> that represents a block of IP addresses.
    /// </summary>
    /// <param name="address">An IPv4 address that is contained in the IP address block.</param>
    /// <param name="prefixBitLength">The number of shared initial bits for addresses in the IP address block.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prefixBitLength"/> is greater than 32.</exception>
    public IPv4CidrBlock(IPv4Address address, byte prefixBitLength)
    {
        PrefixBitLength = prefixBitLength;
        OriginalAddress = address;
        switch (prefixBitLength)
        {
            case 0:
                Mask = First = OriginalAddress = IPv4Address.MinValue;
                Last = IPv4Address.MaxValue;
                break;
            case MaxBlockBitCount:
                Mask = IPv4Address.MaxValue;
                First = Last = address;
                break;
            default:
                if (prefixBitLength > MaxBlockBitCount) throw new ArgumentOutOfRangeException(nameof(prefixBitLength));
                Mask = IPv4Address.AsNetMask(prefixBitLength);
                First = address.AsMasked(Mask);
                Last = First.AsEndOfSegment(prefixBitLength);
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
    /// <param name="prefixBitLength">The number of shared initial bits for addresses in the IP address block.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prefixBitLength"/> is greater than 32.</exception>
    public IPv4CidrBlock(byte octet0, byte octet1, byte octet2, byte octet3, byte prefixBitLength)
    {
        PrefixBitLength = prefixBitLength;
        OriginalAddress = new IPv4Address(octet0, octet1, octet2, octet3);
        switch (prefixBitLength)
        {
            case 0:
                Mask = First = OriginalAddress = IPv4Address.MinValue;
                Last = IPv4Address.MaxValue;
                break;
            case MaxBlockBitCount:
                Mask = IPv4Address.MaxValue;
                First = Last = OriginalAddress;
                break;
            default:
                if (prefixBitLength > MaxBlockBitCount) throw new ArgumentOutOfRangeException(nameof(prefixBitLength));
                Mask = IPv4Address.AsNetMask(prefixBitLength);
                First = OriginalAddress.AsMasked(Mask);
                Last = First.AsEndOfSegment(prefixBitLength);
                break;
        }
    }

    /// <summary>
    /// Creates a new <see cref="IPv4CidrBlock"/> from a 32-bit IPv4 address value and block bit count.
    /// </summary>
    /// <param name="address">The 32-bit IPv4 address value.</param>
    /// <param name="prefixBitLength">The number of shared initial bits for addresses in the IP address block.</param>
    /// /// <returns>An <see cref="IPv4CidrBlock"/> that contains the specified IPv4 address.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prefixBitLength"/> is greater than 32.</exception>
    public static IPv4CidrBlock FromAddress(uint address, byte prefixBitLength) => new(IPv4Address.FromAddress(address), prefixBitLength);

    public IPv4CidrBlock Clone() => new(this);

    object ICloneable.Clone() => new IPv4CidrBlock(this);

    public int CompareTo(IPv4CidrBlock? other)
    {
        if (other is null) return 1;
        if (ReferenceEquals(this, other)) return 0;
        int diff = First.CompareTo(other.First);
        return (diff == 0) ? PrefixBitLength.CompareTo(other.PrefixBitLength) : diff;
    }

    int IComparable.CompareTo(object? obj)
    {
        if (obj is null) return 1;
        if (obj is not IPv4CidrBlock other) return -1;
        if (ReferenceEquals(this, other)) return 0;
        int diff = First.CompareTo(other.First);
        return (diff == 0) ? PrefixBitLength.CompareTo(other.PrefixBitLength) : diff;
    }

    public bool Contains(IPv4Address item)
    {
        int diff = item.CompareTo(First);
        return diff == 0 || (diff > 0 && (item <= Last));
    }

    public bool Equals(IPv4CidrBlock? other) => other is not null && (ReferenceEquals(this, other) || (First.Equals(other.First) && PrefixBitLength == other.PrefixBitLength));

    public override bool Equals(object? obj) => obj is IPv4CidrBlock other && (ReferenceEquals(this, other) || (First.Equals(other.First) && PrefixBitLength == other.PrefixBitLength));

    public long GetCount() => 1L << (32 - PrefixBitLength);

    public override int GetHashCode() => HashCode.Combine(First, PrefixBitLength);

    /// <summary>
    /// Gets an <see cref="IEnumerator{T}"/> that iterates through all the IP addresses included in the IP address block.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<IPv4Address> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

    /// <summary>
    /// Parses a span of characters into a <see cref="IPv4CidrBlock"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPv4CidrBlock"/>.</exception>
    public static IPv4CidrBlock Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        int index = s.IndexOf(SeparatorChar);
        if (index < 0) throw new FormatException("Invalid valid CIDR notation string.");
        var address = IPv4Address.Parse(s[..index], provider);
        var size = byte.Parse(s[(index + 1)..], provider);
        try { return new IPv4CidrBlock(IPv4Address.Parse(s[..index], provider), byte.Parse(s[(index + 1)..], provider)); }
        catch (ArgumentOutOfRangeException exception) { throw new FormatException("Invalid valid CIDR notation string.", exception); }
    }

    /// <summary>
    /// Parses a string into a <see cref="IPv4CidrBlock"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="IPv4CidrBlock"/>.</exception>
    public static IPv4CidrBlock Parse(string s, IFormatProvider? provider)
    {
        ArgumentNullException.ThrowIfNull(s);
        return Parse(s.AsSpan(), provider);
    }

    public override string ToString() => $"{First}{SeparatorChar}{PrefixBitLength}";

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => $"{First.ToString(format, formatProvider)}{SeparatorChar}{PrefixBitLength.ToString(format, formatProvider)}";

    /// <summary>
    /// Tries to parse a span of characters into a <see cref="IPv4CidrBlock"/> value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPv4CidrBlock result)
    {
        int index = s.IndexOf(SeparatorChar);
        if (index > 0 && IPv4Address.TryParse(s[0..index], provider, out IPv4Address address) && byte.TryParse(s[(index + 1)..], out byte blockBitCount) && blockBitCount <= MaxBlockBitCount)
        {
            result = new(address, blockBitCount);
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Tries to parse a string into a <see cref="IPv4CidrBlock"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out IPv4CidrBlock result)
    {
        if (s is null)
        {
            result = default;
            return false;
        }
        return TryParse(s.AsSpan(), provider, out result);
    }

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        var end = destination.Length;
        if (First.TryFormat(destination, out charsWritten, format, provider))
        {
            if (charsWritten == end) return false;
            destination[charsWritten++] = SeparatorChar;
            if (charsWritten == end) return false;
            if (PrefixBitLength.TryFormat(destination[charsWritten..], out int cw, format, provider))
            {
                charsWritten = cw;
                return true;
            }
            if (cw > 0)
                charsWritten = (cw > (end - charsWritten)) ? end : charsWritten + cw; 
        }
        return false;
    }

    private int CheckUniqueAndUnfoundElements(IEnumerable<IPv4Address> other, bool returnIfUnfound, out int unfoundCount)
    {
        // BitArray bitHelper = new(_backingList.Count);

        // unfoundCount = 0;
        // int uniqueFoundCount = 0;
        // foreach (NumberExtents<T> item in other)
        // {
        //     int index = InternalIndexOf(item);

        //     if (index >= 0)
        //     {
        //         if (!bitHelper.Get(index))
        //         {
        //             bitHelper.Set(index, true);
        //             uniqueFoundCount++;
        //         }
        //     }
        //     else
        //     {
        //         unfoundCount++;
        //         if (returnIfUnfound) break;
        //     }
        // }

        // return uniqueFoundCount;
        throw new NotImplementedException();
    }

    public bool IsProperSubsetOf(IEnumerable<IPv4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool IsProperSupersetOf(IEnumerable<IPv4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool IsSubsetOf(IEnumerable<IPv4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool IsSupersetOf(IEnumerable<IPv4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool Overlaps(IEnumerable<IPv4Address> other)
    {
        throw new NotImplementedException();
    }

    public bool SetEquals(IEnumerable<IPv4Address> other)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(IPv4CidrBlock left, IPv4CidrBlock right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(IPv4CidrBlock left, IPv4CidrBlock right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(IPv4CidrBlock left, IPv4CidrBlock right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(IPv4CidrBlock left, IPv4CidrBlock right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator ==(IPv4CidrBlock? left, IPv4CidrBlock? right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(IPv4CidrBlock? left, IPv4CidrBlock? right)
    {
        throw new NotImplementedException();
    }
}