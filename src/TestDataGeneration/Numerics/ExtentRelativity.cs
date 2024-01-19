namespace TestDataGeneration.Numerics;

/// /// <summary>
/// Indicates how one <see cref="NumberExtents{T}"/> value relates to a another <see cref="NumberExtents{T}"/> value.
/// </summary>
public enum ExtentRelativity
{
    /// <summary>
    /// The <see cref="NumberExtents{T}.Last"/> value of the current <see cref="NumberExtents{T}"/> is more than one increment less than the <see cref="NumberExtents{T}.First"/> value of the other.
    /// </summary>
    PrecedesWithGap,

    /// <summary>
    /// The <see cref="NumberExtents{T}.Last"/> value of the current <see cref="NumberExtents{T}"/> is exactly one increment less than the <see cref="NumberExtents{T}.First"/> value of the other.
    /// </summary>
    ImmediatelyPrecedes,

    /// <summary>
    /// Both extent values share the same number values, and both also have values that are not included by each other.
    /// </summary>
    Overlaps,

    /// <summary>
    /// All number values in the other extent are included in the current extent, while both corresponding extent values are not equal.
    /// </summary>
    Contains,

    /// <summary>
    /// All number values in the current extent are included in the other extent, while both corresponding extent values are not equal.
    /// </summary>
    ContainedBy,

    /// <summary>
    /// The current extents include the exact same number values as the other extents.
    /// </summary>
    EqualTo,

    /// <summary>
    /// The <see cref="NumberExtents{T}.First"/> value of the current <see cref="NumberExtents{T}"/> is exactly one increment greater than the <see cref="NumberExtents{T}.Last"/> value of the other.
    /// </summary>
    ImmediatelyFollows,

    /// <summary>
    /// The <see cref="NumberExtents{T}.First"/> value of the current <see cref="NumberExtents{T}"/> is more than one increment greater than the <see cref="NumberExtents{T}.Last"/> value of the other.
    /// </summary>
    FollowsWithGap
}
