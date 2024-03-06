using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using static TestDataGeneration.Numerics.Fraction;

namespace TestDataGeneration.Numerics;

/// <summary>
/// 192-bit unsigned, mixed fractional value comprised of 64-bit whole number, numerator and denominator values.
/// </summary>
public readonly struct UnsignedMixedFraction192 : IMixedFraction<UnsignedMixedFraction192, ulong, UnsignedFraction128>
{
    #region Static Properties

    /// <summary>
    /// Gets the fraction representing the value of one.
    /// </summary>
    /// <returns>The fraction representing a value of one.</returns>
    public static UnsignedMixedFraction192 One { get; } = new(1UL);

    /// <summary>
    /// Gets the zero fraction value.
    /// </summary>
    /// <returns>The fraction representing a zero value.</returns>
    public static UnsignedMixedFraction192 Zero { get; } = new(0UL);

    /// <summary>
    /// Gets the maximum fraction value.
    /// </summary>
    /// <returns>The maximum value.</returns>
    public static UnsignedMixedFraction192 MaxValue { get; } = new(ulong.MaxValue, ulong.MaxValue, 1UL);

    /// <summary>
    /// Gets the minimum fraction value.
    /// </summary>
    /// <returns>The minimum value.</returns>
    public static UnsignedMixedFraction192 MinValue { get; } = new(ulong.MinValue, ulong.MaxValue, 1UL);

    /// <summary>
    /// Gets a fraction value that is not a number (NaN).
    /// </summary>
    /// <returns>A fraction value that is not a number (NaN).</returns>
    public static UnsignedMixedFraction192 NaN { get; } = new();

    #endregion

    #region Instance Properties

    /// <summary>
    /// Gets the whole number.
    /// </summary>
    /// <returns>The whole nubmer associated with the fractional value.</returns>
    public ulong WholeNumber { get; }

    /// <summary>
    /// Gets the numerator value.
    /// </summary>
    /// <value>The numerator for the current fractional value.</value>
    public ulong Numerator { get; }

    /// <summary>
    /// Gets the denominator value.
    /// </summary>
    /// <value>The denominator for the current fractional value.</value>
    public ulong Denominator { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a <c>UnsignedMixedFraction192</c> fraction value.
    /// </summary>
    /// <param name="wholeNumber">The whole number value.</param>
    /// <param name="numerator">The numerator value.</param>
    /// <param name="denominator">The denominator value.</param>
    /// <param name="doNotReduce">If true, the fraction value will not be reduced to its simplest terms.</param>
    /// <param name="doNotMakeProper">If true, improper parameter values will not be converted as a proper fraction.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is less than <c>1</c>.</exception>
    public UnsignedMixedFraction192(ulong wholeNumber, ulong numerator, ulong denominator, bool doNotReduce = false, bool doNotMakeProper = false)
    {
        if (doNotReduce)
        {
            if (doNotMakeProper)
            {
                if (denominator == 0) throw new DivideByZeroException();
            }
            else
                wholeNumber = GetProperRational(wholeNumber, numerator, denominator, out numerator);
        }
        else if (doNotMakeProper)
            numerator = GetSimplifiedRational(numerator, denominator, out denominator);
        else
            wholeNumber = GetNormalizedRational(wholeNumber, numerator, denominator, out numerator, out denominator);
        WholeNumber = wholeNumber;
        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary>
    /// Creates a <c>UnsignedMixedFraction192</c> fraction value with a whole number of <c>0</c>.
    /// </summary>
    /// <param name="numerator">The numerator value.</param>
    /// <param name="denominator">The denominator value.</param>
    /// <param name="doNotReduce">If true, the fraction value will not be reduced to its simplest terms.</param>
    /// <param name="doNotMakeProper">If true, improper parameter values will not be converted as a proper fraction.</param>
    /// <exception cref="DivideByZeroException"><paramref name="denominator"/> is less than <c>1</c>.</exception>
    public UnsignedMixedFraction192(ulong numerator, ulong denominator, bool doNotReduce = false, bool doNotMakeProper = false) :
        this(0UL, numerator, denominator, doNotReduce, doNotMakeProper)
    { }

    /// <summary>
    /// Creates a <c>UnsignedMixedFraction192</c> whole number fraction value with a numerator of <c>0</c> and denominator of <c>1</c>.
    /// </summary>
    /// <param name="wholeNumber">The whole number value.</param>
    public UnsignedMixedFraction192(ulong wholeNumber)
    {
        WholeNumber = wholeNumber;
        Numerator = 0;
        Denominator = 1;
    }

    #endregion

    #region Instance Methods

    /// <summary>
    /// Adds a fractional value to the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to add.</param>
    /// <returns>A proper fraction representing sum of the two fractions, reduced to its simplest form.</returns>
    public UnsignedMixedFraction192 Add(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = AddFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public int CompareTo(UnsignedMixedFraction192 other) => CompareFractionComponents(WholeNumber, Numerator, Denominator, other.WholeNumber, other.Numerator, other.Denominator);

    /// <summary>
    /// Divides the current fraction by a fractional value.
    /// </summary>
    /// <param name="fraction">The divisor.</param>
    public UnsignedMixedFraction192 Divide(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = DivideFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    public bool Equals(UnsignedMixedFraction192 other) => AreMixedFractionsEqual<UnsignedMixedFraction192, ulong>(this, other);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is UnsignedMixedFraction192 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(WholeNumber, Numerator, Denominator);

    /// <summary>
    /// Multiplies the current fraction with a fractional value.
    /// </summary>
    /// <param name="fraction">The multiplicand.</param>
    /// <returns>A proper fraction representing the product of the multiplication, reduced to its simplest form.</returns>
    public UnsignedMixedFraction192 Multiply(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = MultiplyFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Gets a whole number and a simple fraction from a mixed fraction.
    /// </summary>
    /// <param name="properFraction">The proper, simple fraction.</param>
    /// <returns>The whole number from the mixed fraction.</returns>
    public ulong Split(out UnsignedFraction128 properFraction)
    {
        properFraction = new(Numerator, Denominator);
        return WholeNumber;
    }

    /// <summary>
    /// Subtracts a fractional value from the current fraction.
    /// </summary>
    /// <param name="fraction">The fraction to subtract.</param>
    /// <returns>A proper fraction representing the difference of the two fractions, reduced to its simplest form.</returns>
    public UnsignedMixedFraction192 Subtract(UnsignedMixedFraction192 fraction)
    {
        (ulong wholeNumber, ulong numerator, ulong denominator) = SubtractFractions<UnsignedMixedFraction192, ulong>(this, fraction);
        return new(wholeNumber, numerator, denominator);
    }

    /// <summary>
    /// Converts the current fraction to a <see cref="double"/> value.
    /// </summary>
    /// <param name="provider">An optional object that supplies culture-specific formatting information.</param>
    /// <returns>The <see cref="double"/> that is equivalent to the current fraction.</returns>
    public double ToDouble(IFormatProvider? provider = null)
    {
        if (Denominator == 0UL) return double.NaN;
        if (provider is null)
            return (Numerator == 0UL) ? Convert.ToDouble(WholeNumber) : Convert.ToDouble(WholeNumber) + (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator));
        return (Numerator == 0UL) ? Convert.ToDouble(WholeNumber, provider) : Convert.ToDouble(WholeNumber, provider) + (Convert.ToDouble(Numerator, provider) / Convert.ToDouble(Denominator, provider));
    }

    public override string ToString() => ToFractionString(WholeNumber, Numerator, Denominator);

    /// <summary>
    /// Tries to format the value of the current instance into the provided span of characters.
    /// </summary>
    /// <param name="destination">The span in which to write this instance's value formatted as a span of characters.</param>
    /// <param name="charsWritten">When this method returns, contains the number of characters that were written in <paramref name="destination"/>.</param>
    /// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for destination.</param>
    /// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if the formatting was successful; otherwise, <see langword="false"/>.</returns>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
        TryFormatMixedFraction<UnsignedMixedFraction192, ulong>(this, destination, out charsWritten, format, provider);

    #endregion

    #region Static Methods

    /// <summary>
    /// Adds a fraction to a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to add to.</param>
    /// <param name="fraction">The fractional value to be added.</param>
    /// <returns>A proper mixed fraction representing the sum, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction192 Add(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Divides a whole number by a fractional value.
    /// </summary>
    /// <param name="wholeNumber">The whole number to divide.</param>
    /// <param name="fraction">The fractional value to divide by.</param>
    /// <returns>A proper mixed fraction representing the quotient, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction192 Divide(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets an inverted fraction value.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <param name="doNotReduce">If <see langword="true"/>, the return value will have the <see cref="Denominator"/> and <see cref="Numerator"/> inverted
    /// without being reduced to its simplest form; otherwise, the returned fraction will be reduced to its simplest form.</param>
    /// <param name="doNotMakeProper">If <see langword="true"/>, the return value will have the <see cref="Denominator"/> and <see cref="Numerator"/> inverted
    /// and may result in an improper fraction; otherwise, the returned fraction will be will be a proper fraction.</param>
    /// <returns>A fraction from the inverted <see cref="Numerator"/> and <see cref="Denominator"/> values.</returns>
    public static UnsignedMixedFraction192 Invert(UnsignedMixedFraction192 fraction, bool doNotReduce, bool doNotMakeProper)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets an inverted fraction value from the current fractional value and a whole number.
    /// </summary>
    /// <param name="fraction">The fractional value to invert.</param>
    /// <returns>A fraction normalized from inverted <see cref="Denominator"/> and <see cref="Numerator"/> values.</returns>
    public static UnsignedMixedFraction192 Invert(UnsignedMixedFraction192 fraction)
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
    public static UnsignedMixedFraction192 Invert(UnsignedMixedFraction192 fraction, bool doNotReduce)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if a fraction value represents an even integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is an even integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsEvenInteger(UnsignedMixedFraction192 value) => value.Denominator != 0 && (value.Numerator == 0 ||
        (value.Numerator > value.Denominator && value.Numerator % value.Denominator == 0));

    /// <summary>
    /// Determines if a fraction value represents an integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is an integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsInteger(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if a fraction value is not a number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is not a number; otherwise, <see langword="false"/>.</returns>
    public static bool IsNaN(UnsignedMixedFraction192 value) => value.Denominator == 0;

    /// <summary>
    /// Determines if a value represents an odd integral number.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is is an odd integer; otherwise, <see langword="false"/>.</returns>
    public static bool IsOddInteger(UnsignedMixedFraction192 value) => value.Denominator != 0 && ((value.Numerator != 0) ? value.Numerator > value.Denominator &&
        value.Numerator % value.Denominator == 0 && (value.WholeNumber + value.Numerator / value.Denominator) % 2 != 0 : value.WholeNumber % 2 != 0);

    /// <summary>
    /// Determines if a value is a power of two.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is a power of two; otherwise, <see langword="false"/>.</returns>
    public static bool IsPow2(UnsignedMixedFraction192 value) => double.IsPow2(value.ToDouble());

    /// <summary>
    /// Indicates whether a value is a proper fraction.
    /// </summary>
    /// <param name="value">The fractional value to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> is less than the <see cref="Denominator"/>;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsProperFraction(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    /// /// <summary>
    /// Checks whether the value is a proper fraction that is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values
    /// and the <see cref="Numerator"/> is less than the <see cref="Denominator"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsProperSimplestForm(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether a fraction is reduced to its simplest form.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the <see cref="Numerator"/> and <see cref="Numerator"/> are already reduced to their simplest values;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsSimplestForm(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Checks whether a fraction is zero.
    /// </summary>
    /// <param name="value">The <typeparamref name="TSelf"/>-type fraction to check.</param>
    /// <returns><see langword="true"/> if the fraction is zero; otherwise, <see langword="false"/>.</returns>
    public static bool IsZero(UnsignedMixedFraction192 value) => value.Numerator == 0 && value.WholeNumber == 0 && value.Denominator != 0;

    /// <summary>
    /// Computes the log2 of a fraction.
    /// </summary>
    /// <param name="value">The value whose log2 is to be computed.</param>
    /// <returns>The log2 of value.</returns>
    public static UnsignedMixedFraction192 Log2(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares two values to compute which is greater.
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the greater fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedMixedFraction192 MaxMagnitude(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x > y) ? x : y;

    /// <summary>
    /// Compares two values to compute which has the greater magnitude and returning the other value if an input is <see cref="NaN"/>. 
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the greater fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedMixedFraction192 MaxMagnitudeNumber(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x > y) ? x : y;

    /// <summary>
    /// Compares two values to compute which is lesser.
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the lesser fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedMixedFraction192 MinMagnitude(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x < y) ? x : y;

    /// <summary>
    /// Compares two values to compute which has the lesser magnitude and returning the other value if an input is <see cref="NaN"/>. 
    /// </summary>
    /// <param name="x">The first fraction to compare.</param>
    /// <param name="y">The second fraction to compare.</param>
    /// <returns><paramref name="x"/> if it is the lesser fraction; otherwise, <paramref name="y"/>.</returns>
    public static UnsignedMixedFraction192 MinMagnitudeNumber(UnsignedMixedFraction192 x, UnsignedMixedFraction192 y) => (x < y) ? x : y;

    /// <summary>
    /// Multiplies a whole nubmer by a fraction.
    /// </summary>
    /// <param name="wholeNumber">The whole number to be multiplied.</param>
    /// <param name="fraction">The fractional value to multiply by.</param>
    /// <returns>A proper mixed fraction representing the product, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction192 Multiply(ulong wholeNumber, UnsignedFraction128 fraction)
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
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="UnsignedFraction128"/>.</exception>
    public static UnsignedMixedFraction192 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a string into a <see cref="UnsignedFraction128"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s"/>.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="style"/> is not a supported <see cref="NumberStyles"/> value.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="UnsignedFraction128"/>.</exception>
    public static UnsignedMixedFraction192 Parse(string s, NumberStyles style, IFormatProvider? provider)
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
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="UnsignedFraction128"/>.</exception>
    public static UnsignedMixedFraction192 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses a string into a <see cref="UnsignedFraction128"/> value.
    /// </summary>
    /// <param name="s">The string to parse.</param>
    /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
    /// <returns>The result of parsing <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> is not representable by a <see cref="UnsignedFraction128"/>.</exception>
    public static UnsignedMixedFraction192 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Subtracts a fraction from a whole number.
    /// </summary>
    /// <param name="wholeNumber">The whole number to subtract from.</param>
    /// <param name="fraction">The fractional value to subtract.</param>
    /// <returns>A proper mixed fraction representing the difference, reduced to its simplest form.</returns>
    public static UnsignedMixedFraction192 Subtract(ulong wholeNumber, UnsignedFraction128 fraction)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a fraction to a proper fraction.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction with the <see cref="Numerator"/> being less than the <see cref="Denominator"/>.</returns>
    public static UnsignedMixedFraction192 ToProperFraction(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a proper fraction reduced to its simplest form.
    /// </summary>
    /// <param name="value">The fraction to convert.</param>
    /// <returns>A mixed fraction reduced to its simplest form, with the <see cref="Numerator"/> is less than the <see cref="Denominator"/>.</returns>
    public static UnsignedMixedFraction192 ToProperSimplestForm(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a fraction reduced to its simplest form.
    /// </summary>
    /// <param name="fraction">The fractional value to reduce.</param>
    /// <returns>A fraction where the <see cref="Numerator"/> and <see cref="Numerator"/> are reduced to their simplest values.</returns>
    public static UnsignedMixedFraction192 ToSimplestForm(UnsignedMixedFraction192 fraction)
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
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out UnsignedMixedFraction192 result)
    {
        if (TryParseMixedFraction(s, style, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
        {
            result = new(wholeNumber, numerator, denominator);
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
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out UnsignedMixedFraction192 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), style, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
        {
            result = new(wholeNumber, numerator, denominator);
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out UnsignedMixedFraction192 result)
    {
        if (TryParseMixedFraction(s, NumberStyles.Integer, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
        {
            result = new(wholeNumber, numerator, denominator);
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out UnsignedMixedFraction192 result)
    {
        if (string.IsNullOrEmpty(s) && TryParseMixedFraction(s.AsSpan(), NumberStyles.Integer, provider, out ulong wholeNumber, out ulong numerator, out ulong denominator))
        {
            result = new(wholeNumber, numerator, denominator);
            return true;
        }
        result = Zero;
        return false;
    }

    #endregion

    #region Implicit Members

    #region Static Properties

    static int INumberBase<UnsignedMixedFraction192>.Radix => 2;

    static UnsignedMixedFraction192 IAdditiveIdentity<UnsignedMixedFraction192, UnsignedMixedFraction192>.AdditiveIdentity => Zero;

    static UnsignedMixedFraction192 IMultiplicativeIdentity<UnsignedMixedFraction192, UnsignedMixedFraction192>.MultiplicativeIdentity => One;

    #endregion

    #region Instance Methods

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is UnsignedMixedFraction192 other) ? CompareTo(other) : -1;

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

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ConvertFraction<UnsignedMixedFraction192, ulong>(this, conversionType, provider);

    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToDouble(provider), provider);

    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToDouble(provider), provider);

    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToDouble(provider), provider);

    #endregion

    #region Static Methods

    static UnsignedMixedFraction192 INumberBase<UnsignedMixedFraction192>.Abs(UnsignedMixedFraction192 value) => value;

    static bool INumberBase<UnsignedMixedFraction192>.IsCanonical(UnsignedMixedFraction192 value) => true;

    static bool INumberBase<UnsignedMixedFraction192>.IsComplexNumber(UnsignedMixedFraction192 value) => false;

    static bool INumberBase<UnsignedMixedFraction192>.IsFinite(UnsignedMixedFraction192 value) => true;

    static bool INumberBase<UnsignedMixedFraction192>.IsImaginaryNumber(UnsignedMixedFraction192 value) => false;

    static bool INumberBase<UnsignedMixedFraction192>.IsInfinity(UnsignedMixedFraction192 value) => false;

    static bool INumberBase<UnsignedMixedFraction192>.IsNegative(UnsignedMixedFraction192 value) => false;

    static bool INumberBase<UnsignedMixedFraction192>.IsNegativeInfinity(UnsignedMixedFraction192 value) => false;

    static bool INumberBase<UnsignedMixedFraction192>.IsNormal(UnsignedMixedFraction192 value) => true;

    static bool INumberBase<UnsignedMixedFraction192>.IsPositive(UnsignedMixedFraction192 value) => true;

    static bool INumberBase<UnsignedMixedFraction192>.IsPositiveInfinity(UnsignedMixedFraction192 value) => false;

    static bool INumberBase<UnsignedMixedFraction192>.IsRealNumber(UnsignedMixedFraction192 value) => value.Denominator != 0;

    static bool INumberBase<UnsignedMixedFraction192>.IsSubnormal(UnsignedMixedFraction192 value) => false;

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertFromChecked<TOther>(TOther value, out UnsignedMixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertFromSaturating<TOther>(TOther value, out UnsignedMixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertFromTruncating<TOther>(TOther value, out UnsignedMixedFraction192 result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertToChecked<TOther>(UnsignedMixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertToSaturating<TOther>(UnsignedMixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UnsignedMixedFraction192>.TryConvertToTruncating<TOther>(UnsignedMixedFraction192 value, out TOther result)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion

    #region Static Operators

    public static UnsignedMixedFraction192 operator +(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator +(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator -(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator -(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator ~(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator ++(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator --(UnsignedMixedFraction192 value)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator *(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator /(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator %(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator &(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator |(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static UnsignedMixedFraction192 operator ^(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UnsignedMixedFraction192 left, UnsignedMixedFraction192 right)
    {
        throw new NotImplementedException();
    }

    #endregion
}
