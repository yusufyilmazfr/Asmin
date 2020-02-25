using Asmin.Core.DependencyModules;
using Asmin.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public static void AddDependencyModules(this IServiceCollection services)
        {
            DependencyServiceTool.CreateServiceProvider(services);
        }
    }
}
