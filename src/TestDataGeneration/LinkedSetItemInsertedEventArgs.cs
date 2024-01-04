namespace TestDataGeneration;

public class LinkedSetItemInsertedEventArgs<T> : EventArgs where T : LinkedSet<T>.Node, IComparable<T>, IEquatable<T>, ICloneable
{
    public LinkedSet<T> Container { get; }
    
    public T Target { get; }

    public LinkedSetItemInsertedEventArgs(LinkedSet<T> container, T target)
    {
        Container = container;
        Target = target;
    }
}
