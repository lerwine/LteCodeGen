using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public class NumberRangesList<T> : IReadOnlySet<NumberExtents<T>>, IReadOnlyList<NumberExtents<T>>, ICollection<NumberExtents<T>>, IList
    where T : IBinaryNumber<T>, IMinMaxValue<T>
{
    private readonly LinkedList<NumberExtents<T>> _backingList = new();

    public int Count => _backingList.Count;

    public object SyncRoot { get; } = new();

    bool ICollection<NumberExtents<T>>.IsReadOnly => false;

    bool IList.IsFixedSize => false;

    bool IList.IsReadOnly => true;

    bool ICollection.IsSynchronized => true;

    object? IList.this[int index] { get => GetItemAt(index); set => throw new NotSupportedException(); }

    NumberExtents<T> IReadOnlyList<NumberExtents<T>>.this[int index] => GetItemAt(index);

    public NumberRangesList(IEnumerable<NumberExtents<T>> collection)
    {
        throw new NotImplementedException();
    }
    
    public NumberRangesList(IEnumerable<(T First, T Last)> collection)
    {
        throw new NotImplementedException();
    }

    public NumberRangesList(params NumberExtents<T>[] list) : this((IEnumerable<NumberExtents<T>>)list) { }
    
    public NumberRangesList(params (T First, T Last)[] list) : this((IEnumerable<(T First, T Last)>)list) { }

    public NumberRangesList() { }
    
    // true && valueLessThanItemFirst == true: value < node.Value.First && (node.Previous is null || value > node.Previous.Value.Last)
    // true && valueLessThanItemFirst == false: value >= node.Value.First && value <= node.Value.Last && (node.Previous is null || value > node.Previous.Value.Last)
    // false: _backingList.Last is null || value > _backingList.Last.Value.Last
    private bool TryFindInsertionNode(T value, [NotNullWhen(true)] out LinkedListNode<NumberExtents<T>>? node, out bool valueLessThanItemFirst)
    {
        for (node = _backingList.First; node is not null; node = node.Next)
        {
            var item = node.Value;
            var diff = value.CompareTo(item.First);
            if (diff < 0)
            {
                valueLessThanItemFirst = true;
                return true;
            }
            else if (diff == 0 || value <= item.Last)
            {
                valueLessThanItemFirst = false;
                return true;
            }
        }
        valueLessThanItemFirst = false;
        return false;
    }

    public bool Add(T value)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            NumberExtents<T> item;
            if (TryFindInsertionNode(value, out LinkedListNode<NumberExtents<T>>? nextNode, out bool valueLessThanItemFirst))
            {
                if (!valueLessThanItemFirst) return false;
                // value < nextNode.Value.First && (nextNode.Previous is null || value > nextNode.Previous.Value.Last)
                LinkedListNode<NumberExtents<T>>? other;
                if (value + T.One == (item = nextNode.Value).First)
                {
                    // value + 1 == nextNode.Value.First && (nextNode.Previous is null || value > nextNode.Previous.Value.Last)
                    var last = item.Last;
                    if ((other = nextNode.Previous) is not null && (item = other.Value).Last + T.One == value)
                    {
                        value = item.First;
                        _backingList.Remove(nextNode);
                    }
                    else
                        other = nextNode;
                    nextNode = other.Next;
                    _backingList.Remove(other);
                    if (nextNode is null)
                        _backingList.AddLast(new NumberExtents<T>(value, last));
                    else
                        _backingList.AddBefore(nextNode, new NumberExtents<T>(value, last));
                }
                else if ((other = nextNode.Previous) is not null && (item = other.Value).Last + T.One == value)
                {
                    // value < nextNode.Value.First + 1 && value - 1 == nextNode.Previous.Value.Last)
                    var first = item.First;
                    _backingList.Remove(other);
                    _backingList.AddBefore(nextNode, new NumberExtents<T>(first, value));
                }
                else // value < nextNode.Value.First + 1 && (nextNode.Previous is null || value > nextNode.Previous.Value.Last + 1)
                    _backingList.AddBefore(nextNode, new NumberExtents<T>(value));
            }
            else
            {
                // _backingList.Last is null || value > _backingList.Last.Value.Last
                if ((nextNode = _backingList.Last) is not null)
                {
                    if ((item = nextNode.Value).Last + T.One == value)
                    {
                        var first = item.First;
                        _backingList.Remove(nextNode);
                        _backingList.AddLast(new NumberExtents<T>(first, value));
                        return true;
                    }
                }
                // backingList.Last is null || value > _backingList.Last.Value.Last + 1
                _backingList.AddLast(new NumberExtents<T>(value));
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return true;
    }

    // public bool Add(T value)
    // {
    //     Monitor.Enter(SyncRoot);
    //     try
    //     {
    //         var nextNode = _backingList.First;
    //         if (nextNode is null)
    //         {
    //             _backingList.AddLast(new NumberExtents<T>(value));
    //             return true;
    //         }
    //         NumberExtents<T> item = nextNode.Value;
    //         var diff = value.CompareTo(item.First);
    //         if (diff == 0) return false;
    //         LinkedListNode<NumberExtents<T>>? other;
    //         while (diff > 0)
    //         {
    //             // (nextNode.Previous is null || value > nextNode.Previous.Value.Last + 1) && value > nextNode.Value.First;
    //             if (value <= item.Last) return false;
    //             // value > nextNode.Value.Last;
    //             if (value == item.Last + T.One)
    //             {
    //                 var first = item.First;
    //                 if ((other = nextNode.Next) is null)
    //                 {
    //                     _backingList.Remove(nextNode);
    //                     _backingList.AddLast(new NumberExtents<T>(first, value));
    //                 }
    //                 else if (value + T.One == other.Value.First)
    //                 {
    //                     // value == nextNode.Value.Last + 1 && value == nextNode.Value.First - 1;
    //                     value = other.Value.Last;
    //                     _backingList.Remove(nextNode);
    //                     nextNode = other.Next;
    //                     _backingList.Remove(other);
    //                     if (nextNode is null)
    //                         _backingList.AddLast(new NumberExtents<T>(first, value));
    //                     else
    //                         _backingList.AddBefore(nextNode, new NumberExtents<T>(first, value));
    //                 }
    //                 else
    //                 {
    //                     // value == nextNode.Value.Last + 1 && value < nextNode.Value.First - 1;
    //                     _backingList.Remove(nextNode);
    //                     _backingList.AddBefore(other, new NumberExtents<T>(first, value));
    //                 }
    //                 return true;
    //             }
    //             // value > nextNode.Value.Last + 1
    //             nextNode = nextNode.Next;
    //             if (nextNode is null)
    //             {
    //                 _backingList.AddLast(new NumberExtents<T>(value));
    //                 return true;
    //             }
    //             if ((diff = value.CompareTo((item = nextNode.Value).First)) == 0) return false;
    //             // value > nextNode.Previous.Value.Last + 1 && value != nextNode.Value.First;
    //         }
    //         // (nextNode.Previous is null || value > nextNode.Previous.Value.Last + 1) && value < nextNode.Value.First;
    //         other = nextNode.Next;
    //         _backingList.Remove(nextNode);
    //         if (value + T.One == item.First)
    //         {
    //             if (other is null)
    //                 _backingList.AddLast(new NumberExtents<T>(value, item.Last));
    //             else
    //                 _backingList.AddBefore(other, new NumberExtents<T>(value, item.Last));
    //         }
    //         else if (other is null)
    //             _backingList.AddLast(new NumberExtents<T>(value));
    //         else
    //             _backingList.AddBefore(other, new NumberExtents<T>(value));
    //     }
    //     finally { Monitor.Exit(SyncRoot); }
    //     return true;
    // }

    public bool Add(NumberExtents<T> item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            var first = item.First;
            if (TryFindInsertionNode(first, out LinkedListNode<NumberExtents<T>>? nextNode, out bool itemFirstLessThanNextFirst))
            {
                if (itemFirstLessThanNextFirst)
                {
                    // value < nextNode.Value.First && (nextNode.Previous is null || value > nextNode.Previous.Value.Last)=
                }
                else
                {
                    // value >= nextNode.Value.First && value <= nextNode.Value.Last && (nextNode.Previous is null || value > nextNode.Previous.Value.Last)
                }
            }
            else
            {
                // _backingList.Last is null || value > _backingList.Last.Value.Last
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        throw new NotImplementedException();
    }

    private bool SetLast(LinkedListNode<NumberExtents<T>> nextNode, T last)
    {
        throw new NotImplementedException();
    }

    public bool Add(T first, T last)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    void ICollection<NumberExtents<T>>.Add(NumberExtents<T> item) => Add(item);

    int IList.Add(object? value) => throw new NotSupportedException();

    public void Clear()
    {
        Monitor.Enter(SyncRoot);
        try
        {
            _backingList.Clear();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    public bool Contains(NumberExtents<T> item) => _backingList.Contains(item);

    public bool Contains(T first, T last)
    {
        throw new NotImplementedException();
    }

    bool IList.Contains(object? value)
    {
        throw new NotImplementedException();
    }

    public bool ContainsAny(T first, T last)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(NumberExtents<T>[] array, int arrayIndex) => _backingList.CopyTo(array, arrayIndex);

    public void CopyTo(Array array, int index) => _backingList.ToArray().CopyTo(array, index);

    public IEnumerable<T> GetAllValues()
    {
        foreach (NumberExtents<T> item in _backingList)
        {
            foreach (T value in item)
                yield return value;
        }
    }

    public IEnumerator<NumberExtents<T>> GetEnumerator() => _backingList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_backingList).GetEnumerator();

    public NumberExtents<T> GetItemAt(int index)
    {
        throw new NotImplementedException();
    }

    public T GetValueAt(BigInteger index)
    {
        throw new NotImplementedException();
    }

    public BigInteger GetValueCount()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(NumberExtents<T> value)
    {
        throw new NotImplementedException();
    }

    int IList.IndexOf(object? value)
    {
        throw new NotImplementedException();
    }

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

    private bool ContainsAllElements(IEnumerable<NumberExtents<T>> other)
    {
        foreach (NumberExtents<T> element in other)
        {
            if (!Contains(element)) return false;
        }
        return true;
    }

    private int CheckUniqueAndUnfoundElements(IEnumerable<NumberExtents<T>> other, bool returnIfUnfound, out int unfoundCount)
    {
        // need special case in case this has no elements. 
        if (_backingList.Count == 0)
        {
            int numElementsInOther = 0;
            foreach (NumberExtents<T> item in other)
            {
                numElementsInOther++;
                // break right away, all we want to know is whether other has 0 or 1 elements
                break;
            }
            unfoundCount = numElementsInOther;
            return 0;
        }

        BitArray bitHelper = new BitArray(_backingList.Count);

        // count of items in other not found in this
        unfoundCount = 0;
        // count of unique items in other found in this
        int uniqueFoundCount = 0;
        foreach (NumberExtents<T> item in other)
        {
            int index = InternalIndexOf(item);

            if (index >= 0)
            {
                if (!bitHelper.Get(index))
                {
                    bitHelper.Set(index, true);
                    // item hasn't been seen yet
                    uniqueFoundCount++;
                }
            }
            else
            {
                unfoundCount++;
                if (returnIfUnfound) break;
            }
        }

        return uniqueFoundCount;
    }

    private int InternalIndexOf(NumberExtents<T> item)
    {
        int index = -1;
        for (LinkedListNode<NumberExtents<T>>? node = _backingList.First; node is not null; node = node.Next)
        {
            index++;
            if (node.Value.Equals(item)) return index;
        }
        return -1;
    }

    public bool IsProperSubsetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return other.Any();
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount > 0;
    }

    public bool IsProperSupersetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return false;
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount < _backingList.Count && unfoundCount == 0;
    }

    public bool IsSubsetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return true;
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount >= 0;
    }

    public bool IsSupersetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        return ContainsAllElements(other);
    }

    public bool Overlaps(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return false;

        foreach (NumberExtents<T> element in other)
        {
            if (Contains(element))
            {
                return true;
            }
        }
        return false;
    }

    public bool Overlaps(T first, T last)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T value)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Remove(NumberExtents<T> item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            return _backingList.Remove(item);
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Remove(T first, T last)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    void IList.Remove(object? value) => throw new NotSupportedException();

    public void RemoveAt(int index)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool SetEquals(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount == 0;
    }
}
