using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.Caching.Core.Service;
using Asmin.Packages.Caching.InMemory.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Asmin.Packages.Caching.InMemory.Extension
{
    /// <summary>
    /// Add in memory cache service dependencies
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register in memory caching dependencies to IServiceCollection
        /// </summary>
        /// <param name="services">IServiceCollection instance</param>
        /// <returns></returns>
        public static IServiceCollection AddRedis(this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddSingleton<ICacheService, InMemoryCacheService>();

            return services;
        }
    }
}
