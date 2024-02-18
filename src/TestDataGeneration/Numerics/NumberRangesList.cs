using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation.Provider;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Resources;
using System.Security.Policy;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TestDataGeneration.Numerics;

/// <summary>
/// List of distinct, non-adjacent value ranges.
/// </summary>
/// <typeparam name="T">The value type.</typeparam>
public class NumberRangesList<T> : IReadOnlySet<NumberExtents<T>>, IReadOnlyList<NumberExtents<T>>, ICollection<NumberExtents<T>>, IList
    where T : IBinaryNumber<T>, IMinMaxValue<T>
{
    private readonly LinkedList<NumberExtents<T>> _backingList = new();

    /// <summary>
    /// Gets the number of <see cref="NumberExtents{T}"/> items in the current list.
    /// </summary>
    public int Count => _backingList.Count;

    /// <summary>
    /// Gets the object that is used to synchronized access to the current list.
    /// </summary>
    public object SyncRoot { get; } = new();

    bool ICollection<NumberExtents<T>>.IsReadOnly=> false;

    bool IList.IsFixedSize=> false;

    bool IList.IsReadOnly => true;

    bool ICollection.IsSynchronized => true;

    object? IList.this[int index] { get => GetItemAt(index); set => throw new NotSupportedException(); }

    NumberExtents<T> IReadOnlyList<NumberExtents<T>>.this[int index] => GetItemAt(index);

    /// <summary>
    /// Initializes a new <c>NumberRangesList</c>.
    /// </summary>
    /// <param name="collection">The value ranges to add.</param>
    public NumberRangesList(IEnumerable<NumberExtents<T>> collection)
    {
        if (collection is null) return;
        var orderedValues = collection.GroupBy(n => n.First).Select(g => (g.Key, g.OrderByDescending(n => n.Last).First().Last)).ToArray();
        if (orderedValues.Length == 0) return;
        var (prevFirst, prevLast) = orderedValues[0];
        foreach (var (first, last) in orderedValues.Skip(1))
        {
            if (first <= prevLast)
            {
                if (last > prevLast) prevLast = last;
            }
            else if (first + T.One == prevLast)
                prevLast = last;
            else
            {
                _backingList.AddLast(new NumberExtents<T>(prevFirst, prevLast));
                prevFirst = first;
                prevLast = last;
            }
        }
        _backingList.AddLast(new NumberExtents<T>(prevFirst, prevLast));
    }

    /// <summary>
    /// Initializes a new <c>NumberRangesList</c>.
    /// </summary>
    /// <param name="collection">The value ranges to add.</param>
    public NumberRangesList(IEnumerable<(T First, T Last)> collection)
    {
        if (collection is null) return;
        var orderedValues = collection.GroupBy(n => n.First).Select(g => (g.Key, g.OrderByDescending(n => n.Last).First().Last)).ToArray();
        if (orderedValues.Length == 0) return;
        var (prevFirst, prevLast) = orderedValues[0];
        if (prevFirst > prevLast) throw new ArgumentOutOfRangeException(nameof(collection));
        foreach (var (first, last) in orderedValues.Skip(1))
        {
            if (last > first) throw new ArgumentOutOfRangeException(nameof(collection));
            if (first <= prevLast)
            {
                if (last > prevLast) prevLast = last;
            }
            else if (first + T.One == prevLast)
                prevLast = last;
            else
            {
                _backingList.AddLast(new NumberExtents<T>(prevFirst, prevLast));
                prevFirst = first;
                prevLast = last;
            }
        }
        _backingList.AddLast(new NumberExtents<T>(prevFirst, prevLast));
    }

    /// <summary>
    /// Initializes a new <c>NumberRangesList</c>.
    /// </summary>
    /// <param name="list">The value ranges to add.</param>
    public NumberRangesList(params NumberExtents<T>[] list) : this((IEnumerable<NumberExtents<T>>)list) { }

    /// <summary>
    /// Initializes a new <c>NumberRangesList</c>.
    /// </summary>
    /// <param name="list">The value ranges to add.</param>
    public NumberRangesList(params (T First, T Last)[] list) : this((IEnumerable<(T First, T Last)>)list) { }

    /// <summary>
    /// Initializes a new <c>NumberRangesList</c>.
    /// </summary>
    public NumberRangesList() { }

    /// <summary>
    /// Adds a value to the current list.
    /// </summary>
    /// <param name="value">The value to add.</param>
    /// <returns><see langword="true"/> if the <paramref name="value"/> extended an existing <see cref="NumberExtents{T}"/> or was added as a new <see cref="NumberExtents{T}"/>;
    /// otherwise, <see langword="false"/>.</returns>
    public bool Add(T value)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (value == T.MinValue)
            {
                if (_backingList.TryGetFirst(out var node, out var extents))
                {
                    if (value >= extents.First) return false;
                    if (value + T.One == extents.First)
                        node.Value = new(value, extents.Last);
                    else
                        _backingList.AddFirst(new NumberExtents<T>(value));
                }
                else
                    _backingList.AddLast(new NumberExtents<T>(value));
            }
            else if (_backingList.TryGetLast(out var nextNode, out var nextExtents))
            {
                if (value > nextExtents.Last)
                {
                    if (value - T.One == nextExtents.Last)
                        nextNode.Value = new(nextExtents.First, value);
                    else
                        _backingList.AddLast(new NumberExtents<T>(value));
                }
                else
                {
                    if (value >= nextExtents.First) return false;
                    if (nextNode.TryGetPrevious(out var prevNode, out var prevExtents))
                    {
                        while (value < prevExtents.First)
                        {
                            nextExtents = prevExtents;
                            if (!(nextNode = prevNode).TryGetPrevious(out prevNode, out prevExtents))
                            {
                                if (value + T.One == nextExtents.First)
                                    nextNode.Value = new(value, nextExtents.Last);
                                else
                                    _backingList.AddFirst(new NumberExtents<T>(value));
                                return true;
                            }
                            if (value > prevExtents.Last)
                            {
                                if (value - T.One == prevExtents.Last)
                                {
                                    if (value + T.One == nextExtents.First)
                                    {
                                        _backingList.Remove(nextNode);
                                        prevNode.Value = new(prevExtents.First, nextExtents.Last);
                                    }
                                    else
                                        prevNode.Value = new(prevExtents.First, value);
                                }
                                else if (value + T.One == nextExtents.First)
                                    nextNode.Value = new(value, nextExtents.Last);
                                else
                                    _backingList.AddAfter(prevNode, new NumberExtents<T>(value));
                                return true;
                            }
                            if (value >= prevExtents.First) return false;
                        }
                        if (value <= prevExtents.Last) return false;
                        if (value + T.One == nextExtents.First)
                        {
                            if (value - T.One == prevExtents.Last)
                            {
                                _backingList.Remove(nextNode);
                                prevNode.Value = new(prevExtents.First, nextExtents.Last);
                            }
                            else
                                nextNode.Value = new(value, nextExtents.Last);
                        }
                        else if (value - T.One == prevExtents.Last)
                            prevNode.Value = new(prevExtents.First, value);
                        else
                            _backingList.AddAfter(prevNode, new NumberExtents<T>(value));
                    }
                    else if (value + T.One == nextExtents.First)
                        nextNode.Value = new(value, nextExtents.Last);
                    else
                        _backingList.AddFirst(new NumberExtents<T>(value));
                }
            }
            else
                _backingList.AddLast(new NumberExtents<T>(value));
        }
        finally { Monitor.Exit(SyncRoot); }
        return true;
    }

    /// <summary>
    /// Adds range extents to the current list.
    /// </summary>
    /// <param name="item">The range extents to be added.</param>
    /// <returns><see langword="true"/> if the <paramref name="item"/> combined with one or more existing <see cref="NumberExtents{T}"/> elements or was added as a new element;
    /// otherwise, <see langword="false"/>.</returns>
    public bool Add(NumberExtents<T> item) => Add(item.First, item.Last);

    /// <summary>
    /// Adds range extents to the current list.
    /// </summary>
    /// <param name="first">The inclusive start range value to add.</param>
    /// <param name="last">The inclusive end range value to add.</param>
    /// <returns><see langword="true"/> if any existing <see cref="NumberExtents{T}"/> were modfied or a new <see cref="NumberExtents{T}"/> was added;
    /// otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="first"/> is greater than <paramref name="last"/>.</exception>
    public bool Add(T first, T last)
    {
        int diff = first.CompareTo(last);
        if (diff > 0) throw new ArgumentOutOfRangeException(nameof(first));
        if (diff == 0) return Add(first);
        Monitor.Enter(SyncRoot);
        try
        {
            // If first is MinValue, start from First node; otherwise, start from Last node
            if (first == T.MinValue)
            {
                if (_backingList.TryGetFirst(out var prevNode, out var prevExtents))
                {
                    if (last == T.MaxValue)
                    {
                        prevNode.RemoveFollowing();
                        prevNode.Value = new(first, last);
                    }
                    else if (last < prevExtents.First)
                    {
                        if (last + T.One == prevExtents.First)
                            prevNode.Value = new(first, prevExtents.Last);
                        else
                            _backingList.AddFirst(new NumberExtents<T>(first, last));
                    }
                    else if (last <= prevExtents.Last)
                    {
                        if (prevExtents.First == first) return false;
                        prevNode.Value = new(first, prevExtents.Last);
                    }
                    else if (last - T.One == prevExtents.Last)
                    {
                        if (prevNode.TryGetNext(out var nextNode, out var nextExtents) && last + T.One == nextExtents.First)
                        {
                            _backingList.Remove(nextNode);
                            prevNode.Value = new(first, nextExtents.Last);
                        }
                        else
                            prevNode.Value = new(first, last);
                    }
                    else if (prevNode.TryGetNext(out var nextNode, out var nextExtents))
                    {
                        if (last < nextExtents.First)
                        {
                            if (last + T.One == nextExtents.First)
                            {
                                last = nextExtents.Last;
                                _backingList.Remove(nextNode);
                            }
                            prevNode.Value = new(first, last);
                            return true;
                        }
                        var lastMinusOne = last - T.One;
                        // last - T.One > prevExtents.Last
                        while (last > nextExtents.Last)
                        {
                            _backingList.Remove(nextNode);
                            if (lastMinusOne == nextExtents.Last)
                            {
                                if (prevNode.TryGetNext(out nextNode, out nextExtents) && last + T.One == nextExtents.First)
                                {
                                    _backingList.Remove(nextNode);
                                    last = nextExtents.Last;
                                }
                                prevNode.Value = new(first, last);
                                return true;
                            }
                            if (!prevNode.TryGetNext(out nextNode, out nextExtents))
                            {
                                prevNode.Value = new(first, last);
                                return true;
                            }
                        }
                        if (last >= nextExtents.First || last + T.One == nextExtents.First) 
                        {
                            _backingList.Remove(nextNode);
                            last = nextExtents.Last;
                        }
                        prevNode.Value = new(first, last);
                    }
                    else
                        prevNode.Value = new(first, last);
                }
                else
                    _backingList.AddLast(new NumberExtents<T>(first, last));
            }
            else if (_backingList.TryGetLast(out var nextNode, out var nextExtents))
            {
                if (first > nextExtents.Last)
                {
                    if (first - T.One == nextExtents.Last)
                        nextNode.Value = new(nextExtents.First, last);
                    else
                        _backingList.AddLast(new NumberExtents<T>(first, last));
                }
                else if (first >= nextExtents.First)
                {
                    // first <= nextExtents.Last
                    if (last <= nextExtents.Last) return false;
                    nextNode.Value = new(nextExtents.First, last);
                }
                else if (nextNode.TryGetPrevious(out var prevNode, out var prevExtents))
                {
                    var lastPlusOne = last + T.One;
                    while (lastPlusOne < nextExtents.First)
                    {
                        if (prevNode.TryGetPrevious(out var node, out var extents))
                        {
                            nextExtents = prevExtents;
                            prevExtents = extents;
                            nextNode = prevNode;
                            prevNode = node;
                        }
                        else
                        {
                            // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                            // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                            // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                            // | first: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦ ? ‖ ? ¦ ? ¦ ? ¦ ? ‖ ? ¦ ? ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            // |   L+1: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦ ? ‖ ? ¦ ? ¦ ? ¦ ? ‖ ? ¦ ? ¦ ? ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            if (lastPlusOne == nextExtents.First)
                                // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                                // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                                // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                                // | first: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                                // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦ ? ‖ ? ¦ ? ¦ ? ¦ ? ‖ ? ¦ ? ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                                // |   L+1: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦ X ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                                nextNode.Value = new(first, nextExtents.Last);
                            else if (last <= prevExtents.Last)
                            {
                                // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                                // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                                // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                                // | first: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦ ? ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                                // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦ ? ‖ ? ¦ ? ¦ ? ¦ ? ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                                if (first >= prevExtents.First) return false;
                                if (lastPlusOne < prevExtents.First)
                                    _backingList.AddFirst(new NumberExtents<T>(first, last));
                                else
                                    prevNode.Value = new(first, prevExtents.Last);
                            }
                            else if (first > prevExtents.Last)
                            {
                                if (first - T.One == prevExtents.Last)
                                    prevNode.Value = new(prevExtents.First, last);
                                else
                                    _backingList.AddAfter(prevNode, new NumberExtents<T>(first, last));
                                // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                                // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                                // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                                // | first: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖ ? ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                                // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦ ? ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            }
                            // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                            // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                            // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                            // | first: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦ ? ‖ ? ¦ ? ¦ ? ¦ ? ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖ ? ¦ ? ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            else
                                prevNode.Value = new(T.Min(first, prevExtents.First), last);
                            return true;
                        }
                    }
                    if (first > nextExtents.Last)
                    {
                        // lastPlusOne >= nextExtents.First
                        // nextNode.Next is null || lastPlusOne < nextNode.Next.Value.First
                        if (first - T.One == nextExtents.Last)
                            nextNode.Value = new(nextExtents.First, last);
                        else
                            _backingList.AddAfter(nextNode, new NumberExtents<T>(first, last));
                    }
                    else if (first >= nextExtents.First)
                    {
                        if (last <= nextExtents.Last) return false;
                        nextNode.Value = new(nextExtents.First, last);
                    }
                    else
                    {
                        if (last < nextExtents.Last) last = nextExtents.Last;
                        // first < nextExtents.First
                        // last >= nextExtents.Last
                        // nextNode.Next is null || lastPlusOne < nextNode.Next.Value.First
                        // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                        // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                        // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                        // | first: ¦ X ‖ X ¦ X ¦ X ¦ X ‖ X ¦ X ¦ X ‖ X ¦ X ¦ X ¦ X ‖ X ¦ X ¦ X ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                        // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦ X ‖ X ¦ X ¦   ‖   ¦   ¦   ¦   ‖   ¦
                        while (first < prevExtents.First)
                        {
                            _backingList.Remove(nextNode);
                            nextNode = prevNode;
                            nextExtents = prevExtents;
                            if (!nextNode.TryGetPrevious(out prevNode, out prevExtents))
                            {
                                nextNode.Value = new(first, last);
                                return true;
                            }
                        }
                        // first >= prevExtents.First
                        // first < nextExtents.First
                        // last >= nextExtents.Last
                        // nextNode.Next is null || lastPlusOne < nextNode.Next.Value.First
                        // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                        // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                        // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                        // | first: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖ X ¦ X ¦ X ¦ X ‖ X ¦ X ¦ X ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                        // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦ X ‖ X ¦ X ¦   ‖   ¦   ¦   ¦   ‖   ¦
                        if (first - T.One > prevExtents.Last)
                            nextNode.Value = new(first, last);
                        else
                        {
                            // first - T.One <= prevExtents.Last
                            // first >= prevExtents.First
                            // first < nextExtents.First
                            // last >= nextExtents.Last
                            // nextNode.Next is null || lastPlusOne < nextNode.Next.Value.First
                            // ‖            ‖               ‖           ‖  prevExtents  ‖           ‖  nextExtents  ‖           ‖               ‖   ¦
                            // ‖        ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦   ¦   ‖ F ¦   ¦   ¦ L ‖   ¦
                            // ‖--------¦---‖---¦---¦---¦---‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖---¦---¦---‖---¦---¦---¦-- ‖   ¦
                            // | first: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖ X ¦ X ¦ X ¦ X ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            // |  last: ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦   ‖   ¦   ¦   ‖   ¦   ¦   ¦ X ‖ X ¦ X ¦   ‖   ¦   ¦   ¦   ‖   ¦
                            _backingList.Remove(nextNode);
                            prevNode.Value = new(prevExtents.First, last);
                        }
                    }
                }
                else if (last < nextExtents.First)
                {
                    if (last + T.One == nextExtents.First)
                        nextNode.Value = new(first, nextExtents.Last);
                    else
                        _backingList.AddFirst(new NumberExtents<T>(first, last));
                }
                else
                    nextNode.Value = new(first, T.Max(last, nextExtents.Last));
            }
            else
                _backingList.AddLast(new NumberExtents<T>(first, last));
        }
        finally { Monitor.Exit(SyncRoot); }
        return true;
    }

    void ICollection<NumberExtents<T>>.Add(NumberExtents<T> item) => Add(item);

    int IList.Add(object? value) => throw new NotSupportedException();

    private int CheckUniqueAndUnfoundElements(IEnumerable<NumberExtents<T>> other, bool returnIfUnfound, out int unfoundCount)
    {
        if (_backingList.Count == 0)
        {
            int numElementsInOther = 0;
            foreach (NumberExtents<T> item in other)
            {
                numElementsInOther++;
                break;
            }
            unfoundCount = numElementsInOther;
            return 0;
        }

        BitArray bitHelper = new(_backingList.Count);

        unfoundCount = 0;
        int uniqueFoundCount = 0;
        foreach (NumberExtents<T> item in other)
        {
            int index = InternalIndexOf(item);

            if (index >= 0)
            {
                if (!bitHelper.Get(index))
                {
                    bitHelper.Set(index, true);
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

    /// <summary>
    /// Removes all elements from the current list.
    /// </summary>
    public void Clear()
    {
        Monitor.Enter(SyncRoot);
        try { _backingList.Clear(); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Determines whether any ranges in the current list includes a specific value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns><see langword="true"/> if any existing <see cref="NumberExtents{T}"/> includes the specified <paramref name="value"/>; otherwise, <see langword="false"/>.</returns>
    public bool Contains(T value)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (_backingList.Count == 0) return false;
            foreach (var element in _backingList)
            {
                if (element.Contains(value)) return true;
                if (element.First > value) break;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    /// <summary>
    /// Determines whether any items in the current list match the specified range extents.
    /// </summary>
    /// <param name="item">The range extents to look for.</param>
    /// <returns><see langword="true"/> if any existing <see cref="NumberExtents{T}"/> matches the specified <paramref name="item"/>; otherwise, <see langword="false"/>.</returns>
    public bool Contains(NumberExtents<T> item) => _backingList.Contains(item);

    /// <summary>
    /// Determines whether any items in the current list match the specified range extents.
    /// </summary>
    /// <param name="first">The first range extent value.</param>
    /// <param name="last">The last range extent value.</param>
    /// <returns><see langword="true"/> if an element's <see cref="NumberExtents{T}.First"/> matches the specified <paramref name="first"/> value
    /// and the same element's <see cref="NumberExtents{T}.Last"/> matches the specified <paramref name="last"/> value; otherwise, <see langword="false"/>.</returns>
    /// <remarks>This will also return <see langword="false"/> if <paramref name="first"/> is greater than <paramref name="last"/>.</remarks>
    public bool Contains(T first, T last)
    {
        if (first > last) return false;
        Monitor.Enter(SyncRoot);
        try
        {
            if (_backingList.Count == 0) return false;
            foreach (var element in _backingList)
            {
                int diff = first.CompareTo(element.First);
                if (diff == 0) return element.Last == last;
                if (diff < 0) break;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    bool IList.Contains(object? value)
    {
        if (value is null) return false;
        if (value is NumberExtents<T> item) _backingList.Contains(item);
        if (value is T v) return Contains(v);
        return value is Tuple<T, T> t && Contains(t.Item1, t.Item2);
    }

    /// <summary>
    /// Determines whether any items in the current list include the specified range extents.
    /// </summary>
    /// <param name="first">The inclusive first range extent value.</param>
    /// <param name="last">The inclusive last range extent value.</param>
    /// <returns><see langword="true"/> if an element's <see cref="NumberExtents{T}.First"/> is less than or equal to the specified <paramref name="first"/> value
    /// and the same element's <see cref="NumberExtents{T}.Last"/> is greater than or equal to the specified <paramref name="last"/> value; otherwise, <see langword="false"/>.</returns>
    /// <remarks>This will also return <see langword="false"/> if <paramref name="first"/> is greater than <paramref name="last"/>.</remarks>
    public bool ContainsAll(T first, T last)
    {
        if (first > last) return false;
        Monitor.Enter(SyncRoot);
        try
        {
            foreach (var element in _backingList)
            {
                if (first < element.First) break;
                if (last <= element.Last) return true;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    private bool ContainsAllElements(IEnumerable<NumberExtents<T>> other)
    {
        foreach (NumberExtents<T> element in other)
            if (!Contains(element)) return false;
        return true;
    }

    /// <summary>
    /// Copies the elements of the current list to an array of <see cref="NumberExtents{T}"/> values, starting at a particular index.
    /// </summary>
    /// <param name="array">The destination array.</param>
    /// <param name="arrayIndex">The zero-based index in the destination array at which copying begins.</param>
    /// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than zero.</exception>
    /// <exception cref="ArgumentException">The number of elements in the current list is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.</exception>
    public void CopyTo(NumberExtents<T>[] array, int arrayIndex) => _backingList.CopyTo(array, arrayIndex);

    /// <summary>
    /// Copies the elements of the current list to an <see cref="Array" />, starting at a particular index.
    /// </summary>
    /// <param name="array">The destination array.</param>
    /// <param name="index">The zero-based index in the destination array at which copying begins.</param>
    /// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than the lower bound of the <paramref name="array"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="array"/> is multidimensional or he number of elements in the current list is greater than the
    /// available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.</exception>
    /// <exception cref="ArrayTypeMismatchException">The elements from the source list cannot be automatically cast to the type of the destination <paramref name="array"/>.</exception>
    /// <exception cref="RankException"><paramref name="array"/> is multidimensional.</exception>
    /// <exception cref="InvalidCastException">At least one element in the current list cannot e case to the type of the destination <paramref name="array"/>.</exception>
    public void CopyTo(Array array, int index) => _backingList.ToArray().CopyTo(array, index);

    /// <summary>
    /// Gets all values included in all elements of the current list.
    /// </summary>
    /// <returns>All values from all <see cref="NumberExtents{T}"/> elements.</returns>
    public IEnumerable<T> GetAllValues()
    {
        foreach (NumberExtents<T> item in _backingList)
        {
            foreach (T value in item)
                yield return value;
        }
    }

    /// <summary>
    /// Gets an object that iterates through all elements in the current list.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> that iterates through all <see cref="NumberExtents{T}"/> elements in the current list.</returns>
    public IEnumerator<NumberExtents<T>> GetEnumerator() => _backingList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_backingList).GetEnumerator();

    /// <summary>
    /// Gets an element at a specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <returns>The <see cref="IEnumerator{T}"/> at the specified <paramref name="index"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> was less than <c>0<c> or greater than or equal to the <see cref="Count"/> of elements in the current list.</exception>
    public NumberExtents<T> GetItemAt(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        Monitor.Enter(SyncRoot);
        try
        {
            int pos = -1;
            foreach (var element in _backingList)
                if (++pos == index) return element;
        }
        finally { Monitor.Exit(SyncRoot); }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    /// <summary>
    /// Gets a value at a specified index amongst all the ranges in the current list.
    /// </summary>
    /// <param name="index">The zero-based index of the value to retrieve.</param>
    /// <returns>The <typeparamref name="T"/> value at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> was less than <see cref="BigInteger.Zero"/> or greater than or equal to the sum of all values for all elements in the current list.</exception>
    public T GetValueAt(BigInteger index)
    {
        if (index < BigInteger.Zero) throw new ArgumentOutOfRangeException(nameof(index));
        Monitor.Enter(SyncRoot);
        try
        {
            var pos = new BigInteger(-1);
            foreach (var element in _backingList)
                foreach (var value in element)
                    if (++pos == index) return value;
        }
        finally { Monitor.Exit(SyncRoot); }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    /// <summary>
    /// Gets the total number of values included in all ranges in the current list.
    /// </summary>
    /// <returns>A value representing the total number of all values included in all <see cref="NumberExtents{T}"/> elements in the current list.</returns>
    public BigInteger GetValueCount()
    {
        var count = BigInteger.Zero;
        Monitor.Enter(SyncRoot);
        try
        {
            if (_backingList.Count > 0)
                foreach (var element in _backingList)
                    count += element.GetCount();
        }
        finally { Monitor.Exit(SyncRoot); }
        return count;
    }

    /// <summary>
    /// Gets the index of a specified range extents item.
    /// </summary>
    /// <param name="item">The range extents item to look for.</param>
    /// <returns>The zero-based index of the specified <paramref name="item"/> or <c>-1</c> if no elements match the specified <paramref name="item"/>.</returns>
    public int IndexOf(NumberExtents<T> item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (_backingList.Count == 0) return -1;
            var pos = -1;
            var first = item.First;
            foreach (var element in _backingList)
            {
                pos++;
                var diff = element.First.CompareTo(first);
                if (diff == 0)
                {
                    if (item.Last == element.Last) return pos;
                    break;
                }
                if (diff < 0) break;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return -1;
    }

    int IList.IndexOf(object? value)
    {
        if (value is null) return -1;
        if (value is NumberExtents<T> item) IndexOf(item);
        if (value is not Tuple<T, T> t) return -1;
        Monitor.Enter(SyncRoot);
        try
        {
            if (_backingList.Count == 0) return -1;
            var pos = -1;
            var (first, last) = t;
            if (first > last) return -1;
            foreach (var element in _backingList)
            {
                pos++;
                var diff = element.First.CompareTo(first);
                if (diff == 0)
                {
                    if (last == element.Last) return pos;
                    break;
                }
                if (diff < 0) break;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return -1;
    }

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

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

    /// <summary>
    /// Determines whether the current set is a proper (strict) subset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a proper subset of <paramref name="other"/>; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
    public bool IsProperSubsetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return other.Any();
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount > 0;
    }

    /// <summary>
    /// Determines whether the current set is a subset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a proper superset of <paramref name="other"/>; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
    public bool IsProperSupersetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return false;
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount < _backingList.Count && unfoundCount == 0;
    }

    /// <summary>
    /// Determine whether the current set is a subset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a subset of <paramref name="other"/>; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
    public bool IsSubsetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return true;
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount >= 0;
    }

    /// <summary>
    /// Determine whether the current set is a superset of a specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is a superset of <paramref name="other"/>; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
    public bool IsSupersetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        return ContainsAllElements(other);
    }

    /// <summary>
    /// Determines whether the current set overlaps with the specified collection.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set and <paramref name="other"/> share at least one common element; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
    public bool Overlaps(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return false;

        foreach (NumberExtents<T> element in other)
            if (Contains(element)) return true;
        return false;
    }

    /// <summary>
    /// Determines whether any existing element overlaps the given range extents.
    /// </summary>
    /// <param name="first">The inclusive first value to look for.</param>
    /// <param name="last">The inclusive last value to look for.</param>
    /// <returns><see langword="true"/> if an element in the current list includes at least one value from the <paramref name="first"/> extent value,
    /// up to and including the <paramref name="last"/> extent value; otherwise, <see langword="false"/>.</returns>
    /// <remarks>This will also return <see langword="false"/> if <paramref name="first"/> is greater than <paramref name="last"/>.</remarks>
    public bool AnyOverlaps(T first, T last)
    {
        if (first > last) return false;
        Monitor.Enter(SyncRoot);
        try
        {
            foreach (var element in _backingList)
            {
                var diff = last.CompareTo(element.First);
                if (diff < 0) return false;
                if (diff == 0 || first <= element.Last) return true;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    /// <summary>
    /// Removes a value from the existing set of range extents.
    /// </summary>
    /// <param name="value">The value to remove.</param>
    /// <returns><see langword="true"/> if the <paramref name="value"/> was removed from an existing element; otherwise, <see langword="false"/>.</returns>
    public bool Remove(T value)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            for (var node = _backingList.First; node is not null; node = node.Next)
            {
                var element = node.Value;
                int diff = value.CompareTo(element.First);
                if (diff < 0) return false;
                if (diff == 0)
                {
                    if (element.IsSingleValue())
                        _backingList.Remove(node);
                    else
                        node.Value = new(value + T.One, element.Last);
                    return true;
                }
                if ((diff = value.CompareTo(element.Last)) == 0)
                {
                    node.Value = new(element.First, value - T.One);
                    return true;
                }
                else if (diff < 0)
                {
                    node.Value = new(element.First, value - T.One);
                    _backingList.AddAfter(node, new NumberExtents<T>(value + T.One, element.Last));
                    return true;
                }
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    /// <summary>
    /// Removes an element from the current list.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns><see langword="true"/> if a matching element was removed; otherwise, <see langword="false"/>.</returns>
    public bool Remove(NumberExtents<T> item)
    {
        Monitor.Enter(SyncRoot);
        try { return _backingList.Remove(item); }
        finally { Monitor.Exit(SyncRoot); }
    }

    /// <summary>
    /// Removes a range of values from the current set of range extents.
    /// </summary>
    /// <param name="first">The inclusive firs value to be removed.</param>
    /// <param name="last">The inclusive last value to be removed.</param>
    /// <returns><see langword="true"/> if any values were removed; otherwise, <see langword="false"/>.</returns>
    /// <remarks>This will also return <see langword="false"/> if <paramref name="first"/> is greater than <paramref name="last"/>.</remarks>
    public bool Remove(T first, T last)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            for (var node = _backingList.First; node is not null; node = node.Next)
            {
                var element = node.Value;
                int diff = last.CompareTo(element.First);
                if (diff < 0) return false;
                if (diff == 0)
                {
                    if (element.IsSingleValue())
                        _backingList.Remove(node);
                    else
                        node.Value = new(last + T.One, element.Last);
                    return true;
                }
                if (first <= element.First)
                {
                    if ((diff = last.CompareTo(element.Last)) == 0)
                    {
                        _backingList.Remove(node);
                        return true;
                    }
                    if (diff < 0)
                    {
                        node.Value = new(last + T.One, element.Last);
                        return true;
                    }
                    var next = node.Next;
                    _backingList.Remove(node);
                    while (next is not null)
                    {
                        element = (node = next).Value;
                        if ((diff = last.CompareTo(element.Last)) < 0)
                        {
                            node.Value = new(last + T.One, element.Last);
                            return true;
                        }
                        next = node.Next;
                        _backingList.Remove(node);
                        if (diff == 0) return true;
                    }
                    return true;
                }
                else
                {
                    if ((diff = first.CompareTo(element.Last)) == 0)
                    {
                        if (element.IsSingleValue())
                            _backingList.Remove(node);
                        else
                            node.Value = new(element.First, first - T.One);
                        return true;
                    }
                    if (diff < 0)
                    {
                        node.Value = new(element.First, first - T.One);

                        if ((diff = last.CompareTo(element.Last)) < 0)
                            _backingList.AddAfter(node, new NumberExtents<T>(last + T.One, element.Last));
                        else if (diff > 0)
                        {
                            node = node.Next;
                            while (node is not null)
                            {
                                element = node.Value;
                                if ((diff = last.CompareTo(element.Last)) < 0)
                                {
                                    node.Value = new(last + T.One, element.Last);
                                    return true;
                                }
                                var next = node.Next;
                                _backingList.Remove(node);
                                if (diff == 0) return true;
                                node = next;
                            }
                        }
                        return true;
                    }
                }
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    void IList.Remove(object? value) => throw new NotSupportedException();

    /// <summary>
    /// Removes an element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the <see cref="NumberExtents{T}"/> element to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> was less than <c>0<c> or greater than or equal to the <see cref="Count"/> of elements in the current list.</exception>
    public void RemoveAt(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        Monitor.Enter(SyncRoot);
        try
        {
            int pos = -1;
            for (var node = _backingList.First; node is not null; node = node.Next)
            {
                if (++pos == index)
                {
                    _backingList.Remove(node);
                    return;
                }
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    /// <summary>
    /// Determines whether the current set and the specified collection contain the same elements.
    /// </summary>
    /// <param name="other">The collection to compare to the current set.</param>
    /// <returns><see langword="true"/> if the current set is equal to <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
    public bool SetEquals(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount == 0;
    }
}
