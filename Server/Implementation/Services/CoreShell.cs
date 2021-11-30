using System;
#if false
using diconsole.Core;
#endif

namespace diconsole.Server.Services
{
    #if false
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
    #endif
}