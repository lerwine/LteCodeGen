using System.Collections;

namespace TestDataGeneration;

public partial class LinkedSet<T> : ISet<T>, IReadOnlyList<T>, IList where T : LinkedSet<T>.Node, IComparable<T>, IEquatable<T>, ICloneable
{
    private object _changeToken = new();

    public event EventHandler<LinkedSetItemEventArgs<T>>? AfterInsert;

    public event EventHandler<LinkedSetItemDeletedEventArgs<T>>? AfterRemove;

    public event EventHandler<LinkedSetInsertEventArgs<T>>? BeforeInsert;

    public event EventHandler<LinkedSetChangingEventArgs<T>>? BeforeRemove;

    public T? First { get; private set; }

    public T? Last { get; private set; }

    T IReadOnlyList<T>.this[int index] => GetItemAt(index);

    object? IList.this[int index] { get => GetItemAt(index); set => throw new NotSupportedException(); }

    public int Count { get; private set; }

    bool ICollection<T>.IsReadOnly => true;

    bool IList.IsReadOnly => true;

    bool IList.IsFixedSize => false;

    bool ICollection.IsSynchronized => true;

    public object SyncRoot { get; } = new();

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

    public void ExceptWith(IEnumerable<T> other) => Node.ExceptWith(other, this);

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

    public void IntersectWith(IEnumerable<T> other) => Node.IntersectWith(other, this);

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    protected virtual void OnAfterInsert(LinkedSetItemEventArgs<T> args) => AfterInsert?.Invoke(this, args);
    
    protected virtual void OnAfterRemove(LinkedSetItemDeletedEventArgs<T> args) => AfterRemove?.Invoke(this, args);
    
    protected virtual void OnBeforeInsert(LinkedSetInsertEventArgs<T> args) => BeforeInsert?.Invoke(this, args);
    
    protected virtual void OnBeforeRemove(LinkedSetChangingEventArgs<T> args) => BeforeRemove?.Invoke(this, args);
    
    public bool Overlaps(IEnumerable<T> other)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    private void RaiseAfterInsert(T target) => OnAfterInsert(new(this, target));
    
    private void RaiseAfterRemove(T target, T refNode, bool refNodeIsPrevious = false) => OnAfterRemove(new(this, target, refNode, refNodeIsPrevious));
    
    private void RaiseAfterRemove(T target) => OnAfterRemove(new(this, target));
    
    private bool RaiseBeforeInsert(T target, T refNode, bool refNodeIsPrevious = false)
    {
        LinkedSetInsertEventArgs<T> args = new(this, target, refNode, refNodeIsPrevious);
        OnBeforeInsert(args);
        return args.CanInsert;
    }
    
    private bool RaiseBeforeInsert(T target)
    {
        LinkedSetInsertEventArgs<T> args = new(this, target);
        OnBeforeInsert(args);
        return args.CanInsert;
    }
    
    private bool RaiseBeforeRemove(T target)
    {
        LinkedSetChangingEventArgs<T> args = new(this, target);
        OnBeforeRemove(args);
        return args.CanInsert;
    }
    
    public bool Remove(T item) => item.Remove();

    void IList.Remove(object? value) => throw new NotSupportedException();

    void IList.RemoveAt(int index) => throw new NotSupportedException();

    public bool SetEquals(IEnumerable<T> other)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public void SymmetricExceptWith(IEnumerable<T> other) => Node.SymmetricExceptWith(other, this);

    public void UnionWith(IEnumerable<T> other) => Node.UnionWith(other, this);
}
