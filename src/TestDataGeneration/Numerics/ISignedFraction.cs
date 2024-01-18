using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Base interface for signed fractional values.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
public interface ISignedFraction<TSelf> : IFraction<TSelf>, ISignedNumber<TSelf> where TSelf : ISignedFraction<TSelf>? { }

/// <summary>
/// Interface for a signed, strongly-typed fractional value.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
/// <typeparam name="TFractional">The type of signed value for the <see cref="IFraction{TSelf, TFractional, TWholeNumber}.Numerator"/> and <see cref="IFraction{TSelf, TFractional, TWholeNumber}.Numerator"/>.</typeparam>
/// <typeparam name="TWholeNumber">The whole number type to use with fraction operations.</typeparam>
public interface ISignedFraction<TSelf, TFractional, TWholeNumber> : IFraction<TSelf, TFractional, TWholeNumber>, ISignedFraction<TSelf>
    where TSelf : ISignedFraction<TSelf, TFractional, TWholeNumber>?
    where TFractional : IBinaryNumber<TFractional>, ISignedNumber<TFractional>
    where TWholeNumber : IBinaryNumber<TWholeNumber> { }
