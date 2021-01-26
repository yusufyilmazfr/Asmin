using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace Asmin.Packages.Caching.Redis.Server
{
    public interface IRedisServer
    {
        /// <summary>
        /// Get specified database instance from current database id
        /// </summary>
        /// <param name="databaseId">database id, id must greater than or equal to 0 and less than or equal to 15</param>
        /// <returns></returns>
        public IDatabase GetDatabase(int databaseId);
    }
}
