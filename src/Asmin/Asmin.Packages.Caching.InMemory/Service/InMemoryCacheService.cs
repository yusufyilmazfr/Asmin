using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.Caching.Core.Service;
using Microsoft.Extensions.Caching.Memory;

namespace Asmin.Packages.Caching.InMemory.Service
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object data)
        {
            _memoryCache.Set(key, data);
        }

        public T Get<T>(string key)
        {
            _memoryCache.TryGetValue(key, out T returnData);
            return returnData;
        }

        public void Remove(string key)
        {
            if (Any(key))
            {
                _memoryCache.Remove(key);
            }
        }

        public bool Any(string key)
        {
            return _memoryCache.TryGetValue(key, out object data);
        }
    }
}
