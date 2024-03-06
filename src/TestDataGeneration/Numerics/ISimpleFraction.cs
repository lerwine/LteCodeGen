using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Base interface for values representing simple fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations.</typeparam>
public interface ISimpleFraction<TSelf, TValue> : IFraction<TSelf, TValue>
    where TSelf : struct, ISimpleFraction<TSelf, TValue>?
    where TValue : struct, IBinaryNumber<TValue>
{
    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="wholeNumber1">The first whole number.</param>
    /// <param name="fraction1">The first fraction.</param>
    /// <param name="wholeNumber2">The second whole number.</param>
    /// <param name="fraction2">The second fraction.</param>
    /// <param name="sum">Returns the whole number part of the sum of the added mixed fractions.</param>
    /// <returns>The proper fractional part the sum of the added mixed fractions, reduced to its simplest form.</returns>
    static abstract TSelf Add(TValue wholeNumber1, TSelf fraction1, TValue wholeNumber2, TSelf fraction2, out TValue sum);

    /// <summary>
    /// Subtracts individual mixed fraction components.
    /// </summary>
    /// <param name="wholeMinuend">The whole number to be subtracted from.</param>
    /// <param name="minuendFraction">The fractional value to be subtracted from.</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <param name="difference">Returns the whole number part of the difference.</param>
    /// <returns>The proper fractional part of the difference, reduced to its simplest form.</returns>
    static abstract TSelf Subtract(TValue wholeMinuend, TSelf minuendFraction, TValue wholeSubtrahend, TSelf subtrahendFraction, out TValue difference);

    /// <summary>
    /// Multiplies individual mixed fraction components.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to multiply.</param>
    /// <param name="multiplierFraction">The fractional value to multiply.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <param name="product">Returns the whole number part of the product.</param>
    /// <returns>The proper fractional part of the product, reduced to its simplest form.</returns>
    static abstract TSelf Multiply(TValue wholeMultiplier, TSelf multiplierFraction, TValue wholeMultiplicand, TSelf multiplicandFraction, out TValue product);

    /// <summary>
    /// Divides individual mixed fraction components.
    /// </summary>
    /// <param name="wholeDividend">The whole number to be divided.</param>
    /// <param name="dividendFraction">The fractional value to be divided.</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <param name="quotient">Returns the whole number part of the divided value.</param>
    /// <returns>The proper fractional part of the divided value, reduced to its simplest form.</returns>
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
/// Base interface for values representing simple fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations.</typeparam>
/// <typeparam name="TMixed">The <see cref="IMixedFraction{TSelf, TValue, TFraction}"/> type that shares the same value type.</typeparam>
public interface ISimpleFraction<TSelf, TValue, TMixed> : IFraction<TSelf, TValue, TMixed, TSelf>, ISimpleFraction<TSelf, TValue>
    where TSelf : struct, ISimpleFraction<TSelf, TValue, TMixed>?
    where TValue : struct, IBinaryNumber<TValue>
    where TMixed : struct, IMixedFraction<TMixed, TValue, TSelf>?
{
    /// <summary>
    /// Adds mixed fraction components to the current fraction.
    /// </summary>
    /// <param name="wholeNumber1">The whole number to join to the current fraction.</param>
    /// <param name="wholeNumber2">The second whole number to add.</param>
    /// <param name="fraction2">The fractional value to add.</param>
    /// <returns>The proper mixed fraction reprsenting the sum, reduced to its simplest form.</returns>
    TMixed Add(TValue wholeNumber1, TValue wholeNumber2, TSelf fraction2);

    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="fraction1">The first mixed fraction.</param>
    /// <param name="wholeNumber2">The second whole number.</param>
    /// <param name="fraction2">The second fraction.</param>
    /// <param name="sum">Returns the whole number part of the sum of the added mixed fractions.</param>
    /// <returns>The proper fractional part the sum, reduced to its simplest form.</returns>
    static abstract TSelf Add(TMixed fraction1, TValue wholeNumber2, TSelf fraction2, out TValue sum);

    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="wholeNumber1">The first whole number.</param>
    /// <param name="fraction1">The first fraction.</param>
    /// <param name="fraction2">The second mixed fraction.</param>
    /// <param name="sum">Returns the whole number part of the sum of the added mixed fractions.</param>
    /// <returns>The proper fractional part the sum, reduced to its simplest form.</returns>
    static abstract TSelf Add(TValue wholeNumber1, TSelf fraction1, TMixed fraction2, out TValue sum);

    /// <summary>
    /// Creates a mixed fraction.
    /// </summary>
    /// <param name="wholeNumber">The whole number to join to the current fraction.</param>
    /// <returns>A proper, mixed fraction of the current fraction combined with the specified <paramref name="wholeNumber"/>.</returns>
    TMixed Join(TValue wholeNumber);

    /// <summary>
    /// Subtracts mixed fraction components from a whole number.
    /// </summary>
    /// <param name="wholeMinuend">The whole number to be subtracted from.</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <returns>A proper, mixed fraction representing the difference, reduced to its simplest form.</returns>
    TMixed Subtract(TValue wholeMinuend, TValue wholeSubtrahend, TSelf subtrahendFraction);

    /// <summary>
    /// Subtracts mixed fraction components from a mixed fraction.
    /// </summary>
    /// <param name="minuend">The mixed fraction to be subtracted from</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <param name="difference">Returns the whole number part of the difference.</param>
    /// <returns>The proper fractional part of the difference, reduced to its simplest form.</returns>
    static abstract TSelf Subtract(TMixed minuend, TValue wholeSubtrahend, TSelf subtrahendFraction, out TValue difference);

    /// <summary>
    /// Subtracts a mixed fraction from mixed fraction components.
    /// </summary>
    /// <param name="wholeMinuend">The whole number to be subtracted from.</param>
    /// <param name="minuendFraction">The fractional value to be subtracted from.</param>
    /// <param name="subtrahend">The mixed fraction to subtract.</param>
    /// <param name="difference">Returns the whole number part of the difference.</param>
    /// <returns>The proper fractional part of the difference, reduced to its simplest form.</returns>
    static abstract TSelf Subtract(TValue wholeMinuend, TSelf minuendFraction, TMixed subtrahend, out TValue difference);

    /// <summary>
    /// Multiplies the current fraction by mixed fraction components.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to be multiplied along with the current fraction.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <returns>A proper, mixed fraction representing the product, reduced to its simplest form.</returns>
    TMixed Multiply(TValue wholeMultiplier, TValue wholeMultiplicand, TSelf multiplicandFraction);

    /// <summary>
    /// Multiplies a mixed fraction by mixed fraction components.
    /// </summary>
    /// <param name="multiplier">The mixed fraction to be multiplied.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <param name="product">Returns the whole number part of the product.</param>
    /// <returns>The proper fractional part of the product, reduced to its simplest form.</returns>
    static abstract TSelf Multiply(TMixed multiplier, TValue wholeMultiplicand, TSelf multiplicandFraction, out TValue product);

    /// <summary>
    /// Multiplies mixed fraction components by a mixed fraction.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to multiply.</param>
    /// <param name="multiplierFraction">The fractional value to multiply.</param>
    /// <param name="multiplicand">The mixed fraction to multiply by.</param>
    /// <param name="product">Returns the whole number part of the product.</param>
    /// <returns>The proper fractional part of the product, reduced to its simplest form.</returns>
    static abstract TSelf Multiply(TValue wholeMultiplier, TSelf multiplierFraction, TMixed multiplicand, out TValue product);

    /// <summary>
    /// Divides the current fraction by mixed fraction components.
    /// </summary>
    /// <param name="wholeDividend">The whole number to be divided along with the current fraction.</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <returns>A proper, mixed fraction representing the quotient, reduced to its simplest form.</returns>
    TMixed Divide(TValue wholeDividend, TValue wholeDivisor, TSelf divisorFraction);

    /// <summary>
    /// Divides a mixed fraction by mixed fraction components.
    /// </summary>
    /// <param name="dividend">The mixed fraction to be divided</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <param name="quotient">Returns the whole number part of the divided value.</param>
    /// <returns>The proper fractional part of the divided value, reduced to its simplest form.</returns>
    static abstract TSelf Divide(TMixed dividend, TValue wholeDivisor, TSelf divisorFraction, out TValue quotient);

    /// <summary>
    /// Divides mixed fractino components by a mixed fraction.
    /// </summary>
    /// <param name="wholeDividend">The whole number component of the value to be divided.</param>
    /// <param name="dividendFraction">The fractional component of the value to be divided.</param>
    /// <param name="divisor">The mixed fraction to divide by.</param>
    /// <param name="quotient">Returns the whole number part of the divided value.</param>
    /// <returns>The proper fractional part of the divided value, reduced to its simplest form.</returns>
    static abstract TSelf Divide(TValue wholeDividend, TSelf dividendFraction, TMixed divisor, out TValue quotient);

    /// <summary>
    /// Converts a fraction to a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction with the <see cref="IFraction{TSelf, TValue}.Numerator"/> being less than the <see cref="IFraction{TSelf, TValue}.Denominator"/>.</returns>
    static abstract TMixed ToProperFraction(TSelf value);

    /// <summary>
    /// Gets a proper fraction reduced to its simplest form.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction reduced to its simplest form, with the <see cref="IFraction{TSelf, TValue}.Numerator"/> is less than the <see cref="IFraction{TSelf, TValue}.Denominator"/>.</returns>
    static abstract TMixed ToProperSimplestForm(TSelf value);
}
