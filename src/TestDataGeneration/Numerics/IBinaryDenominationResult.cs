using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface IBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue> : ISimpleFraction<TSelf, TFloatingPoint>,
        IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : IBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : IBinaryNumber<TWholeValue>
{ }
