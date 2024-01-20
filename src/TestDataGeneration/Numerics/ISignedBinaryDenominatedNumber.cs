using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Represents a value that implements <see cref="IBinaryNumber{TSelf}"/> and <see cref="ISignedNumber{TSelf}"/>,
/// which is denominated by a <see cref="BinaryDenomination"/>.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
/// <typeparam name="TFloatingPoint">The denominated value type.</typeparam>
/// <typeparam name="TWholeValue">The actual numerical value.</typeparam>
/// <typeparam name="TResult">The denominated value without the original whole value.</typeparam>
public interface ISignedBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue> : IMixedSignedFraction<TSelf, TFloatingPoint>,
        ISignedBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>,
        IBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : struct, ISignedBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : struct, IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : struct, IBinaryNumber<TWholeValue>, ISignedNumber<TWholeValue>
{ }
