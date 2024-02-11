using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDataGeneration;

public static class CollectionExtensionMethods
{
    public static LinkedListNode<T>? RemoveAndGetNext<T>(this LinkedListNode<T> node)
    {
        var list = node.List;
        if (list is null) return null;
        var result = node.Next;
        list.Remove(node);
        return result;
    }

    public static LinkedListNode<T>? RemoveAndGetPrevious<T>(this LinkedListNode<T> node)
    {
        var list = node.List;
        if (list is null) return null;
        var result = node.Previous;
        list.Remove(node);
        return result;
    }


}