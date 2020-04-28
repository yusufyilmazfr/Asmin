using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.CrossCuttingConcerns.Caching.RedisCache
{
    class RedisServer
    {
        private IDatabase _database;
        private int _currentDatabaseId = 0;
        private static string _configurationString = String.Empty;
        private ConnectionMultiplexer _connectionMultiplexer;

        private object _lockObject = new object();

        public IDatabase Database => _database;

        public RedisServer(IConfiguration configuration)
        {
            CreateRedisConfigurationStringAsSingleton(configuration);

            _connectionMultiplexer = ConnectionMultiplexer.Connect(_configurationString);

            if (!_connectionMultiplexer.IsConnected)
            {
                throw new Exception("ConnectionMultiplexer not connected! Please check configuration settings in appsettings.json");
            }

            _database = _connectionMultiplexer.GetDatabase(_currentDatabaseId);
        }

        public void ClearAllKey()
        {
            _connectionMultiplexer.GetServer(_configurationString).FlushDatabase(_currentDatabaseId);
        }

        public IEnumerable<RedisKey> GetAllKeys()
        {
            return _connectionMultiplexer.GetServer(_configurationString).Keys(_currentDatabaseId);
        }

        private void CreateRedisConfigurationStringAsSingleton(IConfiguration configuration)
        {
            if (_configurationString == String.Empty)
            {
                lock (_lockObject)
                {
                    if (_configurationString == String.Empty)
                    {
                        var redisHostConfigurationSection = configuration.GetSection("RedisConfiguration:Host");
                        var redisPortConfigurationSection = configuration.GetSection("RedisConfiguration:Port");

                        if (redisHostConfigurationSection == null || redisPortConfigurationSection == null)
                        {
                            throw new Exception("Redis configuration informations can not be null. Please check appsettings.json file.");
                        }

                        _configurationString = $"{redisHostConfigurationSection.Value}:{redisPortConfigurationSection.Value}";
                    }
                }
            }
        }
    }
}
