using System.Collections;

namespace TestDataGeneration
{
    public partial class ValueRangeSet<T> where T : struct
    {
        class ValueEnumerator : IEnumerator<T>
        {
            private object _changeToken;
            private readonly object _syncRoot;
            private ValueRangeSet<T>? _source;
            private IEnumerator<T>? _currentEnumerator;
            private ValueRangeSet<T>.ValueRange? _currentRange;
            private bool _endOfEnumeration = false;

            public T Current => (_currentEnumerator is null) ? default : _currentEnumerator.Current;
            
            object IEnumerator.Current => Current;

            internal ValueEnumerator(ValueRangeSet<T> source)
            {
                _changeToken = (_source = source)._changeToken;
                _syncRoot = source.SyncRoot;
            }

            public void Dispose()
            {
                Monitor.Enter(_syncRoot);
                try
                {
                    _currentRange = null!;
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
                    if (!ReferenceEquals(_changeToken, _source._changeToken)) throw new InvalidOperationException("Collection has changed.");
                    if (_currentEnumerator is null || !_currentEnumerator.MoveNext())
                    {
                        if ((_currentRange = (_currentRange is null) ? _source.First! : _currentRange.Next!) is null)
                        {
                            _endOfEnumeration = true;
                            return false;
                        }
                        _currentEnumerator = _currentRange.GetEnumerator();
                        _currentEnumerator.MoveNext();
                    }
                }
                finally { Monitor.Exit(_syncRoot); }
                return true;
            }

            public void Reset()
            {
                Monitor.Enter(_syncRoot);
                try
                {
                    if (_source is null) throw new ObjectDisposedException(nameof(RangeEnumerator));
                    _currentRange = null;
                    _currentEnumerator = null;
                    _endOfEnumeration = false;
                    _changeToken = _source._changeToken;
                }
                finally { Monitor.Exit(_syncRoot); }
            }
        }
    }
}