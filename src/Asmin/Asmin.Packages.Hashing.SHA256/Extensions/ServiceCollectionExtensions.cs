using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Packages.Hashing.Core.Service;
using Asmin.Packages.Hashing.SHA256.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Asmin.Packages.Hashing.SHA256.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register SHA256 hash dependencies.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSHA256(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, SHA256HashService>();

            return services;
        }
    }
}
