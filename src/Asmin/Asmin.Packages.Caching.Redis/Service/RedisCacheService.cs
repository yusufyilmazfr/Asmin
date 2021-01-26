using System;
using Asmin.Packages.Caching.Redis.Server;
using Newtonsoft.Json;

namespace Asmin.Packages.Caching.Redis.Service
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IRedisServer _redisServer;

        public RedisCacheService(IRedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public void Add(string key, object data)
        {
            Add(key, data, expiry: -1, databaseId: 0);
        }

        public T Get<T>(string key)
        {
            return Get<T>(key, databaseId: 0);
        }

        public void Remove(string key)
        {
            Remove(key, databaseId: 0);
        }

        public bool Any(string key)
        {
            return Any(key, databaseId: 0);
        }

        public void Add(string key, object data, int expiry = 60, int databaseId = 0)
        {
            string parsedJsonData = JsonConvert.SerializeObject(data);

            _redisServer
                .GetDatabase(databaseId)
                .StringSet(key, parsedJsonData, TimeSpan.FromMinutes(expiry));
        }

        public T Get<T>(string key, int databaseId = 0)
        {
            string parsedJsonData = _redisServer.GetDatabase(databaseId).StringGet(key);
            return JsonConvert.DeserializeObject<T>(parsedJsonData);
        }

        public void Remove(string key, int databaseId = 0)
        {
            _redisServer.GetDatabase(databaseId).KeyDelete(key);
        }

        public bool Any(string key, int databaseId = 0)
        {
            return _redisServer.GetDatabase(databaseId).KeyExists(key);
        }

        public void AddHash(string hashKey, string key, object data, int databaseId = 0)
        {
            string parsedJsonData = JsonConvert.SerializeObject(data);

            _redisServer
                .GetDatabase(databaseId)
                .HashSet(hashKey, key, parsedJsonData);
        }

        public T GetHash<T>(string hashKey, string key, int databaseId = 0)
        {
            string parsedJsonData = _redisServer.GetDatabase(databaseId).HashGet(hashKey, key);
            return JsonConvert.DeserializeObject<T>(parsedJsonData);
        }

        public void RemoveHash(string hashKey, string key, int databaseId = 0)
        {
            _redisServer.GetDatabase(databaseId).HashDelete(hashKey, key);
        }
    }
}
