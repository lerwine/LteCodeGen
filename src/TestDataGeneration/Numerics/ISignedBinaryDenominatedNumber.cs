using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Represents a value that implements <see cref="IBinaryNumber{TSelf}"/> and <see cref="ISignedNumber{TSelf}"/>,
/// which is denominated by a <see cref="BinaryDenomination"/>.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
/// <typeparam name="TFloatingPoint">The denominated value type.</typeparam>
/// <typeparam name="TWholeValue">The actual numerical value.</typeparam>
public interface ISignedBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue> : IBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue>, ISignedFraction<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : ISignedBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : IBinaryFloatingPointIeee754<TFloatingPoint>
    where TWholeValue : IBinaryNumber<TWholeValue>, ISignedNumber<TWholeValue> { }
