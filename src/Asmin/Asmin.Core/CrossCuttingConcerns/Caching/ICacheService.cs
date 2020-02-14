using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int timeout);
        void RemoveByKey(string key);
        void RemoveByPattern(string pattern);
        bool Any(string key);
        void Clear();
    }
}
