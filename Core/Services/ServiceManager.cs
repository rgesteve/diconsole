using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace diconsole.Core // Microsoft.Python.Core
{

    public sealed class ServiceManager : IServiceManager
    {
        private readonly DisposeToken _disposeToken = DisposeToken.Create<ServiceManager>();
        private readonly ConcurrentDictionary<Type, object> _s = new ConcurrentDictionary<Type, object>();
        public IServiceManager AddService(object service, Type type = null)
        {
            _disposeToken.ThrowIfDisposed();
            type = type?? service.GetType();
            Check.ArgumentNotNull(nameof(service), service);
            Check.InvalidOperation(() => {
                return (_s.GetOrAdd(type, service) == service);
            }, $"Another instance of service of type {type} already registered" );
            return this;
        }

        public IServiceManager AddService<T>(Func<IServiceContainer,T> factory) where T : class
        {
            _disposeToken.ThrowIfDisposed();

            var lazy = new Lazy<object>(() => factory(this));
            Check.InvalidOperation( () => {
                return (_s.TryAdd(typeof(T), lazy));
            }, $"Service of type {typeof(T)} already exists.");
            return this;
        }

        public T GetService<T>(Type type = null) where T : class
        {
            if (_disposeToken.IsDisposed) {
                return null;
            }
            type = type ?? typeof(T);
            #if false
            if (!_s.TryGetValue(type, out var value)) {
                value = _s.FirstOrDefault( kvp => type.GetTypeInfo().IsAssignableFrom );
            }
            #endif
            return null;
        }

        public void RemoveService(object service)
        {
            _s.TryRemove(service.GetType(), out var /* unused */ dummy);
        }

        public IEnumerable<Type> AllServices => _s.Keys.ToList();

        public void Dispose()
        {
            // TODO
        }
    }    

}