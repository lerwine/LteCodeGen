using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISignedBinaryDenomination<TSelf, TFloatingPoint, TWholeValue> : ISignedFraction<TSelf, TFloatingPoint>,
        IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : ISignedBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : IBinaryNumber<TWholeValue>, ISignedNumber<TWholeValue>
{ }
