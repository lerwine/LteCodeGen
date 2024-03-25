using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;

namespace TestDataGeneration.Net;

public class IPNetwork : IEquatable<IPNetwork>
{
    private readonly byte[] _bytes;

    public IPAddress BaseAddress { get; }

    public byte PrefixLength { get; }

    /// <summary>
    /// Create a new <see cref="IPNetwork"/> with the specified <see cref="IPAddress"/> and prefix length.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/>.</param>
    /// <param name="prefixLength">The prefix length.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="prefixLength"/> is out of range.</exception>
    public IPNetwork(IPAddress address, byte prefixLength)
    {
        _bytes = (BaseAddress = address.GetFirstAddressInBlock(prefixLength)).GetAddressBytes();
        PrefixLength = prefixLength;
    }

    public bool Equals([NotNullWhen(true)] IPNetwork? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.BaseAddress.AddressFamily != BaseAddress.AddressFamily)
        {
            if (BaseAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                return BaseAddress.IsIPv4MappedToIPv6 && PrefixLength - 96 == other.PrefixLength && (other.PrefixLength == 0 || IPAddressComparer.Equals(BaseAddress.MapToIPv4(), other.BaseAddress));
            return other.BaseAddress.IsIPv4MappedToIPv6 && PrefixLength == other.PrefixLength - 96 && (PrefixLength == 0 || IPAddressComparer.Equals(BaseAddress, other.BaseAddress.MapToIPv4()));
        }
        return PrefixLength == other.PrefixLength && (PrefixLength == 0 || IPAddressComparer.Equals(BaseAddress, other.BaseAddress));
    }

    /// <summary>
    /// Determines whether two <see cref="IPNetwork"/> instances are equal.
    /// </summary>
    /// <param name="obj">The <see cref="IPNetwork"/> instance to compare to this instance.</param>
    /// <returns><see langword="true"/> if <paramref name="obj"/> is an <see cref="IPNetwork"/> instance and the networks are equal; otherwise <see langword="false"/>.</returns>
    /// <exception cref="InvalidOperationException">Uninitialized <see cref="IPNetwork"/> instance.</exception>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is IPNetwork other && Equals(other);

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>An integer hash value.</returns>
    public override int GetHashCode() => HashCode.Combine(IPAddressComparer.GetHashCode(BaseAddress), PrefixLength);

    /// <summary>
    /// Determines whether a given <see cref="IPAddress"/> is part of the network.
    /// </summary>
    /// <param name="address">The <see cref="IPAddress"/> to check.</param>
    /// <returns><see langword="true"/> if the <see cref="IPAddress"/> is part of the network; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">The specified <paramref name="address"/> is <see langword="null"/>.</exception>
    public bool Contains(IPAddress address)
    {
        ArgumentNullException.ThrowIfNull(address);
        if (address.AddressFamily != BaseAddress.AddressFamily)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                if (!BaseAddress.IsIPv4MappedToIPv6) return false;
                if (PrefixLength == 0) return true;
                var bits = PrefixLength * 8;
                var bytes = address.GetAddressBytes();
                int e = (PrefixLength - 96 - bits) >> 3;
                if (bits > 0 && _bytes[e + 12] != (byte)(bytes[e] & (byte.MaxValue << (8 - bits)))) return false;
                for (var i = 0; i < e; i++)
                    if (_bytes[i + 12] != bytes[i]) return false;
            }
            else if (address.IsIPv4MappedToIPv6)
            {
                if (PrefixLength == 0) return true;
                var bits = PrefixLength * 8;
                var bytes = address.GetAddressBytes();
                int e = (PrefixLength - bits) >> 3;
                if (bits > 0 && _bytes[e] != (byte)(bytes[e + 12] & (byte.MaxValue << (8 - bits)))) return false;
                for (var i = 0; i < e; i++)
                    if (_bytes[i] != bytes[i + 12]) return false;
            }
            else
                return false;
        }
        else
        {
            if (PrefixLength == 0) return true;
            var bits = PrefixLength * 8;
            var bytes = address.GetAddressBytes();
            int e = (PrefixLength - bits) >> 3;
            if (bits > 0 && _bytes[e] != (byte)(bytes[e] & (byte.MaxValue << (8 - bits)))) return false;
            for (int i = 0; i < e; i++)
                if (_bytes[i] != bytes[i]) return false;
        }
        return true;
    }

    /// <summary>
    /// Converts a CIDR <see cref="string"/> to an <see cref="IPNetwork"/> instance.
    /// </summary>
    /// <param name="s">A <see cref="string"/> that defines an IP network in CIDR notation.</param>
    /// <returns>An <see cref="IPNetwork"/> instance.</returns>
    /// <exception cref="ArgumentNullException">The specified string is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not a valid CIDR network string, or the address contains non-zero bits after the network prefix.</exception>
    public static IPNetwork Parse(string s)
    {
        ArgumentNullException.ThrowIfNull(s);
        return Parse(s.AsSpan());
    }

    /// <summary>
    /// Converts a CIDR character span to an <see cref="IPNetwork"/> instance.
    /// </summary>
    /// <param name="s">A character span that defines an IP network in CIDR notation.</param>
    /// <returns>An <see cref="IPNetwork"/> instance.</returns>
    /// <exception cref="FormatException"><paramref name="s"/> is not a valid CIDR network string, or the address contains non-zero bits after the network prefix.</exception>
    public static IPNetwork Parse(ReadOnlySpan<char> s)
    {
        if (!TryParse(s, out IPNetwork? result))
            throw new FormatException("Invalid CIDR network string");
        return result;
    }

    /// <summary>
    /// Converts the specified CIDR string to an <see cref="IPNetwork"/> instance and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="string"/> that defines an IP network in CIDR notation.</param>
    /// <param name="result">When the method returns, contains an <see cref="IPNetwork"/> instance if the conversion succeeds.</param>
    /// <returns><see langword="true"/> if the conversion was succesful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(string? s, [NotNullWhen(true)] out IPNetwork? result)
    {
        if (s == null)
        {
            result = default;
            return false;
        }

        return TryParse(s.AsSpan(), out result);
    }

    /// <summary>
    /// Converts the specified CIDR character span to an <see cref="IPNetwork"/> instance and returns a value indicating whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="string"/> that defines an IP network in CIDR notation.</param>
    /// <param name="result">When the method returns, contains an <see cref="IPNetwork"/> instance if the conversion succeeds.</param>
    /// <returns><see langword="true"/> if the conversion was succesful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, [NotNullWhen(true)] out IPNetwork? result)
    {
        int separatorIndex = s.LastIndexOf('/');
        if (separatorIndex >= 0)
        {
            ReadOnlySpan<char> ipAddressSpan = s.Slice(0, separatorIndex);
            ReadOnlySpan<char> prefixLengthSpan = s.Slice(separatorIndex + 1);

            if (IPAddress.TryParse(ipAddressSpan, out IPAddress? address) && byte.TryParse(prefixLengthSpan, NumberStyles.None, CultureInfo.InvariantCulture, out byte prefixLength) &&
                prefixLength <= (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? 32 : 128))
            {
                result = new IPNetwork(address, prefixLength);
                return true;
            }
        }

        result = default;
        return false;
    }

    /// <summary>
    /// Converts the instance to a string containing the <see cref="IPNetwork"/>'s CIDR notation.
    /// </summary>
    /// <returns>The <see cref="string"/> containing the <see cref="IPNetwork"/>'s CIDR notation.</returns>
    public override string ToString() => string.Create(CultureInfo.InvariantCulture, stackalloc char[128], $"{BaseAddress}/{(uint)PrefixLength}");
}