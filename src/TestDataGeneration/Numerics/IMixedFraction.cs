using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Interface for a fraction with a whole number.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The value type for the <see cref="IFraction{TSelf, TValue}.Numerator"/>, <see cref="IFraction{TSelf, TValue}.Denominator"/>,
/// and <see cref="IMixedFraction{TSelf, TValue}.WholeNumber"/>.</typeparam>
public interface IMixedFraction<TSelf, TValue> : IFraction<TSelf, TValue>
    where TSelf : struct, IMixedFraction<TSelf, TValue>?
    where TValue : struct, IBinaryNumber<TValue>
{
    /// <summary>
    /// Gets the whole number.
    /// </summary>
    /// <returns>The whole nubmer associated with the fractional value.</returns>
    TValue WholeNumber { get; }

    /// <summary>
    /// Gets an inverted fraction value.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <param name="doNotReduce">If <see langword="true"/>, the return value will have the <see cref="IFraction{TSelf, TValue}.Denominator"/> and <see cref="IFraction{TSelf, TValue}.Numerator"/> inverted
    /// without being reduced to its simplest form; otherwise, the returned fraction will be reduced to its simplest form.</param>
    /// <param name="doNotMakeProper">If <see langword="true"/>, the return value will have the <see cref="IFraction{TSelf, TValue}.Denominator"/> and <see cref="IFraction{TSelf, TValue}.Numerator"/> inverted
    /// and may result in an improper fraction; otherwise, the returned fraction will be will be a proper fraction.</param>
    /// <returns>A fraction from the inverted <see cref="IFraction{TSelf, TValue}.Numerator"/> and <see cref="IFraction{TSelf, TValue}.Denominator"/> values.</returns>
    static abstract TSelf Invert(TSelf fraction, bool doNotReduce, bool doNotMakeProper);

    /// <summary>
    /// Gets a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction with the <see cref="IFraction{TSelf, TValue}.Numerator"/> being less than the <see cref="IFraction{TSelf, TValue}.Denominator"/>.</returns>
    static abstract TSelf ToProperFraction(TSelf value);

    /// <summary>
    /// Gets a proper fraction reduced to its simplest form.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction reduced to its simplest form, with the <see cref="IFraction{TSelf, TValue}.Numerator"/> is less than the <see cref="IFraction{TSelf, TValue}.Denominator"/>.</returns>
    static abstract TSelf ToProperSimplestForm(TSelf value);
}

/// <summary>
/// Interface for a fraction with a whole number.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The value type for the <see cref="IFraction{TSelf, TValue}.Numerator"/>, <see cref="IFraction{TSelf, TValue}.Denominator"/>,
/// and <see cref="IMixedFraction{TSelf, TValue}.WholeNumber"/>.</typeparam>
/// <typeparam name="TFraction">The <see cref="ISimpleFraction{TFraction, TValue, TSelf}"/> type with the same numerator and denominator type.</typeparam>
public interface IMixedFraction<TSelf, TValue, TFraction> : IFraction<TSelf, TValue, TSelf, TFraction>, IMixedFraction<TSelf, TValue>
    where TSelf : struct, IMixedFraction<TSelf, TValue, TFraction>?
    where TValue : struct, IBinaryNumber<TValue>
    where TFraction : struct, ISimpleFraction<TFraction, TValue, TSelf>?
{
    /// <summary>
    /// Gets a whole number and a simple fraction from a mixed fraction.
    /// </summary>
    /// <param name="properFraction">The proper, simple fraction.</param>
    /// <returns>The whole number from the mixed fraction.</returns>
    TValue Split(out TFraction properFraction);
}
