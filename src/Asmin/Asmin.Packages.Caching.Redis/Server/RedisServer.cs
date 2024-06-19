using System;
using Asmin.Packages.Caching.Redis.Configuration;
using StackExchange.Redis;

namespace Asmin.Packages.Caching.Redis.Server
{
    /// <summary>
    /// Redis Server
    /// </summary>
    public class RedisServer : IRedisServer
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisServer(IRedisConfiguration redisConfiguration)
        {
            string connectionString = CreateRedisConfigurationString(redisConfiguration);

            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);

            if (!_connectionMultiplexer.IsConnected)
            {
                throw new Exception($"ConnectionMultiplexer didn't connect! Please check configuration settings in {redisConfiguration.GetType().Name}");
            }
        }

        /// <summary>
        /// Get specified database instance from current database id
        /// </summary>
        /// <param name="databaseId">database id, id must greater than or equal to 0 and less than or equal to 15</param>
        /// <returns></returns>
        public IDatabase GetDatabase(int databaseId)
        {
            if (databaseId < 0) throw new ArgumentException("Database id must greater than or equal to 0.");
            if (databaseId > 15) throw new ArgumentException("Database id must less than or equal to 15.");

            return _connectionMultiplexer.GetDatabase(databaseId);
        }

        /// <summary>
        /// Generate configuration string
        /// </summary>
        /// <param name="redisConfiguration"></param>
        /// <returns></returns>
        private string CreateRedisConfigurationString(IRedisConfiguration redisConfiguration)
        {
            if (redisConfiguration.Host == default || redisConfiguration.Password == default || redisConfiguration.Port == default)
            {
                throw new Exception($"Redis configuration information can not be null. Please check {redisConfiguration.GetType().Name}");
            }

            return $"{redisConfiguration.Host}:{redisConfiguration.Port},password={redisConfiguration.Password}";
        }
    }
}
