using System.Numerics;

namespace TestDataGeneration.Numerics;

/// <summary>
/// Interface for values representing signed fractions with a whole number.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The value type for the <see cref="IFraction{TSelf, TValue}.Numerator"/>, <see cref="IFraction{TSelf, TValue}.Denominator"/>,
/// and <see cref="IMixedFraction{TSelf, TValue}.WholeNumber"/>.</typeparam>
public interface IMixedSignedFraction<TSelf, TValue> : ISignedFraction<TSelf, TValue>, IMixedFraction<TSelf, TValue>
    where TSelf : struct, IMixedSignedFraction<TSelf, TValue>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
{ }

/// <summary>
/// Interface for values representing signed fractions with a whole number.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TValue">The value type for the <see cref="IFraction{TSelf, TValue}.Numerator"/>, <see cref="IFraction{TSelf, TValue}.Denominator"/>,
/// and <see cref="IMixedSignedFraction{TSelf, TValue}.WholeNumber"/>.</typeparam>
/// <typeparam name="TFraction">The <see cref="ISimpleSignedFraction{TFraction, TValue, TSelf}"/> type with the same numerator and denominator type.</typeparam>
public interface IMixedSignedFraction<TSelf, TValue, TFraction> : ISignedFraction<TSelf, TValue, TSelf, TFraction>, IMixedSignedFraction<TSelf, TValue>,
        IMixedFraction<TSelf, TValue, TFraction>
    where TSelf : struct, IMixedSignedFraction<TSelf, TValue, TFraction>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
    where TFraction : struct, ISimpleSignedFraction<TFraction, TValue, TSelf>?
{ }
