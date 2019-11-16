using System;

namespace diconsole.Core // Microsoft.Python.Core
{
    public interface IServiceCollection
    {
        T GetService<T>(Type type = null) where T : class;
    }
} 