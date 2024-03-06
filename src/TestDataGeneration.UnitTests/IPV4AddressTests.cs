using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using NUnit.Framework;
using TestDataGeneration.Numerics;
using static TestDataGeneration.UnitTests.StaticExplicitInvocation;

namespace TestDataGeneration.UnitTests;

public partial class IPV4AddressTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetConstructorTestData))]
    public uint ConstructorTest(byte octet0, byte octet1, byte octet2, byte octet3)
    {
        var target = new IPV4Address(octet0, octet1, octet2, octet3);
        return ((IConvertible)target).ToUInt32(null);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAsMaskedTestData))]
    public IPV4Address AsMaskedTest(IPV4Address target, IPV4Address netMask) => target.AsMasked(netMask);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetAsEndOfSegmentTestData))]
    public IPV4Address AsEndOfSegmentTest(IPV4Address target, byte bitBlockCount) => target.AsEndOfSegment(bitBlockCount);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetCompareToTestData))]
    public int CompareToTest(IPV4Address target, IPV4Address other)
    {
        var result = target.CompareTo(other);
        return (result < 0) ? -1 : (result > 0) ? 1 : 0;
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetEqualsTestData))]
    public bool EqualsTest(IPV4Address target, IPV4Address other) => target.Equals(other);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetFromAddressTestData))]
    public IPV4Address FromAddressTest(uint address) => IPV4Address.FromAddress(address);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetGetAddressTestData))]
    public uint GetAddressTest(IPV4Address target) => target.GetAddress();

    [TestCaseSource(typeof(TestData), nameof(TestData.GetParse1TestData))]
    public IPV4Address Parse1Test(string s, IFormatProvider? provider) => IPV4Address.Parse(s.AsSpan(), provider);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetParse2TestData))]
    public IPV4Address Parse2Test(string s, NumberStyles style, IFormatProvider? provider) => IPV4Address.Parse(s, style, provider);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetToStringTestData))]
    public string ToStringTest(IPV4Address value) => value.ToString();

    [TestCaseSource(typeof(TestData), nameof(TestData.GetTryParse1TestData))]
    public IPV4Address? TryParse1Test(string? s) => IPV4Address.TryParse(s.AsSpan(), out IPV4Address result) ? result : null;

    [TestCaseSource(typeof(TestData), nameof(TestData.GetTryParse2TestData))]
    public IPV4Address? TryParse2Test(string? s, NumberStyles style) => IPV4Address.TryParse(s.AsSpan(), style, out IPV4Address result) ? result : null;

    [TestCaseSource(typeof(TestData), nameof(TestData.GetTryParse3TestData))]
    public IPV4Address? TryParse3Test(string? s, IFormatProvider? provider) => IPV4Address.TryParse(s.AsSpan(), provider, out IPV4Address result) ? result : null;

    [TestCaseSource(typeof(TestData), nameof(TestData.GetTryParse4TestData))]
    public IPV4Address? TryParse4Test(string? s, NumberStyles style, IFormatProvider? provider) => IPV4Address.TryParse(s.AsSpan(), style, provider, out IPV4Address result) ? result : null;
}