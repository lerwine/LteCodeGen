using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface IMixedFraction<TSelf, TValue> : IFraction<TSelf, TValue>
    where TSelf : IMixedFraction<TSelf, TValue>?
    where TValue : IBinaryNumber<TValue>
{
    TValue WholeNumber { get; }

    /// <summary>
    /// Gets an inverted fraction value.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <param name="doNotReduce">If <see langword="true"/>, the return value will have the <see cref="Denominator"/> and <see cref="Numerator"/> inverted
    /// without being reduced to its simplest form; otherwise, the returned fraction will be reduced to its simplest form.</param>
    /// <param name="doNotMakeProper">If <see langword="true"/>, the return value will have the <see cref="Denominator"/> and <see cref="Numerator"/> inverted
    /// and may result in an improper fraction; otherwise, the returned fraction will be will be a proper fraction.</param>
    /// <returns>A fraction from the inverted <see cref="Numerator"/> and <see cref="Denominator"/> values.</returns>
    static abstract TSelf Invert(TSelf fraction, bool doNotReduce, bool doNotMakeProper);

    static abstract TSelf ToProperFraction(TSelf value);

    static abstract TSelf ToProperSimplestForm(TSelf value);
}

public interface IMixedFraction<TSelf, TValue, TFraction> : IFraction<TSelf, TValue, TSelf, TFraction>, IMixedFraction<TSelf, TValue>
    where TSelf : IMixedFraction<TSelf, TValue, TFraction>?
    where TValue : IBinaryNumber<TValue>
    where TFraction : ISimpleFraction<TFraction, TValue, TSelf>?
{
    TValue Split(out TFraction properFraction);
}
