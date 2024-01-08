using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public class CharRangeSet : SequentialRangeSet<char>
    {
        public CharRangeSet() : base(CharRangeAccessors.Instance) { }
    }
    
    public class SByteRangeSet : SequentialRangeSet<sbyte>
    {
        public SByteRangeSet() : base(SByteRangeAccessors.Instance) { }
    }
    
    public class ByteRangeSet : SequentialRangeSet<byte>
    {
        public ByteRangeSet() : base(ByteRangeAccessors.Instance) { }
    }
    
    public class Int16RangeSet : SequentialRangeSet<short>
    {
        public Int16RangeSet() : base(Int16RangeAccessors.Instance) { }
    }
    
    public class UInt16RangeSet : SequentialRangeSet<ushort>
    {
        public UInt16RangeSet() : base(UInt16RangeAccessors.Instance) { }
    }
    
    public class Int32RangeSet : SequentialRangeSet<int>
    {
        public Int32RangeSet() : base(Int32RangeAccessors.Instance) { }
    }
    
    public class UInt32RangeSet : SequentialRangeSet<uint>
    {
        public UInt32RangeSet() : base(UInt32RangeAccessors.Instance) { }
    }
    
    public class In64RangeSet : SequentialRangeSet<long>
    {
        public In64RangeSet() : base(Int64RangeAccessors.Instance) { }
    }
    
    public class UIn64RangeSet : SequentialRangeSet<ulong>
    {
        public UIn64RangeSet() : base(UInt64RangeAccessors.Instance) { }
    }
}

public partial class SequentialRangeSet<T> : ICollection<SequentialRangeSet<T>.SequentialRange>, IReadOnlyList<SequentialRangeSet<T>.SequentialRange>, IList
    where T : struct
{

    public SequentialRange this[int index] => throw new NotImplementedException();

    object? IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IRangeSequenceAccessors<T> Accessors { get; }

    int ICollection<SequentialRange>.Count => Count();

    int IReadOnlyCollection<SequentialRange>.Count => Count();

    int ICollection.Count => Count();

    public SequentialRange? First { get; private set; }

    bool ICollection<SequentialRange>.IsReadOnly => false;

    bool IList.IsReadOnly => true;

    bool IList.IsFixedSize => false;

    bool ICollection.IsSynchronized => true;

    public SequentialRange? Last { get; private set; }
    
    public object SyncRoot { get; } = new();

    public SequentialRangeSet(IRangeSequenceAccessors<T> accessors)
    {
        ArgumentNullException.ThrowIfNull(accessors);
        Accessors = accessors;
    }

    public void Add(SequentialRange item)
    {
        throw new NotImplementedException();
    }

    int IList.Add(object? value)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(SequentialRange item)
    {
        throw new NotImplementedException();
    }

    bool IList.Contains(object? value)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(SequentialRange[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<SequentialRange> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    int IList.IndexOf(object? value)
    {
        throw new NotImplementedException();
    }

    void IList.Insert(int index, object? value)
    {
        throw new NotImplementedException();
    }

    public bool Remove(SequentialRange item)
    {
        throw new NotImplementedException();
    }

    void IList.Remove(object? value)
    {
        throw new NotImplementedException();
    }

    void IList.RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries to find the first item that includes or is greater than a specified value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <param name="previous">Returns the last <see cref="SequentialRange"/> where <see cref="SequentialRange.End"/> is less than <paramref name="value"/> or <see langword="null"/> if <see cref="Last"/> is null.</param>
    /// <param name="result">Returns the first <see cref="SequentialRange"/> where <see cref="SequentialRange.End"/> is not less than <paramref name="value"/> or <see langword="null"/>
    /// if <paramref name="value"/> is greater than all existing <see cref="SequentialRange.End"/> values.</param>
    /// <param name="includesValue"><see langword="true"/> if <paramref name="result"/> includes the <paramref name="value"/>; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="result"/> includes or is less than the <paramref name="value"/>; otherwise, <see langword="false"/>.</returns>
    private bool TryFindFirstIncludingOrAfter(T value, out SequentialRange? previous, [NotNullWhen(true)] out SequentialRange? result, out bool includesValue)
    {
        previous = null;
        for (result = First; result is not null; result = result.Next)
        {
            int diff = Accessors.Compare(value, result.Start);
            if (diff < 0)
            {
                // (previous is null || value > previous.End) && value < result.Start
                includesValue = false;
                return true;
            }
            if (diff == 0 || Accessors.Compare(value, result.End) <= 0)
            {
                // result.Contains(value)
                includesValue = true;
                return true;
            }
            previous = result;
        }
        // (previous is null || value > previous.End) && result is null
        includesValue = false;
        return false;
    }

    private bool TryFindFirstIncludingOrAfter(T value, [NotNullWhen(true)] out SequentialRange? result, out bool equalsExtent, out bool extentIsEnd)
    {
        for (result = First; result is not null; result = result.Next)
        {
            int diff = Accessors.Compare(value, result.Start);
            if (diff < 0)
            {
                equalsExtent = extentIsEnd = false;
                return true;
            }
            if (diff == 0)
            {
                extentIsEnd = false;
                equalsExtent = true;
            }
            if ((diff = Accessors.Compare(value, result.End)) < 0)
            {
                equalsExtent = false;
                extentIsEnd = true;
                return true;
            }
            if (diff == 0)
            {
                equalsExtent = extentIsEnd = true;
                return true;
            }
        }
        // (previous is null || value > previous.End) && result is null
        equalsExtent = extentIsEnd = false;
        return false;
    }

    /// <summary>
    /// Tries to get the next item includign the specified value.
    /// </summary>
    /// <param name="value">The value to look for.</param>
    /// <param name="start">The starting range.</param>
    /// <param name="result">The <see cref="SequentialRange"/> containing <paramref name="value"/> or the last <see cref="SequentialRange"/> where <see cref="SequentialRange.End"/> is less than <paramref name="value"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="result"/> includes contains <paramref name="value"/>; otherwise, <see langword="false"/> if <see cref="SequentialRange.End"/> is less than <paramref name="value"/>.</returns>
    private bool TryFindNextIncludingOrBefore(T value, SequentialRange start, out SequentialRange result)
    {

        result = start;
        int diff = Accessors.Compare(value, result.End);
        if (diff == 0) return true; // result.Contains(value)
        if (diff < 0)
        {
            if (Accessors.Compare(value, result.Start) < 0) throw new InvalidOperationException();
            // result.Contains(value)
            return true;
        }


        for (var next = result.Next; next is not null; next = next.Next)
        {
            if ((diff = Accessors.Compare(value, next.End)) == 0)
            {
                // result.Contains(value)
                result = next;
                return true;
            }
            if (diff < 0)
            {
                if (Accessors.Compare(value, next.Start) < 0) return false; // value > result.End
                result = next;
                // result.Contains(value)
                return true;
            }
            result = next;
        }
        // value > result.End
        return false;
    }
}
