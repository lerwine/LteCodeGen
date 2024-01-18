using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Represents a <see cref="IBinaryNumber{TSelf}"/> value denominated by a <see cref="BinaryDenomination"/>.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
/// <typeparam name="TFloatingPoint">The denominated value type.</typeparam>
/// <typeparam name="TWholeValue">The actual numerical value.</typeparam>
public interface IBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue> : IFraction<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : IBinaryDenominatedNumber<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : IBinaryFloatingPointIeee754<TFloatingPoint>
    where TWholeValue : IBinaryNumber<TWholeValue>
{
    /// <summary>
    /// Gets the floating-point value.
    /// </summary>
    /// <value>The floating-point value denominated by <see cref="Denomination"/>.</value>
    TFloatingPoint Value { get; }

    /// <summary>
    /// Gets the raw value.
    /// </summary>
    /// <value>The value of <see cref="IBinaryDenominatedNumber{TSelf, TNumerator, TRaw}.Value"/> multiplied by the numerical value of <see cref="IBinaryDenominatedNumber{TSelf, TNumerator, TRaw}.Denomination"/></value>
    TWholeValue WholeValue { get; }

    /// <summary>
    /// Gets the denomination for this numerical value.
    /// </summary>
    /// <value>A <see cref="BinaryDenomination"/> value that reprents the denomination.</value>
    BinaryDenomination Denomination { get; }

    static abstract TSelf Normalize(TSelf value);
}
