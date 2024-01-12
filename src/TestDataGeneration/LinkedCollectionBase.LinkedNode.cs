
namespace TestDataGeneration;

public partial class LinkedCollectionBase<TNode> where TNode : LinkedCollectionBase<TNode>.LinkedNode
{
    public class LinkedNode
    {
        protected object SyncRoot { get; } = new();

        public LinkedCollectionBase<TNode>? Owner { get; private set; }

        public TNode? Previous { get; private set; }
        
        public TNode? Next { get; private set; }

        private void CheckCanInsert(TNode? after, TNode? before, LinkedCollectionBase<TNode> linkedCollection)
        {
            var changeToken = linkedCollection._changeToken;
            AssertCanInsert(after, before, linkedCollection);
            if (!ReferenceEquals(changeToken, linkedCollection._changeToken))
                throw new InvalidOperationException("Collection has changed before insertion had completed.");
        }

        protected virtual void AssertCanInsert(TNode? after, TNode? before, LinkedCollectionBase<TNode> linkedCollection)
        {
            if (Owner is null) return;
            throw new InvalidOperationException(ReferenceEquals(Owner, linkedCollection) ? "Item has already been added to this collection." :
                "Item has been added to another collection.");
        }

        internal void AddFirst(LinkedCollectionBase<TNode> linkedCollection)
        {
            ArgumentNullException.ThrowIfNull(linkedCollection);
            Monitor.Enter(SyncRoot);
            try
            {
                CheckCanInsert(null, linkedCollection.First, linkedCollection);
                Monitor.Enter(linkedCollection.SyncRoot);
                try
                {
                    if ((Next = linkedCollection.First) is null)
                    {
                        linkedCollection.Last = (TNode)this;
                        linkedCollection.Count = 1;
                    }
                    else
                    {
                        Next.Previous = (TNode)this;
                        linkedCollection.Count++;
                    }
                    linkedCollection.First = (TNode)this;
                    Owner = linkedCollection;
                    linkedCollection._changeToken = new();
                }
                finally { Monitor.Exit(linkedCollection.SyncRoot); }
            }
            finally { Monitor.Exit(SyncRoot); }
        }

        internal void AddLast(LinkedCollectionBase<TNode> linkedCollection)
        {
            ArgumentNullException.ThrowIfNull(linkedCollection);
            Monitor.Enter(SyncRoot);
            try
            {
                CheckCanInsert(linkedCollection.Last, null, linkedCollection);
                Monitor.Enter(linkedCollection.SyncRoot);
                try
                {
                    if ((Previous = linkedCollection.Last) is null)
                    {
                        linkedCollection.First = (TNode)this;
                        linkedCollection.Count = 1;
                    }
                    else
                    {
                        Previous.Next = (TNode)this;
                        linkedCollection.Count++;
                    }
                    linkedCollection.Last = (TNode)this;
                    Owner = linkedCollection;
                    linkedCollection._changeToken = new();
                }
                finally { Monitor.Exit(linkedCollection.SyncRoot); }
            }
            finally { Monitor.Exit(SyncRoot); }
        }

        internal static void Clear(LinkedCollectionBase<TNode> linkedCollection)
        {
            ArgumentNullException.ThrowIfNull(linkedCollection);
            Monitor.Enter(linkedCollection.SyncRoot);
            try
            {
                LinkedNode? previous = linkedCollection.First;
                if (previous is null) return;
                linkedCollection._changeToken = new();
                linkedCollection.First = linkedCollection.Last = null;
                linkedCollection.Count = 0;
                LinkedNode? next = previous.Next;
                while (next is not null)
                {
                    previous.Owner = null;
                    previous.Next = null;
                    next.Previous = null;
                    next = (previous = next).Next;
                }
                previous.Owner = null;
            }
            finally { Monitor.Exit(linkedCollection.SyncRoot); }
        }

        internal static bool Contains(TNode item, LinkedCollectionBase<TNode> linkedCollection)
        {
            if (item is null) return false;
            ArgumentNullException.ThrowIfNull(linkedCollection);
            Monitor.Enter(item.SyncRoot);
            try
            {
                return item.Owner is not null && ReferenceEquals(item.Owner, linkedCollection);
            }
            finally { Monitor.Exit(item.SyncRoot); }
        }

        internal static int IndexOf(TNode item, LinkedCollectionBase<TNode> linkedCollection)
        {
            if (item is null) return -1;
            ArgumentNullException.ThrowIfNull(linkedCollection);
            Monitor.Enter(item.SyncRoot);
            try
            {
                if (item.Owner is not null && ReferenceEquals(item.Owner, linkedCollection))
                {
                    Monitor.Enter(linkedCollection.SyncRoot);
                    try
                    {
                        int index = -1;
                        for (var node = linkedCollection.First; node is not null; node = node.Next)
                        {
                            index++;
                            if (ReferenceEquals(node, item)) return index;
                        }
                    }
                    finally { Monitor.Exit(linkedCollection.SyncRoot); } 
                }
            }
            finally { Monitor.Exit(item.SyncRoot); }
            return -1;
        }

