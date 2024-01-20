using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Base interface for values representing signed fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations</typeparam>
public interface ISignedFraction<TSelf, TValue> : IFraction<TSelf, TValue>
    where TSelf : struct, ISignedFraction<TSelf, TValue>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
{ }

/// <summary>
/// Base interface for values representing signed fractions.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The type of value for the <see cref="IFraction{TSelf, TValue}.Numerator"/>,
/// <see cref="IFraction{TSelf, TValue}.Denominator"/>, and whole number calculations</typeparam>
/// <typeparam name="TMixed">The <see cref="IMixedSignedFraction{TSelf, TFractional, TFraction}"/> type that shares the same value type.</typeparam>
/// <typeparam name="TFraction">The <see cref="ISimpleSignedFraction{TSelf, TValue, TMixed}"/> type that shares the same value type.</typeparam>
public interface ISignedFraction<TSelf, TValue, TMixed, TFraction> : ISignedFraction<TSelf, TValue>, IFraction<TSelf, TValue, TMixed, TFraction>
    where TSelf : struct, ISignedFraction<TSelf, TValue, TMixed, TFraction>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
    where TMixed : struct, IMixedSignedFraction<TMixed, TValue, TFraction>?
    where TFraction : struct, ISimpleSignedFraction<TFraction, TValue, TMixed>?
{ }
