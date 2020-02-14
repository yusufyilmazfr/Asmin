using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Utilities.IoC
{
    public static class DependencyServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void CreateServiceProvider(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
