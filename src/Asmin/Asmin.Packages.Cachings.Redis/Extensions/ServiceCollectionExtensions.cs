using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.Cachings.Redis.Configuration;
using Asmin.Packages.Cachings.Redis.Server;
using Asmin.Packages.Cachings.Redis.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Asmin.Packages.Cachings.Redis.Extensions
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
        public static IServiceCollection AddRedisCacheService(this IServiceCollection services, Func<RedisConfiguration> configuration)
        {
            RedisConfiguration redisConfigurationInstance = configuration.Invoke();

            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddSingleton(typeof(IRedisConfiguration), redisConfigurationInstance);
            services.AddSingleton<RedisServer>();

            return services;
        }
    }
}
