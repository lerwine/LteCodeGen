namespace TestDataGeneration
{
    /// <summary>
    /// Interface for working with sequential values (aka. <see cref="int"/>, <see cref="byte"/>, etc.).
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <seealso cref="ValueRangeSet{T}.CharSequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.ByteSequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.SByteSequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.Int16SequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.UInt16SequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.Int32SequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.UInt32SequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.Int64SequentialValueAccessors"/>
    /// <seealso cref="ValueRangeSet{T}.UInt64SequentialValueAccessors"/>
    public interface ISequentalValueAccessors<T> : IEqualityComparer<T>, IComparer<T>
        where T : struct
    {
        /// <summary>
        /// The maximum <typeparamref name="T"/> value.
        /// </summary>
        T MaxValue { get; }

        /// <summary>
        /// The minimum <typeparamref name="T"/> value.
        /// </summary>
        T MinValue { get; }

        /// <summary>
        /// Returns a value decremented by 1.
        /// </summary>
        /// <param name="value">The original value.</param>
        /// <returns>The <paramref name="value"/> decremented by one.</returns>
        /// <param name="count">The optional number of positions to decrement by.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than <c>0</c>.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> could not be decremented because it reached or surpassed its minimum value
        /// or <paramref name="count"/> is too large to be converted to <typeparamref name="T"/>.</exception>
        T Decrement(T value, int count = 1);

        /// <summary>
        /// Gets the number of values in a specified range.
        /// </summary>
        /// <param name="rangeStart">The inclusive range start value.</param>
        /// <param name="rangeEnd">The inclusive range end value.</param>
        /// <returns>The number of values from <paramref name="rangeStart"/>, up to and including <paramref name="rangeEnd"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="rangeStart"/> is greater than <paramref name="rangeEnd"/>.</exception>
        int GetRangeCount(T rangeStart, T rangeEnd);

        /// <summary>
        /// Gets the values in a specified range.
        /// </summary>
        /// <param name="rangeStart">The first value to return.</param>
        /// <param name="rangeEnd">The value at which to stop yielding results.</param>
        /// <returns>All sequential values starting from <paramref name="rangeStart"/>, up to, but not including <paramref name="rangeEnd"/>.</returns>
        /// <remarks>It is expected that if <paramref name="rangeEnd"/> is not greater than <paramref name="rangeStart"/>, that an empty enumeration will be returned.</remarks>
        IEnumerable<T> GetValuesInRange(T rangeStart, T rangeEnd);

        /// <summary>
        /// Returns a value incremented by 1.
        /// </summary>
        /// <param name="value">The original value.</param>
        /// <param name="count">The optional number of positions to increment by.</param>
        /// <returns>The <paramref name="value"/> incremented by one.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than <c>0</c>.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> could not be incremented because it reached or surpassed its maximum value
        /// or <paramref name="count"/> is too large to be converted to <typeparamref name="T"/>.</exception>
        T Increment(T value, int count = 1);

        /// <summary>
        /// Tests whether a value is equal to or between 2 valuesl
        /// </summary>
        /// <param name="targetValue">The value to test.</param>
        /// <param name="rangeStart">The inclusive minimum value.</param>
        /// <param name="rangeEnd">The inclusive maximum value.</param>
        /// <returns><see langword="true"/> if <paramref name="targetValue"/> greater than or equal to <paramref name="rangeEnd"/>, and less than or equal to <paramref name="rangeEnd"/>;
        /// otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="rangeStart"/> is greater than <paramref name="rangeEnd"/>.</exception>
        bool IsInRange(T targetValue, T rangeStart, T rangeEnd);

        /// <summary>
        /// Gets a value whether s value is one more than another.
        /// </summary>
        /// <param name="precedingValue">The potential preceeding value.</param>
        /// <param name="nextValue">The potential next value.</param>
        /// <returns><see langword="true"/> if <paramref name="nextValue"/> is one increment higher than <paramref name="precedingValue"/>; otherwise, <see langword="false"/>.</returns>
        bool IsSequentiallyNext(T precedingValue, T nextValue);
    }
}