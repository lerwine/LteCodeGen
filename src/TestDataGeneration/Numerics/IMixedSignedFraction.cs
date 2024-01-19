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
