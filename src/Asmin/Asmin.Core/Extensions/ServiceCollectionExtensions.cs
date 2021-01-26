using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Asmin.Core.Configuration.Context;
using Asmin.Core.Configuration.Environment;

namespace Asmin.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register core module dependencies to IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddCoreModule(this IServiceCollection services)
        {
            services.AddSingleton<IEnvironmentService, EnvironmentService>();
            services.AddSingleton<IAsminConfigurationContext, AsminConfigurationContext>();
        }
    }
}
