using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.Cachings.Redis.Configuration
{
    /// <summary>
    /// Redis server configuration 
    /// </summary>
    public interface IRedisConfiguration
    {
        /// <summary>
        /// Redis server hostname
        /// </summary>
        string Host { get; set; }
        /// <summary>
        /// Redis server password
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Redis server port
        /// </summary>
        int Port { get; set; }
    }
}
