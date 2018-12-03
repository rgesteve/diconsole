using System;
using System.Collections.Concurrent;

namespace Analyzer.Infrastructure {

    public sealed class DisposableBag
    {
        private readonly string _objectName;
        private readonly string _message;
	private ConcurrentStack<Action> _disposables;
    }

}