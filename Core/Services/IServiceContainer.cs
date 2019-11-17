using System;

namespace diconsole.Core // Microsoft.Python.Core
{
    public interface IServiceContainer
    {
        T GetService<T>(Type type = null) where T : class;
    }
} 