namespace TestDataGeneration;

public class LinkedSetItemInsertedEventArgs<T> : EventArgs where T : OrderedLinkedSet<T>.Node, IComparable<T>, IEquatable<T>, ICloneable
{
    public OrderedLinkedSet<T> Container { get; }
    
    public T Target { get; }

    public LinkedSetItemInsertedEventArgs(OrderedLinkedSet<T> container, T target)
    {
        Container = container;
        Target = target;
    }
}
