using System.Numerics;

namespace TestDataGeneration;

/// <summary>
/// Represents the extents of a sequential range of values.
/// </summary>
/// <typeparam name="T">The value type.</typeparam>
public interface IRangeExtents<T> : IEnumerable<T>, IEquatable<IRangeExtents<T>> where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
{
    /// <summary>
    /// Gets the starting value for the range.
    /// </summary>
    /// <value>The inclusive starting value of the range.</value>
    /// <remarks>This value will always be less than or equal to <see cref="End"/>.</remarks>
    T Start { get; }

    /// <summary>
    /// Gets the ending value for the range.
    /// </summary>
    /// <value>The inclusive range ending value.</value>
    /// <remarks>This value will always be greater than or equal to <see cref="End"/>.</remarks>
    T End { get; }

    /// <summary>
    /// Gets a value indicating whether the extents encompass more than one value.
    /// </summary>
    /// <value><see langword="true"/> if <see cref="Start"/> is less than <see cref="End"/>; otherwise, <see langword="false"/>.</value>
    bool IsMultiValue { get; }

    /// <summary>
    /// Gets a value indicating whether the extents cover the minimum and maximum possible values.
    /// </summary>
    /// <value><see langword="true"/> if <see cref="Start"/> is equal to <see cref="IMinMaxValue{T}.MinValue"/> and <see cref="End"/> is equal to <see cref="IMinMaxValue{T}.MaxValue"/>;
    /// otherwise, <see langword="false"/>.</value>
    bool IsMaxRange { get; }
}