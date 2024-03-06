using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

/// <summary>
/// 32-bit unsigned, simple fractional value comprised of 16-bit numerator and denominator values.
/// </summary>
public readonly struct UnsignedFraction32 : ISimpleFraction<UnsignedFraction32, ushort, UnsignedMixedFraction48>
{
    #region Static Properties

    /// <summary>
    /// Gets the fraction representing the value of one.
    /// </summary>
    /// <returns>The fraction representing a value of one.</returns>
    public static UnsignedFraction32 One { get; } = new(1, 1);

    /// <summary>
    /// Gets the zero fraction value.
    /// </summary>
    /// <returns>The fraction representing a zero value.</returns>
    public static UnsignedFraction32 Zero { get; } = new(0, 1);

    /// <summary>
    /// Gets the maximum fraction value.
    /// </summary>
    /// <returns>The maximum value.</returns>
    public static UnsignedFraction32 MaxValue { get; } = new(ushort.MaxValue, 1);

    /// <summary>
    /// Gets the minimum fraction value.
    /// </summary>
    /// <returns>The minimum value.</returns>
    public static UnsignedFraction32 MinValue { get; } = new(ushort.MinValue, 1);

    /// <summary>
    /// Gets a fraction value that is not a number (NaN).
    /// </summary>
    /// <returns>A fraction value that is not a number (NaN).</returns>
    public static UnsignedFraction32 NaN { get; } = new();

    #endregion

    #region Instance Properties

    /// <summary>
    /// Gets the numerator value.
    /// </summary>
    /// <value>The numerator for the current fractional value.</value>
    public ushort Numerator { get; }

    /// <summary>
    /// Gets the denominator value.
    /// </summary>
    /// <value>The denominator for the current fractional value.</value>
    public ushort Denominator { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a <c>UnsignedFraction32</c> fraction value.
    /// </summary>
    /// <param name="numerator">The numerator value.</param>
    /// <param name="denominator">The denominator value.</param>
    /// <param name="doNotReduce">If true, the fraction value will not be reduced to its simplest terms.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is less than <c>1</c>.</exception>
    public UnsignedFraction32(ushort numerator, ushort denominator, bool doNotReduce = false)
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
    public UnsignedMixedFraction48 Add(ushort wholeNumber1, ushort wholeNumber2, UnsignedFraction32 fraction2)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = AddFractions(wholeNumber1, this, wholeNumber2, fraction2);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Adds a fractional value to the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to add.</param>
    /// <returns>A proper fraction representing sum of the two fractions, reduced to its simplest form.</returns>
    public UnsignedFraction32 Add(UnsignedFraction32 fraction)
    {
        (ushort numerator, ushort denominator) = AddSimpleFractions<UnsignedFraction32, ushort>(this, fraction);
        return new(numerator, denominator);
    }

    public int CompareTo(UnsignedFraction32 other) => CompareFractionComponents(Numerator, Denominator, other.Numerator, other.Denominator);

    /// <summary>
    /// Divides the current fraction by mixed fraction components.
    /// </summary>
    /// <param name="wholeDividend">The whole number to be divided along with the current fraction.</param>
    /// <param name="wholeDivisor">The whole number to divide by.</param>
    /// <param name="divisorFraction">The fractional value to divide by.</param>
    /// <returns>A proper, mixed fraction representing the quotient, reduced to its simplest form.</returns>
    public UnsignedMixedFraction48 Divide(ushort wholeDividend, ushort wholeDivisor, UnsignedFraction32 divisorFraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = DivideFractions(wholeDividend, this, wholeDivisor, divisorFraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Divides the current fraction by a fractional value.
    /// </summary>
    /// <param name="fraction">The divisor.</param>
    public UnsignedFraction32 Divide(UnsignedFraction32 fraction)
    {
        (ushort numerator, ushort denominator) = DivideSimpleFractions<UnsignedFraction32, ushort>(this, fraction);
        return new(numerator, denominator);
    }

    public bool Equals(UnsignedFraction32 other) => AreSimpleFractionsEqual<UnsignedFraction32, ushort>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedFraction32 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    /// <summary>
    /// Creates a mixed fraction.
    /// </summary>
    /// <param name="wholeNumber">The whole number to join to the current fraction.</param>
    /// <returns>A proper, mixed fraction of the current fraction combined with the specified <paramref name="wholeNumber"/>.</returns>
    public UnsignedMixedFraction48 Join(ushort wholeNumber) => new(wholeNumber, Numerator, Denominator);

    /// <summary>
    /// Multiplies the current fraction by mixed fraction components.
    /// </summary>
    /// <param name="wholeMultiplier">The whole number to be multiplied along with the current fraction.</param>
    /// <param name="wholeMultiplicand">The whole number to multiply by.</param>
    /// <param name="multiplicandFraction">The fractional value to multiply by.</param>
    /// <returns>A proper, mixed fraction representing the product, reduced to its simplest form.</returns>
    public UnsignedMixedFraction48 Multiply(ushort wholeMultiplier, ushort wholeMultiplicand, UnsignedFraction32 multiplicandFraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = MultiplyFractions(wholeMultiplier, this, wholeMultiplicand, multiplicandFraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Multiplies the current fraction with a fractional value.
    /// </summary>
    /// <param name="fraction">The multiplicand.</param>
    /// <returns>A proper fraction representing the product of the multiplication, reduced to its simplest form.</returns>
    public UnsignedFraction32 Multiply(UnsignedFraction32 fraction)
    {
        (ushort numerator, ushort denominator) = MultiplySimpleFractions<UnsignedFraction32, ushort>(this, fraction);
        return new(numerator, denominator);
    }

    /// <summary>
    /// Subtracts mixed fraction components from a whole number.
    /// </summary>
    /// <param name="wholeMinuend">The whole number to be subtracted from.</param>
    /// <param name="wholeSubtrahend">The whole number to subtract.</param>
    /// <param name="subtrahendFraction">The fractional value to subtract.</param>
    /// <returns>A proper, mixed fraction representing the difference, reduced to its simplest form.</returns>
    public UnsignedMixedFraction48 Subtract(ushort wholeMinuend, ushort wholeSubtrahend, UnsignedFraction32 subtrahendFraction)
    {
        (ushort wholeNumber, ushort numerator, ushort denominator) = SubtractFractions(wholeMinuend, this, wholeSubtrahend, subtrahendFraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Subtracts a fractional value from the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to subtract.</param>
    /// <returns>A proper fraction representing the difference of the two fractions, reduced to its simplest form.</returns>
    public UnsignedFraction32 Subtract(UnsignedFraction32 fraction)
    {
        (ushort numerator, ushort denominator) = SubtractSimpleFractions<UnsignedFraction32, ushort>(this, fraction);
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
            return (Numerator == 0) ? Convert.ToDouble(Numerator) : Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
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
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatSimpleFraction<UnsignedFraction32, ushort>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    /// <summary>
    /// Adds individual mixed fraction components.
    /// </summary>
    /// <param name="wholeNumber1">The first whole number.</param>
    /// <param name="fraction1">The first fraction.</param>
    /// <param name="wholeNumber2">The second whole number.</param>
    /// <param name="fraction2">The second fraction.</param>
    /// <param name="sum">Returns the whole number part of the sum of the added mixed fractions.</param>
    /// <returns>The proper fractional part the sum of the added mixed fractions, reduced to its simplest form.</returns>
    public static UnsignedFraction32 Add(ushort wholeNumber1, UnsignedFraction32 fraction1, ushort wholeNumber2, UnsignedFraction32 fraction2, out ushort sum)
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
    public static UnsignedFraction32 Add(UnsignedMixedFraction48 fraction1, ushort wholeNumber2, UnsignedFraction32 fraction2, out ushort sum)
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
    public static UnsignedFraction32 Add(ushort wholeNumber1, UnsignedFraction32 fraction1, UnsignedMixedFraction48 fraction2, out ushort sum)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a fraction to a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to add to.</param>
    /// <param name="fraction">The fractional value to be added.</param>
    /// <returns>A proper mixed fraction representing the sum, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction48 Add(ushort wholeNumber, UnsignedFraction32 fraction)
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
    public static UnsignedFraction32 Divide(ushort wholeDividend, UnsignedFraction32 dividendFraction, ushort wholeDivisor, UnsignedFraction32 divisorFraction, out ushort quotient)
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
    public static UnsignedFraction32 Divide(UnsignedMixedFraction48 dividend, ushort wholeDivisor, UnsignedFraction32 divisorFraction, out ushort quotient)
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
    public static UnsignedFraction32 Divide(ushort wholeDividend, UnsignedFraction32 dividendFraction, UnsignedMixedFraction48 divisor, out ushort quotient)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Divides a whole number by a fractional value.
    /// </summary>
    /// <param name="wholeNumber">The whole number to divide.</param>
    /// <param name="fraction">The fractional value to divide by.</param>
    /// <returns>A proper mixed fraction representing the quotient, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction48 Divide(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets an inverted fraction value from the current fractional value and a whole number.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <returns>A fraction normalized from inverted <see cref="Denominator"/> and <see cref="Numerator"/> values.</returns>
    public static UnsignedFraction32 Invert(UnsignedFraction32 fraction)
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
    public static UnsignedFraction32 Invert(UnsignedFraction32 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if a fraction value represents an even integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is an even integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsEvenInteger(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if a fraction value represents an integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is an integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsInteger(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if a fraction value is not a number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is not a number; otherwise, <see langword="false"/>.</returns>
    public static bool IsNaN(UnsignedFraction32 value) => value.Denominator == 0;

    /// <summary>
    /// Determines if a value represents an odd integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is is an odd integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsOddInteger(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if a value is a power of two.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is a power of two; otherwise, <see langword="false"/>.</returns>
    public static bool IsPow2(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Indicates whether a value is a proper fraction.
    /// </summary>
    /// <param name="value">The fractional value to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> is less than the <see cref="Denominator"/>;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsProperFraction(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether the value is a proper fraction that is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values
    /// and the <see cref="Numerator"/> is less than the <see cref="Denominator"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsProperSimplestForm(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether a fraction is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsSimplestForm(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether a fraction is zero.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the fraction is zero; otherwise, <see langword="false"/>.</returns>
    public static bool IsZero(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Computes the log2 of a fraction.
    /// </summary>
    /// <param name="value">The value whose log2 is to be computed.</param>
    /// <returns>The log2 of value.</returns>
    public static UnsignedFraction32 Log2(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares two values to compute which is greater.
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the greater fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedFraction32 MaxMagnitude(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares two values to compute which has the greater magnitude and returning the other value if an input is <see cref="NaN"/>. 
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the greater fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedFraction32 MaxMagnitudeNumber(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares two values to compute which is lesser.
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the lesser fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedFraction32 MinMagnitude(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares two values to compute which has the lesser magnitude and returning the other value if an input is <see cref="NaN"/>. 
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the lesser fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedFraction32 MinMagnitudeNumber(UnsignedFraction32 x, UnsignedFraction32 y)
    {
        throw new NotImplementedException();
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
    public static UnsignedFraction32 Multiply(ushort wholeMultiplier, UnsignedFraction32 multiplierFraction, ushort wholeMultiplicand, UnsignedFraction32 multiplicandFraction, out ushort product)
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
    public static UnsignedFraction32 Multiply(UnsignedMixedFraction48 multiplier, ushort wholeMultiplicand, UnsignedFraction32 multiplicandFraction, out ushort product)
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
    public static UnsignedFraction32 Multiply(ushort wholeMultiplier, UnsignedFraction32 multiplierFraction, UnsignedMixedFraction48 multiplicand, out ushort product)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Multiplies a whole nubmer by a fraction.
    /// </summary>
    /// <param name="wholeNumber">The whole number to be multiplied.</param>
    /// <param name="fraction">The fractional value to multiply by.</param>
    /// <returns>A proper mixed fraction representing the product, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction48 Multiply(ushort wholeNumber, UnsignedFraction32 fraction)
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
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction32"/>.</exception>
    public static UnsignedFraction32 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a string into a <see cref="Fraction32"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction32"/>.</exception>
    public static UnsignedFraction32 Parse(string s, NumberStyles style, IFormatProvider? provider)
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
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction32"/>.</exception>
    public static UnsignedFraction32 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a string into a <see cref="Fraction32"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="Fraction32"/>.</exception>
    public static UnsignedFraction32 Parse(string s, IFormatProvider? provider)
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
    public static UnsignedFraction32 Subtract(ushort wholeMinuend, UnsignedFraction32 minuendFraction, ushort wholeSubtrahend, UnsignedFraction32 subtrahendFraction, out ushort difference)
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
    public static UnsignedFraction32 Subtract(UnsignedMixedFraction48 minuend, ushort wholeSubtrahend, UnsignedFraction32 subtrahendFraction, out ushort difference)
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
    public static UnsignedFraction32 Subtract(ushort wholeMinuend, UnsignedFraction32 minuendFraction, UnsignedMixedFraction48 subtrahend, out ushort difference)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Subtracts a fraction from a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to subtract from.</param>
    /// <param name="fraction">The fractional value to subtract.</param>
    /// <returns>A proper mixed fraction representing the difference, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction48 Subtract(ushort wholeNumber, UnsignedFraction32 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a fraction to a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to normalize.</param>
    /// <param name="wholeNumber">Returns the whole number derived from an improper fraction, which may be zero if the fraction was already a proper fraction.</param>
    /// <returns>A proper fraction where the <see cref="Numerator"/> is less than the <see cref="Denominator"/>.</returns>
    public static UnsignedFraction32 ToProperFraction(UnsignedFraction32 value, out ushort wholeNumber)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a fraction to a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction with the <see cref="Numerator"/> being less than the <see cref="Denominator"/>.</returns>
    public static UnsignedMixedFraction48 ToProperFraction(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a fraction to proper form, also reducing it to its simplest terms.
    /// </summary>
    /// <param name="value">The fraction to normalize.</param>
    /// <param name="wholeNumber">Returns the whole number derived from an improper fraction, which may be zero if the fraction was already a proper fraction.</param>
    /// <returns>A proper fraction where the <see cref="Numerator"/> is less than the <see cref="Denominator"/>, which also has been reduced to its simplest terms.</returns>
    public static UnsignedFraction32 ToProperSimplestForm(UnsignedFraction32 value, out ushort wholeNumber)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a proper fraction reduced to its simplest form.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction reduced to its simplest form, with the <see cref="Numerator"/> is less than the <see cref="Denominator"/>.</returns>
    public static UnsignedMixedFraction48 ToProperSimplestForm(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a fraction reduced to its simplest form.
    /// </summary>
    /// <param name="fraction">The fractional value to reduce.</param>
    /// <returns>A fraction where the <see cref="Numerator"/> and <see cref="Numerator"/> are reduced to their simplest values.</returns>
    public static UnsignedFraction32 ToSimplestForm(UnsignedFraction32 fraction)
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
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out UnsignedFraction32 result)
    {
        if (TryParseSimpleFraction(s, style, provider, out ushort numerator, out ushort denominator))
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
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out UnsignedFraction32 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), style, provider, out ushort numerator, out ushort denominator))
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out UnsignedFraction32 result)
    {
        if (TryParseSimpleFraction(s, NumberStyles.Integer, provider, out ushort numerator, out ushort denominator))
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out UnsignedFraction32 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseSimpleFraction(s.AsSpan(), NumberStyles.Integer, provider, out ushort numerator, out ushort denominator))
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

    static int INumberBase<UnsignedFraction32>.Radix => 2;

    static UnsignedFraction32 IAdditiveIdentity<UnsignedFraction32, UnsignedFraction32>.AdditiveIdentity => Zero;

    static UnsignedFraction32 IMultiplicativeIdentity<UnsignedFraction32, UnsignedFraction32>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedFraction32 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedFraction32, ushort>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static UnsignedFraction32 INumberBase<UnsignedFraction32>.Abs(UnsignedFraction32 value) => value;

    static bool INumberBase<UnsignedFraction32>.IsCanonical(UnsignedFraction32 value) => true;

    static bool INumberBase<UnsignedFraction32>.IsComplexNumber(UnsignedFraction32 value) => false;

    static bool INumberBase<UnsignedFraction32>.IsFinite(UnsignedFraction32 value) => true;

    static bool INumberBase<UnsignedFraction32>.IsImaginaryNumber(UnsignedFraction32 value) => false;

    static bool INumberBase<UnsignedFraction32>.IsInfinity(UnsignedFraction32 value) => false;

    static bool INumberBase<UnsignedFraction32>.IsNegative(UnsignedFraction32 value) => false;

    static bool INumberBase<UnsignedFraction32>.IsNegativeInfinity(UnsignedFraction32 value) => false;

    static bool INumberBase<UnsignedFraction32>.IsNormal(UnsignedFraction32 value) => true;

    static bool INumberBase<UnsignedFraction32>.IsPositive(UnsignedFraction32 value) => true;

    static bool INumberBase<UnsignedFraction32>.IsPositiveInfinity(UnsignedFraction32 value) => false;

    static bool INumberBase<UnsignedFraction32>.IsRealNumber(UnsignedFraction32 value) => value.Denominator != 0;

    static bool INumberBase<UnsignedFraction32>.IsSubnormal(UnsignedFraction32 value) => false;

    static bool INumberBase<UnsignedFraction32>.TryConvertFromChecked<TOther>(TOther value, out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedFraction32 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertToChecked<TOther>(UnsignedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertToSaturating<TOther>(UnsignedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedFraction32>.TryConvertToTruncating<TOther>(UnsignedFraction32 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedFraction32 operator +(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator +(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator -(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator -(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator ~(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator ++(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator --(UnsignedFraction32 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator *(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator /(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator %(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator &(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator |(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedFraction32 operator ^(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedFraction32 left, UnsignedFraction32 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
