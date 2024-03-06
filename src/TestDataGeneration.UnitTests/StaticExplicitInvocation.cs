using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace TestDataGeneration.UnitTests;

public static class StaticExplicitInvocation
{
    internal static T GetOne<T>() where T : INumberBase<T> => T.One;

    internal static int GetRadix<T>() where T : INumberBase<T> => T.Radix;

    internal static T GetZero<T>() where T : INumberBase<T> => T.Zero;

    internal static T GetAdditiveIdentity<T>() where T : IAdditiveIdentity<T, T> => T.AdditiveIdentity;

    internal static T GetMultiplicativeIdentity<T>() where T : IMultiplicativeIdentity<T, T> => T.MultiplicativeIdentity;

    internal static T GetAbs<T>(T value) where T : INumberBase<T> => T.Abs(value);

    internal static bool GetIsCanonical<T>(T value) where T : INumberBase<T> => T.IsCanonical(value);

    internal static bool GetIsComplexNumber<T>(T value) where T : INumberBase<T> => T.IsComplexNumber(value);

    internal static bool GetIsEvenInteger<T>(T value) where T : INumberBase<T> => T.IsEvenInteger(value);

    internal static bool GetIsFinite<T>(T value) where T : INumberBase<T> => T.IsFinite(value);

    internal static bool GetIsImaginaryNumber<T>(T value) where T : INumberBase<T> => T.IsImaginaryNumber(value);

    internal static bool GetIsInfinity<T>(T value) where T : INumberBase<T> => T.IsInfinity(value);

    internal static bool GetIsInteger<T>(T value) where T : INumberBase<T> => T.IsInteger(value);

    internal static bool GetIsNaN<T>(T value) where T : INumberBase<T> => T.IsNaN(value);

    internal static bool GetIsNegative<T>(T value) where T : INumberBase<T> => T.IsNegative(value);

    internal static bool GetIsNegativeInfinity<T>(T value) where T : INumberBase<T> => T.IsNegativeInfinity(value);

    internal static bool GetIsNormal<T>(T value) where T : INumberBase<T> => T.IsNormal(value);

    internal static bool GetIsOddInteger<T>(T value) where T : INumberBase<T> => T.IsOddInteger(value);

    internal static bool GetIsPositive<T>(T value) where T : INumberBase<T> => T.IsPositive(value);

    internal static bool GetIsPositiveInfinity<T>(T value) where T : INumberBase<T> => T.IsPositiveInfinity(value);

    internal static bool GetIsPow2<T>(T value) where T : IBinaryNumber<T> => T.IsPow2(value);

    internal static bool GetIsRealNumber<T>(T value) where T : INumberBase<T> => T.IsRealNumber(value);

    internal static bool GetIsSubnormal<T>(T value) where T : INumberBase<T> => T.IsSubnormal(value);

    internal static bool GetIsZero<T>(T value) where T : INumberBase<T> => T.IsZero(value);

    internal static T GetLog2<T>(T value) where T : IBinaryNumber<T> => T.Log2(value);

    internal static T GetMaxMagnitude<T>(T x, T y) where T : IBinaryNumber<T> => T.MaxMagnitude(x, y);

    internal static T GetMaxMagnitudeNumber<T>(T x, T y) where T : IBinaryNumber<T> => T.MaxMagnitudeNumber(x, y);

    internal static T GetMinMagnitude<T>(T x, T y) where T : IBinaryNumber<T> => T.MinMagnitude(x, y);

    internal static T GetMinMagnitudeNumber<T>(T x, T y) where T : IBinaryNumber<T> => T.MinMagnitudeNumber(x, y);

    internal static T GetPopCount<T>(T value) where T : IBinaryInteger<T> => T.PopCount(value);

    internal static T GetTrailingZeroCount<T>(T value) where T : IBinaryInteger<T> => T.TrailingZeroCount(value);

    internal static bool GetTryReadBigEndian<T>(ReadOnlySpan<byte> source, bool isUnsigned, out T value) where T : IBinaryInteger<T> => T.TryReadBigEndian(source, isUnsigned, out value);

    internal static bool GetTryReadLittleEndian<T>(ReadOnlySpan<byte> source, bool isUnsigned, out T value) where T : IBinaryInteger<T> => T.TryReadLittleEndian(source, isUnsigned, out value);
}