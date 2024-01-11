using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace TestDataGeneration;

public partial class LinkedCollectionBase<TNode> : IList, IHasChangeToken where TNode : LinkedCollectionBase<TNode>.LinkedNode
{
    private object _beforeChangeToken = new();
    private object _changeToken = new();

    object? IList.this[int index] { get => GetNodeAt(index); set => throw new NotSupportedException(); }

    public TNode? First { get; private set; }
    
    public TNode? Last { get; private set; }
    
    public int Count { get; private set; }
    
    protected virtual bool IsReadOnly { get; } = false;

    bool IList.IsReadOnly => IsReadOnly;

    bool IList.IsFixedSize => false;

    bool ICollection.IsSynchronized => true;

    public object SyncRoot { get; } = new();

    object IHasChangeToken.ChangeToken => _changeToken;

    bool IChangeTracking.IsChanged => !ReferenceEquals(_beforeChangeToken, _changeToken);

    protected void SetChanged()
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (ReferenceEquals(_beforeChangeToken, _changeToken)) _changeToken = new();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    void IChangeTracking.AcceptChanges()
    {
        Monitor.Enter(SyncRoot);
        try { _beforeChangeToken = _changeToken; }
        finally { Monitor.Exit(SyncRoot); }
    }

    protected virtual void AddFirst(TNode item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Monitor.Enter(SyncRoot);
        try { item.AddFirst(this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    protected virtual void AddLast(TNode item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Monitor.Enter(SyncRoot);
        try { item.AddLast(this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    protected virtual void InsertBefore(TNode item, TNode refItem)
    {
        ArgumentNullException.ThrowIfNull(item);
        ArgumentNullException.ThrowIfNull(refItem);
        Monitor.Enter(SyncRoot);
        try { LinkedNode.InsertBefore(item, refItem, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    protected virtual void InsertAfter(TNode item, TNode refItem)
    {
        ArgumentNullException.ThrowIfNull(item);
        ArgumentNullException.ThrowIfNull(refItem);
        Monitor.Enter(SyncRoot);
        try { LinkedNode.InsertAfter(item, refItem, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    int IList.Add(object? value) => throw new NotSupportedException();

    public virtual void Clear() => LinkedNode.Clear(this);

    public bool Contains(TNode item)
    {
        if (item is null) return false;
        Monitor.Enter(SyncRoot);
        try { return LinkedNode.Contains(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    bool IList.Contains(object? value) => value is TNode item && LinkedNode.Contains(item, this);

    void ICollection.CopyTo(Array array, int index) => ToList().ToArray().CopyTo(array, index);

    public List<TNode> ToList()
    {
        List<TNode> result = new();
        Monitor.Enter(SyncRoot);
        try
        {
            foreach (var node in GetAllNodes()) result.Add(node);
        }
        finally { Monitor.Exit(SyncRoot); }
        return result;
    }

    protected IEnumerable<TNode> GetAllNodes()
    {
        for (var node = First; node is not null; node = node.Next) yield return node;
    }

    public IEnumerator<TNode> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

    public TNode GetNodeAt(int index)
    {
        if (index >= 0)
        {
            Monitor.Enter(SyncRoot);
            try
            {
                int pos = -1;
                for (var node = First; node is not null; node = node.Next)
                {
                    pos++;
                    if (index == pos) return node;
                }
            }
            finally { Monitor.Exit(SyncRoot); }
        }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    protected int GetIndexOf(TNode item)
    {
        if (item is null) return -1;
        Monitor.Enter(SyncRoot);
        try { return LinkedNode.IndexOf(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    int IList.IndexOf(object? value)
    {
        if (value is not TNode item) return -1;
        Monitor.Enter(SyncRoot);
        try { return LinkedNode.IndexOf(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

    void IList.Remove(object? value) => throw new NotSupportedException();

    void IList.RemoveAt(int index)
    {
        var item = GetNodeAt(index);
        Monitor.Enter(SyncRoot);
        try { Unlink(item); }
        finally { Monitor.Exit(SyncRoot); }
    }

    protected virtual bool Unlink(TNode item)
    {
        if (item is null) return false;
        Monitor.Enter(SyncRoot);
        try { return LinkedNode.Unlink(item, this); }
        finally { Monitor.Exit(SyncRoot); }
    }
}
