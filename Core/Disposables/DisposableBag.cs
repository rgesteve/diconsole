using System;
using System.Threading;
using System.Collections.Concurrent;

namespace diconsole.Core // Microsoft.Python.Core
{
    public sealed class DisposableBag
    {
        private readonly string _objectName;
        private readonly string _message;
        private ConcurrentStack<Action> _disposables;

        public DisposableBag(string objectName, string message = null)
        {
            _objectName  = objectName;
            _message     = message;
            _disposables = new ConcurrentStack<Action>();
        }

        private static DisposableBag Create(Type type) => new DisposableBag(type.Name, FormattableString.Invariant($"{type.Name} instance is disposed"));
        public static DisposableBag Create(IDisposable instance) => Create(instance.GetType());
        public static DisposableBag Create<T>() where T : IDisposable => Create(typeof(T));

        public bool TryAdd(Action action)
        {
            _disposables?.Push(action);
            return _disposables != null;
        }

        public bool TryDispose()
        {
            var disposables = Interlocked.Exchange(ref _disposables, null);
            if (disposables == null) {
                return false;
            }
            foreach (var disposable in disposables) {
                disposable();
            }
            return true;
        }
        public bool IsDisposed => _disposables == null;
    }
}