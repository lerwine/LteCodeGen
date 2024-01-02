namespace TestDataGeneration;

public class LinkedSetInsertEventArgs<T> : LinkedSetChangingEventArgs<T> where T : LinkedSet<T>.Node, IComparable<T>, IEquatable<T>, ICloneable
{
    public T? Previous { get; }

    public T? Next { get; }

    public LinkedSetInsertEventArgs(LinkedSet<T> container, T target, T refNode, bool refNodeIsPrevious) : base(container, target)
    {
        if (refNodeIsPrevious)
            Next = (Previous = refNode).Next;
        else
            Previous = (Next = refNode).Previous;
    }

    public LinkedSetInsertEventArgs(LinkedSet<T> container, T target) : base(container, target)
    {
        Previous = container.Last;
    }
}
