using Asmin.Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Asmin.Core.CrossCuttingConcerns.Caching.MicrosoftMemoryCache
{
    public class MemoryCacheService : ICacheService
    {
        private IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Add(string key, object data, int timeout)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(timeout));
        }

        public bool Any(string key)
        {
            return Get(key) != null;
        }

        public void Clear()
        {
            RemoveByPattern("*");
        }

        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public object Get(string key)
        {
            return Get<object>(key);
        }

        public void RemoveByKey(string key)
        {
            if (Any(key))
            {
                _cache.Remove(key);
            }
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionInfo = typeof(MemoryCache)
                .GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);

            var cacheEntriesCollection = cacheEntriesCollectionInfo.GetValue(_cache) as dynamic;

            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

            foreach (var cacheEntry in cacheEntriesCollection)
            {
                var key = cacheEntry.GetType().GetProperty("Key").GetValue(cacheEntry);

                if (regex.IsMatch(key))
                {
                    RemoveByKey(key);
                }
            }

        }
    }
}
