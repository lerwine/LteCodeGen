using System.Collections;

namespace TestDataGeneration;

public partial class LinkedSet<T> where T : LinkedSet<T>.Node, IComparable<T>, IEquatable<T>, ICloneable
{
    class Enumerator : IEnumerator<T>
    {
        private object _syncRoot;
        private object _changeToken;
        private LinkedSet<T>? _target;
        private T? _current;
        private bool _endOfEnumeration;
        public T Current
        {
            get
            {
                var result = _current;
                if (result is null) throw (_target is null) ? new ObjectDisposedException(nameof(Enumerator)) : new InvalidOperationException();
                return result;
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        internal Enumerator(LinkedSet<T> target)
        {
            ArgumentNullException.ThrowIfNull(target);
            _syncRoot = (_target = target).SyncRoot;
            _changeToken = target._changeToken;
        }

        public bool MoveNext()
        {
            Monitor.Enter(_syncRoot);
            try
            {
                if (_target is null) throw new ObjectDisposedException(nameof(Enumerator));
                if (_endOfEnumeration) return false;
                if (!ReferenceEquals(_changeToken, _target._changeToken)) throw new InvalidOperationException();
                if (_current is null)
                {
                    if ((_current = _target.First) is not null) return true;
                }
                else if ((_current = _current!.Next) is not null)
                    return true;
                _endOfEnumeration = true;
            }
            finally { Monitor.Exit(_syncRoot); }
            return false;
        }

        public void Reset()
        {
            Monitor.Enter(_syncRoot);
            try
            {
                if (_target is null) throw new ObjectDisposedException(nameof(Enumerator));
                _changeToken = _target._changeToken;
                _current = null;
            }
            finally { Monitor.Exit(_syncRoot); }
        }

        protected virtual void Dispose(bool disposing)
        {
            object syncRoot = _syncRoot;
            Monitor.Enter(syncRoot);
            try
            {
                if (_target is null || !ReferenceEquals(syncRoot, _syncRoot)) return;
                _target = null;
                _current = null;
                if (disposing) _syncRoot = new();
            }
            finally { Monitor.Exit(syncRoot); }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
