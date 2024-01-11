namespace TestDataGeneration;

/// <summary>
/// Represents a range of values.
/// </summary>
/// <typeparam name="T">The value type</typeparam>
public interface IValueRange<T> : IEnumerable<T>, IEquatable<IValueRange<T>> where T : struct
{
    /// <summary>
    /// Gets the start value for the range.
    /// </summary>
    /// <value>The inclusive range starting value.</value>
    T Start { get; }

    /// <summary>
    /// Gets the end value for the range.
    /// </summary>
    /// <value>The inclusive range ending value.</value>
    T End { get; }

    /// <summary>
    /// Gets a value indicating whether this range has only one value.
    /// </summary>
    /// <value><see langword="true"/> if <see cref="Start"/> is equal to <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool IsSingleValue { get; }

    /// <summary>
    /// Gets a value indicating whether this range includes the minimum and maximum possible values.
    /// </summary>
    /// <value><see langword="true"/> if <see cref="Start"/> is equal to <see cref="IRangeSequenceAccessors{T}.MinValue"/> and <see cref="End"/> is equal to <see cref="IRangeSequenceAccessors{T}.MaxValue"/>;
    /// otherwise, <see langword="false"/>.</value>
    bool IsMaxRange { get; }

    /// <summary>
    /// Indicates whether a specified value falls within the current value range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is not less than <see cref="Start"/> and is not greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool Contains(T value);

    /// <summary>
    /// Indicates whether the specified range falls within the current value range.
    /// </summary>
    /// <param name="start">The inclusive starting range value.</param>
    /// <param name="end">The inclusive ending range value.</param>
    /// <value><see langword="true"/> if <paramref name="end"/> is not less than <see cref="Start"/> and <paramref name="start"/> is not greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool Contains(T start, T end);

    /// <summary>
    /// Indicates whether the current range is a single-value range matching a given value.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is equal to both <see cref="Start"/> and <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool Equals(T value);

    /// <summary>
    /// Indicates whether the current range matches start and end values.
    /// </summary>
    /// <param name="start">The inclusive starting range value.</param>
    /// <param name="end">The inclusive ending range value.</param>
    /// <value><see langword="true"/> if <paramref name="start"/> is equal to <see cref="Start"/> and <paramref name="end"/> is equal to <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool Equals(T start, T end);

    /// <summary>
    /// Indicates whether a specified value falls beyond the end of the current range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool Follows(T value);

    /// <summary>
    /// Indicates whether the specified range starts after the end of the current range.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <value><see langword="true"/> if the <see cref="Start"/> value of the given <paramref name="item"/> is greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool Follows(IValueRange<T> item);

    /// <summary>
    /// Indicates whether a specified value falls beyond the end of the current range by at least one additional increment.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is at least two greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool FollowsWithGap(T value);

    /// <summary>
    /// Indicates whether the specified range starts after the end of the current range with a gap between.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <value><see langword="true"/> if the <see cref="Start"/> value of the given <paramref name="item"/> is at least 2 increments greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool FollowsWithGap(IValueRange<T> item);

    /// <summary>
    /// Gets the number of sequential values in the current range.
    /// </summary>
    /// <returns>The number of sequential values starting from the <see cref="Start"/> value, up to and including the <see cref="End"/> value.</returns>
    /// <remarks>This will return <c>0UL</c> if <see cref="IsMaxRange"/> is <see langword="true"/> to accomodate 64-bit values.</remarks>
    ulong GetCount();

    /// <summary>
    /// Indicates whether the specified value is exactly one increment greater than the end of the current range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is exactly on increment greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool ImmediatelyFollows(T value);

    /// <summary>
    /// Indicates whether the range starts immediately after the end of the current range.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <value><see langword="true"/> if the <see cref="Start"/> value of the given <paramref name="item"/> is exactly on increment greater than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool ImmediatelyFollows(IValueRange<T> item);

    /// <summary>
    /// Indicates whether the specified value is exactly one increment lesser than the start of the current range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is exactly on increment lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</value>
    bool ImmediatelyPrecedes(T value);

    /// <summary>
    /// Indicates whether the range ends immediately before the start of the current range.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <value><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> is exactly on increment lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</value>
    bool ImmediatelyPrecedes(IValueRange<T> item);

    /// <summary>
    /// Indicates whether a given range overlaps the current range.
    /// </summary>
    /// <param name="item">The range to compare.</param>
    /// <value><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> not lesser than the current <see cref="Start"/> value,
    /// and the <see cref="Start"/> value of the given <paramref name="item"/> is not greater than the current <see cref="End"/> value; otherwise, <see langword="false"/>.</value>
    bool Overlaps(IValueRange<T> item);

    /// <summary>
    /// Indicates whether a given range of values overlaps the current range.
    /// </summary>
    /// <param name="start">The inclusive starting range value.</param>
    /// <param name="end">The inclusive ending range value.</param>
    /// <value><see langword="true"/> if the given <paramref name="end"/> value not lesser than the current <see cref="Start"/> value,
    /// and the given <paramref name="start"/> is not greater than the current <see cref="End"/> value; otherwise, <see langword="false"/>.</value>
    bool Overlaps(T start, T end);

    /// <summary>
    /// Indicates whether a specified value falls before the start of the current range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</value>
    bool Precedes(T value);

    /// <summary>
    /// Indicates whether the specified range ends before the start of the current range.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <value><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> is lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</value>
    bool Precedes(IValueRange<T> item);

    /// <summary>
    /// Indicates whether a specified value falls before the start of the current range by at least one additional increment.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <value><see langword="true"/> if <paramref name="value"/> is at least two lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</value>
    bool PrecedesWithGap(T value);

    /// <summary>
    /// Indicates whether the specified range starts before the start of the current range with a gap between.
    /// </summary>
    /// <param name="item">The range to check.</param>
    /// <value><see langword="true"/> if the <see cref="End"/> value of the given <paramref name="item"/> is at least 2 increments lesser than <see cref="Start"/>; otherwise, <see langword="false"/>.</value>
    bool PrecedesWithGap(IValueRange<T> item);
}