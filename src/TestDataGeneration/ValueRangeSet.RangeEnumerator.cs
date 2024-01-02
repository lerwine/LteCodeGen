using System.Collections;

namespace TestDataGeneration
{
    public partial class ValueRangeSet<T> where T : struct
    {
        class RangeEnumerator : IEnumerator<ValueRange>
        {
            private object _changeToken;
            private readonly object _syncRoot;
            private ValueRangeSet<T>? _source;
            private bool _endOfEnumeration = false;

            public ValueRangeSet<T>.ValueRange Current { get; private set; } = null!;

            object IEnumerator.Current => Current;

            internal RangeEnumerator(ValueRangeSet<T> source)
            {
                _changeToken = (_source = source)._changeToken;
                _syncRoot = source.SyncRoot;
            }

            public void Dispose()
            {
                Monitor.Enter(_syncRoot);
                try
                {
                    Current = null!;
                    _source = null;
                }
                finally { Monitor.Exit(_syncRoot); }
            }

            public bool MoveNext()
            {
                Monitor.Enter(_syncRoot);
                try
                {
                    if (_source is null) throw new ObjectDisposedException(nameof(RangeEnumerator));
                    if (_endOfEnumeration) return false;
                    if ((Current = (Current is null) ? _source.First! : Current.Next!) is not null) return true;
                    _endOfEnumeration = true;
                    return false;
                }
                finally { Monitor.Exit(_syncRoot); }
            }

            public void Reset()
            {
                Monitor.Enter(_syncRoot);
                try
                {
                    if (_source is null) throw new ObjectDisposedException(nameof(RangeEnumerator));
                    Current = null!;
                    _endOfEnumeration = false;
                    _changeToken = _source._changeToken;
                }
                finally { Monitor.Exit(_syncRoot); }
            }
        }
    }
}