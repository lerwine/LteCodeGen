using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TestDataGeneration.Net;

public class IPAddressComparer : IEqualityComparer<IPAddress>, IComparer<IPAddress>
{
    public static readonly IPAddressComparer Instance = new();

    public static IEnumerable<IPAddress> Sort(IEnumerable<IPAddress> source, bool descending = false)
    {
        if (source is null) return Enumerable.Empty<IPAddress>();
        var sorted = source.ToList();
        if (sorted.Count < 2) return source;
        sorted.Sort(descending ? InvertedCompare : Compare);
        return sorted.ToArray();
    }

    public static IEnumerable<IPAddress> Distinct(IEnumerable<IPAddress> source) => source.Distinct(Instance);

    public static int InvertedCompare(IPAddress? x, IPAddress? y)
    {
        if (x is null) return (y is null) ? -1: 0;
        if (y is null) return 1;
        if (ReferenceEquals(x, y)) return 0;
        if (x.AddressFamily != y.AddressFamily)
        {
            if (x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                var a = x.GetAddressBytes();
                if (!x.IsIPv4MappedToIPv6)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        var n = a[i];
                        if (n != 0) return 0 - n;
                    }
                    for (var i = 10; i < 12; i++)
                    {
                        var n = a[i];
                        if (n != 255) return 255 - n;
                    }
                }
                var b = y.GetAddressBytes();
                for (var i = 12; i < 16; i++)
                {
                    var n = b[i].CompareTo(a[i - 12]);
                    if (n != 0) return n;
                }
            }
            else
            {
                var b = y.GetAddressBytes();
                if (!y.IsIPv4MappedToIPv6)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        var n = b[i];
                        if (n != 0) return 0 - n;
                    }
                    for (var i = 10; i < 12; i++)
                    {
                        var n = b[i];
                        if (n != 255) return 255 - n;
                    }
                }
                var a = x.GetAddressBytes();
                for (var i = 12; i < 16; i++)
                {
                    var n = b[i - 12].CompareTo(a[i]);
                    if (n != 0) return n;
                }
            }
        }
        else
        {
            var a = x.GetAddressBytes();
            var b = y.GetAddressBytes();
            var e = a.Length;
            for (var i = 0; i < e; i++)
            {
                var n = b[i].CompareTo(a[i]);
                if (n != 0) return n;
            }
        }
        return 0;
    }

    public static int Compare(IPAddress? x, IPAddress? y)
    {
        if (x is null) return (y is null) ? 0 : -1;
        if (y is null) return 1;
        if (ReferenceEquals(x, y)) return 0;
        if (x.AddressFamily != y.AddressFamily)
        {
            if (x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                var a = x.GetAddressBytes();
                if (!x.IsIPv4MappedToIPv6)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        var n = a[i];
                        if (n != 0) return n;
                    }
                    for (var i = 10; i < 12; i++)
                    {
                        var n = a[i];
                        if (n != 255) return n - 255;
                    }
                }
                var b = y.GetAddressBytes();
                for (var i = 12; i < 16; i++)
                {
                    var n = a[i].CompareTo(b[i - 12]);
                    if (n != 0) return n;
                }
            }
            else
            {
                var b = y.GetAddressBytes();
                if (!y.IsIPv4MappedToIPv6)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        var n = b[i];
                        if (n != 0) return n;
                    }
                    for (var i = 10; i < 12; i++)
                    {
                        var n = b[i];
                        if (n != 255) return n - 255;
                    }
                }
                var a = x.GetAddressBytes();
                for (var i = 12; i < 16; i++)
                {
                    var n = a[i - 12].CompareTo(b[i]);
                    if (n != 0) return n;
                }
            }
        }
        else
        {
            var a = x.GetAddressBytes();
            var b = y.GetAddressBytes();
            var e = a.Length;
            for (var i = 0; i < e; i++)
            {
                var n = a[i].CompareTo(b[i]);
                if (n != 0) return n;
            }
        }
        return 0;
    }

    int IComparer<IPAddress>.Compare(IPAddress? x, IPAddress? y) => Compare(x, y);

    public static bool Equals(IPAddress? x, IPAddress? y)
    {
        if (x is null) return y is null;
        if (y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (x.AddressFamily != y.AddressFamily)
        {
            if (x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                var a = x.GetAddressBytes();
                if (!x.IsIPv4MappedToIPv6)
                {
                    for (var i = 0; i < 10; i++)
                        if (a[i] != 0) return false;
                    for (var i = 10; i < 12; i++)
                        if (a[i] != 255) return false;
                }
                var b = y.GetAddressBytes();
                for (var i = 12; i < 16; i++)
                    if (a[i] != b[i - 12]) return false;
            }
            else
            {
                var b = y.GetAddressBytes();
                if (!y.IsIPv4MappedToIPv6)
                {
                    for (var i = 0; i < 10; i++)
                        if (b[i] != 0) return false;
                    for (var i = 10; i < 12; i++)
                        if (b[i] != 255) return false;
                }
                var a = x.GetAddressBytes();
                for (var i = 12; i < 16; i++)
                    if (a[i - 12] != b[i]) return false;
            }
        }
        else
        {
            var a = x.GetAddressBytes();
            var b = y.GetAddressBytes();
            var e = a.Length;
            for (var i = 0; i < e; i++)
                if (a[i] != b[i]) return false;
        }
        return true;
    }

    bool IEqualityComparer<IPAddress>.Equals(IPAddress? x, IPAddress? y) => Equals(x, y);

    public static int GetHashCode([DisallowNull] IPAddress obj)
    {
        if (obj is null) return 0;
        byte[] bytes = obj.GetAddressBytes();
        int hash = 3;
        for (var i = (obj.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || !obj.IsIPv4MappedToIPv6) ? 0 : 12; i < 16; i++)
            unchecked
            {
                hash = hash * 7 + bytes[i];
            }
        return hash;
    }

    int IEqualityComparer<IPAddress>.GetHashCode([DisallowNull] IPAddress obj) => GetHashCode(obj);
}