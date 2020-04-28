using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Asmin.Core.CrossCuttingConcerns.Caching.RedisCache
{
    class RedisMemoryCacheService : ICacheService
    {
        private readonly RedisServer _redisServer;

        public RedisMemoryCacheService(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public void Add(string key, object data, int timeout)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            _redisServer.Database.StringSet(key, jsonData, TimeSpan.FromMinutes(timeout));
        }

        public bool Any(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public void Clear()
        {
            _redisServer.ClearAllKey();
        }

        public T Get<T>(string key)
        {
            if (Any(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default(T);
        }

        public object Get(string key)
        {
            return Get<object>(key);
        }

        public void RemoveByKey(string key)
        {
            if (Any(key))
            {
                _redisServer.Database.KeyDelete(key);
            }
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

            foreach (string key in _redisServer.GetAllKeys())
            {
                if (regex.IsMatch(key))
                {
                    RemoveByKey(key);
                }
            }
        }
    }
}
