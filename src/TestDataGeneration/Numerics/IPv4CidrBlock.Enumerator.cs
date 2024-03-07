using System.Collections;

namespace TestDataGeneration.Numerics;

public partial class IPv4CidrBlock
{
    sealed class Enumerator : IEnumerator<IPv4Address>
    {
        private readonly IPv4Address _first;
        private readonly IPv4Address _last;
        private bool _started;
        private bool _endOfEnumeration;
        private bool _isDisposed;

        public IPv4Address Current { get; private set; }

        object IEnumerator.Current => Current;

        internal Enumerator(IPv4CidrBlock target) => (_first, _last) = (target.First, target.Last);

        public bool MoveNext()
        {
            if (_isDisposed) throw new ObjectDisposedException(nameof(Enumerator));
            if (_endOfEnumeration) return false;
            if (_started)
                Current++;
            else
                Current = _first;
            if (Current == _last)
                _endOfEnumeration = true;
            return true;
        }

        public void Reset()
        {
            if (_isDisposed) throw new ObjectDisposedException(nameof(Enumerator));
            _endOfEnumeration = _started = false;
        }

        public void Dispose() => _isDisposed = true;
    }
}