using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISignedFraction<TSelf, TValue> : IFraction<TSelf, TValue>
    where TSelf : ISignedFraction<TSelf, TValue>?
    where TValue : IBinaryNumber<TValue>, ISignedNumber<TValue>
{ }

public interface ISignedFraction<TSelf, TValue, TMixed, TFraction> : ISignedFraction<TSelf, TValue>, IFraction<TSelf, TValue, TMixed, TFraction>
    where TSelf : ISignedFraction<TSelf, TValue, TMixed, TFraction>?
    where TValue : IBinaryNumber<TValue>, ISignedNumber<TValue>
    where TMixed : IMixedSignedFraction<TMixed, TValue, TFraction>?
    where TFraction : ISimpleSignedFraction<TFraction, TValue, TMixed>?
{ }
