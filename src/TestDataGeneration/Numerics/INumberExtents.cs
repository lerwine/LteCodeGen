using System.Numerics;

namespace TestDataGeneration.Numerics;

public interface INumberExtents<TSelf, TElement> : IEquatable<TSelf>, IComparable<TSelf>, IComparable, IReadOnlyCollection<TElement>
    where TSelf : INumberExtents<TSelf, TElement>
    where TElement : IBinaryNumber<TElement>
{
    TElement First { get; }

    TElement Last { get; }

    BigInteger GetCount();

    bool IsSingleValue();

    static abstract TSelf MaxExtents { get; }
}
