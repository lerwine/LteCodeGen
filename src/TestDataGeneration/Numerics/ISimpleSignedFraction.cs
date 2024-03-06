using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Interface for values representing simple signed fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations.</typeparam>
public interface ISimpleSignedFraction<TSelf, TValue> : ISignedFraction<TSelf, TValue>, ISimpleFraction<TSelf, TValue>
    where TSelf : struct, ISimpleSignedFraction<TSelf, TValue>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
{ }

/// <summary>
/// Interface for values representing simple signed fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations.</typeparam>
/// <typeparam name="TMixed">The <see cref="IMixedFraction{TSelf, TValue, TFraction}"/> type that shares the same value type.</typeparam>
public interface ISimpleSignedFraction<TSelf, TValue, TMixed> : ISignedFraction<TSelf, TValue, TMixed, TSelf>, ISimpleSignedFraction<TSelf, TValue>,
        ISimpleFraction<TSelf, TValue, TMixed>
    where TSelf : struct, ISimpleSignedFraction<TSelf, TValue, TMixed>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
    where TMixed : struct, IMixedSignedFraction<TMixed, TValue, TSelf>?
{ }
