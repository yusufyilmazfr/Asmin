using Asmin.Core.DependencyModules;
using Asmin.Core.Utilities.IoC;
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
        public static void AddDependencyModules(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (ICoreModule module in modules)
            {
                module.Load(services);
            }

            DependencyServiceTool.CreateServiceProvider(services);
            RegisterRequiredDependencies(services);
        }

        public static void AddDependencyModules(this IServiceCollection services)
        {
            DependencyServiceTool.CreateServiceProvider(services);
            RegisterRequiredDependencies(services);
        }

        /// <summary>
        /// Register required services
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterRequiredDependencies(IServiceCollection services)
        {
            services.AddSingleton<IEnvironmentService, EnvironmentService>();
            services.AddSingleton<IAsminConfigurationContext, AsminConfigurationContext>();
        }
    }
}
