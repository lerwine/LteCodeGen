using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISignedBinaryDenomination<TSelf, TFloatingPoint, TWholeValue> : ISignedFraction<TSelf, TFloatingPoint>,
        IBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : struct, ISignedBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : struct, IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : struct, IBinaryNumber<TWholeValue>, ISignedNumber<TWholeValue>
{ }
