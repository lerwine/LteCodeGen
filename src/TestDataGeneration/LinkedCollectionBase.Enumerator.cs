using System.Collections;

namespace TestDataGeneration;

public partial class LinkedCollectionBase<TNode> where TNode : LinkedCollectionBase<TNode>.LinkedNode
{
    sealed class Enumerator : IEnumerator<TNode>
    {
        private readonly object _syncRoot;
        private object _changeToken;
        private LinkedCollectionBase<TNode>? _source;
        private bool _endOfEnumeration;

        public TNode Current { get; private set; } = null!;

        object IEnumerator.Current => Current;

        internal Enumerator(LinkedCollectionBase<TNode> source)
        {
            ArgumentNullException.ThrowIfNull(source);
            _syncRoot = (_source = source).SyncRoot;
            _changeToken = source._changeToken;
        }

        public bool MoveNext()
        {
            Monitor.Enter(_syncRoot);
            try
            {
                if (_source is null) throw new ObjectDisposedException(nameof(Enumerator));
                if (_endOfEnumeration) return false;
                if (!ReferenceEquals(_changeToken, _source._changeToken)) throw new InvalidOperationException("Collection has changed.");
                if ((Current = (Current is null) ? _source.First! : Current.Next!) is null)
                {
                    _endOfEnumeration = true;
                    return false;
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
                if (_source is null) throw new ObjectDisposedException(nameof(Enumerator));
                Current = null!;
                _endOfEnumeration = false;
                _changeToken = _source._changeToken;
            }
            finally { Monitor.Exit(_syncRoot); }
        }

        private void Dispose(bool disposing)
        {
            Monitor.Enter(_syncRoot);
            try
            {
                if (_source is null) return;
                _source = null;
            }
            finally { Monitor.Exit(_syncRoot); }
            if (disposing)
            {
                _changeToken = null!;
                Current = null!;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
