using System;
using diconsole.Core;

namespace diconsole.Server.Services
{
    internal sealed class CoreShell : ICoreShell, IDisposable
    {
        private static CoreShell _instance;
        public static CoreShell Current => _instance;

        public IServiceManager ServiceManager { get; } = new ServiceManager();

        // Implements ICoreShell
        public IServiceContainer Services => ServiceManager;

        public static IDisposable Create()
        {
            Check.InvalidOperation(() => _instance == null);
            _instance = new CoreShell();
            return _instance;
        }

        private CoreShell()
        {
            ServiceManager.AddService(this);
        }

        public void Dispose()
        {
            ServiceManager?.RemoveService(this);
            ServiceManager?.Dispose();
        }
    }
}