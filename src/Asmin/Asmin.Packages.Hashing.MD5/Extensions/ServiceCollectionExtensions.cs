using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.Hashing.Core.Service;
using Asmin.Packages.Hashing.MD5.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Asmin.Packages.Hashing.MD5.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register MD5 hash dependencies.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMD5(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, MD5HashService>();

            return services;
        }
    }
}
