using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public static class CollectionExtensionMethods
{
    public static bool TryGetFirst<T>(this LinkedList<T>? list, [NotNullWhen(true)] out LinkedListNode<T>? firstNode)
    {
        if (list is null)
        {
            firstNode = null;
            return false;
        }
        return (firstNode = list.First) is not null;
    }

    public static bool TryGetFirst<T>(this LinkedList<T>? list, [NotNullWhen(true)] out LinkedListNode<T>? firstNode, [MaybeNullWhen(false)] out T firstValue)
    {
        if (list is null)
            firstNode = null;
        else if ((firstNode = list.First) is not null)
        {
            firstValue = firstNode.Value;
            return true;
        }
        firstValue = default;
        return false;
    }

    public static bool TryGetLast<T>(this LinkedList<T>? list, [NotNullWhen(true)] out LinkedListNode<T>? lastNode)
    {
        if (list is null)
        {
            lastNode = null;
            return false;
        }
        return (lastNode = list.Last) is not null;
    }

    public static bool TryGetLast<T>(this LinkedList<T>? list, [NotNullWhen(true)] out LinkedListNode<T>? lastNode, [MaybeNullWhen(false)] out T lastValue)
    {
        if (list is null)
            lastNode = null;
        else if ((lastNode = list.Last) is not null)
        {
            lastValue = lastNode.Value;
            return true;
        }
        lastValue = default;
        return false;
    }

    public static bool TryGetNext<T>(this LinkedListNode<T>? currentNode, [NotNullWhen(true)] out LinkedListNode<T>? next)
    {
        if (currentNode is null)
        {
            next = null;
            return false;
        }
        return (next = currentNode.Next) is not null;
    }

    public static bool TryGetNext<T>(this LinkedListNode<T>? currentNode, [NotNullWhen(true)] out LinkedListNode<T>? nextNode, [MaybeNullWhen(false)] out T nextValue)
    {
        if (currentNode is null)
            nextNode = null;
        else if ((nextNode = currentNode.Next) is not null)
        {
            nextValue = nextNode.Value;
            return true;
        }
        nextValue = default;
        return false;
    }

    public static bool TryGetPrevious<T>(this LinkedListNode<T>? currentNode, [NotNullWhen(true)] out LinkedListNode<T>? previous)
    {
        if (currentNode is null)
        {
            previous = null;
            return false;
        }
        return (previous = currentNode.Previous) is not null;
    }

    public static bool TryGetPrevious<T>(this LinkedListNode<T>? currentNode, [NotNullWhen(true)] out LinkedListNode<T>? previousNode, [MaybeNullWhen(false)] out T previousValue)
    {
        if (currentNode is null)
            previousNode = null;
        else if ((previousNode = currentNode.Previous) is not null)
        {
            previousValue = previousNode.Value;
            return true;
        }
        previousValue = default;
        return false;
    }

    public static void RemoveFollowing<T>(this LinkedListNode<T>? node)
    {
        if (node is not null)
        {
            var list = node.List;
            if (list is not null)
            {
                var next = node.Next;
                while (next is not null)
                    next = next.RemoveAndGetNext();
            }
        }
    }

    public static bool RemovePreceding<T>(this LinkedListNode<T>? node)
    {
        if (node is not null)
        {
            var list = node.List;
            if (list is not null)
            {
                var previous = node.Previous;
                while (previous is not null)
                    previous = previous.RemoveAndGetPrevious();
            }
        }
        return false;
    }

    public static LinkedListNode<T>? RemoveAndGetNext<T>(this LinkedListNode<T>? node)
    {
        if (node is null) return null;
        var list = node.List;
        if (list is null) return null;
        var result = node.Next;
        list.Remove(node);
        return result;
    }

    public static bool RemoveAndGetNext<T>(this LinkedListNode<T>? node, out LinkedListNode<T>? next)
    {
        if (node is null)
            next = null;
        else
        {
            var list = node.List;
            if (list is null)
                next = null;
            else if ((next = node.Next) is not null)
            {
                list.Remove(node);
                return true;
            }
        }
        return false;
    }

    public static bool RemoveAndGetNext<T>(this LinkedListNode<T>? node, [NotNullWhen(true)] out LinkedListNode<T>? next, [MaybeNullWhen(false)] out T value)
    {
        if (node is null)
            next = null;
        else
        {
            var list = node.List;
            if (list is null)
                next = null;
            else if ((next = node.Next) is not null)
            {
                list.Remove(node);
                value = next.Value;
                return true;
            }
        }
        value = default;
        return false;
    }

    public static LinkedListNode<T>? RemoveAndGetPrevious<T>(this LinkedListNode<T>? node)
    {
        if (node is null) return null;
        var list = node.List;
        if (list is null) return null;
        var result = node.Previous;
        list.Remove(node);
        return result;
    }

    public static bool RemoveAndGetPrevious<T>(this LinkedListNode<T>? node, out LinkedListNode<T>? previous)
    {
        if (node is null)
            previous = null;
        else
        {
            var list = node.List;
            if (list is null)
                previous = null;
            else if ((previous = node.Previous) is not null)
            {
                list.Remove(node);
                return true;
            }
        }
        return false;
    }

    public static bool RemoveAndGetPrevious<T>(this LinkedListNode<T>? node, [NotNullWhen(true)] out LinkedListNode<T>? previous, [MaybeNullWhen(false)] out T value)
    {
        if (node is null)
            previous = null;
        else
        {
            var list = node.List;
            if (list is null)
                previous = null;
            else if ((previous = node.Previous) is not null)
            {
                list.Remove(node);
                value = previous.Value;
                return true;
            }
        }
        value = default;
        return false;
    }

    public static bool SkipNextWhile<T>(this LinkedListNode<T> node, Func<T, bool> predicate, out LinkedListNode<T> resultNode, out T resultValue)
    {
        ArgumentNullException.ThrowIfNull(node);
        resultValue = (resultNode = node).Value;
        while (predicate(resultValue))
        {
            var prev = node.Next;
            if (prev is null) return false;
            resultValue = (resultNode = prev).Value;
        }
        return true;
    }

    public static bool SkipPreviousWhile<T>(this LinkedListNode<T> node, Func<T, bool> predicate, out LinkedListNode<T> resultNode, out T resultValue)
    {
        ArgumentNullException.ThrowIfNull(node);
        resultValue = (resultNode = node).Value;
        while (predicate(resultValue))
        {
            var prev = node.Previous;
            if (prev is null) return false;
            resultValue = (resultNode = prev).Value;
        }
        return true;
    }
}