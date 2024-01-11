namespace TestDataGeneration;

/// <summary>
/// Sequential ordering methods and properties.
/// </summary>
/// <typeparam name="T">The type of value to be sequentially ordered.</typeparam>
public interface IRangeEvaluator<T> : IComparer<T>
    where T : struct
{
    /// <summary>
    /// Gets the maximum <typeparamref name="T"/> value.
    /// </summary>
    /// <value>The maximum value for type <typeparamref name="T"/>.</value>
    T MaxValue { get; }

    /// <summary>
    /// Gets the minimum <typeparamref name="T"/> value.
    /// </summary>
    /// <value>The minimum value for type <typeparamref name="T"/>.</value>
    T MinValue { get; }

    /// <summary>
    /// <summary>
    /// Gets the number of incremental values in the specified inclusive range of values.
    /// </summary>
    /// <param name="firstInclusive">The first inclusive value.</param>
    /// <param name="lastInclusive">The last inclusive value.</param>
    /// <returns>The difference between <paramref name="firstInclusive"/> and <paramref name="lastInclusive"/> plus one or zero if <paramref name="firstInclusive"/> is greater than <paramref name="lastInclusive"/>.</returns>
    ulong GetLongCountInRange(T firstInclusive, T lastInclusive);

    /// <summary>
    /// Gets an incremented value.
    /// </summary>
    /// <param name="value">The value to increment.</param>
    /// <param name="count">The number of times to increment the value, which defaults to <c>1<c>.</param>
    /// <returns>The <paramref name="value"/> incremented <paramref name="count"/> times.</returns>
    /// <exception cref="OverflowException"><paramref name="value"/> could not be incremented by <paramref name="count"/> because it would exceed <see cref="MaxValue"/>.</exception>
    T GetIncrementedValue(T value, int count = 1);

    /// <summary>
    /// Gets a decremented value.
    /// </summary>
    /// <param name="value">The value to decrement.</param>
    /// <param name="count">The number of times to decrement the value, which defaults to <c>1<c>.</param>
    /// <returns>The <paramref name="value"/> decremented <paramref name="count"/> times.</returns>
    /// <exception cref="OverflowException"><paramref name="value"/> could not be decremented by <paramref name="count"/> because it would exceed <see cref="MinValue"/>.</exception>
    T GetDecrementedValue(T value, int count = 1);

    /// <summary>
    /// Tests whether a value is within a specific inclusive range;
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <param name="start">The inclusive range start value.</param>
    /// <param name="end">The inclusive range end value.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is greater than or equal to <paramref name="start"/> is less than or equal to <paramref name="end"/>;
    /// otherwise, <see langword="false"/>.</returns>
    bool IsInRange(T value, T start, T end);

    /// <summary>
    /// Determines whether one value immediately precedes another.
    /// </summary>
    /// <param name="previousValue">The potential predecing value.</param>
    /// <param name="nextValue">The potential following value.</param>
    /// <returns><see langword="true"/> if <paramref name="previousValue"/> incremented once is equal to <paramref name="nextValue"/>; otherwise, <see langword="false"/>.</returns>
    bool IsSequentiallyAdjacent(T previousValue, T nextValue);

    /// <summary>
    /// Gets sequential within a specified inclusive range.
    /// </summary>
    /// <param name="firstInclusive">The first value to return.</param>
    /// <param name="lastInclusive">The last value to return.</param>
    /// <returns>All of the incremental values in order, starting from <paramref name="firstInclusive"/>, up to and including <paramref name="lastInclusive"/>.</returns>
    /// <remarks>If <paramref name="firstInclusive"/> is greater than <paramref name="lastInclusive"/>, this should return an empty <see cref="IEnumerable{T}"/>.</remarks>
    IEnumerable<T> GetSequentialValuesInRange(T firstInclusive, T lastInclusive);
}
