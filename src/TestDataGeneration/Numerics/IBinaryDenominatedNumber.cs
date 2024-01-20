using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Represents a <see cref="IBinaryNumber{TSelf}"/> value denominated by a <see cref="BinaryDenomination"/>.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
/// <typeparam name="TFloatingPoint">The denominated value type.</typeparam>
/// <typeparam name="TWholeValue">The actual numerical value.</typeparam>
public interface IBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue> : IMixedFraction<TSelf, TFloatingPoint>,
        IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : struct, IBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : struct, IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : struct, IBinaryNumber<TWholeValue>
{
    /// <summary>
    /// Gets the raw value.
    /// </summary>
    /// <value>The value of <see cref="IBinaryDenominatedNumber{TSelf, TNumerator, TRaw}.Value"/> multiplied by the numerical value of <see cref="IBinaryDenominatedNumber{TSelf, TNumerator, TRaw}.Denomination"/></value>
    TWholeValue WholeValue { get; }
}
