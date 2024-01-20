using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISignedBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue> : ISimpleSignedFraction<TSelf, TFloatingPoint>,
        ISignedBinaryDenomination<TSelf, TFloatingPoint, TWholeValue>,
        IBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue>
    where TSelf : struct, ISignedBinaryDenominationResult<TSelf, TFloatingPoint, TWholeValue>?
    where TFloatingPoint : struct, IBinaryNumber<TFloatingPoint>, IFloatingPoint<TFloatingPoint>, ISignedNumber<TFloatingPoint>
    where TWholeValue : struct, IBinaryNumber<TWholeValue>, ISignedNumber<TWholeValue>
{ }
