using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TestDataGeneration.Net;

namespace TestDataGeneration.UnitTests;

public partial class IPAddressComparerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.GetInvertedCompareTestData))]
    public int InvertedCompareTest(IPAddress? x, IPAddress? y) => IPAddressComparer.InvertedCompare(x, y);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetCompareTestData))]
    public int CompareTest(IPAddress? x, IPAddress? y) => IPAddressComparer.Compare(x, y);

    [TestCaseSource(typeof(TestData), nameof(TestData.GetEqualsTestData))]
    public bool EqualsTest(IPAddress? x, IPAddress? y) => IPAddressComparer.Equals(x, y);
}