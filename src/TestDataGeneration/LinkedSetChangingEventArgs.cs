namespace TestDataGeneration;

public class LinkedSetChangingEventArgs<T> : EventArgs where T : LinkedSet<T>.Node, IComparable<T>, IEquatable<T>, ICloneable
{
    public LinkedSet<T> Container { get; }
    
    public T Target { get; }

    public bool CanInsert { get; set; } = true;

    public LinkedSetChangingEventArgs(LinkedSet<T> container, T target)
    {
        Container = container;
        Target = target;
    }
}
