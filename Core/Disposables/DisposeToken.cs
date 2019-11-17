using System;
using System.Threading;

namespace diconsole.Core // Microsoft.Python.Core
{
    public sealed class DisposeToken
    {
        private readonly Type _type;
        private readonly CancellationTokenSource _cts;
        private int _disposed;

        public CancellationToken CancellationToken { get; }

        public static DisposeToken Create<T>() where T : IDisposable
            => new DisposeToken(typeof(T));

        private DisposeToken(Type type)
        {
            _type = type;
            _cts = new CancellationTokenSource();
            CancellationToken = _cts.Token;
        }

        public bool IsDisposed => _cts.IsCancellationRequested;

        public void ThrowIfDisposed()
        {
            if (!_cts.IsCancellationRequested) {
                return;
            }
            throw CreateException();
        }

        private ObjectDisposedException CreateException() => new ObjectDisposedException(_type.Name, $"{_type.Name} instance is disposed.");
    }
}