using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface IBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue> : ISimpleFraction<TSelf, TFloatingPoint>,
        IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : struct, IBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : struct, IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : struct, IBinaryNumber<TWholeValue>
{ }
