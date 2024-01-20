using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Byte size representation in kilobytes, megabytes, etc.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TFloatingPoint">The denominated value type.</typeparam>
/// <typeparam name="TWholeValue">The original byte size value type.</typeparam>
public interface IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue> : IFraction<TSelf, TFloatingPoint>
    where TSelf : struct, IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : struct, IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : struct, IBinaryNumber<TWholeValue>
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
