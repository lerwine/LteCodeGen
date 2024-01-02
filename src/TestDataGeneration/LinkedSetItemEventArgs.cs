namespace TestDataGeneration;

public class LinkedSetItemEventArgs<T> : EventArgs where T : LinkedSet<T>.Node, IComparable<T>, IEquatable<T>, ICloneable
{
    public LinkedSet<T> Container { get; }
    
    public T Target { get; }

    public LinkedSetItemEventArgs(LinkedSet<T> container, T target)
    {
        Container = container;
        Target = target;
    }
}
