namespace TestDataGeneration.UnitTests;

using System.Net;
using TestDataGeneration.Net;

public partial class IPNetworkTests
{
    static class TestData
    {
        public static System.Collections.IEnumerable GetConstructorTestData()
        {
            yield return new TestCaseData(new IPAddress(new byte[] { 0x00, 0x00, 0x00, 0x00 }), (byte)0)
                .Returns((BaseAddress: new IPAddress(new byte[] { 0x00, 0x00, 0x00, 0x00 }), PrefixLength: (byte)0));
        }

        public static System.Collections.IEnumerable GetEqualsTestData()
        {
            yield return new TestCaseData(new IPAddress(new byte[] { 0x00, 0x00, 0x00, 0x00 }), new IPAddress(new byte[] { 0x00, 0x00, 0x00, 0x00 }))
                .Returns(true);
        }

        public static System.Collections.IEnumerable GetContainsTestData()
        {
            yield return new TestCaseData(new IPNetwork(new(new byte[] { 0x00, 0x00, 0x00, 0x00 }), 0), new IPAddress(new byte[] { 0x00, 0x00, 0x00, 0x00 }))
                .Returns(true);
        }

        public static System.Collections.IEnumerable GetParseTestData()
        {
            yield return new TestCaseData("0.0.0.0/0")
                .Returns(new IPNetwork(new(new byte[] { 0x00, 0x00, 0x00, 0x00 }), 0));
        }

        public static System.Collections.IEnumerable GetTryParseTestData()
        {
            yield return new TestCaseData("0.0.0.0/0")
                .Returns((ReturnValue: true, Result: new IPNetwork(new(new byte[] { 0x00, 0x00, 0x00, 0x00 }), 0)));
        }
    }
}