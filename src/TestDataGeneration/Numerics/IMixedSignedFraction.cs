using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface IMixedSignedFraction<TSelf, TValue> : ISignedFraction<TSelf, TValue>, IMixedFraction<TSelf, TValue>
    where TSelf : IMixedSignedFraction<TSelf, TValue>?
    where TValue : IBinaryNumber<TValue>, ISignedNumber<TValue>
{ }

public interface IMixedSignedFraction<TSelf, TValue, TFraction> : ISignedFraction<TSelf, TValue, TSelf, TFraction>, IMixedSignedFraction<TSelf, TValue>,
        IMixedFraction<TSelf, TValue, TFraction>
    where TSelf : IMixedSignedFraction<TSelf, TValue, TFraction>?
    where TValue : IBinaryNumber<TValue>, ISignedNumber<TValue>
    where TFraction : ISimpleSignedFraction<TFraction, TValue, TSelf>?
{ }

[Obsolete("Use IMixedSignedFraction<TSelf, TFractional, TFraction>")]
public interface IMixedSignedFraction<TSelf, TFractional, TWholeNumber, TFraction> : ISignedFraction<TSelf, TFractional, TWholeNumber, TSelf, TFraction>,
        IMixedFraction<TSelf, TFractional, TWholeNumber, TFraction>
    where TSelf : IMixedSignedFraction<TSelf, TFractional, TWholeNumber, TFraction>?
    where TFractional : IBinaryNumber<TFractional>, ISignedNumber<TFractional>
    where TWholeNumber : IBinaryNumber<TWholeNumber>, ISignedNumber<TWholeNumber>
    where TFraction : ISimpleSignedFraction<TFraction, TFractional, TWholeNumber, TSelf>?
{ }
