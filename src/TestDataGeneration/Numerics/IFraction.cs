using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Base interface for values representing fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations</typeparam>
public interface IFraction<TSelf, TValue> : IConvertible, IBinaryNumber<TSelf>, IMinMaxValue<TSelf>
    where TSelf : IFraction<TSelf, TValue>?
    where TValue : IBinaryNumber<TValue>
{
    /// <summary>
    /// Gets the numerator value.
    /// </summary>
    /// <value>The numerator for the current fractional value.</value>
    TValue Numerator { get; }

    /// <summary>
    /// Gets the denominator value.
    /// </summary>
    /// <value>The denominator for the current fractional value.</value>
    TValue Denominator { get; }

    /// <summary>
    /// Adds a fractional value to the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to add.</param>
    /// <returns>A sum of the two fractions.</returns>
    TSelf Add(TSelf fraction);

    /// <summary>
    /// Subtracts a fractional value from the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to subtract.</param>
    /// <returns>The difference of the two fractions.</returns>
    TSelf Subtract(TSelf fraction);

    /// <summary>
    /// Multiplies the current fraction with a fractional value.
    /// </summary>
    /// <param name="fraction">The multiplicand.</param>
    /// <returns>The product of the multiplication.</returns>
    TSelf Multiply(TSelf fraction);

    /// <summary>
    /// Divides the current fraction by a fractional value.
    /// </summary>
    /// <param name="fraction">The divisor.</param>
    /// <returns>The quotient of the division.</returns>
    TSelf Divide(TSelf fraction);

    /// <summary>
    /// Gets an inverted fraction value from the current fractional value and a whole number.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <returns>A fraction normalized from inverted <see cref="Denominator"/> and <see cref="Numerator"/> values.</returns>
    static abstract TSelf Invert(TSelf fraction);

    /// <summary>
    /// Gets an inverted fraction value.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <param name="doNotReduce">If <see langword="true"/>, the return value will have the <see cref="Denominator"/> and <see cref="Numerator"/> inverted
    /// without being reduced to its simplest form; otherwise, the returned fraction will be reduced to its simplest form.</param>
    /// <returns>A fraction from the inverted <see cref="Numerator"/> and <see cref="Denominator"/> values.</returns>
    static abstract TSelf Invert(TSelf fraction, bool doNotReduce);

    /// <summary>
    /// Indicates whether a value is a proper fraction.
    /// </summary>
    /// <param name="value">The fractional value to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> is less than the <see cref="Denominator"/>;
    /// otherwise, <see langword="false"/>.</returns>
    static abstract bool IsProperFraction(TSelf value);

    /// <summary>
    /// Checks whether the value is a proper fraction that is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values
    /// and the <see cref="Numerator"/> is less than the <see cref="Denominator"/>; otherwise, <see langword="false"/>.</returns>
    static abstract bool IsProperSimplestForm(TSelf value);

    /// <summary>
    /// Checks whether a fraction is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values;
    /// otherwise, <see langword="false"/>.</returns>
    static abstract bool IsSimplestForm(TSelf value);

    /// <summary>
    /// Gets a fraction reduced to its simplest form.
    /// </summary>
    /// <param name="fraction">The fractional value to reduce.</param>
    /// <returns>A fraction where the <see cref="Numerator"/> and <see cref="Numerator"/> are reduced to their simplest values.</returns>
    static abstract TSelf ToSimplestForm(TSelf fraction);
}

/// <summary>
/// Base interface for values representing fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations</typeparam>
/// <typeparam name="TMixed">The <see cref="IMixedFraction{TSelf, TFractional, TFraction}"/> type that shares the same value type.</typeparam>
/// <typeparam name="TFraction">The <see cref="ISimpleFraction{TSelf, TValue, TMixed}"/> type that shares the same value type.</typeparam>
public interface IFraction<TSelf, TValue, TMixed, TFraction> : IFraction<TSelf, TValue>
    where TSelf : IFraction<TSelf, TValue, TMixed, TFraction>?
    where TValue : IBinaryNumber<TValue>
    where TMixed : IMixedFraction<TMixed, TValue, TFraction>?
    where TFraction : ISimpleFraction<TFraction, TValue, TMixed>?
{
    /// <summary>
    /// Adds a fraction to a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to add to.</param>
    /// <param name="fraction">The fractional value to be added.</param>
    /// <returns>The sum as a mixed fraction.</returns>
    static abstract TMixed Add(TValue wholeNumber, TFraction fraction);

    /// <summary>
    /// Subtracts a fraction from a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to subtract from.</param>
    /// <param name="fraction">The fractional value to subtract.</param>
    /// <returns>The difference as a mixed fraction.</returns>
    static abstract TMixed Subtract(TValue wholeNumber, TFraction fraction);

    /// <summary>
    /// Multiplies a whole nubmer by a fraction.
    /// </summary>
    /// <param name="wholeNumber">The whole number to be multiplied.</param>
    /// <param name="fraction">The fractional value to multiply by.</param>
    /// <returns>The product as a mixed fraction.</returns>
    static abstract TMixed Multiply(TValue wholeNumber, TFraction fraction);

    /// <summary>
    /// Divides a whole number by a fractional value.
    /// </summary>
    /// <param name="wholeNumber">The whole number to divide.</param>
    /// <param name="fraction">The fractional value to divide by.</param>
    /// <returns>The quotient as a mixed fraction.</returns>
    static abstract TMixed Divide(TValue wholeNumber, TFraction fraction);
}
