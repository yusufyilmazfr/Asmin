using System;
using Asmin.Packages.Caching.Redis.Configuration;
using Asmin.Packages.Caching.Redis.Server;
using Asmin.Packages.Caching.Redis.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Asmin.Packages.Caching.Redis.Extensions
{
    /// <summary>
    /// Add Redis cache service dependencies
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register Redis dependencies to IServiceCollection
        /// </summary>
        /// <param name="services">IServiceCollection instance</param>
        /// <param name="configuration">RedisConfiguration instance</param>
        /// <returns></returns>
        public static IServiceCollection AddRedis(this IServiceCollection services, Action<IRedisConfiguration> configuration)
        {
            IRedisConfiguration redisConfiguration = new RedisConfiguration();
            configuration.Invoke(redisConfiguration);

            services.AddSingleton<IRedisConfiguration>(redisConfiguration);

            services.AddSingleton<IRedisCacheService, RedisCacheService>();

            services.AddSingleton<IRedisServer, RedisServer>();

            return services;
        }
    }
}
