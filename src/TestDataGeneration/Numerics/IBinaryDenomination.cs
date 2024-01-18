using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue> : IFraction<TSelf, TFloatingPoint>
    where TSelf : IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : IBinaryNumber<TWholeValue>
{
    /// <summary>
    /// Gets the floating-point value.
    /// </summary>
    /// <value>The floating-point value denominated by <see cref="Denomination"/>.</value>
    TFloatingPoint Value { get; }

    /// <summary>
    /// Gets the denomination for this numerical value.
    /// </summary>
    /// <value>A <see cref="BinaryDenomination"/> value that reprents the denomination.</value>
    BinaryDenomination Denomination { get; }
}
