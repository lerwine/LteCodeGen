using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISimpleSignedFraction<TSelf, TValue> : ISignedFraction<TSelf, TValue>, ISimpleFraction<TSelf, TValue>
    where TSelf : struct, ISimpleSignedFraction<TSelf, TValue>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
{ }

public interface ISimpleSignedFraction<TSelf, TValue, TMixed> : ISignedFraction<TSelf, TValue, TMixed, TSelf>, ISimpleSignedFraction<TSelf, TValue>,
        ISimpleFraction<TSelf, TValue, TMixed>
    where TSelf : struct, ISimpleSignedFraction<TSelf, TValue, TMixed>?
    where TValue : struct, IBinaryNumber<TValue>, ISignedNumber<TValue>
    where TMixed : struct, IMixedSignedFraction<TMixed, TValue, TSelf>?
{ }
