using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISignedBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue> : ISimpleSignedFraction<TSelf, TFloatingPoint>,
        ISignedBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>,
        IBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : ISignedBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : IBinaryNumber<TWholeValue>, ISignedNumber<TWholeValue>
{ }