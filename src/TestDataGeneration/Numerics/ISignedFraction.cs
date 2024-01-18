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

[Obsolete("Use ISignedFraction<TSelf, TFractional, TMixed, TFraction>")]
public interface ISignedFraction<TSelf, TFractional, TWholeNumber, TMixed, TFraction> : IConvertible, IBinaryNumber<TSelf>, IMinMaxValue<TSelf>,
        IFraction<TSelf, TFractional, TWholeNumber, TMixed, TFraction>
    where TSelf : ISignedFraction<TSelf, TFractional, TWholeNumber, TMixed, TFraction>?
    where TFractional : IBinaryNumber<TFractional>, ISignedNumber<TFractional>
    where TWholeNumber : IBinaryNumber<TWholeNumber>, ISignedNumber<TWholeNumber>
    where TMixed : IMixedSignedFraction<TMixed, TFractional, TWholeNumber, TFraction>?
    where TFraction : ISimpleSignedFraction<TFraction, TFractional, TWholeNumber, TMixed>?
{ }
