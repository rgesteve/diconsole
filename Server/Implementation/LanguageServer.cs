using System;
using System.Threading;

using StreamJsonRpc;

using diconsole.Core;
//using diconsole.Implementation;

namespace diconsole.Implementation
{
    public sealed class LanguageServer : IDisposable
    {

		private Server _server;
#if false
        private readonly object _lock = new object();
#else
		private readonly DisposableBag _disposables = new DisposableBag(nameof(LanguageServer));
		private readonly CancellationTokenSource _sessionTokenSource = new CancellationTokenSource();
		private readonly CancellationTokenSource _shutdownCts = new CancellationTokenSource();
		private IServiceManager _services;

		private JsonRpc _rpc;
#endif

		public CancellationToken Start(IServiceManager services, JsonRpc rpc)
		{
			_server = new Server(services);
			_services = services;
			_rpc = rpc;

			return _sessionTokenSource.Token;
		}

		public void Dispose()
		{
		  // TODO
		}
    }
}
