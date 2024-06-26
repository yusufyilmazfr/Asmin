﻿using Asmin.Packages.Caching.Core.Service;

namespace Asmin.Packages.Caching.Redis.Service
{
    /// <summary>
    /// Redis cache service interface provides some operations for Redis database
    /// </summary>
    public interface IRedisCacheService : ICacheService
    {
        /// <summary>
        /// Insert data to cache.
        /// </summary>
        /// <param name="key">Unique key name</param>
        /// <param name="data">Data</param>
        /// <param name="expiry">Expiration minutes</param>
        /// <param name="databaseId">Current database id</param>
        void Add(string key, object data, int expiry = 60, int databaseId = 0);
        /// <summary>
        /// Get data from cache.
        /// </summary>
        /// <typeparam name="T">Return element type</typeparam>
        /// <param name="key">Unique key name</param>
        /// <param name="databaseId">Current database id</param>
        /// <returns></returns>
        T Get<T>(string key, int databaseId = 0);
        /// <summary>
        /// Remove element from cache.
        /// </summary>
        /// <param name="key">Unique key name</param>
        /// <param name="databaseId">Current database id</param>
        void Remove(string key, int databaseId = 0);
        /// <summary>
        /// Check key exists in cache.
        /// </summary>
        /// <param name="key">Unique key name</param>
        /// <param name="databaseId">Current database</param>
        /// <returns></returns>
        bool Any(string key, int databaseId = 0);
        /// <summary>
        /// Insert data to cache.
        /// </summary>
        /// <param name="hashKey">Hash key name</param>
        /// <param name="key">Unique key name</param>
        /// <param name="data">Data</param>
        /// <param name="databaseId">Current database id</param>
        void AddHash(string hashKey, string key, object data, int databaseId = 0);
        /// <summary>
        /// Get data from cache.
        /// </summary>
        /// <typeparam name="T">Return element type</typeparam>
        /// <param name="hashKey">Hash key name</param>
        /// <param name="key">Unique key name</param>
        /// <param name="databaseId">Current database id</param>
        /// <returns></returns>
        T GetHash<T>(string hashKey, string key, int databaseId = 0);
        /// <summary>
        /// Remove element from cache.
        /// </summary>
        /// <param name="hashKey">Hash key name</param>
        /// <param name="key">Unique key name</param>
        /// <param name="databaseId">Current database id</param>
        void RemoveHash(string hashKey, string key, int databaseId = 0);
    }
}
