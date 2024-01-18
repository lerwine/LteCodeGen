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

[Obsolete("Use ISimpleFraction<TSelf, TValue, TMixed>")]
public interface ISimpleFraction<TSelf, TFractional, TWholeNumber, TMixed> : IFraction<TSelf, TFractional, TWholeNumber, TMixed, TSelf>
    where TSelf : ISimpleFraction<TSelf, TFractional, TWholeNumber, TMixed>?
    where TFractional : IBinaryNumber<TFractional>
    where TWholeNumber : IBinaryNumber<TWholeNumber>
    where TMixed : IMixedFraction<TMixed, TFractional, TWholeNumber, TSelf>?
{
    TMixed Add(TWholeNumber wholeNumber1, TWholeNumber wholeNumber2, TSelf fraction2);
    
    static abstract TSelf Add(TWholeNumber wholeNumber1, TSelf fraction1, TWholeNumber wholeNumber2, TSelf fraction2, out TWholeNumber sum);
    
    static abstract TSelf Add(TMixed fraction1, TWholeNumber wholeNumber2, TSelf fraction2, out TWholeNumber sum);
    
    static abstract TSelf Add(TWholeNumber wholeNumber1, TSelf fraction1, TMixed fraction2, out TWholeNumber sum);
    
    TMixed Join(TWholeNumber wholeNumber);

    TMixed Subtract(TWholeNumber wholeMinuend, TWholeNumber wholeSubtrahend, TSelf subtrahendFraction);
    
    static abstract TSelf Subtract(TWholeNumber wholeMinuend, TSelf minuendFraction, TWholeNumber wholeSubtrahend, TSelf subtrahendFraction, out TWholeNumber difference);
    
    static abstract TSelf Subtract(TMixed minuend, TWholeNumber wholeSubtrahend, TSelf subtrahendFraction, out TWholeNumber difference);
    
    static abstract TSelf Subtract(TWholeNumber wholeMinuend, TSelf minuendFraction, TMixed subtrahend, out TWholeNumber difference);
    
    TMixed Multiply(TWholeNumber wholeMultiplier, TWholeNumber wholeMultiplicand, TSelf multiplicandFraction);
    
    static abstract TSelf Multiply(TWholeNumber wholeMultiplier, TSelf multiplierFraction, TWholeNumber wholeMultiplicand, TSelf multiplicandFraction, out TWholeNumber product);
    
    static abstract TSelf Multiply(TMixed multiplier, TWholeNumber wholeMultiplicand, TSelf multiplicandFraction, out TWholeNumber product);
    
    static abstract TSelf Multiply(TWholeNumber wholeMultiplier, TSelf multiplierFraction, TMixed multiplicand, out TWholeNumber product);
    
    TMixed Divide(TWholeNumber wholeDividend, TWholeNumber wholeDivisor, TSelf divisorFraction);
    
    static abstract TSelf Divide(TWholeNumber wholeDividend, TSelf dividendFraction, TWholeNumber wholeDivisor, TSelf divisorFraction, out TWholeNumber quotient);
    
    static abstract TSelf Divide(TMixed dividend, TWholeNumber wholeDivisor, TSelf divisorFraction, out TWholeNumber quotient);
    
    static abstract TSelf Divide(TWholeNumber wholeDividend, TSelf dividendFraction, TMixed divisor, out TWholeNumber quotient);
    
    static abstract TSelf ToProperFraction(TSelf value, out TWholeNumber wholeNumber);

    static abstract TMixed ToProperFraction(TSelf value);

    static abstract TSelf ToProperSimplestForm(TSelf value, out TWholeNumber wholeNumber);

    static abstract TMixed ToProperSimplestForm(TSelf value);
}
