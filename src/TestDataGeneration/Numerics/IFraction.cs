using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Generic interface for fractional values.
/// </summary>
public interface IFraction : IFractionBase
{
    /// <summary>
    /// Gets the numerator value.
    /// </summary>
    /// <value>The numerator for the current fractional value.</value>
    IConvertible Numerator { get; }
    
    /// <summary>
    /// Gets the denominator value.
    /// </summary>
    /// <value>The denominator for the current fractional value.</value>
    IConvertible Denominator { get; }
    
    /// <summary>
    /// Gets the fractional value as a decimal value.
    /// </summary>
    /// <returns>A <see cref="decimal"/> value equivalent to the current fraction.</returns>
    decimal ToDecimal();

    /// <summary>
    /// Gets the fractional value as a double-precision floating-point value.
    /// </summary>
    /// <returns>A <see cref="double"/> value equivalent to the current fraction.</returns>
    double ToDouble();

    /// <summary>
    /// Gets the fractional value as a single-precision floating-point value.
    /// </summary>
    /// <returns>A <see cref="float"/> value equivalent to the current fraction.</returns>
    float ToSingle();
}

/// <summary>
/// Base interface for fractional values.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
public interface IFraction<TSelf> : IFraction, IBinaryNumber<TSelf>, IHyperbolicFunctions<TSelf>
    where TSelf : IFraction<TSelf>?
{
    /// <summary>
    /// Checks whether a fraction value is already normalized.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="IFraction.Denominator"/> and <see cref="IFraction.Numerator"/> are already normalized; otherwise, <see langword="false"/>.</returns>
    static abstract bool IsNormalized(BinaryDenominatedInt64 value);
}

/// <summary>
/// Interface for a strongly-typed fractional value.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
/// <typeparam name="TFractional">The type of value for the <see cref="IFraction{TSelf, TFractional, TWholeNumber}.Numerator"/> and <see cref="IFraction{TSelf, TFractional, TWholeNumber}.Numerator"/>.</typeparam>
/// <typeparam name="TWholeNumber">The whole number type to use with fraction operations.</typeparam>
public interface IFraction<TSelf, TFractional, TWholeNumber> : IFraction<TSelf>, IMinMaxValue<TSelf>
    where TSelf : IFraction<TSelf, TFractional, TWholeNumber>?
    where TFractional : IBinaryNumber<TFractional>
    where TWholeNumber : IBinaryNumber<TWholeNumber>
{
    /// <summary>
    /// Gets the numerator value.
    /// </summary>
    /// <value>The numerator for the current fractional value.</value>
    new TFractional Numerator { get; }
    
    /// <summary>
    /// Gets the denominator value.
    /// </summary>
    /// <value>The denominator for the current fractional value.</value>
    new TFractional Denominator { get; }

    /// <summary>
    /// Gets an inverted fraction value from the current fractional value and a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to invert and add to the resulting fractional value.</param>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <returns>A fraction normalized from inverted <paramref name="wholeNumber"/>, <see cref="Denominator"/>, and <see cref="Numerator"/> values.</returns>
    static abstract TSelf Invert(TWholeNumber wholeNumber, TSelf fraction);
    
    /// <summary>
    /// Gets an inverted fraction value.
    /// </summary>
    /// <param name="wholeNumber">The whole number to invert and add to the resulting fractional value.</param>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <param name="doNotNormalize">If <see langword="true"/>, the return value will have the <see cref="Denominator"/> and <see cref="Numerator"/> inverted
    /// without normalization; otherwise, the returned fraction will be normalized.</param>
    /// <returns>A fraction from inverted <paramref name="wholeNumber"/>, <see cref="Numerator"/>, and <see cref="Denominator"/> values.</returns>
    static abstract TSelf Invert(TWholeNumber wholeNumber, TSelf fraction, bool doNotNormalize);

    /// <summary>
    /// Gets an inverted fraction value from the current fractional value and a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to invert and add to the resulting fractional value.</param>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <param name="fromInverted">The whole number resulting from the normalized fraction inversion.</param>
    /// <returns>A fraction normalized from inverted <paramref name="wholeNumber"/>, <see cref="Denominator"/>, and <see cref="Numerator"/> values.</returns>
    static abstract TSelf Invert(TWholeNumber wholeNumber, TSelf fraction, out TWholeNumber fromInverted);

    /// <summary>
    /// Gets a normalize fraction and whole number.
    /// </summary>
    /// <param name="fraction">The fractional value to normalize.</param>
    /// <param name="wholeNumber">The whole number value.</param>
    /// <returns>A normalized fractional value, where the <see cref="IFraction{TSelf, TFractional, TWholeNumber}.Numerator"/> is less than the denominator.</returns>
    static abstract TSelf Normalize(TSelf fraction, out TWholeNumber wholeNumber);
}
