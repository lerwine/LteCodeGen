using System.Diagnostics.CodeAnalysis;

namespace TestDataGeneration;

public static partial class SequentialRangeSet
{
    public static bool AreEqual<T>(this IRangeSequenceAccessors<T> accessors, T x, T y) where T : struct => accessors.Compare(x, y) == 0;

    public static bool CanInsert<T>(this IRangeSequenceAccessors<T> accessors, T previous, T next) where T : struct => accessors.Compare(previous, next) < 0 && !accessors.IsSequentiallyAdjacent(previous, next);

    public static SequentialRangeSet<T>.RangeItem GetItemAt<T>(int index, SequentialRangeSet<T> rangeSet) where T : struct
    {
        ArgumentNullException.ThrowIfNull(rangeSet);
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        int pos = -1;
        foreach (var item in SequentialRangeSet<T>.RangeItem.GetRanges(rangeSet))
        {
            pos++;
            if (pos == index) return item;
        }
        throw new ArgumentOutOfRangeException(nameof(index));
    }

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
