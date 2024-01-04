using System.Collections;

namespace TestDataGeneration;

public partial class OrderedLinkedSet<T> : ISet<T>, IReadOnlyList<T>, IList where T : OrderedLinkedSet<T>.Node, IComparable<T>, IEquatable<T>
{
    private object _changeToken = new();

    public event EventHandler<LinkedSetItemInsertedEventArgs<T>>? AfterInsert;

    public event EventHandler<LinkedSetItemDeletedEventArgs<T>>? AfterRemove;

    public T? First { get; private set; }

    public T? Last { get; private set; }

    T IReadOnlyList<T>.this[int index] => GetItemAt(index);

    object? IList.this[int index] { get => GetItemAt(index); set => throw new NotSupportedException(); }

    bool ICollection<T>.IsReadOnly => true;

    bool IList.IsReadOnly => true;

    bool IList.IsFixedSize => false;

    bool ICollection.IsSynchronized => true;

    public object SyncRoot { get; } = new();

    int ICollection<T>.Count => Count();

    int IReadOnlyCollection<T>.Count => Count();

    int ICollection.Count => Count();

    public bool Add(T item) => Node.Add(item, this);

    void ICollection<T>.Add(T item) => Add(item);

    int IList.Add(object? value) => throw new NotSupportedException();

    public void Clear() => Node.Clear(this);

    public bool Contains(T item)
    {
        if (item is null) return false;
        Monitor.Enter(SyncRoot);
        try { return Node.GetAllItems(this).Contains(item); }
        finally { Monitor.Exit(SyncRoot); }
    }

    bool IList.Contains(object? value)
    {
        if (value is T item)
        {
            Monitor.Enter(SyncRoot);
            try { return Node.GetAllItems(this).Contains(item); }
            finally { Monitor.Exit(SyncRoot); }
        }
        return false;
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        Monitor.Enter(SyncRoot);
        try { Node.GetAllItems(this).ToList().CopyTo(array, arrayIndex); }
        finally { Monitor.Exit(SyncRoot); }
    }

    void ICollection.CopyTo(Array array, int index)
    {
        Monitor.Enter(SyncRoot);
        try { Node.GetAllItems(this).ToArray().CopyTo(array, index); }
        finally { Monitor.Exit(SyncRoot); }
    }

    public int Count()
    {
            int result = 0;
        Monitor.Enter(SyncRoot);
        try
        {
            for (var item = First; item is not null; item = item.Next)
                result++;
        }
        finally { Monitor.Exit(SyncRoot); }
        return result;
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        var toDelete = this.Where(other.Contains).ToArray();
        foreach (var item in toDelete) Remove(item);
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

    public T GetItemAt(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        Monitor.Enter(SyncRoot);
        try
        {
            var item = ((index == 0) ? Node.GetAllItems(this) : Node.GetAllItems(this).Take(index)).FirstOrDefault();
            if (item is null) throw new ArgumentOutOfRangeException(nameof(index));
            return item;
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public int IndexOf(T item)
    {
        if (item is null) return -1;
        Monitor.Enter(SyncRoot);
        try
        {
            var items = Node.GetAllItems(this).TakeWhile(i => !i.Equals(item));
            if (items.Any()) return items.Count();
        }
        finally { Monitor.Exit(SyncRoot); }
        return -1;
    }

    int IList.IndexOf(object? value)
    {
        if (value is T item)
        {
            Monitor.Enter(SyncRoot);
            try
            {
                var items = Node.GetAllItems(this).TakeWhile(i => !i.Equals(item));
                if (items.Any()) return items.Count();
            }
            finally { Monitor.Exit(SyncRoot); }
        }
        return -1;
    }

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

    public void IntersectWith(IEnumerable<T> other)
    {
        foreach (T item in this)
            if (!other.Contains(item)) Remove(item);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other) => (First is null) ? other.Any() : Count() < other.Count() && !other.Any(item => !Contains(item));

    public bool IsProperSupersetOf(IEnumerable<T> other) => First is not null && Count() > other.Count() && !this.Any(item => other.Contains(item));

    public bool IsSubsetOf(IEnumerable<T> other) => Count() >= other.Count() && this.All(other.Contains);

    public bool IsSupersetOf(IEnumerable<T> other) => Count() <= other.Count() && other.All(Contains);

    protected virtual void OnAfterInsert(LinkedSetItemInsertedEventArgs<T> args) => AfterInsert?.Invoke(this, args);
    
    protected virtual void OnAfterRemove(LinkedSetItemDeletedEventArgs<T> args) => AfterRemove?.Invoke(this, args);
    
    public bool Overlaps(IEnumerable<T> other) => First is not null && other.Any(Contains);

    private void RaiseAfterInsert(T target) => OnAfterInsert(new(this, target));
    
    private void RaiseAfterRemove(T target, T refNode, bool refNodeIsPrevious = false) => OnAfterRemove(new(this, target, refNode, refNodeIsPrevious));
    
    private void RaiseAfterRemove(T target) => OnAfterRemove(new(this, target));
    
    public bool Remove(T item) => item.Remove();

    void IList.Remove(object? value) => throw new NotSupportedException();

    void IList.RemoveAt(int index) => throw new NotSupportedException();

    public bool SetEquals(IEnumerable<T> other) => Count() == other.Count() && other.All(Contains);

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        var toDelete = this.Where(other.Contains).ToArray();
        var toAdd = other.Where(item => !Contains(item)).ToArray();
        foreach (var item in toDelete) Remove(item);
        foreach (var item in toAdd) Add(item);
    }

    public void UnionWith(IEnumerable<T> other)
    {
        var toAdd = other.Where(item => !Contains(item)).ToArray();
        foreach (var item in toAdd) Add(item);
    }
}
