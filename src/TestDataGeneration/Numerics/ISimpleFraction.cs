using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface ISimpleFraction<TSelf, TValue> : IFraction<TSelf, TValue>
    where TSelf : ISimpleFraction<TSelf, TValue>?
    where TValue : IBinaryNumber<TValue>
{
    static abstract TSelf Add(TValue wholeNumber1, TSelf fraction1, TValue wholeNumber2, TSelf fraction2, out TValue sum);

    static abstract TSelf Subtract(TValue wholeMinuend, TSelf minuendFraction, TValue wholeSubtrahend, TSelf subtrahendFraction, out TValue difference);

    static abstract TSelf Multiply(TValue wholeMultiplier, TSelf multiplierFraction, TValue wholeMultiplicand, TSelf multiplicandFraction, out TValue product);

    static abstract TSelf Divide(TValue wholeDividend, TSelf dividendFraction, TValue wholeDivisor, TSelf divisorFraction, out TValue quotient);

    static abstract TSelf ToProperFraction(TSelf value, out TValue wholeNumber);

    static abstract TSelf ToProperSimplestForm(TSelf value, out TValue wholeNumber);
}

public interface ISimpleFraction<TSelf, TValue, TMixed> : IFraction<TSelf, TValue, TMixed, TSelf>, ISimpleFraction<TSelf, TValue>
    where TSelf : ISimpleFraction<TSelf, TValue, TMixed>?
    where TValue : IBinaryNumber<TValue>
    where TMixed : IMixedFraction<TMixed, TValue, TSelf>?
{
    TMixed Add(TValue wholeNumber1, TValue wholeNumber2, TSelf fraction2);

    static abstract TSelf Add(TMixed fraction1, TValue wholeNumber2, TSelf fraction2, out TValue sum);

    static abstract TSelf Add(TValue wholeNumber1, TSelf fraction1, TMixed fraction2, out TValue sum);

    TMixed Join(TValue wholeNumber);

    TMixed Subtract(TValue wholeMinuend, TValue wholeSubtrahend, TSelf subtrahendFraction);

    static abstract TSelf Subtract(TMixed minuend, TValue wholeSubtrahend, TSelf subtrahendFraction, out TValue difference);

    static abstract TSelf Subtract(TValue wholeMinuend, TSelf minuendFraction, TMixed subtrahend, out TValue difference);

    TMixed Multiply(TValue wholeMultiplier, TValue wholeMultiplicand, TSelf multiplicandFraction);

    static abstract TSelf Multiply(TMixed multiplier, TValue wholeMultiplicand, TSelf multiplicandFraction, out TValue product);

    static abstract TSelf Multiply(TValue wholeMultiplier, TSelf multiplierFraction, TMixed multiplicand, out TValue product);

    TMixed Divide(TValue wholeDividend, TValue wholeDivisor, TSelf divisorFraction);

    static abstract TSelf Divide(TMixed dividend, TValue wholeDivisor, TSelf divisorFraction, out TValue quotient);

    static abstract TSelf Divide(TValue wholeDividend, TSelf dividendFraction, TMixed divisor, out TValue quotient);

    static abstract TMixed ToProperFraction(TSelf value);

    static abstract TMixed ToProperSimplestForm(TSelf value);
}
