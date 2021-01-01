using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.Cachings.Redis.Configuration
{
    /// <summary>
    /// Redis server configuration 
    /// </summary>
    public class RedisConfiguration : IRedisConfiguration
    {
        /// <summary>
        /// Redis server hostname
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Redis server password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Redis server port
        /// </summary>
        public int Port { get; set; }
    }
}