        internal static void InsertAfter(TNode item, TNode refItem, LinkedCollectionBase<TNode> linkedCollection)
        {
            ArgumentNullException.ThrowIfNull(item);
            ArgumentNullException.ThrowIfNull(refItem);
            ArgumentNullException.ThrowIfNull(linkedCollection);
            if (ReferenceEquals(item, refItem)) throw new InvalidOperationException("Item cannot be inserted along side of itself.");
            Monitor.Enter(refItem.SyncRoot);
            try
            {
                if (refItem.Owner is null || !ReferenceEquals(refItem.Owner, linkedCollection))
                    throw new InvalidOperationException("Reference item does not belong to the target collection.");
                Monitor.Enter(item.SyncRoot);
                try
                {
                    item.CheckCanInsert(refItem, refItem.Next, linkedCollection);
                    Monitor.Enter(linkedCollection.SyncRoot);
                    try
                    {
                        if ((item.Next = refItem.Next) is null)
                            linkedCollection.Last = item;
                        else
                            item.Next.Previous = item;
                        (item.Previous = refItem).Next = item;
                        item.Owner = linkedCollection;
                        linkedCollection.Count++;
                        linkedCollection._changeToken = new();
                    }
                    finally { Monitor.Exit(linkedCollection.SyncRoot); } 
                }
                finally { Monitor.Exit(item.SyncRoot); }
            }
            finally { Monitor.Exit(refItem.SyncRoot); }
        }

        internal static void InsertBefore(TNode item, TNode refItem, LinkedCollectionBase<TNode> linkedCollection)
        {
            ArgumentNullException.ThrowIfNull(item);
            ArgumentNullException.ThrowIfNull(refItem);
            ArgumentNullException.ThrowIfNull(linkedCollection);
            if (ReferenceEquals(item, refItem)) throw new InvalidOperationException("Item cannot be inserted along side of itself.");
            Monitor.Enter(refItem.SyncRoot);
            try
            {
                if (refItem.Owner is null || !ReferenceEquals(refItem.Owner, linkedCollection))
                    throw new InvalidOperationException("Reference item does not belong to the target collection.");
                Monitor.Enter(item.SyncRoot);
                try
                {
                    item.CheckCanInsert(refItem.Previous, refItem, linkedCollection);
                    Monitor.Enter(linkedCollection.SyncRoot);
                    try
                    {
                        if ((item.Previous = refItem.Previous) is null)
                            linkedCollection.First = item;
                        else
                            item.Previous.Next = item;
                        (item.Next  = refItem).Previous = item;
                        item.Owner = linkedCollection;
                        linkedCollection.Count++;
                        linkedCollection._changeToken = new();
                    }
                    finally { Monitor.Exit(linkedCollection.SyncRoot); }
                }
                finally { Monitor.Exit(item.SyncRoot); }
            }
            finally { Monitor.Exit(refItem.SyncRoot); }
        }

        private void Unlink(LinkedCollectionBase<TNode> linkedCollection)
        {
            if (Previous is null)
            {
                if ((linkedCollection.First = Next) is null)
                {
                    linkedCollection.Last = null;
                    linkedCollection.Count = 0;
                }
                else
                {
                    Next!.Previous = null;
                    Next = null;
                    linkedCollection.Count--;
                }
            }
            else
            {
                if ((Previous.Next = Next) is null)
                    linkedCollection.Last = Previous;
                else
                {
                    Next!.Previous = Previous;
                    Next = null;
                }
                Previous = null;
                linkedCollection.Count--;
            }
            Owner = null;
            linkedCollection._changeToken = new();
        }

        protected bool Unlink()
        {
            Monitor.Enter(SyncRoot);
            try
            {
                var linkedCollection = Owner;
                if (linkedCollection is null) return false;
                Monitor.Enter(linkedCollection.SyncRoot);
                try { Unlink(linkedCollection); }
                finally { Monitor.Exit(linkedCollection.SyncRoot); }
            }
            finally { Monitor.Exit(SyncRoot); }
            return true;
        }

        internal static bool Unlink(TNode item, LinkedCollectionBase<TNode> linkedCollection)
        {
            ArgumentNullException.ThrowIfNull(linkedCollection);
            if (item is null) return false;
            Monitor.Enter(item.SyncRoot);
            try
            {
                if (item.Owner is null || !ReferenceEquals(item.Owner, linkedCollection)) return false;
                Monitor.Enter(linkedCollection.SyncRoot);
                try { item.Unlink(linkedCollection); }
                finally { Monitor.Exit(linkedCollection.SyncRoot); }
            }
            finally { Monitor.Exit(item.SyncRoot); }
            return true;
        }
    }
}
