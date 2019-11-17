using System;
using diconsole.Core;

namespace diconsole.Server.Services
{
    internal sealed class CoreShell : IDisposable
    {
        private static CoreShell _instance;
        public static CoreShell current => _instance;

        IServiceManager ServiceManager { get; } = new ServiceManager();

        public void Dispose()
        {
            // empty
        }
    }
}