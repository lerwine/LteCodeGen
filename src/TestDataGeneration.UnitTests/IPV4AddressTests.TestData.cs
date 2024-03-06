using System.Globalization;
using TestDataGeneration.Numerics;

namespace TestDataGeneration.UnitTests;

public partial class IPV4AddressTests
{
    static class TestData
    {
        public static System.Collections.IEnumerable GetConstructorTestData()
        {
            yield return new TestCaseData((byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00).Returns(0x00_00_00_00u);
            yield return new TestCaseData((byte)0xc0, (byte)0xa8, (byte)0x0a, (byte)0x02).Returns(0xc0_a8_0a_02u);
        }

        public static System.Collections.IEnumerable GetAsMaskedTestData()
        {
            yield return new TestCaseData(new IPv4Address(0x00, 0x00, 0x00, 0x00), new IPv4Address(0x00, 0x00, 0x00, 0x00)).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
        }

        public static System.Collections.IEnumerable GetAsEndOfSegmentTestData()
        {
            yield return new TestCaseData(new IPv4Address(0x00, 0x00, 0x00, 0x00), (byte)0).Returns(new IPv4Address(0xff, 0xff, 0xff, 0xff));
        }

        public static System.Collections.IEnumerable GetCompareToTestData()
        {
            yield return new TestCaseData(new IPv4Address(0x00, 0x00, 0x00, 0x00), new IPv4Address(0x00, 0x00, 0x00, 0x00)).Returns(0);
        }

        public static System.Collections.IEnumerable GetEqualsTestData()
        {
            yield return new TestCaseData(new IPv4Address(0x00, 0x00, 0x00, 0x00), new IPv4Address(0x00, 0x00, 0x00, 0x00)).Returns(true);
        }

        public static System.Collections.IEnumerable GetFromAddressTestData()
        {
            yield return new TestCaseData(0x00_00_00_00u).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
            yield return new TestCaseData(0x02_0a_a8_c0u).Returns(new IPv4Address(0xc0, 0xa8, 0x0a, 0x02));
        }

        public static System.Collections.IEnumerable GetGetAddressTestData()
        {
            yield return new TestCaseData((byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00).Returns(0x00_00_00_00u);
            yield return new TestCaseData((byte)0xc0, (byte)0xa8, (byte)0x0a, (byte)0x02).Returns(0x02_0a_a8_c0u);
        }

        private static readonly IFormatProvider _formatProvider = CultureInfo.InvariantCulture.NumberFormat;

        public static System.Collections.IEnumerable GetParse1TestData()
        {
            yield return new TestCaseData("0.0.0.0", _formatProvider).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
            yield return new TestCaseData("0.55.49.1", _formatProvider).Returns(new IPv4Address(0x00, 0x37, 0x31, 0x01));
            yield return new TestCaseData("0.136.214.2", _formatProvider).Returns(new IPv4Address(0x00, 0x88, 0xd6, 0x02));
            yield return new TestCaseData("0.139.254.3", _formatProvider).Returns(new IPv4Address(0x00, 0x8b, 0xfe, 0x03));
            yield return new TestCaseData("0.233.242.20", _formatProvider).Returns(new IPv4Address(0x00, 0xe9, 0xf2, 0x14));
            yield return new TestCaseData("0.254.44.25", _formatProvider).Returns(new IPv4Address(0x00, 0xfe, 0x2c, 0x19));
            yield return new TestCaseData("0.174.82.26", _formatProvider).Returns(new IPv4Address(0x00, 0xae, 0x52, 0x1a));
            yield return new TestCaseData("0.211.4.100", _formatProvider).Returns(new IPv4Address(0x00, 0xd3, 0x04, 0x64));
            yield return new TestCaseData("0.33.145.199", _formatProvider).Returns(new IPv4Address(0x00, 0x21, 0x91, 0xc7));
            yield return new TestCaseData("0.248.103.200", _formatProvider).Returns(new IPv4Address(0x00, 0xf8, 0x67, 0xc8));
            yield return new TestCaseData("0.227.156.250", _formatProvider).Returns(new IPv4Address(0x00, 0xe3, 0x9c, 0xfa));
            yield return new TestCaseData("0.46.48.255", _formatProvider).Returns(new IPv4Address(0x00, 0x2e, 0x30, 0xff));
            yield return new TestCaseData("1.44.13.0", _formatProvider).Returns(new IPv4Address(0x01, 0x2c, 0x0d, 0x00));
            yield return new TestCaseData("1.134.238.1", _formatProvider).Returns(new IPv4Address(0x01, 0x86, 0xee, 0x01));
            yield return new TestCaseData("1.80.231.2", _formatProvider).Returns(new IPv4Address(0x01, 0x50, 0xe7, 0x02));
            yield return new TestCaseData("1.15.249.3", _formatProvider).Returns(new IPv4Address(0x01, 0x0f, 0xf9, 0x03));
            yield return new TestCaseData("1.229.81.20", _formatProvider).Returns(new IPv4Address(0x01, 0xe5, 0x51, 0x14));
            yield return new TestCaseData("1.75.225.25", _formatProvider).Returns(new IPv4Address(0x01, 0x4b, 0xe1, 0x19));
            yield return new TestCaseData("1.163.21.26", _formatProvider).Returns(new IPv4Address(0x01, 0xa3, 0x15, 0x1a));
            yield return new TestCaseData("1.248.79.100", _formatProvider).Returns(new IPv4Address(0x01, 0xf8, 0x4f, 0x64));
            yield return new TestCaseData("1.240.215.199", _formatProvider).Returns(new IPv4Address(0x01, 0xf0, 0xd7, 0xc7));
            yield return new TestCaseData("1.25.250.200", _formatProvider).Returns(new IPv4Address(0x01, 0x19, 0xfa, 0xc8));
            yield return new TestCaseData("1.0.254.250", _formatProvider).Returns(new IPv4Address(0x01, 0x00, 0xfe, 0xfa));
            yield return new TestCaseData("1.102.156.255", _formatProvider).Returns(new IPv4Address(0x01, 0x66, 0x9c, 0xff));
            yield return new TestCaseData("2.173.214.0", _formatProvider).Returns(new IPv4Address(0x02, 0xad, 0xd6, 0x00));
            yield return new TestCaseData("2.166.64.1", _formatProvider).Returns(new IPv4Address(0x02, 0xa6, 0x40, 0x01));
            yield return new TestCaseData("2.234.177.2", _formatProvider).Returns(new IPv4Address(0x02, 0xea, 0xb1, 0x02));
            yield return new TestCaseData("2.128.193.3", _formatProvider).Returns(new IPv4Address(0x02, 0x80, 0xc1, 0x03));
            yield return new TestCaseData("2.58.6.20", _formatProvider).Returns(new IPv4Address(0x02, 0x3a, 0x06, 0x14));
            yield return new TestCaseData("2.4.123.25", _formatProvider).Returns(new IPv4Address(0x02, 0x04, 0x7b, 0x19));
            yield return new TestCaseData("2.79.157.26", _formatProvider).Returns(new IPv4Address(0x02, 0x4f, 0x9d, 0x1a));
            yield return new TestCaseData("2.173.1.100", _formatProvider).Returns(new IPv4Address(0x02, 0xad, 0x01, 0x64));
            yield return new TestCaseData("2.226.5.199", _formatProvider).Returns(new IPv4Address(0x02, 0xe2, 0x05, 0xc7));
            yield return new TestCaseData("2.70.93.200", _formatProvider).Returns(new IPv4Address(0x02, 0x46, 0x5d, 0xc8));
            yield return new TestCaseData("2.6.241.250", _formatProvider).Returns(new IPv4Address(0x02, 0x06, 0xf1, 0xfa));
            yield return new TestCaseData("2.96.12.255", _formatProvider).Returns(new IPv4Address(0x02, 0x60, 0x0c, 0xff));
            yield return new TestCaseData("3.152.168.0", _formatProvider).Returns(new IPv4Address(0x03, 0x98, 0xa8, 0x00));
            yield return new TestCaseData("3.119.12.1", _formatProvider).Returns(new IPv4Address(0x03, 0x77, 0x0c, 0x01));
            yield return new TestCaseData("3.131.52.2", _formatProvider).Returns(new IPv4Address(0x03, 0x83, 0x34, 0x02));
            yield return new TestCaseData("3.48.46.3", _formatProvider).Returns(new IPv4Address(0x03, 0x30, 0x2e, 0x03));
            yield return new TestCaseData("3.167.234.20", _formatProvider).Returns(new IPv4Address(0x03, 0xa7, 0xea, 0x14));
            yield return new TestCaseData("3.64.122.25", _formatProvider).Returns(new IPv4Address(0x03, 0x40, 0x7a, 0x19));
            yield return new TestCaseData("3.65.207.26", _formatProvider).Returns(new IPv4Address(0x03, 0x41, 0xcf, 0x1a));
            yield return new TestCaseData("3.14.52.100", _formatProvider).Returns(new IPv4Address(0x03, 0x0e, 0x34, 0x64));
            yield return new TestCaseData("3.208.138.199", _formatProvider).Returns(new IPv4Address(0x03, 0xd0, 0x8a, 0xc7));
            yield return new TestCaseData("3.166.156.200", _formatProvider).Returns(new IPv4Address(0x03, 0xa6, 0x9c, 0xc8));
            yield return new TestCaseData("3.16.125.250", _formatProvider).Returns(new IPv4Address(0x03, 0x10, 0x7d, 0xfa));
            yield return new TestCaseData("3.0.83.255", _formatProvider).Returns(new IPv4Address(0x03, 0x00, 0x53, 0xff));
            yield return new TestCaseData("20.42.23.0", _formatProvider).Returns(new IPv4Address(0x14, 0x2a, 0x17, 0x00));
            yield return new TestCaseData("20.23.251.1", _formatProvider).Returns(new IPv4Address(0x14, 0x17, 0xfb, 0x01));
            yield return new TestCaseData("20.183.9.2", _formatProvider).Returns(new IPv4Address(0x14, 0xb7, 0x09, 0x02));
            yield return new TestCaseData("20.150.187.3", _formatProvider).Returns(new IPv4Address(0x14, 0x96, 0xbb, 0x03));
            yield return new TestCaseData("20.117.154.20", _formatProvider).Returns(new IPv4Address(0x14, 0x75, 0x9a, 0x14));
            yield return new TestCaseData("20.167.65.25", _formatProvider).Returns(new IPv4Address(0x14, 0xa7, 0x41, 0x19));
            yield return new TestCaseData("20.58.116.26", _formatProvider).Returns(new IPv4Address(0x14, 0x3a, 0x74, 0x1a));
            yield return new TestCaseData("20.61.6.100", _formatProvider).Returns(new IPv4Address(0x14, 0x3d, 0x06, 0x64));
            yield return new TestCaseData("20.214.213.199", _formatProvider).Returns(new IPv4Address(0x14, 0xd6, 0xd5, 0xc7));
            yield return new TestCaseData("20.212.101.200", _formatProvider).Returns(new IPv4Address(0x14, 0xd4, 0x65, 0xc8));
            yield return new TestCaseData("20.92.51.250", _formatProvider).Returns(new IPv4Address(0x14, 0x5c, 0x33, 0xfa));
            yield return new TestCaseData("20.192.19.255", _formatProvider).Returns(new IPv4Address(0x14, 0xc0, 0x13, 0xff));
            yield return new TestCaseData("25.246.17.0", _formatProvider).Returns(new IPv4Address(0x19, 0xf6, 0x11, 0x00));
            yield return new TestCaseData("25.140.123.1", _formatProvider).Returns(new IPv4Address(0x19, 0x8c, 0x7b, 0x01));
            yield return new TestCaseData("25.74.195.2", _formatProvider).Returns(new IPv4Address(0x19, 0x4a, 0xc3, 0x02));
            yield return new TestCaseData("25.251.27.3", _formatProvider).Returns(new IPv4Address(0x19, 0xfb, 0x1b, 0x03));
            yield return new TestCaseData("25.168.36.20", _formatProvider).Returns(new IPv4Address(0x19, 0xa8, 0x24, 0x14));
            yield return new TestCaseData("25.225.108.25", _formatProvider).Returns(new IPv4Address(0x19, 0xe1, 0x6c, 0x19));
            yield return new TestCaseData("25.28.52.26", _formatProvider).Returns(new IPv4Address(0x19, 0x1c, 0x34, 0x1a));
            yield return new TestCaseData("25.118.158.100", _formatProvider).Returns(new IPv4Address(0x19, 0x76, 0x9e, 0x64));
            yield return new TestCaseData("25.84.132.199", _formatProvider).Returns(new IPv4Address(0x19, 0x54, 0x84, 0xc7));
            yield return new TestCaseData("25.4.167.200", _formatProvider).Returns(new IPv4Address(0x19, 0x04, 0xa7, 0xc8));
            yield return new TestCaseData("25.39.205.250", _formatProvider).Returns(new IPv4Address(0x19, 0x27, 0xcd, 0xfa));
            yield return new TestCaseData("25.250.91.255", _formatProvider).Returns(new IPv4Address(0x19, 0xfa, 0x5b, 0xff));
            yield return new TestCaseData("26.77.160.0", _formatProvider).Returns(new IPv4Address(0x1a, 0x4d, 0xa0, 0x00));
            yield return new TestCaseData("26.198.59.1", _formatProvider).Returns(new IPv4Address(0x1a, 0xc6, 0x3b, 0x01));
            yield return new TestCaseData("26.169.154.2", _formatProvider).Returns(new IPv4Address(0x1a, 0xa9, 0x9a, 0x02));
            yield return new TestCaseData("26.246.246.3", _formatProvider).Returns(new IPv4Address(0x1a, 0xf6, 0xf6, 0x03));
            yield return new TestCaseData("26.86.4.20", _formatProvider).Returns(new IPv4Address(0x1a, 0x56, 0x04, 0x14));
            yield return new TestCaseData("26.5.166.25", _formatProvider).Returns(new IPv4Address(0x1a, 0x05, 0xa6, 0x19));
            yield return new TestCaseData("26.124.26.26", _formatProvider).Returns(new IPv4Address(0x1a, 0x7c, 0x1a, 0x1a));
            yield return new TestCaseData("26.112.177.100", _formatProvider).Returns(new IPv4Address(0x1a, 0x70, 0xb1, 0x64));
            yield return new TestCaseData("26.158.139.199", _formatProvider).Returns(new IPv4Address(0x1a, 0x9e, 0x8b, 0xc7));
            yield return new TestCaseData("26.152.21.200", _formatProvider).Returns(new IPv4Address(0x1a, 0x98, 0x15, 0xc8));
            yield return new TestCaseData("26.146.208.250", _formatProvider).Returns(new IPv4Address(0x1a, 0x92, 0xd0, 0xfa));
            yield return new TestCaseData("26.234.161.255", _formatProvider).Returns(new IPv4Address(0x1a, 0xea, 0xa1, 0xff));
            yield return new TestCaseData("100.94.53.0", _formatProvider).Returns(new IPv4Address(0x64, 0x5e, 0x35, 0x00));
            yield return new TestCaseData("100.17.215.1", _formatProvider).Returns(new IPv4Address(0x64, 0x11, 0xd7, 0x01));
            yield return new TestCaseData("100.46.25.2", _formatProvider).Returns(new IPv4Address(0x64, 0x2e, 0x19, 0x02));
            yield return new TestCaseData("100.235.41.3", _formatProvider).Returns(new IPv4Address(0x64, 0xeb, 0x29, 0x03));
            yield return new TestCaseData("100.23.49.20", _formatProvider).Returns(new IPv4Address(0x64, 0x17, 0x31, 0x14));
            yield return new TestCaseData("100.46.170.25", _formatProvider).Returns(new IPv4Address(0x64, 0x2e, 0xaa, 0x19));
            yield return new TestCaseData("100.253.192.26", _formatProvider).Returns(new IPv4Address(0x64, 0xfd, 0xc0, 0x1a));
            yield return new TestCaseData("100.114.14.100", _formatProvider).Returns(new IPv4Address(0x64, 0x72, 0x0e, 0x64));
            yield return new TestCaseData("100.46.235.199", _formatProvider).Returns(new IPv4Address(0x64, 0x2e, 0xeb, 0xc7));
            yield return new TestCaseData("100.21.23.200", _formatProvider).Returns(new IPv4Address(0x64, 0x15, 0x17, 0xc8));
            yield return new TestCaseData("100.47.208.250", _formatProvider).Returns(new IPv4Address(0x64, 0x2f, 0xd0, 0xfa));
            yield return new TestCaseData("100.34.57.255", _formatProvider).Returns(new IPv4Address(0x64, 0x22, 0x39, 0xff));
            yield return new TestCaseData("199.20.83.0", _formatProvider).Returns(new IPv4Address(0xc7, 0x14, 0x53, 0x00));
            yield return new TestCaseData("199.8.155.1", _formatProvider).Returns(new IPv4Address(0xc7, 0x08, 0x9b, 0x01));
            yield return new TestCaseData("199.52.228.2", _formatProvider).Returns(new IPv4Address(0xc7, 0x34, 0xe4, 0x02));
            yield return new TestCaseData("199.200.124.3", _formatProvider).Returns(new IPv4Address(0xc7, 0xc8, 0x7c, 0x03));
            yield return new TestCaseData("199.182.36.20", _formatProvider).Returns(new IPv4Address(0xc7, 0xb6, 0x24, 0x14));
            yield return new TestCaseData("199.220.115.25", _formatProvider).Returns(new IPv4Address(0xc7, 0xdc, 0x73, 0x19));
            yield return new TestCaseData("199.136.30.26", _formatProvider).Returns(new IPv4Address(0xc7, 0x88, 0x1e, 0x1a));
            yield return new TestCaseData("199.200.60.100", _formatProvider).Returns(new IPv4Address(0xc7, 0xc8, 0x3c, 0x64));
            yield return new TestCaseData("199.24.219.199", _formatProvider).Returns(new IPv4Address(0xc7, 0x18, 0xdb, 0xc7));
            yield return new TestCaseData("199.143.74.200", _formatProvider).Returns(new IPv4Address(0xc7, 0x8f, 0x4a, 0xc8));
            yield return new TestCaseData("199.235.198.250", _formatProvider).Returns(new IPv4Address(0xc7, 0xeb, 0xc6, 0xfa));
            yield return new TestCaseData("199.179.222.255", _formatProvider).Returns(new IPv4Address(0xc7, 0xb3, 0xde, 0xff));
            yield return new TestCaseData("200.25.138.0", _formatProvider).Returns(new IPv4Address(0xc8, 0x19, 0x8a, 0x00));
            yield return new TestCaseData("200.231.167.1", _formatProvider).Returns(new IPv4Address(0xc8, 0xe7, 0xa7, 0x01));
            yield return new TestCaseData("200.187.210.2", _formatProvider).Returns(new IPv4Address(0xc8, 0xbb, 0xd2, 0x02));
            yield return new TestCaseData("200.114.142.3", _formatProvider).Returns(new IPv4Address(0xc8, 0x72, 0x8e, 0x03));
            yield return new TestCaseData("200.19.215.20", _formatProvider).Returns(new IPv4Address(0xc8, 0x13, 0xd7, 0x14));
            yield return new TestCaseData("200.195.219.25", _formatProvider).Returns(new IPv4Address(0xc8, 0xc3, 0xdb, 0x19));
            yield return new TestCaseData("200.17.79.26", _formatProvider).Returns(new IPv4Address(0xc8, 0x11, 0x4f, 0x1a));
            yield return new TestCaseData("200.245.50.100", _formatProvider).Returns(new IPv4Address(0xc8, 0xf5, 0x32, 0x64));
            yield return new TestCaseData("200.104.178.199", _formatProvider).Returns(new IPv4Address(0xc8, 0x68, 0xb2, 0xc7));
            yield return new TestCaseData("200.243.217.200", _formatProvider).Returns(new IPv4Address(0xc8, 0xf3, 0xd9, 0xc8));
            yield return new TestCaseData("200.227.255.250", _formatProvider).Returns(new IPv4Address(0xc8, 0xe3, 0xff, 0xfa));
            yield return new TestCaseData("200.133.15.255", _formatProvider).Returns(new IPv4Address(0xc8, 0x85, 0x0f, 0xff));
            yield return new TestCaseData("250.34.216.0", _formatProvider).Returns(new IPv4Address(0xfa, 0x22, 0xd8, 0x00));
            yield return new TestCaseData("250.255.83.1", _formatProvider).Returns(new IPv4Address(0xfa, 0xff, 0x53, 0x01));
            yield return new TestCaseData("250.65.215.2", _formatProvider).Returns(new IPv4Address(0xfa, 0x41, 0xd7, 0x02));
            yield return new TestCaseData("250.78.77.3", _formatProvider).Returns(new IPv4Address(0xfa, 0x4e, 0x4d, 0x03));
            yield return new TestCaseData("250.159.41.20", _formatProvider).Returns(new IPv4Address(0xfa, 0x9f, 0x29, 0x14));
            yield return new TestCaseData("250.130.169.25", _formatProvider).Returns(new IPv4Address(0xfa, 0x82, 0xa9, 0x19));
            yield return new TestCaseData("250.253.32.26", _formatProvider).Returns(new IPv4Address(0xfa, 0xfd, 0x20, 0x1a));
            yield return new TestCaseData("250.193.228.100", _formatProvider).Returns(new IPv4Address(0xfa, 0xc1, 0xe4, 0x64));
            yield return new TestCaseData("250.178.78.199", _formatProvider).Returns(new IPv4Address(0xfa, 0xb2, 0x4e, 0xc7));
            yield return new TestCaseData("250.95.177.200", _formatProvider).Returns(new IPv4Address(0xfa, 0x5f, 0xb1, 0xc8));
            yield return new TestCaseData("250.90.237.250", _formatProvider).Returns(new IPv4Address(0xfa, 0x5a, 0xed, 0xfa));
            yield return new TestCaseData("250.43.200.255", _formatProvider).Returns(new IPv4Address(0xfa, 0x2b, 0xc8, 0xff));
            yield return new TestCaseData("255.230.92.0", _formatProvider).Returns(new IPv4Address(0xff, 0xe6, 0x5c, 0x00));
            yield return new TestCaseData("255.225.56.1", _formatProvider).Returns(new IPv4Address(0xff, 0xe1, 0x38, 0x01));
            yield return new TestCaseData("255.211.218.2", _formatProvider).Returns(new IPv4Address(0xff, 0xd3, 0xda, 0x02));
            yield return new TestCaseData("255.250.26.3", _formatProvider).Returns(new IPv4Address(0xff, 0xfa, 0x1a, 0x03));
            yield return new TestCaseData("255.5.215.20", _formatProvider).Returns(new IPv4Address(0xff, 0x05, 0xd7, 0x14));
            yield return new TestCaseData("255.133.226.25", _formatProvider).Returns(new IPv4Address(0xff, 0x85, 0xe2, 0x19));
            yield return new TestCaseData("255.210.30.26", _formatProvider).Returns(new IPv4Address(0xff, 0xd2, 0x1e, 0x1a));
            yield return new TestCaseData("255.76.60.100", _formatProvider).Returns(new IPv4Address(0xff, 0x4c, 0x3c, 0x64));
            yield return new TestCaseData("255.137.118.199", _formatProvider).Returns(new IPv4Address(0xff, 0x89, 0x76, 0xc7));
            yield return new TestCaseData("255.59.231.200", _formatProvider).Returns(new IPv4Address(0xff, 0x3b, 0xe7, 0xc8));
            yield return new TestCaseData("255.205.75.250", _formatProvider).Returns(new IPv4Address(0xff, 0xcd, 0x4b, 0xfa));
            yield return new TestCaseData("255.255.255.255", _formatProvider).Returns(new IPv4Address(0xff, 0xff, 0xff, 0xff));
        }

        public static System.Collections.IEnumerable GetParse2TestData()
        {
            yield return new TestCaseData("0.0.0.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
            yield return new TestCaseData("0.254.234.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0xfe, 0xea, 0x01));
            yield return new TestCaseData("0.245.224.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0xf5, 0xe0, 0x02));
            yield return new TestCaseData("0.137.143.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0x89, 0x8f, 0x03));
            yield return new TestCaseData("0.106.56.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0x6a, 0x38, 0x14));
            yield return new TestCaseData("0.179.159.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0xb3, 0x9f, 0x19));
            yield return new TestCaseData("0.64.35.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0x40, 0x23, 0x1a));
            yield return new TestCaseData("0.122.221.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0x7a, 0xdd, 0x64));
            yield return new TestCaseData("0.217.176.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0xd9, 0xb0, 0xc7));
            yield return new TestCaseData("0.118.136.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0x76, 0x88, 0xc8));
            yield return new TestCaseData("0.253.69.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0xfd, 0x45, 0xfa));
            yield return new TestCaseData("0.162.53.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0xa2, 0x35, 0xff));
            yield return new TestCaseData("1.214.106.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0xd6, 0x6a, 0x00));
            yield return new TestCaseData("1.128.172.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x80, 0xac, 0x01));
            yield return new TestCaseData("1.39.86.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x27, 0x56, 0x02));
            yield return new TestCaseData("1.48.212.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x30, 0xd4, 0x03));
            yield return new TestCaseData("1.21.188.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x15, 0xbc, 0x14));
            yield return new TestCaseData("1.44.63.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x2c, 0x3f, 0x19));
            yield return new TestCaseData("1.186.18.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0xba, 0x12, 0x1a));
            yield return new TestCaseData("1.224.253.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0xe0, 0xfd, 0x64));
            yield return new TestCaseData("1.86.61.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x56, 0x3d, 0xc7));
            yield return new TestCaseData("1.149.71.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x95, 0x47, 0xc8));
            yield return new TestCaseData("1.11.230.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x0b, 0xe6, 0xfa));
            yield return new TestCaseData("1.45.186.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x01, 0x2d, 0xba, 0xff));
            yield return new TestCaseData("2.6.4.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x06, 0x04, 0x00));
            yield return new TestCaseData("2.30.4.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x1e, 0x04, 0x01));
            yield return new TestCaseData("2.99.11.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x63, 0x0b, 0x02));
            yield return new TestCaseData("2.78.49.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x4e, 0x31, 0x03));
            yield return new TestCaseData("2.36.200.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x24, 0xc8, 0x14));
            yield return new TestCaseData("2.19.139.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x13, 0x8b, 0x19));
            yield return new TestCaseData("2.95.220.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x5f, 0xdc, 0x1a));
            yield return new TestCaseData("2.104.19.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x68, 0x13, 0x64));
            yield return new TestCaseData("2.8.222.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x08, 0xde, 0xc7));
            yield return new TestCaseData("2.137.131.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x89, 0x83, 0xc8));
            yield return new TestCaseData("2.246.58.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0xf6, 0x3a, 0xfa));
            yield return new TestCaseData("2.34.199.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x02, 0x22, 0xc7, 0xff));
            yield return new TestCaseData("3.207.121.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0xcf, 0x79, 0x00));
            yield return new TestCaseData("3.50.191.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x32, 0xbf, 0x01));
            yield return new TestCaseData("3.176.91.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0xb0, 0x5b, 0x02));
            yield return new TestCaseData("3.41.240.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x29, 0xf0, 0x03));
            yield return new TestCaseData("3.60.198.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x3c, 0xc6, 0x14));
            yield return new TestCaseData("3.166.34.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0xa6, 0x22, 0x19));
            yield return new TestCaseData("3.56.44.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x38, 0x2c, 0x1a));
            yield return new TestCaseData("3.113.10.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x71, 0x0a, 0x64));
            yield return new TestCaseData("3.110.251.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x6e, 0xfb, 0xc7));
            yield return new TestCaseData("3.27.241.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x1b, 0xf1, 0xc8));
            yield return new TestCaseData("3.254.85.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0xfe, 0x55, 0xfa));
            yield return new TestCaseData("3.157.121.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x03, 0x9d, 0x79, 0xff));
            yield return new TestCaseData("20.213.129.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0xd5, 0x81, 0x00));
            yield return new TestCaseData("20.62.44.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0x3e, 0x2c, 0x01));
            yield return new TestCaseData("20.92.170.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0x5c, 0xaa, 0x02));
            yield return new TestCaseData("20.195.203.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0xc3, 0xcb, 0x03));
            yield return new TestCaseData("20.225.86.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0xe1, 0x56, 0x14));
            yield return new TestCaseData("20.52.233.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0x34, 0xe9, 0x19));
            yield return new TestCaseData("20.217.142.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0xd9, 0x8e, 0x1a));
            yield return new TestCaseData("20.129.201.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0x81, 0xc9, 0x64));
            yield return new TestCaseData("20.159.35.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0x9f, 0x23, 0xc7));
            yield return new TestCaseData("20.78.153.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0x4e, 0x99, 0xc8));
            yield return new TestCaseData("20.54.69.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0x36, 0x45, 0xfa));
            yield return new TestCaseData("20.219.220.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x14, 0xdb, 0xdc, 0xff));
            yield return new TestCaseData("25.109.127.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x6d, 0x7f, 0x00));
            yield return new TestCaseData("25.21.251.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x15, 0xfb, 0x01));
            yield return new TestCaseData("25.30.49.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x1e, 0x31, 0x02));
            yield return new TestCaseData("25.200.122.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0xc8, 0x7a, 0x03));
            yield return new TestCaseData("25.220.185.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0xdc, 0xb9, 0x14));
            yield return new TestCaseData("25.234.46.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0xea, 0x2e, 0x19));
            yield return new TestCaseData("25.28.252.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x1c, 0xfc, 0x1a));
            yield return new TestCaseData("25.147.146.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x93, 0x92, 0x64));
            yield return new TestCaseData("25.2.218.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x02, 0xda, 0xc7));
            yield return new TestCaseData("25.64.225.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x40, 0xe1, 0xc8));
            yield return new TestCaseData("25.247.135.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0xf7, 0x87, 0xfa));
            yield return new TestCaseData("25.48.223.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x19, 0x30, 0xdf, 0xff));
            yield return new TestCaseData("26.121.82.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0x79, 0x52, 0x00));
            yield return new TestCaseData("26.82.219.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0x52, 0xdb, 0x01));
            yield return new TestCaseData("26.6.4.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0x06, 0x04, 0x02));
            yield return new TestCaseData("26.66.143.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0x42, 0x8f, 0x03));
            yield return new TestCaseData("26.166.98.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0xa6, 0x62, 0x14));
            yield return new TestCaseData("26.191.220.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0xbf, 0xdc, 0x19));
            yield return new TestCaseData("26.148.200.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0x94, 0xc8, 0x1a));
            yield return new TestCaseData("26.173.176.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0xad, 0xb0, 0x64));
            yield return new TestCaseData("26.142.186.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0x8e, 0xba, 0xc7));
            yield return new TestCaseData("26.13.32.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0x0d, 0x20, 0xc8));
            yield return new TestCaseData("26.164.82.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0xa4, 0x52, 0xfa));
            yield return new TestCaseData("26.173.162.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x1a, 0xad, 0xa2, 0xff));
            yield return new TestCaseData("100.143.188.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x8f, 0xbc, 0x00));
            yield return new TestCaseData("100.150.92.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x96, 0x5c, 0x01));
            yield return new TestCaseData("100.5.250.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x05, 0xfa, 0x02));
            yield return new TestCaseData("100.228.230.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0xe4, 0xe6, 0x03));
            yield return new TestCaseData("100.79.53.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x4f, 0x35, 0x14));
            yield return new TestCaseData("100.129.204.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x81, 0xcc, 0x19));
            yield return new TestCaseData("100.222.237.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0xde, 0xed, 0x1a));
            yield return new TestCaseData("100.115.216.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x73, 0xd8, 0x64));
            yield return new TestCaseData("100.118.91.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x76, 0x5b, 0xc7));
            yield return new TestCaseData("100.136.185.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x88, 0xb9, 0xc8));
            yield return new TestCaseData("100.61.183.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0x3d, 0xb7, 0xfa));
            yield return new TestCaseData("100.253.58.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x64, 0xfd, 0x3a, 0xff));
            yield return new TestCaseData("199.45.143.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x2d, 0x8f, 0x00));
            yield return new TestCaseData("199.82.61.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x52, 0x3d, 0x01));
            yield return new TestCaseData("199.121.16.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x79, 0x10, 0x02));
            yield return new TestCaseData("199.59.39.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x3b, 0x27, 0x03));
            yield return new TestCaseData("199.164.176.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0xa4, 0xb0, 0x14));
            yield return new TestCaseData("199.75.74.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x4b, 0x4a, 0x19));
            yield return new TestCaseData("199.109.230.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x6d, 0xe6, 0x1a));
            yield return new TestCaseData("199.138.171.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x8a, 0xab, 0x64));
            yield return new TestCaseData("199.125.217.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x7d, 0xd9, 0xc7));
            yield return new TestCaseData("199.141.95.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x8d, 0x5f, 0xc8));
            yield return new TestCaseData("199.70.224.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0x46, 0xe0, 0xfa));
            yield return new TestCaseData("199.210.161.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc7, 0xd2, 0xa1, 0xff));
            yield return new TestCaseData("200.71.53.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0x47, 0x35, 0x00));
            yield return new TestCaseData("200.169.72.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0xa9, 0x48, 0x01));
            yield return new TestCaseData("200.202.243.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0xca, 0xf3, 0x02));
            yield return new TestCaseData("200.100.216.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0x64, 0xd8, 0x03));
            yield return new TestCaseData("200.190.91.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0xbe, 0x5b, 0x14));
            yield return new TestCaseData("200.47.117.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0x2f, 0x75, 0x19));
            yield return new TestCaseData("200.167.167.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0xa7, 0xa7, 0x1a));
            yield return new TestCaseData("200.108.63.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0x6c, 0x3f, 0x64));
            yield return new TestCaseData("200.250.90.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0xfa, 0x5a, 0xc7));
            yield return new TestCaseData("200.40.45.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0x28, 0x2d, 0xc8));
            yield return new TestCaseData("200.161.40.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0xa1, 0x28, 0xfa));
            yield return new TestCaseData("200.106.144.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xc8, 0x6a, 0x90, 0xff));
            yield return new TestCaseData("250.209.220.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0xd1, 0xdc, 0x00));
            yield return new TestCaseData("250.60.100.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0x3c, 0x64, 0x01));
            yield return new TestCaseData("250.41.158.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0x29, 0x9e, 0x02));
            yield return new TestCaseData("250.243.77.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0xf3, 0x4d, 0x03));
            yield return new TestCaseData("250.189.177.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0xbd, 0xb1, 0x14));
            yield return new TestCaseData("250.246.67.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0xf6, 0x43, 0x19));
            yield return new TestCaseData("250.102.242.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0x66, 0xf2, 0x1a));
            yield return new TestCaseData("250.92.177.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0x5c, 0xb1, 0x64));
            yield return new TestCaseData("250.75.115.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0x4b, 0x73, 0xc7));
            yield return new TestCaseData("250.139.18.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0x8b, 0x12, 0xc8));
            yield return new TestCaseData("250.182.20.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0xb6, 0x14, 0xfa));
            yield return new TestCaseData("250.4.213.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xfa, 0x04, 0xd5, 0xff));
            yield return new TestCaseData("255.108.77.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0x6c, 0x4d, 0x00));
            yield return new TestCaseData("255.100.236.1", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0x64, 0xec, 0x01));
            yield return new TestCaseData("255.184.164.2", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xb8, 0xa4, 0x02));
            yield return new TestCaseData("255.255.30.3", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xff, 0x1e, 0x03));
            yield return new TestCaseData("255.203.25.20", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xcb, 0x19, 0x14));
            yield return new TestCaseData("255.119.237.25", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0x77, 0xed, 0x19));
            yield return new TestCaseData("255.183.0.26", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xb7, 0x00, 0x1a));
            yield return new TestCaseData("255.174.32.100", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xae, 0x20, 0x64));
            yield return new TestCaseData("255.103.225.199", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0x67, 0xe1, 0xc7));
            yield return new TestCaseData("255.184.245.200", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xb8, 0xf5, 0xc8));
            yield return new TestCaseData("255.177.40.250", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xb1, 0x28, 0xfa));
            yield return new TestCaseData("255.255.255.255", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0xff, 0xff, 0xff, 0xff));
            yield return new TestCaseData("00.00.00.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
            yield return new TestCaseData("00.ab.20.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0xab, 0x20, 0x01));
            yield return new TestCaseData("00.a3.94.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0xa3, 0x94, 0x09));
            yield return new TestCaseData("00.5a.36.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0x5a, 0x36, 0x0a));
            yield return new TestCaseData("00.17.5e.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0x17, 0x5e, 0x10));
            yield return new TestCaseData("00.77.23.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0x77, 0x23, 0x19));
            yield return new TestCaseData("00.3b.b8.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0x3b, 0xb8, 0x1a));
            yield return new TestCaseData("00.f9.6e.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0xf9, 0x6e, 0xf0));
            yield return new TestCaseData("00.a0.4e.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x00, 0xa0, 0x4e, 0xff));
            yield return new TestCaseData("01.e4.4f.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0xe4, 0x4f, 0x00));
            yield return new TestCaseData("01.52.d0.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0x52, 0xd0, 0x01));
            yield return new TestCaseData("01.5b.be.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0x5b, 0xbe, 0x09));
            yield return new TestCaseData("01.ae.f8.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0xae, 0xf8, 0x0a));
            yield return new TestCaseData("01.07.b0.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0x07, 0xb0, 0x10));
            yield return new TestCaseData("01.15.0d.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0x15, 0x0d, 0x19));
            yield return new TestCaseData("01.76.43.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0x76, 0x43, 0x1a));
            yield return new TestCaseData("01.16.c8.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0x16, 0xc8, 0xf0));
            yield return new TestCaseData("01.48.df.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x01, 0x48, 0xdf, 0xff));
            yield return new TestCaseData("09.7e.49.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0x7e, 0x49, 0x00));
            yield return new TestCaseData("09.b7.c7.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0xb7, 0xc7, 0x01));
            yield return new TestCaseData("09.08.8a.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0x08, 0x8a, 0x09));
            yield return new TestCaseData("09.4f.2b.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0x4f, 0x2b, 0x0a));
            yield return new TestCaseData("09.ff.4e.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0xff, 0x4e, 0x10));
            yield return new TestCaseData("09.23.78.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0x23, 0x78, 0x19));
            yield return new TestCaseData("09.73.de.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0x73, 0xde, 0x1a));
            yield return new TestCaseData("09.e0.e1.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0xe0, 0xe1, 0xf0));
            yield return new TestCaseData("09.7e.b6.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x09, 0x7e, 0xb6, 0xff));
            yield return new TestCaseData("0a.9f.c6.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0x9f, 0xc6, 0x00));
            yield return new TestCaseData("0a.46.ed.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0x46, 0xed, 0x01));
            yield return new TestCaseData("0a.72.ab.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0x72, 0xab, 0x09));
            yield return new TestCaseData("0a.8c.a9.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0x8c, 0xa9, 0x0a));
            yield return new TestCaseData("0a.21.0a.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0x21, 0x0a, 0x10));
            yield return new TestCaseData("0a.e7.33.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0xe7, 0x33, 0x19));
            yield return new TestCaseData("0a.0c.73.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0x0c, 0x73, 0x1a));
            yield return new TestCaseData("0a.70.1a.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0x70, 0x1a, 0xf0));
            yield return new TestCaseData("0a.ef.56.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x0a, 0xef, 0x56, 0xff));
            yield return new TestCaseData("10.96.1c.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0x96, 0x1c, 0x00));
            yield return new TestCaseData("10.47.c8.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0x47, 0xc8, 0x01));
            yield return new TestCaseData("10.80.30.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0x80, 0x30, 0x09));
            yield return new TestCaseData("10.bf.60.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0xbf, 0x60, 0x0a));
            yield return new TestCaseData("10.d4.8e.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0xd4, 0x8e, 0x10));
            yield return new TestCaseData("10.3d.37.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0x3d, 0x37, 0x19));
            yield return new TestCaseData("10.2c.95.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0x2c, 0x95, 0x1a));
            yield return new TestCaseData("10.c5.60.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0xc5, 0x60, 0xf0));
            yield return new TestCaseData("10.29.81.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x10, 0x29, 0x81, 0xff));
            yield return new TestCaseData("19.98.91.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0x98, 0x91, 0x00));
            yield return new TestCaseData("19.d6.0b.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0xd6, 0x0b, 0x01));
            yield return new TestCaseData("19.3b.5e.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0x3b, 0x5e, 0x09));
            yield return new TestCaseData("19.68.45.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0x68, 0x45, 0x0a));
            yield return new TestCaseData("19.43.cb.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0x43, 0xcb, 0x10));
            yield return new TestCaseData("19.41.b0.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0x41, 0xb0, 0x19));
            yield return new TestCaseData("19.08.58.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0x08, 0x58, 0x1a));
            yield return new TestCaseData("19.ee.89.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0xee, 0x89, 0xf0));
            yield return new TestCaseData("19.4a.61.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x19, 0x4a, 0x61, 0xff));
            yield return new TestCaseData("1a.6f.d6.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0x6f, 0xd6, 0x00));
            yield return new TestCaseData("1a.46.16.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0x46, 0x16, 0x01));
            yield return new TestCaseData("1a.2e.11.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0x2e, 0x11, 0x09));
            yield return new TestCaseData("1a.d7.fe.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0xd7, 0xfe, 0x0a));
            yield return new TestCaseData("1a.6c.ea.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0x6c, 0xea, 0x10));
            yield return new TestCaseData("1a.dd.52.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0xdd, 0x52, 0x19));
            yield return new TestCaseData("1a.6e.ac.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0x6e, 0xac, 0x1a));
            yield return new TestCaseData("1a.49.ee.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0x49, 0xee, 0xf0));
            yield return new TestCaseData("1a.82.5e.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0x1a, 0x82, 0x5e, 0xff));
            yield return new TestCaseData("f0.80.8a.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0x80, 0x8a, 0x00));
            yield return new TestCaseData("f0.e1.e8.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0xe1, 0xe8, 0x01));
            yield return new TestCaseData("f0.5f.3a.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0x5f, 0x3a, 0x09));
            yield return new TestCaseData("f0.ec.f3.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0xec, 0xf3, 0x0a));
            yield return new TestCaseData("f0.1f.24.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0x1f, 0x24, 0x10));
            yield return new TestCaseData("f0.86.e5.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0x86, 0xe5, 0x19));
            yield return new TestCaseData("f0.49.a2.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0x49, 0xa2, 0x1a));
            yield return new TestCaseData("f0.4a.63.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0x4a, 0x63, 0xf0));
            yield return new TestCaseData("f0.f1.53.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xf0, 0xf1, 0x53, 0xff));
            yield return new TestCaseData("ff.3b.82.00", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0x3b, 0x82, 0x00));
            yield return new TestCaseData("ff.63.c5.01", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0x63, 0xc5, 0x01));
            yield return new TestCaseData("ff.34.3c.09", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0x34, 0x3c, 0x09));
            yield return new TestCaseData("ff.f2.7e.0a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0xf2, 0x7e, 0x0a));
            yield return new TestCaseData("ff.68.f0.10", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0x68, 0xf0, 0x10));
            yield return new TestCaseData("ff.5d.94.19", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0x5d, 0x94, 0x19));
            yield return new TestCaseData("ff.66.19.1a", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0x66, 0x19, 0x1a));
            yield return new TestCaseData("ff.d6.90.f0", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0xd6, 0x90, 0xf0));
            yield return new TestCaseData("ff.ff.ff.ff", NumberStyles.HexNumber, _formatProvider).Returns(new IPv4Address(0xff, 0xff, 0xff, 0xff));
        }

        public static System.Collections.IEnumerable GetToStringTestData()
        {
            yield return new TestCaseData(new IPv4Address(0x00, 0x00, 0x00, 0x00)).Returns("0.0.0.0");
            yield return new TestCaseData(new IPv4Address(0x00, 0xc6, 0x2b, 0x01)).Returns("0.198.43.1");
            yield return new TestCaseData(new IPv4Address(0x00, 0xe5, 0xe2, 0x02)).Returns("0.229.226.2");
            yield return new TestCaseData(new IPv4Address(0x00, 0x54, 0xa4, 0x03)).Returns("0.84.164.3");
            yield return new TestCaseData(new IPv4Address(0x00, 0x0f, 0x35, 0x14)).Returns("0.15.53.20");
            yield return new TestCaseData(new IPv4Address(0x00, 0xa2, 0x3a, 0x19)).Returns("0.162.58.25");
            yield return new TestCaseData(new IPv4Address(0x00, 0x44, 0x35, 0x1a)).Returns("0.68.53.26");
            yield return new TestCaseData(new IPv4Address(0x00, 0x4f, 0x8a, 0x64)).Returns("0.79.138.100");
            yield return new TestCaseData(new IPv4Address(0x00, 0x78, 0x1c, 0xc7)).Returns("0.120.28.199");
            yield return new TestCaseData(new IPv4Address(0x00, 0x80, 0xf3, 0xc8)).Returns("0.128.243.200");
            yield return new TestCaseData(new IPv4Address(0x00, 0x0d, 0xfc, 0xfa)).Returns("0.13.252.250");
            yield return new TestCaseData(new IPv4Address(0x00, 0xed, 0x2b, 0xff)).Returns("0.237.43.255");
            yield return new TestCaseData(new IPv4Address(0x01, 0x3d, 0xeb, 0x00)).Returns("1.61.235.0");
            yield return new TestCaseData(new IPv4Address(0x01, 0x1f, 0xc7, 0x01)).Returns("1.31.199.1");
            yield return new TestCaseData(new IPv4Address(0x01, 0x59, 0x25, 0x02)).Returns("1.89.37.2");
            yield return new TestCaseData(new IPv4Address(0x01, 0x1e, 0xdc, 0x03)).Returns("1.30.220.3");
            yield return new TestCaseData(new IPv4Address(0x01, 0xf8, 0x67, 0x14)).Returns("1.248.103.20");
            yield return new TestCaseData(new IPv4Address(0x01, 0xc5, 0x0a, 0x19)).Returns("1.197.10.25");
            yield return new TestCaseData(new IPv4Address(0x01, 0x2d, 0x7c, 0x1a)).Returns("1.45.124.26");
            yield return new TestCaseData(new IPv4Address(0x01, 0x09, 0xcc, 0x64)).Returns("1.9.204.100");
            yield return new TestCaseData(new IPv4Address(0x01, 0xb6, 0x82, 0xc7)).Returns("1.182.130.199");
            yield return new TestCaseData(new IPv4Address(0x01, 0xd8, 0x5a, 0xc8)).Returns("1.216.90.200");
            yield return new TestCaseData(new IPv4Address(0x01, 0x42, 0x1a, 0xfa)).Returns("1.66.26.250");
            yield return new TestCaseData(new IPv4Address(0x01, 0xdf, 0xec, 0xff)).Returns("1.223.236.255");
            yield return new TestCaseData(new IPv4Address(0x02, 0x06, 0x48, 0x00)).Returns("2.6.72.0");
            yield return new TestCaseData(new IPv4Address(0x02, 0xc4, 0x44, 0x01)).Returns("2.196.68.1");
            yield return new TestCaseData(new IPv4Address(0x02, 0x2c, 0xba, 0x02)).Returns("2.44.186.2");
            yield return new TestCaseData(new IPv4Address(0x02, 0x8e, 0x8a, 0x03)).Returns("2.142.138.3");
            yield return new TestCaseData(new IPv4Address(0x02, 0xd1, 0x9b, 0x14)).Returns("2.209.155.20");
            yield return new TestCaseData(new IPv4Address(0x02, 0xee, 0xf9, 0x19)).Returns("2.238.249.25");
            yield return new TestCaseData(new IPv4Address(0x02, 0xc2, 0x8c, 0x1a)).Returns("2.194.140.26");
            yield return new TestCaseData(new IPv4Address(0x02, 0x4a, 0xe9, 0x64)).Returns("2.74.233.100");
            yield return new TestCaseData(new IPv4Address(0x02, 0x16, 0xc6, 0xc7)).Returns("2.22.198.199");
            yield return new TestCaseData(new IPv4Address(0x02, 0x42, 0xdc, 0xc8)).Returns("2.66.220.200");
            yield return new TestCaseData(new IPv4Address(0x02, 0x6f, 0x44, 0xfa)).Returns("2.111.68.250");
            yield return new TestCaseData(new IPv4Address(0x02, 0x5c, 0xfc, 0xff)).Returns("2.92.252.255");
            yield return new TestCaseData(new IPv4Address(0x03, 0x12, 0xb3, 0x00)).Returns("3.18.179.0");
            yield return new TestCaseData(new IPv4Address(0x03, 0x3c, 0x8a, 0x01)).Returns("3.60.138.1");
            yield return new TestCaseData(new IPv4Address(0x03, 0x24, 0x93, 0x02)).Returns("3.36.147.2");
            yield return new TestCaseData(new IPv4Address(0x03, 0xe9, 0x22, 0x03)).Returns("3.233.34.3");
            yield return new TestCaseData(new IPv4Address(0x03, 0x0c, 0x33, 0x14)).Returns("3.12.51.20");
            yield return new TestCaseData(new IPv4Address(0x03, 0xc1, 0x11, 0x19)).Returns("3.193.17.25");
            yield return new TestCaseData(new IPv4Address(0x03, 0x61, 0xd9, 0x1a)).Returns("3.97.217.26");
            yield return new TestCaseData(new IPv4Address(0x03, 0xaf, 0x3d, 0x64)).Returns("3.175.61.100");
            yield return new TestCaseData(new IPv4Address(0x03, 0xd8, 0x3b, 0xc7)).Returns("3.216.59.199");
            yield return new TestCaseData(new IPv4Address(0x03, 0x38, 0x92, 0xc8)).Returns("3.56.146.200");
            yield return new TestCaseData(new IPv4Address(0x03, 0x8d, 0x0f, 0xfa)).Returns("3.141.15.250");
            yield return new TestCaseData(new IPv4Address(0x03, 0x0a, 0x2a, 0xff)).Returns("3.10.42.255");
            yield return new TestCaseData(new IPv4Address(0x14, 0x37, 0xee, 0x00)).Returns("20.55.238.0");
            yield return new TestCaseData(new IPv4Address(0x14, 0x43, 0x7b, 0x01)).Returns("20.67.123.1");
            yield return new TestCaseData(new IPv4Address(0x14, 0xd7, 0x02, 0x02)).Returns("20.215.2.2");
            yield return new TestCaseData(new IPv4Address(0x14, 0x7c, 0xc1, 0x03)).Returns("20.124.193.3");
            yield return new TestCaseData(new IPv4Address(0x14, 0xec, 0xc8, 0x14)).Returns("20.236.200.20");
            yield return new TestCaseData(new IPv4Address(0x14, 0x32, 0x78, 0x19)).Returns("20.50.120.25");
            yield return new TestCaseData(new IPv4Address(0x14, 0x7d, 0x03, 0x1a)).Returns("20.125.3.26");
            yield return new TestCaseData(new IPv4Address(0x14, 0x65, 0x3e, 0x64)).Returns("20.101.62.100");
            yield return new TestCaseData(new IPv4Address(0x14, 0xb1, 0xcb, 0xc7)).Returns("20.177.203.199");
            yield return new TestCaseData(new IPv4Address(0x14, 0xed, 0x8e, 0xc8)).Returns("20.237.142.200");
            yield return new TestCaseData(new IPv4Address(0x14, 0xcb, 0x39, 0xfa)).Returns("20.203.57.250");
            yield return new TestCaseData(new IPv4Address(0x14, 0x88, 0x3d, 0xff)).Returns("20.136.61.255");
            yield return new TestCaseData(new IPv4Address(0x19, 0x17, 0x04, 0x00)).Returns("25.23.4.0");
            yield return new TestCaseData(new IPv4Address(0x19, 0x04, 0x34, 0x01)).Returns("25.4.52.1");
            yield return new TestCaseData(new IPv4Address(0x19, 0x0b, 0xc9, 0x02)).Returns("25.11.201.2");
            yield return new TestCaseData(new IPv4Address(0x19, 0x6e, 0x02, 0x03)).Returns("25.110.2.3");
            yield return new TestCaseData(new IPv4Address(0x19, 0xa9, 0x12, 0x14)).Returns("25.169.18.20");
            yield return new TestCaseData(new IPv4Address(0x19, 0x53, 0x35, 0x19)).Returns("25.83.53.25");
            yield return new TestCaseData(new IPv4Address(0x19, 0x50, 0x6e, 0x1a)).Returns("25.80.110.26");
            yield return new TestCaseData(new IPv4Address(0x19, 0x4a, 0x09, 0x64)).Returns("25.74.9.100");
            yield return new TestCaseData(new IPv4Address(0x19, 0xb7, 0xff, 0xc7)).Returns("25.183.255.199");
            yield return new TestCaseData(new IPv4Address(0x19, 0x25, 0x98, 0xc8)).Returns("25.37.152.200");
            yield return new TestCaseData(new IPv4Address(0x19, 0xa7, 0x37, 0xfa)).Returns("25.167.55.250");
            yield return new TestCaseData(new IPv4Address(0x19, 0xbf, 0xd5, 0xff)).Returns("25.191.213.255");
            yield return new TestCaseData(new IPv4Address(0x1a, 0xd5, 0xfa, 0x00)).Returns("26.213.250.0");
            yield return new TestCaseData(new IPv4Address(0x1a, 0xe1, 0xc1, 0x01)).Returns("26.225.193.1");
            yield return new TestCaseData(new IPv4Address(0x1a, 0x22, 0x7b, 0x02)).Returns("26.34.123.2");
            yield return new TestCaseData(new IPv4Address(0x1a, 0x5e, 0xfe, 0x03)).Returns("26.94.254.3");
            yield return new TestCaseData(new IPv4Address(0x1a, 0x65, 0x05, 0x14)).Returns("26.101.5.20");
            yield return new TestCaseData(new IPv4Address(0x1a, 0x64, 0xd2, 0x19)).Returns("26.100.210.25");
            yield return new TestCaseData(new IPv4Address(0x1a, 0xfe, 0x47, 0x1a)).Returns("26.254.71.26");
            yield return new TestCaseData(new IPv4Address(0x1a, 0xb6, 0x22, 0x64)).Returns("26.182.34.100");
            yield return new TestCaseData(new IPv4Address(0x1a, 0x59, 0x30, 0xc7)).Returns("26.89.48.199");
            yield return new TestCaseData(new IPv4Address(0x1a, 0xce, 0x6b, 0xc8)).Returns("26.206.107.200");
            yield return new TestCaseData(new IPv4Address(0x1a, 0xb0, 0x30, 0xfa)).Returns("26.176.48.250");
            yield return new TestCaseData(new IPv4Address(0x1a, 0xed, 0x42, 0xff)).Returns("26.237.66.255");
            yield return new TestCaseData(new IPv4Address(0x64, 0x81, 0xe4, 0x00)).Returns("100.129.228.0");
            yield return new TestCaseData(new IPv4Address(0x64, 0xd6, 0xcb, 0x01)).Returns("100.214.203.1");
            yield return new TestCaseData(new IPv4Address(0x64, 0x13, 0xef, 0x02)).Returns("100.19.239.2");
            yield return new TestCaseData(new IPv4Address(0x64, 0x96, 0xdf, 0x03)).Returns("100.150.223.3");
            yield return new TestCaseData(new IPv4Address(0x64, 0x45, 0x2f, 0x14)).Returns("100.69.47.20");
            yield return new TestCaseData(new IPv4Address(0x64, 0x5f, 0x10, 0x19)).Returns("100.95.16.25");
            yield return new TestCaseData(new IPv4Address(0x64, 0xe8, 0xad, 0x1a)).Returns("100.232.173.26");
            yield return new TestCaseData(new IPv4Address(0x64, 0xe0, 0x2d, 0x64)).Returns("100.224.45.100");
            yield return new TestCaseData(new IPv4Address(0x64, 0xb3, 0x54, 0xc7)).Returns("100.179.84.199");
            yield return new TestCaseData(new IPv4Address(0x64, 0xd0, 0x4a, 0xc8)).Returns("100.208.74.200");
            yield return new TestCaseData(new IPv4Address(0x64, 0x0a, 0x77, 0xfa)).Returns("100.10.119.250");
            yield return new TestCaseData(new IPv4Address(0x64, 0x0b, 0x6f, 0xff)).Returns("100.11.111.255");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x49, 0x02, 0x00)).Returns("199.73.2.0");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x3f, 0x77, 0x01)).Returns("199.63.119.1");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x68, 0x54, 0x02)).Returns("199.104.84.2");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x24, 0xa4, 0x03)).Returns("199.36.164.3");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x0d, 0x9e, 0x14)).Returns("199.13.158.20");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x40, 0x3d, 0x19)).Returns("199.64.61.25");
            yield return new TestCaseData(new IPv4Address(0xc7, 0xa5, 0x92, 0x1a)).Returns("199.165.146.26");
            yield return new TestCaseData(new IPv4Address(0xc7, 0xea, 0x76, 0x64)).Returns("199.234.118.100");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x6f, 0x84, 0xc7)).Returns("199.111.132.199");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x8d, 0xcf, 0xc8)).Returns("199.141.207.200");
            yield return new TestCaseData(new IPv4Address(0xc7, 0xe8, 0xa5, 0xfa)).Returns("199.232.165.250");
            yield return new TestCaseData(new IPv4Address(0xc7, 0x3a, 0xac, 0xff)).Returns("199.58.172.255");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x4f, 0xa1, 0x00)).Returns("200.79.161.0");
            yield return new TestCaseData(new IPv4Address(0xc8, 0xb7, 0x5b, 0x01)).Returns("200.183.91.1");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x60, 0xa2, 0x02)).Returns("200.96.162.2");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x38, 0x09, 0x03)).Returns("200.56.9.3");
            yield return new TestCaseData(new IPv4Address(0xc8, 0xd8, 0x67, 0x14)).Returns("200.216.103.20");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x82, 0x11, 0x19)).Returns("200.130.17.25");
            yield return new TestCaseData(new IPv4Address(0xc8, 0xb0, 0x1f, 0x1a)).Returns("200.176.31.26");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x77, 0xf0, 0x64)).Returns("200.119.240.100");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x0a, 0xba, 0xc7)).Returns("200.10.186.199");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x03, 0x49, 0xc8)).Returns("200.3.73.200");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x6c, 0xa2, 0xfa)).Returns("200.108.162.250");
            yield return new TestCaseData(new IPv4Address(0xc8, 0x88, 0x20, 0xff)).Returns("200.136.32.255");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x6a, 0x59, 0x00)).Returns("250.106.89.0");
            yield return new TestCaseData(new IPv4Address(0xfa, 0xdb, 0x86, 0x01)).Returns("250.219.134.1");
            yield return new TestCaseData(new IPv4Address(0xfa, 0xe9, 0x3c, 0x02)).Returns("250.233.60.2");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x87, 0xa3, 0x03)).Returns("250.135.163.3");
            yield return new TestCaseData(new IPv4Address(0xfa, 0xc8, 0x92, 0x14)).Returns("250.200.146.20");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x27, 0xc6, 0x19)).Returns("250.39.198.25");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x9c, 0xc9, 0x1a)).Returns("250.156.201.26");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x44, 0x6a, 0x64)).Returns("250.68.106.100");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x66, 0x36, 0xc7)).Returns("250.102.54.199");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x65, 0x3d, 0xc8)).Returns("250.101.61.200");
            yield return new TestCaseData(new IPv4Address(0xfa, 0x10, 0xd9, 0xfa)).Returns("250.16.217.250");
            yield return new TestCaseData(new IPv4Address(0xfa, 0xc5, 0x50, 0xff)).Returns("250.197.80.255");
            yield return new TestCaseData(new IPv4Address(0xff, 0x0c, 0x9d, 0x00)).Returns("255.12.157.0");
            yield return new TestCaseData(new IPv4Address(0xff, 0xc4, 0x2d, 0x01)).Returns("255.196.45.1");
            yield return new TestCaseData(new IPv4Address(0xff, 0xa1, 0xf0, 0x02)).Returns("255.161.240.2");
            yield return new TestCaseData(new IPv4Address(0xff, 0x3f, 0xad, 0x03)).Returns("255.63.173.3");
            yield return new TestCaseData(new IPv4Address(0xff, 0x18, 0x97, 0x14)).Returns("255.24.151.20");
            yield return new TestCaseData(new IPv4Address(0xff, 0xf1, 0x06, 0x19)).Returns("255.241.6.25");
            yield return new TestCaseData(new IPv4Address(0xff, 0xc7, 0xb2, 0x1a)).Returns("255.199.178.26");
            yield return new TestCaseData(new IPv4Address(0xff, 0x1f, 0x9c, 0x64)).Returns("255.31.156.100");
            yield return new TestCaseData(new IPv4Address(0xff, 0xe0, 0xde, 0xc7)).Returns("255.224.222.199");
            yield return new TestCaseData(new IPv4Address(0xff, 0x48, 0x1d, 0xc8)).Returns("255.72.29.200");
            yield return new TestCaseData(new IPv4Address(0xff, 0xf7, 0xb0, 0xfa)).Returns("255.247.176.250");
            yield return new TestCaseData(new IPv4Address(0xff, 0xff, 0xff, 0xff)).Returns("255.255.255.255");
        }

        public static System.Collections.IEnumerable GetTryParse1TestData()
        {
            yield return new TestCaseData("0.0.0.0").Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
        }

        public static System.Collections.IEnumerable GetTryParse2TestData()
        {
            yield return new TestCaseData("0.0.0.0", NumberStyles.Integer).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
        }

        public static System.Collections.IEnumerable GetTryParse3TestData()
        {
            yield return new TestCaseData("0.0.0.0", _formatProvider).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
        }

        public static System.Collections.IEnumerable GetTryParse4TestData()
        {
            yield return new TestCaseData("0.0.0.0", NumberStyles.Integer, _formatProvider).Returns(new IPv4Address(0x00, 0x00, 0x00, 0x00));
        }
    }
}