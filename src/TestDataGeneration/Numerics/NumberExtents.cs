using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public static class NumberExtents
{
    /// <summary>
    /// Creates new <see cref="NumberExtents{T}"/> with a new <see cref="NumberExtents{T}.First"/> extent value.
    /// </summary>
    /// <param name="current">The current extents.</param>
    /// <param name="first">The new first extent value.</param>
    /// <returns>The new <see cref="NumberExtents{T}"/> with <see cref="NumberExtents{T}.First"/> equal to <paramref name="first"/>.</returns>
    public static NumberExtents<T> WithFirst<T>(this NumberExtents<T> current, T first) where T : INumber<T>, IMinMaxValue<T>
    {
        if (first > current.Last) throw new ArgumentOutOfRangeException(nameof(first));
        return new(first, current.Last);
    }

    /// <summary>
    /// Creates new <see cref="NumberExtents{T}"/> with a new <see cref="NumberExtents{T}.First"/> extent value.
    /// </summary>
    /// <param name="current">The current extents.</param>
    /// <param name="last">The new last extent value.</param>
    /// <returns>A new <see cref="NumberExtents{T}"/> object.</returns>
    public static NumberExtents<T> WithLast<T>(this NumberExtents<T> current, T last) where T : INumber<T>, IMinMaxValue<T>
    {
        if (last < current.First) throw new ArgumentOutOfRangeException(nameof(last));
        return new(current.First, last);
    }

    /// <summary>
    /// Tests whether a value of <typeparamref name="T"/> is more than 1 increment greater than a given <see cref="NumberExtents{T}"/>.
    /// </summary>
    /// <param name="current">The target value.</param>
    /// <param name="extents">The extent to compare to.</param>
    /// <returns><see langword="true"/> if <paramref name="current"/> - <see cref="INumberBase{T}.One"/> is greater than <see cref="NumberExtents{T}.Last"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool FollowsNonAdjacent<T>(this T current, NumberExtents<T> extents) where T : INumber<T>, IMinMaxValue<T> => current != T.MinValue && (current - T.One) > extents.Last;

    /// <summary>
    /// Tests whether a value of <typeparamref name="T"/> is not more than 1 increment greater than a given <see cref="NumberExtents{T}"/>.
    /// </summary>
    /// <param name="current">The target value.</param>
    /// <param name="extents">The extent to compare to.</param>
    /// <returns><see langword="true"/> if <paramref name="current"/> - <see cref="INumberBase{T}.One"/> is not greater than <see cref="NumberExtents{T}.Last"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool AdjacentOrDoesNotFollow<T>(this T current, NumberExtents<T> extents) where T : INumber<T>, IMinMaxValue<T> => current == T.MinValue || (current - T.One) <= extents.Last;

    /// <summary>
    /// Tests whether a value of <typeparamref name="T"/> is more than 1 increment less than a given <see cref="NumberExtents{T}"/>.
    /// </summary>
    /// <param name="current">The target value.</param>
    /// <param name="extents">The extent to compare to.</param>
    /// <returns><see langword="true"/> if <paramref name="current"/> + <see cref="INumberBase{T}.One"/> is less than <see cref="NumberExtents{T}.First"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool PrecedesNonAdjacent<T>(this T current, NumberExtents<T> extents) where T : INumber<T>, IMinMaxValue<T> => current != T.MaxValue && (current + T.One) < extents.First;

    /// <summary>
    /// Tests whether a value of <typeparamref name="T"/> is not more than 1 increment less than a given <see cref="NumberExtents{T}"/>.
    /// </summary>
    /// <param name="current">The target value.</param>
    /// <param name="extents">The extent to compare to.</param>
    /// <returns><see langword="true"/> if <paramref name="current"/> + <see cref="INumberBase{T}.One"/> is not less than <see cref="NumberExtents{T}.First"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool AdjacentOrDoesNotPrecede<T>(this T current, NumberExtents<T> extents) where T : INumber<T>, IMinMaxValue<T> => current == T.MaxValue || (current + T.One) >= extents.First;

    /// <summary>
    /// Tests whether the current <see cref="NumberExtents{T}"/> is at least 2 increments greater than a value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="current">The target number extent.</param>
    /// <param name="value">The value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> + <see cref="INumberBase{T}.One"/> is less than <see cref="NumberExtents{T}.First"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool FollowsNonAdjacent<T>(this NumberExtents<T> current, T value) where T : INumber<T>, IMinMaxValue<T> => value != T.MaxValue && (value + T.One) < current.First;

    /// <summary>
    /// Tests whether the current <see cref="NumberExtents{T}"/> is not more than 1 increment greater than a value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="current">The target number extent.</param>
    /// <param name="value">The value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> + <see cref="INumberBase{T}.One"/> is not less than <see cref="NumberExtents{T}.Last"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool AdjacentOrDoesNotFollow<T>(this NumberExtents<T> current, T value) where T : INumber<T>, IMinMaxValue<T> => value == T.MaxValue || (value + T.One) >= current.First;

    /// <summary>
    /// Tests whether the current <see cref="NumberExtents{T}"/> is at least 2 increments less than a value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="current">The target number extent.</param>
    /// <param name="value">The value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> - <see cref="INumberBase{T}.One"/> is greater than <see cref="NumberExtents{T}.Last"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool PrecedesNonAdjacent<T>(this NumberExtents<T> current, T value) where T : INumber<T>, IMinMaxValue<T> => value != T.MinValue && (value - T.One) > current.Last;

    /// <summary>
    /// Tests whether the current <see cref="NumberExtents{T}"/> is not more than 1 increment less than a value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="current">The target number extent.</param>
    /// <param name="value">The value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> - <see cref="INumberBase{T}.One"/> is not greater than <see cref="NumberExtents{T}.Last"/>; othwerwise, <see langword="false"/>.</returns>
    public static bool AdjacentOrDoesNotPrecede<T>(this NumberExtents<T> current, T value) where T : INumber<T>, IMinMaxValue<T> => value == T.MinValue || (value - T.One) <= current.Last;
}

