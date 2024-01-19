using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Interface for a simple fraction
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations</typeparam>
public interface ISimpleFraction<TSelf, TValue> : IFraction<TSelf, TValue>
    where TSelf : ISimpleFraction<TSelf, TValue>?
    where TValue : IBinaryNumber<TValue>
{
    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="wholeNumber1">The first whole number.</param>
    /// <param name="fraction1">The first fraction.</param>
    /// <param name="wholeNumber2">The second whole number.</param>
    /// <param name="fraction2">The second fraction</param>
    /// <param name="sum">Returns fractional part the sum of the added mixed fractions.</param>
    /// <returns>The whole number part of the sum of the added mixed fractions.</returns>
    static abstract TSelf Add(TValue wholeNumber1, TSelf fraction1, TValue wholeNumber2, TSelf fraction2, out TValue sum);

    /// <summary>
    /// Sutracts individual mixed fraction components.
    /// </summary>
    /// <param name="wholeMinuend">The whole number to be subtracted from.</param>
    /// <param name="minuendFraction">The fractional value to be subtracted from.</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <param name="difference">Returns the fractional part of the difference.</param>
    /// <returns>The whole number part of the difference.</returns>
    static abstract TSelf Subtract(TValue wholeMinuend, TSelf minuendFraction, TValue wholeSubtrahend, TSelf subtrahendFraction, out TValue difference);

    /// <summary>
    /// Multiplies individual mixed fraction components.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to multiply.</param>
    /// <param name="multiplierFraction">The fractional value to multiply.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <param name="product">The fractional part of the product.</param>
    /// <returns>The whole number part of the product.</returns>
    static abstract TSelf Multiply(TValue wholeMultiplier, TSelf multiplierFraction, TValue wholeMultiplicand, TSelf multiplicandFraction, out TValue product);

    /// <summary>
    /// Divides individual mixed fraction components.
    /// </summary>
    /// <param name="wholeDividend">The whole number to be divided.</param>
    /// <param name="dividendFraction">The fractional value to be divided.</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <param name="quotient">The fractional part of the divided value.</param>
    /// <returns>The whole number part of the divided value.</returns>
    static abstract TSelf Divide(TValue wholeDividend, TSelf dividendFraction, TValue wholeDivisor, TSelf divisorFraction, out TValue quotient);

    /// <summary>
    /// Converts a fraction to a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to normalize.</param>
    /// <param name="wholeNumber">Returns the whole number derived from an improper fraction, which may be zero if the fraction was already a proper fraction.</param>
    /// <returns>A proper fraction where the <see cref="IFraction{TSelf, TValue}.Numerator"/> is less than the <see cref="IFraction{TSelf, TValue}.Denominator"/>.</returns>
    static abstract TSelf ToProperFraction(TSelf value, out TValue wholeNumber);

    /// <summary>
    /// Converts a fraction to proper form, also reducing it to its simplest terms.
    /// </summary>
    /// <param name="value">The fraction to normalize.</param>
    /// <param name="wholeNumber">Returns the whole number derived from an improper fraction, which may be zero if the fraction was already a proper fraction.</param>
    /// <returns>A proper fraction where the <see cref="IFraction{TSelf, TValue}.Numerator"/> is less than the <see cref="IFraction{TSelf, TValue}.Denominator"/>, which also has been reduced to its simplest terms.</returns>
    static abstract TSelf ToProperSimplestForm(TSelf value, out TValue wholeNumber);
}

/// <summary>
/// Interface for a simple fraction
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations.</typeparam>
/// <typeparam name="TMixed">The <see cref="IMixedFraction{TSelf, TValue, TFraction}"/> type that shares the same value type.</typeparam>
public interface ISimpleFraction<TSelf, TValue, TMixed> : IFraction<TSelf, TValue, TMixed, TSelf>, ISimpleFraction<TSelf, TValue>
    where TSelf : ISimpleFraction<TSelf, TValue, TMixed>?
    where TValue : IBinaryNumber<TValue>
    where TMixed : IMixedFraction<TMixed, TValue, TSelf>?
{
    TMixed Add(TValue wholeNumber1, TValue wholeNumber2, TSelf fraction2);

    static abstract TSelf Add(TMixed fraction1, TValue wholeNumber2, TSelf fraction2, out TValue sum);

    static abstract TSelf Add(TValue wholeNumber1, TSelf fraction1, TMixed fraction2, out TValue sum);

    TMixed Join(TValue wholeNumber);

    TMixed Subtract(TValue wholeMinuend, TValue wholeSubtrahend, TSelf subtrahendFraction);

    static abstract TSelf Subtract(TMixed minuend, TValue wholeSubtrahend, TSelf subtrahendFraction, out TValue difference);

    static abstract TSelf Subtract(TValue wholeMinuend, TSelf minuendFraction, TMixed subtrahend, out TValue difference);

    TMixed Multiply(TValue wholeMultiplier, TValue wholeMultiplicand, TSelf multiplicandFraction);

    static abstract TSelf Multiply(TMixed multiplier, TValue wholeMultiplicand, TSelf multiplicandFraction, out TValue product);

    static abstract TSelf Multiply(TValue wholeMultiplier, TSelf multiplierFraction, TMixed multiplicand, out TValue product);

    TMixed Divide(TValue wholeDividend, TValue wholeDivisor, TSelf divisorFraction);

    static abstract TSelf Divide(TMixed dividend, TValue wholeDivisor, TSelf divisorFraction, out TValue quotient);

    static abstract TSelf Divide(TValue wholeDividend, TSelf dividendFraction, TMixed divisor, out TValue quotient);

    static abstract TMixed ToProperFraction(TSelf value);

    static abstract TMixed ToProperSimplestForm(TSelf value);
}
