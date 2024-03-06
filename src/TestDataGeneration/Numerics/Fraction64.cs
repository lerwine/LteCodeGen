using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

/// <summary>
/// 64-bit signed, simple fractional value comprised of 32-bit numerator and denominator values.
/// </summary>
public readonly struct Fraction64 : ISimpleSignedFraction<Fraction64, int, MixedFraction96>
{
    #region Static Properties

    /// <summary>
    /// Gets the fraction representing the value of negative one.
    /// </summary>
    /// <returns>The fraction representing a value of negative one.</returns>
    public static Fraction64 NegativeOne { get; } = new(-1, 1);

    /// <summary>
    /// Gets the fraction representing the value of one.
    /// </summary>
    /// <returns>The fraction representing a value of one.</returns>
    public static Fraction64 One { get; } = new(1, 1);

    /// <summary>
    /// Gets the zero fraction value.
    /// </summary>
    /// <returns>The fraction representing a zero value.</returns>
    public static Fraction64 Zero { get; } = new(0, 1);

    /// <summary>
    /// Gets the maximum fraction value.
    /// </summary>
    /// <returns>The maximum value.</returns>
    public static Fraction64 MaxValue { get; } = new(int.MaxValue, 1);

    /// <summary>
    /// Gets the minimum fraction value.
    /// </summary>
    /// <returns>The minimum value.</returns>
    public static Fraction64 MinValue { get; } = new(int.MinValue, 1);

    /// <summary>
    /// Gets a fraction value that is not a number (NaN).
    /// </summary>
    /// <returns>A fraction value that is not a number (NaN).</returns>
    public static Fraction64 NaN { get; } = new();

    #endregion

    #region Instance Properties

    /// <summary>
    /// Gets the numerator value.
    /// </summary>
    /// <value>The numerator for the current fractional value.</value>
    public int Numerator { get; }

    /// <summary>
    /// Gets the denominator value.
    /// </summary>
    /// <value>The denominator for the current fractional value.</value>
    public int Denominator { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a <c>Fraction64</c> fraction value.
    /// </summary>
    /// <param name="numerator">The numerator value.</param>
    /// <param name="denominator">The denominator value.</param>
    /// <param name="doNotReduce">If true, the fraction value will not be reduced to its simplest terms.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is less than <c>1</c>.</exception>
    public Fraction64(int numerator, int denominator, bool doNotReduce = false)
    {
        if (doNotReduce)
        {
            if (denominator == 0) throw new DivideByZeroException();
        }
        else
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        Numerator = numerator;
        Denominator = denominator;
    }

    #endregion

    #region Instance Methods

    /// <summary>
    /// Adds mixed fraction components to the current fraction.
    /// </summary>
    /// <param name="wholeNumber1">The whole number to join to the current fraction.</param>
    /// <param name="wholeNumber2">The second whole number to add.</param>
    /// <param name="fraction2">The fractional value to add.</param>
    /// <returns>The proper mixed fraction reprsenting the sum, reduced to its simplest form.</returns>
    public MixedFraction96 Add(int wholeNumber1, int wholeNumber2, Fraction64 fraction2)
    {
        (int wholeNumber, int numerator, int denominator) = AddFractions(wholeNumber1, this, wholeNumber2, fraction2);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Adds a fractional value to the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to add.</param>
    /// <returns>A proper fraction representing sum of the two fractions, reduced to its simplest form.</returns>
    public Fraction64 Add(Fraction64 fraction)
    {
        (int numerator, int denominator) = AddSimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    public int CompareTo(Fraction64 other) => CompareFractionComponents(Numerator, Denominator, other.Numerator, other.Denominator);

    /// <summary>
    /// Divides the current fraction by mixed fraction components.
    /// </summary>
    /// <param name="wholeDividend">The whole number to be divided along with the current fraction.</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <returns>A proper, mixed fraction representing the quotient, reduced to its simplest form.</returns>
    public MixedFraction96 Divide(int wholeDividend, int wholeDivisor, Fraction64 divisorFraction)
    {
        (int wholeNumber, int numerator, int denominator) = DivideFractions(wholeDividend, this, wholeDivisor, divisorFraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Divides the current fraction by a fractional value.
    /// </summary>
    /// <param name="fraction">The divisor.</param>
    public Fraction64 Divide(Fraction64 fraction)
    {
        (int numerator, int denominator) = DivideSimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    public bool Equals(Fraction64 other) => AreSimpleFractionsEqual<Fraction64, int>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Fraction64 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    /// <summary>
    /// Creates a mixed fraction.
    /// </summary>
    /// <param name="wholeNumber">The whole number to join to the current fraction.</param>
    /// <returns>A proper, mixed fraction of the current fraction combined with the specified <paramref name="wholeNumber"/>.</returns>
    public MixedFraction96 Join(int wholeNumber) => new(wholeNumber, Numerator, Denominator);

    /// <summary>
    /// Multiplies the current fraction by mixed fraction components.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to be multiplied along with the current fraction.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <returns>A proper, mixed fraction representing the product, reduced to its simplest form.</returns>
    public MixedFraction96 Multiply(int wholeMultiplier, int wholeMultiplicand, Fraction64 multiplicandFraction)
    {
        (int wholeNumber, int numerator, int denominator) = MultiplyFractions(wholeMultiplier, this, wholeMultiplicand, multiplicandFraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Multiplies the current fraction with a fractional value.
    /// </summary>
    /// <param name="fraction">The multiplicand.</param>
    /// <returns>A proper fraction representing the product of the multiplication, reduced to its simplest form.</returns>
    public Fraction64 Multiply(Fraction64 fraction)
    {
        (int numerator, int denominator) = MultiplySimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    /// <summary>
    /// Subtracts mixed fraction components from a whole number.
    /// </summary>
    /// <param name="wholeMinuend">The whole number to be subtracted from.</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <returns>A proper, mixed fraction representing the difference, reduced to its simplest form.</returns>
    public MixedFraction96 Subtract(int wholeMinuend, int wholeSubtrahend, Fraction64 subtrahendFraction)
    {
        (int wholeNumber, int numerator, int denominator) = SubtractFractions(wholeMinuend, this, wholeSubtrahend, subtrahendFraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Subtracts a fractional value from the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to subtract.</param>
    /// <returns>A proper fraction representing the difference of the two fractions, reduced to its simplest form.</returns>
    public Fraction64 Subtract(Fraction64 fraction)
    {
        (int numerator, int denominator) = SubtractSimpleFractions<Fraction64, int>(this, fraction);
        return new(numerator, denominator);
    }

    /// <summary>
    /// Converts the current fraction to a <see cref="double"/> value.
    /// </summary>
    /// <param name="provider">An optional object that supplies culture-specific formatting information.</param>
    /// <returns>The <see cref="double"/> that is equivalent to the current fraction.</returns>
    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0) return double.NaN;
        if (provider is null)
            return (Numerator == 0) ? 0.0 : (Denominator == 1) ? Convert.ToDouble(Numerator) : Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
        return (Numerator == 0) ? Convert.ToDouble(Numerator, provider) : Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider);
    }

    public override string ToString() => ToFractionString(Numerator, Denominator);

    /// <summary>
    /// Tries to format the value of the current instance into the provided span of characters.
    /// </summary>
    /// <param name="destination">The span in which to write this instance's value formatted as a span of characters.</param>
    /// <param name="charsWritten">When this method returns, contains the number of characters that were written in <paramref name="destination"/>.</param>
    /// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for destination.</param>
    /// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if the formatting was successful; otherwise, <see langword="false"/>.</returns>
    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatSimpleFraction<Fraction64, int>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    /// <summary>
    /// Computes the absolute of a fraction.
    /// </summary>
    /// <param name="value">The fraction for which to get its absolute.</param>
    /// <returns>The absolute of fraction.</returns>
    public static Fraction64 Abs(Fraction64 value) => (value.Denominator == 0) ? value : new(int.Abs(value.Numerator), int.Abs(value.Denominator));

    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="wholeNumber1">The first whole number.</param>
    /// <param name="fraction1">The first fraction.</param>
    /// <param name="wholeNumber2">The second whole number.</param>
    /// <param name="fraction2">The second fraction</param>
    /// <param name="sum">Returns fractional part the sum of the added mixed fractions.</param>
    /// <returns>The whole number part of the sum of the added mixed fractions.</returns>
    public static Fraction64 Add(int wholeNumber1, Fraction64 fraction1, int wholeNumber2, Fraction64 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="fraction1">The first mixed fraction.</param>
    /// <param name="wholeNumber2">The second whole number.</param>
    /// <param name="fraction2">The second fraction.</param>
    /// <param name="sum">Returns the whole number part of the sum of the added mixed fractions.</param>
    /// <returns>The proper fractional part the sum, reduced to its simplest form.</returns>
    public static Fraction64 Add(MixedFraction96 fraction1, int wholeNumber2, Fraction64 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="wholeNumber1">The first whole number.</param>
    /// <param name="fraction1">The first fraction.</param>
    /// <param name="fraction2">The second mixed fraction.</param>
    /// <param name="sum">Returns the whole number part of the sum of the added mixed fractions.</param>
    /// <returns>The proper fractional part the sum, reduced to its simplest form.</returns>
    public static Fraction64 Add(int wholeNumber1, Fraction64 fraction1, MixedFraction96 fraction2, out int sum)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a fraction to a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to add to.</param>
    /// <param name="fraction">The fractional value to be added.</param>
    /// <returns>A proper mixed fraction representing the sum, reduced to its simplest form.</returns>
    public static MixedFraction96 Add(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Divides individual mixed fraction components.
    /// </summary>
    /// <param name="wholeDividend">The whole number to be divided.</param>
    /// <param name="dividendFraction">The fractional value to be divided.</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <param name="quotient">Returns the whole number part of the divided value.</param>
    /// <returns>The proper fractional part of the divided value, reduced to its simplest form.</returns>
    public static Fraction64 Divide(int wholeDividend, Fraction64 dividendFraction, int wholeDivisor, Fraction64 divisorFraction, out int quotient)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Divides a mixed fraction by mixed fraction components.
    /// </summary>
    /// <param name="dividend">The mixed fraction to be divided</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <param name="quotient">Returns the whole number part of the divided value.</param>
    /// <returns>The proper fractional part of the divided value, reduced to its simplest form.</returns>
    public static Fraction64 Divide(MixedFraction96 dividend, int wholeDivisor, Fraction64 divisorFraction, out int quotient)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Divides mixed fractino components by a mixed fraction.
    /// </summary>
    /// <param name="wholeDividend">The whole number component of the value to be divided.</param>
    /// <param name="dividendFraction">The fractional component of the value to be divided.</param>
    /// <param name="divisor">The mixed fraction to divide by.</param>
    /// <param name="quotient">Returns the whole number part of the divided value.</param>
    /// <returns>The proper fractional part of the divided value, reduced to its simplest form.</returns>
    public static Fraction64 Divide(int wholeDividend, Fraction64 dividendFraction, MixedFraction96 divisor, out int quotient)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Divides a whole number by a fractional value.
    /// </summary>
    /// <param name="wholeNumber">The whole number to divide.</param>
    /// <param name="fraction">The fractional value to divide by.</param>
    /// <returns>A proper mixed fraction representing the quotient, reduced to its simplest form.</returns>
    public static MixedFraction96 Divide(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets an inverted fraction value from the current fractional value and a whole number.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <returns>A fraction normalized from inverted <see cref="Denominator"/> and <see cref="Numerator"/> values.</returns>
    public static Fraction64 Invert(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets an inverted fraction value.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <param name="doNotReduce">If <see langword="true"/>, the return value will have the <see cref="Denominator"/> and <see cref="Numerator"/> inverted
    /// without being reduced to its simplest form; otherwise, the returned fraction will be reduced to its simplest form.</param>
    /// <returns>A fraction from the inverted <see cref="Numerator"/> and <see cref="Denominator"/> values.</returns>
    public static Fraction64 Invert(Fraction64 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if a fraction value represents an even integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is an even integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsEvenInteger(Fraction64 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0 && value.Numerator / value.Denominator % 2 == 0));

    /// <summary>
    /// Determines if a fraction value represents an integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is an integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsInteger(Fraction64 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (Math.Abs(value.Numerator) > Math.Abs(value.Denominator) && value.Numerator % value.Denominator == 0));

    /// <summary>
    /// Determines if a fraction value is not a number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is not a number; otherwise, <see langword="false"/>.</returns>
    public static bool IsNaN(Fraction64 value) => value.Denominator == 0;

    /// <summary>
    /// Determines if a value is negative.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is negative; otherwise, <see langword="false"/>.</returns>
    public static bool IsNegative(Fraction64 value) => value.Denominator != 0 && value.Numerator != 0 && ((value.Denominator < 0) ? value.Numerator > 0 : value.Numerator < 0);

    /// <summary>
    /// Determines if a value represents an odd integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is is an odd integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsOddInteger(Fraction64 value) => value.Denominator != 0 && value.Numerator != 0 && Math.Abs(value.Numerator) > Math.Abs(value.Denominator) &&
        value.Numerator % value.Denominator == 0 && value.Numerator / value.Denominator % 2 != 0;

    /// <summary>
    /// Determines if a value is positive.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is positive; otherwise, <see langword="false"/>.</returns>
    public static bool IsPositive(Fraction64 value) => value.Denominator != 0 && (value.Numerator == 0 || ((value.Denominator < 0) ? value.Numerator < 0 : value.Numerator > 0));

    /// <summary>
    /// Determines if a value is a power of two.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is a power of two; otherwise, <see langword="false"/>.</returns>
    public static bool IsPow2(Fraction64 value) => double.IsPow2(value.ToDouble());

    /// <summary>
    /// Indicates whether a value is a proper fraction.
    /// </summary>
    /// <param name="value">The fractional value to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> is less than the <see cref="Denominator"/>;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsProperFraction(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether the value is a proper fraction that is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values
    /// and the <see cref="Numerator"/> is less than the <see cref="Denominator"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsProperSimplestForm(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether a fraction is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsSimplestForm(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether a fraction is zero.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the fraction is zero; otherwise, <see langword="false"/>.</returns>
    public static bool IsZero(Fraction64 value) => value.Numerator == 0 && value.Denominator != 0;

    /// <summary>
    /// Computes the log2 of a fraction.
    /// </summary>
    /// <param name="value">The value whose log2 is to be computed.</param>
    /// <returns>The log2 of value.</returns>
    public static Fraction64 Log2(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares two values to compute which is greater.
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the greater fraction; otherwise, <paramref name="y"/>.</returns>
    public static Fraction64 MaxMagnitude(Fraction64 x, Fraction64 y) => (x > y) ? x : y;

    /// <summary>
    /// Compares two values to compute which has the greater magnitude and returning the other value if an input is <see cref="NaN"/>. 
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the greater fraction; otherwise, <paramref name="y"/>.</returns>
    public static Fraction64 MaxMagnitudeNumber(Fraction64 x, Fraction64 y)
    {
        Fraction64 ax = Abs(x);
        Fraction64 ay = Abs(y);
        if ((ax > ay) || ay.Denominator == 0) return x;
        return (ax != ay) ? y : IsNegative(x) ? y : x;
    }

    /// <summary>
    /// Compares two values to compute which is lesser.
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the lesser fraction; otherwise, <paramref name="y"/>.</returns>
    public static Fraction64 MinMagnitude(Fraction64 x, Fraction64 y) => (x < y) ? x : y;

    /// <summary>
    /// Compares two values to compute which has the lesser magnitude and returning the other value if an input is <see cref="NaN"/>. 
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the lesser fraction; otherwise, <paramref name="y"/>.</returns>
    public static Fraction64 MinMagnitudeNumber(Fraction64 x, Fraction64 y)
    {
        Fraction64 ax = Abs(x);
        Fraction64 ay = Abs(y);
        if ((ax < ay) || ay.Denominator == 0) return x;
        return (ax != ay) ? y : IsNegative(x) ? x : y;
    }

    /// <summary>
    /// Multiplies individual mixed fraction components.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to multiply.</param>
    /// <param name="multiplierFraction">The fractional value to multiply.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <param name="product">Returns the whole number part of the product.</param>
    /// <returns>The proper fractional part of the product, reduced to its simplest form.</returns>
    public static Fraction64 Multiply(int wholeMultiplier, Fraction64 multiplierFraction, int wholeMultiplicand, Fraction64 multiplicandFraction, out int product)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Multiplies a mixed fraction by mixed fraction components.
    /// </summary>
    /// <param name="multiplier">The mixed fraction to be multiplied.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <param name="product">Returns the whole number part of the product.</param>
    /// <returns>The proper fractional part of the product, reduced to its simplest form.</returns>
    public static Fraction64 Multiply(MixedFraction96 multiplier, int wholeMultiplicand, Fraction64 multiplicandFraction, out int product)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Multiplies mixed fraction components by a mixed fraction.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to multiply.</param>
    /// <param name="multiplierFraction">The fractional value to multiply.</param>
    /// <param name="multiplicand">The mixed fraction to multiply by.</param>
    /// <param name="product">Returns the whole number part of the product.</param>
    /// <returns>The proper fractional part of the product, reduced to its simplest form.</returns>
    public static Fraction64 Multiply(int wholeMultiplier, Fraction64 multiplierFraction, MixedFraction96 multiplicand, out int product)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Multiplies a whole nubmer by a fraction.
    /// </summary>
    /// <param name="wholeNumber">The whole number to be multiplied.</param>
    /// <param name="fraction">The fractional value to multiply by.</param>
    /// <returns>A proper mixed fraction representing the product, reduced to its simplest form.</returns>
    public static MixedFraction96 Multiply(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a span of characters into a value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction64"/>.</exception>
    public static Fraction64 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a string into a <see cref="Fraction64"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction64"/>.</exception>
    public static Fraction64 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a span of characters into a value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction64"/>.</exception>
    public static Fraction64 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a string into a <see cref="Fraction64"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction64"/>.</exception>
    public static Fraction64 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Subtracts individual mixed fraction components.
    /// </summary>
    /// <param name="wholeMinuend">The whole number to be subtracted from.</param>
    /// <param name="minuendFraction">The fractional value to be subtracted from.</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <param name="difference">Returns the whole number part of the difference.</param>
    /// <returns>The proper fractional part of the difference, reduced to its simplest form.</returns>
    public static Fraction64 Subtract(int wholeMinuend, Fraction64 minuendFraction, int wholeSubtrahend, Fraction64 subtrahendFraction, out int difference)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Subtracts mixed fraction components from a mixed fraction.
    /// </summary>
    /// <param name="minuend">The mixed fraction to be subtracted from</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <param name="difference">Returns the whole number part of the difference.</param>
    /// <returns>The proper fractional part of the difference, reduced to its simplest form.</returns>
    public static Fraction64 Subtract(MixedFraction96 minuend, int wholeSubtrahend, Fraction64 subtrahendFraction, out int difference)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Subtracts mixed fraction components from a mixed fraction.
    /// </summary>
    /// <param name="minuend">The mixed fraction to be subtracted from</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <param name="difference">Returns the whole number part of the difference.</param>
    /// <returns>The proper fractional part of the difference, reduced to its simplest form.</returns>
    public static Fraction64 Subtract(int wholeMinuend, Fraction64 minuendFraction, MixedFraction96 subtrahend, out int difference)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Subtracts a fraction from a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to subtract from.</param>
    /// <param name="fraction">The fractional value to subtract.</param>
    /// <returns>A proper mixed fraction representing the difference, reduced to its simplest form.</returns>
    public static MixedFraction96 Subtract(int wholeNumber, Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a fraction to a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to normalize.</param>
    /// <param name="wholeNumber">Returns the whole number derived from an improper fraction, which may be zero if the fraction was already a proper fraction.</param>
    /// <returns>A proper fraction where the <see cref="Numerator"/> is less than the <see cref="Denominator"/>.</returns>
    public static Fraction64 ToProperFraction(Fraction64 value, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a fraction to a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction with the <see cref="Numerator"/> being less than the <see cref="Denominator"/>.</returns>
    public static MixedFraction96 ToProperFraction(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a fraction to proper form, also reducing it to its simplest terms.
    /// </summary>
    /// <param name="value">The fraction to normalize.</param>
    /// <param name="wholeNumber">Returns the whole number derived from an improper fraction, which may be zero if the fraction was already a proper fraction.</param>
    /// <returns>A proper fraction where the <see cref="Numerator"/> is less than the <see cref="Denominator"/>, which also has been reduced to its simplest terms.</returns>
    public static Fraction64 ToProperSimplestForm(Fraction64 value, out int wholeNumber)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a proper fraction reduced to its simplest form.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction reduced to its simplest form, with the <see cref="Numerator"/> is less than the <see cref="Denominator"/>.</returns>
    public static MixedFraction96 ToProperSimplestForm(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a fraction reduced to its simplest form.
    /// </summary>
    /// <param name="fraction">The fractional value to reduce.</param>
    /// <returns>A fraction where the <see cref="Numerator"/> and <see cref="Numerator"/> are reduced to their simplest values.</returns>
    public static Fraction64 ToSimplestForm(Fraction64 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Fraction64 result)
    {
        if (TryParseSimpleFraction(s, style, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out Fraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), style, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    /// <param name="s">The span of characters to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Fraction64 result)
    {
        if (TryParseSimpleFraction(s, NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <param name="result">On return, contains the result of succesfully parsing <paramref name="s"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Fraction64 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), NumberStyles.Integer | NumberStyles.AllowLeadingSign, provider, out int numerator, out int denominator))
        {
            result = new(numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<Fraction64>.Radix => 2;

    static Fraction64 IAdditiveIdentity<Fraction64, Fraction64>.AdditiveIdentity => Zero;

    static Fraction64 IMultiplicativeIdentity<Fraction64, Fraction64>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is Fraction64 other) ? CompareTo(other) : -1;

    TypeCode IConvertible.GetTypeCode() => TypeCode.Double;

    bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(ToDouble(provider), provider);

    byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(ToDouble(provider), provider);

    char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(ToDouble(provider), provider);

    DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(ToDouble(provider), provider);

    decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(ToDouble(provider), provider);

    short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(ToDouble(provider), provider);

    int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(ToDouble(provider), provider);

    long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(ToDouble(provider), provider);

    sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(ToDouble(provider), provider);

    float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(ToDouble(provider), provider);

    string IConvertible.ToString(IFormatProvider? provider) => ToFractionString(Numerator, Denominator, provider);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToFractionString(Numerator, Denominator, format, formatProvider);

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<Fraction64, int>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static bool INumberBase<Fraction64>.IsCanonical(Fraction64 value) => true;

    static bool INumberBase<Fraction64>.IsComplexNumber(Fraction64 value) => false;

    static bool INumberBase<Fraction64>.IsFinite(Fraction64 value) => true;

    static bool INumberBase<Fraction64>.IsImaginaryNumber(Fraction64 value) => false;

    static bool INumberBase<Fraction64>.IsInfinity(Fraction64 value) => false;

    static bool INumberBase<Fraction64>.IsNegativeInfinity(Fraction64 value) => false;

    static bool INumberBase<Fraction64>.IsNormal(Fraction64 value) => true;

    static bool INumberBase<Fraction64>.IsPositiveInfinity(Fraction64 value) => false;

    static bool INumberBase<Fraction64>.IsRealNumber(Fraction64 value) => value.Denominator != 0;

    static bool INumberBase<Fraction64>.IsSubnormal(Fraction64 value) => false;

    static bool INumberBase<Fraction64>.TryConvertFromChecked<TOther>(TOther value, out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertFromSaturating<TOther>(TOther value, out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertFromTruncating<TOther>(TOther value, out Fraction64 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertToChecked<TOther>(Fraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertToSaturating<TOther>(Fraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Fraction64>.TryConvertToTruncating<TOther>(Fraction64 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static Fraction64 operator +(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator +(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator -(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator -(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator ~(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator ++(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator --(Fraction64 value)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator *(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator /(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator %(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator &(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator |(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static Fraction64 operator ^(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Fraction64 left, Fraction64 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
