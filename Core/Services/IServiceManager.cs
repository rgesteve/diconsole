using System;

namespace diconsole.Core // Microsoft.Python.Core
{
    public interface IServiceManager : IServiceContainer, IDisposable
    {
        IServiceManager AddService(object service, Type type = null);
        IServiceManager AddService<T>(Func<IServiceContainer, T> factory) where T : class;
        void RemoveService(object service);

    }
} 