using System;

#if false

namespace diconsole.Implementation
{
    public sealed class LanguageServer : IDisposable
    {
		private readonly Server _server = new Server();
        private readonly object _lock = new object();

		public void Dispose()
		{
		  // empty
		}
    }
}

#endif