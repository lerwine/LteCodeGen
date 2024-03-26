using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestDataGeneration.Net;

public static class IPAddressExtensions
{
    public static IPAddress GetFirstAddressInBlock(this IPAddress address, byte prefixLength)
    {
        ArgumentNullException.ThrowIfNull(address);
        if (prefixLength == 0)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                return address.Equals(IPAddress.IPv6Any) ? address : IPAddress.IPv6Any;
            return address.Equals(IPAddress.Any) ? address : IPAddress.Any;
        }
        int max = (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) ? 128 : 32;
        if (prefixLength == max) return address;
        if (prefixLength < max)
        {
            byte[] bytes = address.GetAddressBytes();
            var bits = prefixLength % 8;
            if (bits == 0)
            {
                int index = prefixLength >> 3;
                var e = max >> 3;
                do
                {
                    if (bytes[index] != 0)
                    {
                        bytes[index] = 0;
                        while (++index < e) bytes[index] = 0;
                        return new(bytes);
                    }
                }
                while (++index < e);
            }
            else
            {
                int index = (prefixLength - bits) >> 3;
                var b = bytes[index];
                var m = (byte)(bytes[index] & (byte.MaxValue << (8 - bits)));
                var e = max >> 3;
                if (m != b)
                {
                    bytes[index] = m;
                    while (++index < e) bytes[index] = 0;
                    return new(bytes);
                }
                else
                    while (++index < e)
                    {
                        if (bytes[index] != 0)
                        {
                            bytes[index] = 0;
                            while (++index < e) bytes[index] = 0;
                            return new(bytes);
                        }
                    }
            }
            return address;
        }
        throw new ArgumentOutOfRangeException(nameof(prefixLength));
    }

    public static IPAddress GetLastAddressInBlock(this IPAddress address, byte prefixLength)
    {
        ArgumentNullException.ThrowIfNull(address);
        if (prefixLength == 0)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                return address.Equals(IPAddress.IPv6None) ? address : IPAddress.IPv6None;
            return address.Equals(IPAddress.None) ? address : IPAddress.None;
        }
        int max = (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) ? 128 : 32;
        if (prefixLength == max) return address;
        if (prefixLength < max)
        {
            byte[] bytes = address.GetAddressBytes();
            var bits = prefixLength % 8;
            if (bits == 0)
            {
                int index = prefixLength >> 3;
                var e = max >> 3;
                do
                {
                    if (bytes[index] != 255)
                    {
                        bytes[index] = 255;
                        while (++index < e) bytes[index] = 255;
                        return new(bytes);
                    }
                }
                while (++index < e);
            }
            else
            {
                int index = (prefixLength - bits) >> 3;
                var b = bytes[index];
                var m = (byte)(bytes[index] | (byte.MaxValue >> bits));
                var e = max >> 3;
                if (m != b)
                {
                    bytes[index] = m;
                    while (++index < e) bytes[index] = 255;
                    return new(bytes);
                }
                else
                    while (++index < e)
                    {
                        if (bytes[index] != 255)
                        {
                            bytes[index] = 255;
                            while (++index < e) bytes[index] = 255;
                            return new(bytes);
                        }
                    }
            }
            return address;
        }
        throw new ArgumentOutOfRangeException(nameof(prefixLength));
    }

    public static IPAddress GetIPAddressBlockExtents(this IPAddress address, byte prefixLength, out IPAddress lastAddress)
    {
        ArgumentNullException.ThrowIfNull(address);
        if (prefixLength == 0)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                lastAddress = address.Equals(IPAddress.IPv6None) ? address : IPAddress.IPv6None;
                return address.Equals(IPAddress.IPv6Any) ? address : IPAddress.IPv6Any;
            }
            lastAddress = address.Equals(IPAddress.None) ? address : IPAddress.None;
            return address.Equals(IPAddress.Any) ? address : IPAddress.Any;
        }
        int max = (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) ? 128 : 32;
        if (prefixLength == max)
        {
            lastAddress = address;
            return address;
        }
        if (prefixLength > max)
            throw new ArgumentOutOfRangeException(nameof(prefixLength));
        byte[] firstBytes = address.GetAddressBytes();
        byte[] lastBytes = address.GetAddressBytes();
        var bits = prefixLength % 8;
        if (bits == 0)
        {
            int firstIndex = prefixLength >> 3;
            var e = max >> 3;
            int lastIndex = firstIndex;
            do
            {
                if (lastBytes[lastIndex] != 255)
                {
                    lastBytes[lastIndex] = 255;
                    while (++lastIndex < e) lastBytes[lastIndex] = 255;
                    lastAddress = new(lastBytes);
                    do
                    {
                        if (firstBytes[firstIndex] != 0)
                        {
                            firstBytes[firstIndex] = 0;
                            while (++firstIndex < e) firstBytes[firstIndex] = 0;
                            return new(firstBytes);
                        }
                    }
                    while (++firstIndex < e);
                    return address;
                }
            }
            while (++lastIndex < e);
            lastAddress = address;
            do
            {
                if (firstBytes[firstIndex] != 0)
                {
                    firstBytes[firstIndex] = 0;
                    while (++firstIndex < e) firstBytes[firstIndex] = 0;
                    return new(firstBytes);
                }
            }
            while (++firstIndex < e);
        }
        else
        {
            int firstIndex = (prefixLength - bits) >> 3;
            var b = firstBytes[firstIndex];
            var fm = (byte)(firstBytes[firstIndex] & (byte.MaxValue << (8 - bits)));
            var lm = (byte)(lastBytes[firstIndex] | (byte.MaxValue >> bits));
            var e = max >> 3;
            int lastIndex = firstIndex;
            lastAddress = address;
            if (lm != b)
            {
                lastBytes[lastIndex] = lm;
                while (++lastIndex < e) lastBytes[lastIndex] = 255;
                lastAddress = new(lastBytes);
            }
            else
                while (++lastIndex < e)
                {
                    if (lastBytes[lastIndex] != 255)
                    {
                        lastBytes[lastIndex] = 255;
                        while (++lastIndex < e) lastBytes[lastIndex] = 255;
                        lastAddress = new(lastBytes);
                        break;
                    }
                }
            if (fm != b)
            {
                firstBytes[firstIndex] = fm;
                while (++firstIndex < e) firstBytes[firstIndex] = 0;
                return new(firstBytes);
            }
            else
                while (++firstIndex < e)
                {
                    if (firstBytes[firstIndex] != 0)
                    {
                        firstBytes[firstIndex] = 0;
                        while (++firstIndex < e) firstBytes[firstIndex] = 0;
                        return new(firstBytes);
                    }
                }
        }
        return address;
    }

    public static IEnumerable<IPAddress> Sort(this IEnumerable<IPAddress> source, bool descending = false)
    {
        if (source is null) return Enumerable.Empty<IPAddress>();
        var sorted = source.ToList();
        if (sorted.Count < 2) return source;
        sorted.Sort(descending ? IPAddressComparer.InvertedCompare : IPAddressComparer.Compare);
        return sorted.ToArray();
    }

    public static IEnumerable<IPAddress> Unique(this IEnumerable<IPAddress> source) => source.Distinct(IPAddressComparer.Instance);

    public static IPAddress IncrementBlockIP(this IPAddress address, byte prefixLength, bool asUnchecked = false)
    {
        ArgumentNullException.ThrowIfNull(address);
        if (prefixLength == 0)
            return Increment(address, asUnchecked);
        int max = (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) ? 128 : 32;
        if (prefixLength == max)
        {
            if (asUnchecked) return address;
            throw new OverflowException();
        }
        if (prefixLength > max)
            throw new ArgumentOutOfRangeException(nameof(prefixLength));
        var isIPv4MappedToIPv6 = address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 && address.IsIPv4MappedToIPv6;
        if (isIPv4MappedToIPv6)
        {
            if (prefixLength == 96) return Increment(address, asUnchecked);
            if (prefixLength < 96) prefixLength = 96;
        }
        byte[] bytes = address.GetAddressBytes();
        int bits = prefixLength % 8;
        int start;
        int index = bytes.Length;
        if (bits == 0)
        {
            start = prefixLength >> 3;
            while (--index > start)
            {
                if (bytes[index] < 255)
                {
                    bytes[index]++;
                    return new IPAddress(bytes);
                }
                bytes[index] = 0;
            }
            if (bytes[start] < 255)
                bytes[start]++;
            else
            {
                if (asUnchecked) return address;
                throw new OverflowException();
            }
            return new IPAddress(bytes);
        }
        start = (prefixLength - bits) >> 3;
        while (--index > start)
        {
            if (bytes[index] < 255)
            {
                bytes[index]++;
                return new IPAddress(bytes);
            }
            bytes[index] = 0;
        }
        if (bytes[start] < ((bytes[start] & byte.MaxValue << (8 - bits)) | byte.MaxValue >> bits))
            bytes[start]++;
        else
        {
            if (asUnchecked) return address;
            throw new OverflowException();
        }
        return new IPAddress(bytes);
    }

    public static IPAddress DecrementBlockIP(this IPAddress address, byte prefixLength, bool asUnchecked = false)
    {
        ArgumentNullException.ThrowIfNull(address);
        if (prefixLength == 0)
            return Increment(address, asUnchecked);
        int max = (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) ? 128 : 32;
        if (prefixLength == max)
        {
            if (asUnchecked) return address;
            throw new OverflowException();
        }
        if (prefixLength > max)
            throw new ArgumentOutOfRangeException(nameof(prefixLength));
        var isIPv4MappedToIPv6 = address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 && address.IsIPv4MappedToIPv6;
        if (isIPv4MappedToIPv6)
        {
            if (prefixLength == 96) return Increment(address, asUnchecked);
            if (prefixLength < 96) prefixLength = 96;
        }
        byte[] bytes = address.GetAddressBytes();
        int bits = prefixLength % 8;
        int start;
        int index = bytes.Length;
        if (bits == 0)
        {
            start = prefixLength >> 3;
            while (--index > start)
            {
                if (bytes[index] > 0)
                {
                    bytes[index]--;
                    return new IPAddress(bytes);
                }
                bytes[index] = 255;
            }
            if (bytes[start] > 0)
                bytes[start]--;
            else
            {
                if (asUnchecked) return address;
                throw new OverflowException();
            }
            return new IPAddress(bytes);
        }
        start = (prefixLength - bits) >> 3;
        while (--index > start)
        {
            if (bytes[index] > 0)
            {
                bytes[index]--;
                return new IPAddress(bytes);
            }
            bytes[index] = 255;
        }
        if (bytes[start] > (bytes[start] & byte.MaxValue << (8 - bits)))
            bytes[start]--;
        else
        {
            if (asUnchecked) return address;
            throw new OverflowException();
        }
        return new IPAddress(bytes);
    }

    public static IPAddress Increment(this IPAddress address, bool asUnchecked = false)
    {
        ArgumentNullException.ThrowIfNull(address);
        byte[] bytes = address.GetAddressBytes();
        int index = bytes.Length - 1;
        do
        {
            if (bytes[index] < 255)
            {
                bytes[index]++;
                return new IPAddress(bytes);
            }
            bytes[index] = 0;
        }
        while (--index > 0);
        if (bytes[0] < 255)
            bytes[0]++;
        else
        {
            if (asUnchecked) return address;
            throw new OverflowException();
        }
        return new IPAddress(bytes);
    }

    public static IPAddress Decrement(this IPAddress address, bool asUnchecked = false)
    {
        ArgumentNullException.ThrowIfNull(address);
        byte[] bytes = address.GetAddressBytes();
        int index = bytes.Length - 1;
        do
        {
            if (bytes[index] > 0)
            {
                bytes[index]--;
                return new IPAddress(bytes);
            }
            bytes[index] = 255;
        }
        while (--index > 0);
        if (bytes[0] > 0)
            bytes[0]--;
        else
        {
            if (asUnchecked) return address;
            throw new OverflowException();
        }
        return new IPAddress(bytes);
    }

    public static IEnumerable<IPAddress> GetIPAddresses(this IPNetwork network, bool reverse = false)
    {
        IPAddress address = network.BaseAddress;
        byte pl = network.PrefixLength;
        IPAddress last = address.GetLastAddressInBlock(pl);
        if (reverse)
        {
            yield return last;
            while (!last.Equals(address))
            {
                address = address.DecrementBlockIP(pl);
                yield return address;
            }
        }
        else
        {
            yield return address;
            while (!address.Equals(last))
            {
                address = address.IncrementBlockIP(pl);
                yield return address;
            }
        }
    }

    public static IEnumerable<IPNetwork> GetNetworks(this IPAddress address)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets networks that includes the start and end address.
    /// </summary>
    /// <param name="startAddress"></param>
    /// <param name="endAddress"></param>
    /// <returns></returns>
    public static IEnumerable<IPNetwork> GetNetworksIn(this IPAddress startAddress, IPAddress endAddress)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the smallest network setgment that contains the specified IP addresses.
    /// </summary>
    /// <param name="startAddress"></param>
    /// <param name="endAddress"></param>
    /// <returns></returns>
    public static IPNetwork GetNetworkTo(this IPAddress startAddress, IPAddress endAddress)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the smallest network segment that contains the specified address, with the specified prefix length.
    /// </summary>
    /// <param name="startAddress"></param>
    /// <param name="prefixLength"></param>
    /// <returns></returns>
    public static IPNetwork GetNetworkTo(this IPAddress startAddress, byte prefixLength)
    {
        throw new NotImplementedException();
    }
}