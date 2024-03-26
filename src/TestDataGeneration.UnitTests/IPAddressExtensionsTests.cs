using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TestDataGeneration.Net;

namespace TestDataGeneration.UnitTests;

public partial class IPAddressExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetFirstAddressInBlockTest1Data))]
    [Description("Gets first IP address in block where the return value is not equal to the input value.")]
    public object GetFirstAddressInBlockTest1(IPAddress address, byte prefixLength)
    {
        try { return address.GetFirstAddressInBlock(prefixLength); }
        catch (ArgumentOutOfRangeException exception) { return (exception.Message, exception.ParamName, exception.ActualValue); }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetFirstAddressInBlockTest2Data))]
    [Description("Gets first IP address in block where the return value is equal to the input value.")]
    public void GetFirstAddressInBlockTest2(IPAddress address, byte prefixLength)
    {
        var result = address.GetFirstAddressInBlock(prefixLength);
        Assert.That(result, Is.SameAs(address));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetLastAddressInBlockTest1Data))]
    [Description("Gets last IP address in block where the return value is not equal to the input value.")]
    public IPAddress? GetLastAddressInBlockTest1(IPAddress address, byte prefixLength)
    {
        try { return address.GetLastAddressInBlock(prefixLength); }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetLastAddressInBlockTest2Data))]
    [Description("Gets last IP address in block where the return value is equal to the input value.")]
    public void GetLastAddressInBlockTest2(IPAddress address, byte prefixLength)
    {
        var result = address.GetLastAddressInBlock(prefixLength);
        Assert.That(result, Is.SameAs(address));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetIPAddressBlockExtentsTestData))]
    public (IPAddress First, IPAddress Last)? GetIPAddressBlockExtentsTest(IPAddress address, byte prefixLength)
    {
        try
        {
            IPAddress first = address.GetIPAddressBlockExtents(prefixLength, out IPAddress last);
            return (first, last);
        }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetSortTestData))]
    public IPAddress[] SortTest(IEnumerable<IPAddress> source, bool? descending)
    {
        if (descending.HasValue) return source.Sort(descending.Value).ToArray();
        return source.Sort().ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetUniqueTestData))]
    public IPAddress[] UniqueTest(IEnumerable<IPAddress> source) => source.Unique().ToArray();

    [TestCaseSource(typeof(TestData), nameof(TestData.GetIncrementBlockIPTestData))]
    public IPAddress? IncrementBlockIPTest(IPAddress address, byte prefixLength, bool? asUnchecked)
    {
        try
        {
             if (asUnchecked.HasValue)
                return address.IncrementBlockIP(prefixLength, asUnchecked.Value);
            return address.IncrementBlockIP(prefixLength);
        }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetDecrementBlockIPTestData))]
    public IPAddress? DecrementBlockIPTest(IPAddress address, byte prefixLength, bool? asUnchecked)
    {
        try
        {
            if (asUnchecked.HasValue)
                return address.DecrementBlockIP(prefixLength, asUnchecked.Value);
            return address.DecrementBlockIP(prefixLength);
        }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetIncrementTestData))]
    public IPAddress? IncrementTest(IPAddress address, bool? asUnchecked)
    {
        try
        {
            if (asUnchecked.HasValue)
                return address.Increment(asUnchecked.Value);
            return address.Increment();
        }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetDecrementTestData))]
    public IPAddress? DecrementTest(IPAddress address, bool? asUnchecked)
    {
        try
        {
            if (asUnchecked.HasValue)
                return address.Decrement(asUnchecked.Value);
            return address.Decrement();
        }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetIPAddressesTestData))]
    public IPAddress[] GetIPAddressesTest(IPNetwork network, bool? reverse)
    {
        if (reverse.HasValue)
            return network.GetIPAddresses(reverse.Value).ToArray();
        return network.GetIPAddresses().ToArray();
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetNetworksTestData))]
    public IPNetwork[] GetNetworksTest(IPAddress address) => address.GetNetworks().ToArray();

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetNetworksInTestData))]
    public IPNetwork[] GetNetworksInTest(IPAddress startAddress, IPAddress endAddress) => startAddress.GetNetworksIn(endAddress).ToArray();

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetNetworkToIPAddressTestData))]
    public IPNetwork? GetNetworkToIPAddressTest(IPAddress startAddress, IPAddress endAddress)
    {
        try { return startAddress.GetNetworkTo(endAddress); }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetNetworkToInt32TestData))]
    public IPNetwork? GetNetworkToInt32Test(IPAddress startAddress, byte prefixLength)
    {
        try { return startAddress.GetNetworkTo(prefixLength); }
        catch { return null; }
    }
}