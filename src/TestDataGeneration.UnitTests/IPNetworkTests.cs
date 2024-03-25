using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TestDataGeneration.Net;

namespace TestDataGeneration.UnitTests;

public partial class IPNetworkTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorTestData))]
    public (IPAddress BaseAddress, byte PrefixLength)? ConstructorTest(IPAddress address, byte prefixLength)
    {
        try
        {
            IPNetwork result = new(address, prefixLength);
            return (result.BaseAddress, result.PrefixLength);
        }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetEqualsTestData))]
    public bool EqualsTest(IPNetwork current, IPNetwork? other) => current.Equals(other);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetContainsTestData))]
    public bool ContainsTest(IPNetwork network, IPAddress address) => network.Contains(address);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetParseTestData))]
    public IPNetwork? ParseTest(string s)
    {
        try { return IPNetwork.Parse(s); }
        catch { return null; }
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetTryParseTestData))]
    public (bool ReturnValue, IPNetwork? Result) TryParseTest(string? s)
    {
        var returnValue = IPNetwork.TryParse(s, out IPNetwork? result);
        return (returnValue, result);
    }
}