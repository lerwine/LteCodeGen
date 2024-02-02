namespace TestDataGeneration.Numerics;

/// <summary>
/// Indicates how a number value relates to a specific <see cref="NumberExtents{T}"/> value.
/// </summary>
public enum ExtentValueRelativity
{
    /// <summary>
    /// The number value is less than the <see cref="NumberExtents{T}.First"/> extent by at least 2 increments.
    /// </summary>
    PrecedesWithGap,

    /// <summary>
    /// The number value is exactly one increment less than the <see cref="NumberExtents{T}.First"/> extent.
    /// </summary>
    ImmediatelyPrecedes,

    /// <summary>
    /// The number value is not less than the <see cref="NumberExtents{T}.First"/> extent and not greater than the <see cref="NumberExtents{T}.Last"/> extent.
    /// </summary>
    Includes,

    /// <summary>
    /// The number value is exactly one increment greater than the <see cref="NumberExtents{T}.Last"/> extent.
    /// </summary>
    ImmediatelyFollows,

    /// <summary>
    /// The number value is greater than the <see cref="NumberExtents{T}.Last"/> extent by at least 2 increments.
    /// </summary>
    FollowsWithGap
}