/// <summary>
/// Represents the extents of a range of numbers.
/// </summary>
/// <typeparam name="T">The type of numbers represented.</typeparam>
/// <remarks>The explicitly-defined <see cref=" IReadOnlyCollection{T}.Count"/> property calls <see cref="INumberBase{TSelf}.CreateSaturating{TOther}(TOther)"/>
/// to convert the results from <see cref="GetCount()"/> to an integer value.</remarks>
public readonly struct NumberExtents<T> : IEquatable<NumberExtents<T>>, IComparable<NumberExtents<T>>, IComparable, IReadOnlyCollection<T>
    where T : INumber<T>, IMinMaxValue<T>
{
    private static readonly Func<T, T, string> _toString;

    static NumberExtents()
    {
        if (typeof(T) == typeof(char))
            _toString = (f, l) => f.Equals(l) ? $"{{U+{int.CreateChecked(f):x4}}}" : $"{{U+{int.CreateChecked(f):x4}..U+{int.CreateChecked(l):x4}}}";
        else
            _toString = (f, l) => f.Equals(l) ? $"{{{f}}}" : $"{{{f}..{l}}}";
    }

    /// <summary>
    /// Gets the maximum range of values.
    /// </summary>
    /// <returns>A <see cref="NumberExtents{T}"/> value where <see cref="First"/> is <see cref="IMinMaxValue{TSelf}.MinValue"/> and <see cref="Last"/> is <see cref="IMinMaxValue{TSelf}.MaxValue"/>.</returns>
    public static NumberExtents<T> MaxExtents { get; } = new(T.MinValue, T.MaxValue);

    /// <summary>
    /// Gets the inclusive starting value for this range of values.
    /// </summary>
    /// <value>The lowest extent value for the current <see cref="NumberExtents{T}"/>.</value>
    public T First { get; }

    /// /// <summary>
    /// Gets the inclusive ending value for this range of values.
    /// </summary>
    /// <value>The highest extent value for the current <see cref="NumberExtents{T}"/>.</value>
    public T Last { get; }

    int IReadOnlyCollection<T>.Count => int.CreateSaturating(GetCount());

    /// <summary>
    /// Creates a new <c>NumberExtents&lt;c&gt;</c> object.
    /// </summary>
    /// <param name="first">The lowest extent value.</param>
    /// <param name="last">The higest extent value.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="first"/> is greater than <paramref name="last"/>.</exception>
    public NumberExtents(T first, T last)
    {
        if (first > last) throw new ArgumentOutOfRangeException(nameof(first));
        First = first;
        Last = last;
    }

    /// <summary>
    /// Creates a new <c>NumberExtents&lt;c&gt;</c> object with only one value.
    /// </summary>
    /// <param name="number">The value for the lowest and highest extent values.</param>
    public NumberExtents(T number)
    {
        First = Last = number;
    }

    /// <summary>
    /// Gets all values covered by the current extents in forward order.
    /// </summary>
    /// <returns>All sequential values from the <see cref="First"/>, up to and including the <see cref="Last"/> value.</returns>
    public IEnumerable<T> AsEnumerable()
    {
        for (var value = First; value < Last; value++)
            yield return value;
        yield return Last;
    }

    /// <summary>
    /// Compares the current extents with another and returns an integer that indicates whether the current object precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="other">A <see cref="NumberExtents{T}"/> to compare to.</param>
    /// <returns>Less than <c>0</c> if the current extents is less than the other object; greater than <c>0</c> if the other object is greater;
    /// otherwise <c>0</c> if both extents are equal.</returns>
    public int CompareTo(NumberExtents<T> other)
    {
        int diff = First.CompareTo(other.First);
        return (diff == 0) ? Last.CompareTo(other.Last) : diff;
    }

    int IComparable.CompareTo(object? obj) => (obj is null) ? 1 : (obj is NumberExtents<T> other) ? CompareTo(other) : -1;

    /// <summary>
    /// Gets a value indicating whether a specified value is covered by the current extents.
    /// </summary>
    /// <param name="number">The value to check.</param>
    /// <returns><see langword="true"/> if the specified <paramref name="number"/> not less than the <see cref="First"/> extent and not greater than <see cref="Last"/>; otherwise, <see langword="false"/>.</returns>
    public bool Contains(T number)
    {
        int result = First.CompareTo(number);
        return result == 0 || (result < 0 && number <= Last);
    }

    /// <summary>
    /// Gets a value indicating whether a number immediately precedes the <see cref="First"/> extent value.
    /// </summary>
    /// <param name="number">The number to compare.</param>
    /// <returns><see langword="true"/> if the specified <paramref name="number"/> is exactly one increment less than the <see cref="First"/> extent; otherwise, <see langword="false"/>.</returns>
    public bool ImmediatelyFollows(T number) => number < First && ++number == First;

    /// <summary>
    /// Gets a value indicating whether a number immediately follows the <see cref="Last"/> extent value.
    /// </summary>
    /// <param name="number">The number to compare.</param>
    /// <returns><see langword="true"/> if the specified <paramref name="number"/> is exactly one increment greater than the <see cref="Last"/> extent; otherwise, <see langword="false"/>.</returns>
    public bool ImmediatelyPrecedes(T number) => number > Last && --number == Last;

    /// <summary>
    /// Gets a value indicating whetehr a number is less than the <see cref="First"/> extent value.
    /// </summary>
    /// <param name="number">The number to compare.</param>
    /// <returns><see langword="true"/> if the specified <paramref name="number"/> is less than the <see cref="First"/> extent value; otherwise, <see langword="false"/>.</returns>
    public bool IsBefore(T number) => number > Last;

    /// <summary>
    /// Gets a value indicating whetehr a number is more than one increment less than the <see cref="First"/> extent value.
    /// </summary>
    /// <param name="number">The number to compare.</param>
    /// <returns><see langword="true"/> if the specified <paramref name="number"/> is at least 2 increments less than the <see cref="First"/> extent value; otherwise, <see langword="false"/>.</returns>
    public bool IsMoreThanOneAfter(T number) => number < First && ++number < First;

    /// /// <summary>
    /// Gets a value indicating whetehr a number is greater than the <see cref="Last"/> extent value.
    /// </summary>
    /// <param name="number">The number to compare.</param>
    /// <returns><see langword="true"/> if the specified <paramref name="number"/> is greater than the <see cref="Last"/> extent value; otherwise, <see langword="false"/>.</returns>
    public bool IsAfter(T number) => number < First;

    /// <summary>
    /// Gets a value indicating whetehr a number is more than one increment greater than the <see cref="Last"/> extent value.
    /// </summary>
    /// <param name="number">The number to compare.</param>
    /// <returns><see langword="true"/> if the specified <paramref name="number"/> is at least 2 increments greater than the <see cref="Last"/> extent value; otherwise, <see langword="false"/>.</returns>
    public bool IsMoreThanOneBefore(T number) => number > Last && --number > Last;

    /// <summary>
    /// Compares the current extents with another and returns a value indicating if they are equal.
    /// </summary>
    /// <param name="other">A <see cref="NumberExtents{T}"/> to compare to.</param>
    /// <returns><see langword="true"/> if <paramref name="other"/> is the same as the current extents; otherwise, <see langword="false"/>.</returns>
    public bool Equals(NumberExtents<T> other) => First == other.First && Last == other.Last;

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is NumberExtents<T> other && Equals(other);

    /// <summary>
    /// Gets the count of numbers from the <see cref="First"/> value, up to and including the <see cref="Last"/> value.
    /// </summary>
    /// <returns>The value of <see cref="First"/> subtracted from <see cref="Last"/>, plus <c>1</c>.</returns>
    public BigInteger GetCount() => BigInteger.CreateSaturating(Last - First) + BigInteger.One;

    /// <summary>
    /// Returns a value indicating how a specified number relates to the current extents.
    /// </summary>
    /// <param name="number">The number to compare.</param>
    /// <returns>A <see cref="ExtentValueRelativity"/> value indicating how the specified <paramref name="number"/> relates to the current extents.</returns>
    public ExtentValueRelativity GetRelationOf(T number)
    {
        int diff = number.CompareTo(First);
        if (diff == 0) return ExtentValueRelativity.Includes;
        if (diff < 0)
            return (++number == First) ? ExtentValueRelativity.ImmediatelyFollows : ExtentValueRelativity.FollowsWithGap;
        return (number <= Last) ? ExtentValueRelativity.Includes : (--number == Last) ? ExtentValueRelativity.ImmediatelyPrecedes : ExtentValueRelativity.PrecedesWithGap;
    }

    /// <summary>
    /// Returns a value indicating how the current extents relates to another.
    /// </summary>
    /// <param name="other">The extents to compare to.</param>
    /// <returns>A <see cref="ExtentRelativity"/> value indicating how the current extents relates to another extent pair.</returns>
    public ExtentRelativity GetRelationTo(NumberExtents<T> other) => GetRelationTo(other.First, other.Last);

    /// <summary>
    /// Returns a value indicating how the current extents relates to another.
    /// </summary>
    /// <param name="first">The inclusive first value extent.</param>
    /// <param name="last">The inclusive last value extent.</param>
    /// <returns>A <see cref="ExtentRelativity"/> value indicating how the current extents relates to another extent pair.</returns>
    public ExtentRelativity GetRelationTo(T first, T last)
    {
        int diff = Last.CompareTo(first);
        if (diff < 0)
            return ((Last + T.One) == first) ? ExtentRelativity.ImmediatelyPrecedes : ExtentRelativity.PrecedesWithGap;
        if (diff == 0)
        {
            if (First == Last)
                return (Last == last) ? ExtentRelativity.EqualTo : ExtentRelativity.ContainedBy;
            return (first == last) ? ExtentRelativity.Contains : ExtentRelativity.Overlaps;
        }
        if ((diff = Last.CompareTo(last)) < 0)
            return (First < first) ? ExtentRelativity.Overlaps : ExtentRelativity.ContainedBy;
        if (diff == 0)
            return ((diff = First.CompareTo(first)) == 0) ? ExtentRelativity.EqualTo : (diff < 0) ? ExtentRelativity.Contains : ExtentRelativity.ContainedBy;
        if (First < first) return ExtentRelativity.Contains;
        if (last < First)
            return ((First - T.One) == last) ? ExtentRelativity.ImmediatelyFollows : ExtentRelativity.FollowsWithGap;
        return (First == first) ? ExtentRelativity.Contains : ExtentRelativity.Overlaps;
    }

    /// <summary>
    /// Gets all values covered by the current extents in reverse order.
    /// </summary>
    /// <returns>All sequential values in reverse order, starting from the <see cref="Last"/>, down to and including the <see cref="First"/> value.</returns>
    public IEnumerable<T> Reverse()
    {
        for (var value = Last; value > First; value--)
            yield return value;
        yield return First;
    }

    /// <summary>
    /// Gets an enumerator that iterates through all the values covered by the current extents.
    /// </summary>
    /// <returns>An enumerator that iterates through all sequential values from the <see cref="First"/>, up to and including the <see cref="Last"/> value.</returns>
    public IEnumerator<T> GetEnumerator() => AsEnumerable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override int GetHashCode() => HashCode.Combine(First, Last);

    /// <summary>
    /// Gets a value indicating whether the current extents covers only one value.
    /// </summary>
    /// <returns><see langword="true"/> if <see cref="First"/> is equal to <see cref="Last"/>; otherwise, <see langword="false"/> to indicate that <see cref="Last"/> is greater than <see cref="First"/>.</returns>
    public bool IsSingleValue() => First == Last;

    public override string ToString() => _toString(First, Last);

    public static bool operator ==(NumberExtents<T> left, NumberExtents<T> right) => left.Equals(right);

    public static bool operator !=(NumberExtents<T> left, NumberExtents<T> right) => !(left == right);

    public static bool operator <(NumberExtents<T> left, NumberExtents<T> right) => left.CompareTo(right) < 0;

    public static bool operator <=(NumberExtents<T> left, NumberExtents<T> right) => left.CompareTo(right) <= 0;

    public static bool operator >(NumberExtents<T> left, NumberExtents<T> right) => left.CompareTo(right) > 0;

    public static bool operator >=(NumberExtents<T> left, NumberExtents<T> right) => left.CompareTo(right) >= 0;
}
